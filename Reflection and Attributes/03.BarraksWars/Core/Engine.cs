using System;
using System.Globalization;
using System.Linq;

public class Engine : IRunnable
{
    private ICommandInterpreter interpreter;

    public Engine()
    {
        this.interpreter = new CommandInterpreter(new UnitFactory(), new UnitRepository());
    }
    public void Run()
    {
        string input;
        while ((input = Console.ReadLine()) != "fight")
        {
            string output;
            try
            {
                string[] data = input.Split();
                string commandName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(data[0]);

                var result = this.interpreter.InterpretCommand(data, commandName);
                output = result.Execute();
            }
            catch (Exception e)
            {
                output = e.Message;
            }

            Console.WriteLine(output);
        }
    }
}
