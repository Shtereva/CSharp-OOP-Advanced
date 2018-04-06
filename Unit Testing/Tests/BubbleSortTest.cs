using System.Linq;
using NUnit.Framework;

public class BubbleSortTest
{
    [Test]
    public void SortCollection()
    {
        var expected = Enumerable.Range(1, 10).ToArray();

        var bubble = new Bubble(expected.Reverse().ToArray());
        bubble.Sort();

        for (int i = 0; i < expected.Length; i++)
        {
            Assert.AreEqual(expected[i], bubble[i]);
        }
    }
}
