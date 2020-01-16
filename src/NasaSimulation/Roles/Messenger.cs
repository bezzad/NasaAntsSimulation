using System;
using System.Collections.Generic;

namespace Nasa.ANTS.Simulation.Roles
{
   public class Messenger:Role
    {
        int _iRecieverId;
        int _iSenderId;
        Agent _messengerAgent;
        Container _container;
        public Area MessengerArea;
        Point _centerPoint;
        public List<Message> ReplyWaitingList;
        public List<Message> AdaptingWaitingList ;

       //***********************************************************************************************************************************
       public void OnTimedEvent()
       {
           //
           if (ReplyWaitingList == null)
           {
               return;
           }

           foreach (Message message in ReplyWaitingList)
           {
               if (message.RoutingTime != null)
               {
                   if ((Time.GlobalSimulationTime - message.RoutingTime) > 50 && message.RoutingTime != -1)
                   {
                       if (message.ReciverAgent.AgentType == Role.RolesName.Ruler)
                       {
                           Message adaptListMessage = AdaptingWaitingList.Find(delegate(Message tempMessage)
                           {
                               return tempMessage.SenderAgentId == message.SenderAgentId && tempMessage.RecieverAgentId == tempMessage.RecieverAgentId  ;
                           });

                           if (adaptListMessage == null)
                           {
                              // message.routingTime = Time.GlobalSimulationTime;
                               AdaptingWaitingList.Add(message.Copy());
                               SendBroadcastMessage(this._messengerAgent, this._messengerAgent, Program.BroadcastType.MessengersToRulersBroadcast,
                               Program.MessagesContent.LostRuler, 1);
                           }

                           else
                           {
                               message.RoutingTime = Time.GlobalSimulationTime;
                               SendBroadcastMessage(this._messengerAgent, this._messengerAgent, Program.BroadcastType.MessengersToRulersBroadcast,
                               Program.MessagesContent.LostRuler, 2);
                           }
                       }

                   }
               }
           }
       }

       //***************************************************************************************************************************************


        public Messenger(Agent agent,Container cont, Area area)
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

        public void oursProcessMessage(Message message)
        {
            if (message.MessageContent == Program.MessagesContent.ReplyRulerNum)
            {
                if (message.RulerPingReply != null)
                {
                    if (AdaptingWaitingList.Count > 0)
                    {
                        foreach(Message adaptingMessage in AdaptingWaitingList)
                        {
                            SendMessage(this._messengerAgent, this._messengerAgent, adaptingMessage.SenderAgent, adaptingMessage.SenderAgentId,
                                Program.BroadcastType.SingleCast, Program.MessagesContent.ReplyRulerNum, message.RulerPingReply);

                            Message replyListMessage = ReplyWaitingList.Find(delegate(Message tempMessage)
                            {
                                return tempMessage.SenderAgent  == adaptingMessage.SenderAgent;
                            });
                            ReplyWaitingList.Remove(replyListMessage);

                        }


                        AdaptingWaitingList.Clear();
                    }
                }        
            }
        }

        //private void oursRouting(Message message)
        //{
        //    if (message.messageContent == Program.MessagesContent.ping)
        //    {
        //        message.routingTime = Time.GlobalSimulationTime;
        //        message.currentRecieverAgentID = message.recieverAgentID;
        //        message.currentReciverAgent = message.ReciverAgent;
        //        message.currentSenderAgentID = this.messengerAgent.agentID;
        //        message.currentSenderAgent = this.messengerAgent;
        //        message.RoutingList.Add(this.messengerAgent);
        //        replyWaitingList.Add(message.Copy());
        //        container.containerMedia.sendMessage(this.messengerAgent, message.Copy());
                
        //    }

        //    if (message.messageContent == Program.MessagesContent.pingReply)
        //    {
           
