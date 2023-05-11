using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1A_1
{
    public abstract class MainDish
    {
        public abstract string GetName();

        public abstract bool CheckIfGoesWellWithSideDish(SideDish sd);
    }

    public class Sushi : MainDish
    {
        public override bool CheckIfGoesWellWithSideDish(SideDish sd)
        {
            if (sd.GetName().Equals("Rice")) return true;
            return false;
        }

        public override string GetName()
        {
            return "Sushi";
        }
    }

    public class Schnitzel : MainDish
    {
        public override bool CheckIfGoesWellWithSideDish(SideDish sd)
        {
            if (sd.GetName().Equals("Beer") || sd.GetName().Equals("Fries")) return true;
            return false;
        }

        public override string GetName()
        {
            return "Schnitzel";
        }
    }

    public class Burger : MainDish
    {
        public override bool CheckIfGoesWellWithSideDish(SideDish sd)
        {
            if (sd.GetName().Equals("Fries")) return true;
            return false;
        }

        public override string GetName()
        {
            return "Burger";
        }
    }
}
