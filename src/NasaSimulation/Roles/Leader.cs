using System.Windows.Forms;
using Simulation.Enums;

namespace Simulation.Roles
{
    public class Leader : Role
    {
        readonly Agent _leaderAgent;
        readonly Container _container;
        public Agent RulerAgent { set; get; }

        //0 is corrupted 1 is OK and 2 is under ruler correction
        int _iStatus = 1;
        long _pingTime = -1;
        long _startPartialAdaptationTime = long.MaxValue;


        public Leader(Agent agent, Container cont)
        {
            _leaderAgent = agent;
            _container = cont;
        }

        public void OnTimedEvent()
        {
            if (_pingTime != -1 && Time.GlobalSimulationTime - _pingTime > 100 && _iStatus == 3)
            {
                if (Program.BOurMethod == false)
                {
                    _iStatus = 2;
                    _startPartialAdaptationTime = Time.GlobalSimulationTime;
                    SendBroadcastMessage(_leaderAgent, _leaderAgent, BroadcastType.MessengerToLeaderBroadcast,
                        Program.MessagesContent.LostRuler, 1);
                }
            }


            else if (RulerAgent != null && _iStatus == 1)
            {
                _pingTime = Time.GlobalSimulationTime;
                SendMessage(_leaderAgent, _leaderAgent, RulerAgent, RulerAgent.AgentId, BroadcastType.SendReceive,
                         Program.MessagesContent.Ping, "");
                _iStatus = 3;
            }

            else if (_iStatus == 2 && Time.GlobalSimulationTime - _startPartialAdaptationTime > 200)
            {
                if (Program.MultiOff)
                {
                    Program.EndOfSimulation = true;
                    UpdateTimeLabel("MVal");
                    UpdateMessageLabel("MVal");

                }
                _startPartialAdaptationTime = Time.GlobalSimulationTime;
                SendBroadcastMessage(_leaderAgent, _leaderAgent,
                    BroadcastType.MessengerToLeaderBroadcast,
                        Program.MessagesContent.LostRuler, 2);
            }

        }

        private void SendMessage(Agent senderAgent,
            Agent currentSenderAgent,
            Agent receiverAgent,
            string receiverId,
            BroadcastType messageType,
            Program.MessagesContent messageContent,
            Agent rulerAgent)
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

            var messengerAgent = FindNearestMessenger(_leaderAgent.GetPosition(), receiverAgent.GetPosition());

            message.RulerPingReply = rulerAgent;
            if (messengerAgent == null)
            {
                RadioRange += 50;
                _leaderAgent.RadioRange += 50;
                SendMessage(senderAgent, currentSenderAgent, receiverAgent, receiverId, messageType, messageContent, rulerAgent);
                return;

            }
            message.CurrentReceiverAgent = messengerAgent;
            message.CurrentReceiverAgentId = messengerAgent.AgentId;

            _container.ContainerMedia.SendMessage(_leaderAgent, message.Copy());
        }

        private void SendMessage(Agent senderAgent,
            Agent currentSenderAgent,
            Agent receiverAgent,
            string receiverId,
            BroadcastType messageType,
            Program.MessagesContent messageContent, string messageTextData)
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

            var messengerAgent = FindNearestMessenger(_leaderAgent.GetPosition(), receiverAgent.GetPosition());
            message.DataMessageText = messageTextData;
            if (messengerAgent == null)
            {
                RadioRange += 50;
                _leaderAgent.RadioRange += 50;
                SendMessage(senderAgent, currentSenderAgent, receiverAgent, receiverId, messageType, messageContent, messageTextData);
                return;

            }
            message.CurrentReceiverAgent = messengerAgent;
            message.CurrentReceiverAgentId = messengerAgent.AgentId;

