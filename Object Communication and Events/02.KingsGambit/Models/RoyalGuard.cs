using System;

public class RoyalGuard : IKillable
{
    private const int HitsToDie = 3;

    private bool isAlive;
    private int hits;

    public int Hits => this.hits;
    public bool IsAlive => this.isAlive;
    public string Name { get; }

    public RoyalGuard(string name)
    {
        this.Name = name;
        this.isAlive = true;
    }

    public void Die()
    {
        this.hits++;

        if (this.Hits == HitsToDie)
        {
            this.isAlive = false;
        }
    }

    public void RespondToAttack()
    {
        Console.WriteLine($"Royal Guard {this.Name} is defending!");
    }
}
