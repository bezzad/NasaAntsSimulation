using System.Collections.Generic;
using Simulation.Core;
using Simulation.Enums;
using Simulation.Roles;

namespace Simulation.Tools
{
    public class Media
    {
        public List<Message> MessageList = new List<Message>();
        readonly Container _container;
        public int MessageCount = 1;
        public Media(Container cont)
        {
            _container = cont;
        }
        public bool SendMessage(Agent sender, Message msg)
        {
            MessageCount++;
            msg.MessageId = MessageCount;
            MessageList.Add(msg);
            //--- must do --- check if this agent is in forbidden area
            AddMessageEventToContainer(MessageCount);
            return true;
        }

        private void AddMessageEventToContainer(int msgId)
        {



            _container.AddEventToQueue(msgId, Program.MsgDelay);
        }

        public bool SendToAgent(Message message, Agent receiver)
        {
            if (receiver.AgentType == Role.RolesName.Messenger)
            {
                var tempMessenger = (Messenger)receiver.AgentRole;
                tempMessenger.GetMessage(message.Copy());
                MessageList.Remove(message);
            }

            else if (receiver.AgentType == Role.RolesName.Worker)
            {
                var tempWorker = (Worker)receiver.AgentRole;
                //tempWorker.GetMessage(message.Copy());
                MessageList.Remove(message);
            }

            else if (receiver.AgentType == Role.RolesName.Ruler)
            {
                var tempRuler = (Ruler)receiver.AgentRole;
                tempRuler.GetAndSendMessage(message.Copy());
                MessageList.Remove(message);
            }

            else if (receiver.AgentType == Role.RolesName.Leader)
            {
                var tempLeader = (Leader)receiver.AgentRole;
                tempLeader.GetMessage(message.Copy());
                MessageList.Remove(message);
            }
            return true;
        }



        public bool SendBroadcastToAgent(Message message, Agent receiver)
        {
            if (receiver.AgentType == Role.RolesName.Messenger)
            {
                var tempMessenger = (Messenger)receiver.AgentRole;
                tempMessenger.GetMessage(message);
                MessageList.Remove(message);
            }

            else if (receiver.AgentType == Role.RolesName.Worker)
            {
                var tempWorker = (Worker)receiver.AgentRole;
                // tempWorker.GetMessage(message);
                MessageList.Remove(message);
            }

            else if (receiver.AgentType == Role.RolesName.Ruler)
            {
                var tempRuler = (Ruler)receiver.AgentRole;
                tempRuler.GetAndSendMessage(message);
                MessageList.Remove(message);
            }

            else if (receiver.AgentType == Role.RolesName.Leader)
            {
                var tempLeader = (Leader)receiver.AgentRole;
                tempLeader.GetMessage(message);
                MessageList.Remove(message);
            }
            return true;
        }

        public bool SendToAgentAndReceive(Message message, Agent receiver)
        {


            if (receiver.AgentType == Role.RolesName.Ruler)
            {
                var tempRuler = (Ruler)receiver.AgentRole;
                tempRuler.GetAndSendMessage(message.Copy());
                MessageList.Remove(message);
            }

            return true;
        }

