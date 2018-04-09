using System;
using System.Collections.Generic;
using System.Linq;

public class JobsRepo : IRepository
{
    public event UpdateHandler OnUpdate;

    private List<Job> jobs;
    private List<IEmployee> employees;

    public JobsRepo()
    {
        this.jobs = new List<Job>();
        this.employees = new List<IEmployee>();
    }


    public void CreateJob(string jobName, int hours, string employeeName)
    {
        var empl = this.employees.FirstOrDefault(e => e.Name == employeeName);

        if (empl != null)
        {
            var job = new Job(jobName, hours, empl);

            this.OnUpdate += job.Update;
            job.OnJobDone += this.RemoveJob;

            this.jobs.Add(job);
        }
    }

    public void CreateEmployee(IEmployee employee)
    {
        this.employees.Add(employee);
    }

    public void PassWeek()
    {
        this.OnUpdate?.Invoke();
    }

    public void Status()
    {
        foreach (var job in this.jobs)
        {
            job.PrintStatus();
        }
    }

    public void RemoveJob(object sender)
    {
        var job = this.jobs.FirstOrDefault(j => j == (Job)sender);

        this.OnUpdate -= job.Update;
        this.jobs.Remove(job);
    }
}
