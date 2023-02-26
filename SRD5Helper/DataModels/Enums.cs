using System.Runtime.Serialization;
using YamlDotNet.Serialization;

namespace SRD5Helper.DataModels; 
/*    public static class EnumExtensions
{

    // This extension method is broken out so you can use a similar pattern with 
    // other MetaData elements in the future. This is your base method for each.
    public static T GetAttribute<T>(this Enum value) where T : Attribute
    {
        if (value == null) return null;
        var type = value.GetType();
        var memberInfo = type.GetMember(value.ToString());
        var attributes = memberInfo[0].GetCustomAttributes(typeof(T), false);
        return attributes.Length > 0
          ? (T)attributes[0]
          : null;
    }

    // This method creates a specific call to the above method, requesting the
    // Description MetaData attribute.
    public static string ToDisplayName(this Enum value, GenreID? genre = null)
    {
        var attributeDisplayName = value?.GetAttribute<DisplayNameAttribute>();
        if (attributeDisplayName != null)
        {
            switch (genre)
            {
                case GenreID.Female:
                    return attributeDisplayName.FemaleName;
                case GenreID.Male:
                    return attributeDisplayName.MaleName;
                case GenreID.Neutral:
                    return attributeDisplayName.NeutralName;
                case GenreID.Inclusive:
                    return attributeDisplayName.InclusiveName;
            }
            return attributeDisplayName.Name;
        }
        return value?.ToString();
    }
}
*/
public enum GenderID
{
    Null,
    /// <summary>
    /// Féminin
    /// </summary>
    Female,
    /// <summary>
    /// Masculin
    /// </summary>
    Male,
    /// <summary>
    /// Neutre
    /// </summary>
    Neutral,
    /// <summary>
    /// Inclusif
    /// </summary>
    Inclusive,
}

//[AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
//public class GenredNameAttribute : Attribute
//{
//    public string FemaleName { get; set; }
//    public string MaleName { get; set; }
//    public string NeutralName { get; set; }
//}
[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.All, AllowMultiple = false)]
public class DisplayNameAttribute : Attribute
{
    public DisplayNameAttribute(string name = null)
    {
        Name = name;
    }
    /// <summary>
    /// Nom
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// Nom féminin
    /// </summary>
    public string FemaleName { get; set; }
    /// <summary>
    /// Nom masculin
    /// </summary>
    public string MaleName { get; set; }
    /// <summary>
    /// Nom neutre
    /// </summary>
    public string NeutralName { get; set; }
    /// <summary>
    /// Nom inclusif
    /// </summary>
    public string InclusiveName { get; set; }
}

