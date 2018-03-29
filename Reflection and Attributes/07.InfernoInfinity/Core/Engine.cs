using System;
public class Engine : IRunable
{
    private ICommandInterpreter interpreter;

    public Engine()
    {
        this.interpreter = new CommandInterpreter(new WeaponRepository(), new WeaponFactory(), new GemFactory());
    }

    public void Run()
    {
        IOManager.ReadInput(this.interpreter);
    }
}
