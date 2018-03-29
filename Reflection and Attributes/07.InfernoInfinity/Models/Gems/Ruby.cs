public class Ruby : Gem
{
    private const int STRENGTH = 7;
    private const int AGILITY = 2;
    private const int VITALITY = 5;

    public Ruby(GemClarity clarity) 
        : base(clarity, STRENGTH, AGILITY, VITALITY)
    {
    }
}
