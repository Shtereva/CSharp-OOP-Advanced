using System;
using System.Linq;
using System.Reflection;

public class StartUp
{
    static void Main()
    {
        var input = Console.ReadLine();

        var classType = Type.GetType(input);

        var attribute = classType
            .GetCustomAttributes<TypeAttribute>()
            .First(a => a.Category == input);

        Console.WriteLine($"Type = {attribute.Type}, Description = {attribute.Descripion}");
    }
}
