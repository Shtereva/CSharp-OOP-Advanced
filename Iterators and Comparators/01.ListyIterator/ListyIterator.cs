using System;
using System.Collections.Generic;
using System.Linq;

public class ListyIterator<T> : IListyIterrator
{
    private List<T> collection;
    private int currentIndex;

    public ListyIterator(params T[] elements)
    {
        this.collection = new List<T>(elements);
    }

    public  bool Move()
    {
        if (!this.HasNext())
        {
            return false;
        }

        this.currentIndex++;
        return true;
    }

    public void Print()
    {
        if (!this.collection.Any())
        {
            throw new InvalidOperationException("Invalid Operation!");
        }

        Console.WriteLine(this.collection[this.currentIndex]);
    }

    public bool HasNext()
    {
        if (this.currentIndex + 1 > this.collection.Count - 1)
        {
            return false;
        }

        return true;
    }
}
