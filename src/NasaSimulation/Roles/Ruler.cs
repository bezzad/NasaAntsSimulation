using Simulation.Core;
using Simulation.Enums;
using Simulation.Tools;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using OpenTK.Graphics.OpenGL;

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
                            var messengerAgent = FindNearestMessenger(Position, message.SenderAgent.Position);
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
                            if (Position.Position.CalculateDistance(replyMessage.ReceiverAgent.Position.Position) < RadioRange)
                            {
                                replyMessage.CurrentReceiverAgent = replyMessage.ReceiverAgent;
                                replyMessage.CurrentReceiverAgentId = replyMessage.ReceiverAgentId;
                            }
                            else
                            {
                                var messengerAgent = FindNearestMessenger(Position, message.SenderAgent.Position);
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
                            var messengerAgent = FindNearestMessenger(Position, message.SenderAgent.Position);
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
                if (agentPosition.Position.CalculateDistance(mAgent.Position.Position) <= RadioRange &&
                    agentPosition.Position.CalculateDistance(mAgent.Position.Position) +
                    destPosition.Position.CalculateDistance(mAgent.Position.Position) < minDist)
                {
                    minDist = agentPosition.Position.CalculateDistance(mAgent.Position.Position) +
                              destPosition.Position.CalculateDistance(mAgent.Position.Position);
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

        public override void Draw()
        {
            var p = Position.Position;
            if (Status == State.Failed)
                GL.Color3(255f, 0f, 0f);
            else
                GL.Color3(0f, 255f, 255f);

            var p1 = new Point(p.X, p.Y + 10);
            var p2 = new Point(p.X + 10, p.Y + 5);
            var p3 = new Point(p.X + 10, p.Y - 5);
            var p4 = new Point(p.X, p.Y - 10);
            var p5 = new Point(p.X - 10, p.Y - 5);
            var p6 = new Point(p.X - 10, p.Y + 5);

            GL.Begin(PrimitiveType.Polygon);
            GL.Vertex2(p1.X, p1.Y);
            GL.Vertex2(p2.X, p2.Y);
            GL.Vertex2(p3.X, p3.Y);
            GL.Vertex2(p4.X, p4.Y);
            GL.Vertex2(p5.X, p5.Y);
            GL.Vertex2(p6.X, p6.Y);
            GL.Vertex2(p1.X, p1.Y);
            GL.End();
        }
    }
}
