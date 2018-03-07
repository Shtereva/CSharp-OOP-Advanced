using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        int lines = int.Parse(Console.ReadLine());
        var list = new List<Box<int>>();

        for (int i = 0; i < lines; i++)
        {
            int input = int.Parse(Console.ReadLine());
            var box = new Box<int>(input);
            list.Add(box);
        }

        var swapIndexes = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToArray();

        Swap(list, swapIndexes);

        Console.WriteLine(string.Join(Environment.NewLine, list));
    }

    private static void Swap<T>(List<T> list, int[] swapIndexes)
    {
        int indexOne = swapIndexes[0];
        int indexTwo = swapIndexes[1];

        T temp = list[indexTwo];
        list[indexTwo] = list[indexOne];
        list[indexOne] = temp;
    }
}
