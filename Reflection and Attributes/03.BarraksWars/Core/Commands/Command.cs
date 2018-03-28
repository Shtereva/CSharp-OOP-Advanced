public abstract class Command : IExecutable
{
    [Inject]
    private string[] data;

    protected Command(string[] data)
    {
        this.Data = data;
    }

    protected string[] Data
    {
        get => this.data;
        private set => this.data = value;
    }

    public abstract string Execute();
}
