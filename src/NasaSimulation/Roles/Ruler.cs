using System;
using System.Collections.Generic;

namespace Simulation.Roles
{
    
    public class Ruler:Role
    {
        public Agent RulerAgent { set; get; }
        public Area RulerArea { set; get; }
        public Container Container { set; get; }
        public List<Agent> LeaderList;
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
                leader.RulerAgent = this.RulerAgent;
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
            if (message.RecieverAgentId == RulerAgent.AgentId)
            {
                if (message.MessageContent == Program.MessagesContent.Ping)
                {
                    if (Program.OursExecutionMode)
                    {
                        ProcessMessage(message);
                        if (Status == 1)
                        {
                            //message.returnedStatus = 1;
                            var replyMessage = new Message();
                            replyMessage.MessageType = Program.BroadcastType.SingleCast;
                            replyMessage.RecieverAgentId = message.SenderAgentId;
                            replyMessage.ReciverAgent = message.SenderAgent;
                            replyMessage.SenderAgent = this.RulerAgent;
                            replyMessage.SenderAgentId = this.RulerAgent.AgentId;
                            replyMessage.CurrentSenderAgent = this.RulerAgent;
                            replyMessage.CurrentSenderAgentId = this.RulerAgent.AgentId;
                            replyMessage.MessageContent = Program.MessagesContent.PingReply;
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

                         
                            replyMessage.CurrentRecieverAgentId = messengerAgent.AgentId;
                            replyMessage.CurrentReciverAgent = messengerAgent;




                            Container.ContainerMedia.SendMessage(this.RulerAgent, replyMessage.Copy());
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
                            replyMessage.RecieverAgentId = message.SenderAgentId;
                            replyMessage.ReciverAgent = message.SenderAgent;
                            replyMessage.SenderAgent = this.RulerAgent;
                            replyMessage.SenderAgentId = this.RulerAgent.AgentId;
                            replyMessage.CurrentSenderAgent = this.RulerAgent;
                            replyMessage.CurrentSenderAgentId = this.RulerAgent.AgentId;
                            replyMessage.MessageContent = Program.MessagesContent.PingReply;
                            var messengerAgent = FindNearestMessenger(RulerAgent.GetPosition(), message.SenderAgent.GetPosition());
                            if (messengerAgent == null)
                            {

                                RadioRange += 50;
                                RulerAgent.RadioRange += 50;

                                GetandSendMessage(message);
                                return;
                            }


                            replyMessage.CurrentRecieverAgentId = messengerAgent.AgentId;
                            replyMessage.CurrentReciverAgent = messengerAgent;



                            Container.ContainerMedia.SendMessage(this.RulerAgent, replyMessage.Copy());
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
                        var replyMessage = new Message();
                        replyMessage.MessageType = Program.BroadcastType.SingleCast;
                        replyMessage.RecieverAgentId = message.SenderAgentId;
                        replyMessage.ReciverAgent = message.SenderAgent;
                        replyMessage.SenderAgent = this.RulerAgent;
                        replyMessage.SenderAgentId = this.RulerAgent.AgentId;
                        replyMessage.CurrentSenderAgent = this.RulerAgent;
                        replyMessage.CurrentSenderAgentId = this.RulerAgent.AgentId;
                        replyMessage.MessageContent = Program.MessagesContent.ReplyRulerNum;
                        replyMessage.RulerPingReply = this.RulerAgent;
                        if (message.ReciverAgent.AgentType == RolesName.Messenger)
                        {
                            if (CalculateDistance(this.RulerAgent.GetPosition().Position, replyMessage.ReciverAgent.GetPosition().Position) < this.RadioRange)
                            {
                                replyMessage.CurrentReciverAgent = replyMessage.ReciverAgent;
                                replyMessage.CurrentRecieverAgentId = replyMessage.RecieverAgentId;
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

                                replyMessage.CurrentRecieverAgentId = messengerAgent.AgentId;
                                replyMessage.CurrentReciverAgent = messengerAgent;
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

                            replyMessage.CurrentRecieverAgentId = messengerAgent.AgentId;
                            replyMessage.CurrentReciverAgent = messengerAgent;

                        }
                     



                        Container.ContainerMedia.SendMessage(replyMessage.SenderAgent, replyMessage.Copy());

                    }
                }
            }

        }

        internal void GetMessage(Message message)
        {
            if (message.RecieverAgentId == RulerAgent.AgentId)
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

            foreach (var mAgent in Container.MessangerList)
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
            double dest;

            var x = position.X - position2.X;
            var y = position.Y - position2.Y;
            x *= x;
            y *= y;
            dest = Math.Sqrt(x + y);
            return dest;
        }




    }
}
