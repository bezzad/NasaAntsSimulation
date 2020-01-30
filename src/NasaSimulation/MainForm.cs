using System;
using System.ComponentModel;
using System.Threading;
using System.Windows.Forms;
using Simulation.Tools;
using Container = Simulation.Core.Container;

namespace Simulation
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            LowerBoarder = new Point();
            UpperBoarder = new Point();
            InitializeComponent();
        }


        private Container EnvironmentContainer { get; set; }
        private Gui AnimationController { get; set; }
        private Thread AnimationThread { get; set; }
        private Thread EnvironmentThread { get; set; }
        public Point LowerBoarder { get; set; }
        public Point UpperBoarder { get; set; }


        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            SetContainerSize();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            EnvironmentContainer = new Container(UpperBoarder, LowerBoarder);
            AnimationController = new Gui(EnvironmentContainer, guiOpenGLFrame);
        }


        private void BtnStartClick(object sender, EventArgs e)
        {
            SetContainerSize();

            if (EnvironmentThread?.IsAlive == true)
                return;

            if (radioButtonSH.Checked)
            {
                Program.ScenarioNum = 1;
            }

            if (checkBoxOurs.Checked)
            {
                Program.BOurMethod = false;
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

            Program.EndOfApplication = true;
            EnvironmentThread?.Abort();
            AnimationThread?.Abort();
        }

        private void CheckBoxOursCheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxOurs.Checked)
            {
                Program.OursExecutionMode = true;
            }
        }

        private void CheckBoxMultiOffCheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxMultiOff.Checked)
            {
                Program.MultiOff = true;
            }
        }

        private void SetContainerSize()
        {
            LowerBoarder.X = 0;
            LowerBoarder.Y = 0;
            UpperBoarder.X = (double)numWidth.Value;
            UpperBoarder.Y = (double)numHeight.Value;

            lblSize.Text = $@"{guiOpenGLFrame.Width}×{guiOpenGLFrame.Height}";
        }
    }
}
