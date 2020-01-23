using System;
using System.Collections.Generic;

namespace Simulation.Roles
{
    public class Ruler:Role
    {
        public Agent RulerAgent { set; get; }
        public Area RulerArea { set; get; }
        public Container Container { set; get; }
        public List<Agent> LeaderList { get; set; }
        // 1 is OK, 0 is Failed
        public int Status { set; get; }


        public Ruler(Area area, Container cont, Agent agent)
        {
            RulerArea = area;
            Container = cont;
            RulerAgent = agent;
            LeaderList = InitialLeaderList();
            foreach(var leaderAgent in LeaderList)
            {
                var leader = (Leader)leaderAgent.AgentRole;
                leader.RulerAgent = RulerAgent;
                leaderAgent.AgentRole = leader;
            }

            Status = 1;

        }



        private List<Agent> InitialLeaderList()
        {
            var tempTeamList = FindTeamsInArea();
            var tempLeaderList = new List<Agent>();
            foreach (var team in tempTeamList)
            {
                tempLeaderList.Add(team.OrgLeader);

            }

            return tempLeaderList;
        }

        private List<Team> FindTeamsInArea()
        {
            var tempTeamList = new List<Team>();
            foreach (var team in Container.TeamList)
            {
                if (team.OrganizationBoundries.OrgCenter.X >= RulerArea.MinX && team.OrganizationBoundries.OrgCenter.X <= RulerArea.MaxX && team.OrganizationBoundries.OrgCenter.Y >= RulerArea.MinY && team.OrganizationBoundries.OrgCenter.Y <= RulerArea.MaxY)
                {
                    tempTeamList.Add(team);
                }
            }
            return tempTeamList;
        }

        public void ProcessMessage(Message message)
        {

        }

