using System;

public class StartUp
{
    public static void Main()
    {
        double a = Math.Floor(0.99999999999 + 0.0000000001);

        decimal b = Math.Floor(0.99999999999999m + 0.000000001m);

        Console.WriteLine(a);
        Console.WriteLine(b);
    }
}
