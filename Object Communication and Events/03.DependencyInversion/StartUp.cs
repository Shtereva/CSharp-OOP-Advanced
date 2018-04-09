using System;

public class StartUp
{
    public static void Main()
    {
        var calculator = new PrimitiveCalculator();
        string input;

        while ((input = Console.ReadLine()) != "End")
        {
            var args = input.Split();

            if (args[0] == "mode")
            {
                calculator.ChangeStrategy(args[1][0]);
                continue;
            }

            int result = calculator.PerformCalculation(int.Parse(args[0]), int.Parse(args[1]));
            Console.WriteLine(result);
        }
    }
}
