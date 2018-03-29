using System;
using System.Linq;
using System.Reflection;

public class StartUp
{
    public static void Main()
    {
        string input;
        var weaponType = Type.GetType("Weapon");

        while ((input = Console.ReadLine()) != "END")
        {

            var atribute = weaponType
                .GetCustomAttribute<CustomAttribute>();

            string result = GetAttributeInfo(input, atribute);
            Console.WriteLine(result);
        }
    }

    private static string GetAttributeInfo(string input, CustomAttribute attribute)
    {
        switch (input)
        {
            case "Author":
                return $"Author: {attribute.Author}";

            case "Revision":
                return $"Revision: {attribute.Revision}";

            case "Description":
                return $"Class description: {attribute.Description}";

            case "Reviewers":
                return $"Reviewers: {string.Join(", ", attribute.Reviewers)}";
        }

        return null;
    }
}
