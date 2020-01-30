using OpenTK.Graphics.OpenGL;
using Simulation.Core;
using Simulation.Tools;

namespace Simulation.Roles
{
    public class Worker : Agent
    {
        protected OrganizationBoundries TeamBoundary { get; set; }

        public Worker(Configuration config, AgentPosition pos, string id, 
            OrganizationBoundries orgBoundary, Container cont) 
            : base(config, pos, id, cont)
        {
            TeamBoundary = orgBoundary;
        }

        private Messenger FindNearestMessenger(AgentPosition agentPosition, AgentPosition destPosition)
        {
            double minDist = 10000;
            Messenger nAgent = null;
            foreach (var mAgent in Container.MessengerList)
            {
                if (agentPosition.Position.CalculateDistance(mAgent.Position.Position) <= RadioRange &&
                    agentPosition.Position.CalculateDistance(mAgent.Position.Position) +
                    destPosition.Position.CalculateDistance(mAgent.Position.Position) < minDist)
                {
                    minDist = agentPosition.Position.CalculateDistance(mAgent.Position.Position) +
                              destPosition.Position.CalculateDistance(mAgent.Position.Position);
                    nAgent = mAgent;
                }
            }
            return nAgent;
        }

        protected override void Movement()
        {
            base.Movement();


            if (Position.Position.CalculateDistance(TeamBoundary.OrgCenter) > TeamBoundary.Radius)
            {
                Position.Position.X = TeamBoundary.OrgCenter.X;
                Position.Position.Y = TeamBoundary.OrgCenter.Y;
            }

            if (Time.GlobalSimulationTime > 1000 & Time.GlobalSimulationTime % 1000 == 0)
            {
                UpdateVelocity(Position);
            }
        }

        protected override void FreeMovement()
        {
            base.FreeMovement();

            if (Position.Position.X > (Config.UpperBoarder.X - Config.LowerBoarder.X)) Position.Position.X = 0;
            if (Position.Position.X < 0) Position.Position.X = (Config.UpperBoarder.X + Config.LowerBoarder.X);
            if (Position.Position.Y > (Config.UpperBoarder.Y - Config.LowerBoarder.Y)) Position.Position.Y = 0;
            if (Position.Position.Y < 0) Position.Position.Y = (Config.UpperBoarder.Y + Config.LowerBoarder.Y);

            if (Time.GlobalSimulationTime > 1000 & Time.GlobalSimulationTime % 1000 == 0)
                UpdateVelocity(Position);
        }

        public override void Draw()
        {
            var p = Position.Position;
            GL.Color3(125f, 125f, 0f);
            GL.Begin(PrimitiveType.Points);
            GL.Vertex2(p.X, p.Y);
            GL.End();
        }
    }
}
