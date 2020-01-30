using System;
using Simulation.Scenario;
using Simulation.Tools;

namespace Simulation.Core
{
    public class Configuration
    {
        public Configuration()
        {
            Rnd = new Random(DateTime.Now.Millisecond);
            LowerBoarder = new Point();
            UpperBoarder = new Point();
            MaxSpeed = 10;
            MaxRadioRange = 85;
            MaxMessengerRadioRange = 170;
            MsgDelay = 3;
        }


        public Random Rnd { get; }
        public Point LowerBoarder { get; set; }
        public Point UpperBoarder { get; set; }
        public int HesitateValue { get; set; } 
        public double MaxSpeed { get; set; }
        public bool RunGui { get; set; } 
        public bool EndOfApplication { get; set; }
        public IScenario SelectedScenario { get; set; }
        public bool BOurMethod { get; set; }
        public int StartMessageCount { get; set; }
        public bool OursExecutionMode { get; set; }
        public bool EndOfSimulation { get; set; }
        public bool MultiOff { get; set; }

        //agent parameter -------------------
        public double MaxRadioRange { get; set; } 
        public double MaxMessengerRadioRange { get; set; }
        public int MsgDelay { get; set; }
    }
}
