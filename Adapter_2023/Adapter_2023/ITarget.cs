using System.Collections.Generic;

namespace Smoke
{
    interface ITarget
    {
        string Name { get; }
        string Genre { get; }
        List<Review> Reviews { get; }
        List<Mod> Mods { get; }
        string[] Devices { get; }
    }

    interface IReviewTarget
    {
        string Text { get; }
        int Rating { get; }
        string Author { get; }
    }


}
