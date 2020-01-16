using System.Collections.Generic;
using Nasa.ANTS.Simulation.Roles;

namespace Nasa.ANTS.Simulation
{
    public class Media
    {
        public List<Message> MessageList = new List<Message>();
        Container _container;
        public int MessageCount = 1;
        public Media(Container cont)
        {
            _container = cont;
        }
        public bool sendMessage(Agent sender, Message msg)
        {
            MessageCount++;
            msg.MessageId = MessageCount;
            MessageList.Add(msg);
            //--- must do --- check if this agent is in forbiden area
            //------------------
            addMessageEventToContainer(MessageCount);
            return true;
        }

        private void addMessageEventToContainer(int msgId)
        {



            _container.addEventToQeue(msgId, Program.Msgdelay);
        }

        public bool sendToAgent(Message message, Agent reciever)
        {
            if (reciever.AgentType == Role.RolesName.Messenger)
            {
                Messenger tempMesenger = (Messenger)reciever.AgentRole;
                tempMesenger.getMessage(message.Copy());
                MessageList.Remove(message);
            }

            else if (reciever.AgentType == Role.RolesName.Worker)
            {
                Worker tempWorker = (Worker)reciever.AgentRole;
                tempWorker.getMessage(message.Copy());
                MessageList.Remove(message);
            }

            else if (reciever.AgentType == Role.RolesName.Ruler)
            {
                Ruler tempRuler = (Ruler)reciever.AgentRole;
                tempRuler.GetandSendMessage(message.Copy());
                MessageList.Remove(message);
            }

            else if (reciever.AgentType == Role.RolesName.Leader)
            {
                Leader tempLeader = (Leader)reciever.AgentRole;
                tempLeader.getMessage(message.Copy());
                MessageList.Remove(message);
            }
            return true;
        }



        public bool sendBroadcastToAgent(Message message, Agent reciever)
        {
            if (reciever.AgentType == Role.RolesName.Messenger)
            {
                Messenger tempMesenger = (Messenger)reciever.AgentRole;
                tempMesenger.getMessage(message);
                MessageList.Remove(message);
            }

            else if (reciever.AgentType == Role.RolesName.Worker)
            {
                Worker tempWorker = (Worker)reciever.AgentRole;
                tempWorker.getMessage(message);
                MessageList.Remove(message);
            }

            else if (reciever.AgentType == Role.RolesName.Ruler)
            {
                Ruler tempRuler = (Ruler)reciever.AgentRole;
                tempRuler.GetandSendMessage(message);
                MessageList.Remove(message);
            }

            else if (reciever.AgentType == Role.RolesName.Leader)
            {
                Leader tempLeader = (Leader)reciever.AgentRole;
                tempLeader.getMessage(message);
                bool x = MessageList.Remove(message);
            }
            return true;
        }

        public bool sendToAgentAndRecieve(Message message, Agent reciever)
        {


            if (reciever.AgentType == Role.RolesName.Ruler)
            {
                Ruler tempRuler = (Ruler)reciever.AgentRole;
                tempRuler.GetandSendMessage(message.Copy());
                MessageList.Remove(message);
            }

            return true;
        }