        public void GetandSendMessage(Message message)
        {
            if (message.ReceiverAgentId == RulerAgent.AgentId)
            {
                if (message.MessageContent == Program.MessagesContent.Ping)
                {
                    if (Program.OursExecutionMode)
                    {
                        ProcessMessage(message);
                        if (Status == 1)
                        {
                            //message.returnedStatus = 1;
                            var replyMessage = new Message
                            {
                                MessageType = Program.BroadcastType.SingleCast,
                                ReceiverAgentId = message.SenderAgentId,
                                ReceiverAgent = message.SenderAgent,
                                SenderAgent = RulerAgent,
                                SenderAgentId = RulerAgent.AgentId,
                                CurrentSenderAgent = RulerAgent,
                                CurrentSenderAgentId = RulerAgent.AgentId,
                                MessageContent = Program.MessagesContent.PingReply
                            };
                            var messengerAgent = message.CurrentSenderAgent;

                            //shoulf be revised

                            //    FindNearestMessenger(rulerAgent.getPosition(), message.senderAgent.getPosition());
                            //if (messengerAgent == null)
                            //{

                            //    RadioRange += 50;
                            //    rulerAgent.RadioRange += 50;

                            //    GetandSendMessage(message);
                            //    return;
                            //}

                         
                            replyMessage.CurrentReceiverAgentId = messengerAgent.AgentId;
                            replyMessage.CurrentReceiverAgent = messengerAgent;




                            Container.ContainerMedia.SendMessage(RulerAgent, replyMessage.Copy());
                        }

                        else
                        {
                            var x = 0;
                            // message.returnedStatus = 0;
                        }
                    }
                    else
                    {
                        ProcessMessage(message);
                        if (Status == 1)
                        {
                            //message.returnedStatus = 1;
                            var replyMessage = new Message();
                            replyMessage.MessageType = Program.BroadcastType.SingleCast;
                            replyMessage.ReceiverAgentId = message.SenderAgentId;
                            replyMessage.ReceiverAgent = message.SenderAgent;
                            replyMessage.SenderAgent = RulerAgent;
                            replyMessage.SenderAgentId = RulerAgent.AgentId;
                            replyMessage.CurrentSenderAgent = RulerAgent;
                            replyMessage.CurrentSenderAgentId = RulerAgent.AgentId;
                            replyMessage.MessageContent = Program.MessagesContent.PingReply;
                            var messengerAgent = FindNearestMessenger(RulerAgent.GetPosition(), message.SenderAgent.GetPosition());
                            if (messengerAgent == null)
                            {

                                RadioRange += 50;
                                RulerAgent.RadioRange += 50;

                                GetandSendMessage(message);
                                return;
                            }


                            replyMessage.CurrentReceiverAgentId = messengerAgent.AgentId;
                            replyMessage.CurrentReceiverAgent = messengerAgent;



                            Container.ContainerMedia.SendMessage(RulerAgent, replyMessage.Copy());
                        }

                        else
                        {
                            var x = 0;
                            // message.returnedStatus = 0;
                        }
                    }


                }
                else if (Program.OursExecutionMode && message.MessageContent == Program.MessagesContent.LostRuler)
                {
                    if (Status == 1)
                    {
                        var replyMessage = new Message
                        {
                            MessageType = Program.BroadcastType.SingleCast,
                            ReceiverAgentId = message.SenderAgentId,
                            ReceiverAgent = message.SenderAgent,
                            SenderAgent = RulerAgent,
                            SenderAgentId = RulerAgent.AgentId,
                            CurrentSenderAgent = RulerAgent,
                            CurrentSenderAgentId = RulerAgent.AgentId,
                            MessageContent = Program.MessagesContent.ReplyRulerNum,
                            RulerPingReply = RulerAgent
                        };
                        if (message.ReceiverAgent.AgentType == RolesName.Messenger)
                        {
                            if (CalculateDistance(RulerAgent.GetPosition().Position, replyMessage.ReceiverAgent.GetPosition().Position) < RadioRange)
                            {
                                replyMessage.CurrentReceiverAgent = replyMessage.ReceiverAgent;
                                replyMessage.CurrentReceiverAgentId = replyMessage.ReceiverAgentId;
                            }
                            else
                            {
                                var messengerAgent = FindNearestMessenger(RulerAgent.GetPosition(), message.SenderAgent.GetPosition());
                                if (messengerAgent == null)
                                {

                                    RadioRange += 50;
                                    RulerAgent.RadioRange += 50;

                                    GetandSendMessage(message);
                                    return;
                                }

                                replyMessage.CurrentReceiverAgentId = messengerAgent.AgentId;
                                replyMessage.CurrentReceiverAgent = messengerAgent;
                            }
                        }
                        else
                        {
                            var messengerAgent = FindNearestMessenger(RulerAgent.GetPosition(), message.SenderAgent.GetPosition());
                            if (messengerAgent == null)
                            {

                                RadioRange += 50;
                                RulerAgent.RadioRange += 50;

                                GetandSendMessage(message);
                                return;
                            }

                            replyMessage.CurrentReceiverAgentId = messengerAgent.AgentId;
                            replyMessage.CurrentReceiverAgent = messengerAgent;

                        }
                     



                        Container.ContainerMedia.SendMessage(replyMessage.SenderAgent, replyMessage.Copy());

                    }
                }
            }

        }

        internal void GetMessage(Message message)
        {
            if (message.ReceiverAgentId == RulerAgent.AgentId)
            {
                ProcessMessage(message);
            }
            else //must route Message
            {
                // SendMessage(message, recieverAgent);
            }
        }

        //public void SendMessage(Message message, Agent recieverAgent)
        //{
        //    Agent messengerAgent = FindNearestMessenger(rulerAgent.getPosition(), recieverAgent.getPosition());

        //    message.currentRecieverAgentID = messengerAgent.agentID;

        //    Messenger messenger = (Messenger)messengerAgent.agentRole;
        //    messenger.getMessage(message);
        //}

        private Agent FindNearestMessenger(AgentPosition agentPosition, AgentPosition destPosition)
        {
            double minDist = 10000;
            Agent nAgent = null;
            var testList = new List<double>();

            //foreach (Agent mAgent in container.MessangerList)
            //{
            //    //Role temptRole = (Role)mAgent.agentRole;
            //    testList.Add(calculateDistance(agentPosition.Position, mAgent.getPosition().Position));
                
            //}

            foreach (var mAgent in Container.MessengerList)
            {
                //Role temptRole = (Role)mAgent.agentRole;
                if (CalculateDistance(agentPosition.Position, mAgent.GetPosition().Position) <= RadioRange && CalculateDistance(agentPosition.Position, mAgent.GetPosition().Position) + CalculateDistance(destPosition.Position, mAgent.GetPosition().Position) < minDist)
                {
                    minDist = CalculateDistance(agentPosition.Position, mAgent.GetPosition().Position) + CalculateDistance(destPosition.Position, mAgent.GetPosition().Position);
                    nAgent = mAgent;
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
    }
}
