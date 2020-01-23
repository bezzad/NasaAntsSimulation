using System;
using System.Collections.Generic;
using System.Threading;
using Simulation.Roles;

namespace Simulation
{
    public class Container
    {
        //Prameters ---------------------------------------------------------
        Random _r;
        public Media ContainerMedia { set; get; }
        List<Event> _eventQueue = new List<Event>();
        Point _upperBoarder;
        Point _lowerBoarder;
        //public int numOfAgents{set;get;}
        public int NumOfOrganization { set; get; }

        // not used
        int _maxSimulationTime;
        public int InitNumOfTeams = 20;
        public int InitNumOfRulers = 16;
        public int InitNumOfMessengers = 80;
        public int InitNumOfWorkersInOrganization = 30;
        public int NumOfOrganizations { get; set; }
        public List<Team> TeamList = new List<Team>();
        public List<Agent> MessangerList = new List<Agent>();
        public List<Agent> RulerList = new List<Agent>();

        public Area[] AreaArray = new Area[16];
        Program.Scenario _simulationScenario;



        //Impelementation ----------------------------------------------------
        public Container(Point upperBorder, Point lowerBoarder)
        {
            _upperBoarder = upperBorder;
            _lowerBoarder = lowerBoarder;
            //numOfAgents = NumOfAgents;
            ContainerMedia = new Media(this);
            Time.GlobalSimulationTime = 0;
            _r = Program.R;





            for (var iOrgCount = 0; iOrgCount < InitNumOfTeams; iOrgCount++)
            {
                var orgBoundry = InitialOrgBoundries(TeamList);
                TeamList.Add(new Team(TeamList.Count, "org" + TeamList.Count, InitNumOfWorkersInOrganization, orgBoundry, this));
            }
            InitializeAreas();
            CreateMessangers();

            CreateRulers();

        }

        private void InitializeAreas()
        {
            var iArea = 0;
            for (double ix = 0; ix <= 750; ix += 250)
            {
                for (double iy = 0; iy <= 750; iy += 250)
                {
                    var tempArea = new Area();
                    tempArea.MinX = ix;
                    tempArea.MinY = iy;
                    tempArea.MaxX = ix + 250;
                    tempArea.MaxY = iy + 250;

                    AreaArray[iArea] = tempArea;
                    iArea++;
                }
            }
        }

        //Methods -------------------------------------------------------------

        public void CreateMessangers()
        {
            for (var i = 0; i < AreaArray.Length; i++)
            {
                for (var j = 0; j < InitNumOfMessengers / AreaArray.Length; j++)
                {

                    var tempPosition = SetAgentPosition();
                    SetAgentVelocity(tempPosition);
                    var sId = "M" + i.ToString() + j.ToString();
                    var tempAgent = new Agent(tempPosition, sId, Role.RolesName.Messenger, AreaArray[i], this);

                    MessangerList.Add(tempAgent);

                }
            }
        }


        public void CreateRulers()
        {
            for (var i = 0; i < InitNumOfRulers; i++)
            {
                var iarea = i;
                var tempPosition = SetAgentPosition();
                SetAgentVelocity(tempPosition);
                var sId = "R" + i;
                RulerList.Add(new Agent(tempPosition, sId, Role.RolesName.Ruler, AreaArray[iarea], this));
            }
        }




