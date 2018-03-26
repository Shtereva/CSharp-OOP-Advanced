using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Stack<T> : IEnumerable<T>
{
    private List<T> data;

    public Stack()
    {
        this.data = new List<T>();
    }

    public void Push(T item)
    {
        this.data.Add(item);
    }

    public T Pop()
    {
        if (!this.data.Any())
        {
            throw new InvalidOperationException("No elements");
        }

        int index = this.data.Count - 1;
        T item = this.data[index];
        this.data.RemoveAt(index);

        return item;
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = this.data.Count - 1; i >= 0; i--)
        {
            yield return this.data[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
}
