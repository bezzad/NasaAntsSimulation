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
                MessageId = this.MessageId,
                SenderAgent = this.SenderAgent,
                SenderAgentId = this.SenderAgentId,
                ReceiverAgent = this.ReceiverAgent,
                ReceiverAgentId = this.ReceiverAgentId,
                CurrentSenderAgent = this.CurrentSenderAgent,
                CurrentSenderAgentId = this.CurrentSenderAgentId,
                CurrentReceiverAgent = this.CurrentReceiverAgent,
                CurrentReceiverAgentId = this.CurrentReceiverAgentId,
                MessageType = this.MessageType,
                ReturnedStatus = this.ReturnedStatus,
                MessageContent = this.MessageContent,
                RulerPingReply = this.RulerPingReply,
                DataMessageText = this.DataMessageText,
                NumOfBroadcastSteps = this.NumOfBroadcastSteps,
                RoutingList = this.RoutingList,
                RoutingTime = this.RoutingTime
            };
            return tempMessage;
        }
    }
}
