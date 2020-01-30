using Simulation.Tools;

namespace Simulation.Core
{
    public class Agent
    {
        protected Configuration Config { get; }
        protected Container Container { get; }
        protected AgentPosition Position { get; }
        public string AgentId { set; get; }
        public double RadioRange { set; get; }


        public Agent(Configuration config, AgentPosition position, string id, Container cont)
        {
            Config = config;
            Container = cont;
            Position = position;
            AgentId = id;
            RadioRange = Config.MaxRadioRange;
        }


        public virtual void UpdateOneMillisecond()
        {
            Movement();
        }
        public virtual void FreeUpdateOneMillisecond()
        {
            FreeMovement();
        }
        public AgentPosition GetPosition()
        {
            return Position;
        }
        protected virtual void Movement()
        {
            Position.Position.X += Position.Velocity.X / 1500;
            Position.Position.Y += Position.Velocity.Y / 1500;
        }
        protected virtual void FreeMovement()
        {
            Position.Position.X += Position.Velocity.X / Config.UpperBoarder.X;
            Position.Position.Y += Position.Velocity.Y / Config.UpperBoarder.Y;
        }
        protected void UpdateVelocity(AgentPosition position)
        {
            var t1 = Config.Rnd.NextDouble();
            t1 = (t1 - 0.5) * 2;
            var t2 = Config.Rnd.NextDouble();
            t2 = (t2 - 0.5) * 2;

            if ((position.Velocity.X * position.Velocity.X) + (position.Velocity.Y * position.Velocity.Y) > (Config.MaxSpeed * Config.MaxSpeed))
            {
                position.Velocity.X /= 2;
                position.Velocity.Y /= 2;
            }

            position.Velocity.X += t1;
            position.Velocity.Y += t2;
        }
    }
}
