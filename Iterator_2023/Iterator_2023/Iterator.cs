using System;
using System.Collections.Generic;

namespace Smoke
{
    interface IIterator<T>
    {
        bool HasNext();
        T Next();
        //T Find(Predicate<T> predicate);
        //void ForEach(Action<T> action);
        //int CountIf(Func<T, bool> predicate);
    }
    static class IteratorExtensions
    {
        public static T Find<T>(this IIterator<T> iterator, Predicate<T> predicate)
        {
            while (iterator.HasNext())
            {
                T element = iterator.Next();
                if (predicate(element))
                {
                    return element;
                }
            }
            return default(T);
        }

        public static void ForEach<T>(this IIterator<T> iterator, Action<T> action)
        {
            while (iterator.HasNext())
            {
                T element = iterator.Next();
                action(element);
            }
        }

        public static int CountIf<T>(this IIterator<T> iterator, Func<T, bool> predicate)
        {
            int count = 0;
            while (iterator.HasNext())
            {
                T element = iterator.Next();
                if (predicate(element))
                {
                    count++;
                }
            }
            return count;
        }
    }

    //Forward Iterator
    class HashmapIterator<T> : IIterator<T>
    {
        private Hashmap<T> hashmap;
        private int index;

        public HashmapIterator(Hashmap<T> hashmap)
        {
            this.hashmap = hashmap;
            index = 0;
        }

        public bool HasNext()
        {
            while (index < hashmap.Size() && hashmap.Get(index) == null)
            {
                index++;
            }
            return index < hashmap.Size();
        }

        public T Next()
        {
            return hashmap.Get(index++);
        }

        //public T Find(Predicate<T> predicate)
        //{
        //    while (HasNext())
        //    {
        //        T element = Next();
        //        if (predicate(element))
        //        {
        //            return element;
        //        }
        //    }
        //    return default(T);
        //}

        //public void ForEach(Action<T> action)
        //{
        //    for (int i = 0; i < hashmap.Size(); i++)
        //    {
        //        action(hashmap.Get(i));
        //    }
        //}

        //public int CountIf(Func<T, bool> predicate)
        //{
        //    int count = 0;
        //    for (int i = index; i < hashmap.Size(); i++)
        //    {
        //        T element = hashmap.Get(i);
        //        if (element != null && predicate(element))
        //        {
        //            count++;
        //        }
        //    }
        //    return count;
        //}

    }

    //Reverse Iterator 
    class HashmapReverseIterator<T> : IIterator<T>
    {
        private Hashmap<T> hashmap;
        private int index;

        public HashmapReverseIterator(Hashmap<T> hashmap)
        {
            this.hashmap = hashmap;
            index = hashmap.Size() - 1;
        }

        public bool HasNext()
        {
            while (index >= 0 && hashmap.Get(index) == null)
            {
                index--;
            }
            return index >= 0;
        }

        public T Next()
        {
            return hashmap.Get(index--);
        }

        //public T Find(Predicate<T> predicate)
        //{
        //    while (HasNext())
        //    {
        //        T element = Next();
        //        if (predicate(element))
        //        {
        //            return element;
        //        }
        //    }
        //    return default(T);
        //}

        //public void ForEach(Action<T> action)
        //{
        //    for (int i = hashmap.Size() - 1; i >= 0; i--)
        //    {
        //        action(hashmap.Get(i));
        //    }
        //}

        //public int CountIf(Func<T, bool> predicate)
        //{
        //    int count = 0;
        //    for (int i = index; i >= 0; i--)
        //    {
        //        T element = hashmap.Get(i);
        //        if (element != null && predicate(element))
        //        {
        //            count++;
        //        }
        //    }
        //    return count;
        //}
    }

    class Hashmap<T>
    {
        private List<T>[] elements;
        private int capacity;

        public Hashmap(int capacity)
        {
            this.capacity = capacity;
            elements = new List<T>[capacity];
            for (int i = 0; i < capacity; i++)
            {
                elements[i] = new List<T>();
            }
        }

        public void Insert(T element)
        {
            int hashCode = element.GetHashCode();
            // to make sure the index won't small than 0, we are using Abs here
            int index = Math.Abs(hashCode) % capacity;

            if (elements[index] == null)
            {
                elements[index] = new List<T>();
            }

            elements[index].Add(element);
        }

        public void pushFront(T element)
        {


            int hashCode = element.GetHashCode();
            // to make sure the index won't small than 0, we are using Abs here
            int index = Math.Abs(hashCode) % capacity;

            if (elements[index] == null)
            {
                elements[index] = new List<T>();
            }

            elements[index].Insert(0, element);
        }

        public void pushBack(T element)
        {


            int hashCode = element.GetHashCode();
            // to make sure the index won't small than 0, we are using Abs here
            int index = Math.Abs(hashCode) % capacity;

            if (elements[index] == null)
            {
                elements[index] = new List<T>();
            }

            elements[index].Add(element);
        }



        public void Delete(T element)
        {

            int hashcode = element.GetHashCode();
            // to make sure the index won't small than 0, we are using Abs here
            int index = Math.Abs(hashcode) % capacity;

            if (elements[index] != null)
            {
                elements[index].Remove(element);
            }
        }



        public int Size()
        {
            int size = 0;
            for (int i = 0; i < capacity; i++)
            {
                size += elements[i].Count;
            }
            return size;
        }

        public T Get(int index)
        {
            int count = 0;
            for (int i = 0; i < capacity; i++)
            {
                foreach (T element in elements[i])
                {
                    if (count == index)
                    {
                        return element;
                    }
                    count++;
                }
            }
            throw new IndexOutOfRangeException();
        }

        public T Find(Predicate<T> predicate)
        {
            foreach (T element in this)
            {
                if (predicate(element))
                {
                    return element;
                }
            }
            return default(T);
        }

        public void ForEach(Action<T> action)
        {
            foreach (T element in this)
            {
                action(element);
            }
        }

        public int CountIf(Func<T, bool> predicate)
        {
            int count = 0;
            foreach (T element in this)
            {
                if (predicate(element))
                {
                    count++;
                }
            }
            return count;
        }


        public IIterator<T> CreateIterator()
        {
            return new HashmapIterator<T>(this);
        }

        public IIterator<T> CreateReverseIterator()
        {
            return new HashmapReverseIterator<T>(this);
        }



        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < capacity; i++)
            {
                foreach (T element in elements[i])
                {
                    yield return element;
                }
            }
        }



        public IEnumerable<T> GetReverseEnumerator()
        {
            for (int i = capacity - 1; i >= 0; i--)
            {
                if (elements[i] != null)
                {
                    for (int j = elements[i].Count - 1; j >= 0; j--)
                    {
                        yield return elements[i][j];
                    }
                }
            }
        }


    }


    

 }


