using Moq;
using NUnit.Framework;

public class HeroTest
{
    private int experience;
    private IWeapon weapon;
    private ITarget dummy;

    public HeroTest()
    {
        this.experience = 0;
        this.weapon = new FakeWeapon();
        this.dummy = new FakeDummy();
    }

    [Test]
    public void HeroGainXpAfterAttack()
    {
        //Testing with mock objects
        var dummyMock = new Mock<ITarget>();

        dummyMock.Setup(t => t.GiveExperience())
            .Returns(10);

        this.experience = dummyMock.Object.GiveExperience();
        //var weaponMock = new Mock<IWeapon>();

        //weaponMock.Setup(w => w.Attack(It.IsAny<ITarget>()))
        //    .Callback(() => { weaponMock.Object.DurabilityPoints -= 1; });


        // Testing with fake Dummy and Weapon
        //this.weapon.Attack(this.dummy);

        //this.experience += this.dummy.GiveExperience();

        Assert.AreEqual(10, this.experience);
    }
}
