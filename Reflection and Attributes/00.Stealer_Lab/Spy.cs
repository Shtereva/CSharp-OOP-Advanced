using System;
using System.Linq;
using System.Reflection;
using System.Text;

public class Spy
{
    public string StealFieldInfo(string nameOfClass, params string[] nameOfFields)
    {
        var sb = new StringBuilder();

        var classToInvestigate = Type.GetType(nameOfClass);
        var classInstance = Activator.CreateInstance(classToInvestigate, new object[0]);

        var fieldsToInvestigate = classInstance
                .GetType()
            .GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public)
            .Where(f => nameOfFields.Contains(f.Name));


        sb.AppendLine($"Class under investigation: {nameOfClass}");

        foreach (var fieldInfo in fieldsToInvestigate)
        {
            sb.AppendLine($"{fieldInfo.Name} = {fieldInfo.GetValue(classInstance)}");
        }
        return sb.ToString().Trim();
    }

    public string AnalyzeAcessModifiers(string className)
    {
        var classToInvestigate = Type.GetType(className);
        //var classToInvestigate = Activator.CreateInstance(className.GetType(), new object[] {});

        var fileds = classToInvestigate
            .GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static);

        var publicMethods = classToInvestigate
            .GetMethods(BindingFlags.Instance | BindingFlags.Public);

        var nonPublicMethods = classToInvestigate
            .GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);


        var sb = new StringBuilder();

        foreach (var fieldInfo in fileds)
        {
            sb.AppendLine($"{fieldInfo.Name} must be private!");
        }

        foreach (var nonPublicMethod in nonPublicMethods.Where(m => m.Name.StartsWith("get")))
        {
            sb.AppendLine($"{nonPublicMethod.Name} have to be public!");
        }

        foreach (var methodInfo in publicMethods.Where(m => m.Name.StartsWith("set")))
        {
            sb.AppendLine($"{methodInfo.Name} have to be private!");
        }

        return sb.ToString().Trim();
    }

    public string RevealPrivateMethods(string className)
    {
        var classType = Type.GetType(className);

        var nonPublicMethods = classType
            .GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

        var sb = new StringBuilder();

        sb.AppendLine($"All Private Methods of Class: {className}");
        sb.AppendLine("Base Class: " + classType.BaseType.Name);

        foreach (var nonPublicMethod in nonPublicMethods)
        {
            sb.AppendLine(nonPublicMethod.Name);
        }

        return sb.ToString().Trim();
    }

    public string CollectGettersAndSetters(string className)
    {
        var classType = Type.GetType(className);

        var methods = classType
            .GetMethods(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

        var sb = new StringBuilder();

        foreach (var method in methods.Where(m => m.Name.StartsWith("get")))
        {
            sb.AppendLine($"{method.Name} will return {method.ReturnType}");
        }

        foreach (var method in methods.Where(m => m.Name.StartsWith("set")))
        {
            sb.AppendLine($"{method.Name} will set field of {method.GetParameters().First().ParameterType.FullName}");
        }

        return sb.ToString().Trim();
    }
}
