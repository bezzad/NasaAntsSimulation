using System.Collections.Generic;

namespace Simulation
{
    public class Message
    {  
        public int     MessageId { set; get; }
        public Agent   SenderAgent { set; get; }
        public Agent   ReciverAgent { set; get; }
        public Agent   CurrentSenderAgent { set; get; }
        public Agent   CurrentReciverAgent { set; get; }
        public string  SenderAgentId { set; get; }
        public string  RecieverAgentId { set; get; }
        public string  CurrentSenderAgentId { set; get; }
        public string  CurrentRecieverAgentId { set; get; }
        public Program.BroadcastType MessageType { set; get; }
        public int     ReturnedStatus { set; get; }
        public Program.MessagesContent MessageContent { set; get; }
        public Agent   RulerPingReply { set; get; }
        public string  DataMessageText { set; get; }
        public int NumOfBoroadcastSteps { set; get; }
        public long RoutingTime {set;get;}
        public List<Agent> RoutingList = new List<Agent>();
        public  Message Copy()
        {
            var tempMessage = new Message();
            tempMessage.MessageId = this.MessageId;
            tempMessage.SenderAgent = this.SenderAgent;
            tempMessage.SenderAgentId = this.SenderAgentId;
            tempMessage.ReciverAgent = this.ReciverAgent;
            tempMessage.RecieverAgentId = this.RecieverAgentId;
            tempMessage.CurrentSenderAgent = this.CurrentSenderAgent;
            tempMessage.CurrentSenderAgentId = this.CurrentSenderAgentId;
            tempMessage.CurrentReciverAgent = this.CurrentReciverAgent;
            tempMessage.CurrentRecieverAgentId = this.CurrentRecieverAgentId;
            tempMessage.MessageType = this.MessageType;
            tempMessage.ReturnedStatus = this.ReturnedStatus;
            tempMessage.MessageContent = this.MessageContent;
            tempMessage.RulerPingReply = this.RulerPingReply;
            tempMessage.DataMessageText = this.DataMessageText;
            tempMessage.NumOfBoroadcastSteps = this.NumOfBoroadcastSteps;
            tempMessage.RoutingList = this.RoutingList;
            tempMessage.RoutingTime = this.RoutingTime;
            return tempMessage;
        }
    }
}
