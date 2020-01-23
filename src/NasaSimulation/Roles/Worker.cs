using System;

namespace Simulation.Roles
{
    class Worker:Role
    {
        Container _container;
     
        Agent _workerAgent;
        public Worker(Container cont,Agent agent)
        {
            _container = cont;
            _workerAgent = agent;




        }


        public void ProcessMessage(Message message)
        {

        }

        internal void GetMessage(Message message)
        {
            if (message.RecieverAgentId == _workerAgent.AgentId)
            {
                ProcessMessage(message);
            }
            else //must route Message
            {
               // SendMessage(message, recieverAgent);

            }
        }


        //public void SendMessage(Message message, Agent recieverAgent)
        //{
        //   Agent messengerAgent = FindNearestMessenger(workerAgent.getPosition(), recieverAgent.getPosition());

        //   message.currentRecieverAgentID = messengerAgent.agentID;

        //   Messenger messenger = (Messenger)messengerAgent.agentRole;
        //   messenger.getMessage(message);         
        //}

        private Agent FindNearestMessenger(AgentPosition agentPosition, AgentPosition destPosition)
        {
            double minDist = 10000;
            Agent nAgent = null;
            foreach (var mAgent in _container.MessangerList)
            {
                //Role temptRole = (Role)mAgent.agentRole;
                if (CalculateDistance(agentPosition.Position, mAgent.GetPosition().Position) <= RadioRange && CalculateDistance(agentPosition.Position, mAgent.GetPosition().Position) + CalculateDistance(destPosition.Position, mAgent.GetPosition().Position) < minDist)
                {
                  minDist =  CalculateDistance(agentPosition.Position, mAgent.GetPosition().Position) + CalculateDistance(destPosition.Position, mAgent.GetPosition().Position);
                    nAgent = mAgent;
                }
            }
            return nAgent;
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




    }
}
