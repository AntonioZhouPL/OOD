using System;
using System.Collections.Generic;
using System.Linq;

namespace Smoke
{
    class Game
    {
        public string Name { get; set; }
        public string Genre { get; set; }
        public string[] Authors { get; set; }
        public List<Review> Reviews { get; set; }
        public List<Mod> Mods { get; set; }
        public string[] Devices { get; set; }

        public Game(string name, string genre, string[] authors, List<Review> reviews, List<Mod> mods, string[] devices)
        {
            Name = name;
            Genre = genre;
            Authors = authors;
            Reviews = reviews;
            Mods = mods;
            Devices = devices;
        }
    }

    class Review
    {
        public string Text { get; set; }
        public int Rating { get; set; }
        public string Author { get; set; }

        public Review(string text, int rating, string author)
        {
            Text = text;
            Rating = rating;
            Author = author;
        }

        public Review(string v1, string v2, string v3)
        {
        }
    }

    class Mod
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string[] Authors { get; set; }
        public int[] Compatibility { get; set; }

        public Mod(string name, string description, string[] authors, int[] compatibility)
        {
            Name = name;
            Description = description;
            Authors = authors;
            Compatibility = compatibility;
        }
    }

    class User
    {
        public string Nickname { get; set; }
        public int[] OwnedGames { get; set; }

        public User(string nickname, int[] ownedGames)
        {
            Nickname = nickname;
            OwnedGames = ownedGames;
        }
    }
    // You can test the Base representation from Here
    class Program
    {
        static void Main(string[] args)
        {

            Review review1 = new Review("I’m Commander Shepard and this is my favorite game on Smoke", 10, "Commander Shepard");
            Review review2 = new Review("The Moo remake sets a new standard for the future of the survival horror series⁠, even if it isn't the sequel I've been pining for.", 12, "Driver");
            Review review3 = new Review("Universe of Technology is a spectacular 4X game, that manages to shine even when the main campaign doesn't.", 15, "lemon");
            Review review5 = new Review("Moo’s interesting art design can't save it from its glitches, bugs, and myriad terrible game design decisions, but I love its sound design", 2, "Bonet");

            var game1 = new Game("Garbage Collector", "simulation", new string[] { }, new List<Review> { review1, review2 }, new List<Mod> { new Mod("Clouds", "Super clouds", new string[] { "Pek" }, new int[] { 2, 3, 4, 5 }) }, new string[] { "PC" });
            var game2 = new Game("Universe of Technology", "4X", new string[] { }, new List<Review> { new Review("Universe of Technology is a spectacular 4X game, that manages to shine even when the main campaign doesn't.", 15, "lemon") }, new List<Mod> { new Mod("Clouds", "Super clouds", new string[] { "Pek" }, new int[] { 2, 3, 4, 5 }), new Mod("Commander Shepard", "I’m Commander Shepard and this is my favorite mod on Smoke", new string[] { "Commander Shepard" }, new int[] { 1, 2, 4 }) }, new string[] { "bitnix" });
            var game3 = new Game("Moo", "rogue-like", new string[] { "Driver" }, new List<Review> { new Review("The Moo remake sets a new standard for the future of the survival horror series⁠, even if it isn't the sequel I've been pining for.", 12, "Driver"), new Review("Moo’s interesting art design can't save it from its glitches, bugs, and myriad terrible game design decisions, but I love its sound design", 2, "Bonet") }, new List<Mod> { new Mod("Clouds", "Super clouds", new string[] { "Pek" }, new int[] { 2, 3, 4, 5 }), new Mod("T-pose", "Cow are now T-posing", new string[] { "Rondo" }, new int[] { 1, 3 }), new Mod("Commander Shepard", "I’m Commander Shepard and this is my favorite mod on Smoke", new string[] { "Commander Shepard" }, new int[] { 1, 2, 4 }) }, new string[] { "bitstation" });
            var game4 = new Game("Tickets Please", "platformer", new string[] { "Szredor" }, new List<Review> { new Review("I’m Commander Shepard and this is my favorite game on Smoke", 10, "Commander Shepard") }, new List<Mod> { new Mod("Clouds", "Super clouds", new string[] { "Pek" }, new int[] { 1, 3, 4 }), new Mod("Commander Shepard", "I’m Commander Shepard and this is my favorite mod on Smoke", new string[] { "Commander Shepard" }, new int[] { 1, 2, 4 }), new Mod("BTM", "You can now play in BTM’s trains and bytebuses", new string[] { "lemon, Bonet" }, new int[] { 1, 3 }) }, new string[] { "bitbox" });
            var game5 = new Game("Cosmic", "MOBA", new string[] { "MLG" }, new List<Review> { new Review("I've played this game for years nonstop. Over 8k hours logged (not even joking). And I'm gonna tell you: at this point, the game's just not worth playing anymore. I think it hasn't been worth playing for a year or two now, but I'm only just starting to realize it. It breaks my heart to say that, but that's just the truth of the matter.", 5, "Szredor") }, new List<Mod> { new Mod("Clouds", "Super clouds", new string[] { "Pek" }, new int[] { 2, 3, 4, 5 }), new Mod("Cosmic - black hole edition", "Adds REALISTIC black holes", new string[] { "Driver" }, new int[] { 1 }) }, new string[] { "platform" });

            // Add objects to data dictionary
            var data = new Dictionary<string, List<object>>();
            var games = new List<object> { game1, game2, game3, game4, game5 };
            var reviews = new List<object> { review1, review2, review3, review5 };
            //var Game = new List<object> { };
            data.Add("games", games);
            data.Add("reviews", reviews);
            //data.Add("Game", Game);

            // List commands
            string input = "";
            while (!data.ContainsKey(input))
            {
                Console.WriteLine("list: (Type 'list' to see available types): ");
                input = Console.ReadLine();

                if (input == "list")
                {
                    var listCommand = new ListCommand("", true);
                    listCommand.Execute(data);
                    input = "";
                }
                else
                {
                    var listCommand = new ListCommand(input);
                    listCommand.Execute(data);
                }
            }

            //Find commands
            string input1 = "";
            string input2 = "";
            string input3 = "";
            string input4 = "";

            while (!data.ContainsKey(input4))
            {
                Console.WriteLine("find: (Type 'find' to see available types): ");
                input4 = Console.ReadLine();

                if (input4 == "find")
                {
                    Console.WriteLine(" games\n reviews\n Game\n");
                }

                else if(input4 == "games")
                {
                    Console.WriteLine("Type the type of games you want to find: ");
                    input1 = Console.ReadLine();
                    Console.WriteLine("Type the Operation: ");
                    input2 = Console.ReadLine();
                    Console.WriteLine("Type the name or number of the type");
                    input3 = Console.ReadLine();

                    var Requirements1 = new List<Requirement> { new Requirement(input1, input2, input3) };
                    var findGamesCommand = new FindCommand("games", Requirements1);
                    findGamesCommand.Execute(data);
                }
                else if (input4 == "reviews")
                {
                    Console.WriteLine("Type the type of reviews you want to find: ");
                    input1 = Console.ReadLine();
                    Console.WriteLine("Type the Operation: ");
                    input2 = Console.ReadLine();
                    Console.WriteLine("Type the name or number of the type");
                    input3 = Console.ReadLine();

                    var Requirements1 = new List<Requirement> { new Requirement(input1, input2, input3) };
                    var findGamesCommand = new FindCommand("reviews", Requirements1);
                    findGamesCommand.Execute(data);
                }

            }
            //var requirements1 = new List<Requirement> { new Requirement("Genre", "==", "4X") };
            //var findGames4XCommand = new FindCommand("games", requirements1);

            //var requirements2 = new List<Requirement> { new Requirement("Name", "==", "Moo") };
            //var findGamesMooCommand = new FindCommand("games", requirements2);

            //var requirements3 = new List<Requirement> { new Requirement("Rating", "<", "3") };
            //var findReviewsCommand3 = new FindCommand("reviews", requirements3);


            var ExitGamesCommand = new ExitCommand();
            //var findGamesCommand = new FindCommand("games", new List<string> {"MOBA"});

            // Execute commands


            //Console.WriteLine("Finding games whose Genre is 4X:");
            //findGames4XCommand.Execute(data);

            //Console.WriteLine("Finding games whose Name is Moo:");
            //findGamesMooCommand.Execute(data);

            //Console.WriteLine("Finding games whose Reviews < 3:");
            //findReviewsCommand3.Execute(data);


            //Add Command
            string input5 = "";
            while (!data.ContainsKey(input5))
            {
                Console.WriteLine("Add: (Type 'Add' to see available types): ");
                input5 = Console.ReadLine();

                if (input5 == "Add")
                {
                    Console.WriteLine(" NewGame\n");
                }
                else if (input5 == "NewGame")
                {
                    var NewGame = new List<object>();
                    data.Add("NewGame", NewGame);

                    var addCommand = new AddCommand("NewGame", "base");
                    var SecondCommand = new AddCommand("NewGame", "Secondary");
                    addCommand.Execute(data);
                    SecondCommand.Execute(data);


                    var listGameCommand = new ListCommand("NewGame");
                    listGameCommand.Execute(data);                                
                }               
            }

            string input6 = "";
            while (!data.ContainsKey(input6))
            {
                Console.WriteLine("Exit: (Type 'Exit' to Exit the program or stay in output): ");
                input6 = Console.ReadLine();

                if (input6 == "Exit") 
                {
                    ExitGamesCommand.Execute(data); 
                }
                else
                {
                    Console.WriteLine("Stay in output and check the commands above");
                }
            }

        }

    }
}
