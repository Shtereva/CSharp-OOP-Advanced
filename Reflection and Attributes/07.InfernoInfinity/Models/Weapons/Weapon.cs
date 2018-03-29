using System.Linq;

public abstract class Weapon : IWeapon
{
    private string name;
    private int minDamage;
    private int maxDamage;
    private IGem[] sockets;
    private WeaponRarety rarity;

    protected Weapon(WeaponRarety rarity, string name, int minDamage, int maxDamage, IGem[] sockets)
    {
        this.rarity = rarity;
        this.name = name;
        this.minDamage = minDamage;
        this.maxDamage = maxDamage;
        this.sockets = sockets;
    }

    public string Name => this.name;

    public int MinDamage => this.minDamage * (int)this.rarity;

    public int MaxDamage => this.maxDamage * (int)this.rarity;

    public void AddGem(IGem gem, int index)
    {
        if (index >= 0 && index < this.sockets.Length)
        {
            this.sockets[index] = gem;
        }
    }

    public void RemoveGem(int index)
    {
        if (index >= 0 && index < this.sockets.Length && this.sockets[index] != null)
        {
            this.sockets[index] = null;
        }
    }

    public override string ToString()
    {
        var sockets = this.sockets
            .Cast<Gem>()
            .Where(g => g != null)
            .ToArray();

        int bonusMinDamage = sockets.Sum(g => g.AddBonusToMinDamage()) + this.MinDamage;

        int bonusMaxDamage = sockets.Sum(g => g.AddBonusToMaxDamage()) + this.MaxDamage;

        int strength = sockets.Sum(g => g.Strength);
        int agility = sockets.Sum(g => g.Agility);
        int vitality = sockets.Sum(g => g.Vitality);

        return $"{this.Name}: {bonusMinDamage}-{bonusMaxDamage} Damage, +{strength} Strength, +{agility} Agility, +{vitality} Vitality";
    }
}
