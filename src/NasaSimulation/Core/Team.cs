using System;
using System.Collections.Generic;
using Simulation.Roles;
using Simulation.Tools;

namespace Simulation.Core
{
    public class Team
    {
        protected Configuration Config { get; }
        public int NumOfAgents { set; get; }
        public int OrganizationId { set; get; }
        public string OrganizationName { set; get; }
        public List<Agent> AgentsArray;
        public Agent OrgLeader;
        public OrganizationBoundries OrganizationBoundries;
        public Container Container;


        public Team(Configuration config, int orgId, int agentCount, OrganizationBoundries orgBoundries, Container cont)
        {
            Config = config;
            Container = cont;
            OrganizationBoundries = orgBoundries;
            OrganizationId = orgId;
            NumOfAgents = agentCount;

            AgentsArray = new List<Agent>(NumOfAgents);
            for (var i = 0; i < NumOfAgents; i++)
            {
                var sId = "W" + OrganizationId + i;
                AgentsArray.Add(CreateNode(sId));
            }

            OrgLeader = CreateLeader();
        }

        private Agent CreateLeader()
        {
            var tempAgentPosition = SetAgentPosition();
            SetAgentVelocity(tempAgentPosition);
            var sId = "L" + OrganizationId;
            var tempAgent = new Agent(Config, tempAgentPosition, sId, Role.RolesName.Leader, OrganizationBoundries, Container);
            return tempAgent;
        }

        private Agent CreateNode(string id)
        {
            var tempAgentPosition = SetAgentPosition();
            SetAgentVelocity(tempAgentPosition);

            var tempAgent = new Agent(Config, tempAgentPosition, id, Role.RolesName.Worker, OrganizationBoundries, Container);
            return tempAgent;
        }

        private void SetAgentVelocity(AgentPosition agentPosition)
        {
            var v = Config.MaxSpeed / 2;
            v += (Config.Rnd.NextDouble() - 0.5) * Config.MaxSpeed;
            var degree = Config.Rnd.NextDouble() * 360;
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


        private AgentPosition SetAgentPosition()
        {
            var tempAgentPosition = new AgentPosition();
            var randomRadius = Config.Rnd.NextDouble() * OrganizationBoundries.Radius;
            double randomDegree = Config.Rnd.Next(0, 360);
            tempAgentPosition.Position.X = randomRadius * Math.Sin(randomDegree) + OrganizationBoundries.OrgCenter.X;
            tempAgentPosition.Position.Y = randomRadius * Math.Cos(randomDegree) + OrganizationBoundries.OrgCenter.Y;
            return tempAgentPosition;
        }

        public Agent GetAgent(int index)
        {
            var t = AgentsArray[index];
            return t;
        }

        public void SubscribeAgent(Agent agent)
        {
            AgentsArray.Add(agent);
        }

        public void UnsubscribeAgent(Agent agent)
        {
            AgentsArray.Remove(agent);
        }

        public void UpdateOrgOneMillisecond()
        {

            foreach (var agent in AgentsArray)
            {
                agent.UpdateOneMillisecond();

            }
        }
    }
}
