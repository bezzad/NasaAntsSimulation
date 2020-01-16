using System;

namespace Nasa.ANTS.Simulation.Roles
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

        internal void getMessage(Message message)
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
            foreach (Agent mAgent in _container.MessangerList)
            {
                //Role temptRole = (Role)mAgent.agentRole;
                if (calculateDistance(agentPosition.Position, mAgent.getPosition().Position) <= RadioRange && calculateDistance(agentPosition.Position, mAgent.getPosition().Position) + calculateDistance(destPosition.Position, mAgent.getPosition().Position) < minDist)
                {
                  minDist =  calculateDistance(agentPosition.Position, mAgent.getPosition().Position) + calculateDistance(destPosition.Position, mAgent.getPosition().Position);
                    nAgent = mAgent;
                }
            }
            return nAgent;
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




    }
}
