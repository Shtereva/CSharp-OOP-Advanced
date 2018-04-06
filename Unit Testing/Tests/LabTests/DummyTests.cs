using System;
using NUnit.Framework;

public class DummyTests
{
    private Axe axe;

    public DummyTests()
    {
        this.axe = new Axe(10, 10);
    }

    [Test]
    public void DummyLossesHealthAfterAttack()
    {
        var dummy = new Dummy(11, 10);
        this.axe.Attack(dummy);
        Assert.AreEqual(1, dummy.Health);
    }

    [Test]
    public void DeadDummyThrowsExceptionIfAttacked()
    {
        var dummy = new Dummy(0, 10);

        Assert.Throws<InvalidOperationException>(() => this.axe.Attack(dummy));
    }

    [Test]
    public void DeadDummyGiveExpirience()
    {
        var dummy = new Dummy(5, 10);
        this.axe.Attack(dummy);

        int expirience = dummy.GiveExperience();

        Assert.AreEqual(10, expirience);
    }

    [Test]
    public void AliveDummyDoNotGiveExpirience()
    {
        var dummy = new Dummy(11, 10);
        this.axe.Attack(dummy);

        Assert.Throws<InvalidOperationException>(() => dummy.GiveExperience());
    }
}
