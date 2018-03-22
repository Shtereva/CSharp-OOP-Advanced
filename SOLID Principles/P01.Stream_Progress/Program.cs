using System;

namespace P01.Stream_Progress
{
    public class Program
    {
        public static void Main()
        {   
            var streamFile = new Movie("Going Postal", 100, 1000);

            var stream = new StreamProgressInfo(streamFile);

            Console.WriteLine(stream.CalculateCurrentPercent());
        }
    }
}
