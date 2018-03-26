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
            var cmdArgs = input.Split(" ,".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            string command = cmdArgs[0];

            try
            {
                switch (command)
                {
                    case "Push":
                        controller.Push(cmdArgs.Skip(1).Select(int.Parse).ToArray());
                        break;
                    case "Pop":
                        controller.Pop();
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
