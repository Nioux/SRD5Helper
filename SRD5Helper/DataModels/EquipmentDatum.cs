using SRD5Helper.Tools;
using YamlDotNet.Serialization;
using Library = SRD5Helper.Resources.Library;

namespace SRD5Helper.DataModels;

public enum MoneyEnum : long
{
    CP = 1,
    SP = 10,
    EP = 50,
    GP = 100,
    PP = 1000,
}
public struct Money
{
    public Money()
    {
        CP = null;
        SP = null;
        EP = null;
        GP = null;
        PP = null;
    }
    /// <summary>
    /// Copper / Cuivre
    /// </summary>
    [YamlMember(Alias = "cp")]
    public long? CP { get; set; }
    /// <summary>
    /// Silver / Argent
    /// </summary>
    [YamlMember(Alias = "sp")]
    public long? SP { get; set; }
    /// <summary>
    /// Electrum
    /// </summary>
    [YamlMember(Alias = "ep")]
    public long? EP { get; set; }
    /// <summary>
    /// Gold / Or
    /// </summary>
    [YamlMember(Alias = "gp")]
    public long? GP { get; set; }
    /// <summary>
    /// Platinum / Platine
    /// </summary>
    [YamlMember(Alias = "pp")]
    public long? PP { get; set; }

    public static Money FromCP(long cp) => new Money { CP = cp };
    public static Money FromSP(long sp) => new Money { SP = sp };
    public static Money FromEP(long ep) => new Money { EP = ep };
    public static Money FromGP(long gp) => new Money { GP = gp };
    public static Money FromPP(long pp) => new Money { PP = pp };
    public long ToLongCP()
    {
        return (CP ?? 0) * ((long)MoneyEnum.CP)
            + (SP ?? 0) * ((long)MoneyEnum.SP)
            + (EP ?? 0) * ((long)MoneyEnum.EP)
            + (GP ?? 0) * ((long)MoneyEnum.GP)
            + (PP ?? 0) * ((long)MoneyEnum.PP);
    }
    /*
    public Money ToCP()
    {
        var intCP = ToIntCP();
        CP = 0;
    }*/
}
/*public class Number
{
    [YamlIgnore, JsonIgnore]
    public int Value { get; init; }


    public Number() { }
    public Number(int value) { Value = value; }


    // Custom cast from "int":
    public static implicit operator Number(Int32 x) { return new Number(x); }

    // Custom cast to "int":
    public static implicit operator Int32(Number x) { return x.Value; }


    public override string ToString()
    {
        return $"{Value}";
    }
}*/

public struct Capacity
{
    public string Litters { get; init; }
    public string Gramms { get; init; }
}
public struct EquipmentDatum
{
    public string ID { get; init; }
    private string _name;
    public string Name { get => _name ??= Library.Equipments.ResourceManager.GetName(ID); init => _name = value; }
    public string _description;
    public string Description { get => _description ??= Library.Equipments.ResourceManager.GetDescription(ID); init => _description = value; }
    public string _picture;
    public string Picture { get => _picture ??= Library.Equipments.ResourceManager.GetPicture(ID); init => _picture = value; }
    public EquipmentType Type { get; init; }
    public long? Weight { get; init; }
    public Money Cost { get; init; }
    public int? Quantity { get; init; }
    public bool IsEquippable { get => EquipmentType.Armor.HasFlag(Type) || EquipmentType.Weapon.HasFlag(Type) || EquipmentType.Shield.HasFlag(Type); }
    // Armes
    public Damage? MeleeDamage { get; init; }
    public Damage? TwoHandledMeleeDamage { get; init; }
    public Damage? RangeDamage { get; init; }
    //public Damage? ThrowingDamage { get; init; }
    public WeaponAbility? WeaponAbility { get; init; }
    public WeaponHandCount? HandCount { get; init; }
    public WeaponHeaviness? Heaviness { get; init; }

    // Armures & bouclier
    public int? ArmorClass { get; init; }
    public int? ArmorClassModifier { get; init; }
    public bool UseDexterityModifier { get => (Type == EquipmentType.Armor) && (Heaviness != WeaponHeaviness.Heavy); }
    public int? MaxDexterityModifier { get; init; }
    public int? Strength { get; init; }
    public bool StealthDisadvantage { get; init; }

    // Récipients
    public Capacity? Capacity { get; init; }
}

public struct Roll
{
    public Roll(int dice, int diceCount = 1, int modifier = 0)
    {
        Dice = dice;
        DiceCount = diceCount;
        Modifier = modifier;
    }
    public int Dice { get; init; }
    public int DiceCount { get; init; }
    public int Modifier { get; init; }
}
public struct Damage
{
    public int Dice { get; init; }
    public int? DiceCount { get; init; }
    public int? Modifier { get; init; }
    public DamageType Type { get; init; }
    public Distance NormalRange { get; init; }
    public Distance LongRange { get; init; }
    public bool Ammunition { get; init; }
    public bool Loading { get; init; }
    public bool Reach { get; init; }
    public bool Special { get; init; }

    public Damage AddModifier(int modifier)
    {
        return new Damage
        {
            Dice = this.Dice,
            DiceCount = this.DiceCount,
            Modifier = this.Modifier + modifier,
            Type = this.Type,
            NormalRange = this.NormalRange,
            LongRange = this.LongRange,
            Ammunition = this.Ammunition,
            Loading = this.Loading,
            Reach = this.Reach,
            Special = this.Special,
        };
    }
    public Damage SetModifier(int modifier)
    {
        return new Damage
        {
            Dice = this.Dice,
            DiceCount = this.DiceCount,
            Modifier = modifier,
            Type = this.Type,
            NormalRange = this.NormalRange,
            LongRange = this.LongRange,
            Ammunition = this.Ammunition,
            Loading = this.Loading,
            Reach = this.Reach,
            Special = this.Special,
        };
    }

    public override string ToString()
    {
        return $"{DiceCount ?? 1}d{Dice}{Modifier:+0;-#} {Library.DamageTypes.ResourceManager.GetName(Type)}";
    }
}
