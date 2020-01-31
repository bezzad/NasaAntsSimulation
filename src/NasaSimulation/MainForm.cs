using Simulation.Core;
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
            SetButtonsEnable(false);
        }


        private FaultGenerator FaultGenerator { get; set; }
        private Container EnvironmentContainer { get; set; }
        private Gui AnimationController { get; set; }
        private Thread AnimationThread { get; set; }
        private Thread EnvironmentThread { get; set; }
        private System.Timers.Timer UiUpdater { get; set; }
        private Configuration Config { get; }


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
            
            SetButtonsEnable(false);
        }

        private void BtnStartClick(object sender, EventArgs e)
        {
            if (EnvironmentThread?.IsAlive == true)
                return;

            SetButtonsEnable(true);
            SetConfiguration();
            Time.OursAdaptingTime = 0;
            Time.EndSimulationTime = 0;
            Time.StartSimulationTime = 0;
            Time.ConventionalAdaptingTime = 0;
            Time.GlobalSimulationTime = 0;
            Time.OursOptimizingTime = 0;
            Config.StartMessageCount = 0;

            EnvironmentContainer = new Container(Config);
            AnimationController = new Gui(Config, EnvironmentContainer, guiOpenGLFrame);
            FaultGenerator = new FaultGenerator(Config, EnvironmentContainer);

            var ts = new ThreadStart(EnvironmentContainer.Run);
            EnvironmentThread = new Thread(ts) { IsBackground = true, Priority = ThreadPriority.Highest };
            EnvironmentThread.Start();

            AnimationThread = new Thread(AnimationController.Run) { IsBackground = true, Priority = ThreadPriority.AboveNormal };
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

            var maxOneTeamLength = 4 * Config.TeamOrganizationRadius; // Square width is 4R
            var xSquaresCount = Math.Floor(Config.UpperBoarder.X / maxOneTeamLength);
            var ySquaresCount = Math.Floor(Config.UpperBoarder.Y / maxOneTeamLength);

            var oneTeamArea = maxOneTeamLength * maxOneTeamLength;
            var aspectRatio = ySquaresCount / xSquaresCount;

            if (Config.TeamsCount * oneTeamArea >= xSquaresCount * ySquaresCount)
            {
                Config.UpperBoarder.X = Math.Ceiling(Math.Sqrt(oneTeamArea * Config.TeamsCount / aspectRatio));
                Config.UpperBoarder.Y = Config.UpperBoarder.X * aspectRatio;
            }

            Text = $@"NASA ANTS Simulation by OpenGL    |   Environment Size:{guiOpenGLFrame.Size}";
        }

        private void BtnMessengerFailureClick(object sender, EventArgs e)
        {
            FaultGenerator.MessengerFailure();
        }

        private void BtnRulerFailureClick(object sender, EventArgs e)
        {
            FaultGenerator.RulerFailure();
        }

        private void BtnLeaderFailureClick(object sender, EventArgs e)
        {
            FaultGenerator.LeaderFailure();
        }

        private void BtnWorkerFailureClick(object sender, EventArgs e)
        {
            FaultGenerator.WorkerFailure();
        }

        private void SetButtonsEnable(bool enable)
        {
            btnLeaderFailure.Enabled = enable;
            btnWorkerFailure.Enabled = enable;
            btnMessengerFailure.Enabled = enable;
            btnRulerFailure.Enabled = enable;
            btnStart.Enabled = !enable;
            btnStop.Enabled = enable;
        }
    }
}
