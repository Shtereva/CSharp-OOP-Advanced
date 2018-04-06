public interface IWeapon
{
    int DurabilityPoints { get; }

    void Attack(ITarget target);
}
