using System.Collections.Generic;

public delegate void AttackHandler();

public interface IAttackable : INameable
{
    event AttackHandler OnAttack;

    ICollection<IKillable> Players { get; }

    void Attack();

    void Kill(string name);

    void RespondToAttack();

    void AddPlayer(IKillable player);
}