/*
public enum ClassID
{
    Null,
    /// <summary>
    /// Barbare
    /// </summary>
    //[DisplayName("Barbare")]
    Barbarian,
    /// <summary>
    /// Barde
    /// </summary>
    //[DisplayName("Barde")]
    Bard,
    /// <summary>
    /// Clerc
    /// </summary>
    //[DisplayName("Clerc")]
    Cleric,
    /// <summary>
    /// Druide
    /// </summary>
    //[DisplayName(FemaleName = "Druidesse", MaleName = "Druide", NeutralName = "Druide·sse")]
    Druid,
    /// <summary>
    /// Ensorceleur
    /// </summary>
    //[DisplayName(FemaleName = "Ensorceleuse", MaleName = "Ensorceleur", NeutralName = "Ensorceleu·r·se")]
    Sorcerer,
    /// <summary>
    /// Guerrier
    /// </summary>
    //[DisplayName(FemaleName = "Guerrière", MaleName = "Guerrier", NeutralName = "Guerri·er·ère")]
    Fighter,
    /// <summary>
    /// Magicien
    /// </summary>
    //[DisplayName(FemaleName = "Magicienne", MaleName = "Magicien", NeutralName = "Magicien·ne")]
    Wizard,
    /// <summary>
    /// Moine
    /// </summary>
    //[DisplayName("Moine")]
    Monk,
    /// <summary>
    /// Ombrelame
    /// </summary>
    //[DisplayName("Ombrelame")]
    Shadowblade,
    /// <summary>
    /// Paladin
    /// </summary>
    //[DisplayName("Paladin")]
    Paladin,
    /// <summary>
    /// Rôdeur
    /// </summary>
    //[DisplayName("Rôdeur")]
    Ranger,
    /// <summary>
    /// Roublard
    /// </summary>
    //[DisplayName("Roublard")]
    Rogue,
    /// <summary>
    /// Sorcelame
    /// </summary>
    //[DisplayName("Sorcelame")]
    Witchblade,
    /// <summary>
    /// Sorcier
    /// </summary>
    //[DisplayName("Sorcier")]
    Warlock,
}
*/
/*
public enum BaseOriginID
{
    Null,
    //[DisplayName("Demi-Elfe")]
    HalfElf,
    //[DisplayName("Demi-Orc")]
    HalfOrc,
    //[DisplayName("Elfe")]
    Elf,
    //[DisplayName("Gnome")]
    Gnome,
    //[DisplayName(FemaleName = "Halfeline", MaleName = "Halfelin", NeutralName = "Halfelin-e")]
    Halfling,
    //[DisplayName(FemaleName = "Humaine", MaleName = "Humain", NeutralName = "Humain-e")]
    Human,
    //[DisplayName(FemaleName = "Naine", MaleName = "Nain", NeutralName = "Nain-e")]
    Dwarf,
    //[DisplayName(FemaleName = "Drakh", MaleName = "Drakh", NeutralName = "Drakh")]
    Dragonborn,
    //Gobelin,
    //[DisplayName("Tiefelin")]
    Tiefling,
    //[DisplayName("Félys")]
    Felys,
}
public enum OriginID
{
    Null,
    /// <summary>
    /// Demi-elfe
    /// </summary>
    //[DisplayName("Demi-Elfe")]
    HalfElf,
    /// <summary>
    /// Demi-orc
    /// </summary>
    //[DisplayName("Demi-Orc")]
    HalfOrc,
    /// <summary>
    /// Elfe
    /// </summary>
    //[DisplayName("Elfe")]
    Elf,
    //[DisplayName("Elfe d'Aether")]
    AetherElf,
    //[DisplayName("Elfe de fer")]
    IronElf,
    //[DisplayName("Elfe des sylves")]
    SylvanElf,
    /// <summary>
    /// Gnome
    /// </summary>
    //[DisplayName("Gnome")]
    Gnome,
    //[DisplayName("Gnome des fées")]
    FeyGnome,
    //[DisplayName("Gnome des lacs")]
    LakeGnome,
    //[DisplayName("Gnome des rochers")]
    RockGnome,
    /// <summary>
    /// Halfelin
    /// </summary>
    //[DisplayName(FemaleName = "Halfeline", MaleName = "Halfelin", NeutralName = "Halfelin-e")]
    Halfling,
    /// <summary>
    /// Humain
    /// </summary>
    //[DisplayName(FemaleName = "Humaine", MaleName = "Humain", NeutralName = "Humain-e")]
    Human,
    /// <summary>
    /// Nain
    /// </summary>
    //[DisplayName(FemaleName = "Naine", MaleName = "Nain", NeutralName = "Nain-e")]
    Dwarf,
    /// <summary>
    /// Drakh
    /// </summary>
    //[DisplayName(FemaleName = "Drakh", MaleName = "Drakh", NeutralName = "Drakh")]
    Dragonborn,
    //Gobelin,
    //[DisplayName("Tiefelin")]
    Tiefling,
    /// <summary>
    /// Félys
    /// </summary>
    //[DisplayName("Félys")]
    Felys,
}
*/

public enum AbilityID
{
    Null,
    /// <summary>
    /// Force
    /// </summary>
    [YamlMember(Alias = "str")]
    Strength,
    /// <summary>
    /// Dextérité
    /// </summary>
    [YamlMember(Alias = "dex")]
    Dexterity,
    /// <summary>
    /// Constitution
    /// </summary>
    [YamlMember(Alias = "con")]
    Constitution,
    /// <summary>
    /// Intelligence
    /// </summary>
    [YamlMember(Alias = "int")]
    Intelligence,
    /// <summary>
    /// Sagesse
    /// </summary>
    [YamlMember(Alias = "wis")]
    Wisdom,
    /// <summary>
    /// Charisme
    /// </summary>
    [YamlMember(Alias = "cha")]
    Charisma,
}

