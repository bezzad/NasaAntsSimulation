namespace Simulation
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

        public static long OneSecTick()
        {
            GlobalSimulationTime += 1000;
            return GlobalSimulationTime;
        }
        public static long Tick()
        {
            GlobalSimulationTime += 1;
            return GlobalSimulationTime;
        }
    }

    public class Point
    {
        public double X { set; get; }
        public double Y { set; get; }
    }

    public class Area
    {
        public double MinX { set; get; }
        public double MinY { set; get; }
        public double MaxX { set; get; }
        public double MaxY { set; get; }
    }

    public class OrganizationBoundries
    {
        public Point OrgCenter { get; set; }
        public double Radius { get; set; }
    }

    public class AgentPosition
    {
        public Point Position = new Point();
        public Point Velocity = new Point();
    }

    public class AgentEvent
    {
        public int AgentId;
        public Point Position = new Point();
        public double Velocity;
    }

    public class ForbidenArea
    {
        public double Range;
        Point _position;
    }
}
