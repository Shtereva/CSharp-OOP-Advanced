using System;
using NUnit.Framework;

public class AxeTests
{
    private Axe axe;

    [Test]
    public void AxeLossesDurabilityAfterAttack()
    {
        this.axe = new Axe(10, 10);

        this.axe.Attack(new Dummy(10, 10));
        Assert.AreEqual(9, this.axe.DurabilityPoints, "Axe durability doestn't change after attack.");

        this.axe.Attack(new Dummy(10, 10));
        Assert.AreEqual(8, this.axe.DurabilityPoints, "Axe durability doestn't change after attack.");
    }

    [Test]
    public void AttackWithBrockenAxe()
    {
        this.axe = new Axe(10, 0);

        Assert.Throws<InvalidOperationException>(() => this.axe.Attack(new Dummy(10, 10)));
    }
}
