using OpenTK.Graphics.OpenGL;
using Simulation.Core;
using Simulation.Enums;
using Simulation.Tools;
using Message = Simulation.Core.Message;

namespace Simulation.Roles
{
    public class Leader : Agent
    {
        public Ruler RulerAgent { set; get; }
        public Team Team { get; set; }
        protected OrganizationBoundries TeamBoundary => Team.OrganizationBoundries;


        //1 is corrupted 2 is OK and 3 is under ruler correction
        int _iStatus = 2;
        long _pingTime = -1;
        long _startPartialAdaptationTime = long.MaxValue;


        public Leader(Team team, Configuration config, AgentPosition pos, string id, Container cont)
            : base(config, pos, id, cont)
        {
            Team = team;
        }

        public void OnTimedEvent()
        {
            if (_pingTime != -1 && Time.GlobalSimulationTime - _pingTime > 100 && _iStatus == 3)
            {
                if (Config.OursExecutionMode == false)
                {
                    _iStatus = 2;
                    _startPartialAdaptationTime = Time.GlobalSimulationTime;
                    SendBroadcastMessage(this, this, BroadcastType.MessengerToLeaderBroadcast,
                        MessagesContent.LostRuler, 1);
                }
            }
            else if (RulerAgent != null && _iStatus == 1)
            {
                _pingTime = Time.GlobalSimulationTime;
                var message = new Message()
                {
                    SenderAgent = this,
                    SenderAgentId = this.AgentId,
                    CurrentSenderAgent = this,
                    ReceiverAgent = RulerAgent,
                    ReceiverAgentId = RulerAgent.AgentId,
                    MessageType = BroadcastType.SendReceive,
                    MessageContent = MessagesContent.Ping,
                    DataMessageText = ""
                };
                SendMessage(message);
                _iStatus = 3;
            }
            else if (_iStatus == 2 && Time.GlobalSimulationTime - _startPartialAdaptationTime > 200)
            {
                if (Config.MultiOff)
                {
                    Config.EndOfSimulation = true;
                }

                _startPartialAdaptationTime = Time.GlobalSimulationTime;
                SendBroadcastMessage(this, this,
                    BroadcastType.MessengerToLeaderBroadcast,
                    MessagesContent.LostRuler, 2);
            }
        }


        private void SendBroadcastMessage(Agent senderAgent, Agent currentSenderAgent,
            BroadcastType messageType,
            MessagesContent messageContent, int iBroadcastNum)
        {
            if (Status == State.Failed) return;

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
                NumOfBroadcastSteps = iBroadcastNum
            };
            var messengerAgent = FindNearestMessenger(Position);
            if (messengerAgent == null)
            {
                RadioRange += 50;
                SendBroadcastMessage(senderAgent, currentSenderAgent, messageType, messageContent, iBroadcastNum);
                return;
            }

            message.CurrentReceiverAgent = messengerAgent;
            message.CurrentReceiverAgentId = messengerAgent.AgentId;

            Container.ContainerMedia.SendMessage(message.Copy());
        }

        public void ProcessMessage(Message message)
        {
            if (message.MessageContent == MessagesContent.PingReply)
            {
                _pingTime = -1;
                _iStatus = 1;
            }
            //LostRuler
            else if (message.MessageContent == MessagesContent.LostRuler)
            {
                if (_iStatus == 0 || _iStatus == 2)
                {
                    var tempMessage = new Message()
                    {
                        SenderAgent = this,
                        SenderAgentId = AgentId,
                        CurrentSenderAgent = this,
                        ReceiverAgent = message.SenderAgent,
                        ReceiverAgentId = message.SenderAgent.AgentId,
                        MessageType = BroadcastType.SingleCast,
                        MessageContent = MessagesContent.ReplyRulerNum,
                        DataMessageText = "-1"
                    };
                    SendMessage(tempMessage);
                }
                else
                {
                    var tempMessage = new Message()
                    {
                        SenderAgent = this,
                        SenderAgentId = AgentId,
                        CurrentSenderAgent = this,
                        ReceiverAgent = message.SenderAgent,
                        ReceiverAgentId = message.SenderAgent.AgentId,
                        MessageType = BroadcastType.SingleCast,
                        MessageContent = MessagesContent.ReplyRulerNum,
                        RulerPingReply = RulerAgent
                    };
                    SendMessage(tempMessage);
                }
            }
            else if (message.MessageContent == MessagesContent.ReplyRulerNum)
            {
                if (message.DataMessageText != "-1")
                {
                    var repliedRuler = message.RulerPingReply;
                    if (repliedRuler != RulerAgent)
                    {
                        RulerAgent = repliedRuler;
                        _iStatus = 1;
                        _startPartialAdaptationTime = long.MaxValue;
                        _pingTime = -1;
                        MeasureAdaptingTime();
                    }
                }
            }
        }

