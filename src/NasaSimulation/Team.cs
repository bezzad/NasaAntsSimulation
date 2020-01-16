using System;
using System.Collections.Generic;
using Nasa.ANTS.Simulation.Roles;

namespace Nasa.ANTS.Simulation
{
    public class Team
    {
        Random _r;
        public int NumOfAgents { set; get; }
        public int OrganizationId { set; get; }
        public string OrganizationName { set; get; }
        public List<Agent> AgentsArray;
        public Agent OrgLeader;
        public OrganizationBoundries OrganizationBoundries;
        public Container Container;
        //public float rColor { set; get; }
        //public float gColor { set; get; }
        //public float bColor { set; get; }




        public Team(int orgId, string orgName, int agentCount, OrganizationBoundries orgBoundires, Container cont)
        {
            Container = cont;
            _r = Program.R;
            OrganizationBoundries = orgBoundires;
            //rColor = r.Next(256);
            //gColor = r.Next(256);
            //bColor = r.Next(256);
            //orgLowerBoarder = orgLB;
            //orgUpperBoarder = orgUB;
            OrganizationId = orgId;
            orgName = OrganizationName;
            NumOfAgents = agentCount;

            AgentsArray = new List<Agent>(NumOfAgents);
            for (int i = 0; i < NumOfAgents; i++)
            {
                string sId = "W" + OrganizationId + i;
                AgentsArray.Add(createNode(sId));
            }

            OrgLeader = CreateLeader();

        }

        private Agent CreateLeader()
        {
            Agent tempAgent;
            //AgentPosition tempAgentPosition = new AgentPosition();

            //setAgentVelocity(tempAgentPosition);

            AgentPosition tempAgentPosition = setAgentPosition();
            setAgentVelocity(tempAgentPosition);
            string sId = "L" + OrganizationId;
            tempAgent = new Agent(tempAgentPosition, sId, Role.RolesName.Leader, OrganizationBoundries, Container);
            return tempAgent;
        }





        private Agent createNode(string id)
        {
            Agent tempAgent;
            //AgentPosition tempAgentPosition = new AgentPosition();

            //setAgentVelocity(tempAgentPosition);

            AgentPosition tempAgentPosition = setAgentPosition();
            setAgentVelocity(tempAgentPosition);

            tempAgent = new Agent(tempAgentPosition, id, Role.RolesName.Worker, OrganizationBoundries, Container);
            return tempAgent;
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


        private AgentPosition setAgentPosition()
        {
            AgentPosition tempAgentPosition = new AgentPosition();
            double randomRadious = _r.NextDouble() * OrganizationBoundries.Radious;
            double randomdegree = _r.Next(0, 360);
            tempAgentPosition.Position.X = randomRadious * Math.Sin(randomdegree) + OrganizationBoundries.OrgCenter.X;
            tempAgentPosition.Position.Y = randomRadious * Math.Cos(randomdegree) + OrganizationBoundries.OrgCenter.Y;
            return tempAgentPosition;
        }

        public Agent getAgent(int index)
        {
            Agent t = AgentsArray[index];
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

        public void UpdateOrgOneMiliSec()
        {

            foreach (Agent agent in AgentsArray)
            {
                agent.updateOneMiliSec();

            }



        }


    }
}
