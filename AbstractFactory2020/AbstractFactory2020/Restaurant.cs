using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lab1A_1;
using System.Threading.Tasks;

namespace _1A
{
    public abstract class Restaurant
    {
        public abstract MainDish mainDish();
        public abstract SideDish sideDish();
        public abstract Dessert dessert();
        public void PrintMenu()
        {
            Program.PrintMenu(mainDish(), sideDish(), dessert());
        }
    }

    public class PolishRestaurant : Restaurant
    {
        public override MainDish mainDish() { return new Schnitzel(); }
        public override SideDish sideDish() { return new Beer(); }
        public override Dessert dessert() { return new IceCream(); }
    }

    public class JapaneseRestaurant : Restaurant
    {
        public override MainDish mainDish() { return new Sushi(); }
        public override SideDish sideDish() { return new Rice(); }
        public override Dessert dessert() { return new Dango(); }
    }

    public class AmericanRestaurant : Restaurant
    {
        public override MainDish mainDish() { return new Burger(); }
        public override SideDish sideDish() { return new Fries(); }
        public override Dessert dessert() { return new Shake(); }
    }







}
