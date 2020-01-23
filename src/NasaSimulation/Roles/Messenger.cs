using System;
using System.Collections.Generic;

namespace Simulation.Roles
{
    public class Messenger : Role
    {
        int _iRecieverId;
        int _iSenderId;
        Agent _messengerAgent;
        Container _container;
        Point _centerPoint;
        public Area MessengerArea { get; set; }
        public List<Message> ReplyWaitingList { get; set; }
        public List<Message> AdaptingWaitingList { get; set; }

        //***********************************************************************************************************************************
        public void OnTimedEvent()
        {
            //
            if (ReplyWaitingList == null)
            {
                return;
            }

            foreach (var message in ReplyWaitingList)
            {
                if (message.RoutingTime != null)
                {
                    if ((Time.GlobalSimulationTime - message.RoutingTime) > 50 && message.RoutingTime != -1)
                    {
                        if (message.ReceiverAgent.AgentType == RolesName.Ruler)
                        {
                            var adaptListMessage = AdaptingWaitingList.Find(delegate (Message tempMessage)
                            {
                                return tempMessage.SenderAgentId == message.SenderAgentId && tempMessage.ReceiverAgentId == tempMessage.ReceiverAgentId;
                            });

                            if (adaptListMessage == null)
                            {
                                // message.routingTime = Time.GlobalSimulationTime;
                                AdaptingWaitingList.Add(message.Copy());
                                SendBroadcastMessage(_messengerAgent, _messengerAgent, Program.BroadcastType.MessengersToRulersBroadcast,
                                Program.MessagesContent.LostRuler, 1);
                            }

                            else
                            {
                                message.RoutingTime = Time.GlobalSimulationTime;
                                SendBroadcastMessage(_messengerAgent, _messengerAgent, Program.BroadcastType.MessengersToRulersBroadcast,
                                Program.MessagesContent.LostRuler, 2);
                            }
                        }

                    }
                }
            }
        }

        //***************************************************************************************************************************************


        public Messenger(Agent agent, Container cont, Area area)
        {
            _messengerAgent = agent;
            _container = cont;
            MessengerArea = area;
            ReplyWaitingList = new List<Message>();
            AdaptingWaitingList = new List<Message>();
        }

