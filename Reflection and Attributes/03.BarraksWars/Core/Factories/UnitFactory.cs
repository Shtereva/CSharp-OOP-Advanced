using System;

public class UnitFactory : IUnitFactory
{
    public IUnit CreateUnit(string unitType)
    {
        var classType = Type.GetType(unitType);

        var classInstance = Activator.CreateInstance(classType, false);

        return (IUnit) classInstance;
    }
}
