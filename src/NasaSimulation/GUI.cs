﻿using System;
using System.Threading;
using System.Windows.Forms;
using Simulation.Enums;
using Simulation.Roles;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace Simulation
{
    public class Gui
    {
        private Container EnvironmentContainer { get; }
        private GLControl GuiFrame { get; set; }


        public Gui(Container environmentContainer)
        {
            EnvironmentContainer = environmentContainer;
        }

        private void InitialGui()
        {
            if (GuiFrame.InvokeRequired)
            {
                GuiFrame.Invoke(new MethodInvoker(InitialGui));
            }
            else
            {
                GL.ClearColor(0.0f, 0.0f, 0.0f, 0.0f);
                GL.MatrixMode(MatrixMode.Projection);
                GL.LoadIdentity();
                GL.Clear(ClearBufferMask.ColorBufferBit);
                GL.Ortho(EnvironmentContainer.LowerBoarder.X - 50, EnvironmentContainer.UpperBoarder.X + 50, EnvironmentContainer.LowerBoarder.Y - 50,
                    EnvironmentContainer.UpperBoarder.Y + 50, 0.0, 1.0);
            }
        }

        public void DrawMessenger(Point messengerCenter)
        {
            GL.Color3(0, 255, 0);
            var p1 = new Point();
            var p2 = new Point();
            var p3 = new Point();
            var p4 = new Point();
            var p5 = new Point();
            var p6 = new Point();

            p4.X = messengerCenter.X - 12;
            p4.Y = messengerCenter.Y + 8;
            p5.X = messengerCenter.X - 12;
            p5.Y = messengerCenter.Y - 8;
            p6.X = messengerCenter.X;
            p6.Y = messengerCenter.Y;

            p1.X = messengerCenter.X + 12;
            p1.Y = messengerCenter.Y + 8;
            p2.X = messengerCenter.X + 12;
            p2.Y = messengerCenter.Y - 8;
            p3.X = messengerCenter.X;
            p3.Y = messengerCenter.Y;

            GL.Begin(PrimitiveType.Lines);
            GL.Vertex2(p3.X, p3.Y);
            GL.Vertex2(p1.X, p1.Y);
            GL.Vertex2(p1.X, p1.Y);
            GL.Vertex2(p2.X, p2.Y);
            GL.Vertex2(p2.X, p2.Y);
            GL.Vertex2(p3.X, p3.Y);
            GL.End();
            GL.Begin(PrimitiveType.Lines);
            GL.Vertex2(messengerCenter.X, messengerCenter.Y);
            GL.Vertex2(messengerCenter.X, messengerCenter.Y - 20);
            GL.End();


            GL.Begin(PrimitiveType.Lines);

            GL.Vertex2(p6.X, p6.Y);
            GL.Vertex2(p4.X, p4.Y);
            GL.Vertex2(p4.X, p4.Y);
            GL.Vertex2(p5.X, p5.Y);
            GL.Vertex2(p5.X, p5.Y);
            GL.Vertex2(p6.X, p6.Y);
            GL.End();
        }

        public void DrawRuler(Point rulerCenter)
        {
            GL.Color3(0, 255, 255);
            var p1 = new Point();
            var p2 = new Point();
            var p3 = new Point();
            var p4 = new Point();
            var p5 = new Point();
            var p6 = new Point();

            p1.X = rulerCenter.X;
            p1.Y = rulerCenter.Y + 10;
            p2.X = rulerCenter.X + 10;
            p2.Y = rulerCenter.Y + 5;
            p3.X = rulerCenter.X + 10;
            p3.Y = rulerCenter.Y - 5;
            p4.X = rulerCenter.X;
            p4.Y = rulerCenter.Y - 10;

            p5.X = rulerCenter.X - 10;
            p5.Y = rulerCenter.Y - 5;
            p6.X = rulerCenter.X - 10;
            p6.Y = rulerCenter.Y + 5;

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

        public void DrawDisabledRuler(Point rulerCenter)
        {
            GL.Color3(255, 0, 0);
            var p1 = new Point();
            var p2 = new Point();
            var p3 = new Point();
            var p4 = new Point();
            var p5 = new Point();
            var p6 = new Point();

            p1.X = rulerCenter.X;
            p1.Y = rulerCenter.Y + 10;
            p2.X = rulerCenter.X + 10;
            p2.Y = rulerCenter.Y + 5;
            p3.X = rulerCenter.X + 10;
            p3.Y = rulerCenter.Y - 5;
            p4.X = rulerCenter.X;
            p4.Y = rulerCenter.Y - 10;

            p5.X = rulerCenter.X - 10;
            p5.Y = rulerCenter.Y - 5;
            p6.X = rulerCenter.X - 10;
            p6.Y = rulerCenter.Y + 5;

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

        public void DrawCircle(Point orgCenter, double radius)
        {
            GL.Begin(PrimitiveType.Points);
            for (double deg = 0; deg <= 360; deg += 0.4)
            {
                var x = radius * Math.Sin(deg) + orgCenter.X + EnvironmentContainer.LowerBoarder.X;
                var y = radius * Math.Cos(deg) + orgCenter.Y + EnvironmentContainer.LowerBoarder.Y;
                GL.Vertex2(x, y);
            }

            GL.End();


        }


        private void GuiDraw()
        {
            GL.Clear(ClearBufferMask.ColorBufferBit);
            if (GuiFrame.InvokeRequired)
            {
                try
                {
                    GuiFrame.Invoke(new MethodInvoker(GuiDraw));
                }
                catch
                {
                    // ignored
                }
            }
            else
            {
                #region team

                foreach (var team in EnvironmentContainer.TeamList)
                {
                    GL.Color3(255, 0, 0);
                    GL.PointSize(2);

                    DrawCircle(team.OrganizationBoundries.OrgCenter, team.OrganizationBoundries.Radius);

                    AgentPosition tempAgentPosition;
                    GL.Color3(125, 125, 0);
                    GL.Begin(PrimitiveType.Points);

                    foreach (var agent in team.AgentsArray)
                    {

                        tempAgentPosition = agent.GetPosition();
                        GL.Vertex2(tempAgentPosition.Position.X, tempAgentPosition.Position.Y);

                    }

                    GL.End();
                    GL.Color3(0, 0, 125);
                    GL.PointSize(5);
                    GL.Begin(PrimitiveType.Points);
                    GL.Vertex2(team.OrgLeader.GetPosition().Position.X, team.OrgLeader.GetPosition().Position.Y);
                    GL.End();




                }

                #endregion

                foreach (var messenger in EnvironmentContainer.MessengerList)
                {
                    DrawMessenger(messenger.GetPosition().Position);
                }

                foreach (var rulerAgent in EnvironmentContainer.RulerList)
                {
                    var ruler = (Ruler)rulerAgent.AgentRole;
                    if (ruler.Status == State.Stable)
                        DrawRuler(rulerAgent.GetPosition().Position);
                    else
                    {
                        DrawDisabledRuler(rulerAgent.GetPosition().Position);
                    }
                }

                GL.Flush();
                GuiFrame.SwapBuffers();
            }
        }

        public void Run()
        {
            GuiFrame = Program.GuiOpenGlControl;

            InitialGui();

            while (true)
            {
                if (Program.RunGui && !Program.EndOfApplication)
                {
                    GuiDraw();
                }

                var t = 33;
                if (Program.HezitateValue > t) t = Program.HezitateValue;
                Thread.Sleep(t);

                if (Program.EndOfApplication)
                {
                    return;
                }
            }
        }
    }
}