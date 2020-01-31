using System.Collections.Generic;
using OpenTK.Graphics.OpenGL;
using Simulation.Core;
using Simulation.Enums;
using Simulation.Tools;

namespace Simulation.Roles
{
    public class Worker : Agent
    {
        public Worker(Configuration config, AgentPosition pos, string id,
            OrganizationBoundries orgBoundary, Container cont)
            : base(config, pos, id, cont)
        {
            TeamBoundary = orgBoundary;
            ReplyWaitingList = new List<Message>();
            MaxPingDelay = 10000;
        }

        public Leader LeaderAgent { get; set; }
        protected OrganizationBoundries TeamBoundary { get; set; }
        protected int MaxPingDelay { get; set; }

        protected override void Movement()
        {
            base.Movement();

            if (Position.Position.CalculateDistance(TeamBoundary.OrgCenter) > TeamBoundary.Radius)
            {
                // go back to center slowly
                Position.Velocity.X *= -1;
                Position.Velocity.Y *= -1;
                UpdateVelocity(Position);
            }
        }

        protected override void FreeMovement()
        {
            base.FreeMovement();

            if (Position.Position.X > Config.UpperBoarder.X - Config.LowerBoarder.X)
            {
                Position.Velocity.X *= -1;
                UpdateVelocity(Position);
            }
            if (Position.Position.X < 0)
            {
                Position.Position.X = Config.LowerBoarder.X;
                Position.Velocity.X *= -1;
                UpdateVelocity(Position);
            }

            if (Position.Position.Y > Config.UpperBoarder.Y - Config.LowerBoarder.Y)
            {
                Position.Velocity.Y *= -1;
                UpdateVelocity(Position);
            }
            if (Position.Position.Y < 0)
            {
                Position.Position.Y = Config.LowerBoarder.Y;
                Position.Velocity.Y *= -1;
                UpdateVelocity(Position);
            }
        }

        public override void Draw()
        {
            var p = Position.Position;
            if (Status == State.Failed)
                GL.Color3(255f, 0f, 0f);
            else
                GL.Color3(125f, 125f, 0f);
            GL.Begin(PrimitiveType.Points);
            GL.Vertex2(p.X, p.Y);
            GL.End();
        }

        public override void UpdateOneMillisecond()
        {
            base.UpdateOneMillisecond();
            var period = Config.Rnd.Next(10000, 10100);
            if (Time.GlobalSimulationTime % period == 0) // ping per 1sec
            {
                var messenger = FindNearestMessenger();
                if (messenger == null) return;
                var ping = new Message()
                {
                    RoutingTime = Time.GlobalSimulationTime,
                    SenderAgent = this,
                    SenderAgentId = AgentId,
                    CurrentSenderAgent = this,
                    CurrentReceiverAgent = messenger,
                    CurrentReceiverAgentId = messenger.AgentId,
                    ReceiverAgent = LeaderAgent,
                    ReceiverAgentId = LeaderAgent.AgentId,
                    MessageType = BroadcastType.SendReceive,
                    MessageContent = MessagesContent.Ping,
                    DataMessageText = ""
                };
                SendMessage(ping);
                ReplyWaitingList.Add(ping);
            }

            CheckPingList();
        }

        public override void OnMessage(Message message)
        {
            if (Status == State.Failed) return;

            if (message.MessageContent == MessagesContent.PingReply)
            {
                var index = ReplyWaitingList.FindIndex(m => m.ReceiverAgentId == message.SenderAgentId);
                if (index >= 0)
                    ReplyWaitingList.RemoveAt(index);
            }
        }

        protected void CheckPingList()
        {
            var expiredPing = ReplyWaitingList.Find(m => Time.GlobalSimulationTime - m.RoutingTime > MaxPingDelay);
            if (expiredPing?.ReceiverAgent is Leader)
            {
                // Leader is lost
                var messenger = FindNearestMessenger();
                if (messenger != null)
                {
                    ReplyWaitingList.Remove(expiredPing); // remove to prevent duplicate request
                    var ping = new Message()
                    {
                        RoutingTime = Time.GlobalSimulationTime,
                        SenderAgent = this,
                        SenderAgentId = AgentId,
                        CurrentSenderAgent = this,
                        CurrentReceiverAgent = messenger,
                        CurrentReceiverAgentId = messenger.AgentId,
                        ReceiverAgent = messenger,
                        ReceiverAgentId = messenger.AgentId,
                        MessageType = BroadcastType.SingleCast,
                        MessageContent = MessagesContent.LostLeader,
                    };
                    SendMessage(ping);
                }
            }
        }
    }
}
