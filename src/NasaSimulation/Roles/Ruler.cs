using Simulation.Core;
using Simulation.Enums;
using Simulation.Tools;
using System.Collections.Generic;

namespace Simulation.Roles
{
    public class Ruler : Agent
    {
        public Area RulerArea { set; get; }
        public List<Leader> LeaderList { get; set; }
        public State Status { set; get; }


        public Ruler(Configuration config, AgentPosition pos, string id, Area area, Container cont)
            : base(config, pos, id, cont)
        {
            RulerArea = area;
            LeaderList = InitialLeaderList();
            Status = State.Stable;

            foreach (var leader in LeaderList)
            {
                leader.RulerAgent = this;
            }
        }



        private List<Leader> InitialLeaderList()
        {
            var tempTeamList = FindTeamsInArea();
            var tempLeaderList = new List<Leader>();
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
            if (message.ReceiverAgentId == AgentId)
            {
                if (message.MessageContent == MessagesContent.Ping)
                {
                    if (Config.OursExecutionMode)
                    {
                        if (Status == State.Stable)
                        {
                            var replyMessage = new Message
                            {
                                MessageType = BroadcastType.SingleCast,
                                ReceiverAgentId = message.SenderAgentId,
                                ReceiverAgent = message.SenderAgent,
                                SenderAgent = this,
                                SenderAgentId = AgentId,
                                CurrentSenderAgent = this,
                                CurrentSenderAgentId = AgentId,
                                MessageContent = MessagesContent.PingReply
                            };
                            var messengerAgent = message.CurrentSenderAgent;
                            replyMessage.CurrentReceiverAgentId = messengerAgent.AgentId;
                            replyMessage.CurrentReceiverAgent = messengerAgent;
                            Container.ContainerMedia.SendMessage(this, replyMessage.Copy());
                        }
                    }
                    else
                    {
                        if (Status == State.Stable)
                        {
                            var replyMessage = new Message
                            {
                                MessageType = BroadcastType.SingleCast,
                                ReceiverAgentId = message.SenderAgentId,
                                ReceiverAgent = message.SenderAgent,
                                SenderAgent = this,
                                SenderAgentId = AgentId,
                                CurrentSenderAgent = this,
                                CurrentSenderAgentId = AgentId,
                                MessageContent = MessagesContent.PingReply
                            };
                            var messengerAgent = FindNearestMessenger(GetPosition(), message.SenderAgent.GetPosition());
                            if (messengerAgent == null)
                            {

                                RadioRange += 50;
                                GetAndSendMessage(message);
                                return;
                            }


                            replyMessage.CurrentReceiverAgentId = messengerAgent.AgentId;
                            replyMessage.CurrentReceiverAgent = messengerAgent;
                            Container.ContainerMedia.SendMessage(this, replyMessage.Copy());
                        }
                    }


                }
                else if (Config.OursExecutionMode && message.MessageContent == MessagesContent.LostRuler)
                {
                    if (Status == State.Stable)
                    {
                        var replyMessage = new Message
                        {
                            MessageType = BroadcastType.SingleCast,
                            ReceiverAgentId = message.SenderAgentId,
                            ReceiverAgent = message.SenderAgent,
                            SenderAgent = this,
                            SenderAgentId = AgentId,
                            CurrentSenderAgent = this,
                            CurrentSenderAgentId = AgentId,
                            MessageContent = MessagesContent.ReplyRulerNum,
                            RulerPingReply = this
                        };
                        if (message.ReceiverAgent is Messenger)
                        {
                            if (GetPosition().Position.CalculateDistance(replyMessage.ReceiverAgent.GetPosition().Position) < RadioRange)
                            {
                                replyMessage.CurrentReceiverAgent = replyMessage.ReceiverAgent;
                                replyMessage.CurrentReceiverAgentId = replyMessage.ReceiverAgentId;
                            }
                            else
                            {
                                var messengerAgent = FindNearestMessenger(GetPosition(), message.SenderAgent.GetPosition());
                                if (messengerAgent == null)
                                {
                                    RadioRange += 50;
                                    GetAndSendMessage(message);
                                    return;
                                }

                                replyMessage.CurrentReceiverAgentId = messengerAgent.AgentId;
                                replyMessage.CurrentReceiverAgent = messengerAgent;
                            }
                        }
                        else
                        {
                            var messengerAgent = FindNearestMessenger(GetPosition(), message.SenderAgent.GetPosition());
                            if (messengerAgent == null)
                            {
                                RadioRange += 50;

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

        private Messenger FindNearestMessenger(AgentPosition agentPosition, AgentPosition destPosition)
        {
            double minDist = 10000;
            Messenger nAgent = null;

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

        protected override void FreeMovement()
        {
            base.FreeMovement();

            var x = (double)Config.Rnd.Next((int)RulerArea.MinX, (int)RulerArea.MaxX);
            var y = (double)Config.Rnd.Next((int)RulerArea.MinY, (int)RulerArea.MaxY);
            if (Position.Position.X > RulerArea.MaxX) Position.Position.X = x;
            if (Position.Position.X < RulerArea.MinX) Position.Position.X = x;
            if (Position.Position.Y > RulerArea.MaxY) Position.Position.Y = y;
            if (Position.Position.Y < RulerArea.MinY) Position.Position.Y = y;

            if (Time.GlobalSimulationTime > 1000 & Time.GlobalSimulationTime % 1000 == 0)
                UpdateVelocity(Position);
        }
    }
}
