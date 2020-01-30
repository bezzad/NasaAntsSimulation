using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using Simulation.Enums;
using Simulation.Roles;
using Simulation.Scenario;
using Simulation.Tools;

namespace Simulation.Core
{
    public class Container
    {
        public Container(Configuration config)
        {
            Config = config;
            TeamList = new List<Team>();
            MessengerList = new List<Messenger>();
            RulerList = new List<Ruler>();
            AreaArray = new List<Area>();
            ContainerMedia = new Media(Config, this);
            Time.GlobalSimulationTime = 0;

            var oneTeamArea = Math.Pow(Config.TeamOrganizationRadius, 2) * Math.PI;
            if (Config.TeamsCount * oneTeamArea >= Config.UpperBoarder.X * config.UpperBoarder.Y)
            {
                Debug.WriteLine("This number of teams, can not fill in this environment.");
                Config.TeamsCount = (int)Math.Floor(Config.UpperBoarder.X * config.UpperBoarder.Y / oneTeamArea) - 5;
            }
            for (var iOrgCount = 0; iOrgCount < Config.TeamsCount; iOrgCount++)
            {
                var orgBoundary = InitialOrgBoundries(TeamList);
                TeamList.Add(new Team(Config, TeamList.Count, Config.WorkersCount, orgBoundary, this));
            }
            InitializeAreas();
            CreateMessengers();
            CreateRulers();
        }


        protected Configuration Config { get; }
        protected List<Event> EventQueue { get; } = new List<Event>();
        public Media ContainerMedia { set; get; }
        public List<Team> TeamList { get; set; }
        public List<Messenger> MessengerList { get; set; }
        public List<Ruler> RulerList { get; set; }
        public List<Area> AreaArray { get; set; }


        private void InitializeAreas()
        {
            var areaLen = Config.TeamOrganizationRadius * 4;
            for (double ix = 0; ix <= Config.UpperBoarder.X; ix += areaLen)
            {
                for (double iy = 0; iy <= Config.UpperBoarder.Y; iy += areaLen)
                {
                    var tempArea = new Area { MinX = ix, MinY = iy, MaxX = ix + areaLen, MaxY = iy + areaLen };
                    AreaArray.Add(tempArea);
                }
            }
        }

        public void CreateMessengers()
        {
            for (var i = 0; i < AreaArray.Count; i++)
            {
                for (var j = 0; j < Config.MessengersCount / AreaArray.Count; j++)
                {

                    var tempPosition = SetAgentPosition();
                    SetAgentVelocity(tempPosition);
                    var sId = "M" + i + j;
                    var tempAgent = new Messenger(Config, tempPosition, sId, this, AreaArray[i]);

                    MessengerList.Add(tempAgent);
                }
            }
        }

        public void CreateRulers()
        {
            for (var i = 0; i < Config.RulersCount; i++)
            {
                var iArea = i;
                var tempPosition = SetAgentPosition();
                SetAgentVelocity(tempPosition);
                var sId = "R" + i;
                RulerList.Add(new Ruler(Config, tempPosition, sId, AreaArray[iArea], this));
            }
        }




        private void SetAgentVelocity(AgentPosition agentPosition)
        {
            var v = Config.MaxSpeed / 2;
            v = v + (Config.Rnd.NextDouble() - 0.5) * Config.MaxSpeed;
            var degree = Config.Rnd.NextDouble() * 360;
            agentPosition.Velocity.Y = v * Math.Sin(degree);
            agentPosition.Velocity.X = v * Math.Cos(degree);
        }

        public void Run()
        {
            Config.IsRunning = true;
            Simulation();
        }

        public OrganizationBoundries InitialOrgBoundries(List<Team> teamList)
        {
            var localOrgBoundary = CreateRandomOrganization();
            foreach (var team in teamList)
            {
                if (team.OrganizationBoundries.Radius + localOrgBoundary.Radius > localOrgBoundary.OrgCenter.CalculateDistance(team.OrganizationBoundries.OrgCenter))
                {
                    return InitialOrgBoundries(teamList);
                }
            }
            return localOrgBoundary;
        }

        public OrganizationBoundries CreateRandomOrganization()
        {
            var localOrgBoundary = new OrganizationBoundries
            {
                OrgCenter = SetAgentPosition().Position,
                Radius = Config.TeamOrganizationRadius
            };
            return localOrgBoundary;
        }

        #region Simulation
        public void Simulation()
        {
            while (!Config.EndOfApplication)
            {
                Time.Tick();
                UpdateOrganizations();
                if (Time.GlobalSimulationTime == 100 &&
                    Config.SelectedScenario is SelfHealingScenario1)
                {
                    Time.StartSimulationTime = Time.GlobalSimulationTime;
                    Config.StartMessageCount = ContainerMedia.MessageCount;
                    var iRemoveIndex = Config.Rnd.Next(0, RulerList.Count - 1);
                    var lostRuler = RulerList[iRemoveIndex];

                    while (lostRuler.LeaderList.Count == 0)
                    {
                        iRemoveIndex = Config.Rnd.Next(0, RulerList.Count - 1);
                        lostRuler = RulerList[iRemoveIndex];
                    }

                    lostRuler.Status = State.Failed;
                }

                Thread.Sleep(Config.HesitateValue);
                HandleEvents();
            }
        }
        private void HandleEvents()
        {
            if (EventQueue.Count == 0) return;
            while (EventQueue[EventQueue.Count - 1].EventTime == Time.GlobalSimulationTime)
            {
                var tempEvent = EventQueue[EventQueue.Count - 1];
                DoEvent(tempEvent);
                EventQueue.RemoveAt(EventQueue.Count - 1);
                if (EventQueue.Count == 0) return;
            }

        }

