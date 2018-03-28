using System;
using System.Linq;
using System.Reflection;

public class CommandInterpreter : ICommandInterpreter
{
    private IUnitFactory unitFactory;
    private IRepository unitRepository;

    public CommandInterpreter(IUnitFactory unitFactory, IRepository unitRepository)
    {
        this.unitFactory = unitFactory;
        this.unitRepository = unitRepository;
    }

    public IExecutable InterpretCommand(string[] data, string commandName)
    {
        var assembly = Assembly.GetEntryAssembly();

        var commandTypes = assembly
            .GetTypes()
            .Where(t => t.GetInterfaces().Contains(typeof(IExecutable)))
            .ToArray();

        var commandType = commandTypes
            .SingleOrDefault(c => c.Name == $"{commandName}Command");

        if (commandType == null)
        {
            throw new InvalidOperationException("Invalid command");
        }

        object[] parameters = new object[]
        {
            data
        };

        var currentCommand = (IExecutable)Activator.CreateInstance(commandType, parameters);

        var command = this.InjectDependencies(currentCommand);

        return command;
    }

    private IExecutable InjectDependencies(IExecutable currentCommand)
    {
        var commandFileds = currentCommand
            .GetType()
            .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
            .Where(f => f.GetCustomAttributes<Inject>() != null)
            .ToArray();

        var thisFileds = this
            .GetType()
            .GetFields(BindingFlags.Instance | BindingFlags.NonPublic);

        foreach (var fieldInfo in commandFileds)
        {
            var field = thisFileds
                .SingleOrDefault(f => f.FieldType == fieldInfo.FieldType)
                .GetValue(this);

            fieldInfo.SetValue(currentCommand, field);
        }

        return currentCommand;
    }
}
