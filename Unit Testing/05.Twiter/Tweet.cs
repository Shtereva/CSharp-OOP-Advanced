using System;

public class Tweet : IMessage
{
    private string message;

    public Tweet(string message)
    {
        this.Message = message;
    }

    public string Message
    {
        get => this.message;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Invalid message");
            }

            this.message = value;
        }
    }

    public string SendMessage()
    {
        return this.Message;
    }
}
