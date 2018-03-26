using System.Collections;
using System.Collections.Generic;

public class LinkedList<T> : IEnumerable<T>
{
    private class Node
    {
        public T Value { get; set; }
        public Node Next { get; set; }

        public Node(T value)
        {
            this.Value = value;
        }
    }

    private Node head;
    private Node tail;
    public int Count { get; private set; }

    public void Add(T item) //Last
    {
        Node old = this.tail;

        this.tail = new Node(item);

        if (this.IsEmpty())
        {
            this.head = this.tail;
        }
        else
        {
            old.Next = this.tail;
        }

        this.Count++;
    }

    public bool Remove(T item) // First
    {
        if (this.IsEmpty())
        {
            return false;
        }

        Node current = new Node(item);
        if (this.head.Value.Equals(current.Value))
        {
            this.head = this.head.Next;
            current.Next = null;
            this.Count--;

            if (this.IsEmpty())
            {
                this.tail = null;
            }

            return true;
        }

        Node currentHead = this.head.Next;
        Node oldHead = this.head;

        while (this.head.Next != null)
        {
            if (this.head.Next.Value.Equals(current.Value))
            {
                this.head.Next = currentHead.Next;
                this.Count--;

                if (this.IsEmpty())
                {
                    this.tail = null;
                }

                return true;
            }

            this.head = currentHead;
            currentHead = this.head.Next;
        }

        this.head = oldHead;
        return false;
    }

    private bool IsEmpty()
    {
        return this.Count == 0 ? true : false;
    }
    public IEnumerator<T> GetEnumerator()
    {
        Node cuurentNode = this.head;

        while (cuurentNode != null)
        {
            yield return cuurentNode.Value;
            cuurentNode = cuurentNode.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}
