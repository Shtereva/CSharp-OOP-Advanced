using System;

public class Clients : IReciever
{
    public string SendMessage(IMessage message)
    {
        Console.WriteLine(message.SendMessage());

        return message.SendMessage();
    }
}
