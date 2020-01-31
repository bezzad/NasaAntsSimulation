using System.Collections.Generic;
using Simulation.Core;
using Simulation.Enums;
using Simulation.Roles;

namespace Simulation.Tools
{
    public class Media
    {
        public Media(Configuration config, Container cont)
        {
            Config = config;
            Container = cont;
            MessageList = new List<Message>();
        }


        protected Configuration Config { get; }
        protected Container Container { get; }
        protected List<Message> MessageList { get; set; }
        public int MessageCount { get; set; }


        public bool SendMessage(Message msg)
        {
            msg.MessageId = ++MessageCount;
            MessageList.Add(msg);
            //--- must do --- check if this agent is in forbidden area
            AddMessageEventToContainer(MessageCount);
            return true;
        }

        protected void AddMessageEventToContainer(int msgId)
        {
            Container.AddEventToQueue(msgId, Config.MsgDelay);
        }

        protected bool SendMessage(Message message, Agent receiver)
        {
            receiver.OnMessage(message);
            MessageList.Remove(message);
            return true;
        }

        internal bool DoMessage(int msgId)
        {
            var msgStatus = true;
            var tempMsg = MessageList.Find(msg => msg.MessageId == msgId);

            switch (tempMsg.MessageType)
            {
                case BroadcastType.Broadcast:
                    {
                        if (tempMsg.CurrentReceiverAgentId == "-1")
                        {
                            var agentList = Container.GetAgentsInRange(tempMsg.CurrentSenderAgent);
                            foreach (var agent in agentList)
                            {

                                var singleMessage = tempMsg.Copy();
                                singleMessage.CurrentReceiverAgent = agent;
                                singleMessage.CurrentReceiverAgentId = agent.AgentId;
                                singleMessage.ReceiverAgent = agent;
                                singleMessage.ReceiverAgentId = agent.AgentId;
                                SendMessage(singleMessage, agent);
                            }
                        }

                        else
                        {
                            var agent = tempMsg.CurrentReceiverAgent;
                            SendMessage(tempMsg, agent);
                        }
                        break;

                    }

                case BroadcastType.SingleCast:
                    {
                        SendMessage(tempMsg, tempMsg.CurrentReceiverAgent);
                        break;
                    }

                case BroadcastType.MessengersToRulersBroadcast:
                    {
                        if (tempMsg.CurrentReceiverAgentId == "-1")
                        {
                            if (tempMsg.NumOfBroadcastSteps == 1)
                            {
                                var agentList = Container.GetRulersInRange(tempMsg.CurrentSenderAgent);
                                foreach (var agent in agentList)
                                {
                                    if (agent is Ruler && agent.AgentId != tempMsg.SenderAgentId)
                                    {
                                        var singleMessage = tempMsg.Copy();
                                        MessageCount++;
                                        singleMessage.MessageId = MessageCount;
                                        singleMessage.CurrentReceiverAgent = agent;
                                        singleMessage.CurrentReceiverAgentId = agent.AgentId;
                                        singleMessage.ReceiverAgent = agent;
                                        singleMessage.ReceiverAgentId = agent.AgentId;
                                        SendMessage(singleMessage, agent);
                                    }
                                }
                            }
                            else if (tempMsg.NumOfBroadcastSteps == 2)
                            {
                                var agentList = Container.GetRulersInRange(tempMsg.CurrentSenderAgent);
                                foreach (var agent in agentList)
                                {
                                    if (agent is Ruler && agent.AgentId != tempMsg.SenderAgentId)
                                    {
                                        var singleMessage = tempMsg.Copy();
                                        MessageCount++;
                                        singleMessage.MessageId = MessageCount;
                                        singleMessage.CurrentReceiverAgent = agent;
                                        singleMessage.CurrentReceiverAgentId = agent.AgentId;
                                        singleMessage.ReceiverAgent = agent;
                                        singleMessage.ReceiverAgentId = agent.AgentId;
                                        SendMessage(singleMessage, agent);
                                    }
                                }
                                var messengerAgentList = Container.GetMessengersInRange(tempMsg.CurrentSenderAgent);
                                foreach (var agent in messengerAgentList)
                                {
                                    if (agent is Messenger && agent.AgentId != tempMsg.CurrentSenderAgentId)
                                    {
                                        var lostRulerMessage = tempMsg.Copy();
                                        MessageCount++;
                                        lostRulerMessage.MessageId = MessageCount;
                                        lostRulerMessage.CurrentReceiverAgent = agent;
                                        lostRulerMessage.CurrentReceiverAgentId = agent.AgentId;
                                        lostRulerMessage.ReceiverAgent = null;
                                        lostRulerMessage.ReceiverAgentId = "-1";

                                        lostRulerMessage.MessageType = BroadcastType.MessengersToRulersBroadcast;
                                        lostRulerMessage.NumOfBroadcastSteps = 1;

                                        lostRulerMessage.MessageContent = MessagesContent.LostRuler;
                                        SendMessage(lostRulerMessage, agent);
                                    }
                                }
                            }

                            MessageList.Remove(tempMsg);
                        }

                        else
                        {
                            var agent = tempMsg.CurrentReceiverAgent;
                            SendMessage(tempMsg, agent);
                        }
                        break;
                    }

                case BroadcastType.MessengerToLeaderBroadcast:
                    {
                        if (tempMsg.CurrentReceiverAgentId == "-1")
                        {
                            if (tempMsg.NumOfBroadcastSteps == 1)
                            {
                                var agentList = Container.GetLeadersInRange(tempMsg.CurrentSenderAgent);
                                foreach (var agent in agentList)
                                {
                                    if (agent is Leader && agent.AgentId != tempMsg.SenderAgentId)
                                    {
                                        var singleMessage = tempMsg.Copy();
                                        MessageCount++;
                                        singleMessage.MessageId = MessageCount;
                                        singleMessage.CurrentReceiverAgent = agent;
                                        singleMessage.CurrentReceiverAgentId = agent.AgentId;
                                        singleMessage.ReceiverAgent = agent;
                                        singleMessage.ReceiverAgentId = agent.AgentId;
                                        SendMessage(singleMessage, agent);
                                    }
                                }
                            }
                            else if (tempMsg.NumOfBroadcastSteps == 2)
                            {
                                var agentList = Container.GetLeadersInRange(tempMsg.CurrentSenderAgent);
                                foreach (var agent in agentList)
                                {
                                    if (agent is Leader && agent.AgentId != tempMsg.SenderAgentId)
                                    {
                                        var singleMessage = tempMsg.Copy();
                                        MessageCount++;
                                        singleMessage.MessageId = MessageCount;
                                        singleMessage.CurrentReceiverAgent = agent;
                                        singleMessage.CurrentReceiverAgentId = agent.AgentId;
                                        singleMessage.ReceiverAgent = agent;
                                        singleMessage.ReceiverAgentId = agent.AgentId;
                                        SendMessage(singleMessage, agent);
                                    }
                                }
                                var messengerAgentList = Container.GetMessengersInRange(tempMsg.CurrentSenderAgent);
                                foreach (var agent in messengerAgentList)
                                {
                                    if (agent is Messenger && agent.AgentId != tempMsg.CurrentSenderAgentId)
                                    {
                                        var lostRulerMessage = tempMsg.Copy();
                                        MessageCount++;
                                        lostRulerMessage.MessageId = MessageCount;
                                        lostRulerMessage.CurrentReceiverAgent = agent;
                                        lostRulerMessage.CurrentReceiverAgentId = agent.AgentId;
                                        lostRulerMessage.ReceiverAgent = null;
                                        lostRulerMessage.ReceiverAgentId = "-1";

                                        lostRulerMessage.MessageType = BroadcastType.MessengerToLeaderBroadcast;
                                        lostRulerMessage.NumOfBroadcastSteps = 1;



                                        lostRulerMessage.MessageContent = MessagesContent.LostRuler;
                                        SendMessage(lostRulerMessage, agent);

                                    }
                                }
                            }

                            MessageList.Remove(tempMsg);
                        }
                        else
                        {
                            var agent = tempMsg.CurrentReceiverAgent;
                            SendMessage(tempMsg, agent);
                        }
                        break;
                    }

                case BroadcastType.MessengerToMessengersBroadcast:
                    {
                        if (tempMsg.CurrentReceiverAgentId == "-1")
                        {
                            var agentList = Container.GetAgentsInRange(tempMsg.CurrentSenderAgent);
                            foreach (var agent in agentList)
                            {
                                if (agent is Messenger)
                                {
                                    var singleMessage = tempMsg.Copy();
                                    MessageCount++;
                                    singleMessage.MessageId = MessageCount;
                                    singleMessage.CurrentReceiverAgent = agent;
                                    singleMessage.CurrentReceiverAgentId = agent.AgentId;
                                    singleMessage.ReceiverAgent = agent;
                                    singleMessage.ReceiverAgentId = agent.AgentId;
                                    SendMessage(singleMessage, agent);
                                }
                            }
                        }
                        else
                        {
                            var agent = tempMsg.CurrentReceiverAgent;
                            SendMessage(tempMsg, agent);
                        }
                        break;
                    }

                case BroadcastType.MessengerToWorkersBroadcast:
                    {
                        if (tempMsg.ReceiverAgentId == "-1")
                        {
                            var agentList = Container.GetAgentsInRange(tempMsg.CurrentSenderAgent);
                            foreach (var agent in agentList)
                            {
                                if (agent is Worker)
                                {
                                    var singleMessage = tempMsg.Copy();
                                    MessageCount++;
                                    singleMessage.MessageId = MessageCount;
                                    singleMessage.CurrentReceiverAgent = agent;
                                    singleMessage.CurrentReceiverAgentId = agent.AgentId;
                                    singleMessage.ReceiverAgent = agent;
                                    singleMessage.ReceiverAgentId = agent.AgentId;
                                    SendMessage(singleMessage, agent);
                                }
                            }
                        }
                        else
                        {
                            var agent = tempMsg.CurrentReceiverAgent;
                            SendMessage(tempMsg, agent);
                        }
                        break;
                    }

                case BroadcastType.SendReceive:
                    {
                        if (tempMsg.ReceiverAgentId == "-1")
                        {
                            //List<Agent> agentList = container.getAgentsInRange(tempMSG.senderAgent);
                            //foreach (Agent agent in agentList)
                            //{
                            //    if (agent.agentType == Role.RolesName.Worker)
                            //    {
                            //        sendToAgent(tempMSG, agent);

                            //    }

                            //}
                        }

                        else if (tempMsg.CurrentReceiverAgentId == tempMsg.ReceiverAgentId)
                        {
                            var agent = tempMsg.CurrentReceiverAgent;
                            msgStatus = SendMessage(tempMsg, agent);
                        }

                        else
                        {
                            var agent = tempMsg.CurrentReceiverAgent;
                            msgStatus = SendMessage(tempMsg, agent);
                        }
                        break;
                    }
            }
            return msgStatus;
        }
    }
}