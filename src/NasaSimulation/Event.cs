using Simulation.Enums;

namespace Simulation
{
    public struct Event
    {
        public EventType EventType { set; get; }
        public int MessageId { set; get; }
        public long EventTime { set; get; }
    }
}
