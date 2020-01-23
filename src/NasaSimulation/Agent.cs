using System;
using Simulation.Roles;

namespace Simulation
{
    public class Agent
    {
        //Parameters ------------------------------------------------------
        //int numOfAgents;
        readonly Random _random;
        private AgentPosition _position = new AgentPosition();
        readonly Container _container;
        public string AgentId {set; get;}
        readonly OrganizationBoundries _teamBoundary;
        public object AgentRole { get; set; }
        public Role.RolesName   AgentType ;
        Point _upB, _lowB;
        public double RadioRange { set; get; }

               
        //Implementation --------------------------------------------------
        public Agent(AgentPosition position, string id, Role.RolesName agentRoleType, OrganizationBoundries orgBoundary,Container cont    /*, int maxNumAgents,Container tempContainer*/)
        {
            _container = cont;
            //numOfAgents = maxNumAgents;
            _position = position;
            AgentId = id;
            //container = tempContainer;
            _random = Program.R;
            _teamBoundary = orgBoundary;
            
            AgentType = agentRoleType;
            var temptRole = new Role();

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
                    temptRole.RadioRange = Program.MaxRadioRange;
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
                    temptRole.RadioRange = Program.MaxRadioRange;
                    AgentRole = temptRole;
                    RadioRange = temptRole.RadioRange;
                    break;
            }
            
           
        }

        public Agent(AgentPosition position, string id, Role.RolesName agentRoleType, Container cont)
        {
            _position = position;
            AgentId = id;
            //container = tempContainer;
            _random = Program.R;
            
           
            AgentType = agentRoleType;

            _upB = Program.UpperBoarder;
            _lowB = Program.LowerBoarder;
        }


        public Agent(AgentPosition position, string id, Role.RolesName agentRoleType, Area agentArea, Container cont)
        {
            _position = position;
            AgentId = id;
            //container = tempContainer;
            _container = cont;
            _random = Program.R;
            AgentType = agentRoleType;
            _upB = Program.UpperBoarder;
            _lowB = Program.LowerBoarder;
            var temptRole = new Role();
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
                    temptRole.RadioRange = Program.MaxRadioRange;
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

        
        public void UpdateOneSec()
        {
            Movement();
        }

        public void UpdateOneMillisecond()
        {
            Movement();

            if (AgentType == Role.RolesName.Leader)
            {
                if (Program.OursExecutionMode)
                {
                    var leader = (Leader)AgentRole;
                    if (Time.GlobalSimulationTime % 40 == 0)
                    {
                        leader.OursOnTimeEvent();
                    }
                }
                else
                {
                    var leader = (Leader)AgentRole;
                    if (Time.GlobalSimulationTime % 40== 0)
                    {
                        leader.OnTimedEvent();
                    }
                }
            }


        }

        public void FreeUpdateOneMillisecond()
        {
            if (AgentType == Role.RolesName.Messenger)
            {
                if (Program.OursExecutionMode)
                {
                    var messenger = (Messenger)AgentRole;
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
        public AgentPosition GetPosition()
        {
            var p = new AgentPosition();
            p = _position;
            return p;
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


        private int Movement()
        {
            _position.Position.X += _position.Velocity.X/1000;

            _position.Position.Y += _position.Velocity.Y/1000;

            if (CalculateDistance(_position.Position, _teamBoundary.OrgCenter) > _teamBoundary.Radius) 
            {
                _position.Position.X = _teamBoundary.OrgCenter.X;
                _position.Position.Y = _teamBoundary.OrgCenter.Y;
            }

            //if (position.Position.X > (upB.X - lowB.X)) position.Position.X = 0;
            //if (position.Position.X < 0) position.Position.X = (upB.X + lowB.X);
            //if (position.Position.Y > (upB.Y - lowB.Y)) position.Position.Y = 0;
            //if (position.Position.Y < 0) position.Position.Y = (upB.Y + lowB.Y);

            if (Time.GlobalSimulationTime > 1000 & Time.GlobalSimulationTime % 1000 == 0)
            {
                UpdateVelocity(_position);
            }
            return 0;
        }


        private int FreeMovement()
        {
            _position.Position.X += _position.Velocity.X / 1000;

            _position.Position.Y += _position.Velocity.Y / 1000;

            //if (calculateDistance(position.Position, teamBoundary.orgCenter) > teamBoundary.Radius)
            //{
            //    position.Position.X = teamBoundary.orgCenter.X;
            //    position.Position.Y = teamBoundary.orgCenter.Y;
            //}

            if (AgentType == Role.RolesName.Messenger)
            {
                var tempMessenger = (Messenger)AgentRole;

                var x = (double)_random.Next((int)tempMessenger.MessengerArea.MinX, (int)tempMessenger.MessengerArea.MaxX);
                var y = (double)_random.Next((int)tempMessenger.MessengerArea.MinY, (int)tempMessenger.MessengerArea.MaxY);
                if (_position.Position.X > tempMessenger.MessengerArea.MaxX) _position.Position.X = x;
                if (_position.Position.X < tempMessenger.MessengerArea.MinX) _position.Position.X = x;
                if (_position.Position.Y > tempMessenger.MessengerArea.MaxY) _position.Position.Y = y;
                if (_position.Position.Y < tempMessenger.MessengerArea.MinY) _position.Position.Y = y;
            }



            else if (AgentType == Role.RolesName.Ruler)
            {
                var tempRuler = (Ruler)AgentRole;

                var x = (double)_random.Next((int)tempRuler.RulerArea.MinX, (int)tempRuler.RulerArea.MaxX);
                var y = (double)_random.Next((int)tempRuler.RulerArea.MinY, (int)tempRuler.RulerArea.MaxY);
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
                UpdateVelocity(_position);
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


            if ((Time.GlobalSimulationTime>1000)&&((Time.GlobalSimulationTime%1000) == 0)) UpdateVelocity(_position);
            return 0;
        }
        private void UpdateVelocity(AgentPosition position)
        {
            var t1 = _random.NextDouble();
            t1 = (t1 - 0.5) * 2; 
            var t2 = _random.NextDouble();
            t2 = (t2 - 0.5) * 2;

           


           if((position.Velocity.X *position.Velocity.X) +(position.Velocity.Y*position.Velocity.Y)>(Program.MaxSpeed*Program.MaxSpeed))
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

        private void MessageNotSent()
        {
            throw new NotImplementedException();
        }

        private void SendMessage(int nextHopAgentId, Message msg)
        {
            //MSG.currentSenderAgentID = this.agentID;
            //MSG.currentRecieverAgentID = nextHopAgentID;
            //bool sendIsOK=container.containerMedia.sendMessage(this,MSG);
            //if (!sendIsOK)
            //{
            //    mediaIsBussy();
            //}
        }

        private void MediaIsBussy()
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
