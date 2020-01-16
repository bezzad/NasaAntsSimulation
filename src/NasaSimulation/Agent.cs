using System;
using Nasa.ANTS.Simulation.Roles;

namespace Nasa.ANTS.Simulation
{
    public class Agent
    {
        //Parameters ------------------------------------------------------
        //int numOfAgents;
        Random _r;
        private AgentPosition _position = new AgentPosition();
        Container _container;
        public string AgentId {set; get;}
        OrganizationBoundries _teamBoundry;
        public object AgentRole { get; set; }
        public Role.RolesName   AgentType ;
        Point _upB, _lowB;
        public double RadioRange { set; get; }

               
        //Implementation --------------------------------------------------
        public Agent(AgentPosition position, string id, Role.RolesName agentRoleType, OrganizationBoundries orgBoundry,Container cont    /*, int maxNumAgents,Container tempContainer*/)
        {
            _container = cont;
            //numOfAgents = maxNumAgents;
            this._position = position;
            AgentId = id;
            //container = tempContainer;
            _r = Program.R;
            _teamBoundry = orgBoundry;
            
            AgentType = agentRoleType;
            Role temptRole = new Role();

            switch (AgentType)
            {
                //case Role.RolesName.Messenger:
                //    agentRole = new Messenger(this, container);
                //    temptRole = (Role)agentRole;
                //    temptRole.RadioRange = Program.maxMessengerRadioRange;
                //    break;
                case Role.RolesName.Worker:
                    AgentRole = new Worker(_container,this);
                    temptRole = (Role)AgentRole;
                    temptRole.RadioRange = Program.Maxradiorange;
                    AgentRole = temptRole;
                    RadioRange = temptRole.RadioRange;
                    break;
                //case Role.RolesName.Ruler:
                //    agentRole = new Ruler();
                //    temptRole = (Role)agentRole;
                //    temptRole.RadioRange = Program.MAXRADIORANGE;
                //    break;
                case Role.RolesName.Leader:
                    AgentRole = new Leader(this, _container);
                    temptRole = (Role)AgentRole;
                    temptRole.RadioRange = Program.Maxradiorange;
                    AgentRole = temptRole;
                    RadioRange = temptRole.RadioRange;
                    break;
            }
            
           
        }

        public Agent(AgentPosition position, string id, Role.RolesName agentRoleType, Container cont)
        {
            this._position = position;
            AgentId = id;
            //container = tempContainer;
            _r = Program.R;
            
           
            AgentType = agentRoleType;

            _upB = Program.UpperBoarder;
            _lowB = Program.LowerBoarder;
        }


        public Agent(AgentPosition position, string id, Role.RolesName agentRoleType, Area agentArea, Container cont)
        {
            this._position = position;
            AgentId = id;
            //container = tempContainer;
            _container = cont;
            _r = Program.R;
            AgentType = agentRoleType;
            _upB = Program.UpperBoarder;
            _lowB = Program.LowerBoarder;
            Role temptRole = new Role();
            switch (AgentType)
            {
                case Role.RolesName.Messenger:
                    AgentRole = new Messenger(this, cont,agentArea);
                    temptRole = (Role)AgentRole;
                    temptRole.RadioRange = Program.MaxMessengerRadioRange;
                    AgentRole = temptRole;
                    RadioRange = temptRole.RadioRange;
                    break;
                //case Role.RolesName.Worker:
                //    agentRole = new Worker(container, this);
                //    temptRole = (Role)agentRole;
                //    temptRole.RadioRange = Program.MAXRADIORANGE;
                //    break;
                case Role.RolesName.Ruler:
                    AgentRole = new Ruler(agentArea,cont,this);
                    temptRole = (Role)AgentRole;
                    temptRole.RadioRange = Program.Maxradiorange;
                    AgentRole = temptRole;
                    RadioRange = temptRole.RadioRange;
                    break;
                //case Role.RolesName.Leader:
                //    agentRole = new Leader();
                //    temptRole = (Role)agentRole;
                //    temptRole.RadioRange = Program.MAXRADIORANGE;
                //    break;
            }
        }

        





       

        public void updateOneSec()
        {
            Movement();
        }

        public void updateOneMiliSec()
        {

            Movement();

            if (AgentType == Role.RolesName.Leader)
            {
                if (Program.OursExecutionMode)
                {
                    Leader leader = (Leader)this.AgentRole;
                    if (Time.GlobalSimulationTime % 40 == 0)
                    {
                        leader.oursOnTimeEvent();
                    }
                }
                else
                {
                    Leader leader = (Leader)this.AgentRole;
                    if (Time.GlobalSimulationTime % 40== 0)
                    {
                        leader.OnTimedEvent();
                    }
                }
            }


        }

