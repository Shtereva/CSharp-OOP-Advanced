using System;
using System.Linq;
using System.Text;

public class StartUp
{
    public static void Main()
    {
        var numbers = Console.ReadLine()
            .Split(" ,".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse);

        var lake = new Lake(numbers);
        var sb = new StringBuilder();

        foreach (var stone in lake)
        {
            sb.Append($"{stone}, ");
        }

        Console.WriteLine(sb.ToString().TrimEnd(' ', ','));
    }
}
