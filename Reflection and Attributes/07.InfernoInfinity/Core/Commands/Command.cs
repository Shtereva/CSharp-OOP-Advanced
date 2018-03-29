public abstract class Command : ICommand
{
    private string[] data;

    protected string[] Data
    {
        get => this.data;
        private set => this.data = value;
    }

    protected Command(string[] data)
    {
        this.Data = data;
    }

    public abstract void Execute();

}
