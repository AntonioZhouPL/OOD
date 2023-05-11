using System;

namespace Shapes
{
    class Cube : IShape
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public Cube(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public void Scale(double factor)
        {
            Z *= factor;
        }

        public void Translate(double dx, double dy)
        {
            X += dx;
            Y += dy;
        }

        public object Clone()
        {
            return new Cube(X, Y, Z);
        }

        public override string ToString()
        {
            return $"({X}, {Y}), Z = {Z}";
        }


        public void Export()
        {
            Console.WriteLine($"\tExporting{Cube}: {shape.ToString()}");
        }

        public void Accept(IShape shape)
        {
            shape.Visit(this);
        }

    }




}