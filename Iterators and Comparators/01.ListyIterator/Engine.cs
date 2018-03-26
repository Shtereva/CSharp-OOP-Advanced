using System;
using System.Linq;

public class Engine
{
    public void Run()
    {
        string input;
        var controller = new Controller();

        while ((input = Console.ReadLine()) != string.Empty)
        {
            var cmdArgs = input.Split();
            string command = cmdArgs[0];

            try
            {
                switch (command)
                {
                    case "Create":
                        controller.Create(cmdArgs.Skip(1).ToArray());
                        break;
                    case "Move":
                        Console.WriteLine(controller.Move());
                        break;
                    case "Print":
                        controller.Print();
                        break;
                    case "HasNext":
                        Console.WriteLine(controller.HasNext());
                        break;
                    case "END":
                        controller.End();
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
