using System;
using System.Collections.Generic;
using Moq;
using NUnit.Framework;

public class PeopleDatabaseTest
{
    private PeopleDatabase peopleDatabase;

    [SetUp]
    public void Initialize()
    {
        var people = new List<Person>()
        {
            new Person(1, "Ani"),
            new Person(2, "Gosho"),
            new Person(3, "John")
        };

        this.peopleDatabase = new PeopleDatabase(people);
    }

    [Test]
    public void CreatePersonWithInvalidArguments()
    {
        Assert.Throws<ArgumentException>(() => new Person(-1, "Ani"));
        Assert.Throws<ArgumentException>(() => new Person(1, null));
    }

    [Test]
    public void ConstructorDoesntAcceptNullElements()
    {
        string message = "Database should not be initialized with null";

        Assert.Throws<InvalidOperationException>(() => new PeopleDatabase(null), message);
    }

    [Test]
    public void AddNewPerson()
    {
        this.peopleDatabase.Add(new Person(4, "Sam"));

        Assert.AreEqual(4, this.peopleDatabase.Count);
    }

    [Test]
    public void AddPersonWithExistingName()
    {
        Assert.Throws<InvalidOperationException>(() => this.peopleDatabase.Add(new Person(4, "Ani")));
    }

    [Test]
    public void AddPersonWithExistingId()
    {
        Assert.Throws<InvalidOperationException>(() => this.peopleDatabase.Add(new Person(3, "Sam")));
    }

    [Test]
    public void RemovePerson()
    {
        this.peopleDatabase.Remove();

        Assert.AreEqual(2, this.peopleDatabase.Count);
    }

    [Test]
    public void RemovePersonFromEmptyDatabase()
    {
        this.peopleDatabase.Remove();
        this.peopleDatabase.Remove();
        this.peopleDatabase.Remove();

        Assert.Throws<InvalidOperationException>(() => this.peopleDatabase.Remove());
    }

    [Test]
    public void FindByUsernameArgumentShouldBeCaseSensitive()
    {
        string name = "ani";

        string personName = this.peopleDatabase.FindByUsername("Ani").Name;

        Assert.AreNotEqual(name, personName);
    }

    [Test]
    public void FindByUsername()
    {
        var person = new Person(1, "Ani");

        var anotherPerson = this.peopleDatabase.FindByUsername("Ani");

        Assert.AreEqual(person.Name, anotherPerson.Name);
    }

    [Test]
    public void FindByNonExistingOrNullUsername()
    {
        Assert.Throws<InvalidOperationException>(() => this.peopleDatabase.FindByUsername("Jerry"));
        Assert.Throws<ArgumentNullException>(() => this.peopleDatabase.FindByUsername(null));
    }

    [Test]
    public void FindById()
    {
        var person = new Person(1, "Ani");

        var anotherPerson = this.peopleDatabase.FindById(1);

        Assert.AreEqual(person.Id, anotherPerson.Id);
    }

    [Test]
    public void FindByNonExistingOrNegativeId()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => this.peopleDatabase.FindById(-1));
        Assert.Throws<InvalidOperationException>(() => this.peopleDatabase.FindById(7));
    }

    [Test]
    public void FetchPeopleCorrectly()
    {
        var expected = new List<Person>()
        {
            new Person(1, "Ani"),
            new Person(2, "Gosho"),
            new Person(3, "John")
        };

        var mock = new Mock<IPeople>();
        mock.Setup(p => p.Fetch())
            .Returns(expected);

        CollectionAssert.AreEqual(expected, mock.Object.Fetch());
    }
}
