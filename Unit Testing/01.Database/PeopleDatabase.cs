using System;
using System.Collections.Generic;
using System.Linq;

public class PeopleDatabase : IPeople
{
    private List<Person> people;

    private List<Person> People
    {
        get => this.people;
        set
        {
            if (value == null)
            {
                throw new InvalidOperationException("Database should not be initialized with null");
            }

            this.people = new List<Person>(value);
        }
    }

    public int Count => this.People.Count;

    public PeopleDatabase(ICollection<Person> people)
    {
        this.People = people?.ToList();
    }

    public void Add(Person element)
    {
        if (this.People.Any(p => p.Name == element.Name || p.Id == element.Id))
        {
            throw new InvalidOperationException("There is already such person");
        }

        this.People.Add(element);
    }

    public void Remove()
    {
        if (!this.People.Any())
        {
            throw new InvalidOperationException("Database is empty.");
        }
        this.People.RemoveAt(this.People.Count - 1);
    }

    public IEnumerable<Person> Fetch()
    {
        return this.People;
    }

    public Person FindById(long id)
    {
        if (id < 0)
        {
            throw new ArgumentOutOfRangeException("Id should be positive.");
        }

        var person = this.People.SingleOrDefault(p => p.Id == id);

        if (person == null)
        {
            throw new InvalidOperationException("There is no person with this Id.");
        }

        return person;
    }

    public Person FindByUsername(string name)
    {
        if (name == null)
        {
            throw new ArgumentNullException("Invalid name.");
        }

        var person = this.People.SingleOrDefault(p => p.Name == name);

        if (person == null)
        {
            throw new InvalidOperationException("There is no person with this name.");
        }

        return person;
    }
}
