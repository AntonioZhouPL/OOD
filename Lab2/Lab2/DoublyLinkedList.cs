using System;
using System.Collections;
using System.Collections.Generic;

public class DoublyLinkedList<T> : ICollection<T>
{
    private class Node
    {
        public T Value { get; set; }
        public Node Previous { get; set; }
        public Node Next { get; set; }

        public Node(T value)
        {
            Value = value;
        }
    }

    private Node head;
    private Node tail;

    public int Count { get; private set; }

    public bool IsReadOnly => false;

    public void Add(T item)
    {
        Node node = new Node(item);

        if (head == null)
        {
            head = node;
            tail = node;
        }
        else
        {
            tail.Next = node;
            node.Previous = tail;
            tail = node;
        }

        Count++;
    }

    public void Clear()
    {
        head = null;
        tail = null;
        Count = 0;
    }

    public bool Contains(T item)
    {
        Node current = head;

        while (current != null)
        {
            if (EqualityComparer<T>.Default.Equals(current.Value, item))
            {
                return true;
            }

            current = current.Next;
        }

        return false;
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        Node current = head;
        int i = arrayIndex;

        while (current != null)
        {
            array[i++] = current.Value;
            current = current.Next;
        }
    }

    public bool Remove(T item)
    {
        Node current = head;

        while (current != null)
        {
            if (EqualityComparer<T>.Default.Equals(current.Value, item))
            {
                if (current == head)
                {
                    head = current.Next;

                    if (head != null)
                    {
                        head.Previous = null;
                    }
                    else
                    {
                        tail = null;
                    }
                }
                else if (current == tail)
                {
                    tail = current.Previous;
                    tail.Next = null;
                }
                else
                {
                    current.Previous.Next = current.Next;
                    current.Next.Previous = current.Previous;
                }

                Count--;
                return true;
            }

            current = current.Next;
        }

        return false;
    }

    public IEnumerator<T> GetEnumerator()
    {
        Node current = head;

        while (current != null)
        {
            yield return current.Value;
            current = current.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public IEnumerator<T> GetReverseEnumerator()
    {
        Node current = tail;

        while (current != null)
        {
            yield return current.Value;
            current = current.Previous;
        }
    }
}