        public bool DoMessage(int msgId)
        {
            var msgStatus = true;
            var tempMsg = MessageList.Find(
                msg => msg.MessageId == msgId
            );

            switch (tempMsg.MessageType)
            {
                case BroadcastType.Broadcast:
                    {
                        if (tempMsg.CurrentReceiverAgentId == "-1")
                        {
                            var agentList = _container.GetAgentsInRange(tempMsg.CurrentSenderAgent);
                            foreach (var agent in agentList)
                            {

                                var singleMessage = tempMsg.Copy();
                                singleMessage.CurrentReceiverAgent = agent;
                                singleMessage.CurrentReceiverAgentId = agent.AgentId;
                                singleMessage.ReceiverAgent = agent;
                                singleMessage.ReceiverAgentId = agent.AgentId;
                                SendBroadcastToAgent(singleMessage, agent);
                            }
                        }

                        else
                        {
                            var agent = tempMsg.CurrentReceiverAgent;
                            SendToAgent(tempMsg, agent);
                        }
                        break;

                    }
                case BroadcastType.SingleCast:
                    {
                        var agent = tempMsg.CurrentReceiverAgent;
                        SendToAgent(tempMsg, agent);
                        break;
                    }

                case BroadcastType.MessengersToRulersBroadcast:
                    {
                        if (tempMsg.CurrentReceiverAgentId == "-1")
                        {
                            if (tempMsg.NumOfBroadcastSteps == 1)
                            {
                                var agentList = _container.GetRulersInRange(tempMsg.CurrentSenderAgent);
                                foreach (var agent in agentList)
                                {
                                    if (agent.AgentType == Role.RolesName.Ruler && agent.AgentId != tempMsg.SenderAgentId)
                                    {
                                        var singleMessage = tempMsg.Copy();
                                        MessageCount++;
                                        singleMessage.MessageId = MessageCount;
                                        singleMessage.CurrentReceiverAgent = agent;
                                        singleMessage.CurrentReceiverAgentId = agent.AgentId;
                                        singleMessage.ReceiverAgent = agent;
                                        singleMessage.ReceiverAgentId = agent.AgentId;
                                        SendBroadcastToAgent(singleMessage, agent);
                                    }
                                }
                            }
                            else if (tempMsg.NumOfBroadcastSteps == 2)
                            {
                                var agentList = _container.GetRulersInRange(tempMsg.CurrentSenderAgent);
                                foreach (var agent in agentList)
                                {
                                    if (agent.AgentType == Role.RolesName.Ruler && agent.AgentId != tempMsg.SenderAgentId)
                                    {
                                        var singleMessage = tempMsg.Copy();
                                        MessageCount++;
                                        singleMessage.MessageId = MessageCount;
                                        singleMessage.CurrentReceiverAgent = agent;
                                        singleMessage.CurrentReceiverAgentId = agent.AgentId;
                                        singleMessage.ReceiverAgent = agent;
                                        singleMessage.ReceiverAgentId = agent.AgentId;
                                        SendBroadcastToAgent(singleMessage, agent);
                                    }
                                }
                                var messengerAgentList = _container.GetMessengersInRange(tempMsg.CurrentSenderAgent);
                                foreach (var agent in messengerAgentList)
                                {
                                    if (agent.AgentType == Role.RolesName.Messenger && agent.AgentId != tempMsg.CurrentSenderAgentId)
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
                                        SendBroadcastToAgent(lostRulerMessage, agent);

                                    }
                                }
                            }

                            MessageList.Remove(tempMsg);

                        }

                        else
                        {
                            var agent = tempMsg.CurrentReceiverAgent;
                            SendToAgent(tempMsg, agent);
                        }
                        break;
                    }


                case BroadcastType.MessengerToLeaderBroadcast:
                    {
                        if (tempMsg.CurrentReceiverAgentId == "-1")
                        {
                            if (tempMsg.NumOfBroadcastSteps == 1)
                            {
                                var agentList = _container.GetLeadersInRange(tempMsg.CurrentSenderAgent);
                                foreach (var agent in agentList)
                                {
                                    if (agent.AgentType == Role.RolesName.Leader && agent.AgentId != tempMsg.SenderAgentId)
                                    {
                                        var singleMessage = tempMsg.Copy();
                                        MessageCount++;
                                        singleMessage.MessageId = MessageCount;
                                        singleMessage.CurrentReceiverAgent = agent;
                                        singleMessage.CurrentReceiverAgentId = agent.AgentId;
                                        singleMessage.ReceiverAgent = agent;
                                        singleMessage.ReceiverAgentId = agent.AgentId;
                                        SendBroadcastToAgent(singleMessage, agent);
                                    }
                                }
                            }
                            else if (tempMsg.NumOfBroadcastSteps == 2)
                            {
                                var agentList = _container.GetLeadersInRange(tempMsg.CurrentSenderAgent);
                                foreach (var agent in agentList)
                                {
                                    if (agent.AgentType == Role.RolesName.Leader && agent.AgentId != tempMsg.SenderAgentId)
                                    {
                                        var singleMessage = tempMsg.Copy();
                                        MessageCount++;
                                        singleMessage.MessageId = MessageCount;
                                        singleMessage.CurrentReceiverAgent = agent;
                                        singleMessage.CurrentReceiverAgentId = agent.AgentId;
                                        singleMessage.ReceiverAgent = agent;
                                        singleMessage.ReceiverAgentId = agent.AgentId;
                                        SendBroadcastToAgent(singleMessage, agent);
                                    }
                                }
                                var messengerAgentList = _container.GetMessengersInRange(tempMsg.CurrentSenderAgent);
                                foreach (var agent in messengerAgentList)
                                {
                                    if (agent.AgentType == Role.RolesName.Messenger && agent.AgentId != tempMsg.CurrentSenderAgentId)
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
                                        SendBroadcastToAgent(lostRulerMessage, agent);

                                    }
                                }
                            }

                            MessageList.Remove(tempMsg);

                        }

                        else
                        {
                            var agent = tempMsg.CurrentReceiverAgent;
                            SendToAgent(tempMsg, agent);
                        }
                        break;
                    }

