using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        string kingName = Console.ReadLine();
        var king = new King(kingName);

        AddPlayer(king);

        string input;

        while ((input = Console.ReadLine()) != "End")
        {
            var args = input.Split();
            string command = args[0];

            if (command == "Attack")
            {
                king.Attack();
            }

            if (command == "Kill")
            {
                string name = args[1];
                king.Kill(name);
            }
        }
    }

    private static void AddPlayer(IAttackable king)
    {
        var royalGuards = Console.ReadLine().Split();

        foreach (var royalGuard in royalGuards)
        {
            king.AddPlayer(new RoyalGuard(royalGuard));
        }

        var footmans = Console.ReadLine().Split();

        foreach (var footman in footmans)
        {
            king.AddPlayer(new Footman(footman));
        }
    }
}
