using System;

public class StartUp
{
    public static void Main()
    {
        var nameAndAddress = Console.ReadLine().Split();
        var personInfo = new Threeuple<string, string, string>($"{nameAndAddress[0]} {nameAndAddress[1]}",
            nameAndAddress[2], nameAndAddress[3]);

        var nameAndAmountBeer = Console.ReadLine().Split();
        bool drinkOrNot = nameAndAmountBeer[2] == "drunk" ? true : false;
        var personsBeerAmoubt = new Threeuple<string, int, bool>(nameAndAmountBeer[0], int.Parse(nameAndAmountBeer[1]), drinkOrNot);

        var bankAccount = Console.ReadLine().Split();
        double balance = Math.Round(double.Parse(bankAccount[1]), 1);
        var differentTypeNumbers = new Threeuple<string, double, string>(bankAccount[0], balance, bankAccount[2]);

        Console.WriteLine(personInfo);
        Console.WriteLine(personsBeerAmoubt);
        Console.WriteLine(differentTypeNumbers);
    }
}
