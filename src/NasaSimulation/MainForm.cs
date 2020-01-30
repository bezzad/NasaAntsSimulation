using OpenTK.Graphics.OpenGL;
using Simulation.Core;
using Simulation.Scenario;
using Simulation.Tools;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
using Container = Simulation.Core.Container;

namespace Simulation
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            Config = new Configuration();
            InitializeComponent();
        }


        private Container EnvironmentContainer { get; set; }
        private Gui AnimationController { get; set; }
        private Thread AnimationThread { get; set; }
        private Thread EnvironmentThread { get; set; }
        protected System.Timers.Timer UiUpdater { get; set; }
        protected Configuration Config { get; set; }


        protected void RefreshInfo()
        {
            try
            {
                if (InvokeRequired)
                {
                    Invoke(new MethodInvoker(RefreshInfo));
                    return;
                }

                SetConfiguration();
                lblAdapting.Text = Time.ConventionalAdaptingTime.ToString();
                lblOptimizing.Text = (EnvironmentContainer.ContainerMedia.MessageCount - Config.StartMessageCount).ToString();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
        }

        private void BtnStopClick(object sender, EventArgs e)
        {
            EnvironmentThread?.Abort();
            AnimationThread?.Abort();
            UiUpdater?.Stop();
            RefreshInfo();
        }

        private void BtnStartClick(object sender, EventArgs e)
        {
            if (EnvironmentThread?.IsAlive == true)
                return;

            SetConfiguration();
            Config.SelectedScenario = new SelfHealingScenario1(Config);
            EnvironmentContainer = new Container(Config);
            AnimationController = new Gui(Config, EnvironmentContainer, guiOpenGLFrame);

            var ts = new ThreadStart(EnvironmentContainer.Run);
            EnvironmentThread = new Thread(ts) { IsBackground = true };
            EnvironmentThread.Start();

            AnimationThread = new Thread(AnimationController.Run) { IsBackground = true };
            AnimationThread.Start();

            //
            // create an timer to update UI form information like labels and size
            UiUpdater = new System.Timers.Timer(1000) { AutoReset = true };
            UiUpdater.Elapsed += delegate { RefreshInfo(); };
            UiUpdater.Start();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);

            Config.EndOfApplication = true;
            UiUpdater?.Stop();
            EnvironmentThread?.Abort();
            AnimationThread?.Abort();
        }

        private void SetConfiguration()
        {
            Config.SelectedScenario = new SelfHealingScenario1(Config); // radioButtonSH.Checked
            Config.LowerBoarder.X = 0;
            Config.LowerBoarder.Y = 0;
            Config.UpperBoarder.X = Width - settingPanel.Width;
            Config.UpperBoarder.Y = Height;
            Config.RulersCount = (int)numRulersCount.Value;
            Config.MessengersCount = (int)numMessengersCount.Value;
            Config.TeamsCount = (int)numTeamsCount.Value;
            Config.WorkersCount = (int)numWorkersCount.Value;
            Config.MaxMessengerRadioRange = (double)numMaxMessengersRadioRange.Value;
            Config.MaxRadioRange = (double)numMaxRadioRange.Value;
            Config.MaxSpeed = (double)numSpeed.Value;
            Config.OursExecutionMode = checkBoxOurs.Checked;
            Config.MultiOff = checkBoxMultiOff.Checked;

            var expandoRatio = Config.TeamsCount / 4;
            var oneTeamArea = 4 * Config.TeamOrganizationRadius * Config.TeamOrganizationRadius; //Math.Pow(Config.TeamOrganizationRadius, 2) * Math.PI;
            if ((Config.TeamsCount + expandoRatio) * oneTeamArea >= Config.UpperBoarder.X * Config.UpperBoarder.Y)
            {
                Debug.WriteLine("This number of teams, can not fill in this environment. Fix autonomic...");
                var aspectRatio = Config.UpperBoarder.Y / Config.UpperBoarder.X;
                Config.UpperBoarder.X = Math.Ceiling(Math.Sqrt(oneTeamArea * (Config.TeamsCount + expandoRatio) / aspectRatio));
                Config.UpperBoarder.Y = Config.UpperBoarder.X * aspectRatio;
            }

            Text = $@"NASA ANTS Simulation by OpenGL    |   Environment Size:{guiOpenGLFrame.Size}";

            //if (Config.IsRunning)  GL.Viewport((int)Config.LowerBoarder.X, (int)Config.LowerBoarder.Y, (int)Config.UpperBoarder.X *2/ 3, (int)Config.UpperBoarder.Y*2/3);
        }

    }
}
