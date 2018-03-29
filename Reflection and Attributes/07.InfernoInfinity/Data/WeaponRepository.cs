using System.Collections.Generic;
using System.Linq;

public class WeaponRepository : IRepository
{
    private IList<Weapon> weapons;

    public WeaponRepository()
    {
        this.weapons = new List<Weapon>();
    }

    public void Create(IWeapon weapon)
    {
        this.weapons.Add((Weapon)weapon);
    }

    public void Add(string weaponName, int socketIndex, IGem gem)
    {
        this.weapons
            .Single(w => w.Name == weaponName)
            .AddGem(gem, socketIndex);

    }

    public void Remove(string weaponName, int socketIndex)
    {
        this.weapons
            .Single(w => w.Name == weaponName)
            .RemoveGem(socketIndex);
    }

    public void Print(string weaponName)
    {
        IOManager.WriteOutput(this.weapons.SingleOrDefault(w => w.Name == weaponName));
    }
}
