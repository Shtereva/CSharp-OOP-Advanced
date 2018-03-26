using System;
using System.Collections.Generic;

public class PersonComparer : IComparer<Person>
{
    public int Compare(Person x, Person y)
    {
        return x.Equals(y) ? -1 : 1;
    }
}
