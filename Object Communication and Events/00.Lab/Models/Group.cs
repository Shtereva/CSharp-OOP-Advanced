using System.Collections.Generic;

public class Group : IAttackGroup
{
    private List<IAttacker> attackers;

    public Group()
    {
        this.attackers = new List<IAttacker>();
    }

    public void AddMember(IAttacker attacker)
    {
        this.attackers.Add(attacker);
    }

    public void GroupTarget(ITarget target)
    {
        throw new System.NotImplementedException();
    }

    public void GroupAttack()
    {
        foreach (var attacker in this.attackers)
        {
            attacker.Attack();
        }
    }
}
