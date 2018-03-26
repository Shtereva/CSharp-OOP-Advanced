using System;

public class Controller
{
    private Stack<int> myStack;

    public Controller()
    {
        this.myStack = new Stack<int>();
    }

    public void Push(params int[] elements)
    {
        foreach (var element in elements)
        {
            this.myStack.Push(element);
        }
    }

    public int Pop()
    {
        return this.myStack.Pop();
    }

    public void End()
    {
        for (int i = 0; i < 2; i++)
        {
            this.PrintAll();
        }

        Environment.Exit(0);
    }

    private void PrintAll()
    {
        foreach (var element in this.myStack)
        {
            Console.WriteLine(element);
        }
    }
}