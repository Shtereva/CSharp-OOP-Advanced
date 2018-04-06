using System;
using Moq;
using System.Linq;
using NUnit.Framework;

public class DatabaseTest
{
    private const int Datalength = 16;

    [Test]
    public void ConstructorDoesntAcceptNullElements()
    {
        string message = "Database should not be initialized with null";

        Assert.Throws<InvalidOperationException>(() => new Database(null), message);
    }

    [Test]
    public void ConstructorTakeElementsBiggerThanSixteen()
    {
        string message = $"Database should be initialized with sixteen elements";

        Assert.Throws<InvalidOperationException>(() => new Database(new int[20]));
    }

    [Test]
    public void AddElementToDatabase()
    {
        var database = new Database(new int[] { 1, 1, 1 });

        database.Add(2);
        database.Add(2);
        database.Add(2);

        Assert.AreEqual(6, database.Count);
    }

    [Test]
    public void AddElementAtLastFreeSell()
    {
        var numbers = Enumerable.Range(1, Datalength - 1).ToArray();

        var db = new Database(numbers);
        db.Add(16);

        numbers = Enumerable.Range(1, Datalength).ToArray();
        CollectionAssert.AreEqual(numbers, db.Data);
    }

    [Test]
    public void AddElementsMoreThanCapacity()
    {
        var numbers = Enumerable.Range(1, Datalength).ToArray();

        var database = new Database(numbers);

        Assert.Throws<InvalidOperationException>(() => database.Add(6));
    }

    [Test]
    public void RemoveElement()
    {
        var numbers = Enumerable.Range(1, Datalength).ToArray();

        var database = new Database(numbers);
        database.Remove();
        database.Remove();

        numbers[Datalength - 1] = 0;
        numbers[Datalength - 2] = 0;

        CollectionAssert.AreEqual(numbers, database.Data);
    }

    [Test]
    public void RemoveElementFromEmtyDatabase()
    {
        var database = new Database(new int[Datalength]);

        Assert.Throws<InvalidOperationException>(() => database.Remove());
    }

    [Test]
    public void FetchDatabaseReturnsCorrectData()
    {
        var numbers = Enumerable.Range(1, Datalength).ToArray();
        var mock = new Mock<IDatabase<int>>();

        mock = new Mock<IDatabase<int>>();
        mock.Setup(x => x.Fetch())
            .Returns(numbers);

        CollectionAssert.AreEqual(numbers, mock.Object.Fetch().ToArray());
    }
}
