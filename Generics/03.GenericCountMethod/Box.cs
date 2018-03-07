using System;
public class Box<T> 
{
    public T Element { get; set; }

    public Box(T element)
    {
        this.Element = element;
    }

    //public override string ToString()
    //{
    //    return $"{this.Element.GetType().FullName}: {this.Element}";
    //}
}
