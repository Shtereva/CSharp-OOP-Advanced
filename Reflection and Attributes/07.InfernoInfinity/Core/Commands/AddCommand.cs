public class AddCommand : Command
{
    [Inject]
    private IRepository weaponRepository;

    [Inject] private IGemFactory gemFactory;

    public AddCommand(string[] data) 
        : base(data)
    {
    }

    public override void Execute()
    {
        string weapoName = this.Data[0];
        int index = int.Parse(this.Data[1]);
        string gemType = this.Data[2];

        var gem = this.gemFactory.CreateUnit(gemType);
        this.weaponRepository.Add(weapoName, index, gem);
    }
}
