using System;

public class WeaponFactory : IWeaponFactory
{
    public IWeapon CreateUnit(string weaponType, string weaponName)
    {
        var args = weaponType.Split();

        var rarety = Enum.Parse<WeaponRarety>(args[0]);
        string type = args[1];

        var weaponInfo = Type.GetType(type);

        var weapon = Activator.CreateInstance(weaponInfo, new object[] {rarety, weaponName});

        return (IWeapon)weapon;
    }
}