public enum SkillID
{
    Null,
    /// <summary>
    /// Acrobaties (DEX)
    /// </summary>
    Acrobatics,
    /// <summary>
    /// Arcanes (INT)
    /// </summary>
    Arcana,
    /// <summary>
    /// Athlétisme (FOR)
    /// </summary>
    Athletics,
    /// <summary>
    /// Discrétion (DEX)
    /// </summary>
    Stealth,
    /// <summary>
    /// Dressage (SAG)
    /// </summary>
    Animal_Handling,
    /// <summary>
    /// Escamotage (DEX)
    /// </summary>
    Sleight_Of_Hand,
    /// <summary>
    /// Histoire (INT)
    /// </summary>
    History,
    /// <summary>
    /// Intimidation (CHA)
    /// </summary>
    Intimidation,
    /// <summary>
    /// Investigation (INT)
    /// </summary>
    Investigation,
    /// <summary>
    /// Médecine (SAG)
    /// </summary>
    Medicine,
    /// <summary>
    /// Nature (INT)
    /// </summary>
    Nature,
    /// <summary>
    /// Perception (SAG)
    /// </summary>
    Perception,
    /// <summary>
    /// Perspicacité (SAG)
    /// </summary>
    Insight,
    /// <summary>
    /// Persuasion (CHA)
    /// </summary>
    Persuasion,
    /// <summary>
    /// Religion (INT)
    /// </summary>
    Religion,
    /// <summary>
    /// Représentation (CHA)
    /// </summary>
    Performance,
    /// <summary>
    /// Supercherie (CHA)
    /// </summary>
    Deception,
    /// <summary>
    /// Survie (SAG)
    /// </summary>
    Survival,
}

[Flags]
public enum EquipmentType
{
    Null,
    /// <summary>
    /// Munitions
    /// </summary>
    Ammunition = 0x1,
    /// <summary>
    /// Vêtements
    /// </summary>
    Clothes = 0x2,
    /// <summary>
    /// Focalisateur arcanique
    /// </summary>
    Arcane_Focus = 0x4,
    /// <summary>
    /// Focalisateur druidique
    /// </summary>
    Druidic_Focus = 0x8,
    /// <summary>
    /// Symbole sacré
    /// </summary>
    Holy_Symbol = 0x10,
    /// <summary>
    /// Récipient
    /// </summary>
    Container = 0x20,
    /// <summary>
    /// Outils d'artisan
    /// </summary>
    Artisans_Tools = 0x40,
    /// <summary>
    /// Jeux
    /// </summary>
    Gaming_Set = 0x80,
    /// <summary>
    /// Instruments de musique
    /// </summary>
    Musical_Instrument = 0x100,
    /// <summary>
    /// Monture
    /// </summary>
    Mount = 0x200,
    /// <summary>
    /// Equipement pour véhicule
    /// </summary>
    Tack = 0x400,
    /// <summary>
    /// Sellerie
    /// </summary>
    Harness = 0x800,
    /// <summary>
    /// Véhicule à traction
    /// </summary>
    Drawn_Vehicle = 0x1000,
    /// <summary>
    /// Selle
    /// </summary>
    Saddle = 0x2000,
    /// <summary>
    /// Bateau
    /// </summary>
    Waterborne_Vehicle = 0x4000,
    /// <summary>
    /// Objet
    /// </summary>
    [DisplayName("Objet")]
    Item = 0x8000,

    Spellcasting_Focus = Musical_Instrument | Holy_Symbol | Druidic_Focus | Arcane_Focus,

