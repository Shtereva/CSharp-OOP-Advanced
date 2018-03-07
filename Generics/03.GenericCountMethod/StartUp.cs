using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        int lines = int.Parse(Console.ReadLine());
        //var list = new List<Box<string>>();
        var list = new List<Box<double>>();

        for (int i = 0; i < lines; i++)
        {
            double input = double.Parse(Console.ReadLine());
            list.Add(new Box<double>(input));
        }

        double elementToCompare = double.Parse(Console.ReadLine());

        int count = Count(list, elementToCompare);

        Console.WriteLine(count);
    }

    private static int Count<T>(List<Box<T>> elements, T element)
        where T : IComparable<T>
    {
        return elements.Count(e => e.Element.CompareTo(element) > 0);
    }
}
