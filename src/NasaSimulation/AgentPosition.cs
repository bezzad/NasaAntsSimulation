using Simulation.Tools;

namespace Simulation
{
    public class AgentPosition
    {
        public AgentPosition()
        {
            Position = new Point();
            Velocity = new Point();
        }

        public Point Position { get; set; }
        public Point Velocity { get; set; }
    }
}