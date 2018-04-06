using System.Collections.Generic;

public class User
{
    public string Name { get; set; }

    public ICollection<Category> Categories { get; set; } = new HashSet<Category>(new CategoryComparator());
}
