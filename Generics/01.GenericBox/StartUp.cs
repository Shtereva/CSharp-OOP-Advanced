using System;

public class StartUp
{
    public static void Main()
    {
        int lines = int.Parse(Console.ReadLine());

        for (int i = 0; i < lines; i++)
        {
            string input = Console.ReadLine();
            var box = new Box<string>(input);
            Console.WriteLine(box);

            //int input = int.Parse(Console.ReadLine());
            //var box = new Box<int>(input);
            //Console.WriteLine(box);
        }
    }
}
