using System;
using System.Collections.Generic;

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

    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        // Creating instances of the classes
    //        //Game game1 = new Game("Garbage Collector", "simulation", new string[] { }, new List<Review> { }, new List<Mod> { new Mod("Clouds", "Super clouds", new string[] { "Pek" }, new int[] { 2, 3, 4, 5 }) }, new string[] { "PC" });
    //        //Game game2 = new Game("Universe of Technology", "4X", new string[] { }, new List<Review> { new Review("Universe of Technology is a spectacular 4X game, that manages to shine even when the main campaign doesn't.", 15, "lemon") }, new List<Mod> { new Mod("Clouds", "Super clouds", new string[] { "Pek" }, new int[] { 2, 3, 4, 5 }), new Mod("Commander Shepard", "I’m Commander Shepard and this is my favorite mod on Smoke", new string[] { "Commander Shepard" }, new int[] { 1, 2, 4 }) }, new string[] { "bitnix" });
    //        //Game game3 = new Game("Moo", "rogue-like", new string[] { "Driver" }, new List<Review> { new Review("The Moo remake sets a new standard for the future of the survival horror series⁠, even if it isn't the sequel I've been pining for.", 12, "Driver"), new Review("Moo’s interesting art design can't save it from its glitches, bugs, and myriad terrible game design decisions, but I love its sound design", 2, "Bonet") }, new List<Mod> { new Mod("Clouds", "Super clouds", new string[] { "Pek" }, new int[] { 2, 3, 4, 5 }), new Mod("T-pose", "Cow are now T-posing", new string[] { "Rondo" }, new int[] { 1, 3 }), new Mod("Commander Shepard", "I’m Commander Shepard and this is my favorite mod on Smoke", new string[] { "Commander Shepard" }, new int[] { 1, 2, 4 }) }, new string[] { "bitstation" });
    //        //Game game4 = new Game("Tickets Please", "platformer", new string[] { "Szredor" }, new List<Review> { new Review("I’m Commander Shepard and this is my favorite game on Smoke", 10, "Commander Shepard") }, new List<Mod> { new Mod("Clouds", "Super clouds", new string[] { "Pek" }, new int[] { 1, 3, 4 }), new Mod("Commander Shepard", "I’m Commander Shepard and this is my favorite mod on Smoke", new string[] { "Commander Shepard" }, new int[] { 1, 2, 4 }), new Mod("BTM", "You can now play in BTM’s trains and bytebuses", new string[] { "lemon, Bonet" }, new int[] { 1, 3 }) }, new string[] { "bitbox" });
    //        //Game game5 = new Game("Cosmic", "MOBA", new string[] { "MLG" }, new List<Review> { new Review("I've played this game for years nonstop. Over 8k hours logged (not even joking). And I'm gonna tell you: at this point, the game's just not worth playing anymore. I think it hasn't been worth playing for a year or two now, but I'm only just starting to realize it. It breaks my heart to say that, but that's just the truth of the matter.", 5, "Szredor") }, new List<Mod> { new Mod("Clouds", "Super clouds", new string[] { "Pek" }, new int[] { 2, 3, 4, 5 }), new Mod("Cosmic - black hole edition", "Adds REALISTIC black holes", new string[] { "Driver" }, new int[] { 1 }) }, new string[] { "platform" });

    //        //Review review1 = new Review("I’m Commander Shepard and this is my favorite game on Smoke", 10, "Commander Shepard");
    //        //Review review2 = new Review("The Moo remake sets a new standard for the future of the survival horror series⁠, even if it isn't the sequel I've been pining for.", 12, "Driver");
    //        //Review review3 = new Review("Universe of Technology is a spectacular 4X game, that manages to shine even when the main campaign doesn't.", 15, "lemon");
    //        //Review review5 = new Review("Moo’s interesting art design can't save it from its glitches, bugs, and myriad terrible game design decisions, but I love its sound design", 2, "Bonet");


    //        //User user1 = new User("Szredor", new int[] { 1, 2, 3, 4, 5 });
    //        //User user2 = new User("Driver", new int[] { 1, 2, 3, 4, 5 });
    //        //User user3 = new User("Pek", new int[] { 1, 2, 3, 4, 5 });
    //        //User user4 = new User("Commander Shepard", new int[] { 1, 2, 4 });
    //        //User user5 = new User("MLG", new int[] { 1, 5 });
    //        //User user6 = new User("Rondo", new int[] { 1 });
    //        //User user7 = new User("lemon", new int[] { 3, 4 });
    //        //User user8 = new User("Bonet", new int[] { 2 });


    //        //// Outputting the created instances
    //        //Console.WriteLine("Game:");
    //        //Console.WriteLine($"Name: {game1.Name}");
    //        //Console.WriteLine($"Genre: {game1.Genre}");
    //        //Console.WriteLine($"Authors: {string.Join(", ", game1.Authors)}");
    //        //Console.WriteLine($"Reviews: {game1.Reviews.Count}");
    //        //Console.WriteLine($"Mods: {game1.Mods.Count}");
    //        //Console.WriteLine($"Devices: {string.Join(", ", game1.Devices)}");

    //        //Console.WriteLine("\nReview:");
    //        //Console.WriteLine($"Text: {review1.Text}");
    //        //Console.WriteLine($"Rating: {review1.Rating}");
    //        //Console.WriteLine($"Author: {review1.Author}");

    //        //Console.WriteLine("\nUser:");
    //        //Console.WriteLine($"Nickname: {user1.Nickname}");
    //        //Console.WriteLine($"Owned games: {string.Join(", ", user1.OwnedGames)}");
    //    }
    //}


}
