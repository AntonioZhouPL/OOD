using System;
using System.Collections;
using System.Collections.Generic;

public class Vector<T> : IList<T>
{
    private T[] items;

    public int Count { get; private set; }

    public bool IsReadOnly => false;

    public Vector()
    {
        items = new T[4];
    }

    public Vector(int capacity)
    {
        if (capacity < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(capacity), "Capacity must be non-negative.");
        }

        items = new T[capacity];
    }

    public T this[int index]
    {
        get
        {
            if (index < 0 || index >= Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            return items[index];
        }
        set
        {
            if (index < 0 || index >= Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            items[index] = value;
        }
    }

    public void Add(T item)
    {
        if (Count == items.Length)
        {
            Array.Resize(ref items, items.Length * 2);
        }

        items[Count++] = item;
    }

    public void Clear()
    {
        Array.Clear(items, 0, Count);
        Count = 0;
    }

    public bool Contains(T item)
    {
        return Array.IndexOf(items, item, 0, Count) != -1;
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        Array.Copy(items, 0, array, arrayIndex, Count);
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < Count; i++)
        {
            yield return items[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public int IndexOf(T item)
    {
        return Array.IndexOf(items, item, 0, Count);
    }

    public void Insert(int index, T item)
    {
        if (index < 0 || index > Count)
        {
            throw new ArgumentOutOfRangeException(nameof(index));
        }

        if (Count == items.Length)
        {
            Array.Resize(ref items, items.Length * 2);
        }

        Array.Copy(items, index, items, index + 1, Count - index);
        items[index] = item;
        Count++;
    }

    public bool Remove(T item)
    {
        int index = Array.IndexOf(items, item, 0, Count);

        if (index == -1)
        {
            return false;
        }

        Array.Copy(items, index + 1, items, index, Count - index - 1);
        items[--Count] = default;

        return true;
    }

    public void RemoveAt(int index)
    {
        if (index < 0 || index >= Count)
        {
            throw new ArgumentOutOfRangeException(nameof(index));
        }

        Array.Copy(items, index + 1, items, index, Count - index - 1);
        items[--Count] = default;
    }
}
