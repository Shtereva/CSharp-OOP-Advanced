public class RetireCommand : Command
{
    [Inject]
    private IRepository unitRepository;

    public RetireCommand(string[] data)
        : base(data)
    {
    }

    public override string Execute()
    {
        string unitType = this.Data[1];
        this.unitRepository.RemoveUnit(unitType);

        return $"{unitType} retired!";
    }
}
