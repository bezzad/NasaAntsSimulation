using System;
using System.Collections.Generic;
using System.Threading;
using Simulation.Roles;

namespace Simulation
{
    public class Container
    {
        //Parameters ---------------------------------------------------------
        readonly Random _random;
        public Media ContainerMedia { set; get; }
        readonly List<Event> _eventQueue = new List<Event>();
        readonly Point _upperBoarder;
        readonly Point _lowerBoarder;

        // not used
        public int InitNumOfTeams = 20;
        public int InitNumOfRulers = 16;
        public int InitNumOfMessengers = 80;
        public int InitNumOfWorkersInOrganization = 30;
        public List<Team> TeamList = new List<Team>();
        public List<Agent> MessengerList = new List<Agent>();
        public List<Agent> RulerList = new List<Agent>();

        public Area[] AreaArray = new Area[16];
        private Program.Scenario SimulationScenario => Program.Scenario.Scenario1;


        //Implementation ----------------------------------------------------
        public Container(Point upperBorder, Point lowerBoarder)
        {
            _upperBoarder = upperBorder;
            _lowerBoarder = lowerBoarder;
            ContainerMedia = new Media(this);
            Time.GlobalSimulationTime = 0;
            _random = Program.R;

            for (var iOrgCount = 0; iOrgCount < InitNumOfTeams; iOrgCount++)
            {
                var orgBoundry = InitialOrgBoundries(TeamList);
                TeamList.Add(new Team(TeamList.Count, InitNumOfWorkersInOrganization, orgBoundry, this));
            }
            InitializeAreas();
            CreateMessengers();
            CreateRulers();
        }

        private void InitializeAreas()
        {
            var iArea = 0;
            for (double ix = 0; ix <= 750; ix += 250)
            {
                for (double iy = 0; iy <= 750; iy += 250)
                {
                    var tempArea = new Area {MinX = ix, MinY = iy, MaxX = ix + 250, MaxY = iy + 250};
                    AreaArray[iArea] = tempArea;
                    iArea++;
                }
            }
        }

        //Methods -------------------------------------------------------------

        public void CreateMessengers()
        {
            for (var i = 0; i < AreaArray.Length; i++)
            {
                for (var j = 0; j < InitNumOfMessengers / AreaArray.Length; j++)
                {

                    var tempPosition = SetAgentPosition();
                    SetAgentVelocity(tempPosition);
                    var sId = "M" + i.ToString() + j.ToString();
                    var tempAgent = new Agent(tempPosition, sId, Role.RolesName.Messenger, AreaArray[i], this);

                    MessengerList.Add(tempAgent);

                }
            }
        }


        public void CreateRulers()
        {
            for (var i = 0; i < InitNumOfRulers; i++)
            {
                var iArea = i;
                var tempPosition = SetAgentPosition();
                SetAgentVelocity(tempPosition);
                var sId = "R" + i;
                RulerList.Add(new Agent(tempPosition, sId, Role.RolesName.Ruler, AreaArray[iArea], this));
            }
        }




        private void SetAgentVelocity(AgentPosition agentPosition)
        {
            double v = Program.MaxSpeed / 2;
            v = v + ((_random.NextDouble() - 0.5) * Program.MaxSpeed);
            var degree = _random.NextDouble() * 360;
            agentPosition.Velocity.Y = v * Math.Sin(degree);
            agentPosition.Velocity.X = v * Math.Cos(degree);

            //if (degree >= 90 && degree < 180)
            //{
            //    agentPosition.Velocity.X *= -1;
            //}
            //if (degree >= 180 && degree < 270)
            //{
            //    agentPosition.Velocity.X *= -1;
            //    agentPosition.Velocity.Y *= -1;
            //}
            //if (degree >= 270 && degree <= 360)
            //{
            //    agentPosition.Velocity.Y *= -1;
            //}
        }

        public void Run()
        {
            Program.RunGui = true;
            Simulation();
        }

        //***************************************************************************
        public OrganizationBoundries InitialOrgBoundries(List<Team> teamList)
        {
            var localOrgBoundry = CreateRandomOrganization();
            foreach (var team in teamList)
            {
                if (team.OrganizationBoundries.Radius + localOrgBoundry.Radius > CalculateDistance(localOrgBoundry.OrgCenter, team.OrganizationBoundries.OrgCenter))
                {
                    return InitialOrgBoundries(teamList);
                }
            }
            return localOrgBoundry;
        }

        public double CalculateDistance(Point position, Point position2)
        {
            var x = position.X - position2.X;
            var y = position.Y - position2.Y;
            x *= x;
            y *= y;
            var dest = Math.Sqrt(x + y);
            return dest;
        }

        public OrganizationBoundries CreateRandomOrganization()
        {
            var localOrgBoundry = new OrganizationBoundries {OrgCenter = SetAgentPosition().Position, Radius = 80};
            return localOrgBoundry;
        }