        private void DoEvent(Event tempEvent)
        {
            switch (tempEvent.EventType)
            {
                case EventType.Message:
                    ContainerMedia.DoMessage(tempEvent.MessageId);
                    break;
            }
        }

        private void UpdateOrganizations()
        {
            foreach (var team in TeamList)
            {
                team.UpdateOrgOneMillisecond();
                team.OrgLeader.UpdateOneMillisecond();
            }

            foreach (var agent in MessengerList)
            {
                agent.FreeUpdateOneMillisecond();
            }

            foreach (var agent in RulerList)
            {
                agent.FreeUpdateOneMillisecond();
            }
        }

        #endregion

        private AgentPosition SetAgentPosition()
        {
            var tempAgentPosition = new AgentPosition
            {
                Position =
                {
                    X = Config.Rnd.NextDouble() * (Config.UpperBoarder.X - Config.LowerBoarder.X) + Config.LowerBoarder.X,
                    Y = Config.Rnd.NextDouble() * (Config.UpperBoarder.Y - Config.LowerBoarder.Y) + Config.LowerBoarder.Y
                }
            };
            return tempAgentPosition;
        }



        public bool AddEventToQueue(int messageId, int timeFromNow)
        {
            var tempEvent = new Event();
            var time = Time.GlobalSimulationTime;

            tempEvent.EventTime = time + timeFromNow;

            tempEvent.MessageId = messageId;
            tempEvent.EventType = EventType.Message;

            var indexOccur = EventQueue.FindIndex(
                ev => ev.EventTime > tempEvent.EventTime
            );
            if (indexOccur == -1)
            {
                indexOccur = 0;
            }
            EventQueue.Insert(indexOccur, tempEvent);

            return true;
        }




        #region MessengerInRange
        internal List<Agent> GetMessengersInRange(Agent agent)
        {
            var listOfAgent = new List<Agent>();
            var position = agent.Position.Position;
            foreach (var messengerAgent in MessengerList)
            {
                var tempPosition = messengerAgent.Position.Position;
                if (CalculateInRange(position, tempPosition, agent.RadioRange))
                {
                    if (agent.AgentId != messengerAgent.AgentId)
                    {
                        listOfAgent.Add(messengerAgent);
                    }
                }
            }
            return listOfAgent;
        }

        internal List<Agent> GetLeadersInRange(Agent agent)
        {
            var listOfAgent = new List<Agent>();
            var position = agent.Position.Position;
            foreach (var team in TeamList)
            {
                var leaderAgent = team.OrgLeader;
                var tempPosition = leaderAgent.Position.Position;
                if (CalculateInRange(position, tempPosition, agent.RadioRange))
                {
                    listOfAgent.Add(leaderAgent);
                }
            }
            return listOfAgent;
        }


        internal List<Agent> GetRulersInRange(Agent agent)
        {
            var listOfAgent = new List<Agent>();
            var position = agent.Position.Position;
            foreach (var rulerAgent in RulerList)
            {
                var tempPosition = rulerAgent.Position.Position;
                if (CalculateInRange(position, tempPosition, agent.RadioRange))
                {
                    listOfAgent.Add(rulerAgent);
                }
            }
            return listOfAgent;
        }


        internal List<Agent> GetAgentsInRange(Agent agent)
        {
            var listOfAgent = new List<Agent>();
            var position = agent.Position.Position;
            Point tempPosition;
            foreach (var messengerAgent in MessengerList)
            {
                tempPosition = messengerAgent.Position.Position;
                if (CalculateInRange(position, tempPosition, agent.RadioRange))
                {
                    if (agent.AgentId != messengerAgent.AgentId)
                    {
                        listOfAgent.Add(messengerAgent);
                    }
                }
            }
            foreach (var rulerAgent in RulerList)
            {
                tempPosition = rulerAgent.Position.Position;
                if (CalculateInRange(position, tempPosition, agent.RadioRange))
                {
                    if (agent.AgentId != rulerAgent.AgentId)
                    {
                        listOfAgent.Add(rulerAgent);
                    }
                }
            }
            foreach (var team in TeamList)
            {
                foreach (var workerAgent in team.AgentsArray)
                {
                    tempPosition = workerAgent.Position.Position;
                    if (CalculateInRange(position, tempPosition, agent.RadioRange))
                    {
                        if (agent.AgentId != workerAgent.AgentId)
                        {
                            listOfAgent.Add(workerAgent);
                        }
                    }
                }
            }

            return listOfAgent;
        }

        private bool CalculateInRange(Point position, Point position2, double radioRange)
        {
            var x = position.X - position2.X;
            var y = position.Y - position2.Y;
            x *= x;
            y *= y;
            radioRange *= radioRange;
            if ((x + y) < radioRange) return true;
            return false;
        }
    }
}
#endregion
