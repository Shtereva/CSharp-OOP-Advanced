using System;
using System.Collections.Generic;
using System.Linq;

public static class Sorter
{
    public static List<T> Sort<T>(List<T> collection)
    {
        return collection.OrderBy(e => e).ToList();
    }
}
