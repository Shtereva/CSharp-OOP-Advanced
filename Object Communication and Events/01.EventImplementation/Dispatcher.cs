public class Dispatcher : INameChangeable
{
    private string name;

    public event NameChangeEventHandler NameChange;

    public string Name
    {
        get => this.name;
        set
        {
            this.OnNameChange(new NameChangeEventArgs(value));
            this.name = value;
        }
    }

    public void OnNameChange(NameChangeEventArgs args)
    {
        this.NameChange.Invoke(this, args);
    }
}
