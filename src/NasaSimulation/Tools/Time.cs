namespace Simulation.Tools
{
    public static class Time
    {
        public static long GlobalSimulationTime { set; get; }
        public static long StartSimulationTime { set; get; }
        public static long EndSimulationTime { set; get; }
        public static long ConventionalAdaptingTime { set; get; }
        public static long ConventionalOptimizationTime { set; get; }
        public static long OursAdaptingTime { set; get; }
        public static long OursOptimizingTime { set; get; }

        public static long Tick()
        {
            GlobalSimulationTime += 1;
            return GlobalSimulationTime;
        }
    }
}
