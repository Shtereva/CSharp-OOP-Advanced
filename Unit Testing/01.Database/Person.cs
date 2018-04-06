using System;

public class Person
{
    private long id;
    private string name;

    public Person(long id, string name)
    {
        this.Id = id;
        this.Name = name;
    }

    public long Id
    {
        get => this.id;
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Id should be positive.");
            }

            this.id = value;
        }
    }

    public string Name
    {
        get => this.name;
        set
        {
            if (value == null)
            {
                throw new ArgumentException("Name cannot be null.");
            }

            this.name = value;
        }
    }
}
