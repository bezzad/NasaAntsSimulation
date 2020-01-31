using OpenTK.Graphics.OpenGL;
using Simulation.Core;
using Simulation.Enums;
using Simulation.Tools;
using System.Collections.Generic;
using System.Linq;
using Configuration = Simulation.Core.Configuration;

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
        public List<Message> AdaptingWaitingList { get; set; }



        protected void OnTimedEvent()
        {
            if (ReplyWaitingList?.Any() != true)
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

        protected void ProcessMessage(Message message)
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

        public override void OnMessage(Message message)
        {
            if (Status == State.Failed) return;

            if (message.ReceiverAgentId == AgentId)
            {
                {
                    ProcessMessage(message);
                }
            }
            else if (message.ReceiverAgentId == "-1")
            {
                message.CurrentReceiverAgentId = "-1";
                message.CurrentSenderAgent = this;
                message.CurrentSenderAgentId = AgentId;
                message.RoutingList.Add(this);
                Container.ContainerMedia.SendMessage(message.Copy());
            }

            else if (Position.Position.CalculateDistance(message.ReceiverAgent.Position.Position) <= RadioRange)
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
                    Container.ContainerMedia.SendMessage(message.Copy());
                }
                else if (message.MessageContent == MessagesContent.PingReply)
                {
                    message.CurrentReceiverAgentId = message.ReceiverAgentId;
                    message.CurrentReceiverAgent = message.ReceiverAgent;
                    message.CurrentSenderAgentId = AgentId;
                    message.CurrentSenderAgent = this;
                    message.RoutingList.Add(this);
                    Container.ContainerMedia.SendMessage(message.Copy());
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
                    Container.ContainerMedia.SendMessage(message.Copy());
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


                var mAgent = FindNearestMessenger(Position, message.ReceiverAgent.Position, message);
                if (mAgent == null)
                {
                    RadioRange += 50;
                    RadioRange += 50;
                    OnMessage(message);
                    return;
                }
                message.CurrentReceiverAgentId = mAgent.AgentId;
                message.CurrentReceiverAgent = mAgent;
                message.CurrentSenderAgent = this;
                message.CurrentSenderAgentId = AgentId;
                message.RoutingList.Add(this);
                Container.ContainerMedia.SendMessage(message.Copy());

            }
        }

        protected void SendMessage(Agent senderAgent, Agent currentSenderAgent, Agent receiverAgent,
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

            if (Position.Position.CalculateDistance(message.ReceiverAgent.Position.Position) <= RadioRange)
            {
                message.CurrentReceiverAgent = message.ReceiverAgent;
                message.CurrentReceiverAgentId = message.ReceiverAgentId;
            }
            else
            {
                var temp = FindNearestMessenger(Position, receiverAgent.Position, message);
                message.RulerPingReply = rulerAgent;
                message.CurrentReceiverAgent = temp;
                message.CurrentReceiverAgentId = temp.AgentId;
            }

            Container.ContainerMedia.SendMessage(message.Copy());
        }

        protected Agent FindNearestMessenger(AgentPosition agentPosition, AgentPosition destPosition, Message message)
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
                        if (agentPosition.Position.CalculateDistance(mAgent.Position.Position) <= RadioRange &&
                            agentPosition.Position.CalculateDistance(mAgent.Position.Position) +
                            destPosition.Position.CalculateDistance(mAgent.Position.Position) < minDist)
                        {
                            minDist = agentPosition.Position.CalculateDistance(mAgent.Position.Position) +
                                      destPosition.Position.CalculateDistance(mAgent.Position.Position);
                            nAgent = mAgent;
                        }
                    }

                }
            }
            return nAgent;
        }

        protected void SendBroadcastMessage(Agent senderAgent,
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
            Container.ContainerMedia.SendMessage(message.Copy());
        }


        public override void FreeUpdateOneMillisecond()
        {
            if (Time.GlobalSimulationTime % 50 == 0 &&
                Time.GlobalSimulationTime > 100)
            {
                OnTimedEvent();
            }

            base.FreeUpdateOneMillisecond();
        }

        protected override void FreeMovement()
        {
            base.FreeMovement();

            if (Position.Position.X > MessengerArea.MaxX)
            {
                Position.Velocity.X *= -1;
                Position.Position.X = MessengerArea.MaxX;
                UpdateVelocity(Position);
            }

            if (Position.Position.X < MessengerArea.MinX)
            {
                Position.Velocity.X *= -1;
                Position.Position.X = MessengerArea.MinX;
                UpdateVelocity(Position);
            }

            if (Position.Position.Y > MessengerArea.MaxY)
            {
                Position.Velocity.Y *= -1;
                Position.Position.Y = MessengerArea.MaxY;
                UpdateVelocity(Position);
            }

            if (Position.Position.Y < MessengerArea.MinY)
            {
                Position.Velocity.Y *= -1;
                Position.Position.Y = MessengerArea.MinY;
                UpdateVelocity(Position);
            }
        }

        public override void Draw()
        {
            var p = Position.Position;
            if (Status == State.Failed)
                GL.Color3(255f, 0f, 0f);
            else
                GL.Color3(0f, 255f, 0f);
            //
            // +Y
            // |     c________b  l_k  g________h
            // |     |        \  | |  /        |
            // |     |        a\_|p|_/f        |
            // |     |         / | | \         |
            // |     |________/  | |  \________|
            // |     d       e   | |   j       i
            // |                 |_|         
            // |                 q r         
            // |------------------------------------> +X                 
            //
            var a = new Point(p.X - 5, p.Y);
            var b = new Point(a.X - 5, a.Y + 8);
            var c = new Point(b.X - 15, b.Y);
            var d = new Point(c.X, c.Y - 18);
            var e = new Point(b.X, b.Y - 18);
            var f = new Point(p.X + 5, p.Y);
            var g = new Point(f.X + 5, f.Y + 8);
            var h = new Point(g.X + 15, g.Y);
            var i = new Point(h.X, h.Y - 18);
            var j = new Point(g.X, g.Y - 18);
            var l = new Point(p.X - 2, b.Y);
            var k = new Point(p.X + 2, b.Y);
            var q = new Point(l.X, e.Y - 18);
            var r = new Point(k.X, j.Y - 18);

            GL.Begin(PrimitiveType.LineLoop);
            GL.Vertex2(p.X, p.Y);
            GL.Vertex2(a.X, a.Y);
            GL.Vertex2(b.X, b.Y);
            GL.Vertex2(c.X, c.Y);
            GL.Vertex2(d.X, d.Y);
            GL.Vertex2(e.X, e.Y);
            GL.Vertex2(a.X, a.Y);
            GL.Vertex2(f.X, f.Y);
            GL.Vertex2(g.X, g.Y);
            GL.Vertex2(h.X, h.Y);
            GL.Vertex2(i.X, i.Y);
            GL.Vertex2(j.X, j.Y);
            GL.Vertex2(f.X, f.Y);
            GL.End();

            GL.Begin(PrimitiveType.Polygon);
            GL.Vertex2(k.X, k.Y);
            GL.Vertex2(l.X, l.Y);
            GL.Vertex2(q.X, q.Y);
            GL.Vertex2(r.X, r.Y);
            GL.Vertex2(k.X, k.Y);
            GL.End();
        }
    }
}
