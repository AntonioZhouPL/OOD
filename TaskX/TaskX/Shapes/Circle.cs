using System;

namespace Shapes
{
    class Circle : IShape
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Radius { get; set; }

        public Circle(double x, double y, double radius)
        {
            X = x;
            Y = y;
            Radius = radius;
        }

        public void Scale(double factor)
        {
            Radius *= factor;
        }

        public void Translate(double dx, double dy)
        {
            X += dx;
            Y += dy;
        }

        public object Clone()
        {
            return new Circle(X, Y, Radius);
        }

        public override string ToString()
        {
            return $"({X}, {Y}), R = {Radius}";
        }

        public void Export()
        {
            Console.WriteLine($"\tExporting{Circle}: {shape.ToString()}");
        }

        public void Accept(IShape shape)
        {
            shape.Visit(this);
        }

    }
}