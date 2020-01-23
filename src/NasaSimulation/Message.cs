using System.Collections.Generic;

namespace Simulation
{
    public class Message
    {
        public int MessageId { set; get; }
        public Agent SenderAgent { set; get; }
        public Agent ReceiverAgent { set; get; }
        public Agent CurrentSenderAgent { set; get; }
        public Agent CurrentReceiverAgent { set; get; }
        public string SenderAgentId { set; get; }
        public string ReceiverAgentId { set; get; }
        public string CurrentSenderAgentId { set; get; }
        public string CurrentReceiverAgentId { set; get; }
        public Program.BroadcastType MessageType { set; get; }
        public int ReturnedStatus { set; get; }
        public Program.MessagesContent MessageContent { set; get; }
        public Agent RulerPingReply { set; get; }
        public string DataMessageText { set; get; }
        public int NumOfBroadcastSteps { set; get; }
        public long RoutingTime { set; get; }
        public List<Agent> RoutingList = new List<Agent>();
        public Message Copy()
        {
            var tempMessage = new Message
            {
                MessageId = MessageId,
                SenderAgent = SenderAgent,
                SenderAgentId = SenderAgentId,
                ReceiverAgent = ReceiverAgent,
                ReceiverAgentId = ReceiverAgentId,
                CurrentSenderAgent = CurrentSenderAgent,
                CurrentSenderAgentId = CurrentSenderAgentId,
                CurrentReceiverAgent = CurrentReceiverAgent,
                CurrentReceiverAgentId = CurrentReceiverAgentId,
                MessageType = MessageType,
                ReturnedStatus = ReturnedStatus,
                MessageContent = MessageContent,
                RulerPingReply = RulerPingReply,
                DataMessageText = DataMessageText,
                NumOfBroadcastSteps = NumOfBroadcastSteps,
                RoutingList = RoutingList,
                RoutingTime = RoutingTime
            };
            return tempMessage;
        }
    }
}
