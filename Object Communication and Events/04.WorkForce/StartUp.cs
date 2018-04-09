using System;

public class StartUp
{
    public static void Main()
    {
        var jobs = new JobsRepo();

        string input;

        while ((input = Console.ReadLine()) != "End")
        {
            var args = input.Split();

            switch (args[0])
            {
                case "Job":
                    jobs.CreateJob(args[1], int.Parse(args[2]), args[3]);
                    break;
                case "StandardEmployee":
                    jobs.CreateEmployee(new StandardEmployee(args[1]));
                    break;
                case "PartTimeEmployee":
                    jobs.CreateEmployee(new PartTimeEmployee(args[1]));
                    break;
                case "Pass":
                    jobs.PassWeek();
                    break;
                case "Status":
                    jobs.Status();
                    break;
            }
        }

    }
}
