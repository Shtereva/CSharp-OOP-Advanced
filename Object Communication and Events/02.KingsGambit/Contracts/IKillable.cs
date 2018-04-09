public interface IKillable : INameable
{
    int Hits { get; }
    bool IsAlive { get; }

    void Die();

    void RespondToAttack();
}
