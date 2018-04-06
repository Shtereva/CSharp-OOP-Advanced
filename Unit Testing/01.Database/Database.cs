using System;
using System.Collections.Generic;
using System.Linq;

public class Database : IDatabase<int>
{
    private const int Datalength = 16;

    private int[] data;
    private int lastFreeCell;

    public int[] Data
    {
        get => this.data;
        private set
        {
            if (value == null || value.Length > Datalength)
            {
                throw new InvalidOperationException();
            }

            this.data = new int[Datalength];
            value.CopyTo(this.data, this.lastFreeCell);
        }
    }

    public int Count => this.lastFreeCell;

    public Database(IEnumerable<int> elements)
    {
        this.Data = elements?.ToArray();
        this.lastFreeCell = this.FindLastElement();
    }

    private int FindLastElement()
    {
        for (int i = 0; i < this.Data.Length; i++)
        {
            if (this.Data[i] == 0)
            {
                return i;
            }
        }

        return Datalength;
    }

    public void Add(int element)
    {
        if (this.lastFreeCell >= Datalength)
        {
            throw new InvalidOperationException();
        }

        this.Data[this.lastFreeCell] = element;
        this.lastFreeCell++;
    }

    public void Remove()
    {
        this.lastFreeCell--;

        if (this.lastFreeCell < 0)
        {
            this.lastFreeCell = 0;
            throw new InvalidOperationException();
        }

        this.Data[this.lastFreeCell] = 0;
    }

    public IEnumerable<int> Fetch()
    {
        return this.Data;
    }
}
