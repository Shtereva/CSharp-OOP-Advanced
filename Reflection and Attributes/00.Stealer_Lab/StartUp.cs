using System;

public class StartUp
{
    public static void Main()
    {
        var spy = new Spy();
        string result = spy.StealFieldInfo("System.Text.StringBuilder", "MaxChunkSize", "ThreadIDField");
        //string result = spy.AnalyzeAcessModifiers("Hacker");
        //string result = spy.RevealPrivateMethods("Hacker");
        //string result = spy.CollectGettersAndSetters("Hacker");

        Console.WriteLine(result);
        Console.WriteLine(result.Length);
    }
}
