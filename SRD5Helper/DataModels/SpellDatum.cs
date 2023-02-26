using SRD5Helper.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using YamlDotNet.Serialization;
using Library = SRD5Helper.Resources.Library;

namespace SRD5Helper.DataModels;

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
    [EnumMember(Value = "null")]
    Null,
    /// <summary>
    /// Abjuration
    /// </summary>
    [EnumMember(Value = "abj")]
    Abjuration,
    /// <summary>
    /// Conjuration
    /// </summary>
    [EnumMember(Value = "con")]
    Conjuration,
    /// <summary>
    /// Divination
    /// </summary>
    [EnumMember(Value = "div")]
    Divination,
    /// <summary>
    /// Enchantement
    /// </summary>
    [EnumMember(Value = "enc")]
    Enchantment,
    /// <summary>
    /// Evocation
    /// </summary>
    [EnumMember(Value = "evo")]
    Evocation,
    /// <summary>
    /// Illusion
    /// </summary>
    [EnumMember(Value = "ill")]
    Illusion,
    /// <summary>
    /// Nécromancie
    /// </summary>
    [EnumMember(Value = "nec")]
    Necromancy,
    /// <summary>
    /// Transmutation
    /// </summary>
    [EnumMember(Value = "trs")]
    Transmutation,
}

public enum AOETypes
{
    Null,
    Square,
    Cone,
    Cube,
    Cylinder,
    Line,
    Sphere,
}
public enum Attacks
{
    Null,
    Melee,
    Ranged,
}
public enum AtHigherLevelsTypes
{
    Null,
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
    [EnumMember(Value = "null")]
    Null,
    [EnumMember(Value = "attack")]
    Attack,
    [EnumMember(Value = "defense")]
    Defense,
    [EnumMember(Value = "heal")]
    Heal,
    [EnumMember(Value = "support")]
    Support,
    [EnumMember(Value = "utility")]
    Utility,
}
public struct Source
{
    public string Book { get; set; }
    public int Page { get; set; }
}
public enum SaveSuccesses
{
    Null,
    Negates,
    Half
}

[Flags]
public enum ConditionID
{
    Null,
    /// <summary>
    /// À terre
    /// </summary>
    [DisplayName("À terre")]
    Prone = 0x1,
    /// <summary>
    /// Assourdi
    /// </summary>
    [DisplayName("Assourdi")]
    Deafened = 0x2,
    /// <summary>
    /// Aveuglé
    /// </summary>
    [DisplayName("Aveuglé")]
    Blinded = 0x4,
    /// <summary>
    /// Charmé
    /// </summary>
    [DisplayName("Charmé")]
    Charmed = 0x8,
    /// <summary>
    /// Empoigné
    /// </summary>
    [DisplayName("Empoigné")]
    Grappled = 0x10,
    /// <summary>
    /// Empoisonné
    /// </summary>
    [DisplayName("Empoisonné")]
    Poisoned = 0x20,
    /// <summary>
    /// Entravé
    /// </summary>
    [DisplayName("Entravé")]
    Restrained = 0x40,
    /// <summary>
    /// Étourdi
    /// </summary>
    [DisplayName("Étourdi")]
    Stunned = 0x80,
    /// <summary>
    /// Inconscient
    /// </summary>
    [DisplayName("Inconscient")]
    Unconscious = 0x100,
    /// <summary>
    /// Neutralisé
    /// </summary>
    [DisplayName("Neutralisé")]
    Incapacitated = 0x200,
    /// <summary>
    /// Terrorisé
    /// </summary>
    [DisplayName("Terrorisé")]
    Frightened = 0x400,
    /// <summary>
    /// Invisible
    /// </summary>
    [DisplayName("Invisible")]
    Invisible = 0x800,
    /// <summary>
    /// Paralisé
    /// </summary>
    [DisplayName("Paralisé")]
    Paralyzed = 0x1000,
    /// <summary>
    /// Pétrifié
    /// </summary>
    [DisplayName("Pétrifié")]
    Petrified = 0x2000,

    [DisplayName("Spécial")]
    Special = 0x4000,

    [DisplayName("Fatigue niveau 1")]
    ExhaustionLevel1 = 0x10000,
    [DisplayName("Fatigue niveau 2")]
    ExhaustionLevel2 = 0x20000,
    [DisplayName("Fatigue niveau 3")]
    ExhaustionLevel3 = 0x40000,
    [DisplayName("Fatigue niveau 4")]
    ExhaustionLevel4 = 0x80000,
    [DisplayName("Fatigue niveau 5")]
    ExhaustionLevel5 = 0x100000,
    [DisplayName("Fatigue niveau 6")]
    ExhaustionLevel6 = 0x200000,
    [DisplayName("Fatigué")]
    Exhausted = ExhaustionLevel1 | ExhaustionLevel2 | ExhaustionLevel3 | ExhaustionLevel4 | ExhaustionLevel5 | ExhaustionLevel6,
}

public struct SpellDatum
{
    private string _name;
    public string Name { get => _name ??= Library.Spells.ResourceManager.GetName(ID); init => _name = value; }
    public string _description;
    public string Description { get => _description ??= Library.Spells.ResourceManager.GetDescription(ID); init => _description = value; }


    [JsonPropertyName("slug")]
    public string ID { get; init; }
    public override string ToString()
    {
        return Name;
    }

    //[JsonPropertyName("title")]
    //public string Name { get; init; }

    public int Level { get; init; }

    public SpellSchool School { get; init; }

    public string CastingTime { get; init; }

    public string ReactionTrigger { get; init; }

    public SpellComponents Components { get; init; }

    public bool Ritual { get; init; }

    public object Range { get; init; }

    public object Duration { get; init; }

    public bool Concentration { get; init; }

    //public string Target { get; init; }
    public object Target { get; init; }

    public AOETypes AoeType { get; init; }

    public string AoeSize { get; init; }

    public Attacks? Attack { get; init; }

    public string DamageType { get; set; }

    public int? DamageDiceCount { get; set; }

    public string DamageDieType { get; set; }

    public string DamageModifier { get; set; }

    //public AbilityNameEnum Save { get; set; }
    public object Save { get; set; }

    [JsonPropertyName("Condition")]
    public List<ConditionID> Conditions { get; set; }

    public SaveSuccesses SaveSuccess { get; set; }

    [YamlMember(Alias = "atHigherLevel")]
    public List<AtHigherLevels> AtHigherLevels { get; init; }

    public SpellCategories Category { get; init; }

    [JsonPropertyName("classesInitiation")]
    public List<string> Classes { get; init; }
    //public object Classes { get; set; }

    [JsonPropertyName("Sources")]
    public List<string> JsonSources { get; init; }
    [JsonPropertyName("SourcePages")]
    public List<int> JsonSourcePages { get; init; }
    
    public IReadOnlyList<Source> Sources
    {
        get
        {
            var pages = JsonSourcePages;
            return JsonSources?.Select((book, index) => new Source { Book = book, Page = pages[index] })?.ToList();
        }
    }

    public string Appearance { get; set; }

}
