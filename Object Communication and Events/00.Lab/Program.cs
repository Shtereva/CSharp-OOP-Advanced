
using System.Linq;

public class Program
{
    public static void Main()
    {
        Logger combatLogger = new CombatLogger();
        Logger eventLogger = new EventLogger();

        combatLogger.SetSuccessor(eventLogger);

        IAttackGroup group = new Group();

        group.AddMember(new Warrior("gosho", 10, combatLogger));
        group.AddMember(new Warrior("Rolo", 15, combatLogger));

        var dragon = new Dragon("Peter", 200, 25, combatLogger);

        IExecutor executor = new CommandExecutor();
        
        ICommand groupTarget = new GroupTargetCommand(group, dragon);
        ICommand groupAttack = new GroupAttackCommand(group);
    }
}
