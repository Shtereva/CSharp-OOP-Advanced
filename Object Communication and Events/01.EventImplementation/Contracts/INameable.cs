public delegate void NameChangeEventHandler(object sender, NameChangeEventArgs args);

public interface INameable
{
    event NameChangeEventHandler NameChange;

    string Name { get; set; }
}
