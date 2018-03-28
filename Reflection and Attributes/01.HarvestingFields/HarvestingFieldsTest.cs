using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class HarvestingFieldsTest
{
    public static void Main()
    {
        string input;
        var fields = Type
            .GetType("HarvestingFields")
            .GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

        while ((input = Console.ReadLine()) != "HARVEST")
        {
            switch (input)
            {
                case "private":
                    Print(fields.Where(f => f.IsPrivate));
                    break;
                case "protected":
                    Print(fields.Where(f => f.IsFamily));
                    break;
                case "public":
                    Print(fields.Where(f => f.IsPublic));
                    break;
                case "all":
                    Print(fields);
                    break;
            }
        }
    }

    private static void Print(IEnumerable<FieldInfo> fields)
    {
        foreach (var fieldInfo in fields)
        {
            string modifier = fieldInfo.Attributes == FieldAttributes.Family
                ? "protected"
                : fieldInfo.Attributes.ToString().ToLower();

            Console.WriteLine($"{modifier} {fieldInfo.FieldType.Name} {fieldInfo.Name}");
        }
    }
}
