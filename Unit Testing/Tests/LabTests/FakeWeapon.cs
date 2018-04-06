using System;

public class FakeWeapon : IWeapon
{
    private const string ExceptionMessage = "Axe is broken.";
    private const int ReduseDurability = 1;

    public int AttackPoints { get; set; }

    public int DurabilityPoints { get; set; }

    public FakeWeapon()
    {
        this.AttackPoints = 10;
        this.DurabilityPoints = 10;
    }

    public void Attack(ITarget target)
    {
        if (this.DurabilityPoints <= 0)
        {
            throw new InvalidOperationException(ExceptionMessage);
        }

        target.TakeAttack(this.AttackPoints);
        this.DurabilityPoints -= ReduseDurability;
    }
}
