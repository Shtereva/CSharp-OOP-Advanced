using System;
using System.Linq;

public class Engine
{
    public void Run()
    {
        int lines = int.Parse(Console.ReadLine());
        var controller = new Controller();

        for (int i = 0; i < lines; i++)
        {
            try
            {
                var cmdArgs = Console.ReadLine().Split();
                string command = cmdArgs[0];

                switch (command)
                {
                    case "Create":
                        var args = cmdArgs.Skip(2).ToArray();
                        if (cmdArgs[1] == "Pet")
                        {
                            controller.CreatePet(args);
                            continue;
                        }
                        controller.CreateClinic(args);
                        break;

                    case "Add":
                        Console.WriteLine(controller.AddPetToClinic(cmdArgs.Skip(1).ToArray()));
                        break;

                    case "Release":
                        Console.WriteLine(controller.Release(cmdArgs.Skip(1).ToArray()));
                        break;

                    case "HasEmptyRooms":
                        Console.WriteLine(controller.HasEmptyRooms(cmdArgs.Skip(1).ToArray()));
                        break;

                    case "Print":
                        var printArgs = cmdArgs.Skip(1).ToArray();
                        if (printArgs.Length > 1)
                        {
                            controller.PrintClinicRoom(printArgs);
                            continue;
                        }

                        controller.PrintClinic(printArgs);
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
