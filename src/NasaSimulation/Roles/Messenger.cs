﻿using System;
using System.Collections.Generic;

namespace Simulation.Roles
{
    public class Messenger : Role
    {
        public Messenger(Agent agent, Container cont, Area area)
        {
            MessengerAgent = agent;
            Container = cont;
            MessengerArea = area;
            ReplyWaitingList = new List<Message>();
            AdaptingWaitingList = new List<Message>();
        }

        private Agent MessengerAgent { get; }
        private Container Container { get; }
        public Area MessengerArea { get; set; }
        public List<Message> ReplyWaitingList { get; set; }
        public List<Message> AdaptingWaitingList { get; set; }

        public void OnTimedEvent()
        {
            //
            if (ReplyWaitingList == null)
            {
                return;
            }

            foreach (var message in ReplyWaitingList)
            {
                if ((Time.GlobalSimulationTime - message.RoutingTime) > 50 && message.RoutingTime != -1)
                {
                    if (message.ReceiverAgent.AgentType == RolesName.Ruler)
                    {
                        var adaptListMessage = AdaptingWaitingList.Find(tempMessage =>
                            tempMessage.SenderAgentId == message.SenderAgentId &&
                            tempMessage.ReceiverAgentId == message.ReceiverAgentId);

                        if (adaptListMessage == null)
                        {
                            AdaptingWaitingList.Add(message.Copy());
                            SendBroadcastMessage(MessengerAgent, MessengerAgent, Program.BroadcastType.MessengersToRulersBroadcast,
                                Program.MessagesContent.LostRuler, 1);
                        }

                        else
                        {
                            message.RoutingTime = Time.GlobalSimulationTime;
                            SendBroadcastMessage(MessengerAgent, MessengerAgent, Program.BroadcastType.MessengersToRulersBroadcast,
                                Program.MessagesContent.LostRuler, 2);
                        }
                    }
                }
            }
        }

        //***************************************************************************************************************************************


        public void OursProcessMessage(Message message)
        {
            if (message.MessageContent == Program.MessagesContent.ReplyRulerNum)
            {
                if (message.RulerPingReply != null)
                {
                    if (AdaptingWaitingList.Count > 0)
                    {
                        foreach (var adaptingMessage in AdaptingWaitingList)
                        {
                            SendMessage(MessengerAgent, MessengerAgent, adaptingMessage.SenderAgent, adaptingMessage.SenderAgentId,
                                Program.BroadcastType.SingleCast, Program.MessagesContent.ReplyRulerNum, message.RulerPingReply);

                            var replyListMessage = ReplyWaitingList.Find(delegate (Message tempMessage)
                            {
                                return tempMessage.SenderAgent == adaptingMessage.SenderAgent;
                            });
                            ReplyWaitingList.Remove(replyListMessage);

                        }


                        AdaptingWaitingList.Clear();
                    }
                }
            }
        }

        internal void GetMessage(Message message)
        {
            if (Program.OursExecutionMode)
            {
                OursGetMessage(message);
            }
            else
            {
                if (message.ReceiverAgentId == MessengerAgent.AgentId)
                {
                    //ProcessMessage(message);
                }
                else if (message.ReceiverAgentId == "-1")
                {
                    message.CurrentReceiverAgentId = "-1";
                    message.CurrentSenderAgent = MessengerAgent;
                    message.CurrentSenderAgentId = MessengerAgent.AgentId;
                    message.RoutingList.Add(MessengerAgent);
                    Container.ContainerMedia.SendMessage(MessengerAgent, message.Copy());
                }
                else //must route Message
                {
                    if (CalculateDistance(MessengerAgent.GetPosition().Position, message.ReceiverAgent.GetPosition().Position) <= RadioRange)
                    {
                        message.CurrentReceiverAgentId = message.ReceiverAgentId;
                        message.CurrentReceiverAgent = message.ReceiverAgent;
                        message.CurrentSenderAgentId = MessengerAgent.AgentId;
                        message.CurrentSenderAgent = MessengerAgent;
                        message.RoutingList.Add(MessengerAgent);
                        Container.ContainerMedia.SendMessage(MessengerAgent, message.Copy());

                    }
                    else
                    {
                        var mAgent = FindNearestMessenger(MessengerAgent.GetPosition(), message.ReceiverAgent.GetPosition(), message);
                        if (mAgent == null)
                        {
                            RadioRange += 50;
                            MessengerAgent.RadioRange += 50;
                            GetMessage(message);
                            return;
                        }
                        message.CurrentReceiverAgentId = mAgent.AgentId;
                        message.CurrentReceiverAgent = mAgent;
                        message.CurrentSenderAgent = MessengerAgent;
                        message.CurrentSenderAgentId = MessengerAgent.AgentId;
                        message.RoutingList.Add(MessengerAgent);
                        Container.ContainerMedia.SendMessage(MessengerAgent, message.Copy());
                    }
                }
            }


        }

