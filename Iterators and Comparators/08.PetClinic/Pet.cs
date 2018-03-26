public class Pet
{
    private string name;
    private int age;
    private string kind;

    public Pet(string name, int ae, string kind)
    {
        this.name = name;
        this.age = ae;
        this.kind = kind;
    }

    public string Name => this.name;

    public override string ToString()
    {
        return $"{this.Name} {this.age} {this.kind}";
    }
}
