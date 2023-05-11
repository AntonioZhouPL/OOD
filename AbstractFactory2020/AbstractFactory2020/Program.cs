using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1A;
namespace Lab1A_1
{
    class Program
    {

        static void Main(string[] args)
        {
            //ToDo: implementation
            Restaurant polish = new PolishRestaurant();
            Restaurant japanese = new JapaneseRestaurant();
            Restaurant american = new AmericanRestaurant();
            
            //    var input = "Japanese";
            Console.WriteLine("Input the type of the dish: ");

            string input = Console.ReadLine();

            if (input == "Exit")
                Console.WriteLine("sddsa");

                if (input == "Japanese")
                {
                    japanese.PrintMenu();
                }

                if (input == "Polish")
                {
                    polish.PrintMenu();
                }

                if (input == "American")
                {
                    american.PrintMenu();
                }

                if (input == "Mixed1")
                {
                    PrintMenu(japanese.mainDish(), american.sideDish(), polish.dessert());
                }
                
                if (input == "Mixed2")
                {
                    PrintMenu(polish.mainDish(), japanese.sideDish(), american.dessert());
                }
                
                if (input == "Mixed3")
                {
                    PrintMenu(polish.mainDish(), american.sideDish(), polish.dessert());
                }
            
        }

        public static void PrintMenu(MainDish mainDish, SideDish sideDish, Dessert dessert)
        {
            Console.WriteLine("Menu for today:");
            Console.WriteLine("Main Dish: " + mainDish.GetName());
            Console.WriteLine("Side Dish: " + sideDish.GetName());
            Console.WriteLine("Dessert: " + dessert.GetName() + ". Only " + dessert.GetCalories() + " calories");
            if (mainDish.CheckIfGoesWellWithSideDish(sideDish))
                Console.WriteLine("Satisfaction : guaranteed");
        }
    }
}
