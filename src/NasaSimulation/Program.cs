using System;
using System.Windows.Forms;

namespace Simulation
{
    public static class Program
    {
        //------------------------my parameter --------------
        public static int HezitateValue = 0;
        public static OpenTK.GLControl GuiOpenGlControl;
        public static int MaxSpeed = 10;
        public static Form ActiveForm;
        public static Form GuiForm;
        public static bool RunGui = false;
        public static bool EndOfApplication = false;
        public static Random R = new Random(DateTime.Now.Millisecond);
        public static int ScenarioNum;
        public static double AvgRadius = 50;
        public static int MaxPingDelay = 7;
        public static bool BOurMethod;
        public static int StartMessageCount;
        public static int EndMessageCount;
        public static bool OursExecutionMode = false;
        public static bool EndOfSimulation = false;
        public static bool MultiOff = false;
        

        //agent parameter -------------------
        public static double MaxRadioRange = 85;
        public static double MaxMessengerRadioRange = 170;
        public static int LastAgentId;
        public static int MsgDelay = 3;
        
        
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ActiveForm = new MainForm();
            Application.Run(ActiveForm);
        }
    }
}