        //        message.currentRecieverAgentID = message.recieverAgentID;
        //        message.currentReciverAgent = message.ReciverAgent;
        //        message.currentSenderAgentID = this.messengerAgent.agentID;
        //        message.currentSenderAgent = this.messengerAgent;
        //        message.RoutingList.Add(this.messengerAgent);
        //        container.containerMedia.sendMessage(this.messengerAgent, message.Copy());
        //        foreach (Message pingMessage in replyWaitingList)
        //        {
        //            if (pingMessage.ReciverAgent == message.senderAgent)
        //            {
        //                replyWaitingList.Remove(pingMessage);
        //                break;
        //            }
        //        }
              
        //    }
        //    else if (message.messageContent == Program.MessagesContent.LostRuler)
        //    {
        //        message.currentRecieverAgentID = message.recieverAgentID;
        //        message.currentReciverAgent = message.ReciverAgent;
        //        message.currentSenderAgentID = this.messengerAgent.agentID;
        //        message.currentSenderAgent = this.messengerAgent;
        //        message.RoutingList.Add(this.messengerAgent);
        //        container.containerMedia.sendMessage(this.messengerAgent, message.Copy());
        //    }
        //}

        private void AdaptToLostMessage(Message message)
        {
            Agent failedAgent = message.
                ReciverAgent;
        }

        internal void getMessage(Message message)
        {
            if (Program.OursExecutionMode)
            {
                OursGetMessage(message);
            }
            else
            {
                if (message.RecieverAgentId == _messengerAgent.AgentId)
                {
                    {
                        ProcessMessage(message);
                    }
                }
                else if (message.RecieverAgentId == "-1")
                {
                    message.CurrentRecieverAgentId = "-1";
                    message.CurrentSenderAgent = this._messengerAgent;
                    message.CurrentSenderAgentId = this._messengerAgent.AgentId;
                    message.RoutingList.Add(this._messengerAgent);
                    _container.ContainerMedia.sendMessage(this._messengerAgent, message.Copy());
                }
                else //must route Message
                {
                    if (calculateDistance(_messengerAgent.getPosition().Position, message.ReciverAgent.getPosition().Position) <= RadioRange)
                    {
                        message.CurrentRecieverAgentId = message.RecieverAgentId;
                        message.CurrentReciverAgent = message.ReciverAgent;
                        message.CurrentSenderAgentId = this._messengerAgent.AgentId;
                        message.CurrentSenderAgent = this._messengerAgent;
                        message.RoutingList.Add(this._messengerAgent);
                        _container.ContainerMedia.sendMessage(this._messengerAgent, message.Copy());

                    }
                    else
                    {
                        //if (Program.oursExecutionMode&&  message.messageContent == Program.MessagesContent.LostRuler)
                        //{
                        //    oursRouting(message.Copy());
                        //}
                        //else
                        //{
                        Agent mAgent = FindNearestMessenger(_messengerAgent.getPosition(), message.ReciverAgent.getPosition(), message);
                        if (mAgent == null)
                        {
                            RadioRange += 50;
                            _messengerAgent.RadioRange += 50;
                            getMessage(message);
                            return;
                        }
                        message.CurrentRecieverAgentId = mAgent.AgentId;
                        message.CurrentReciverAgent = mAgent;
                        message.CurrentSenderAgent = this._messengerAgent;
                        message.CurrentSenderAgentId = this._messengerAgent.AgentId;
                        message.RoutingList.Add(this._messengerAgent);
                        _container.ContainerMedia.sendMessage(this._messengerAgent, message.Copy());
                        //}

                    }
                }
            }
           
            
        }

