public interface ICommandInterpreter
{
    ICommand InterpretCommand(string[] data, string commandName);
}
