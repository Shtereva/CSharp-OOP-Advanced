public class StandardEmployee : IEmployee
{
    public string Name { get; }

    public int WorkHoursPerWeek => 40;

    public StandardEmployee(string name)
    {
        this.Name = name;
    }
}