        private void SetAgentVelocity(AgentPosition agentPosition)
        {
            double v = Program.Maxspeed / 2;
            v = v + ((_r.NextDouble() - 0.5) * Program.Maxspeed);
            var degree = _r.NextDouble() * 360;
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



        //public organizationBoundries InitialMessangerArea(List<Messenger> mList)
        //{
        //    Area localMessengerBoundry = createRandomOrganization();
        //    foreach (Messenger messenger in MessangerList)
        //    {
        //        if (team.organizationBoundries.radious + localOrgBoundry.radious > calculateDistance(localOrgBoundry.orgCenter, team.organizationBoundries.orgCenter))
        //        {
        //            return InitialOrgBoundries(teamList);
        //        }






        //    }

        //    return localOrgBoundry;
        //}

        //***************************************************************************
        public OrganizationBoundries InitialOrgBoundries(List<Team> teamList)
        {
            var localOrgBoundry = CreateRandomOrganization();
            foreach (var team in teamList)
            {
                if (team.OrganizationBoundries.Radious + localOrgBoundry.Radious > CalculateDistance(localOrgBoundry.OrgCenter, team.OrganizationBoundries.OrgCenter))
                {
                    return InitialOrgBoundries(teamList);
                }
            }
            return localOrgBoundry;
        }

        public double CalculateDistance(Point position, Point position2)
        {
            double dest;
            var x = position.X - position2.X;
            var y = position.Y - position2.Y;
            x *= x;
            y *= y;
            dest = Math.Sqrt(x + y);
            return dest;
        }

        public OrganizationBoundries CreateRandomOrganization()
        {
            var localOrgBoundry = new OrganizationBoundries();
            localOrgBoundry.OrgCenter = SetAgentPosition().Position;
            localOrgBoundry.Radious = 80;
            return localOrgBoundry;
        }

        #region Simulation
        public void Simulation()
        {
            while (!Program.EndOfApplication)
            {
                Time.Tick();
                UpdateOrganizations();
                if (Time.GlobalSimulationTime == 100 && _simulationScenario == Program.Scenario.Scenario1)
                {

                    Time.StartSimulationTime = Time.GlobalSimulationTime;
                    Program.StartMessageCount = ContainerMedia.MessageCount;
                    var iRemoveIndex = _r.Next(0, RulerList.Count - 1);
                    var lostRulerAgent = RulerList[iRemoveIndex];
                    var lostruler = (Ruler)lostRulerAgent.AgentRole;

                    while (lostruler.LeaderList.Count == 0)
                    {
                        iRemoveIndex = _r.Next(0, RulerList.Count - 1);
                        lostRulerAgent = RulerList[iRemoveIndex];
                        lostruler = (Ruler)lostRulerAgent.AgentRole;
                    }

                    lostruler.Status = 0;

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
                team.UpdateOrgOneMiliSec();
                team.OrgLeader.updateOneMiliSec();
            }

            foreach (var agent in MessangerList)
            {
                agent.FreeUpdateOneMiliSec();
            }

            foreach (var agent in RulerList)
            {
                agent.FreeUpdateOneMiliSec();
            }
        }

        //private void updateAgents()
        //{
        //    for (int i = 0; i < numOfAgents; i++)
        //    {
        //        agentsArray[i].updateOneMiliSec();

        //    }
        //}
        #endregion

        private AgentPosition SetAgentPosition()
        {
            var tempAgentPosition = new AgentPosition();
            tempAgentPosition.Position.X = (_r.NextDouble() * (_upperBoarder.X - _lowerBoarder.X)) + _lowerBoarder.X;
            tempAgentPosition.Position.Y = (_r.NextDouble() * (_upperBoarder.Y - _lowerBoarder.Y)) + _lowerBoarder.Y;
            return tempAgentPosition;
        }



        public bool AddEventToQeue(int messageId, int timeFromNow)
        {
            var tempEvent = new Event();
            var time = Time.GlobalSimulationTime;

            tempEvent.EventTime = time + timeFromNow;

            tempEvent.MessageId = messageId;
            tempEvent.EventType = EventType.Message;

            var indexOccur = _eventQueue.FindIndex(
                delegate (Event ev)
                {
                    return ev.EventTime > tempEvent.EventTime;
                }
                );
            if (indexOccur == -1)
            {
                indexOccur = 0;
            }
            _eventQueue.Insert(indexOccur, tempEvent);



            return true;
        }




        #region MessengerInRange
        internal List<Agent> GetMessangersInRange(Agent agent)
        {
            var listOfAgent = new List<Agent>();
            var position = agent.GetPosition().Position;
            Point tempPosition;
            foreach (var messangerAgent in MessangerList)
            {
                tempPosition = messangerAgent.GetPosition().Position;
                if (CalculateInRange(position, tempPosition, agent.RadioRange))
                {
                    if (agent.AgentId != messangerAgent.AgentId)
                    {
                        if (messangerAgent.AgentType == Role.RolesName.Messenger)
                        {
                            listOfAgent.Add(messangerAgent);
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
            Point tempPosition;
            foreach (var team in TeamList)
            {
                var leaderAgent = team.OrgLeader;
                tempPosition = leaderAgent.GetPosition().Position;
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
            Point tempPosition;
            foreach (var rulerAgent in RulerList)
            {

                tempPosition = rulerAgent.GetPosition().Position;
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
            foreach (var messangerAgent in MessangerList)
            {
                tempPosition = messangerAgent.GetPosition().Position;
                if (CalculateInRange(position, tempPosition, agent.RadioRange))
                {
                    if (agent.AgentId != messangerAgent.AgentId)
                    {
                        if (agent.AgentType == Role.RolesName.Messenger)
                        {
                            listOfAgent.Add(messangerAgent);
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
                        if (agent.AgentId != agent.AgentId)
                        {
                            if (agent.AgentType == Role.RolesName.Ruler)
                            {
                                listOfAgent.Add(agent);
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
            else return false;
        }
        //#endregion


        //private Agent createNode(int index)
        //{
        //    Agent tempAgent;
        //    AgentPosition tempAgentPosition = new AgentPosition();
        //    setAgentPosition(tempAgentPosition);
        //    setAgentVelocity(tempAgentPosition);

        //    tempAgent = new Agent(tempAgentPosition, index,numOfAgents,this);

        //    return tempAgent;
        //}
    }
}
#endregion
