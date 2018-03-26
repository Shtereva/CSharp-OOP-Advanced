using System;
using System.Collections.Generic;

public class StartUp
{
    public static void Main()
    {
        var people = new List<Person>();

        string input;

        while ((input = Console.ReadLine()) != "END")
        {
            var cmdArgs = input.Split();
            people.Add(new Person(cmdArgs[0], int.Parse(cmdArgs[1]), cmdArgs[2]));
        }

        int personsIndex = int.Parse(Console.ReadLine());

        int equalPersons = 0;
        int notEqualPersons = 0;

        try
        {
            var person = people[personsIndex];

            foreach (var personToCompare in people)
            {
                if (person.CompareTo(personToCompare) == 0)
                {
                    equalPersons++;
                    continue;
                }

                notEqualPersons++;
            }

            Console.WriteLine(equalPersons == 0 ? "No matches" : $"{equalPersons} {notEqualPersons} {people.Count}");
        }
        catch (Exception)
        {
            Console.WriteLine("No matches");
        }
    }
}
