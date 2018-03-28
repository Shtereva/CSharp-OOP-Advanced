using System;
using System.Linq;
using System.Reflection;

public class BlackBoxIntegerTests
{
    public static void Main()
    {
        string input;

        var classType = Type.GetType("BlackBoxInteger");

        var classInstance = Activator.CreateInstance(classType, true);

        var field = classInstance
            .GetType()
            .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
            .First();

        while ((input = Console.ReadLine()) != "END")
        {
            string[] cmdArgs = input.Split("_");

            string command = cmdArgs[0];
            int value = int.Parse(cmdArgs[1]);

            var method = classInstance
                .GetType()
                .GetMethod(command, BindingFlags.Instance | BindingFlags.NonPublic);

            method.Invoke(classInstance, new object[] {value});

            var result = field.GetValue(classInstance);
            Console.WriteLine(result);
        }
    }
}
