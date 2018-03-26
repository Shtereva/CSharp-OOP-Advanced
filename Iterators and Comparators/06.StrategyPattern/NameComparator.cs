using System;
using System.Collections.Generic;

public class NameComparator : IComparer<Person>
{
    public int Compare(Person x, Person y)
    {
        if (x.Name.Length != y.Name.Length)
        {
            return x.Name.Length.CompareTo(y.Name.Length);
        }

        int compareFirstLetters = string.Compare(x.Name[0].ToString(), y.Name[0].ToString(), StringComparison.InvariantCultureIgnoreCase);
        return compareFirstLetters;
    }
}
