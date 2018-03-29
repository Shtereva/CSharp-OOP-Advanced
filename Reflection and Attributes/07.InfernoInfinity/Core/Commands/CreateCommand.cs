public class CreateCommand : Command
{
    [Inject]
    private IRepository weaponRepository;

    [Inject]
    private IWeaponFactory weaponFactory;

    public CreateCommand(string[] data)
        : base(data)
    {
    }

    public override void Execute()
    {
        var weapon = this.weaponFactory.CreateUnit(this.Data[0], this.Data[1]);
        this.weaponRepository.Create(weapon);
    }

}
