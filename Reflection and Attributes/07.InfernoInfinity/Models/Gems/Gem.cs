public abstract class Gem : IGem
{
    private const int MIN_BONUS_STRENGTH = 2;
    private const int MAX_BONUS_STRENGTH = 3;

    private const int MIN_BONUS_AGILITY = 1;
    private const int MAX_BONUS_AGILITY = 4;

    private int strength;
    private int agility;
    private int vitality;
    private GemClarity clarity;

    protected Gem(GemClarity clarity, int strength, int agility, int vitality)
    {
        this.clarity = clarity;
        this.strength = strength;
        this.agility = agility;
        this.vitality = vitality;
    }

    public int Strength => this.strength + (int)this.clarity;
    public int Agility => this.agility + (int)this.clarity;
    public int Vitality => this.vitality + (int)this.clarity;

    public int AddBonusToMinDamage()
    {
        return (MIN_BONUS_STRENGTH * this.Strength) + (MIN_BONUS_AGILITY * this.Agility);
    }

    public int AddBonusToMaxDamage()
    {
        return (MAX_BONUS_STRENGTH * this.Strength) + (MAX_BONUS_AGILITY * this.Agility);
    }
}