        public void FreeUpdateOneMiliSec()
        {
            if (AgentType == Role.RolesName.Messenger)
            {
                if (Program.OursExecutionMode)
                {
                    Messenger messenger = (Messenger)this.AgentRole;
                    if (Time.GlobalSimulationTime % 50 == 0 && Time.GlobalSimulationTime > 100)
                    {
                        messenger.OnTimedEvent();
                    }
                }
            }
            FreeMovement();
        }

        public void UpdateAgentType(Role.RolesName newAgentType)
        {
            AgentType = newAgentType;
        }
       
        //public int AssignRole(Role agentRole)
        //{
        //    agentRoles.Add(agentRole);
        //    return agentRoles.Count - 1;
        //}



        //private void sendMessageToAgent(int AgentID, Message msg)
        //{
        //    Agent nextHopAgent = getBestNextHopAgent(msg);
        //    if (nextHopAgent == null)
        //    {
        //        messageNotSent();
        //    }
        //    else
        //    {
        //        sendMessage(nextHopAgent.ID, msg);
        //    }
        //}

        //Methods -----------------------------------------------------
        public AgentPosition getPosition()
        {
            AgentPosition p = new AgentPosition();
            p = _position;
            return p;
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


        private int Movement()
        {
            _position.Position.X += _position.Velocity.X/1000;

            _position.Position.Y += _position.Velocity.Y/1000;

            if (calculateDistance(_position.Position, _teamBoundry.OrgCenter) > _teamBoundry.Radious) 
            {
                _position.Position.X = _teamBoundry.OrgCenter.X;
                _position.Position.Y = _teamBoundry.OrgCenter.Y;
            }

            //if (position.Position.X > (upB.X - lowB.X)) position.Position.X = 0;
            //if (position.Position.X < 0) position.Position.X = (upB.X + lowB.X);
            //if (position.Position.Y > (upB.Y - lowB.Y)) position.Position.Y = 0;
            //if (position.Position.Y < 0) position.Position.Y = (upB.Y + lowB.Y);

            if (Time.GlobalSimulationTime > 1000 & Time.GlobalSimulationTime % 1000 == 0)
            {
                updateVelocity(_position);
            }
            return 0;
        }


        private int FreeMovement()
        {
            _position.Position.X += _position.Velocity.X / 1000;

            _position.Position.Y += _position.Velocity.Y / 1000;

            //if (calculateDistance(position.Position, teamBoundry.orgCenter) > teamBoundry.radious)
            //{
            //    position.Position.X = teamBoundry.orgCenter.X;
            //    position.Position.Y = teamBoundry.orgCenter.Y;
            //}

            if (AgentType == Role.RolesName.Messenger)
            {
                Messenger tempMessenger = (Messenger)AgentRole;

                double x = (double)_r.Next((int)tempMessenger.MessengerArea.MinX, (int)tempMessenger.MessengerArea.MaxX);
                double y = (double)_r.Next((int)tempMessenger.MessengerArea.MinY, (int)tempMessenger.MessengerArea.MaxY);
                if (_position.Position.X > tempMessenger.MessengerArea.MaxX) _position.Position.X = x;
                if (_position.Position.X < tempMessenger.MessengerArea.MinX) _position.Position.X = x;
                if (_position.Position.Y > tempMessenger.MessengerArea.MaxY) _position.Position.Y = y;
                if (_position.Position.Y < tempMessenger.MessengerArea.MinY) _position.Position.Y = y;
            }



            else if (AgentType == Role.RolesName.Ruler)
            {
                Ruler tempRuler = (Ruler)AgentRole;

                double x = (double)_r.Next((int)tempRuler.RulerArea.MinX, (int)tempRuler.RulerArea.MaxX);
                double y = (double)_r.Next((int)tempRuler.RulerArea.MinY, (int)tempRuler.RulerArea.MaxY);
                if (_position.Position.X > tempRuler.RulerArea.MaxX) _position.Position.X = x;
                if (_position.Position.X < tempRuler.RulerArea.MinX) _position.Position.X = x;
                if (_position.Position.Y > tempRuler.RulerArea.MaxY) _position.Position.Y = y;
                if (_position.Position.Y < tempRuler.RulerArea.MinY) _position.Position.Y = y;
            }

            else
            {
                if (_position.Position.X > (_upB.X - _lowB.X)) _position.Position.X = 0;
                if (_position.Position.X < 0) _position.Position.X = (_upB.X + _lowB.X);
                if (_position.Position.Y > (_upB.Y - _lowB.Y)) _position.Position.Y = 0;
                if (_position.Position.Y < 0) _position.Position.Y = (_upB.Y + _lowB.Y);
            }

            if (Time.GlobalSimulationTime > 1000 & Time.GlobalSimulationTime % 1000 == 0)
            {
                updateVelocity(_position);
            }
            return 0;
        }

        private int MovementOneTick()
        {
            _position.Position.X += (_position.Velocity.X/1000);
            _position.Position.Y += (_position.Velocity.Y/1000);

            //if (position.Position.X > (upB.X - lowB.X)) position.Position.X = 0;
            //if (position.Position.X < 0) position.Position.X = (upB.X + lowB.X);
            //if (position.Position.Y > (upB.Y - lowB.Y)) position.Position.Y = 0;
            //if (position.Position.Y < 0) position.Position.Y = (upB.Y + lowB.Y);


            if ((Time.GlobalSimulationTime>1000)&&((Time.GlobalSimulationTime%1000) == 0)) updateVelocity(_position);
            return 0;
        }
        private void updateVelocity(AgentPosition position)
        {
            double t1 = _r.NextDouble();
            t1 = (t1 - 0.5) * 2; 
            double t2 = _r.NextDouble();
            t2 = (t2 - 0.5) * 2;

           


           if((position.Velocity.X *position.Velocity.X) +(position.Velocity.Y*position.Velocity.Y)>(Program.Maxspeed*Program.Maxspeed))
           {
                position.Velocity.X/=2;
               position.Velocity.Y/=2;
           }

           position.Velocity.X += t1;
           position.Velocity.Y += t2;





        }



        //internal void getMessage(Message MSG)
        //{
        //    if (MSG.recieverAgentID == ID)
        //    {
        //        recievedOurMessage(MSG);
        //    }
        //    else //must route Message
        //    {
        //        Agent nextHopAgent = getBestNextHopAgent(MSG);

        //        if (nextHopAgent == null)
        //        {
        //            messageNotSent();

        //        }
        //        else
        //        {
        //            sendMessage(nextHopAgent.ID, MSG);
        //        }

        //    }
        //}

        private void messageNotSent()
        {
            throw new NotImplementedException();
        }

        private void sendMessage(int nextHopAgentId, Message msg)
        {
            //MSG.currentSenderAgentID = this.agentID;
            //MSG.currentRecieverAgentID = nextHopAgentID;
            //bool sendIsOK=container.containerMedia.sendMessage(this,MSG);
            //if (!sendIsOK)
            //{
            //    mediaIsBussy();
            //}
        }

        private void mediaIsBussy()
        {
            throw new NotImplementedException();
        }

        //private Agent getBestNextHopAgent(Message MSG)
        //{
        //    Agent bestMessanger;

        //    double bestDestination;
        // List<Agent> aroundAgent = container.getAgentsInRange(this,RadioRange);

            



        //    if(aroundAgent.Count==0)
        //    {
        //        noAgentAround();
        //        return null;
        //    }
        //    bestAgent=aroundAgent[0];
        //    bestDestination = calculateDestination(MSG.recieverAgentID,bestAgent.agentID);
        //    for (int i = 1; i < aroundAgent.Count;i++ )
        //    {
        //        double dest = calculateDestination(aroundAgent[i].agentID, MSG.recieverAgentID);
        //        if (dest < bestDestination)
        //        {
        //            bestDestination = dest;
        //            bestAgent = aroundAgent[i];
        //        }

        //    }

        //    return bestAgent;

        //}

        //private double calculateDestination(int agentID, int bestAgentID)
        //{
        //    double dest;
        //    twoDimentionParameter position = container.getAgent(agentID).getPosition().Position;
        //    twoDimentionParameter position2 = container.getAgent(bestAgentID).getPosition().Position;

        //    double x = position.X - position2.X;
        //    double y = position.Y - position2.Y;
        //    x *= x;
        //    y *= y;
        //    dest = Math.Sqrt(x + y);
        //    return dest;

        //}

        //private void noAgentAround()
        //{
        //    throw new NotImplementedException();
        //}

        //private void recievedOurMessage(Message MSG)
        //{
        //    int a = 0;   a = 2;
        //    //throw new NotImplementedException();
        //}
    }
}
