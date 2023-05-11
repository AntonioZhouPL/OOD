using System.Collections.Generic;

namespace Smoke
{
    class BaseToGivenAdapter : Game_g
    {
        private Game game;

        public BaseToGivenAdapter(Game game) : base(game.GetHashCode(), game.Name, game.Genre, new List<string>(game.Authors), new List<string>(), new List<string>(), string.Join(",", game.Devices))
        {
            this.game = game;

            // Adapt Reviews
            foreach (Review review in game.Reviews)
            {
                this.Reviews.Add($"{review.Text} ({review.Author})");
            }

            // Adapt Mods
            foreach (Mod mod in game.Mods)
            {
                this.Mods.Add(mod.Name);
            }
        }

        public int GetReviewsCount()
        {
            return this.game.Reviews.Count;
        }
    }
}
