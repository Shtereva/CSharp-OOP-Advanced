public class GroupTargetCommand : ICommand
{
    private IAttackGroup atackGroup;
    private ITarget target;

    public GroupTargetCommand(IAttackGroup atackGroup, ITarget target)
    {
        this.atackGroup = atackGroup;
        this.target = target;
    }

    public void Execute()
    {
        throw new System.NotImplementedException();
    }
}
