public delegate void UpdateHandler();

public interface IRepository
{
    event UpdateHandler OnUpdate;

    void CreateJob(string jobName, int hours, string employeeName);

    void CreateEmployee(IEmployee employee);

    void PassWeek();

    void Status();
}
