using System;

public delegate void JobDoneHandler(object sender);

public class Job
{
    public event JobDoneHandler OnJobDone;

    private string name;
    private int requiredHoursOfWork;
    private IEmployee employee;

    public Job(string name, int requiredHoursOfWork, IEmployee employee)
    {
        this.name = name;
        this.requiredHoursOfWork = requiredHoursOfWork;
        this.employee = employee;
    }

    public void Update()
    {
        this.requiredHoursOfWork -= this.employee.WorkHoursPerWeek;

        if (this.requiredHoursOfWork <= 0)
        {
            Console.WriteLine($"Job {this.name} done!");

            if (this.OnJobDone != null)
            {
                this.OnJobDone.Invoke(this);
            }
        }
    }

    public void PrintStatus()
    {
        Console.WriteLine($"Job: {this.name} Hours Remaining: {this.requiredHoursOfWork}");
    }
}
