public class Amethyst : Gem
{
    private const int STRENGTH = 2;
    private const int AGILITY = 8;
    private const int VITALITY = 4;

    public Amethyst(GemClarity clarity) 
        : base(clarity, STRENGTH, AGILITY, VITALITY)
    {
    }
}
