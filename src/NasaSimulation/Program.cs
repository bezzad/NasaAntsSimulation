using System;
using System.Windows.Forms;
using Tao.Platform.Windows;
using ThesisSimulation;

namespace Nasa.ANTS.Simulation
{
    public static class Program
    {
        //------------------------my parameter --------------
        public static int HezitateValue = 0;
        public static SimpleOpenGlControl GuiOpenGLcontrol;
        public static int Maxspeed = 10;
        public static Form ActiveForm;
        public static Form GuiForm;
        public static bool RunGui = false;
        public static bool EndOfApplication = false;
        public static Random R = new Random(DateTime.Now.Millisecond);
        public static Point LowerBoarder = new Point();
        public static Point UpperBoarder = new Point();
        public static int ScenarioNum;
        public static double AvgRadious = 50;
        public static int MaxPingDelay = 7;
        public enum Scenario { Scenario1, Scenario2, Scenario3, Scenario4, Scenario5 };
        public static bool BOurMethod;
        public static int StartMessageCount;
        public static int EndMessageCount;
        public static bool OursExecutionMode = false;
        public static bool EndOfSimulation = false;
        public static bool MultiOff = false;



        public enum BroadcastType
        {
            Broadcast, MessengerBroadcast, MessengerToMessengersBroadcast,
            MessengersToRulersBroadcast, MessengerToLeaderBroadcast, MessengerToWorkersBroadcast, SingleCast,
            MessengerToLeadersAndMessengersBroadcast,
            SendRecieve
        }

        public enum MessagesContent { UnavailableReciever, LostRuler, ReplyRulerNum, Ping, PingReply }


        //agent parameter -------------------
        public static double Maxradiorange = 85;
        public static double MaxMessengerRadioRange = 170;
        public static int ILastAgentId;
        public static int Msgdelay = 3;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            setparameter();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ActiveForm = new Form1();
            Application.Run(ActiveForm);
        }

        private static void setparameter()
        {
            LowerBoarder.X = 0;
            LowerBoarder.Y = 0;
            UpperBoarder.X = 1000;
            UpperBoarder.Y = 1000;
        }
    }
}
