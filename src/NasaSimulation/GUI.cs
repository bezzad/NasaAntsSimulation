using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using Simulation.Core;
using Simulation.Enums;
using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using Configuration = Simulation.Core.Configuration;
using Point = Simulation.Tools.Point;

namespace Simulation
{
    public class Gui
    {
        protected Configuration Config { get; }
        protected Container EnvironmentContainer { get; }
        protected GLControl GuiFrame { get; set; }
        protected IGraphicsContext GlControlContext { get; set; }
        protected double Padding { get; set; }

        public Gui(Configuration config, Container environmentContainer, GLControl frameControl)
        {
            Config = config;
            EnvironmentContainer = environmentContainer;
            GuiFrame = frameControl;
            Padding = 100;
        }

        private void InitialGui()
        {
            if (GuiFrame.InvokeRequired)
            {
                GuiFrame.Invoke(new MethodInvoker(InitialGui));
            }
            else
            {
                // Creates a 3.0-compatible GraphicsContext with 32bpp color, 24bpp depth
                // 8bpp stencil and 4x anti-aliasing.
                GlControlContext = new GraphicsContext(GraphicsMode.Default, GuiFrame.WindowInfo, 3, 0, GraphicsContextFlags.Default);
                GlControlContext.MakeCurrent(GuiFrame.WindowInfo);
                GL.ClearColor(Color.Black);
                GL.MatrixMode(MatrixMode.Projection);
                GL.LoadIdentity();
                GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit); // Clear the back buffer.
                GL.Ortho(Config.LowerBoarder.X - Padding, Config.UpperBoarder.X + Padding,
                    Config.LowerBoarder.Y - Padding, Config.UpperBoarder.Y + Padding,
                    0.0, 1.0);
                GL.Enable(EnableCap.DepthTest);
                GL.Hint(HintTarget.PerspectiveCorrectionHint, HintMode.Nicest);
                GL.DepthFunc(DepthFunction.Lequal);
                GL.ColorMaterial(MaterialFace.FrontAndBack, ColorMaterialParameter.AmbientAndDiffuse);
                GL.Enable(EnableCap.ColorMaterial);
                GL.Enable(EnableCap.Blend);
                GL.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);
                GL.Ext.BindFramebuffer(FramebufferTarget.FramebufferExt, 0); // render per default onto screen, not some FBO
            }
        }

        public void DrawMessenger(Point messengerCenter)
        {
            GL.Color3(0f, 255f, 0f);
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
            GL.Color3(0f, 255f, 255f);
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
            GL.Color3(255f, 0f, 0f);
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
            GL.Begin(PrimitiveType.LineLoop);

            for (var i = 0; i <= 300; i++)
            {
                var angle = 2 * Math.PI * i / 300;
                var x = radius * Math.Cos(angle) + orgCenter.X + Config.LowerBoarder.X;
                var y = radius * Math.Sin(angle) + orgCenter.Y + Config.LowerBoarder.Y;
                GL.Vertex2(x, y);
            }

            GL.End();
        }

        private void GuiDraw()
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit); // Clear the back buffer.
            if (GuiFrame.InvokeRequired)
            {
                GuiFrame.Invoke(new MethodInvoker(GuiDraw));
            }
            else
            {
                #region team

                foreach (var team in EnvironmentContainer.TeamList)
                {
                    GL.Color3(255f, 0f, 0f);
                    GL.PointSize(2);

                    DrawCircle(team.OrganizationBoundries.OrgCenter, team.OrganizationBoundries.Radius);

                    GL.Color3(125f, 125f, 0f);
                    GL.Begin(PrimitiveType.Points);

                    foreach (var agent in team.AgentsArray)
                    {
                        var tempAgentPosition = agent.Position;
                        GL.Vertex2(tempAgentPosition.Position.X, tempAgentPosition.Position.Y);
                    }

                    GL.End();
                    GL.Color3(0f, 0f, 125f);
                    GL.PointSize(5);
                    GL.Begin(PrimitiveType.Points);
                    GL.Vertex2(team.OrgLeader.Position.Position.X, team.OrgLeader.Position.Position.Y);
                    GL.End();
                }

                #endregion

                foreach (var messenger in EnvironmentContainer.MessengerList)
                {
                    DrawMessenger(messenger.Position.Position);
                }

                foreach (var ruler in EnvironmentContainer.RulerList)
                {
                    if (ruler.Status == State.Stable)
                        DrawRuler(ruler.Position.Position);
                    else
                    {
                        DrawDisabledRuler(ruler.Position.Position);
                    }
                }

                GL.Flush();
                GuiFrame.SwapBuffers();
            }
        }

        public void Run()
        {
            InitialGui();

            while (true)
            {
                if (Config.IsRunning && !Config.EndOfApplication)
                {
                    GuiDraw();
                }

                var t = 33;
                if (Config.HesitateValue > t) t = Config.HesitateValue;
                Thread.Sleep(t);

                if (Config.EndOfApplication)
                {
                    return;
                }
            }
        }
    }
}