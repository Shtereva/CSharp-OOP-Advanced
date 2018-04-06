using System;
using System.Reflection;
using Moq;
using NUnit.Framework;

public class DateTimeNowAddDaysTests
{

    [Test]
    public void DateTimeNowAddDaysToCurrentMonth()
    {
        var date = DateTime.Now.AddDays(13);

        Assert.AreEqual(2018, date.Year);
        Assert.AreEqual(4, date.Month);
        Assert.AreEqual(19, date.Day);
    }

    [Test]
    public void DateTimeNowAddDaysToNextMonth()
    {
        var date = DateTime.Now.AddDays(25);

        Assert.AreEqual(2018, date.Year);
        Assert.AreEqual(5, date.Month);
        Assert.AreEqual(1, date.Day);
    }

    [Test]
    public void DateTimeNowAddDaysToCurrentMonthWithNegativeValue()
    {
        var date = DateTime.Now.AddDays(-3);

        Assert.AreEqual(2018, date.Year);
        Assert.AreEqual(4, date.Month);
        Assert.AreEqual(3, date.Day);
    }

    [Test]
    public void DateTimeNowAddDaysToPreviouseMonthWithNegativeValue()
    {
        var date = DateTime.Now.AddDays(-10);

        Assert.AreEqual(2018, date.Year);
        Assert.AreEqual(3, date.Month);
        Assert.AreEqual(27, date.Day);
    }

    [Test]
    public void AddDaysToLeapYear()
    {
        var date = new DateTime(2018, 2, 28);
        date = date.AddDays(1);

        Assert.AreEqual(2018, date.Year);
        Assert.AreEqual(3, date.Month);
        Assert.AreEqual(1, date.Day);
    }

    [Test]
    public void AddDaysToNonLeapYear()
    {
        var date = new DateTime(2016, 2, 28);
        date = date.AddDays(1);

        Assert.AreEqual(2016, date.Year);
        Assert.AreEqual(2, date.Month);
        Assert.AreEqual(29, date.Day);
    }

    [Test]
    public void AddDaysToDateTimeMaxAndMinValue()
    {
        var dateMax = DateTime.MaxValue;

        Assert.Throws<ArgumentOutOfRangeException>(() => dateMax.AddDays(1));

        var dateMin = DateTime.MinValue.AddDays(1);

        Assert.AreEqual(1, dateMin.Year);
        Assert.AreEqual(1, dateMin.Month);
        Assert.AreEqual(2, dateMin.Day);
    }

    [Test]
    public void SubstractDaysToDateTimeMaxAndMinValue()
    {
        var dateMax = DateTime.MaxValue.AddDays(-1);

        Assert.AreEqual(9999, dateMax.Year);
        Assert.AreEqual(12, dateMax.Month);
        Assert.AreEqual(30, dateMax.Day);

        var dateMin = DateTime.MinValue;

        Assert.Throws<ArgumentOutOfRangeException>(() => dateMin.AddDays(-1));
    }
}
