using System;public class Person : IComparable<Person>
{
    private string name;
    private int age;
    private string town;

    public Person(string name, int age, string town)
    {
        this.name = name;
        this.age = age;
        this.town = town;
    }

    public int CompareTo(Person other)
    {
        if (this.name == other.name && this.age == other.age && this.town == other.town)
        {
            return 0;
        }

        return 1;
    }
}