        public bool doMessage(int msgId)
        {
            bool msgStatus = true;
            Message tempMsg = MessageList.Find(
                delegate (Message msg)
                {
                    return msg.MessageId == msgId;
                }
                );


            if (tempMsg == null)
            {
                int r = 0;
            }
            switch (tempMsg.MessageType)
            {
                case Program.BroadcastType.Broadcast:
                    {
                        if (tempMsg.CurrentRecieverAgentId == "-1")
                        {
                            List<Agent> agentList = _container.getAgentsInRange(tempMsg.CurrentSenderAgent);
                            foreach (Agent agent in agentList)
                            {

                                Message singleMessage = tempMsg.Copy();
                                singleMessage.CurrentReciverAgent = agent;
                                singleMessage.CurrentRecieverAgentId = agent.AgentId;
                                singleMessage.ReciverAgent = agent;
                                singleMessage.RecieverAgentId = agent.AgentId;
                                sendBroadcastToAgent(singleMessage, agent);
                            }
                        }

                        else
                        {
                            Agent agent = tempMsg.CurrentReciverAgent;
                            sendToAgent(tempMsg, agent);
                        }
                        break;

                    }
                case Program.BroadcastType.SingleCast:
                    {
                        Agent agent = tempMsg.CurrentReciverAgent;
                        sendToAgent(tempMsg, agent);
                        break;
                    }

                case Program.BroadcastType.MessengersToRulersBroadcast:
                    {
                        if (tempMsg.CurrentRecieverAgentId == "-1")
                        {
                            if (tempMsg.NumOfBoroadcastSteps == 1)
                            {
                                List<Agent> agentList = _container.getRulersInRange(tempMsg.CurrentSenderAgent);
                                foreach (Agent agent in agentList)
                                {
                                    if (agent.AgentType == Role.RolesName.Ruler && agent.AgentId != tempMsg.SenderAgentId)
                                    {
                                        Message singleMessage = tempMsg.Copy();
                                        MessageCount++;
                                        singleMessage.MessageId = MessageCount;
                                        singleMessage.CurrentReciverAgent = agent;
                                        singleMessage.CurrentRecieverAgentId = agent.AgentId;
                                        singleMessage.ReciverAgent = agent;
                                        singleMessage.RecieverAgentId = agent.AgentId;
                                        sendBroadcastToAgent(singleMessage, agent);
                                    }
                                }
                            }
                            else if (tempMsg.NumOfBoroadcastSteps == 2)
                            {
                                List<Agent> agentList = _container.getRulersInRange(tempMsg.CurrentSenderAgent);
                                foreach (Agent agent in agentList)
                                {
                                    if (agent.AgentType == Role.RolesName.Ruler && agent.AgentId != tempMsg.SenderAgentId)
                                    {
                                        Message singleMessage = tempMsg.Copy();
                                        MessageCount++;
                                        singleMessage.MessageId = MessageCount;
                                        singleMessage.CurrentReciverAgent = agent;
                                        singleMessage.CurrentRecieverAgentId = agent.AgentId;
                                        singleMessage.ReciverAgent = agent;
                                        singleMessage.RecieverAgentId = agent.AgentId;
                                        sendBroadcastToAgent(singleMessage, agent);
                                    }
                                }
                                List<Agent> messengerAgentList = _container.getMessangersInRange(tempMsg.CurrentSenderAgent);
                                foreach (Agent agent in messengerAgentList)
                                {
                                    if (agent.AgentType == Role.RolesName.Messenger && agent.AgentId != tempMsg.CurrentSenderAgentId)
                                    {
                                        Message lostRulerMessage = tempMsg.Copy();
                                        MessageCount++;
                                        lostRulerMessage.MessageId = MessageCount;
                                        lostRulerMessage.CurrentReciverAgent = agent;
                                        lostRulerMessage.CurrentRecieverAgentId = agent.AgentId;
                                        lostRulerMessage.ReciverAgent = null;
                                        lostRulerMessage.RecieverAgentId = "-1";

                                        lostRulerMessage.MessageType = Program.BroadcastType.MessengersToRulersBroadcast;
                                        lostRulerMessage.NumOfBoroadcastSteps = 1;



                                        lostRulerMessage.MessageContent = Program.MessagesContent.LostRuler;
                                        sendBroadcastToAgent(lostRulerMessage, agent);

                                    }
                                }
                            }

                            MessageList.Remove(tempMsg);

                        }

                        else
                        {
                            Agent agent = tempMsg.CurrentReciverAgent;
                            sendToAgent(tempMsg, agent);
                        }
                        break;
                    }


                case Program.BroadcastType.MessengerToLeaderBroadcast:
                    {
                        if (tempMsg.CurrentRecieverAgentId == "-1")
                        {
                            if (tempMsg.NumOfBoroadcastSteps == 1)
                            {
                                List<Agent> agentList = _container.getLeadersInRange(tempMsg.CurrentSenderAgent);
                                foreach (Agent agent in agentList)
                                {
                                    if (agent.AgentType == Role.RolesName.Leader && agent.AgentId != tempMsg.SenderAgentId)
                                    {
                                        Message singleMessage = tempMsg.Copy();
                                        MessageCount++;
                                        singleMessage.MessageId = MessageCount;
                                        singleMessage.CurrentReciverAgent = agent;
                                        singleMessage.CurrentRecieverAgentId = agent.AgentId;
                                        singleMessage.ReciverAgent = agent;
                                        singleMessage.RecieverAgentId = agent.AgentId;
                                        sendBroadcastToAgent(singleMessage, agent);
                                    }
                                }
                            }
                            else if (tempMsg.NumOfBoroadcastSteps == 2)
                            {
                                List<Agent> agentList = _container.getLeadersInRange(tempMsg.CurrentSenderAgent);
                                foreach (Agent agent in agentList)
                                {
                                    if (agent.AgentType == Role.RolesName.Leader && agent.AgentId != tempMsg.SenderAgentId)
                                    {
                                        Message singleMessage = tempMsg.Copy();
                                        MessageCount++;
                                        singleMessage.MessageId = MessageCount;
                                        singleMessage.CurrentReciverAgent = agent;
                                        singleMessage.CurrentRecieverAgentId = agent.AgentId;
                                        singleMessage.ReciverAgent = agent;
                                        singleMessage.RecieverAgentId = agent.AgentId;
                                        sendBroadcastToAgent(singleMessage, agent);
                                    }
                                }
                                List<Agent> messengerAgentList = _container.getMessangersInRange(tempMsg.CurrentSenderAgent);
                                foreach (Agent agent in messengerAgentList)
                                {
                                    if (agent.AgentType == Role.RolesName.Messenger && agent.AgentId != tempMsg.CurrentSenderAgentId)
                                    {
                                        Message lostRulerMessage = tempMsg.Copy();
                                        MessageCount++;
                                        lostRulerMessage.MessageId = MessageCount;
                                        lostRulerMessage.CurrentReciverAgent = agent;
                                        lostRulerMessage.CurrentRecieverAgentId = agent.AgentId;
                                        lostRulerMessage.ReciverAgent = null;
                                        lostRulerMessage.RecieverAgentId = "-1";

                                        lostRulerMessage.MessageType = Program.BroadcastType.MessengerToLeaderBroadcast;
                                        lostRulerMessage.NumOfBoroadcastSteps = 1;



                                        lostRulerMessage.MessageContent = Program.MessagesContent.LostRuler;
                                        sendBroadcastToAgent(lostRulerMessage, agent);

                                    }
                                }
                            }

                            MessageList.Remove(tempMsg);

                        }

                        else
                        {
                            Agent agent = tempMsg.CurrentReciverAgent;
                            sendToAgent(tempMsg, agent);
                        }
                        break;
                    }

                case Program.BroadcastType.MessengerToMessengersBroadcast:
                    {
                        if (tempMsg.CurrentRecieverAgentId == "-1")
                        {
                            List<Agent> agentList = _container.getAgentsInRange(tempMsg.CurrentSenderAgent);
                            foreach (Agent agent in agentList)
                            {
                                if (agent.AgentType == Role.RolesName.Messenger)
                                {
                                    Message singleMessage = tempMsg.Copy();
                                    MessageCount++;
                                    singleMessage.MessageId = MessageCount;
                                    singleMessage.CurrentReciverAgent = agent;
                                    singleMessage.CurrentRecieverAgentId = agent.AgentId;
                                    singleMessage.ReciverAgent = agent;
                                    singleMessage.RecieverAgentId = agent.AgentId;
                                    sendBroadcastToAgent(singleMessage, agent);
                                }
                            }
                        }


                        else
                        {
                            Agent agent = tempMsg.CurrentReciverAgent;
                            sendToAgent(tempMsg, agent);
                        }
                        break;
                    }

                case Program.BroadcastType.MessengerToWorkersBroadcast:
                    {
                        if (tempMsg.RecieverAgentId == "-1")
                        {
                            List<Agent> agentList = _container.getAgentsInRange(tempMsg.CurrentSenderAgent);
                            foreach (Agent agent in agentList)
                            {
                                if (agent.AgentType == Role.RolesName.Worker)
                                {
                                    Message singleMessage = tempMsg.Copy();
                                    MessageCount++;
                                    singleMessage.MessageId = MessageCount;
                                    singleMessage.CurrentReciverAgent = agent;
                                    singleMessage.CurrentRecieverAgentId = agent.AgentId;
                                    singleMessage.ReciverAgent = agent;
                                    singleMessage.RecieverAgentId = agent.AgentId;
                                    sendBroadcastToAgent(singleMessage, agent);

                                }

                            }
                        }

                        else
                        {
                            Agent agent = tempMsg.CurrentReciverAgent;
                            sendToAgent(tempMsg, agent);
                        }
                        break;
                    }

                case Program.BroadcastType.SendRecieve:
                    {
                        if (tempMsg.RecieverAgentId == "-1")
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

                        else if (tempMsg.CurrentRecieverAgentId == tempMsg.RecieverAgentId)
                        {
                            Agent agent = tempMsg.CurrentReciverAgent;

                            msgStatus = sendToAgentAndRecieve(tempMsg, agent);
                        }

                        else
                        {
                            Agent agent = tempMsg.CurrentReciverAgent;
                            msgStatus = sendToAgent(tempMsg, agent);
                        }


                        break;

                    }







            }

            return msgStatus;

        }





    }





}

