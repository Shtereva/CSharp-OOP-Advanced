using System;

public class Controller
{
    private IListyIterrator listyItterator;

    public void Create<T>(params T[] elements)
    {
        this.listyItterator = new ListyIterator<T>(elements);
    }

    public void End()
    {
        Environment.Exit(0);
    }

    public bool Move()
    {
        return this.listyItterator.Move();
    }

    public void Print()
    {
        this.listyItterator.Print();
    }

    public void PrintAll()
    {
        foreach (var item in this.listyItterator)
        {
            Console.Write($"{item} ");
        }

        Console.WriteLine();
    }

    public bool HasNext()
    {
        return this.listyItterator.HasNext();
    }
}
