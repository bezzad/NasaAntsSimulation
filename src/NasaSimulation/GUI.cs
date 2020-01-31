using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using Simulation.Core;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using Configuration = Simulation.Core.Configuration;

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
                    team.Draw();

                    foreach (var worker in team.AgentsArray)
                        worker.Draw();

                    foreach (var leader in team.LeadersHistory)
                        leader.Draw();
                }

                #endregion

                foreach (var messenger in EnvironmentContainer.MessengerList)
                    messenger.Draw();
                foreach (var ruler in EnvironmentContainer.RulerList)
                    ruler.Draw();

                GL.Flush();
                GuiFrame.SwapBuffers();
            }
        }

        public void Run()
        {
            InitialGui();

            while (Config.IsRunning)
            {
                GuiDraw();

                var t = 33;
                if (Config.HesitateValue > t) t = Config.HesitateValue;
                Thread.Sleep(t);

                if (Config.EndOfApplication)
                    Config.IsRunning = false;
            }
        }
    }
}