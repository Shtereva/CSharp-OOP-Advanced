using System.Collections;

public interface IListyIterrator : IEnumerable
{
    bool Move();

    void Print();

    bool HasNext();
}
