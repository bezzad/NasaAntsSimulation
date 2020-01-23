using System;

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

        public double CalculateDistance(Point other)
        {
            var x = X - other.X;
            var y = Y - other.Y;
            var dest = Math.Sqrt(x * x + y * y);
            return dest;
        }
    }
}