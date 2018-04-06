using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class ListyIterator<T> : IListyIterrator , IEnumerable<string>
{
    private List<string> collection;
    private int currentIndex;

    private List<string> Collection
    {
        get => this.collection;
        set
        {
            if (value == null)
            {
                throw new ArgumentNullException("Parameters should not be null or emptry");
            }
            this.collection = value;
        }
    }

    public ListyIterator(params string[] elements)
    {
        this.Collection = new List<string>(elements);
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

    public string Print()
    {
        if (!this.Collection.Any())
        {
            throw new InvalidOperationException("Invalid Operation!");
        }

        return this.Collection[this.currentIndex];
    }

    public bool HasNext()
    {
        if (this.currentIndex + 1 > this.Collection.Count - 1)
        {
            return false;
        }

        return true;
    }

    public IEnumerator<string> GetEnumerator()
    {
        return this.Collection.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}
