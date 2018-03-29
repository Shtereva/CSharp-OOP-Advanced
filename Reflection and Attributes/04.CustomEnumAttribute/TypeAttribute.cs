using System;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Enum, AllowMultiple = true)]
[Serializable]
public class TypeAttribute : Attribute
{
    public string Type { get; set; }
    public string Category { get; set; }
    public string Descripion { get; set; }

    public TypeAttribute(string type, string category, string descripion)
    {
        this.Type = type;
        this.Category = category;
        this.Descripion = descripion;
    }
}
