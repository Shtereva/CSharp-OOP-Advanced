﻿using System;
using System.Collections.Generic;

public class CategoryComparator : IEqualityComparer<Category>
{
    public bool Equals(Category x, Category y)
    {
        return x.Name == y.Name;
    }

    public int GetHashCode(Category obj)
    {
        return this.GetHashCode();
    }
}