        private void OursGetMessage(Message message)
        {
            if (message.ReceiverAgentId == MessengerAgent.AgentId)
            {
                {
                    OursProcessMessage(message);
                }
            }
            else if (message.ReceiverAgentId == "-1")
            {
                message.CurrentReceiverAgentId = "-1";
                message.CurrentSenderAgent = MessengerAgent;
                message.CurrentSenderAgentId = MessengerAgent.AgentId;
                message.RoutingList.Add(MessengerAgent);
                Container.ContainerMedia.SendMessage(MessengerAgent, message.Copy());
            }

            else if (CalculateDistance(MessengerAgent.GetPosition().Position, message.ReceiverAgent.GetPosition().Position) <= RadioRange)
            {
                if (message.MessageContent == Program.MessagesContent.Ping)
                {
                    message.RoutingTime = Time.GlobalSimulationTime;
                    message.CurrentReceiverAgentId = message.ReceiverAgentId;
                    message.CurrentReceiverAgent = message.ReceiverAgent;
                    message.CurrentSenderAgentId = MessengerAgent.AgentId;
                    message.CurrentSenderAgent = MessengerAgent;

                    message.RoutingList.Add(MessengerAgent);
                    ReplyWaitingList.Add(message.Copy());
                    Container.ContainerMedia.SendMessage(MessengerAgent, message.Copy());
                }
                else if (message.MessageContent == Program.MessagesContent.PingReply)
                {
                    message.CurrentReceiverAgentId = message.ReceiverAgentId;
                    message.CurrentReceiverAgent = message.ReceiverAgent;
                    message.CurrentSenderAgentId = MessengerAgent.AgentId;
                    message.CurrentSenderAgent = MessengerAgent;
                    message.RoutingList.Add(MessengerAgent);
                    Container.ContainerMedia.SendMessage(MessengerAgent, message.Copy());
                    foreach (var pingMessage in ReplyWaitingList)
                    {
                        if (pingMessage.ReceiverAgent == message.SenderAgent)
                        {
                            ReplyWaitingList.Remove(pingMessage);
                            break;
                        }
                    }
                }

                else
                {
                    message.CurrentReceiverAgentId = message.ReceiverAgentId;
                    message.CurrentReceiverAgent = message.ReceiverAgent;
                    message.CurrentSenderAgentId = MessengerAgent.AgentId;
                    message.CurrentSenderAgent = MessengerAgent;
                    message.RoutingList.Add(MessengerAgent);
                    Container.ContainerMedia.SendMessage(MessengerAgent, message.Copy());
                }
            }

            else
            {
                if (message.MessageContent == Program.MessagesContent.PingReply)
                {
                    foreach (var pingMessage in ReplyWaitingList)
                    {
                        if (pingMessage.ReceiverAgent == message.SenderAgent)
                        {
                            ReplyWaitingList.Remove(pingMessage);
                            break;
                        }
                    }

                }


                var mAgent = FindNearestMessenger(MessengerAgent.GetPosition(), message.ReceiverAgent.GetPosition(), message);
                if (mAgent == null)
                {
                    RadioRange += 50;
                    MessengerAgent.RadioRange += 50;
                    GetMessage(message);
                    return;
                }
                message.CurrentReceiverAgentId = mAgent.AgentId;
                message.CurrentReceiverAgent = mAgent;
                message.CurrentSenderAgent = MessengerAgent;
                message.CurrentSenderAgentId = MessengerAgent.AgentId;
                message.RoutingList.Add(MessengerAgent);
                Container.ContainerMedia.SendMessage(MessengerAgent, message.Copy());

            }
        }