    /// <summary>
    /// Armure légère
    /// </summary>
    [DisplayName("Armure légère")]
    Light_Armor = 0x10000,
    /// <summary>
    /// Armure intermédiaire
    /// </summary>
    [DisplayName("Armure intermédiaire")]
    Medium_Armor = 0x20000,
    /// <summary>
    /// Armure lourde
    /// </summary>
    [DisplayName("Armure lourde")]
    Heavy_Armor = 0x40000,
    /// <summary>
    /// Armure
    /// </summary>
    [DisplayName("Armure")]
    Armor = Light_Armor | Medium_Armor | Heavy_Armor,
    /// <summary>
    /// Bouclier
    /// </summary>
    [DisplayName("Bouclier")]
    Shield = 0x80000,
    /// <summary>
    /// Arme de corps à corps courante
    /// </summary>
    [DisplayName("Arme de corps à corps courante")]
    Simple_Melee_Weapon = 0x100000,
    /// <summary>
    /// Arme à distance courante
    /// </summary>
    [DisplayName("Arme à distance courante")]
    Simple_Ranged_Weapon = 0x200000,
    /// <summary>
    /// Arme de corps à corps de guerre
    /// </summary>
    [DisplayName("Arme de corps à corps de guerre")]
    Martial_Melee_Weapon = 0x400000,
    /// <summary>
    /// Arme à distance de guerre
    /// </summary>
    [DisplayName("Arme à distance de guerre")]
    Martial_Ranged_Weapon = 0x800000,
    /// <summary>
    /// Arme courante
    /// </summary>
    [DisplayName("Arme courante")]
    Simple_Weapon = Simple_Melee_Weapon | Simple_Ranged_Weapon,
    /// <summary>
    /// Arme de guerre
    /// </summary>
    [DisplayName("Arme de guerre")]
    Martial_Weapon = Martial_Melee_Weapon | Martial_Ranged_Weapon,
    /// <summary>
    /// Arme de corps à corps
    /// </summary>
    [DisplayName("Arme de corps à corps")]
    Melee_Weapon = Simple_Melee_Weapon | Martial_Melee_Weapon,
    /// <summary>
    /// Arme à distance
    /// </summary>
    [DisplayName("Arme à distance")]
    Ranged_Weapon = Simple_Ranged_Weapon | Martial_Ranged_Weapon,
    /// <summary>
    /// Arme
    /// </summary>
    [DisplayName("Arme")]
    Weapon = Simple_Melee_Weapon | Simple_Ranged_Weapon | Martial_Melee_Weapon | Martial_Ranged_Weapon,
}

public enum WeaponHeaviness
{
    /// <summary>
    /// Légère
    /// </summary>
    Light = -1,
    /// <summary>
    /// Intermédiaire
    /// </summary>
    Medium = 0,
    /// <summary>
    /// Lourde
    /// </summary>
    Heavy = 1,
}
public enum WeaponHandCount
{
    Null,
    /// <summary>
    /// A une main
    /// </summary>
    One_Handed,
    /// <summary>
    /// A deux mains
    /// </summary>
    Two_Handed,
    /// <summary>
    /// Versatile (à une ou deux mains)
    /// </summary>
    Versatile
}

public enum WeaponAbility
{
    Null,
    /// <summary>
    /// Force
    /// </summary>
    Strength,
    /// <summary>
    /// Dextérité
    /// </summary>
    Dexterity,
    /// <summary>
    /// Finesse (force ou dextérité)
    /// </summary>
    Finesse = Strength | Dexterity,
}

public enum DamageType
{
    Null,
    /// <summary>
    /// Acide
    /// </summary>
    Acid,
    /// <summary>
    /// Contondant
    /// </summary>
    Bludgeoning,
    /// <summary>
    /// Froid
    /// </summary>
    Cold,
    /// <summary>
    /// Feu
    /// </summary>
    Fire,
    /// <summary>
    /// Force
    /// </summary>
    Force,
    /// <summary>
    /// Foudre
    /// </summary>
    Lightning,
    /// <summary>
    /// Nécrotique
    /// </summary>
    Necrotic,
    /// <summary>
    /// Perforant
    /// </summary>
    Piercing,
    /// <summary>
    /// Poison
    /// </summary>
    Poison,
    /// <summary>
    /// Psychique
    /// </summary>
    Psychic,
    /// <summary>
    /// Radiant
    /// </summary>
    Radiant,
    /// <summary>
    /// Tranchant
    /// </summary>
    Slashing,
    /// <summary>
    /// Tonnerre
    /// </summary>
    Thunder,
}
