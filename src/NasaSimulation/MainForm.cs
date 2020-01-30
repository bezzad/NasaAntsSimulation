using System;
using System.ComponentModel;
using System.Threading;
using System.Windows.Forms;
using Simulation.Core;
using Simulation.Scenario;
using Simulation.Tools;
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
        protected Configuration Config { get; set; }


        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            SetContainerSize();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            EnvironmentContainer = new Container(Config);
            AnimationController = new Gui(Config, EnvironmentContainer, guiOpenGLFrame);

            var timer = new System.Timers.Timer(1000) { AutoReset = true };
            timer.Elapsed += delegate { Invoke(new MethodInvoker(RefreshInfo)); };
            timer.Start();
        }

        protected void RefreshInfo()
        {
            lblAdapting.Text = Time.ConventionalAdaptingTime.ToString();
            lblOptimizing.Text = (EnvironmentContainer.ContainerMedia.MessageCount - Config.StartMessageCount).ToString();
        }

        private void BtnStartClick(object sender, EventArgs e)
        {
            SetContainerSize();

            if (EnvironmentThread?.IsAlive == true)
                return;

            if (radioButtonSH.Checked)
            {
                Config.SelectedScenario = new SelfHealingScenario1();
            }

            if (checkBoxOurs.Checked)
            {
                Config.BOurMethod = false;
            }

            var ts = new ThreadStart(EnvironmentContainer.Run);
            EnvironmentThread = new Thread(ts) { IsBackground = true };
            EnvironmentThread.Start();

            AnimationThread = new Thread(AnimationController.Run) { IsBackground = true };
            AnimationThread.Start();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);

            Config.EndOfApplication = true;
            EnvironmentThread?.Abort();
            AnimationThread?.Abort();
        }

        private void CheckBoxOursCheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxOurs.Checked)
            {
                Config.OursExecutionMode = true;
            }
        }

        private void CheckBoxMultiOffCheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxMultiOff.Checked)
            {
                Config.MultiOff = true;
            }
        }

        private void SetContainerSize()
        {
            Config.LowerBoarder.X = 0;
            Config.LowerBoarder.Y = 0;
            Config.UpperBoarder.X = (double)numWidth.Value;
            Config.UpperBoarder.Y = (double)numHeight.Value;

            lblSize.Text = $@"{guiOpenGLFrame.Width}×{guiOpenGLFrame.Height}";
        }
    }
}
