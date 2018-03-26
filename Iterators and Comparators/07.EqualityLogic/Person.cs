using System;

public class Person : IEquatable<Person>
{
    public int Age { get; set; }
    public string Name { get; set; }

    public Person(string name, int age)
    {
        this.Name = name;
        this.Age = age;
    }

    public override string ToString()
    {
        return $"{this.Name} {this.Age}";
    }

    public bool Equals(Person x, Person y)
    {

        return x == y;
    }

    public override int GetHashCode()
    {
        return Name.GetHashCode();
    }

    public bool Equals(Person other)
    {
        
        return this.Age == other.Age && string.Equals(this.Name, other.Name);
    }
}
