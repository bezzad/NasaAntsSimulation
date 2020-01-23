using System;
using System.ComponentModel;
using System.Threading;
using System.Windows.Forms;

namespace Simulation
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            
            EnvironmentContainer = new Container(Program.UpperBoarder, Program.LowerBoarder);
            AnimationController = new Gui(EnvironmentContainer);

            guiOpenGLFrame.InitializeContexts();
            Program.GuiOpenGlControl = guiOpenGLFrame;
        }


        private Container EnvironmentContainer { get; }
        private Gui AnimationController { get; }
        private Thread AnimationThread { get; set; }
        private Thread EnvironmentThread { get; set; }
        private int ClickFlag { get; set; }


        void Run()
        {
            AnimationController.Run();
        }

        private void BtnStartClick(object sender, EventArgs e)
        {
            if (ClickFlag == 1)
                return;

            ClickFlag = 1;

            if (radioButtonSH.Checked)
            {
                Program.ScenarioNum = 1;
            }

            if (checkBoxOurs.Checked)
            {
                Program.BOurMethod = false;
            }

            var ts = new ThreadStart(EnvironmentContainer.Run);
            EnvironmentThread = new Thread(ts);
            EnvironmentThread.Start();

            AnimationThread = new Thread(AnimationController.Run);
            AnimationThread.Start();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);

            Program.EndOfApplication = true;
            EnvironmentThread.Abort();
            AnimationThread.Abort();
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
    }
}
