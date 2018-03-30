using System;
using System.Linq;
using System.Reflection;

public class Tracker
{
    public  void PrintMethodsByAuthor()
    {
        var classType = typeof(StartUp);

        var methods = classType
            .GetMethods(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public)
            .Where(m => m.GetCustomAttributes<SoftUniAttribute>() != null)
            .ToArray();

        foreach (var methodInfo in methods)
        {
            var attributes = methodInfo.GetCustomAttributes<SoftUniAttribute>();

            foreach (var softUniAttribute in attributes)
            {
                Console.WriteLine($"{methodInfo.Name} is written by {softUniAttribute.Name}");
            }
        }
    }
}
