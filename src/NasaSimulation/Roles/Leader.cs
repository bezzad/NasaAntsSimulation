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
        protected OrganizationBoundries TeamBoundary { get; }


        //0 is corrupted 1 is OK and 2 is under ruler correction
        int _iStatus = 1;
        long _pingTime = -1;
        long _startPartialAdaptationTime = long.MaxValue;


        public Leader(Configuration config, AgentPosition pos, string id,
            OrganizationBoundries orgBoundary, Container cont)
            : base(config, pos, id, cont)
        {
            TeamBoundary = orgBoundary;
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
                SendMessage(this, this, RulerAgent, RulerAgent.AgentId, BroadcastType.SendReceive,
                    MessagesContent.Ping, "");
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

        private void SendMessage(Agent senderAgent,
            Agent currentSenderAgent,
            Agent receiverAgent,
            string receiverId,
            BroadcastType messageType,
            MessagesContent messageContent,
            Ruler rulerAgent)
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

            var messengerAgent = FindNearestMessenger(Position, receiverAgent.Position);

            message.RulerPingReply = rulerAgent;
            if (messengerAgent == null)
            {
                RadioRange += 50;
                SendMessage(senderAgent, currentSenderAgent, receiverAgent, receiverId, messageType, messageContent,
                    rulerAgent);
                return;

            }

            message.CurrentReceiverAgent = messengerAgent;
            message.CurrentReceiverAgentId = messengerAgent.AgentId;

            Container.ContainerMedia.SendMessage(this, message.Copy());
        }

        private void SendMessage(Agent senderAgent,
            Agent currentSenderAgent,
            Agent receiverAgent,
            string receiverId,
            BroadcastType messageType,
            MessagesContent messageContent, string messageTextData)
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

            var messengerAgent = FindNearestMessenger(Position, receiverAgent.Position);
            message.DataMessageText = messageTextData;
            if (messengerAgent == null)
            {
                RadioRange += 50;
                SendMessage(senderAgent, currentSenderAgent, receiverAgent, receiverId, messageType, messageContent,
                    messageTextData);
                return;

            }

            message.CurrentReceiverAgent = messengerAgent;
            message.CurrentReceiverAgentId = messengerAgent.AgentId;

            Container.ContainerMedia.SendMessage(this, message.Copy());
        }

        private void SendBroadcastMessage(Agent senderAgent, Agent currentSenderAgent,
            BroadcastType messageType,
            MessagesContent messageContent, int iBroadcastNum)
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

            Container.ContainerMedia.SendMessage(this, message.Copy());
        }

        public Agent FindNearestMessenger(AgentPosition agentPosition, AgentPosition destPosition)
        {
            double minDist = 10000;
            Agent nAgent = null;
            foreach (var mAgent in Container.MessengerList)
            {
                //Role temptRole = (Role)mAgent.agentRole;
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

        public Agent FindNearestMessenger(AgentPosition agentPosition)
        {
            double minDist = 10000;
            Agent nAgent = null;
            foreach (var mAgent in Container.MessengerList)
            {
                if (agentPosition.Position.CalculateDistance(mAgent.Position.Position) <= RadioRange &&
                    agentPosition.Position.CalculateDistance(mAgent.Position.Position) < minDist)
                {
                    minDist = agentPosition.Position.CalculateDistance(mAgent.Position.Position);
                    nAgent = mAgent;
                }
            }

            return nAgent;
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
                    SendMessage(this,
                        this,
                        message.SenderAgent,
                        message.SenderAgentId,
                        BroadcastType.SingleCast,
                        MessagesContent.ReplyRulerNum,
                        "-1");
                }
                else
                {
                    SendMessage(this,
                        this,
                        message.SenderAgent,
                        message.SenderAgentId,
                        BroadcastType.SingleCast,
                        MessagesContent.ReplyRulerNum,
                        RulerAgent);
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

        internal void GetMessage(Message message)
        {
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
                SendMessage(this,
                    this,
                    RulerAgent,
                    RulerAgent.AgentId,
                    BroadcastType.SendReceive,
                    MessagesContent.Ping, "");
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
            GL.Color3(100f, 0f, 125f);
            GL.PointSize(7);
            GL.Begin(PrimitiveType.Points);
            GL.Vertex2(p.X, p.Y);
            GL.End();
        }
    }
}