            _container.ContainerMedia.SendMessage(_leaderAgent, message.Copy());
        }

        private void SendBroadcastMessage(Agent senderAgent, Agent currentSenderAgent,
            BroadcastType messageType,
            Program.MessagesContent messageContent, int iBroadcastNum)
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
            var messengerAgent = FindNearestMessenger(_leaderAgent.GetPosition());
            if (messengerAgent == null)
            {
                RadioRange += 50;
                _leaderAgent.RadioRange += 50;
                SendBroadcastMessage(senderAgent, currentSenderAgent, messageType, messageContent, iBroadcastNum);
                return;
            }

            message.CurrentReceiverAgent = messengerAgent;
            message.CurrentReceiverAgentId = messengerAgent.AgentId;

            _container.ContainerMedia.SendMessage(_leaderAgent, message.Copy());
        }

        public Agent FindNearestMessenger(AgentPosition agentPosition, AgentPosition destPosition)
        {
            double minDist = 10000;
            Agent nAgent = null;
            foreach (var mAgent in _container.MessengerList)
            {
                //Role temptRole = (Role)mAgent.agentRole;
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
        public Agent FindNearestMessenger(AgentPosition agentPosition)
        {
            double minDist = 10000;
            Agent nAgent = null;
            foreach (var mAgent in _container.MessengerList)
            {
                if (agentPosition.Position.CalculateDistance(mAgent.GetPosition().Position) <= RadioRange &&
                    agentPosition.Position.CalculateDistance(mAgent.GetPosition().Position) < minDist)
                {
                    minDist = agentPosition.Position.CalculateDistance(mAgent.GetPosition().Position);
                    nAgent = mAgent;
                }
            }
            return nAgent;
        }

        public void ProcessMessage(Message message)
        {
            if (message.MessageContent == Program.MessagesContent.PingReply)
            {
                _pingTime = -1;
                _iStatus = 1;
            }
            //LostRuler
            else if (message.MessageContent == Program.MessagesContent.LostRuler)
            {
                if (_iStatus == 0 || _iStatus == 2)
                {
                    SendMessage(_leaderAgent,
                        _leaderAgent,
                        message.SenderAgent,
                        message.SenderAgentId,
                        BroadcastType.SingleCast,
                        Program.MessagesContent.ReplyRulerNum,
                        "-1");
                }
                else
                {
                    SendMessage(_leaderAgent,
                        _leaderAgent,
                        message.SenderAgent,
                        message.SenderAgentId,
                        BroadcastType.SingleCast,
                        Program.MessagesContent.ReplyRulerNum,
                        RulerAgent);
                }
            }
            else if (message.MessageContent == Program.MessagesContent.ReplyRulerNum)
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
            if (Program.EndOfSimulation)
            {
                return;
            }
            var f = (MainForm)Program.ActiveForm;
            if (f.InvokeRequired)
            {
                f.Invoke(new MethodInvoker(MeasureAdaptingTime));
            }
            else
            {
                Time.ConventionalAdaptingTime = Time.GlobalSimulationTime - Time.StartSimulationTime;
                f.labelAdapting.Text = Time.ConventionalAdaptingTime.ToString();
                f.lableOptimizing.Text = (_container.ContainerMedia.MessageCount - Program.StartMessageCount).ToString();
                Program.EndOfSimulation = true;
            }
        }

        internal void GetMessage(Message message)
        {
            if (message.ReceiverAgentId == _leaderAgent.AgentId)
            {
                if (Program.OursExecutionMode)
                {
                    OursProcessMessage(message);
                }
                else
                {
                    ProcessMessage(message);
                }
            }
        }

        internal void UpdateTimeLabel(string labelTxt)
        {
            var f = (MainForm)Program.ActiveForm;
            if (f.InvokeRequired)
            {
                f.Invoke(new MethodInvoker(delegate { UpdateTimeLabel(labelTxt); }));
            }
            else
            {
                f.labelAdapting.Text = labelTxt;
            }
        }

        internal void UpdateMessageLabel(string labelTxt)
        {
            var f = (MainForm)Program.ActiveForm;
            if (f.InvokeRequired)
            {
                f.Invoke(new MethodInvoker(delegate { UpdateMessageLabel(labelTxt); }));
            }
            else
            {
                f.lableOptimizing.Text = labelTxt;
            }
        }

        #region Ours

        public void OursOnTimeEvent()
        {
            if (RulerAgent != null && _iStatus == 1)
            {
                _pingTime = Time.GlobalSimulationTime;
                SendMessage(_leaderAgent,
                    _leaderAgent,
                    RulerAgent,
                    RulerAgent.AgentId,
                    BroadcastType.SendReceive,
                    Program.MessagesContent.Ping, "");
                _iStatus = 3;
            }
        }

        private void OursProcessMessage(Message message)
        {
            if (message.MessageContent == Program.MessagesContent.PingReply)
            {
                _pingTime = -1;
                _iStatus = 1;
            }
            else if (message.MessageContent == Program.MessagesContent.LostRuler)
            {
                //if (iStatus == 0 || iStatus == 2)
                //{
                //    SendMessage(this.leaderAgent, this.leaderAgent, message.senderAgent, message.senderAgentID, BroadcastType.singleCast,
                //        Program.MessagesContent.ReplyRulerNum, "-1");
                //}
                //else
                //{
                //    SendMessage(this.leaderAgent, this.leaderAgent, message.senderAgent, message.senderAgentID, BroadcastType.singleCast,
                //       Program.MessagesContent.ReplyRulerNum, this.RulerAgent);
                //}
            }

            else if (message.MessageContent == Program.MessagesContent.ReplyRulerNum)
            {
                if (message.DataMessageText != "-1")
                {
                    var repliedRuler = message.RulerPingReply;
                    if (repliedRuler != RulerAgent)
                    {
                        RulerAgent = repliedRuler;

                        _iStatus = 1;
                        _startPartialAdaptationTime = 9223372036854775807;
                        _pingTime = -1;
                        MeasureAdaptingTime();
                    }
                }
            }
        }

        #endregion
    }
}