public class RemoveCommand : Command
{
    [Inject]
    private IRepository weaponRepository;

    public RemoveCommand(string[] data) : base(data)
    {
    }

    public override void Execute()
    {
        string weapoName = this.Data[0];
        int index = int.Parse(this.Data[1]);

        this.weaponRepository.Remove(weapoName, index);
    }
}
