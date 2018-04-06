using System;
using CustomLinkedList;
using NUnit.Framework;

public class CustomLinkedListTests
{
    private DynamicList<int> list;

    [SetUp]
    public void Initialize()
    {
        this.list = new DynamicList<int>();
    }

    [Test]
    public void ListSHouldBeInitializedEmpty()
    {
        Assert.AreEqual(0, this.list.Count, "Linked List should be initialized empty");
    }

    [Test]
    public void AddItemsToList()
    {
        this.list.Add(1);
        this.list.Add(2);
        Assert.AreEqual(2, this.list.Count, "Add item should increment list size");
    }

    [TestCase(-1)]
    [TestCase(3)]
    public void IndexGetSmallerThanZeroBiggerThanListSizeShouldThrowException(int index)
    {
        this.list.Add(1);
        this.list.Add(2);
        this.list.Add(3);

        Assert.Throws<ArgumentOutOfRangeException>(() => this.list[index] = 1, "Invalid index should throw exception");
    }

    [TestCase(0, 1)]
    [TestCase(1, 2)]
    [TestCase(2, 3)]
    public void IndexGetShouldReturnCorrectValues(int index, int value)
    {
        this.list.Add(1);
        this.list.Add(2);
        this.list.Add(3);

        Assert.AreEqual(value, this.list[index], "Index doesn't return correct value");
    }

    [TestCase(1)]
    [TestCase(2)]
    [TestCase(3)]
    public void IndexSetShouldSetCorrectValues(int value)
    {
        this.list.Add(1);
        this.list[0] = value;

        Assert.AreEqual(value, this.list[0], "Index doesn't set correct value");
    }

    [Test]
    public void RemoveAtIndexSHouldReturnCorrectValue()
    {
        this.list.Add(1);
        this.list.Add(2);
        this.list.Add(3);

        int removedNumber = this.list.RemoveAt(1);

        Assert.AreEqual(2, removedNumber, "Remved number is different from expected number");
        Assert.AreEqual(2, this.list.Count);
        Assert.AreEqual(1, this.list[0]);
        Assert.AreEqual(3, this.list[1]);
    }

    [Test]
    public void RemoveMissingElementShouldReturnMinusOne()
    {
        this.list.Add(1);
        this.list.Add(2);

        int result = this.list.Remove(5);

        Assert.AreEqual(-1, result, "The given value is presented in the collection");
    }

    [Test]
    public void RemoveElementShouldReturnTheElement()
    {
        this.list.Add(1);
        this.list.Add(2);
        this.list.Add(3);

        int result = this.list.Remove(2);

        Assert.AreEqual(1, result, "The given value is not presented in the collection");
        Assert.AreEqual(2, this.list.Count);
        Assert.AreEqual(1, this.list[0]);
        Assert.AreEqual(3, this.list[1]);
    }

    [Test]
    public void IndexOfMissingElementShouldReturnMinusOne()
    {
        this.list.Add(1);
        this.list.Add(2);

        int result = this.list.IndexOf(5);

        Assert.AreEqual(-1, result, "The given value is presented in the collection");
    }

    [Test]
    public void IndexOfElementShouldReturnTheElement()
    {
        this.list.Add(1);
        this.list.Add(2);
        this.list.Add(3);

        int result = this.list.IndexOf(3);

        Assert.AreEqual(2, result, "The given value is not presented in the collection");
    }

    [Test]
    public void ContainsElementShouldReturnFalse()
    {
        this.list.Add(1);
        this.list.Add(2);

        bool result = this.list.Contains(5);

        Assert.IsFalse( result, "The given value is presented in the collection");
    }

    [Test]
    public void ContainsElementShouldReturnTrue()
    {
        this.list.Add(1);
        this.list.Add(2);
        this.list.Add(3);

        bool result = this.list.Contains(3);

        Assert.IsTrue(result, "The given value is not presented in the collection");
    }
}
