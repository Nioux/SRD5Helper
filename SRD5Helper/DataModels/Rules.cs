using SRD5Helper.Tools;
using SRD5Helper.ViewModels;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Numerics;
using System.Text.Json.Serialization;
using YamlDotNet.Serialization;
using Library = SRD5Helper.Resources.Library;

namespace SRD5Helper.DataModels;
/*
public struct PropertyPath
{
    public static PropertyPath _Abilities = nameof(PlayerCharacter.Abilities);
    
    public static PropertyPath _Abilities_Strength = _Abilities + nameof(PlayerCharacter.Abilities.Strength);
    public static PropertyPath _Abilities_Strength_Score = _Abilities_Strength + nameof(PlayerCharacter.Abilities.Strength.Score);
    public static PropertyPath _Abilities_Strength_Mod = _Abilities_Strength + nameof(PlayerCharacter.Abilities.Strength.Mod);
    public static PropertyPath _Abilities_Strength_SaveProficiency = _Abilities_Strength + nameof(PlayerCharacter.Abilities.Strength.SaveProficiency);
    public static PropertyPath _Abilities_Strength_Save = _Abilities_Strength + nameof(PlayerCharacter.Abilities.Strength.Save);
    
    public static PropertyPath _Abilities_Dexterity = _Abilities + nameof(PlayerCharacter.Abilities.Dexterity);
    public static PropertyPath _Abilities_Dexterity_Score = _Abilities_Dexterity + nameof(PlayerCharacter.Abilities.Dexterity.Score);
    public static PropertyPath _Abilities_Dexterity_Mod = _Abilities_Dexterity + nameof(PlayerCharacter.Abilities.Dexterity.Mod);
    public static PropertyPath _Abilities_Dexterity_SaveProficiency = _Abilities_Dexterity + nameof(PlayerCharacter.Abilities.Dexterity.SaveProficiency);
    public static PropertyPath _Abilities_Dexterity_Save = _Abilities_Dexterity + nameof(PlayerCharacter.Abilities.Dexterity.Save);

    public static PropertyPath _Skills = nameof(Skills);





    public PropertyPath(params string[] target)
    {
        Path = target;
    }
    public string[] Path { get; init; }

    public static implicit operator PropertyPath(string target) { return new PropertyPath(new[] { target }); }
    public static implicit operator PropertyPath(string[] target) { return new PropertyPath(target); }
    public static PropertyPath operator +(PropertyPath a, PropertyPath b) => a.Concat(b);
    public static bool operator ==(PropertyPath a, PropertyPath b) => ((a.StringPath) == (b.StringPath));
    public static bool operator !=(PropertyPath a, PropertyPath b) => (a.StringPath != b.StringPath);

    public PropertyPath Concat(PropertyPath propertyPath)
    {
        return Concat(propertyPath.Path);
    }
    public PropertyPath Concat(params string[] path)
    {
        if(Path == null)
        {
            return new PropertyPath(path);
        }
        if (path.Length > 0)
        {
            return new PropertyPath(Path.Concat(path).ToArray());
        }
        return new PropertyPath(Path);
    }

    public string StringPath
    {
        get
        {
            if (Path != null && Path.Length > 0)
            {
                string path = Path[0];
                for (int i = 1; i < Path.Length; i++)
                {
                    path += $".{Path[i]}";
                }
                return path;
            }
            return null;
        }
    }
    public override string ToString()
    {
        return StringPath;
    }
}
*/
public static class RulesExtensions
{
    public static string TrimAndJoin(this IEnumerable<string> strings, char separator)
    {
        return string.Join(separator, strings.Where(s => !string.IsNullOrEmpty(s)).Select(s => s.Trim(separator)));
    }
    public static string ToString(this IEnumerable<Rule> rules, BaseModel sender)
    {
        //return String.Join(" ", rules.Select(rule => rule.ToString(sender)));
        return rules.Select(rule => rule.ToString(sender)).TrimAndJoin(' ');
    }

