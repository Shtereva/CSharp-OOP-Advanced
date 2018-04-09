using System;

public class Footman : IKillable
{
    private const int HitsToDie = 2;

    private bool isAlive;
    private int hits;

    public int Hits => this.hits;
    public bool IsAlive => this.isAlive;
    public string Name { get; }

    public Footman(string name)
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
        Console.WriteLine($"Footman {this.Name} is panicking!");
    }
}
