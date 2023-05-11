using System;
using System.Collections.Generic;
using System.Linq;

public static class FindAlgorithm
{
    public static T Find<T>(ICollection<T> collection, Func<T, bool> predicate, bool searchFromBeginning)
    {
        if (collection == null)
        {
            throw new ArgumentNullException(nameof(collection));
        }

        if (predicate == null)
        {
            throw new ArgumentNullException(nameof(predicate));
        }

        if (searchFromBeginning)
        {
            foreach (var item in collection)
            {
                if (predicate(item))
                {
                    return item;
                }
            }
        }
        else
        {
            var reverseEnumerator = collection.Reverse().GetEnumerator();

            while (reverseEnumerator.MoveNext())
            {
                if (predicate(reverseEnumerator.Current))
                {
                    return reverseEnumerator.Current;
                }
            }
        }

        return default;
    }
}
