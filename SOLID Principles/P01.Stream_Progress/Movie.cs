namespace P01.Stream_Progress
{
    public class Movie : IStreamable
    {
        private string title;

        public int Length { get; }
        public int BytesSent { get; }

        public Movie(string title, int length, int bytesSent)
        {
            this.title = title;
            this.Length = length;
            this.BytesSent = bytesSent;
        }
    }
}