    public static string ToMarkdownTitle(this string title, int level = 1)
    {
        return title.PadLeft(1).PadLeft(level, '#');
    }
    public static string ToMarkdownList(this IEnumerable<string> strings)
    {
        return strings.ToMarkdown(prefix: "* ", separator: "\n* ");
    }
    public static string ToMarkdown(this IEnumerable<string> strings, string separator = "", string prefix = "", string suffix = "")
    {
        return prefix + string.Join(separator, strings) + suffix;
    }
}

public abstract class Rule
{
    [YamlIgnore, JsonIgnore]
    public virtual string ID { get; init; }

    [YamlIgnore, JsonIgnore]
    public virtual string Name => Library.Rules.ResourceManager.GetName(ID);
    //    public PropertyPath Target { get; init; }

    [YamlIgnore, JsonIgnore]    
    public virtual string TargetPropertyName { get; init; }
    
    [YamlIgnore, JsonIgnore]
    public virtual string TargetObjectID { get; init; }
    
    [YamlIgnore, JsonIgnore]
    public virtual Type TargetObjectType { get; init; }

    [YamlIgnore, JsonIgnore]
    public virtual string[] DependsOn { get; init; }

    [YamlIgnore, JsonIgnore]
    public virtual Func<BaseModel, bool> CustomCondition { get; init; }
    
    [YamlIgnore, JsonIgnore]
    public virtual Func<PlayerCharacter, object> TargetObject { get; init; }


    [YamlIgnore, JsonIgnore]
    public virtual Func<string, BaseModel, bool> IsRuled => (string targetPropertyName, BaseModel sender) =>
    {
        if(TargetPropertyName != null && targetPropertyName != TargetPropertyName)
        {
            return false;
        }
        if(TargetObjectType != null && TargetObjectType != sender.GetType())
        {
            return false;
        }
        if(TargetObject != null && !(TargetObject.Invoke(sender.PC).Equals(sender)))
        {
            return false;
        }
        if(CustomCondition != null && !CustomCondition.Invoke(sender))
        {
            return false;
        }
        return true;
    };
    
    
    /*
    public Func<PlayerCharacter, BaseModel> Model => pc => pc.Abilities.Strength;
    public bool IsRullllled(BaseModel sender, string propertyName)
    {
        var receiver = Model.Invoke(sender.PC);
        if(receiver == sender)
        {
            return true;
        }
        return false;
    }
    */


    //public virtual bool IsRuled(PropertyPath target, object self, BaseModel sender)
    //{
    //    return target == Target;
    //}
    public abstract object GetResult(BaseModel sender);

    public abstract string ToString(BaseModel sender);
}
public class BoolRule : Rule
{
    [YamlIgnore, JsonIgnore]
    
    public Func<BaseModel, bool> Callback { get; init; }

    public override object GetResult(BaseModel sender)
    {
        return Callback(sender);
    }

    public override string ToString(BaseModel sender)
    {
        var result = (bool)GetResult(sender);
        return result ? Name : string.Empty;
    }
}

public class SkillProficiencyRule : BoolRule
{
    public SkillProficiencyRule()
    {
        TargetPropertyName = nameof(Skill.Proficiency);
        Callback = sender => true; // DataService.Const(true);
    }
}
/*
public class IntRule : Rule
{
    [YamlIgnore, JsonIgnore]
    
    public Func<BaseModel, int> Callback { get; init; }


    public override object GetResult(BaseModel sender)
    {
        return Callback(sender);
    }

    public override string ToString(BaseModel sender)
    {
        return $"{GetResult(sender):+0;-#} ({Name})";
    }
}
*/
public class NumberRule<T> : Rule where T : INumber<T>
{
    [YamlIgnore, JsonIgnore]

    public Func<BaseModel, T> Callback { get; init; }


    public override object GetResult(BaseModel sender)
    {
        var result = Callback(sender);
        return new AnnotatedNumber<T> { Value = result, Name = this.Name, Description = $"{result:+0;-#} ({Name})"};
    }