                case BroadcastType.MessengerToMessengersBroadcast:
                    {
                        if (tempMsg.CurrentReceiverAgentId == "-1")
                        {
                            var agentList = _container.GetAgentsInRange(tempMsg.CurrentSenderAgent);
                            foreach (var agent in agentList)
                            {
                                if (agent.AgentType == Role.RolesName.Messenger)
                                {
                                    var singleMessage = tempMsg.Copy();
                                    MessageCount++;
                                    singleMessage.MessageId = MessageCount;
                                    singleMessage.CurrentReceiverAgent = agent;
                                    singleMessage.CurrentReceiverAgentId = agent.AgentId;
                                    singleMessage.ReceiverAgent = agent;
                                    singleMessage.ReceiverAgentId = agent.AgentId;
                                    SendBroadcastToAgent(singleMessage, agent);
                                }
                            }
                        }


                        else
                        {
                            var agent = tempMsg.CurrentReceiverAgent;
                            SendToAgent(tempMsg, agent);
                        }
                        break;
                    }

                case BroadcastType.MessengerToWorkersBroadcast:
                    {
                        if (tempMsg.ReceiverAgentId == "-1")
                        {
                            var agentList = _container.GetAgentsInRange(tempMsg.CurrentSenderAgent);
                            foreach (var agent in agentList)
                            {
                                if (agent.AgentType == Role.RolesName.Worker)
                                {
                                    var singleMessage = tempMsg.Copy();
                                    MessageCount++;
                                    singleMessage.MessageId = MessageCount;
                                    singleMessage.CurrentReceiverAgent = agent;
                                    singleMessage.CurrentReceiverAgentId = agent.AgentId;
                                    singleMessage.ReceiverAgent = agent;
                                    singleMessage.ReceiverAgentId = agent.AgentId;
                                    SendBroadcastToAgent(singleMessage, agent);
                                }
                            }
                        }
                        else
                        {
                            var agent = tempMsg.CurrentReceiverAgent;
                            SendToAgent(tempMsg, agent);
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

                            msgStatus = SendToAgentAndReceive(tempMsg, agent);
                        }

                        else
                        {
                            var agent = tempMsg.CurrentReceiverAgent;
                            msgStatus = SendToAgent(tempMsg, agent);
                        }
                        break;
                    }
            }
            return msgStatus;
        }
    }
}