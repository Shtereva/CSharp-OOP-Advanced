public class Sword : Weapon
{
    private const int MIN_DAMAGE = 4;
    private const int MAX_DAMAGE = 6;
    private const int NUMBER_OF_SOCKETS = 3;

    public Sword(WeaponRarety rarity, string name)
        : base(rarity, name, MIN_DAMAGE, MAX_DAMAGE, new IGem[NUMBER_OF_SOCKETS])
    {
    }
}
