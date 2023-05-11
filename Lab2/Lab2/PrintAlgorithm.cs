﻿using System;
using System.Collections.Generic;
using System.Linq;

public static class PrintAlgorithm
{
    public static void Print<T>(ICollection<T> collection, Func<T, bool> predicate, bool searchFromBeginning)
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
                    Console.WriteLine(item.ToString());
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
                    Console.WriteLine(reverseEnumerator.Current.ToString());
                }
            }
        }
    }
}
