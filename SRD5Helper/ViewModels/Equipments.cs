using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.Input;
using SRD5Helper.DataModels;
using SRD5Helper.Resources.Library;
using SRD5Helper.Tools;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Text.Json.Serialization;
using YamlDotNet.Serialization;
using Library = SRD5Helper.Resources.Library;

namespace SRD5Helper.ViewModels;

public class Equipment : DatumReference<string, EquipmentDatum>
{
    [YamlMember(Alias = "id", Order = 0)]
    public override string ID { get; set; }
    public Equipment() { }
    public Equipment(string _id) { ID = _id; }
    //public static implicit operator Equipment(string x) { return new Equipment(x); }
    [YamlIgnore, JsonIgnore]
    public override EquipmentDatum Datum => Property.Calculated(() => EquipmentsData[ID]);

    [YamlIgnore, JsonIgnore]
    public string Name => Property.Calculated(() => Datum.Name);
    [YamlIgnore, JsonIgnore]
    public EquipmentType Type => Property.Calculated(() => Datum.Type);
    [YamlIgnore, JsonIgnore]
    public int? ArmorClass => Property.Calculated(() => Datum.ArmorClass);
    [YamlIgnore, JsonIgnore]
    public int? ArmorClassModifier => Property.Calculated(() => Datum.ArmorClassModifier);
    [YamlIgnore, JsonIgnore]
    public WeaponHeaviness? Heaviness => Property.Calculated(() => Datum.Heaviness);
    [YamlIgnore, JsonIgnore]
    public bool IsEquippable => Property.Calculated(() => Datum.IsEquippable);


    [YamlMember(Order = 1)]
    public bool IsEquipped
    {
        get => Property.Get(false);
        set => Property.Set(value);
    }

    public int Quantity { get => Property.Get(() => Datum.Quantity ?? 1); set => Property.Set(value); }

    //[YamlIgnore, JsonIgnore]
    //private EquipmentDatum? _equipment = null;
    //public EquipmentDatum Datum { get => _equipment ?? EquipmentsData[ID]; set => SetProperty(ref _equipment, value); }

    // MeleeAttackModifier = modif sur le jet de dés d'attaque
    // MeleeDamageModifier = modif sur le jet de dés de dégâts

    [YamlIgnore, JsonIgnore]
    public Ability AttackAbility => Property.Calculated(() =>
    {
        if (PC == null) return null;
        switch (Datum.WeaponAbility)
        {
            case WeaponAbility.Strength:
                return PC.Abilities.Strength;
            case WeaponAbility.Dexterity:
                return PC.Abilities.Dexterity;
            case WeaponAbility.Finesse:
                if (PC.Abilities.Dexterity.Mod > PC.Abilities.Strength.Mod)
                {
                    return PC.Abilities.Dexterity;
                }
                return PC.Abilities.Strength;
            default:
                if (EquipmentType.Melee_Weapon.HasFlag(Datum.Type))
                {
                    return PC.Abilities.Strength;
                }
                if (EquipmentType.Ranged_Weapon.HasFlag(Datum.Type))
                {
                    return PC.Abilities.Dexterity;
                }
                return null;
        }
    });

    [YamlIgnore, JsonIgnore]
    private int AttackAbilityModifier => Property.Calculated(() => AttackAbility?.Mod ?? 0);
    [YamlIgnore, JsonIgnore]
    private int MeleeAttackBaseModifier => Property.Calculated(() => Datum.MeleeDamage?.Modifier ?? 0);
    //private IEnumerable<Rule> MeleeAttackModifierRules => GetRules(nameof(MeleeAttackModifier));
    [YamlIgnore, JsonIgnore]
    private int MeleeAttackModifierRuled => Property.Calculated(() => SumRules(nameof(MeleeAttackModifier)));
    [YamlIgnore, JsonIgnore]
    public int MeleeAttackModifier => Property.Calculated(() => MeleeAttackBaseModifier + AttackAbilityModifier + ProficiencyBonus + MeleeAttackModifierRuled);

    [YamlIgnore, JsonIgnore]
    private int MeleeDamageBaseModifier => Property.Calculated(() => Datum.MeleeDamage?.Modifier ?? 0);
    [YamlIgnore, JsonIgnore]
    public int MeleeDamageModifier => Property.Calculated(() => MeleeDamageBaseModifier + AttackAbilityModifier + MeleeAttackModifierRuled);

    [YamlIgnore, JsonIgnore]
    public Damage? MeleeDamage => Property.Calculated(() => Datum.MeleeDamage?.SetModifier(MeleeDamageModifier));

    [YamlIgnore, JsonIgnore]
    public Damage? TwoHandledMeleeDamage => Property.Calculated(() => Datum.TwoHandledMeleeDamage?.SetModifier(MeleeDamageModifier));



