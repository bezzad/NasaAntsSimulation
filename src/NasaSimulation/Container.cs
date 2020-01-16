using System;
using System.Collections.Generic;
using System.Threading;
using Nasa.ANTS.Simulation.Roles;

namespace Nasa.ANTS.Simulation
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





            for (int iOrgCount = 0; iOrgCount < InitNumOfTeams; iOrgCount++)
            {
                OrganizationBoundries orgBoundry = InitialOrgBoundries(TeamList);
                TeamList.Add(new Team(TeamList.Count, "org" + TeamList.Count, InitNumOfWorkersInOrganization, orgBoundry, this));
            }
            InitializeAreas();
            CreateMessangers();

            CreateRulers();

        }

        private void InitializeAreas()
        {
            int iArea = 0;
            for (double ix = 0; ix <= 750; ix += 250)
            {
                for (double iy = 0; iy <= 750; iy += 250)
                {
                    Area tempArea = new Area();
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
            for (int i = 0; i < AreaArray.Length; i++)
            {
                for (int j = 0; j < InitNumOfMessengers / AreaArray.Length; j++)
                {

                    AgentPosition tempPosition = setAgentPosition();
                    setAgentVelocity(tempPosition);
                    string sId = "M" + i.ToString() + j.ToString();
                    Agent tempAgent = new Agent(tempPosition, sId, Role.RolesName.Messenger, AreaArray[i], this);

                    MessangerList.Add(tempAgent);

                }
            }
        }


        public void CreateRulers()
        {
            for (int i = 0; i < InitNumOfRulers; i++)
            {
                int iarea = i;
                AgentPosition tempPosition = setAgentPosition();
                setAgentVelocity(tempPosition);
                string sId = "R" + i;
                RulerList.Add(new Agent(tempPosition, sId, Role.RolesName.Ruler, AreaArray[iarea], this));
            }
        }




        private void setAgentVelocity(AgentPosition agentPosition)
        {
            double v = Program.Maxspeed / 2;
            v = v + ((_r.NextDouble() - 0.5) * Program.Maxspeed);
            double degree = _r.NextDouble() * 360;
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

        public void run()
        {
            Program.RunGui = true;
            simulation();
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
            OrganizationBoundries localOrgBoundry = createRandomOrganization();
            foreach (Team team in teamList)
            {
                if (team.OrganizationBoundries.Radious + localOrgBoundry.Radious > calculateDistance(localOrgBoundry.OrgCenter, team.OrganizationBoundries.OrgCenter))
                {
                    return InitialOrgBoundries(teamList);
                }
            }
            return localOrgBoundry;
        }

        public double calculateDistance(Point position, Point position2)
        {
            double dest;
            double x = position.X - position2.X;
            double y = position.Y - position2.Y;
            x *= x;
            y *= y;
            dest = Math.Sqrt(x + y);
            return dest;
        }

        public OrganizationBoundries createRandomOrganization()
        {
            OrganizationBoundries localOrgBoundry = new OrganizationBoundries();
            localOrgBoundry.OrgCenter = setAgentPosition().Position;
            localOrgBoundry.Radious = 80;
            return localOrgBoundry;
        }

        #region Simulation
        public void simulation()
        {
            while (!Program.EndOfApplication)
            {
                Time.tick();
                updateOrganizations();
                if (Time.GlobalSimulationTime == 100 && _simulationScenario == Program.Scenario.Scenario1)
                {

                    Time.StartSimulationTime = Time.GlobalSimulationTime;
                    Program.StartMessageCount = ContainerMedia.MessageCount;
                    int iRemoveIndex = _r.Next(0, RulerList.Count - 1);
                    Agent lostRulerAgent = RulerList[iRemoveIndex];
                    Ruler lostruler = (Ruler)lostRulerAgent.AgentRole;

                    while (lostruler.LeaderList.Count == 0)
                    {
                        iRemoveIndex = _r.Next(0, RulerList.Count - 1);
                        lostRulerAgent = RulerList[iRemoveIndex];
                        lostruler = (Ruler)lostRulerAgent.AgentRole;
                    }

                    lostruler.IStatus = 0;

                }




                Thread.Sleep(Program.HezitateValue);
                handleEvents();
            }
        }
        private void handleEvents()
        {
            if (_eventQueue.Count == 0) return;
            while (_eventQueue[_eventQueue.Count - 1].EventTime == Time.GlobalSimulationTime)
            {
                Event tempEvent = _eventQueue[_eventQueue.Count - 1];
                doEvent(tempEvent);
                _eventQueue.RemoveAt(_eventQueue.Count - 1);
                if (_eventQueue.Count == 0) return;
            }

        }

        private void doEvent(Event tempEvent)
        {
            switch (tempEvent.EventType)
            {
                case EventType.Message:
                    ContainerMedia.doMessage(tempEvent.MessageId);
                    break;

            }
        }

        private void updateOrganizations()
        {
            foreach (Team team in TeamList)
            {
                team.UpdateOrgOneMiliSec();
                team.OrgLeader.updateOneMiliSec();
            }

            foreach (Agent agent in MessangerList)
            {
                agent.FreeUpdateOneMiliSec();
            }

            foreach (Agent agent in RulerList)
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

        private AgentPosition setAgentPosition()
        {
            AgentPosition tempAgentPosition = new AgentPosition();
            tempAgentPosition.Position.X = (_r.NextDouble() * (_upperBoarder.X - _lowerBoarder.X)) + _lowerBoarder.X;
            tempAgentPosition.Position.Y = (_r.NextDouble() * (_upperBoarder.Y - _lowerBoarder.Y)) + _lowerBoarder.Y;
            return tempAgentPosition;
        }



        public bool addEventToQeue(int messageId, int timeFromNow)
        {
            Event tempEvent = new Event();
            long time = Time.GlobalSimulationTime;

            tempEvent.EventTime = time + timeFromNow;

            tempEvent.MessageId = messageId;
            tempEvent.EventType = EventType.Message;

            int indexOccur = _eventQueue.FindIndex(
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
        internal List<Agent> getMessangersInRange(Agent agent)
        {
            List<Agent> listOfAgent = new List<Agent>();
            Point position = agent.getPosition().Position;
            Point tempPosition;
            foreach (Agent messangerAgent in MessangerList)
            {
                tempPosition = messangerAgent.getPosition().Position;
                if (calculateInRange(position, tempPosition, agent.RadioRange))
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
        internal List<Agent> getLeadersInRange(Agent agent)
        {
            List<Agent> listOfAgent = new List<Agent>();
            Point position = agent.getPosition().Position;
            Point tempPosition;
            foreach (Team team in TeamList)
            {
                Agent leaderAgent = team.OrgLeader;
                tempPosition = leaderAgent.getPosition().Position;
                if (calculateInRange(position, tempPosition, agent.RadioRange))
                {
                    if (leaderAgent.AgentType == Role.RolesName.Leader)
                    {
                        listOfAgent.Add(leaderAgent);
                    }
                }
            }
            return listOfAgent;
        }


        internal List<Agent> getRulersInRange(Agent agent)
        {
            List<Agent> listOfAgent = new List<Agent>();
            Point position = agent.getPosition().Position;
            Point tempPosition;
            foreach (Agent rulerAgent in RulerList)
            {

                tempPosition = rulerAgent.getPosition().Position;
                if (calculateInRange(position, tempPosition, agent.RadioRange))
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
        internal List<Agent> getAgentsInRange(Agent agent)
        {
            List<Agent> listOfAgent = new List<Agent>();
            Point position = agent.getPosition().Position;
            Point tempPosition;
            foreach (Agent messangerAgent in MessangerList)
            {
                tempPosition = messangerAgent.getPosition().Position;
                if (calculateInRange(position, tempPosition, agent.RadioRange))
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
            foreach (Agent rulerAgent in RulerList)
            {
                tempPosition = rulerAgent.getPosition().Position;
                if (calculateInRange(position, tempPosition, agent.RadioRange))
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
            foreach (Team team in TeamList)
            {
                foreach (Agent workerAgent in team.AgentsArray)
                {
                    tempPosition = workerAgent.getPosition().Position;
                    if (calculateInRange(position, tempPosition, agent.RadioRange))
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




        private bool calculateInRange(Point position, Point position2, double radioRange)
        {
            double x = position.X - position2.X;
            double y = position.Y - position2.Y;
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
