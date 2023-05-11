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

            var games = new Hashmap<Game>(10);

            Game game1 = new Game("Garbage Collector", "simulation", new string[] { }, new List<Review> { }, new List<Mod> { new Mod("Clouds", "Super clouds", new string[] { "Pek" }, new int[] { 2, 3, 4, 5 }) }, new string[] { "PC" });
            Game game2 = new Game("Universe of Technology", "4X", new string[] { }, new List<Review> { new Review("Universe of Technology is a spectacular 4X game, that manages to shine even when the main campaign doesn't.", 15, "lemon") }, new List<Mod> { new Mod("Clouds", "Super clouds", new string[] { "Pek" }, new int[] { 2, 3, 4, 5 }), new Mod("Commander Shepard", "I’m Commander Shepard and this is my favorite mod on Smoke", new string[] { "Commander Shepard" }, new int[] { 1, 2, 4 }) }, new string[] { "bitnix" });
            Game game3 = new Game("Moo", "rogue-like", new string[] { "Driver" }, new List<Review> { new Review("The Moo remake sets a new standard for the future of the survival horror series⁠, even if it isn't the sequel I've been pining for.", 12, "Driver"), new Review("Moo’s interesting art design can't save it from its glitches, bugs, and myriad terrible game design decisions, but I love its sound design", 2, "Bonet") }, new List<Mod> { new Mod("Clouds", "Super clouds", new string[] { "Pek" }, new int[] { 2, 3, 4, 5 }), new Mod("T-pose", "Cow are now T-posing", new string[] { "Rondo" }, new int[] { 1, 3 }), new Mod("Commander Shepard", "I’m Commander Shepard and this is my favorite mod on Smoke", new string[] { "Commander Shepard" }, new int[] { 1, 2, 4 }) }, new string[] { "bitstation" });

            Review review1 = new Review("I’m Commander Shepard and this is my favorite game on Smoke", 10, "Commander Shepard");


            User user1 = new User("Szredor", new int[] { 1, 2, 3, 4, 5 });
            // Inserting games into hashmap
            games.pushFront(game1);
            games.Insert(game2);
            games.pushBack(game3);

            // Creating forward iterator for games
            var gameIterator = games.CreateIterator();
            Console.WriteLine("Forward Iterator Printing");
            Console.WriteLine("Game");
            while (gameIterator.HasNext())
            {
                var game = gameIterator.Next();
                Console.WriteLine($"Name: {game.Name}");
                Console.WriteLine($"Genre: {game.Genre}");
                Console.WriteLine($"Authors: {string.Join(", ", game.Authors)}");
                Console.WriteLine($"Reviews: {game.Reviews.Count}");
                Console.WriteLine($"Mods: {game.Mods.Count}");
                Console.WriteLine($"Devices: {string.Join(", ", game.Devices)}");
                Console.WriteLine("\n");
            }
            Console.WriteLine("---------------------------------------");
            // Creating reverse iterator for games
            var reverseGameIterator = games.CreateReverseIterator();
            Console.WriteLine("Reverse Iterator Printing");
            Console.WriteLine("Game");
            while (reverseGameIterator.HasNext())
            {
                var game = reverseGameIterator.Next();
                Console.WriteLine($"Name: {game.Name}");
                Console.WriteLine($"Genre: {game.Genre}");
                Console.WriteLine($"Authors: {string.Join(", ", game.Authors)}");
                Console.WriteLine($"Reviews: {game.Reviews.Count}");
                Console.WriteLine($"Mods: {game.Mods.Count}");
                Console.WriteLine($"Devices: {string.Join(", ", game.Devices)}");
                Console.WriteLine("\n");
            }

            Console.WriteLine("---------------------------------------");
            // Deleting game2 from hashmap
            games.Delete(game2);

            // Creating forward iterator for games again
            gameIterator = games.CreateIterator();
            Console.WriteLine("Forward Iterator Printing after Deleting");
            Console.WriteLine("Game");
            while (gameIterator.HasNext())
            {
                var game = gameIterator.Next();
                Console.WriteLine($"Name: {game.Name}");
                Console.WriteLine($"Genre: {game.Genre}");
                Console.WriteLine($"Authors: {string.Join(", ", game.Authors)}");
                Console.WriteLine($"Reviews: {game.Reviews.Count}");
                Console.WriteLine($"Mods: {game.Mods.Count}");
                Console.WriteLine($"Devices: {string.Join(", ", game.Devices)}");
                Console.WriteLine("\n");
            }
            Console.WriteLine("---------------------------------------");

            // Creating reverse iterator for games again
            reverseGameIterator = games.CreateReverseIterator();
            Console.WriteLine("Reverse Iterator Printing after Deleting");
            Console.WriteLine("Game");
            while (reverseGameIterator.HasNext())
            {
                var game = reverseGameIterator.Next();
                Console.WriteLine($"Name: {game.Name}");
                Console.WriteLine($"Genre: {game.Genre}");
                Console.WriteLine($"Authors: {string.Join(", ", game.Authors)}");
                Console.WriteLine($"Reviews: {game.Reviews.Count}");
                Console.WriteLine($"Mods: {game.Mods.Count}");
                Console.WriteLine($"Devices: {string.Join(", ", game.Devices)}");
                Console.WriteLine("\n");
            }
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("Find the game whose name is Moo and print the name and Genre:");
            var foundGame = games.Find(game => game.Name == "Moo");
            if (foundGame != null)
            {
                Console.WriteLine($"Game found: {foundGame.Name}");
                Console.WriteLine($"Genre: {string.Join(", ", foundGame.Genre)}");
            }

            // ForEach method
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("print name and Genre ForEach game");
            games.ForEach(game => Console.WriteLine(game.Name));
            games.ForEach(game => Console.WriteLine(game.Genre));
            // CountIF method
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("Count the Number of games that whose Genre is 4x and count the number of games that whose author is Diver");
            int count = games.CountIf(game => game.Genre == "simulation");
            int count1 = games.CountIf(game => game.Authors.Contains("Driver"));

            Console.WriteLine($"Number of 4X games: {count}");
            Console.WriteLine($"Number of games whose author is Driver: {count1}");

        }


    }

}