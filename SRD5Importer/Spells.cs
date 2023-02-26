using ICSharpCode.Decompiler.Util;
using Newtonsoft.Json.Converters;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using YamlDotNet.Serialization;

namespace MauiApp3;

[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum ClassID
{
    Barbarian,
    Bard,
    Cleric,
    Druid,
    Sorcerer,
    Fighter,
    Wizard,
    Monk,
    Shadowblade,
    Paladin,
    Ranger,
    Rogue,
    Witchblade,
    Warlock,
}
public struct SpellComponents
{
    public override string ToString()
    {
        var v = (Verbal ? "V, " : "");
        var s = (Somatic ? "S, " : "");
        var m = (Material ? $"M ({MaterialDescription})" : "");
        return (v + s + m).TrimEnd(' ', ',');
    }
    public bool Verbal { get; init; }

    public bool Somatic { get; init; }

    public bool Material { get; init; }

    public string MaterialDescription { get; set; }

}

// voir https://stackoverflow.com/questions/59059989/system-text-json-how-do-i-specify-a-custom-name-for-an-enum-value
/// <summary>
/// Ecole de magie
/// </summary>
[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum SpellSchool
{
    [EnumMember(Value = "abj")]
    Abjuration,
    [EnumMember(Value = "con")]
    Conjuration,
    [EnumMember(Value = "div")]
    Divination,
    [EnumMember(Value = "enc")]
    Enchantment,
    [EnumMember(Value = "evo")]
    Evocation,
    [EnumMember(Value = "ill")]
    Illusion,
    [EnumMember(Value = "nec")]
    Necromancy,
    [EnumMember(Value = "trs")]
    Transmutation,
}

[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum Attacks
{
    Melee,
    Ranged,
}
[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum AtHigherLevelsTypes
{
    BonusDamageDie,
    TargetNumber,
}
public struct AtHigherLevels
{
    public int Scale { get; set; }
    public AtHigherLevelsTypes Type { get; set; }
    public int Value { get; set; }
}

[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum SpellCategories
{
    Attack,
    Defense,
    Heal,
    Support,
    Utility,
}
public struct Source
{
    public string Book { get; set; }
    public int Page { get; set; }
}
[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum SaveSuccesses
{
    Negates,
    Half
}

[JsonConverter(typeof(JsonStringEnumMemberConverter))]
[Flags]
public enum ConditionID
{
    Prone,
    Deafened,
    Blinded,
    Charmed,
    Grappled,
    Poisoned,
    Restrained,
    Stunned,
    Unconscious,
    Incapacitated,
    Frightened,
    Invisible,
    Paralyzed,
    Petrified,

    Special,

    ExhaustionLevel1 = 0x10000,
    ExhaustionLevel2 = 0x20000,
    ExhaustionLevel3 = 0x40000,
    ExhaustionLevel4 = 0x80000,
    ExhaustionLevel5 = 0x100000,
    ExhaustionLevel6 = 0x200000,
    Exhausted = ExhaustionLevel1 | ExhaustionLevel2 | ExhaustionLevel3 | ExhaustionLevel4 | ExhaustionLevel5 | ExhaustionLevel6,
}

public struct Roll
{
    public static implicit operator Roll(string s) { return new Roll(s); }
    public static implicit operator string(Roll r) { return r.ToString(); }

    public Roll(string s)
    {
        if (s != null)
        {
            //var regex = new Regex("(?<diceNumber>\\d*)d(?<dieType>\\d*)(?<modifier>\\+|\\-\\d*)");
            var regex = new Regex("(?<diceNumber>\\d*)d(?<dieType>\\d*)");
            var m = regex.Match(s);
            if (m.Success)
            {
                //int.TryParse(m.Result("${diceNumber}"), out DiceNumber);
                //int.TryParse(m.Result("${dieType}"), out DieType);
                //int.TryParse(m.Result("${modifier}"), out Modifier);
                DiceNumber = int.Parse(m.Result("${diceNumber}"));
                int.TryParse(m.Result("${dieType}"), out DieType);
                //Modifier = int.Parse(m.Result("${modifier}"));
            }
        }
    }
    public int? DiceNumber;
    public int DieType;
    public int? Modifier;

    public override string ToString()
    {
        return (DiceNumber.HasValue ? DiceNumber.Value.ToString() : string.Empty)
            + $"d{DieType.ToString()}"
            + (Modifier.HasValue ? "" : string.Empty);
    }
}

public class RollJsonConverter : JsonConverter<Roll>
{
    public override Roll Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options)
    {
        var roll = reader.GetString();
        if(roll != null)
        {
            return new Roll(roll);
        }
        return null;
    }

    public override void Write(
        Utf8JsonWriter writer,
        Roll rollValue,
        JsonSerializerOptions options) =>
            writer.WriteStringValue(rollValue.ToString());
}

[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum DurationUnit
{
    //[JsonPropertyName("inst")]
    Inst,
    //[JsonPropertyName("round")]
    Round,
    //[JsonPropertyName("minute")]
    Minute,
    //[EnumMember(Value = "hour")]
    //[JsonPropertyName("hour")]
    Hour,
}

public struct Duration
{
    //[JsonPropertyName("value")]
    public int? Value { get; set; }
    //[JsonPropertyName("units")]
    public DurationUnit Units { get; set; }

    public override string ToString()
    {
        return $"{Units} {Value}";
    }
}

[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum RangeUnit
{
    Self,
    Touch,
    M,
}

public struct Range
{
    //[JsonPropertyName("value")]
    public int? Value { get; set; }
    //[JsonPropertyName("units")]
    public RangeUnit? Units { get; set; }

    public override string ToString()
    {
        return $"{Units} {Value}";
    }
}

[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum TargetUnit
{
    Any,
    Spec,
    M,
}

[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum TargetType
{
    Self,
    Object,
    Creature,
    Space,
    Square,
    Radius,
    Line,
    Sphere,
    Cone,
    Cylinder,
    Cube,
}


public struct Target
{
    //[JsonPropertyName("value")]
    public float? Value { get; set; }
    //[JsonPropertyName("units")]
    public TargetUnit? Units { get; set; }
    //[JsonPropertyName("type")]
    public TargetType? Type { get; set; }
    //[JsonPropertyName("override")]
    public string Override { get; set; }

    public override string ToString()
    {
        return $"{Units} {Value} {Type} {Override}";
    }
}
public struct Spell
{
    [JsonPropertyName("slug")]
    public string ID { get; init; }
    public override string ToString()
    {
        return Name;
    }

    [JsonPropertyName("title")]
    public string Name { get; init; }

    [JsonPropertyName("level")]
    public int Level { get; init; }

    [JsonPropertyName("school")]
    public SpellSchool School { get; init; }

    [JsonPropertyName("castingTime")]
    public string CastingTime { get; init; }

    [JsonPropertyName("reactionTrigger")]
    public string ReactionTrigger { get; init; }

    [JsonPropertyName("components")]
    public SpellComponents Components { get; init; }

    [JsonPropertyName("ritual")]
    public bool Ritual { get; init; }

    [JsonPropertyName("range")]
    public Range? Range { get; init; }

    [JsonPropertyName("duration")]
    public Duration? Duration { get; init; }

    [JsonPropertyName("concentration")]
    public bool Concentration { get; init; }

    //public string Target { get; init; }
    [JsonPropertyName("target")]
    public Target? Target { get; init; }

    [JsonPropertyName("aoeType")]
    public TargetType AoeType { get; init; }

    [JsonPropertyName("aoeSize")]
    public string AoeSize { get; init; }

    public Attacks? Attack { get; init; }

    public string DamageType { get; set; }

    public int? DamageDiceCount { get; set; }

    public string DamageDieType { get; set; }

    public string DamageModifier { get; set; }

    //public AbilityNameEnum Save { get; set; }
    public object Save { get; set; }

    [JsonPropertyName("condition")]
    public List<string> Conditions { get; set; }

    public SaveSuccesses SaveSuccess { get; set; }

    [YamlMember(Alias = "atHigherLevel")]
    public List<AtHigherLevels> AtHigherLevels { get; init; }

    public SpellCategories Category { get; init; }

    [JsonPropertyName("classesInitiation")]
    public List<string> Classes { get; init; }
    //public object Classes { get; set; }

    [JsonPropertyName("sources")]
    public List<string> JsonSources { get; init; }
    [JsonPropertyName("sourcePages")]
    public List<int> JsonSourcePages { get; init; }
    [JsonIgnore]
    public IReadOnlyList<Source> Sources
    {
        get
        {
            var pages = JsonSourcePages;
            return JsonSources.Select((book, index) => new Source { Book = book, Page = pages[index] }).ToList();
        }
    }

    [JsonPropertyName("appearance")]
    public string Appearance { get; init; }

    [JsonPropertyName("damage")]
    public Damage Damage { get; init; }

    public Body Body { get; init; }
    public Activation Activation { get; init; }

    public string ToCSharp()
    {
        var result = $@"
        new()
        {{
            ID = Library.Spells.{ID.Replace("-", "_")},
            Level = {Level},
            Classes = new()
            {{";
        foreach (var cl in Classes)
        {
            if (cl == "shadowblade")
            {
                result += $@"
                Library.Archetypes.{cl.ToLower()},";
            }
            else
            {
                result += $@"
                Library.Classes.{cl.ToLower()},";
            }
        }
        result += $@"
            }},
        }},";

        return result;
    }

    public void AddToResource(ResXResourceWriter resx)
    {
        resx.AddResource(ID, ID);
        resx.AddResource(ID + "-name", Name);
        resx.AddResource(ID + "-description", Appearance);
        resx.AddResource(ID + "-details", Body.ToString());
    }
}

[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum ActivationType
{
    Action,
    Bonus,
    Minute,
}
public struct Activation
{
    public ActivationType Type { get; init; }
    public int? Cost { get; init; }
    public object Condition { get; init; }
}

[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum BodyType
{
    Root,
    Element,
    Text,
}
public struct Body
{
    public BodyType Type { get; init; }
    public string Tag { get; init; }
    public string Value { get; init; }
    public Body[]? Children { get; init; }

    public override string ToString()
    {
        if(Type == BodyType.Text)
        {
            return Value;
        }
        var result = string.Empty;
        if (Children != null)
        {
            foreach (var child in Children)
            {
                result += child.ToString();
            }
        }
        return result;
    }
}

public struct Damage
{
    [JsonPropertyName("parts")]
    public string[][]? Parts { get; set; }

    [JsonIgnore]
    public DamagePart[]? DamageParts { get => Parts?.Select(part => new DamagePart { Roll = part[0], DamageType = part[1] })?.ToArray(); set => Parts = value?.Select(part => new string[] { part.Roll.ToString(), part.DamageType })?.ToArray(); }

    [JsonPropertyName("versatile")]
    public Roll? Versatile { get; set; }
}

public struct DamagePart
{
    public static implicit operator DamagePart(string[] ss) { return new DamagePart(ss); }
    public static implicit operator string[](DamagePart dp) { return dp.ToStrings(); }

    public Roll Roll { get; set; }
    public string DamageType { get; set; }

    public DamagePart(string[] ss)
    {
        Roll = ss[0];
        DamageType = ss[1];
    }

    public string[] ToStrings()
    {
        return new string[] { Roll, DamageType };
    }
}


