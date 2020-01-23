namespace Simulation
{
    public class Point
    {
        public Point() { }

        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        public double X { set; get; }
        public double Y { set; get; }
    }
}