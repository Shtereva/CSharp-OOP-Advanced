public class Emerald : Gem
{
    private const int STRENGTH = 1;
    private const int AGILITY = 4;
    private const int VITALITY = 9;

    public Emerald(GemClarity clarity) 
        : base(clarity, STRENGTH, AGILITY, VITALITY)
    {
    }
}
