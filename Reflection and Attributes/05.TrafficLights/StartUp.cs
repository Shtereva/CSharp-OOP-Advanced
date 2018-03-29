using System;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        var lights = Console.ReadLine()
            .Split()
            .Select(Enum.Parse<TraficLight>)
            .ToArray();

        int num = int.Parse(Console.ReadLine());

        for (int i = 0; i < num; i++)
        {
            for (int j = 0; j < lights.Length; j++)
            {
                int currentIndex = (int)lights[j] + 1;
                if (currentIndex > 2)
                {
                    currentIndex = 0;
                }

                lights[j] = (TraficLight)currentIndex;
            }

            Console.WriteLine(string.Join(" ", lights));
        }
    }
}
