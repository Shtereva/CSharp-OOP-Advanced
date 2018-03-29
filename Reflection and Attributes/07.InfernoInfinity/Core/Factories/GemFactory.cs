using System;

public class GemFactory : IGemFactory
{
    public IGem CreateUnit(string gemType)
    {
        var args = gemType.Split();

        var clarity = Enum.Parse<GemClarity>(args[0]);
        string type = args[1];

        var gemInfo = Type.GetType(type);

        var gem = Activator.CreateInstance(gemInfo, new object[] { clarity });

        return (IGem) gem;
    }
}