        private void MeasureAdaptingTime()
        {
            if (Config.EndOfSimulation)
                return;

            Time.ConventionalAdaptingTime = Time.GlobalSimulationTime - Time.StartSimulationTime;
            Config.EndOfSimulation = true;
        }

        public override void OnMessage(Message message)
        {
            if (Status == State.Failed) return;
            if (message.ReceiverAgentId == AgentId)
            {
                if (Config.OursExecutionMode)
                {
                    OursProcessMessage(message);
                }
                else
                {
                    ProcessMessage(message);
                }
            }
        }

        #region Ours

        public void OursOnTimeEvent()
        {
            if (RulerAgent != null && _iStatus == 1)
            {
                _pingTime = Time.GlobalSimulationTime;
                var tempMessage = new Message()
                {
                    SenderAgent = this,
                    SenderAgentId = AgentId,
                    CurrentSenderAgent = this,
                    ReceiverAgent = RulerAgent,
                    ReceiverAgentId = RulerAgent.AgentId,
                    MessageType = BroadcastType.SendReceive,
                    MessageContent = MessagesContent.Ping,
                    DataMessageText = ""
                };
                SendMessage(tempMessage);
                _iStatus = 3;
            }
        }

        private void OursProcessMessage(Message message)
        {
            if (message.MessageContent == MessagesContent.PingReply)
            {
                _pingTime = -1;
                _iStatus = 1;
            }
            else if (message.MessageContent == MessagesContent.LostRuler)
            {
                //if (iStatus == 0 || iStatus == 2)
                //{
                //    SendMessage(this.leaderAgent, this.leaderAgent, message.senderAgent, message.senderAgentID, BroadcastType.singleCast,
                //        MessagesContent.ReplyRulerNum, "-1");
                //}
                //else
                //{
                //    SendMessage(this.leaderAgent, this.leaderAgent, message.senderAgent, message.senderAgentID, BroadcastType.singleCast,
                //       MessagesContent.ReplyRulerNum, this.RulerAgent);
                //}
            }

            else if (message.MessageContent == MessagesContent.ReplyRulerNum)
            {
                if (message.DataMessageText != "-1")
                {
                    var repliedRuler = message.RulerPingReply;
                    if (repliedRuler != RulerAgent)
                    {
                        RulerAgent = repliedRuler;

                        _iStatus = 1;
                        _startPartialAdaptationTime = long.MaxValue;
                        _pingTime = -1;
                        MeasureAdaptingTime();
                    }
                }
            }
        }

        #endregion

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

        public override void UpdateOneMillisecond()
        {
            base.UpdateOneMillisecond();

            if (Config.OursExecutionMode)
            {
                if (Time.GlobalSimulationTime % 40 == 0)
                {
                    OursOnTimeEvent();
                }
            }
            else
            {
                if (Time.GlobalSimulationTime % 40 == 0)
                {
                    OnTimedEvent();
                }
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
                GL.Color3(100f, 0f, 125f);
            GL.PointSize(7);
            GL.Begin(PrimitiveType.Points);
            GL.Vertex2(p.X, p.Y);
            GL.End();
        }
    }
}