using System;
using NUnit.Framework;

public class MathAbsAndFloorTests
{
    [TestCase(0, 0)]
    [TestCase(-2, 2)]
    [TestCase(5, 5)]
    [TestCase(-2147483647, 2147483647)]
    [TestCase(-5 - (-10), 5)]
    [TestCase(5 - 10, 5)]
    [TestCase(10 - 5, 5)]
    public void MathAbsShouldReturnAbsoluteValueOfOneNumber(int actual, int expected)
    {
        Assert.AreEqual(expected, Math.Abs(actual));
    }

    [TestCase(0, 0)]
    [TestCase(-2.3, 2.3)]
    [TestCase(5.123456, 5.123456)]
    [TestCase(double.MinValue, double.MaxValue)]
    [TestCase(-5.37 - (-10.46), 5.0900000000000007)]
    [TestCase(5.23 - 10.18, 4.9499999999999993)]
    [TestCase(10.48 - 5.23, 5.25)]
    public void MathAbsShouldReturnAbsoluteValueOfOneNumber(double actual, double expected)
    {
        Assert.AreEqual(expected, Math.Abs(actual));
    }

    [TestCase(5.7, 5)]
    [TestCase(-5.7, -6)]
    [TestCase(0.99999999999 + 0.0000000001, 1)]
    public void MathFloorWithDoubleTypes(double actual, double expected)
    {
        Assert.AreEqual(expected, Math.Floor(actual));
    }
}