    [YamlIgnore, JsonIgnore]
    private int RangeAttackBaseModifier => Property.Calculated(() => Datum.RangeDamage?.Modifier ?? 0);
    [YamlIgnore, JsonIgnore]
    public int RangeAttackModifier => Property.Calculated(() => RangeAttackBaseModifier + AttackAbilityModifier + ProficiencyBonus + SumRules(nameof(RangeAttackModifier)));
    [YamlIgnore, JsonIgnore]
    private int RangeDamageBaseModifier => Property.Calculated(() => Datum.RangeDamage?.Modifier ?? 0);
    [YamlIgnore, JsonIgnore]
    public int RangeDamageModifier => Property.Calculated(() => RangeDamageBaseModifier + AttackAbilityModifier);

    [YamlIgnore, JsonIgnore]
    public Damage? RangeDamage => Property.Calculated(() => Datum.RangeDamage?.SetModifier(RangeDamageModifier));

    [YamlIgnore, JsonIgnore]
    public Damage? Damage => Property.Calculated(() => MeleeDamage ?? TwoHandledMeleeDamage ?? RangeDamage);
    //public Damage? ThrowingAttack => Datum.ThrowingDamage;

    [YamlIgnore, JsonIgnore]
    public bool Proficiency => Property.Calculated(() => PC?.EquipmentProficiencies.Any(etr => etr.IsEquivalent(this)) ?? false);
    [YamlIgnore, JsonIgnore]
    public int ProficiencyBonus => Property.Calculated(() => (Proficiency ? PC.ProficiencyBonus : 0));

    //public int MeleeAttackProficiencyBonus { get => MeleeAbilityModifier + (Proficiency ? PC.ProficiencyBonus : 0); }
    //public int RangeAttackProficiencyBonus { get => PC.Abilities.Dexterity.Mod.Value + (Proficiency ? PC.ProficiencyBonus : 0); }




    public int? AttackAdvantage { get; set; }
    public int? AttackDisadvantage { get; set; }
    [YamlIgnore, JsonIgnore]
    public AdvantageDisadvantageBalance AttackBalance { get => (AttackAdvantage == 0) ? ((AttackDisadvantage == 0) ? AdvantageDisadvantageBalance.Null : AdvantageDisadvantageBalance.Disadvantage) : AdvantageDisadvantageBalance.Advantage; }


    public string ToMarkdown()
    {
        return $"# {Datum.Name}\n" +
            "\n" +
            (Datum.ArmorClass != null ? $"* CA : {Datum.ArmorClass}\n" : "") +
            (MeleeAttackModifier != 0 ? $"* Mod au corps à corps : {MeleeAttackModifier}\n" + "\n" : "") +
            (MeleeDamage != null ? $"* Dégâts au corps à corps à une main : {MeleeDamage}\n" + "\n" : "") +
            (TwoHandledMeleeDamage != null ? $"* Dégâts au corps à corps à deux mains : {TwoHandledMeleeDamage}\n" + "\n" : "") +
            (RangeDamage != null ? $"* Dégâts à distance : {RangeDamage}\n" : "") +
            $"* Type : {Library.EquipmentTypes.ResourceManager.GetName(Datum.Type)}\n" +
            "\n" +
            $"{Datum.Description}\n" +
            "\n" +
            $"![]({Datum.Picture})";
    }
}

public enum AdvantageDisadvantageBalance
{
    Null = 0,
    Advantage = 1,
    Disadvantage = -1,
}

public class EquipmentTypeRef : BaseModel
{
    [YamlMember(Alias = "id", Order = 0)]
    public string ID { get; init; }
    [YamlIgnore, JsonIgnore]
    public EquipmentDatum EquipmentDatum => Property.Calculated(() => EquipmentsData[ID]);
    public EquipmentType? Type { get => Property.Get<EquipmentType?>(() => null); init => Property.Set(value); }

    public static implicit operator EquipmentTypeRef(string id) { return new EquipmentTypeRef() { ID = id }; }
    public static implicit operator EquipmentTypeRef(EquipmentType type) { return new EquipmentTypeRef() { Type = type }; }

    public bool IsEquivalent(Equipment equipment)
    {
        if(ID != null)
        {
            return equipment.ID == ID;
        }
        if(Type != null)
        {
            return Type.Value.HasFlag(equipment.Type);
        }
        return false;
    }

    public bool IsEquivalent(EquipmentType type)
    {
        if (ID != null)
        {
            return type.HasFlag(EquipmentDatum.Type);
            //return EquipmentDatum.Type.HasFlag(type);
        }
        if (Type != null)
        {
            return type.HasFlag(Type.Value);
            //return Type.Value.HasFlag(type);
        }
        return false;
    }

    public override string ToString()
    {
        if (ID != null)
        {
            return ID;
        }
        if (Type != null)
        {
            return Type.ToString();
        }
        return string.Empty;
    }
}

public class EquipmentRefs : ObservableCollection<Equipment>
{

}

