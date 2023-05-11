using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vectors
{
    class Program
    {
        static void PrintVector(IAgregate vector)
        {
            Iterator it = vector.GetIterator();
            double value;
            Console.WriteLine($"Vector values: ");
            for (; !it.IsDone; it.Next())
            {
                value = it.GetValue;
                Console.Write($"{value} ");
            }
            //Console.WriteLine("");
        }

        static bool AllNonNegative(IAgregate vector)
        {
            Iterator it = vector.GetIterator();
            double value;
            for (; !it.IsDone; it.Next())
            {
                value = it.GetValue;
                if (value < 0) return false;
            }
            return true;
        }

        static double Sum(IAgregate vector)
        {
            Iterator it = vector.GetIterator();
            double value,sum=0;
            for (; !it.IsDone; it.Next())
            {
                value = it.GetValue;
                sum += value;
            }
            return sum;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Sparse 1");
            VectorSparse vs1 = new VectorSparse(5);
            vs1.AddValue(3, 6);
            vs1.AddValue(2, -1);
            PrintVector(vs1);
            Console.WriteLine("\nAll non-negative: " + AllNonNegative(vs1));
            Console.WriteLine("Sum: " + Sum(vs1));

            Console.WriteLine("Sparse 1");
            VectorSparse vs2 = new VectorSparse(5);
            vs2.AddValue(3, 6);
            vs2.AddValue(1, 2);
            PrintVector(vs2);
            Console.WriteLine("\nAll non-negative: " + AllNonNegative(vs2));
            Console.WriteLine("Sum: " + Sum(vs2));

            Console.WriteLine("VectorList 1");
            VectorList vl1 = new VectorList(new int[] { 0, -1, 2, 5, 6, 0 });
            PrintVector(vl1);
            Console.WriteLine("\nAll non-negative: " + AllNonNegative(vl1));
            Console.WriteLine("Sum: " + Sum(vl1));

            Console.WriteLine("VectorList 2");
            VectorList vl2 = new VectorList(new int[] { 0, 3, 2, 5, 6, 0 });
            PrintVector(vl2);
            Console.WriteLine("\nAll non-negative: " + AllNonNegative(vl2));
            Console.WriteLine("Sum: " + Sum(vl2));

            Console.WriteLine("VectorOneElement 1");
            VectorOneElement voe1 = new VectorOneElement(5, 3, -6);
            PrintVector(voe1);
            Console.WriteLine("\nAll non-negative: " + AllNonNegative(voe1));
            Console.WriteLine("Sum: " + Sum(voe1));

            Console.WriteLine("VectorOneElement 2");
            VectorOneElement voe2 = new VectorOneElement(5, 3, 6);
            PrintVector(voe2);
            Console.WriteLine("\nAll non-negative: " + AllNonNegative(voe2));
            Console.WriteLine("Sum: " + Sum(voe2));

        }
    }
}
