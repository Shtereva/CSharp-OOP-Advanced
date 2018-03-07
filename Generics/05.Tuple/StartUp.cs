using System;

public class StartUp
{
    public static void Main()
    {
        var nameAndAddress = Console.ReadLine().Split();
        var personInfo = new Tuple<string,string>($"{nameAndAddress[0]} {nameAndAddress[1]}", nameAndAddress[2]);

        var nameAndAmountBeer = Console.ReadLine().Split();
        var personsBeerAmoubt = new Tuple<string,int>(nameAndAmountBeer[0], int.Parse(nameAndAmountBeer[1]));

        var numbers = Console.ReadLine().Split();
        var differentTypeNumbers = new Tuple<int,double>(int.Parse(numbers[0]), double.Parse(numbers[1]));

        Console.WriteLine(personInfo);
        Console.WriteLine(personsBeerAmoubt);
        Console.WriteLine(differentTypeNumbers);
    }
}
