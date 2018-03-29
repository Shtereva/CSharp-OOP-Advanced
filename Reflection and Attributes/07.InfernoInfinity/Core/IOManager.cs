using System;
using System.Linq;

public static class IOManager
{
    public static void ReadInput(ICommandInterpreter interpreter)
    {
        string input;

        while ((input = Console.ReadLine()) != "END")
        {
            var cmdArgs = input.Split(";");

            string command = cmdArgs[0];
            cmdArgs = cmdArgs.Skip(1).ToArray();

            var result = interpreter.InterpretCommand(cmdArgs, command);
            result.Execute();
        }
    }

    public static void WriteOutput(Weapon weapon)
    {
        Console.WriteLine(weapon);
    }
}
