using System;
using System.Collections.Generic;

public class StartUp
{
    public static void Main()
    {
        var nameSet = new SortedSet<Person>(new NameComparator());
        var ageSet = new SortedSet<Person>(new AgeComparator());

        int num = int.Parse(Console.ReadLine());

        for (int i = 0; i < num; i++)
        {
            var input = Console.ReadLine().Split();

            var person = new Person(input[0], int.Parse(input[1]));

            nameSet.Add(person);
            ageSet.Add(person);
        }

        Console.WriteLine(string.Join(Environment.NewLine, nameSet));
        Console.WriteLine(string.Join(Environment.NewLine, ageSet));
    }
}
