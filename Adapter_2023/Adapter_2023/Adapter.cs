using System.Collections.Generic;
using System.Linq;

namespace Smoke
{
    class GameAdapter : ITarget
    {
        private readonly Game_g _game;

        public GameAdapter(Game_g game)
        {
            _game = game;
        }

        public GameAdapter(Game game_g1)
        {
        }

        public string Name => _game.Name;

        public string Genre => _game.Genre;

        public List<Review> Reviews => _game.Reviews.Select((r, i) => new Review(r, int.Parse(_game.Map[$"rating{i}"]), _game.Map[$"author{i}"])).ToList();
        public List<Mod> Mods => _game.Mods.Select(m => new Mod(m, "", new string[0], new int[0])).ToList();
        public string[] Devices => _game.Devices.Split();

    }

    class ReviewAdapter : IReviewTarget
    {
        private readonly Review_g _review;

        public ReviewAdapter(Review_g review)
        {
            _review = review;
        }

        public string Text => _review.Text;

        public int Rating => _review.Rating;

        public string Author => _review.Author;
    }




}
