using System;
using System.Collections.Generic;

namespace Smoke
{
    class Game_g
    {
        public int Id { get; set; }
        public Dictionary<string, string> Map { get; set; }
        public string Name { get => Map[nameof(Name)]; set => Map[nameof(Name)] = value; }
        public string Genre { get => Map[nameof(Genre)]; set => Map[nameof(Genre)] = value; }
        public List<string> Authors { get; set; }
        public List<string> Reviews { get; set; }
        public List<string> Mods { get; set; }
        public string Devices { get => Map[nameof(Devices)]; set => Map[nameof(Devices)] = value; }

        public Game_g(int id, string name, string genre, List<string> authors, List<string> reviews, List<string> mods, string devices)
        {
            Id = id;
            Map = new Dictionary<string, string>();
            Name = name;
            Genre = genre;
            Authors = authors;
            Reviews = reviews;
            Mods = mods;
            Devices = devices;
        }
    }

    class Review_g
    {
        public int Id { get; set; }
        public Dictionary<string, string> Map { get; set; }
        public string Text { get => Map[nameof(Text)]; set => Map[nameof(Text)] = value; }
        public int Rating { get => int.Parse(Map[nameof(Rating)]); set => Map[nameof(Rating)] = value.ToString(); }
        public string Author { get => Map[nameof(Author)]; set => Map[nameof(Author)] = value; }

        public Review_g(int id, string text, int rating, string author)
        {
            Id = id;
            Map = new Dictionary<string, string>();
            Text = text;
            Rating = rating;
            Author = author;
        }
    }

    class Mod_g
    {
        public int Id { get; set; }
        public Dictionary<string, string> Map { get; set; }
        public string Name { get => Map[nameof(Name)]; set => Map[nameof(Name)] = value; }
        public string Description { get => Map[nameof(Description)]; set => Map[nameof(Description)] = value; }
        public List<string> Authors { get; set; }
        public List<string> Compatibility { get; set; }

        public Mod_g(int id, string name, string description, List<string> authors, List<string> compatibility)
        {
            Id = id;
            Map = new Dictionary<string, string>();
            Name = name;
            Description = description;
            Authors = authors;
            Compatibility = compatibility;
        }
    }

    class User_g
    {
        public int Id { get; set; }
        public Dictionary<string, string> Map { get; set; }
        public string Nickname { get => Map[nameof(Nickname)]; set => Map[nameof(Nickname)] = value; }
        public List<string> OwnedGames { get; set; }

        public User_g(int id, string nickname, List<string> ownedGames)
        {
            Id = id;
            Map = new Dictionary<string, string>();
            Nickname = nickname;
            OwnedGames = ownedGames;
        }
    }

    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        var game_1 = new Game_g(
    //               id: 1,
    //               name: "Garbage Collector",
    //               genre: "simulation",
    //               authors: new List<string> { },
    //               reviews: new List<string> { },
    //               mods: new List<string> { "Clouds", "Super clouds", "[Pek]", "[2,3,4,5]" },
    //               devices: "PC"
    //           );


    //        var game_2 = new Game_g(
    //               id: 1,
    //               name: "Universe of Techonology",
    //               genre: "4X",
    //               authors: new List<string> { },
    //               reviews: new List<string> {
    //        "I’m Commander Shepard and this is my favorite game on Smoke",
    //        "10",
    //        "Commander Shepard"
    //    },
    //               mods: new List<string> { "Clouds", "Super clouds", "[Pek]", "[2,3,4,5]" },
    //               devices: "PC"
    //           );

    //        var game_3 = new Game_g(
    //               id: 1,
    //               name: "Garbage Collector",
    //               genre: "simulation",
    //               authors: new List<string> { },
    //               reviews: new List<string> { },
    //               mods: new List<string> { "Clouds", "Super clouds", "[Pek]", "[2,3,4,5]" },
    //               devices: "PC"
    //           );

    //        var game_4 = new Game_g(
    //               id: 1,
    //               name: "Garbage Collector",
    //               genre: "simulation",
    //               authors: new List<string> { },
    //               reviews: new List<string> { },
    //               mods: new List<string> { "Clouds", "Super clouds", "[Pek]", "[2,3,4,5]" },
    //               devices: "PC"
    //           );

    //        var game_5 = new Game_g(
    //               id: 1,
    //               name: "Garbage Collector",
    //               genre: "simulation",
    //               authors: new List<string> { },
    //               reviews: new List<string> { },
    //               mods: new List<string> { "Clouds", "Super clouds", "[Pek]", "[2,3,4,5]" },
    //               devices: "PC"
    //           );



    //        var gameadapter1 = new GameAdapter(game_1);
    //        var gameadapter2 = new GameAdapter(game_2);
    //        var gameadapter3 = new GameAdapter(game_3);
    //        var gameadapter4 = new GameAdapter(game_4);
    //        var gameadapter5 = new GameAdapter(game_5);

    //        // create a list of ITarget objects
    //        var games = new List<ITarget> { gameadapter1, gameadapter2, gameadapter3, gameadapter4, gameadapter5 };

    //        // print games whose average rating is >=10
    //        foreach (var game in games)
    //        {
    //            var totalRating = 0;
    //            var averageRating = 0;
    //            foreach (var review in game.Reviews)
    //            {
    //                totalRating += review.Rating;
    //            }

    //            if (game.Reviews.Count != 0)
    //            {
    //                _ = totalRating / game.Reviews.Count;
    //            }

    //            if (averageRating >= 10)
    //            {
    //                //Console.WriteLine($"Name: {game.Name}, Genre: {game.Genre}");
    //                Console.WriteLine($"Name: {game.Name}, Genre: {game.Genre}, Average Rating: {averageRating}, Reviews: {game.Reviews.Count}");
    //            }
    //        }




    //        //Test represention 6 here.

    //        //Console.WriteLine($"Name: {game_1.Name}");
    //        //Console.WriteLine($"Genre: {game_1.Genre}");
    //        //Console.WriteLine($"Authors: {string.Join(", ", game_1.Authors)}");
    //        //Console.WriteLine($"Reviews: {string.Join(", ", game_1.Reviews)}");
    //        //Console.WriteLine($"Mods: {string.Join(", ", game_1.Mods)}");
    //        //Console.WriteLine($"Devices: {game_1.Devices}");
    //    }
    //}

 }
