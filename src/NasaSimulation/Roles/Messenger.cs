﻿using System.Collections.Generic;
using Simulation.Core;
using Simulation.Enums;
using Simulation.Tools;

namespace Simulation.Roles
{
    public class Messenger : Agent
    {
        public Messenger(Configuration config, AgentPosition pos, string id, Container cont, Area area)
            : base(config, pos, id, cont)
        {
            MessengerArea = area;
            ReplyWaitingList = new List<Message>();
            AdaptingWaitingList = new List<Message>();
        }

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
                    if (message.ReceiverAgent is Ruler)
                    {
                        var adaptListMessage = AdaptingWaitingList.Find(tempMessage =>
                            tempMessage.SenderAgentId == message.SenderAgentId &&
                            tempMessage.ReceiverAgentId == message.ReceiverAgentId);

                        if (adaptListMessage == null)
                        {
                            AdaptingWaitingList.Add(message.Copy());
                            SendBroadcastMessage(this, this, BroadcastType.MessengersToRulersBroadcast,
                                MessagesContent.LostRuler, 1);
                        }

                        else
                        {
                            message.RoutingTime = Time.GlobalSimulationTime;
                            SendBroadcastMessage(this, this, BroadcastType.MessengersToRulersBroadcast,
                                MessagesContent.LostRuler, 2);
                        }
                    }
                }
            }
        }


        public void OursProcessMessage(Message message)
        {
            if (message.MessageContent == MessagesContent.ReplyRulerNum)
            {
                if (message.RulerPingReply != null)
                {
                    if (AdaptingWaitingList.Count > 0)
                    {
                        foreach (var adaptingMessage in AdaptingWaitingList)
                        {
                            SendMessage(this, this, adaptingMessage.SenderAgent, adaptingMessage.SenderAgentId,
                                BroadcastType.SingleCast, MessagesContent.ReplyRulerNum, message.RulerPingReply);

                            var replyListMessage = ReplyWaitingList.Find(tempMessage =>
                                tempMessage.SenderAgent == adaptingMessage.SenderAgent);
                            ReplyWaitingList.Remove(replyListMessage);

                        }


                        AdaptingWaitingList.Clear();
                    }
                }
            }
        }

        internal void GetMessage(Message message)
        {
            if (Config.OursExecutionMode)
            {
                OursGetMessage(message);
            }
            else
            {
                if (message.ReceiverAgentId == AgentId)
                {
                    //ProcessMessage(message);
                }
                else if (message.ReceiverAgentId == "-1")
                {
                    message.CurrentReceiverAgentId = "-1";
                    message.CurrentSenderAgent = this;
                    message.CurrentSenderAgentId = AgentId;
                    message.RoutingList.Add(this);
                    Container.ContainerMedia.SendMessage(this, message.Copy());
                }
                else //must route Message
                {
                    if (GetPosition().Position.CalculateDistance(message.ReceiverAgent.GetPosition().Position) <= RadioRange)
                    {
                        message.CurrentReceiverAgentId = message.ReceiverAgentId;
                        message.CurrentReceiverAgent = message.ReceiverAgent;
                        message.CurrentSenderAgentId = AgentId;
                        message.CurrentSenderAgent = this;
                        message.RoutingList.Add(this);
                        Container.ContainerMedia.SendMessage(this, message.Copy());

                    }
                    else
                    {
                        var mAgent = FindNearestMessenger(GetPosition(), message.ReceiverAgent.GetPosition(), message);
                        if (mAgent == null)
                        {
                            RadioRange += 50;
                            GetMessage(message);
                            return;
                        }
                        message.CurrentReceiverAgentId = mAgent.AgentId;
                        message.CurrentReceiverAgent = mAgent;
                        message.CurrentSenderAgent = this;
                        message.CurrentSenderAgentId = AgentId;
                        message.RoutingList.Add(this);
                        Container.ContainerMedia.SendMessage(this, message.Copy());
                    }
                }
            }


        }

        private void OursGetMessage(Message message)
        {
            if (message.ReceiverAgentId == AgentId)
            {
                {
                    OursProcessMessage(message);
                }
            }
            else if (message.ReceiverAgentId == "-1")
            {
                message.CurrentReceiverAgentId = "-1";
                message.CurrentSenderAgent = this;
                message.CurrentSenderAgentId = AgentId;
                message.RoutingList.Add(this);
                Container.ContainerMedia.SendMessage(this, message.Copy());
            }

            else if (GetPosition().Position.CalculateDistance(message.ReceiverAgent.GetPosition().Position) <= RadioRange)
            {
                if (message.MessageContent == MessagesContent.Ping)
                {
                    message.RoutingTime = Time.GlobalSimulationTime;
                    message.CurrentReceiverAgentId = message.ReceiverAgentId;
                    message.CurrentReceiverAgent = message.ReceiverAgent;
                    message.CurrentSenderAgentId = AgentId;
                    message.CurrentSenderAgent = this;

                    message.RoutingList.Add(this);
                    ReplyWaitingList.Add(message.Copy());
                    Container.ContainerMedia.SendMessage(this, message.Copy());
                }
                else if (message.MessageContent == MessagesContent.PingReply)
                {
                    message.CurrentReceiverAgentId = message.ReceiverAgentId;
                    message.CurrentReceiverAgent = message.ReceiverAgent;
                    message.CurrentSenderAgentId = AgentId;
                    message.CurrentSenderAgent = this;
                    message.RoutingList.Add(this);
                    Container.ContainerMedia.SendMessage(this, message.Copy());
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
                    message.CurrentSenderAgentId = AgentId;
                    message.CurrentSenderAgent = this;
                    message.RoutingList.Add(this);
                    Container.ContainerMedia.SendMessage(this, message.Copy());
                }
            }

            else
            {
                if (message.MessageContent == MessagesContent.PingReply)
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


                var mAgent = FindNearestMessenger(GetPosition(), message.ReceiverAgent.GetPosition(), message);
                if (mAgent == null)
                {
                    RadioRange += 50;
                    RadioRange += 50;
                    GetMessage(message);
                    return;
                }
                message.CurrentReceiverAgentId = mAgent.AgentId;
                message.CurrentReceiverAgent = mAgent;
                message.CurrentSenderAgent = this;
                message.CurrentSenderAgentId = AgentId;
                message.RoutingList.Add(this);
                Container.ContainerMedia.SendMessage(this, message.Copy());

            }
        }

        private void SendMessage(Agent senderAgent, Agent currentSenderAgent, Agent receiverAgent,
           string receiverId,
           BroadcastType messageType,
           MessagesContent messageContent, Ruler rulerAgent)
        {
            var message = new Message
            {
                CurrentSenderAgent = currentSenderAgent,
                CurrentSenderAgentId = currentSenderAgent.AgentId,
                SenderAgentId = senderAgent.AgentId,
                SenderAgent = senderAgent,
                ReceiverAgent = receiverAgent,
                ReceiverAgentId = receiverId,
                MessageContent = messageContent,
                MessageType = messageType
            };

            if (GetPosition().Position.CalculateDistance(message.ReceiverAgent.GetPosition().Position) <= RadioRange)
            {
                message.CurrentReceiverAgent = message.ReceiverAgent;
                message.CurrentReceiverAgentId = message.ReceiverAgentId;
            }
            else
            {
                var temp = FindNearestMessenger(GetPosition(), receiverAgent.GetPosition(), message);
                message.RulerPingReply = rulerAgent;
                message.CurrentReceiverAgent = temp;
                message.CurrentReceiverAgentId = temp.AgentId;
            }

            Container.ContainerMedia.SendMessage(message.SenderAgent, message.Copy());
        }

        public Agent FindNearestMessenger(AgentPosition agentPosition, AgentPosition destPosition, Message message)
        {
            double minDist = 10000;
            Agent nAgent = null;
            foreach (var mAgent in Container.MessengerList)
            {
                if (mAgent != this)
                {
                    var foundAgent = message.RoutingList.Find(messengerAg => messengerAg == mAgent);

                    if (foundAgent == null)
                    {
                        if (agentPosition.Position.CalculateDistance(mAgent.GetPosition().Position) <= RadioRange &&
                            agentPosition.Position.CalculateDistance(mAgent.GetPosition().Position) +
                            destPosition.Position.CalculateDistance(mAgent.GetPosition().Position) < minDist)
                        {
                            minDist = agentPosition.Position.CalculateDistance(mAgent.GetPosition().Position) +
                                      destPosition.Position.CalculateDistance(mAgent.GetPosition().Position);
                            nAgent = mAgent;
                        }
                    }

                }
            }
            return nAgent;
        }

        private void SendBroadcastMessage(Agent senderAgent,
            Agent currentSenderAgent,
            BroadcastType messageType,
            MessagesContent messageContent,
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


        public override void FreeUpdateOneMillisecond()
        {
            if (Config.OursExecutionMode)
            {
                if (Time.GlobalSimulationTime % 50 == 0 &&
                    Time.GlobalSimulationTime > 100)
                {
                    OnTimedEvent();
                }
            }

            base.FreeUpdateOneMillisecond();
        }

        protected override void FreeMovement()
        {
            base.FreeMovement();

            var x = (double)Config.Rnd.Next((int)MessengerArea.MinX, (int)MessengerArea.MaxX);
            var y = (double)Config.Rnd.Next((int)MessengerArea.MinY, (int)MessengerArea.MaxY);
            if (Position.Position.X > MessengerArea.MaxX) Position.Position.X = x;
            if (Position.Position.X < MessengerArea.MinX) Position.Position.X = x;
            if (Position.Position.Y > MessengerArea.MaxY) Position.Position.Y = y;
            if (Position.Position.Y < MessengerArea.MinY) Position.Position.Y = y;

            if (Time.GlobalSimulationTime > 1000 & Time.GlobalSimulationTime % 1000 == 0)
                UpdateVelocity(Position);
        }
    }
}
