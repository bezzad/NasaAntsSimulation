﻿using System;
using Simulation.Roles;
using Simulation.Tools;

namespace Simulation
{
    public class Agent
    {
        readonly Random _random;
        private AgentPosition Position { get; }
        private Container Container { get; }
        public string AgentId { set; get; }
        public object AgentRole { get; set; }
        public double RadioRange { set; get; }
        public Role.RolesName AgentType { set; get; }
        private OrganizationBoundries TeamBoundary { get; }
        private Point UpperBoarder { set; get; }
        private Point LowerBoarder { set; get; }


        public Agent(AgentPosition position, string id, Role.RolesName agentRoleType, OrganizationBoundries orgBoundary, Container cont)
        {
            Container = cont;
            Position = position;
            AgentId = id;
            _random = Program.R;
            TeamBoundary = orgBoundary;

            AgentType = agentRoleType;
            Role temptRole;

            switch (AgentType)
            {
                case Role.RolesName.Worker:
                    AgentRole = new Worker(Container, this);
                    temptRole = (Role)AgentRole;
                    temptRole.RadioRange = Program.MaxRadioRange;
                    AgentRole = temptRole;
                    RadioRange = temptRole.RadioRange;
                    break;
                case Role.RolesName.Leader:
                    AgentRole = new Leader(this, Container);
                    temptRole = (Role)AgentRole;
                    temptRole.RadioRange = Program.MaxRadioRange;
                    AgentRole = temptRole;
                    RadioRange = temptRole.RadioRange;
                    break;
            }
        }
        public Agent(AgentPosition position, string id, Role.RolesName agentRoleType, Area agentArea, Container container)
        {
            Position = position;
            AgentId = id;
            Container = container;
            _random = Program.R;
            AgentType = agentRoleType;
            UpperBoarder = container.UpperBoarder;
            LowerBoarder = container.LowerBoarder;
            var temptRole = new Role();
            switch (AgentType)
            {
                case Role.RolesName.Messenger:
                    AgentRole = new Messenger(this, container, agentArea);
                    temptRole = (Role)AgentRole;
                    temptRole.RadioRange = Program.MaxMessengerRadioRange;
                    AgentRole = temptRole;
                    RadioRange = temptRole.RadioRange;
                    break;
                case Role.RolesName.Ruler:
                    AgentRole = new Ruler(agentArea, container, this);
                    temptRole = (Role)AgentRole;
                    temptRole.RadioRange = Program.MaxRadioRange;
                    AgentRole = temptRole;
                    RadioRange = temptRole.RadioRange;
                    break;
            }
        }
        


        public void UpdateOneMillisecond()
        {
            Movement();

            if (AgentType == Role.RolesName.Leader)
            {
                if (Program.OursExecutionMode)
                {
                    var leader = (Leader)AgentRole;
                    if (Time.GlobalSimulationTime % 40 == 0)
                    {
                        leader.OursOnTimeEvent();
                    }
                }
                else
                {
                    var leader = (Leader)AgentRole;
                    if (Time.GlobalSimulationTime % 40 == 0)
                    {
                        leader.OnTimedEvent();
                    }
                }
            }


        }
        public void FreeUpdateOneMillisecond()
        {
            if (AgentType == Role.RolesName.Messenger)
            {
                if (Program.OursExecutionMode)
                {
                    var messenger = (Messenger)AgentRole;
                    if (Time.GlobalSimulationTime % 50 == 0 && Time.GlobalSimulationTime > 100)
                    {
                        messenger.OnTimedEvent();
                    }
                }
            }
            FreeMovement();
        }
        public AgentPosition GetPosition()
        {
            var p = new AgentPosition();
            p = Position;
            return p;
        }
        private int Movement()
        {
            Position.Position.X += Position.Velocity.X / 1500;

            Position.Position.Y += Position.Velocity.Y / 1500;

            if (Position.Position.CalculateDistance(TeamBoundary.OrgCenter) > TeamBoundary.Radius)
            {
                Position.Position.X = TeamBoundary.OrgCenter.X;
                Position.Position.Y = TeamBoundary.OrgCenter.Y;
            }

            if (Time.GlobalSimulationTime > 1000 & Time.GlobalSimulationTime % 1000 == 0)
            {
                UpdateVelocity(Position);
            }
            return 0;
        }
        private int FreeMovement()
        {
            Position.Position.X += Position.Velocity.X / 1500;

            Position.Position.Y += Position.Velocity.Y / 1500;
            
            if (AgentType == Role.RolesName.Messenger)
            {
                var tempMessenger = (Messenger)AgentRole;

                var x = (double)_random.Next((int)tempMessenger.MessengerArea.MinX, (int)tempMessenger.MessengerArea.MaxX);
                var y = (double)_random.Next((int)tempMessenger.MessengerArea.MinY, (int)tempMessenger.MessengerArea.MaxY);
                if (Position.Position.X > tempMessenger.MessengerArea.MaxX) Position.Position.X = x;
                if (Position.Position.X < tempMessenger.MessengerArea.MinX) Position.Position.X = x;
                if (Position.Position.Y > tempMessenger.MessengerArea.MaxY) Position.Position.Y = y;
                if (Position.Position.Y < tempMessenger.MessengerArea.MinY) Position.Position.Y = y;
            }



            else if (AgentType == Role.RolesName.Ruler)
            {
                var tempRuler = (Ruler)AgentRole;

                var x = (double)_random.Next((int)tempRuler.RulerArea.MinX, (int)tempRuler.RulerArea.MaxX);
                var y = (double)_random.Next((int)tempRuler.RulerArea.MinY, (int)tempRuler.RulerArea.MaxY);
                if (Position.Position.X > tempRuler.RulerArea.MaxX) Position.Position.X = x;
                if (Position.Position.X < tempRuler.RulerArea.MinX) Position.Position.X = x;
                if (Position.Position.Y > tempRuler.RulerArea.MaxY) Position.Position.Y = y;
                if (Position.Position.Y < tempRuler.RulerArea.MinY) Position.Position.Y = y;
            }

            else
            {
                if (Position.Position.X > (UpperBoarder.X - LowerBoarder.X)) Position.Position.X = 0;
                if (Position.Position.X < 0) Position.Position.X = (UpperBoarder.X + LowerBoarder.X);
                if (Position.Position.Y > (UpperBoarder.Y - LowerBoarder.Y)) Position.Position.Y = 0;
                if (Position.Position.Y < 0) Position.Position.Y = (UpperBoarder.Y + LowerBoarder.Y);
            }

            if (Time.GlobalSimulationTime > 1000 & Time.GlobalSimulationTime % 1000 == 0)
            {
                UpdateVelocity(Position);
            }
            return 0;
        }
        private void UpdateVelocity(AgentPosition position)
        {
            var t1 = _random.NextDouble();
            t1 = (t1 - 0.5) * 2;
            var t2 = _random.NextDouble();
            t2 = (t2 - 0.5) * 2;
            
            if ((position.Velocity.X * position.Velocity.X) + (position.Velocity.Y * position.Velocity.Y) > (Program.MaxSpeed * Program.MaxSpeed))
            {
                position.Velocity.X /= 2;
                position.Velocity.Y /= 2;
            }

            position.Velocity.X += t1;
            position.Velocity.Y += t2;
        }
    }
}
