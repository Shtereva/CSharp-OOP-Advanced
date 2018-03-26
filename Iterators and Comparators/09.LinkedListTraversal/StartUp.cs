using System;

public class StartUp
{
    public static void Main()
    {
        var myLinkedList = new LinkedList<int>();

        int lines = int.Parse(Console.ReadLine());

        for (int i = 0; i < lines; i++)
        {
            var input = Console.ReadLine().Split();
            int number = int.Parse(input[1]);

            if (input[0] == "Add")
            {
                myLinkedList.Add(number);
            }

            if (input[0] == "Remove")
            {
                myLinkedList.Remove(number);
            }
        }

        Console.WriteLine(myLinkedList.Count);

        foreach (var item in myLinkedList)
        {
            Console.Write(item + " ");
        }

        Console.WriteLine();
    }
}
