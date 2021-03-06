﻿using System;
using System.Collections.Generic;
using System.Linq;
using OpenTK.Graphics.OpenGL;
using Simulation.Roles;
using Simulation.Tools;

namespace Simulation.Core
{
    public class Team
    {
        protected Configuration Config { get; }
        public int NumOfAgents { set; get; }
        public int OrganizationId { set; get; }
        public List<Worker> AgentsArray { set; get; }
        public List<Leader> LeadersHistory { set; get; }
        public Leader ActiveLeader => LeadersHistory?.LastOrDefault();
        public OrganizationBoundries OrganizationBoundries { set; get; }
        public Container Container { get; }


        public Team(Configuration config, int orgId, int agentCount, 
            OrganizationBoundries orgBoundries, Container cont)
        {
            LeadersHistory = new List<Leader>();
            Config = config;
            Container = cont;
            OrganizationBoundries = orgBoundries;
            OrganizationId = orgId;
            NumOfAgents = agentCount;
            LeadersHistory.Add(CreateLeader());
            AgentsArray = new List<Worker>(NumOfAgents);
            for (var i = 0; i < NumOfAgents; i++)
            {
                var sId = "W" + OrganizationId + i;
                var worker = CreateNode(sId);
                worker.LeaderAgent = ActiveLeader;
                AgentsArray.Add(worker);
            }
        }

        private Leader CreateLeader()
        {
            var tempAgentPosition = SetAgentPosition();
            SetAgentVelocity(tempAgentPosition);
            var sId = "L" + OrganizationId;
            var tempAgent = new Leader(this, Config, tempAgentPosition, sId, Container);
            return tempAgent;
        }

        private Worker CreateNode(string id)
        {
            var tempAgentPosition = SetAgentPosition();
            SetAgentVelocity(tempAgentPosition);

            var tempAgent = new Worker(Config, tempAgentPosition, id, OrganizationBoundries, Container);
            return tempAgent;
        }

        private void SetAgentVelocity(AgentPosition agentPosition)
        {
            var v = Config.MaxSpeed / 2;
            v += (Config.Rnd.NextDouble() - 0.5) * Config.MaxSpeed;
            var degree = Config.Rnd.NextDouble() * 360;
            agentPosition.Velocity.Y = v * Math.Sin(degree);
            agentPosition.Velocity.X = v * Math.Cos(degree);
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

        public void UpdateOrgOneMillisecond()
        {

            foreach (var agent in AgentsArray)
            {
                agent.UpdateOneMillisecond();

            }
        }

        public void Draw()
        {
            // Draw circle to show team environment
            GL.Color3(255f, 0f, 0f);
            GL.PointSize(2);
            GL.Begin(PrimitiveType.LineLoop);
            for (var i = 0; i <= 300; i++)
            {
                var angle = 2 * Math.PI * i / 300;
                var x = OrganizationBoundries.Radius * Math.Cos(angle) + OrganizationBoundries.OrgCenter.X + Config.LowerBoarder.X;
                var y = OrganizationBoundries.Radius * Math.Sin(angle) + OrganizationBoundries.OrgCenter.Y + Config.LowerBoarder.Y;
                GL.Vertex2(x, y);
            }
            GL.End();
        }
    }
}
