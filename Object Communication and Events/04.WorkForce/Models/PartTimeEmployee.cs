public class PartTimeEmployee : IEmployee
{
    public string Name { get; }

    public int WorkHoursPerWeek => 20;

    public PartTimeEmployee(string name)
    {
        this.Name = name;
    }
}
