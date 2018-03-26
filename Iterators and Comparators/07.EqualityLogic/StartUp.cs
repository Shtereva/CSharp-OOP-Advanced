using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    static void Main()
    {
        var sortedSet = new SortedSet<Person>(new PersonComparer());
        var hashSet = new HashSet<Person>();

        int num = int.Parse(Console.ReadLine());

        for (int i = 0; i < num; i++)
        {
            var input = Console.ReadLine().Split();

            var person = new Person(input[0], int.Parse(input[1]));

            if (sortedSet.All(e => !e.Equals(person)))
            {
                sortedSet.Add(person);
            }

            hashSet.Add(person);
        }

        Console.WriteLine(sortedSet.Count);
        Console.WriteLine(hashSet.Count);
    }
}
