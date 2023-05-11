using System;

namespace Shapes
{
    class Rectangle : IShape
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }

        public Rectangle(double x, double y, double width, double height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        public void Scale(double factor)
        {
            Width *= factor;
            Height *= factor;
        }

        public void Translate(double dx, double dy)
        {
            X += dx;
            Y += dy;
        }

        public object Clone()
        {
            return new Rectangle(X, Y, Width, Height);
        }

        public override string ToString()
        {
            return $"({X}, {Y}), Width = {Width}, Height = {Height}";
        }

        public void Export()
        {
            Console.WriteLine($"\tExporting{Rectangle}: {shape.ToString()}");
        }

        //public void Accept(IShape shape)
        //{
        //    shape.Visit(this);
        //}
        
    }
}