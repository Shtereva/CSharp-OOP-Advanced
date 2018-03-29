public class Knife : Weapon
{
    private const int MIN_DAMAGE = 3;
    private const int MAX_DAMAGE = 4;
    private const int NUMBER_OF_SOCKETS = 2;

    public Knife(WeaponRarety rarity, string name)
        : base(rarity, name, MIN_DAMAGE, MAX_DAMAGE, new IGem[NUMBER_OF_SOCKETS])
    {
    }
}
