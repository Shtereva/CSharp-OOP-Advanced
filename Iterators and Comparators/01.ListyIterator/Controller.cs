using System;

public class Controller
{
    private IListyIterrator listyItterator;

    public void Create(params string[] elements)
    {
        this.listyItterator = new ListyIterator<string>(elements);
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
        Console.WriteLine(this.listyItterator.Print());
    }

    public bool HasNext()
    {
        return this.listyItterator.HasNext();
    }
}
