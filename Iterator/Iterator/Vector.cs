using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vectors
{
    class VectorSparse : IAgregate
    {
        Dictionary<int, double> fields;
        int Length;
        public VectorSparse(int length) 
        {
            fields = new Dictionary<int, double>();
            this.Length = length;
        }

        public void AddValue(int index, double value)
        {
            this.fields[index] = value;
        }

        public Iterator GetIterator()
        {
            return new VectorSparseIterator(this.fields,this.Length);
        }
    }

    public class VectorSparseIterator : Iterator
    {
        double[] vec;
        int Lenght;
        int current;
        public VectorSparseIterator(Dictionary<int, double> dict, int len)
        {
            this.Lenght = len;
            this.current = 0;
            vec = new double[this.Lenght];
            for (int i = 0; i < this.Lenght; i++)
            {
                if (dict.ContainsKey(i))
                {
                    vec[i] = dict[i];
                }
                else
                {
                    vec[i] = 0;
                }
            }
        }
        public bool IsDone { get; private set; }

        public void Next()
        {
            current++;
            if (current == this.Lenght) IsDone = true;
            return;
        }

        public double GetValue { get { return vec[current]; } }

    }

    public class Node
    {
        public double Value { get; set; }
        public Node Next { get; set; }

        public Node(double value, Node next)
        {
            this.Value = value;
            this.Next = next;
        }
    }

    class VectorList: IAgregate
    {

        private Node head=null;

        public VectorList(int[] values) 
        {
            Node n, p = null;
            foreach(var elem in values)
            {
                n = new Node(elem, null);
                if (head != null)
                {
                    p = head;
                    while (p.Next != null) p = p.Next;
                    p.Next = n;
                }
                if (head == null) head = n;

            }
        }

        public Iterator GetIterator()
        {
            return new VectorListIterator(head);
        }
    }


    public class VectorListIterator : Iterator
    {
        double[] vec;
        int Lenght;
        int current;
        public VectorListIterator(Node head)
        {   
            this.current = 0;
            Node n = head;
            int count = 0;
            if (head != null)
            {
                while (n.Next != null) { count++; n = n.Next; }
                this.Lenght = count;
                vec = new double[this.Lenght];
                n = head;
                for (int i = 0; i < this.Lenght; i++, n = n.Next)
                {
                    vec[i] = n.Value;
                }
            }
            else
            {
                this.Lenght = 0;
                IsDone = true;
            }
        }

        public bool IsDone { get; private set; }

        public void Next()
        {
            current++;
            if (current == this.Lenght) IsDone = true;
            return;
        }

        public double GetValue { get { return vec[current]; } }

    }

    class VectorOneElement : IAgregate
    {
        int index;
        int value;
        int length;

        public VectorOneElement(int length, int index, int value)
        {
            this.index = index;
            this.value = value;
            this.length = length;
        }

        public Iterator GetIterator()
        {
            return new VectorOneElementIterator(this.index, this.value,this.length);
        }
    }

    public class VectorOneElementIterator : Iterator
    {
        double[] vec;
        int Lenght;
        int current;
        public VectorOneElementIterator(int index, int value, int len)
        {
            this.Lenght = len;
            this.current = 0;
            vec = new double[this.Lenght];
            for (int i = 0; i < this.Lenght; i++)
            {
                if (i==index)
                {
                    vec[i] = value;
                }
                else
                {
                    vec[i] = 0;
                }
            }
        }

        public bool IsDone { get; private set; }

        public void Next()
        {
            current++;
            if (current == this.Lenght) IsDone = true;
            return;
        }

        public double GetValue { get { return vec[current]; } }

    }

}
