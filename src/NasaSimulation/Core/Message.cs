using Simulation.Enums;
using Simulation.Roles;
using System.Collections.Generic;

namespace Simulation.Core
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
        public BroadcastType MessageType { set; get; }
        public MessagesContent MessageContent { set; get; }
        public Ruler RulerPingReply { set; get; }
        public string DataMessageText { set; get; }
        public object Data { set; get; }
        public int NumOfBroadcastSteps { set; get; }
        public long RoutingTime { set; get; }
        public List<Agent> RoutingList { set; get; } = new List<Agent>();


        public Message Copy()
        {
            var type = typeof(Message);
            var properties = type.GetProperties();
            var clonedMessage = new Message();

            foreach (var property in properties)
            {
                var value = property.GetValue(this);
                property.SetValue(clonedMessage, value);
            }
            
            return clonedMessage;
        }
    }
}
