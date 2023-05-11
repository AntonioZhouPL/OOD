using System;

namespace Shapes
{
    interface IShape : ICloneable
    {
        void Scale(double factor);
        void Translate(double dx, double dy);
        new object Clone();
        string ToString();
        void Export();
    }   

    public interface Ishape
    {
        void Visit(Circle circle);
        void Visit(Cube cube);
        void Visit(Line line);
        void Visit(Rectangle rectangle);
        void Visit(Square square);

    }
}

