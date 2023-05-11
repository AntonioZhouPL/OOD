using System;
using System.Collections.Generic;
using Shapes;

namespace lab4a_en
{
    class Program
    {
        static void Main(string[] args)
        {
            var square = new Square(0, 5, 2);
            var rectangle = new Rectangle(-1, -2, 14.5, 29);
            var circle = new Circle(10, 50, 0.5);
            var line = new Line(0.4, 0.5, 1, 1);

            var shapes = new List<IShape>() { square, rectangle, circle, line };

            
            Console.WriteLine($"Exporting via SvgExporter:");
            
            
            Console.WriteLine($"Exporting via JpegExporter:");
            


        }



    }

    

}
