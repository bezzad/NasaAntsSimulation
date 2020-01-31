using Simulation.Enums;
using Simulation.Roles;
using Simulation.Tools;

namespace Simulation.Core
{
    public abstract class Agent
    {
        protected Agent(Configuration config, AgentPosition position, string id, Container cont)
        {
            Config = config;
            Container = cont;
            Position = position;
            AgentId = id;
            RadioRange = Config.MaxRadioRange;
        }



        protected Configuration Config { get; }
        protected Container Container { get; }
        public string AgentId { set; get; }
        public double RadioRange { set; get; }
        public AgentPosition Position { get; }
        public State Status { set; get; }
        
        
        public virtual void UpdateOneMillisecond()
        {
            Movement();
        }
        public virtual void FreeUpdateOneMillisecond()
        {
            FreeMovement();
        }
        protected virtual void Movement()
        {
            Position.Position.X += Position.Velocity.X / Config.UpperBoarder.X;
            Position.Position.Y += Position.Velocity.Y / Config.UpperBoarder.Y;
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
        protected Messenger FindNearestMessenger(AgentPosition destPosition)
        {
            double minMessengerDistance = 10000;
            Messenger messenger = null;

            foreach (var mAgent in Container.MessengerList)
            {
                if (Position.Position.CalculateDistance(mAgent.Position.Position) <= RadioRange &&
                    Position.Position.CalculateDistance(mAgent.Position.Position) +
                    destPosition.Position.CalculateDistance(mAgent.Position.Position) < minMessengerDistance)
                {
                    minMessengerDistance = Position.Position.CalculateDistance(mAgent.Position.Position) +
                                           destPosition.Position.CalculateDistance(mAgent.Position.Position);
                    messenger = mAgent;
                }
            }
            return messenger;
        }
        protected Messenger FindNearestMessenger()
        {
            double minMessengerDistance = 10000;
            Messenger messenger = null;

            foreach (var mAgent in Container.MessengerList)
            {
                if (Position.Position.CalculateDistance(mAgent.Position.Position) <= RadioRange &&
                    Position.Position.CalculateDistance(mAgent.Position.Position) < minMessengerDistance)
                {
                    minMessengerDistance = Position.Position.CalculateDistance(mAgent.Position.Position);
                    messenger = mAgent;
                }
            }
            return messenger;
        }

        public abstract void Draw();
    }
}