    public override string ToString(BaseModel sender)
    {
        return (GetResult(sender) as AnnotatedNumber<T>).Description;
    }
}

public class IntRule : NumberRule<int>
{

}
public class AnnotatedNumber<T> where T : INumber<T> // IFormattable
{
    public T Value { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public static implicit operator AnnotatedNumber<T>(T value) => new AnnotatedNumber<T> { Value = value };
    public static implicit operator T(AnnotatedNumber<T> value) => value.Value;
    public static AnnotatedNumber<T> operator +(AnnotatedNumber<T> left, AnnotatedNumber<T> right) => new AnnotatedNumber<T> { Value = left.Value + right.Value, Description = left.Description + " " + right.Description };

    public override string ToString() {
        return ToString("+0;-#");
    }
    public string ToString([StringSyntax(StringSyntaxAttribute.NumericFormat)] string? format)
    {
        return Value.ToString(format, null);
    }

}

public class StringRule : Rule
{
    [YamlIgnore, JsonIgnore]
    
    public Func<BaseModel, IEnumerable<string>> Callback { get; init; }


    public override object GetResult(BaseModel sender)
    {
        return Callback(sender);
    }

    public override string ToString(BaseModel sender)
    {
        return $"{GetResult(sender):+0;-#} ({Name})";
    }
}

public class EquipmentRule : Rule
{
    [YamlIgnore, JsonIgnore]
    
    public virtual Func<BaseModel, EquipmentTypeRef> Callback { get; init; }


    public override object GetResult(BaseModel sender)
    {
        return Callback(sender);
    }

    public override string ToString(BaseModel sender)
    {
        return $"{GetResult(sender)} ({Name})";
    }
}

public class EquipmentProficiencyRule : EquipmentRule
{
    public override string Name { get => "Maitrise de " + Library.Equipments.longsword; }
    public override Func<PlayerCharacter, object> TargetObject => pc => pc;
    public override string TargetPropertyName => nameof(PlayerCharacter.EquipmentProficiencies);
    public override Func<BaseModel, EquipmentTypeRef> Callback => (sender) => Library.Equipments.longsword;

}

//public class FuncRule : Rule
//{
//    public Func<object, BaseModel, object> Callback { get; init; }
//    public Func<int, BaseModel, int> IntCallback { get; init; }
//    public Func<long, BaseModel, long> LongCallback { get; init; }
//    public Func<bool, BaseModel, bool> BoolCallback { get; init; }
//    public Func<string, BaseModel, string> StringCallback { get; init; }

//    public Func<AdvantageNumber, BaseModel, AdvantageNumber> AdvantageCallback { get; init; }

//    public override object ApplyRule(object self, BaseModel sender)
//    {
//        if (self.GetType() == typeof(int))
//        {
//            return IntCallback((int)self, sender);
//        }
//        if (self.GetType() == typeof(long))
//        {
//            return LongCallback((long)self, sender);
//        }
//        if (self.GetType() == typeof(bool))
//        {
//            return BoolCallback((bool)self, sender);
//        }
//        if (self.GetType() == typeof(string))
//        {
//            return StringCallback((string)self, sender);
//        }
//        if (self is AdvantageNumber)
//        {
//            return AdvantageCallback(self as AdvantageNumber, sender);
//        }
//        return Callback(self, sender);
//    }
//}

//public class ScriptRule : Rule
//{
//    public string Script { get; init; }

//    public override object ApplyRule(object self, BaseModel sender)
//    {
//        var engine = new Jint.Engine().SetValue("self", self).SetValue("sender", sender);
//        return engine.Evaluate(Script).ToObject();
//        /*switch(output.Type)
//        {
//            case Jint.Runtime.Types.Number:
//                return Convert.ToInt32(output.ToObject());
//            case Jint.Runtime.Types.String:
//                return Convert.ToString(output.ToObject());
//            case Jint.Runtime.Types.Boolean:
//                return Convert.ToBoolean(output.ToObject());
//        }
//        return null;*/
//        //return output.ToObject();
//    }
//}