        private void SendMessage(Agent senderAgent, Agent currentSenderAgent, Agent receiverAgent,
           string receiverId,
           Program.BroadcastType messageType,
           Program.MessagesContent messageContent, Agent rulerAgent)
        {
            var message = new Message();
            message.CurrentSenderAgent = currentSenderAgent;
            message.CurrentSenderAgentId = currentSenderAgent.AgentId;
            message.SenderAgentId = senderAgent.AgentId;
            message.SenderAgent = senderAgent;
            message.ReceiverAgent = receiverAgent;
            message.ReceiverAgentId = receiverId;

            message.MessageContent = messageContent;
            message.MessageType = messageType;


            if (CalculateDistance(MessengerAgent.GetPosition().Position, message.ReceiverAgent.GetPosition().Position) <= RadioRange)
            {

                message.CurrentReceiverAgent = message.ReceiverAgent;
                message.CurrentReceiverAgentId = message.ReceiverAgentId;

            }
            else
            {
                var tempMessengerAgent = FindNearestMessenger(MessengerAgent.GetPosition(), receiverAgent.GetPosition(), message);

                message.RulerPingReply = rulerAgent;
                if (MessengerAgent == null)
                {
                    RadioRange += 50;
                    if (MessengerAgent != null) MessengerAgent.RadioRange += 50;
                    SendMessage(senderAgent, currentSenderAgent, receiverAgent, receiverId, messageType, messageContent, rulerAgent);
                    return;

                }

                message.CurrentReceiverAgent = tempMessengerAgent;
                message.CurrentReceiverAgentId = tempMessengerAgent.AgentId;
            }

            Container.ContainerMedia.SendMessage(message.SenderAgent, message.Copy());
        }

        public Agent FindNearestMessenger(AgentPosition agentPosition, AgentPosition destPosition, Message message)
        {
            double minDist = 10000;
            Agent nAgent = null;
            foreach (var mAgent in Container.MessengerList)
            {
                if (mAgent != MessengerAgent)
                {
                    var foundAgent = message.RoutingList.Find(messengerAg => messengerAg == mAgent);

                    if (foundAgent == null)
                    {
                        //Role temptRole = (Role)mAgent.agentRole;
                        if (CalculateDistance(agentPosition.Position, mAgent.GetPosition().Position) <= RadioRange && CalculateDistance(agentPosition.Position, mAgent.GetPosition().Position) + CalculateDistance(destPosition.Position, mAgent.GetPosition().Position) < minDist)
                        {
                            minDist = CalculateDistance(agentPosition.Position, mAgent.GetPosition().Position) + CalculateDistance(destPosition.Position, mAgent.GetPosition().Position);
                            nAgent = mAgent;
                        }
                    }

                }
            }
            return nAgent;
        }
        
        public double CalculateDistance(Point position, Point position2)
        {
            var x = position.X - position2.X;
            var y = position.Y - position2.Y;
            x *= x;
            y *= y;
            var dest = Math.Sqrt(x + y);
            return dest;
        }

        private void SendBroadcastMessage(Agent senderAgent, 
            Agent currentSenderAgent,
            Program.BroadcastType messageType,
            Program.MessagesContent messageContent, 
            int iBroadcastNum)
        {
            var message = new Message
            {
                CurrentSenderAgent = currentSenderAgent,
                CurrentSenderAgentId = currentSenderAgent.AgentId,
                SenderAgentId = senderAgent.AgentId,
                SenderAgent = senderAgent,
                ReceiverAgent = null,
                ReceiverAgentId = "-1",
                MessageContent = messageContent,
                MessageType = messageType,
                NumOfBroadcastSteps = iBroadcastNum,
                CurrentReceiverAgentId = "-1",
                CurrentReceiverAgent = null
            };
            Container.ContainerMedia.SendMessage(message.SenderAgent, message.Copy());
        }
    }
}
