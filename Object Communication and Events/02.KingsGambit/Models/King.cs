using System;
using System.Collections.Generic;
using System.Linq;

public class King : IAttackable
{
    private ICollection<IKillable> players;

    public string Name { get; }

    public event AttackHandler OnAttack;

    public ICollection<IKillable> Players => this.players;

    public King(string name)
    {
        this.Name = name;
        this.players = new List<IKillable>();
        this.OnAttack += this.RespondToAttack;
    }

    public void Attack()
    {
        this.OnAttack.Invoke();
    }

    public void Kill(string name)
    {
        var player = this.Players.FirstOrDefault(p => p.Name == name);

        player.Die();

        if (!player.IsAlive)
        {
            this.OnAttack -= player.RespondToAttack;
        }
    }

    public void AddPlayer(IKillable player)
    {
        this.OnAttack += player.RespondToAttack;
        this.Players.Add(player);
    }

    public void RespondToAttack()
    {
       Console.WriteLine($"King {this.Name} is under attack!");
    }
}
