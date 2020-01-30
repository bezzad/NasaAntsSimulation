using Simulation.Enums;

namespace Simulation.Tools
{
    public struct Event
    {
        public EventType EventType { set; get; }
        public int MessageId { set; get; }
        public long EventTime { set; get; }
    }
}