        private void OursGetMessage(Message message)
        {
            if (message.RecieverAgentId == _messengerAgent.AgentId)
            {
                {
                    oursProcessMessage(message);
                }
            }
            else if(message.RecieverAgentId == "-1")
            {
                    message.CurrentRecieverAgentId = "-1";
                    message.CurrentSenderAgent = this._messengerAgent;
                    message.CurrentSenderAgentId = this._messengerAgent.AgentId;
                    message.RoutingList.Add(this._messengerAgent);
                    _container.ContainerMedia.sendMessage(this._messengerAgent, message.Copy());   
            }

            else if (calculateDistance(_messengerAgent.getPosition().Position, message.ReciverAgent.getPosition().Position) <= RadioRange)
            {
                if (message.MessageContent == Program.MessagesContent.Ping)
                {
                    message.RoutingTime = Time.GlobalSimulationTime;
                    message.CurrentRecieverAgentId = message.RecieverAgentId;
                    message.CurrentReciverAgent = message.ReciverAgent;
                    message.CurrentSenderAgentId = this._messengerAgent.AgentId;
                    message.CurrentSenderAgent = this._messengerAgent;
           
                    message.RoutingList.Add(this._messengerAgent);
                    ReplyWaitingList.Add(message.Copy());
                    _container.ContainerMedia.sendMessage(this._messengerAgent, message.Copy());
                }
                else  if (message.MessageContent == Program.MessagesContent.PingReply)
                {
                    message.CurrentRecieverAgentId = message.RecieverAgentId;
                    message.CurrentReciverAgent = message.ReciverAgent;
                    message.CurrentSenderAgentId = this._messengerAgent.AgentId;
                    message.CurrentSenderAgent = this._messengerAgent;
                    message.RoutingList.Add(this._messengerAgent);
                    _container.ContainerMedia.sendMessage(this._messengerAgent, message.Copy());
                    foreach (Message pingMessage in ReplyWaitingList)
                    {
                        if (pingMessage.ReciverAgent == message.SenderAgent)
                        {
                            ReplyWaitingList.Remove(pingMessage);
                            break;
                        }
                    }
                }

                else
                {
                    message.CurrentRecieverAgentId = message.RecieverAgentId;
                    message.CurrentReciverAgent = message.ReciverAgent;
                    message.CurrentSenderAgentId = this._messengerAgent.AgentId;
                    message.CurrentSenderAgent = this._messengerAgent;
                    message.RoutingList.Add(this._messengerAgent);
                    _container.ContainerMedia.sendMessage(this._messengerAgent, message.Copy());
                }
            }

            else
            {
                if (message.MessageContent == Program.MessagesContent.PingReply)
                {
                    foreach (Message pingMessage in ReplyWaitingList)
                    {
                        if (pingMessage.ReciverAgent == message.SenderAgent)
                        {
                            ReplyWaitingList.Remove(pingMessage);
                            break;
                        }
                    }

                }


                Agent mAgent = FindNearestMessenger(_messengerAgent.getPosition(), message.ReciverAgent.getPosition(), message);
                if (mAgent == null)
                {
                    RadioRange += 50;
                    _messengerAgent.RadioRange += 50;
                    getMessage(message);
                    return;
                }
                message.CurrentRecieverAgentId = mAgent.AgentId;
                message.CurrentReciverAgent = mAgent;
                message.CurrentSenderAgent = this._messengerAgent;
                message.CurrentSenderAgentId = this._messengerAgent.AgentId;
                message.RoutingList.Add(this._messengerAgent);
                _container.ContainerMedia.sendMessage(this._messengerAgent, message.Copy());

            }



        }

        private void oursMultiRouting(Message message)
        {

            if (message.MessageContent == Program.MessagesContent.PingReply)
            {

              
                message.CurrentSenderAgentId = this._messengerAgent.AgentId;
                message.CurrentSenderAgent = this._messengerAgent;

                if (calculateDistance(this._messengerAgent.getPosition().Position, message.ReciverAgent.getPosition().Position)< RadioRange)
                {
                    message.CurrentRecieverAgentId = message.RecieverAgentId;
                    message.CurrentReciverAgent = message.ReciverAgent;

                }

                else
                {
                    {
                        Agent tempMessengerAgent = FindNearestMessenger(this._messengerAgent.getPosition(), message.ReciverAgent.getPosition(), message);

                        if (_messengerAgent == null)
                        {
                            RadioRange += 50;
                            _messengerAgent.RadioRange += 50;
                            oursMultiRouting(message);

                        }

                        message.CurrentReciverAgent = tempMessengerAgent;
                        message.CurrentRecieverAgentId = tempMessengerAgent.AgentId;
                    }

                }
               
                message.RoutingList.Add(this._messengerAgent);


                _container.ContainerMedia.sendMessage(this._messengerAgent, message.Copy());
                foreach (Message pingMessage in ReplyWaitingList)
                {
                    if (pingMessage.ReciverAgent == message.SenderAgent)
                    {
                        ReplyWaitingList.Remove(pingMessage);
                        break;
                    }
                }

            }
        }

