using OpenTK.Graphics.OpenGL;
using Simulation.Core;
using Simulation.Tools;

namespace Simulation.Roles
{
    public class Worker : Agent
    {
        public Worker(Configuration config, AgentPosition pos, string id, 
            OrganizationBoundries orgBoundary, Container cont) 
            : base(config, pos, id, cont)
        {
            TeamBoundary = orgBoundary;
        }


        protected OrganizationBoundries TeamBoundary { get; set; }


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
                // go back to center slowly
                Position.Velocity.X *= -1; 
                Position.Velocity.Y *= -1;
                UpdateVelocity(Position);
            }
        }

        protected override void FreeMovement()
        {
            base.FreeMovement();

            if (Position.Position.X > Config.UpperBoarder.X - Config.LowerBoarder.X)
            {
                Position.Velocity.X *= -1;
                UpdateVelocity(Position);
            }
            if (Position.Position.X < 0)
            {
                Position.Position.X = Config.LowerBoarder.X;
                Position.Velocity.X *= -1;
                UpdateVelocity(Position);
            }

            if (Position.Position.Y > Config.UpperBoarder.Y - Config.LowerBoarder.Y)
            {
                Position.Velocity.Y *= -1;
                UpdateVelocity(Position);
            }
            if (Position.Position.Y < 0)
            {
                Position.Position.Y = Config.LowerBoarder.Y;
                Position.Velocity.Y *= -1;
                UpdateVelocity(Position);
            }
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
