﻿using System.Collections.Generic;
using Simulation.Roles;

namespace Simulation
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
            //--- must do --- check if this agent is in forbiden area
            //------------------
            AddMessageEventToContainer(MessageCount);
            return true;
        }

        private void AddMessageEventToContainer(int msgId)
        {



            _container.AddEventToQeue(msgId, Program.Msgdelay);
        }

        public bool SendToAgent(Message message, Agent reciever)
        {
            if (reciever.AgentType == Role.RolesName.Messenger)
            {
                var tempMesenger = (Messenger)reciever.AgentRole;
                tempMesenger.GetMessage(message.Copy());
                MessageList.Remove(message);
            }

            else if (reciever.AgentType == Role.RolesName.Worker)
            {
                var tempWorker = (Worker)reciever.AgentRole;
                tempWorker.GetMessage(message.Copy());
                MessageList.Remove(message);
            }

            else if (reciever.AgentType == Role.RolesName.Ruler)
            {
                var tempRuler = (Ruler)reciever.AgentRole;
                tempRuler.GetandSendMessage(message.Copy());
                MessageList.Remove(message);
            }

            else if (reciever.AgentType == Role.RolesName.Leader)
            {
                var tempLeader = (Leader)reciever.AgentRole;
                tempLeader.GetMessage(message.Copy());
                MessageList.Remove(message);
            }
            return true;
        }



        public bool SendBroadcastToAgent(Message message, Agent reciever)
        {
            if (reciever.AgentType == Role.RolesName.Messenger)
            {
                var tempMesenger = (Messenger)reciever.AgentRole;
                tempMesenger.GetMessage(message);
                MessageList.Remove(message);
            }

            else if (reciever.AgentType == Role.RolesName.Worker)
            {
                var tempWorker = (Worker)reciever.AgentRole;
                tempWorker.GetMessage(message);
                MessageList.Remove(message);
            }

            else if (reciever.AgentType == Role.RolesName.Ruler)
            {
                var tempRuler = (Ruler)reciever.AgentRole;
                tempRuler.GetandSendMessage(message);
                MessageList.Remove(message);
            }

            else if (reciever.AgentType == Role.RolesName.Leader)
            {
                var tempLeader = (Leader)reciever.AgentRole;
                tempLeader.GetMessage(message);
                var x = MessageList.Remove(message);
            }
            return true;
        }

        public bool SendToAgentAndRecieve(Message message, Agent reciever)
        {


            if (reciever.AgentType == Role.RolesName.Ruler)
            {
                var tempRuler = (Ruler)reciever.AgentRole;
                tempRuler.GetandSendMessage(message.Copy());
                MessageList.Remove(message);
            }

            return true;
        }

        public bool DoMessage(int msgId)
        {
            var msgStatus = true;
            var tempMsg = MessageList.Find(
                delegate (Message msg)
                {
                    return msg.MessageId == msgId;
                }
                );


            if (tempMsg == null)
            {
                var r = 0;
            }
            switch (tempMsg.MessageType)
            {
                case Program.BroadcastType.Broadcast:
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
                case Program.BroadcastType.SingleCast:
                    {
                        var agent = tempMsg.CurrentReceiverAgent;
                        SendToAgent(tempMsg, agent);
                        break;
                    }

                case Program.BroadcastType.MessengersToRulersBroadcast:
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
                                var messengerAgentList = _container.GetMessangersInRange(tempMsg.CurrentSenderAgent);
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

                                        lostRulerMessage.MessageType = Program.BroadcastType.MessengersToRulersBroadcast;
                                        lostRulerMessage.NumOfBroadcastSteps = 1;



                                        lostRulerMessage.MessageContent = Program.MessagesContent.LostRuler;
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


                case Program.BroadcastType.MessengerToLeaderBroadcast:
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
                                var messengerAgentList = _container.GetMessangersInRange(tempMsg.CurrentSenderAgent);
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

                                        lostRulerMessage.MessageType = Program.BroadcastType.MessengerToLeaderBroadcast;
                                        lostRulerMessage.NumOfBroadcastSteps = 1;



                                        lostRulerMessage.MessageContent = Program.MessagesContent.LostRuler;
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

                case Program.BroadcastType.MessengerToMessengersBroadcast:
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

                case Program.BroadcastType.MessengerToWorkersBroadcast:
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

                case Program.BroadcastType.SendRecieve:
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

                            msgStatus = SendToAgentAndRecieve(tempMsg, agent);
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

