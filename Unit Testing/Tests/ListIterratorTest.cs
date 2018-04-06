using System;
using NUnit.Framework;

public class ListIterratorTest
{
    private ListyIterator<string> listyIterator;

    [SetUp]
    public void Initializa()
    {
        this.listyIterator = new ListyIterator<string>("Gosho", "Pesho");
    }

    [Test]
    public void CreateListyIterattorWithParameters()
    {
        string expected = "Gosho";
        foreach (var item in this.listyIterator)
        {
            Assert.AreEqual(expected, item);
            expected = "Pesho";
        }
    }

    [Test]
    public void ConstructorDoesntAcceptNullElements()
    {
        Assert.Throws<ArgumentNullException>(() => new ListyIterator<string>(null));
    }

    [Test]
    public void HasNextReturnsTrueIfThereIsNextElement()
    {
        bool result = this.listyIterator.HasNext();

        Assert.IsTrue(result);
    }

    [Test]
    public void HasNextReturnsFalseIfThereIsNotNextElement()
    {
        var iterrator = new ListyIterator<string>("John");

        bool result = iterrator.HasNext();

        Assert.IsFalse(result);
    }

    [Test]
    public void MoveReturnsTrueIfThereIsNextElement()
    {
        bool result = this.listyIterator.Move();

        Assert.IsTrue(result);
    }

    [Test]
    public void MoveReturnsFalseIfThereIsNotNextElement()
    {
        var iterrator = new ListyIterator<string>("John");

        bool result = iterrator.Move();

        Assert.IsFalse(result);
    }

    [Test]
    public void PrintElementAtCurrentIndex()
    {
        this.listyIterator.Move();

        Assert.AreEqual("Pesho", this.listyIterator.Print());
    }

    [Test]
    public void PrintElementFromEmptyCollectionShouldThrowException()
    {
        var iterrator = new ListyIterator<string>();

        Assert.Throws<InvalidOperationException>(() => iterrator.Print());
    }
}