        public void ProcessMessage(Message message)
        {

        }

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
                            SendMessage(_messengerAgent, _messengerAgent, adaptingMessage.SenderAgent, adaptingMessage.SenderAgentId,
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


        private void AdaptToLostMessage(Message message)
        {
            var failedAgent = message.
                ReceiverAgent;
        }

        internal void GetMessage(Message message)
        {
            if (Program.OursExecutionMode)
            {
                OursGetMessage(message);
            }
            else
            {
                if (message.ReceiverAgentId == _messengerAgent.AgentId)
                {
                    {
                        ProcessMessage(message);
                    }
                }
                else if (message.ReceiverAgentId == "-1")
                {
                    message.CurrentReceiverAgentId = "-1";
                    message.CurrentSenderAgent = _messengerAgent;
                    message.CurrentSenderAgentId = _messengerAgent.AgentId;
                    message.RoutingList.Add(_messengerAgent);
                    _container.ContainerMedia.SendMessage(_messengerAgent, message.Copy());
                }
                else //must route Message
                {
                    if (CalculateDistance(_messengerAgent.GetPosition().Position, message.ReceiverAgent.GetPosition().Position) <= RadioRange)
                    {
                        message.CurrentReceiverAgentId = message.ReceiverAgentId;
                        message.CurrentReceiverAgent = message.ReceiverAgent;
                        message.CurrentSenderAgentId = _messengerAgent.AgentId;
                        message.CurrentSenderAgent = _messengerAgent;
                        message.RoutingList.Add(_messengerAgent);
                        _container.ContainerMedia.SendMessage(_messengerAgent, message.Copy());

                    }
                    else
                    {
                        var mAgent = FindNearestMessenger(_messengerAgent.GetPosition(), message.ReceiverAgent.GetPosition(), message);
                        if (mAgent == null)
                        {
                            RadioRange += 50;
                            _messengerAgent.RadioRange += 50;
                            GetMessage(message);
                            return;
                        }
                        message.CurrentReceiverAgentId = mAgent.AgentId;
                        message.CurrentReceiverAgent = mAgent;
                        message.CurrentSenderAgent = _messengerAgent;
                        message.CurrentSenderAgentId = _messengerAgent.AgentId;
                        message.RoutingList.Add(_messengerAgent);
                        _container.ContainerMedia.SendMessage(_messengerAgent, message.Copy());
                    }
                }
            }


        }

        private void OursGetMessage(Message message)
        {
            if (message.ReceiverAgentId == _messengerAgent.AgentId)
            {
                {
                    OursProcessMessage(message);
                }
            }
            else if (message.ReceiverAgentId == "-1")
            {
                message.CurrentReceiverAgentId = "-1";
                message.CurrentSenderAgent = _messengerAgent;
                message.CurrentSenderAgentId = _messengerAgent.AgentId;
                message.RoutingList.Add(_messengerAgent);
                _container.ContainerMedia.SendMessage(_messengerAgent, message.Copy());
            }

            else if (CalculateDistance(_messengerAgent.GetPosition().Position, message.ReceiverAgent.GetPosition().Position) <= RadioRange)
            {
                if (message.MessageContent == Program.MessagesContent.Ping)
                {
                    message.RoutingTime = Time.GlobalSimulationTime;
                    message.CurrentReceiverAgentId = message.ReceiverAgentId;
                    message.CurrentReceiverAgent = message.ReceiverAgent;
                    message.CurrentSenderAgentId = _messengerAgent.AgentId;
                    message.CurrentSenderAgent = _messengerAgent;

                    message.RoutingList.Add(_messengerAgent);
                    ReplyWaitingList.Add(message.Copy());
                    _container.ContainerMedia.SendMessage(_messengerAgent, message.Copy());
                }
                else if (message.MessageContent == Program.MessagesContent.PingReply)
                {
                    message.CurrentReceiverAgentId = message.ReceiverAgentId;
                    message.CurrentReceiverAgent = message.ReceiverAgent;
                    message.CurrentSenderAgentId = _messengerAgent.AgentId;
                    message.CurrentSenderAgent = _messengerAgent;
                    message.RoutingList.Add(_messengerAgent);
                    _container.ContainerMedia.SendMessage(_messengerAgent, message.Copy());
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
                    message.CurrentSenderAgentId = _messengerAgent.AgentId;
                    message.CurrentSenderAgent = _messengerAgent;
                    message.RoutingList.Add(_messengerAgent);
                    _container.ContainerMedia.SendMessage(_messengerAgent, message.Copy());
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


                var mAgent = FindNearestMessenger(_messengerAgent.GetPosition(), message.ReceiverAgent.GetPosition(), message);
                if (mAgent == null)
                {
                    RadioRange += 50;
                    _messengerAgent.RadioRange += 50;
                    GetMessage(message);
                    return;
                }
                message.CurrentReceiverAgentId = mAgent.AgentId;
                message.CurrentReceiverAgent = mAgent;
                message.CurrentSenderAgent = _messengerAgent;
                message.CurrentSenderAgentId = _messengerAgent.AgentId;
                message.RoutingList.Add(_messengerAgent);
                _container.ContainerMedia.SendMessage(_messengerAgent, message.Copy());

            }
        }

        private void OursMultiRouting(Message message)
        {

            if (message.MessageContent == Program.MessagesContent.PingReply)
            {
                message.CurrentSenderAgentId = _messengerAgent.AgentId;
                message.CurrentSenderAgent = _messengerAgent;

                if (CalculateDistance(_messengerAgent.GetPosition().Position, message.ReceiverAgent.GetPosition().Position) < RadioRange)
                {
                    message.CurrentReceiverAgentId = message.ReceiverAgentId;
                    message.CurrentReceiverAgent = message.ReceiverAgent;

                }

                else
                {
                    {
                        var tempMessengerAgent = FindNearestMessenger(_messengerAgent.GetPosition(), message.ReceiverAgent.GetPosition(), message);

                        if (_messengerAgent == null)
                        {
                            RadioRange += 50;
                            _messengerAgent.RadioRange += 50;
                            OursMultiRouting(message);

                        }

                        message.CurrentReceiverAgent = tempMessengerAgent;
                        message.CurrentReceiverAgentId = tempMessengerAgent.AgentId;
                    }

                }

                message.RoutingList.Add(_messengerAgent);
                _container.ContainerMedia.SendMessage(_messengerAgent, message.Copy());
                foreach (var pingMessage in ReplyWaitingList)
                {
                    if (pingMessage.ReceiverAgent == message.SenderAgent)
                    {
                        ReplyWaitingList.Remove(pingMessage);
                        break;
                    }
                }

            }
        }

        private void SendMessage(Agent senderAgent, Agent currentSenderAgent, Agent reciverAgent,
           string receiverId,
           Program.BroadcastType messageType,
           Program.MessagesContent messageContent, Agent rulerAgent)
        {
            var message = new Message();
            message.CurrentSenderAgent = currentSenderAgent;
            message.CurrentSenderAgentId = currentSenderAgent.AgentId;
            message.SenderAgentId = senderAgent.AgentId;
            message.SenderAgent = senderAgent;
            message.ReceiverAgent = reciverAgent;
            message.ReceiverAgentId = receiverId;

            message.MessageContent = messageContent;
            message.MessageType = messageType;


            if (CalculateDistance(_messengerAgent.GetPosition().Position, message.ReceiverAgent.GetPosition().Position) <= RadioRange)
            {

                message.CurrentReceiverAgent = message.ReceiverAgent;
                message.CurrentReceiverAgentId = message.ReceiverAgentId;

            }
            else
            {
                var tempMessengerAgent = FindNearestMessenger(_messengerAgent.GetPosition(), reciverAgent.GetPosition(), message);

                message.RulerPingReply = rulerAgent;
                if (_messengerAgent == null)
                {
                    RadioRange += 50;
                    _messengerAgent.RadioRange += 50;
                    SendMessage(senderAgent, currentSenderAgent, reciverAgent, receiverId, messageType, messageContent, rulerAgent);
                    return;

                }

                message.CurrentReceiverAgent = tempMessengerAgent;
                message.CurrentReceiverAgentId = tempMessengerAgent.AgentId;
            }





            var messageStatus = _container.ContainerMedia.SendMessage(message.SenderAgent, message.Copy());
        }

        //Agent messengerAgent = FindNearestMessenger(messengerAgent.getPosition(), recieverAgent.getPosition());

        //message.currentRecieverAgentID = messengerAgent.agentID;

        //Messenger messenger = (Messenger)messengerAgent.agentRole;
        //messenger.getMessage(message, recieverAgent);


        public Agent FindNearestMessenger(AgentPosition agentPosition, AgentPosition destPosition, Message message)
        {
            double minDist = 10000;
            Agent nAgent = null;
            foreach (var mAgent in _container.MessengerList)
            {
                if (mAgent != _messengerAgent)
                {
                    var foundAgent = message.RoutingList.Find(delegate (Agent messengerAg)
                    {
                        return messengerAg == mAgent;
                    });




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
        //************************************************************
        public double CalculateDistance(Point position, Point position2)
        {
            double dest;
            var x = position.X - position2.X;
            var y = position.Y - position2.Y;
            x *= x;
            y *= y;
            dest = Math.Sqrt(x + y);
            return dest;
        }

        //***************************************************************

        private void SendBroadcastMessage(Agent senderAgent, Agent currentSenderAgent,
            Program.BroadcastType messageType,
            Program.MessagesContent messageContent, int iBroadcastNum)
        {
            var message = new Message();
            message.CurrentSenderAgent = currentSenderAgent;
            message.CurrentSenderAgentId = currentSenderAgent.AgentId;
            message.SenderAgentId = senderAgent.AgentId;
            message.SenderAgent = senderAgent;
            message.ReceiverAgent = null;
            message.ReceiverAgentId = "-1";
            message.MessageContent = messageContent;
            message.MessageType = messageType;
            message.NumOfBroadcastSteps = iBroadcastNum;
            message.CurrentReceiverAgentId = "-1";
            message.CurrentReceiverAgent = null;


            var messageStatus = _container.ContainerMedia.SendMessage(message.SenderAgent, message.Copy());

        }


        //private void messageNotSent()
        //{
        //    throw new NotImplementedException();
        //}

        //private void sendMessage(int nextHopAgentID, Message MSG)
        //{
        //    MSG.currentSenderAgentID = this.ID;
        //    MSG.currentRecieverAgentID = nextHopAgentID;
        //    bool sendIsOK = container.containerMedia.sendMessage(this, MSG);
        //    if (!sendIsOK)
        //    {
        //        mediaIsBussy();
        //    }
        //}
    }
}
