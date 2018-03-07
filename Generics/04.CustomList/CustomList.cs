using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class CustomList<T> : IEnumerable<T> where T : IComparable<T> 
{
    private List<T> collection;

    public CustomList()
    {
        this.collection = new List<T>();
    }
    public void Add(T element)
    {
        this.collection.Add(element);
    }

    public T Remove(int index)
    {
        T result = this.collection[index];
        this.collection.RemoveAt(index);

        return result;
    }

    public bool Contains(T element)
    {
        return this.collection.Contains(element);
    }

    public void Swap(int index1, int index2)
    {
        T temp = this.collection[index2];
        this.collection[index2] = this.collection[index1];
        this.collection[index1] = temp;
    }

    public int CountGreaterThan(T element)
    {
        return this.collection.Count(e => e.CompareTo(element) > 0);
    }

    public T Max()
    {
        return this.collection.Max(e => e);
    }

    public T Min()
    {
        return this.collection.Min(e => e);
    }

    public void Sort()
    {
        this.collection = Sorter.Sort(this.collection);
    }

    public IEnumerator<T> GetEnumerator()
    {
        return this.collection.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}
