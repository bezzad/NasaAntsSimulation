using System;
using System.Collections.Generic;

namespace Simulation.Roles
{
    public class Ruler : Role
    {
        public Agent RulerAgent { set; get; }
        public Area RulerArea { set; get; }
        public Container Container { set; get; }
        public List<Agent> LeaderList { get; set; }
        public State Status { set; get; }


        public Ruler(Area area, Container cont, Agent agent)
        {
            RulerArea = area;
            Container = cont;
            RulerAgent = agent;
            LeaderList = InitialLeaderList();
            Status = State.Stable;

            foreach (var leaderAgent in LeaderList)
            {
                var leader = (Leader)leaderAgent.AgentRole;
                leader.RulerAgent = RulerAgent;
                leaderAgent.AgentRole = leader;
            }
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
        
        public void GetAndSendMessage(Message message)
        {
            if (message.ReceiverAgentId == RulerAgent.AgentId)
            {
                if (message.MessageContent == Program.MessagesContent.Ping)
                {
                    if (Program.OursExecutionMode)
                    {
                        if (Status == State.Stable)
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
                                MessageContent = Program.MessagesContent.PingReply
                            };
                            var messengerAgent = message.CurrentSenderAgent;
                            replyMessage.CurrentReceiverAgentId = messengerAgent.AgentId;
                            replyMessage.CurrentReceiverAgent = messengerAgent;
                            Container.ContainerMedia.SendMessage(RulerAgent, replyMessage.Copy());
                        }
                    }
                    else
                    {
                        if (Status == State.Stable)
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
                                MessageContent = Program.MessagesContent.PingReply
                            };
                            var messengerAgent = FindNearestMessenger(RulerAgent.GetPosition(), message.SenderAgent.GetPosition());
                            if (messengerAgent == null)
                            {

                                RadioRange += 50;
                                RulerAgent.RadioRange += 50;

                                GetAndSendMessage(message);
                                return;
                            }


                            replyMessage.CurrentReceiverAgentId = messengerAgent.AgentId;
                            replyMessage.CurrentReceiverAgent = messengerAgent;



                            Container.ContainerMedia.SendMessage(RulerAgent, replyMessage.Copy());
                        }
                    }


                }
                else if (Program.OursExecutionMode && message.MessageContent == Program.MessagesContent.LostRuler)
                {
                    if (Status == State.Stable)
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
                            if (RulerAgent.GetPosition().Position.CalculateDistance( replyMessage.ReceiverAgent.GetPosition().Position) < RadioRange)
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

                                    GetAndSendMessage(message);
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

                                GetAndSendMessage(message);
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
        
        private Agent FindNearestMessenger(AgentPosition agentPosition, AgentPosition destPosition)
        {
            double minDist = 10000;
            Agent nAgent = null;

            foreach (var mAgent in Container.MessengerList)
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
            return nAgent;
        }
    }
}
