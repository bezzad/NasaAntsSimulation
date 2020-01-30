using System;
using System.Collections.Generic;
using Simulation.Roles;
using Simulation.Tools;

namespace Simulation
{
    public class Team
    {
        readonly Random _random;
        public int NumOfAgents { set; get; }
        public int OrganizationId { set; get; }
        public string OrganizationName { set; get; }
        public List<Agent> AgentsArray;
        public Agent OrgLeader;
        public OrganizationBoundries OrganizationBoundries;
        public Container Container;


        public Team(int orgId, int agentCount, OrganizationBoundries orgBoundries, Container cont)
        {
            Container = cont;
            _random = Program.R;
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
            var tempAgent = new Agent(tempAgentPosition, sId, Role.RolesName.Leader, OrganizationBoundries, Container);
            return tempAgent;
        }

        private Agent CreateNode(string id)
        {
            var tempAgentPosition = SetAgentPosition();
            SetAgentVelocity(tempAgentPosition);

            var tempAgent = new Agent(tempAgentPosition, id, Role.RolesName.Worker, OrganizationBoundries, Container);
            return tempAgent;
        }

        private void SetAgentVelocity(AgentPosition agentPosition)
        {
            double v = Program.MaxSpeed / 2;
            v += (_random.NextDouble() - 0.5) * Program.MaxSpeed;
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


        private AgentPosition SetAgentPosition()
        {
            var tempAgentPosition = new AgentPosition();
            var randomRadius = _random.NextDouble() * OrganizationBoundries.Radius;
            double randomDegree = _random.Next(0, 360);
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
