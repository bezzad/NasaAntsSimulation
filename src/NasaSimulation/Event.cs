namespace Nasa.ANTS.Simulation
{
    public enum EventType { Message, BroadcastMessage };
    public struct Event
    {
        public EventType EventType { set; get; }
        public int MessageId { set; get; }
        public long EventTime { set; get; }
    }
}
