using System;
using System.Collections.Generic;

namespace Nasa.ANTS.Simulation.Roles
{
    
    public class Ruler:Role
    {
        public Agent RulerAgent { set; get; }
        public Area RulerArea { set; get; }
        public Container Container { set; get; }
        public List<Agent> LeaderList;
        // 1 is OK, 0 is Failed
        public int IStatus { set; get; }


        public Ruler(Area area, Container cont, Agent agent)
        {
            RulerArea = area;
            Container = cont;
            RulerAgent = agent;
            LeaderList = InitialLeaderList();
            foreach(Agent leaderAgent in LeaderList)
            {
                Leader leader = (Leader)leaderAgent.AgentRole;
                leader.RulerAgent = this.RulerAgent;
                leaderAgent.AgentRole = leader;
            }

            IStatus = 1;

        }



        private List<Agent> InitialLeaderList()
        {
            List<Team> tempTeamList = FindTeamsInArea();
            List<Agent> tempLeaderList = new List<Agent>();
            foreach (Team team in tempTeamList)
            {
                tempLeaderList.Add(team.OrgLeader);

            }

            return tempLeaderList;
        }

        private List<Team> FindTeamsInArea()
        {
            List<Team> tempTeamList = new List<Team>();
            foreach (Team team in Container.TeamList)
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
                        if (IStatus == 1)
                        {
                            //message.returnedStatus = 1;
                            Message replyMessage = new Message();
                            replyMessage.MessageType = Program.BroadcastType.SingleCast;
                            replyMessage.RecieverAgentId = message.SenderAgentId;
                            replyMessage.ReciverAgent = message.SenderAgent;
                            replyMessage.SenderAgent = this.RulerAgent;
                            replyMessage.SenderAgentId = this.RulerAgent.AgentId;
                            replyMessage.CurrentSenderAgent = this.RulerAgent;
                            replyMessage.CurrentSenderAgentId = this.RulerAgent.AgentId;
                            replyMessage.MessageContent = Program.MessagesContent.PingReply;
                            Agent messengerAgent = message.CurrentSenderAgent;

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




                            Container.ContainerMedia.sendMessage(this.RulerAgent, replyMessage.Copy());
                        }

                        else
                        {
                            int x = 0;
                            // message.returnedStatus = 0;
                        }
                    }
                    else
                    {
                        ProcessMessage(message);
                        if (IStatus == 1)
                        {
                            //message.returnedStatus = 1;
                            Message replyMessage = new Message();
                            replyMessage.MessageType = Program.BroadcastType.SingleCast;
                            replyMessage.RecieverAgentId = message.SenderAgentId;
                            replyMessage.ReciverAgent = message.SenderAgent;
                            replyMessage.SenderAgent = this.RulerAgent;
                            replyMessage.SenderAgentId = this.RulerAgent.AgentId;
                            replyMessage.CurrentSenderAgent = this.RulerAgent;
                            replyMessage.CurrentSenderAgentId = this.RulerAgent.AgentId;
                            replyMessage.MessageContent = Program.MessagesContent.PingReply;
                            Agent messengerAgent = FindNearestMessenger(RulerAgent.getPosition(), message.SenderAgent.getPosition());
                            if (messengerAgent == null)
                            {

                                RadioRange += 50;
                                RulerAgent.RadioRange += 50;

                                GetandSendMessage(message);
                                return;
                            }


                            replyMessage.CurrentRecieverAgentId = messengerAgent.AgentId;
                            replyMessage.CurrentReciverAgent = messengerAgent;



                            Container.ContainerMedia.sendMessage(this.RulerAgent, replyMessage.Copy());
                        }

                        else
                        {
                            int x = 0;
                            // message.returnedStatus = 0;
                        }
                    }


                }
                else if (Program.OursExecutionMode && message.MessageContent == Program.MessagesContent.LostRuler)
                {
                    if (IStatus == 1)
                    {
                        Message replyMessage = new Message();
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
                            if (calculateDistance(this.RulerAgent.getPosition().Position, replyMessage.ReciverAgent.getPosition().Position) < this.RadioRange)
                            {
                                replyMessage.CurrentReciverAgent = replyMessage.ReciverAgent;
                                replyMessage.CurrentRecieverAgentId = replyMessage.RecieverAgentId;
                            }
                            else
                            {
                                Agent messengerAgent = FindNearestMessenger(RulerAgent.getPosition(), message.SenderAgent.getPosition());
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
                            Agent messengerAgent = FindNearestMessenger(RulerAgent.getPosition(), message.SenderAgent.getPosition());
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
                     



                        Container.ContainerMedia.sendMessage(replyMessage.SenderAgent, replyMessage.Copy());

                    }
                }
            }

        }

        internal void getMessage(Message message)
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
            List<double> testList = new List<double>();

            //foreach (Agent mAgent in container.MessangerList)
            //{
            //    //Role temptRole = (Role)mAgent.agentRole;
            //    testList.Add(calculateDistance(agentPosition.Position, mAgent.getPosition().Position));
                
            //}

            foreach (Agent mAgent in Container.MessangerList)
            {
                //Role temptRole = (Role)mAgent.agentRole;
                if (calculateDistance(agentPosition.Position, mAgent.getPosition().Position) <= RadioRange && calculateDistance(agentPosition.Position, mAgent.getPosition().Position) + calculateDistance(destPosition.Position, mAgent.getPosition().Position) < minDist)
                {
                    minDist = calculateDistance(agentPosition.Position, mAgent.getPosition().Position) + calculateDistance(destPosition.Position, mAgent.getPosition().Position);
                    nAgent = mAgent;
                }
            }
            return nAgent;
        }

        public double calculateDistance(Point position, Point position2)
        {
            double dest;

            double x = position.X - position2.X;
            double y = position.Y - position2.Y;
            x *= x;
            y *= y;
            dest = Math.Sqrt(x + y);
            return dest;
        }




    }
}