        #region Simulation
        public void Simulation()
        {
            while (!Program.EndOfApplication)
            {
                Time.Tick();
                UpdateOrganizations();
                if (Time.GlobalSimulationTime == 100 && 
                    SimulationScenario == Program.Scenario.Scenario1)
                {

                    Time.StartSimulationTime = Time.GlobalSimulationTime;
                    Program.StartMessageCount = ContainerMedia.MessageCount;
                    var iRemoveIndex = _random.Next(0, RulerList.Count - 1);
                    var lostRulerAgent = RulerList[iRemoveIndex];
                    var lostRuler = (Ruler)lostRulerAgent.AgentRole;

                    while (lostRuler.LeaderList.Count == 0)
                    {
                        iRemoveIndex = _random.Next(0, RulerList.Count - 1);
                        lostRulerAgent = RulerList[iRemoveIndex];
                        lostRuler = (Ruler)lostRulerAgent.AgentRole;
                    }

                    lostRuler.Status = 0;
                }

                Thread.Sleep(Program.HezitateValue);
                HandleEvents();
            }
        }
        private void HandleEvents()
        {
            if (_eventQueue.Count == 0) return;
            while (_eventQueue[_eventQueue.Count - 1].EventTime == Time.GlobalSimulationTime)
            {
                var tempEvent = _eventQueue[_eventQueue.Count - 1];
                DoEvent(tempEvent);
                _eventQueue.RemoveAt(_eventQueue.Count - 1);
                if (_eventQueue.Count == 0) return;
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
                    X = (_random.NextDouble() * (_upperBoarder.X - _lowerBoarder.X)) + _lowerBoarder.X,
                    Y = (_random.NextDouble() * (_upperBoarder.Y - _lowerBoarder.Y)) + _lowerBoarder.Y
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

            var indexOccur = _eventQueue.FindIndex(
                ev => ev.EventTime > tempEvent.EventTime
            );
            if (indexOccur == -1)
            {
                indexOccur = 0;
            }
            _eventQueue.Insert(indexOccur, tempEvent);

            return true;
        }




        #region MessengerInRange
        internal List<Agent> GetMessengersInRange(Agent agent)
        {
            var listOfAgent = new List<Agent>();
            var position = agent.GetPosition().Position;
            foreach (var messengerAgent in MessengerList)
            {
                var tempPosition = messengerAgent.GetPosition().Position;
                if (CalculateInRange(position, tempPosition, agent.RadioRange))
                {
                    if (agent.AgentId != messengerAgent.AgentId)
                    {
                        if (messengerAgent.AgentType == Role.RolesName.Messenger)
                        {
                            listOfAgent.Add(messengerAgent);
                        }
                    }
                }
            }
            return listOfAgent;
        }
        //***************************************************************************
        internal List<Agent> GetLeadersInRange(Agent agent)
        {
            var listOfAgent = new List<Agent>();
            var position = agent.GetPosition().Position;
            foreach (var team in TeamList)
            {
                var leaderAgent = team.OrgLeader;
                var tempPosition = leaderAgent.GetPosition().Position;
                if (CalculateInRange(position, tempPosition, agent.RadioRange))
                {
                    if (leaderAgent.AgentType == Role.RolesName.Leader)
                    {
                        listOfAgent.Add(leaderAgent);
                    }
                }
            }
            return listOfAgent;
        }


        internal List<Agent> GetRulersInRange(Agent agent)
        {
            var listOfAgent = new List<Agent>();
            var position = agent.GetPosition().Position;
            foreach (var rulerAgent in RulerList)
            {
                var tempPosition = rulerAgent.GetPosition().Position;
                if (CalculateInRange(position, tempPosition, agent.RadioRange))
                {
                    if (rulerAgent.AgentType == Role.RolesName.Ruler)
                    {
                        listOfAgent.Add(rulerAgent);
                    }
                }
            }
            return listOfAgent;
        }


        //****************************************************************************
        internal List<Agent> GetAgentsInRange(Agent agent)
        {
            var listOfAgent = new List<Agent>();
            var position = agent.GetPosition().Position;
            Point tempPosition;
            foreach (var messengerAgent in MessengerList)
            {
                tempPosition = messengerAgent.GetPosition().Position;
                if (CalculateInRange(position, tempPosition, agent.RadioRange))
                {
                    if (agent.AgentId != messengerAgent.AgentId)
                    {
                        if (agent.AgentType == Role.RolesName.Messenger)
                        {
                            listOfAgent.Add(messengerAgent);
                        }
                    }
                }
            }
            foreach (var rulerAgent in RulerList)
            {
                tempPosition = rulerAgent.GetPosition().Position;
                if (CalculateInRange(position, tempPosition, agent.RadioRange))
                {
                    if (agent.AgentId != rulerAgent.AgentId)
                    {
                        if (agent.AgentType == Role.RolesName.Ruler)
                        {
                            listOfAgent.Add(rulerAgent);
                        }
                    }
                }
            }
            foreach (var team in TeamList)
            {
                foreach (var workerAgent in team.AgentsArray)
                {
                    tempPosition = workerAgent.GetPosition().Position;
                    if (CalculateInRange(position, tempPosition, agent.RadioRange))
                    {
                        if (agent.AgentId != workerAgent.AgentId)
                        {
                            if (agent.AgentType == Role.RolesName.Ruler)
                            {
                                listOfAgent.Add(workerAgent);
                            }
                        }
                    }
                }
            }

            return listOfAgent;
        }
        //**********************************************************************************


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
