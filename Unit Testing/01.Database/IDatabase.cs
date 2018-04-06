using System.Collections.Generic;

public interface IDatabase<T>
{
    void Add(T element);

    void Remove();

    IEnumerable<T> Fetch();
}
