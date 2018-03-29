using System;
using System.Linq;
using System.Reflection;

public class CommandInterpreter : ICommandInterpreter
{
    private const string PREFIX = "Command";

    private IRepository weaponRepository;
    private IWeaponFactory weaponFactory;
    private IGemFactory gemFactory;

    public CommandInterpreter(IRepository weaRepository, IWeaponFactory weaponFactory, IGemFactory gemFactory)
    {
        this.weaponRepository = weaRepository;
        this.weaponFactory = weaponFactory;
        this.gemFactory = gemFactory;
    }

    public ICommand InterpretCommand(string[] data, string commandName)
    {
        var commandType = Type.GetType(commandName + PREFIX);

        if (commandType == null)
        {
            throw new InvalidOperationException("Invalid command");
        }

        var parameters = new object[]
        {
            data
        };

        var currentCommand = Activator.CreateInstance(commandType, parameters);

        var command = InjectDependencies(currentCommand);

        return command;
    }

    private ICommand InjectDependencies(object currentCommand)
    {
        var commandFields = currentCommand
            .GetType()
            .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
            .Where(f => f.GetCustomAttributes<InjectAttribute>() != null);

        var interpreterFields = this
            .GetType()
            .GetFields(BindingFlags.Instance | BindingFlags.NonPublic);

        foreach (var commandField in commandFields)
        {
            var field = interpreterFields
                .SingleOrDefault(f => f.FieldType == commandField.FieldType)
                .GetValue(this);

            commandField.SetValue(currentCommand, field);
        }

        return (ICommand)currentCommand;
    }
}
