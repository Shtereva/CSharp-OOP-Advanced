﻿public class Axe : Weapon
{
    private const int MIN_DAMAGE = 5;
    private const int MAX_DAMAGE = 10;
    private const int NUMBER_OF_SOCKETS = 4;

    public Axe(WeaponRarety rarity, string name)
        : base(rarity, name, MIN_DAMAGE, MAX_DAMAGE, new IGem[NUMBER_OF_SOCKETS])
    {
    }
}
