using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1A_1
{
    public abstract class Dessert
    {
        public abstract int GetCalories();
        public abstract string GetName();
    }

    public class Dango : Dessert
    {
        public override int GetCalories()
        {
            return 50;
        }

        public override string GetName()
        {
            return "Dango";
        }
    }

    public class IceCream : Dessert
    {
        public override int GetCalories()
        {
            return 100;
        }

        public override string GetName()
        {
            return "Ice Cream";
        }
    }

    public class Shake : Dessert
    {
        public override int GetCalories()
        {
            return 200;
        }

        public override string GetName()
        {
            return "Shake";
        }
    }
}
