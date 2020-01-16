using System;
using System.Threading;
using System.Windows.Forms;
using Nasa.ANTS.Simulation.Roles;
using Tao.OpenGl;
using Tao.Platform.Windows;

namespace Nasa.ANTS.Simulation
{
    public class Gui
    {
        private Random _r;
        private readonly Container _envirumentContainer;

        private SimpleOpenGlControl _guiFrame;
        //private int numOfAgent { set; get; }
        private int _numOfOrganization;
        private float _rColor;
        private float _gColor;
        private float _bColor;
        private double _xratio;
        private double _yratio;

        public Gui(Container envirumentContaniner)
        {
            _envirumentContainer = envirumentContaniner;

            //numOfOrganization = envirumentContainer.numOfAgents;
            // this.viewScreen = viewScreen;
            _xratio = _yratio = 0.5;
        }

        private void initialGui()
        {
            _r = Program.R;
            if (_guiFrame.InvokeRequired)
            {
                _guiFrame.Invoke(new MethodInvoker(delegate () { initialGui(); }));
            }
            else
            {
                Gl.glClearColor(0.0f, 0.0f, 0.0f, 0.0f);
                Gl.glMatrixMode(Gl.GL_PROJECTION);
                Gl.glLoadIdentity();
                Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
                Gl.glOrtho(Program.LowerBoarder.X - 50, Program.UpperBoarder.X + 50, Program.LowerBoarder.Y - 50, Program.UpperBoarder.Y + 50, 0.0, 1.0);
            }
        }

        public void DrawMessenger(Point messengerCenter)
        {
            Gl.glColor3f(0, 255, 0);
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


            Gl.glBegin(Gl.GL_LINES);
            Gl.glVertex2d(p3.X, p3.Y);
            Gl.glVertex2d(p1.X, p1.Y);
            Gl.glVertex2d(p1.X, p1.Y);
            Gl.glVertex2d(p2.X, p2.Y);
            Gl.glVertex2d(p2.X, p2.Y);
            Gl.glVertex2d(p3.X, p3.Y);
            Gl.glEnd();
            Gl.glBegin(Gl.GL_LINES);
            Gl.glVertex2d(messengerCenter.X, messengerCenter.Y);
            Gl.glVertex2d(messengerCenter.X, messengerCenter.Y - 20);
            Gl.glEnd();


            Gl.glBegin(Gl.GL_LINES);

            Gl.glVertex2d(p6.X, p6.Y);
            Gl.glVertex2d(p4.X, p4.Y);
            Gl.glVertex2d(p4.X, p4.Y);
            Gl.glVertex2d(p5.X, p5.Y);
            Gl.glVertex2d(p5.X, p5.Y);
            Gl.glVertex2d(p6.X, p6.Y);
            Gl.glEnd();
        }

        public void DrawRuler(Point rulerCenter)
        {
            Gl.glColor3f(0, 255, 255);
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





            Gl.glBegin(Gl.GL_POLYGON);


            Gl.glVertex2d(p1.X, p1.Y);
            Gl.glVertex2d(p2.X, p2.Y);
            Gl.glVertex2d(p3.X, p3.Y);



            Gl.glVertex2d(p4.X, p4.Y);

            Gl.glVertex2d(p5.X, p5.Y);
            Gl.glVertex2d(p6.X, p6.Y);

            Gl.glVertex2d(p1.X, p1.Y);



            Gl.glEnd();
            //Gl.glBegin(Gl.GL_LINES);
            //Gl.glVertex2d(messengerCenter.X, messengerCenter.Y);
            //Gl.glVertex2d(messengerCenter.X, messengerCenter.Y - 30);
            //Gl.glEnd();


        }

        public void DrawDisabledRuler(Point rulerCenter)
        {
            Gl.glColor3f(255, 0, 0);
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





            Gl.glBegin(Gl.GL_POLYGON);


            Gl.glVertex2d(p1.X, p1.Y);
            Gl.glVertex2d(p2.X, p2.Y);
            Gl.glVertex2d(p3.X, p3.Y);



            Gl.glVertex2d(p4.X, p4.Y);

            Gl.glVertex2d(p5.X, p5.Y);
            Gl.glVertex2d(p6.X, p6.Y);

            Gl.glVertex2d(p1.X, p1.Y);



            Gl.glEnd();
            //Gl.glBegin(Gl.GL_LINES);
            //Gl.glVertex2d(messengerCenter.X, messengerCenter.Y);
            //Gl.glVertex2d(messengerCenter.X, messengerCenter.Y - 30);
            //Gl.glEnd();


        }

        public void DrawCircle(Point orgCenter, double radious)
        {
            Gl.glBegin(Gl.GL_POINTS);
            for (double deg = 0; deg <= 360; deg += 0.4)
            {
                var x = radious * Math.Sin(deg) + orgCenter.X + Program.LowerBoarder.X;
                var y = radious * Math.Cos(deg) + orgCenter.Y + Program.LowerBoarder.Y;
                Gl.glVertex2d(x, y);
            }
            Gl.glEnd();


        }


        private void guiDraw()
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
            if (_guiFrame.InvokeRequired)
            {
                try
                {
                    //if (Program.endOfApplication) return;
                    _guiFrame.Invoke(new MethodInvoker(delegate () { guiDraw(); }));
                }
                catch
                {
                    // ignored
                }
            }
            else
            {
                #region team
                foreach (var team in _envirumentContainer.TeamList)
                {
                    Gl.glColor3f(255, 0, 0);
                    Gl.glPointSize(2);

                    DrawCircle(team.OrganizationBoundries.OrgCenter, team.OrganizationBoundries.Radious);





                    AgentPosition tempAgentPosition;
                    Gl.glColor3f(125, 125, 0);
                    Gl.glBegin(Gl.GL_POINTS);

                    foreach (var agent in team.AgentsArray)
                    {

                        tempAgentPosition = agent.getPosition();
                        Gl.glVertex2d(tempAgentPosition.Position.X, tempAgentPosition.Position.Y);

                    }
                    Gl.glEnd();
                    Gl.glColor3f(0, 0, 125);
                    Gl.glPointSize(5);
                    Gl.glBegin(Gl.GL_POINTS);
                    Gl.glVertex2d(team.OrgLeader.getPosition().Position.X, team.OrgLeader.getPosition().Position.Y);
                    Gl.glEnd();




                }
                #endregion

                foreach (var messenger in _envirumentContainer.MessangerList)
                {
                    DrawMessenger(messenger.getPosition().Position);


                }

                foreach (var rulerAgent in _envirumentContainer.RulerList)
                {
                    var ruler = (Ruler)rulerAgent.AgentRole;
                    if (ruler.IStatus == 1)
                        DrawRuler(rulerAgent.getPosition().Position);
                    else
                    {
                        DrawDisabledRuler(rulerAgent.getPosition().Position);
                    }
                }

                Gl.glFlush();
                _guiFrame.SwapBuffers();
            }
        }
        public void run()
        {
            _guiFrame = Program.GuiOpenGLcontrol;

            initialGui();


            while (true)
            {
                if (Program.RunGui && !Program.EndOfApplication)
                {
                    guiDraw();
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
