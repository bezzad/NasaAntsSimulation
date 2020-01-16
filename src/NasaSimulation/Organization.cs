using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ThesisSimulation
{
    class Organization
    {
        Random r;
        public int numOfAgents { set; get;}
        public int organizationID { set; get;}
        public string organizationName { set; get; }
        List<Agent> agentsArray;
        twoDimentionParameter orgUpperBoarder;
        twoDimentionParameter orgLowerBoarder;

        public Organization(int orgID, string orgName, int agentCount)
        {
            r = Program.r;
            organizationID = orgID;
            orgName = organizationName;
            numOfAgents = agentCount;
            agentsArray = new List<Agent>(numOfAgents);
            for (int i = 0; i < numOfAgents; i++)
            {
                agentsArray.Add(createNode(i));
            }
        }

         private Agent createNode(int ID)
         {
            Agent tempAgent;
            AgentPosition tempAgentPosition = new AgentPosition();
            setAgentPosition(tempAgentPosition);
            setAgentVelocity(tempAgentPosition);
           // tempAgent = new Agent(tempAgentPosition,ID,Role.RolesName.Worker,new organizationBoundries(),);
            return tempAgent;
         }

         private void setAgentVelocity(AgentPosition agentPosition)
         {


             double V = Program.MAXSPEED / 2;
             V = V + ((r.NextDouble() - 0.5) * Program.MAXSPEED);
             double degree = r.NextDouble() * 360;
             agentPosition.Velocity.Y = V * Math.Sin(r.NextDouble());
             agentPosition.Velocity.X = V * Math.Cos(r.NextDouble());

             if (degree >= 90 && degree < 180)
             {
                 agentPosition.Velocity.X *= -1;
             }
             if (degree >= 180 && degree < 270)
             {
                 agentPosition.Velocity.X *= -1;
                 agentPosition.Velocity.Y *= -1;
             }
             if (degree >= 270 && degree <= 360)
             {
                 agentPosition.Velocity.Y *= -1;
             }

         }


         private void setAgentPosition(AgentPosition tempAgentPosition)
         {
             tempAgentPosition.Position.X = (r.NextDouble() * (orgUpperBoarder.X - orgLowerBoarder.X)) + orgLowerBoarder.X;
             tempAgentPosition.Position.Y = (r.NextDouble() * (orgUpperBoarder.Y - orgLowerBoarder.Y)) + orgLowerBoarder.Y;
         }

         public Agent getAgent(int index)
         {
             Agent t = agentsArray[index];
             return t;
         }

        public void SubscribeAgent(Agent agent)
        {
            agentsArray.Add(agent);
        }

        public void UnsubscribeAgent(Agent agent)
        {
            agentsArray.Remove(agent);         
        }
    }
}
