public class StartUp
{
    public static void Main()
    {
        var engine = new Engine();
        engine.Run();

        var a = new ListyIterator<int>();
        a.GetEnumerator();
    }
}
