using System;

public class FakeDummy : ITarget
{
    public int Health { get; set; }
    public int Experience { get; set; }

    public FakeDummy()
    {
        this.Health = 5;
        this.Experience = 10;
    }

    public void TakeAttack(int attackPoints)
    {
        this.Health -= attackPoints;
    }

    public int GiveExperience()
    {
        return this.Experience;
    }

    public bool IsDead()
    {
        return this.Health <= 0;
    }
}
