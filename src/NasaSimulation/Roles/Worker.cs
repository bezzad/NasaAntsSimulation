using Simulation.Core;
using Simulation.Tools;

namespace Simulation.Roles
{
    public class Worker : Role
    {
        private Container Container { get; }
        private Agent WorkerAgent { get; }

        public Worker(Configuration config, Container cont, Agent agent) 
            : base(config)
        {
            RoleName = RolesName.Worker.ToString();
            Container = cont;
            WorkerAgent = agent;
        }

        private Agent FindNearestMessenger(AgentPosition agentPosition, AgentPosition destPosition)
        {
            double minDist = 10000;
            Agent nAgent = null;
            foreach (var mAgent in Container.MessengerList)
            {
                if (agentPosition.Position.CalculateDistance(mAgent.GetPosition().Position) <= RadioRange &&
                    agentPosition.Position.CalculateDistance(mAgent.GetPosition().Position) +
                    destPosition.Position.CalculateDistance(mAgent.GetPosition().Position) < minDist)
                {
                    minDist = agentPosition.Position.CalculateDistance(mAgent.GetPosition().Position) +
                              destPosition.Position.CalculateDistance(mAgent.GetPosition().Position);
                    nAgent = mAgent;
                }
            }
            return nAgent;
        }
    }
}