        private void SendMessage(Agent senderAgent, Agent currentSenderAgent, Agent reciverAgent,
           string reciverId,
           Program.BroadcastType messageType,
           Program.MessagesContent messageContent, Agent rulerAgent)
        {
            Message message = new Message();
            message.CurrentSenderAgent = currentSenderAgent;
            message.CurrentSenderAgentId = currentSenderAgent.AgentId;
            message.SenderAgentId = senderAgent.AgentId;
            message.SenderAgent = senderAgent;
            message.ReciverAgent = reciverAgent;
            message.RecieverAgentId = reciverId;

            message.MessageContent = messageContent;
            message.MessageType = messageType;
    

            if (calculateDistance(_messengerAgent.getPosition().Position, message.ReciverAgent.getPosition().Position) <= RadioRange)
            {
             
                message.CurrentReciverAgent = message.ReciverAgent;
            message.CurrentRecieverAgentId = message.RecieverAgentId;

            }
            else
            {
             Agent  tempMessengerAgent = FindNearestMessenger(this._messengerAgent.getPosition(), reciverAgent.getPosition(),message);

            message.RulerPingReply = rulerAgent;
            if (_messengerAgent == null)
            {
                RadioRange += 50;
                _messengerAgent.RadioRange += 50;
                SendMessage(senderAgent, currentSenderAgent, reciverAgent, reciverId, messageType, messageContent, rulerAgent);
                return;

            }

                message.CurrentReciverAgent = tempMessengerAgent;
            message.CurrentRecieverAgentId = tempMessengerAgent.AgentId;
            }


             
            

            bool messageStatus = _container.ContainerMedia.sendMessage(message.SenderAgent, message.Copy());
        }

            //Agent messengerAgent = FindNearestMessenger(messengerAgent.getPosition(), recieverAgent.getPosition());

            //message.currentRecieverAgentID = messengerAgent.agentID;

            //Messenger messenger = (Messenger)messengerAgent.agentRole;
            //messenger.getMessage(message, recieverAgent);
       

        public Agent FindNearestMessenger(AgentPosition agentPosition, AgentPosition destPosition, Message message)
        {
            double minDist = 10000;
            Agent nAgent = null;
            foreach (Agent mAgent in _container.MessangerList)
            {
                if (mAgent != this._messengerAgent )
                {
                    Agent foundAgent = message.RoutingList. Find( delegate(Agent messengerAg){
                       return messengerAg == mAgent;});



                 
                    if (foundAgent == null)
                    {
                        //Role temptRole = (Role)mAgent.agentRole;
                        if (calculateDistance(agentPosition.Position, mAgent.getPosition().Position) <= RadioRange && calculateDistance(agentPosition.Position, mAgent.getPosition().Position) + calculateDistance(destPosition.Position, mAgent.getPosition().Position) < minDist)
                        {
                            minDist = calculateDistance(agentPosition.Position, mAgent.getPosition().Position) + calculateDistance(destPosition.Position, mAgent.getPosition().Position);
                            nAgent = mAgent;
                        }
                    }
                   
                }
            }
            return nAgent;
        }
       //************************************************************
     public double calculateDistance(Point position, Point position2)
        {
            double dest;
            double x = position.X - position2.X;
            double y = position.Y - position2.Y;
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
         Message message = new Message();
         message.CurrentSenderAgent = currentSenderAgent;
         message.CurrentSenderAgentId = currentSenderAgent.AgentId;
         message.SenderAgentId = senderAgent.AgentId;
         message.SenderAgent = senderAgent;
         message.ReciverAgent = null;
         message.RecieverAgentId = "-1";
         message.MessageContent = messageContent;
         message.MessageType = messageType;
         message.NumOfBoroadcastSteps = iBroadcastNum;
         message.CurrentRecieverAgentId = "-1";
         message.CurrentReciverAgent = null;


         bool messageStatus = _container.ContainerMedia.sendMessage(message.SenderAgent, message.Copy());

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
