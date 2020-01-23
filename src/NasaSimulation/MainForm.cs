using System;
using System.Threading;
using System.Windows.Forms;
using Tao.OpenGl;
using Container = Simulation.Container;
using Point = Simulation.Point;


namespace Simulation
{
    public partial class MainForm : Form
    {
        private Container _envirumentContainer;
        private Gui _animationController;
        Thread _tanimation;
        Thread _tenvirument;
        int _clickFlag = 0;

        public MainForm()
        {
            InitializeComponent();
            //viewScreen = glControl1;
            var p1 = new Point();
            var p2 = new Point();
            p1 = Program.UpperBoarder;
            p2 = Program.LowerBoarder;



            _envirumentContainer = new Container(p1, p2);
            _animationController = new Gui(_envirumentContainer);




            guiOpenGLFrame.InitializeContexts();
            Program.GuiOpenGlControl = guiOpenGLFrame;


        }

        void Run()
        {
            //if (this.InvokeRequired)
            //{
            //   this.Invoke(new MethodInvoker(delegate() { animationController.RUN(); }));
            //}
            //else
            //{
            _animationController.Run();
            //}
        }


        private void button1_Click(object sender, EventArgs e)
        {

            if (_clickFlag == 1)
                return;



            _clickFlag = 1;

            if (radioButtonSH.Checked)
            {
                Program.ScenarioNum = 1;
            }

            if (checkBoxOurs.Checked)
            {
                Program.BOurMethod = false;
            }

            ///--------------------

            //GUIform gf = new GUIform(envirumentContainer);
            ///

            var ts = new ThreadStart(_envirumentContainer.Run);
            _tenvirument = new Thread(ts);

            _tenvirument.Start();

            _tanimation = new Thread(_animationController.Run);
            // animationController.RUN();
            _tanimation.Start();


            //gf.Show();
            // animationController.RUN();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }





        private void M()
        {
            Gl.glClearColor(0.0f, 0.0f, 0.0f, 0.0f);
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
            Gl.glOrtho(Program.LowerBoarder.X, Program.UpperBoarder.X, Program.LowerBoarder.Y, Program.UpperBoarder.Y, 0.0, 1.0);

            Gl.glColor3f(1.0f, 0.0f, 0.0f);
            Gl.glPointSize(100);
            Gl.glBegin(Gl.GL_POLYGON);
            Gl.glVertex2d(200, 200);
            Gl.glVertex2d(250, 200);
            Gl.glVertex2d(200, 250);
            Gl.glVertex2d(100, 300);

            Gl.glEnd();
            Gl.glFlush();
            guiOpenGLFrame.SwapBuffers();
        }

        private void guiOpenGLFrame_Load(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.EndOfApplication = true;
            _tenvirument.Abort();
            _tanimation.Abort();
        }


        private void Form1_Load_1(object sender, EventArgs e)
        {

        }



        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void checkBoxOurs_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxOurs.Checked == true)
            {
                Program.OursExecutionMode = true;
            }
        }

        private void checkBoxMultiOff_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxMultiOff.Checked)
            {
                Program.MultiOff = true;
            }
        }


    }
}
