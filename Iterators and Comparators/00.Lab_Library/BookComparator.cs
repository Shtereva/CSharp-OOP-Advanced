using System.Collections.Generic;

public class BookComparator : IComparer<Book>
{
    public int Compare(Book that, Book other)
    {
        int result = that.Year.CompareTo(other.Year);
        if (result == 0)
        {
            return that.Title.CompareTo(other.Title);
        }

        return result;
    }
}
