public class ReportCommand : Command
{
    [Inject]
    private IRepository unitRepository;

    public ReportCommand(string[] data)
        : base(data)
    {
    }

    public override string Execute()
    {
        string output = this.unitRepository.Statistics;
        return output;
    }
}
