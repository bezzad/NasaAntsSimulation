namespace Simulation.Enums
{
    public enum BroadcastType
    {
        Broadcast,
        MessengerBroadcast,
        MessengerToMessengersBroadcast,
        MessengersToRulersBroadcast,
        MessengerToLeaderBroadcast,
        MessengerToWorkersBroadcast,
        SingleCast,
        MessengerToLeadersAndMessengersBroadcast,
        SendReceive
    }
}
