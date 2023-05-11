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
}
