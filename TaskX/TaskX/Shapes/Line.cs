using System;

namespace Shapes
{
    class Line : IShape
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double DX { get; set; }
        public double DY { get; set; }

        public Line(double x, double y, double dx, double dy)
        {
            X = x;
            Y = y;
            DX = dx;
            DY = dy;
        }

        public void Scale(double factor)
        {
            DX *= factor;
            DY *= factor;
        }

        public void Translate(double dx, double dy)
        {
            X += dx;
            Y += dy;
        }

        public object Clone()
        {
            return new Line(X, Y, DX, DY);
        }

        public override string ToString()
        {
            return $"({X}, {Y}), DX = {DX}, DY = {DY}";
        }

        public void Export()
        {
            Console.WriteLine($"\tExporting {Line}: {shape.ToString()}");
        }

    }
}