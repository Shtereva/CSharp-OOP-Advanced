using System.Collections.Generic;

public class Box<T>
{
    private Stack<T> collection;
    public int Count => this.collection.Count;

    public Box()
    {
        this.collection = new Stack<T>();
    }
    public void Add(T element)
    {
        this.collection.Push(element);
    }

    public T Remove()
    {
        T element = this.collection.Pop();

        return element;
    }
}
