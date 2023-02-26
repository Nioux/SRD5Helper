using SRD5Helper.Tools;
using SRD5Helper.ViewModels;
using Library = SRD5Helper.Resources.Library;

namespace SRD5Helper.DataModels;

public class Distance
{
    public int Square { get; set; }
    public static Distance FromMeters(int meters, int centimeters = 0)
    {
        return new Distance { Square = meters * 100 + centimeters };
    }
}
public struct ClassDatum
{
    public string ID { get; init; }

    private GenderedName _genderedName;
    public GenderedName GenderedName { get => _genderedName ??= 
            new GenderedName
            {
                Name = Library.Classes.ResourceManager.GetName(ID),
                FemaleName = Library.Classes.ResourceManager.GetFName(ID),
                MaleName = Library.Classes.ResourceManager.GetMName(ID),
                NeutralName = Library.Classes.ResourceManager.GetNName(ID),
                InclusiveName = Library.Classes.ResourceManager.GetIName(ID),
            }; init => _genderedName = value; }
    public string _description;
    public string Description { get => _description ??= Library.Classes.ResourceManager.GetDescription(ID); init => _description = value; }

    //public GenderedName GenderedName { get; init; }

    public int HitDice { get; init; }
    public AbilityID HitPointsAbilityBonus { get; init; }
    public IReadOnlyList<EquipmentTypeRef> EquipmentProficiencies { get; init; }
    public IReadOnlyList<EquipmentTypeRef> WeaponsProficiencies { get => EquipmentProficiencies.Where(e => e.IsEquivalent(EquipmentType.Weapon)).ToList(); }
    public IReadOnlyList<EquipmentTypeRef> ArmorsProficiencies { get => EquipmentProficiencies.Where(e => e.IsEquivalent(EquipmentType.Armor)).ToList(); }
    public IReadOnlyList<EquipmentTypeRef> ToolsProficiencies { get => EquipmentProficiencies.Where(e => e.IsEquivalent(EquipmentType.Artisans_Tools)).ToList(); }
    public IReadOnlyList<AbilityID> SavesProficiencies { get; init; }
    public IReadOnlyList<SkillID> AllowedSkillProficiencies { get; init; }
    public int SkillProficienciesCount { get; init; }
    public AbilityID? SpellcastingAbility { get; init; }
    public EquipmentType? SpellcastingFocus { get; init; }

    // table d'avancement
    public readonly int[] ProficiencyBonus { get; init; }
    public IReadOnlyList<string>[] FeaturesTable { get; init; }
    public string[] Archetypes { get; init; }
    public int[] CantripsKnown { get; init; }
    public int[] SpellsKnown { get; init; }
    public bool SpellsAlwaysKnown { get; init; }
    public bool SpellsAlwaysPrepared { get; init; }
    public int[] SpellSlots { get; init; }
    public int[] SlotLevel { get; init; }
    public int[] InvocationsKnown { get; init; }
    public int[] SorceryPoints { get; init; }
    public Roll[] SneakAttack { get; init; }
    public int[,] SpellSlotsPerSpellLevelTable { get; init; }
    public Roll[] MartialArts { get; init; }
    public int[] KiPoints { get; init; }
    public Distance[] UnarmoredMovement { get; init; }
    public int[] Rages { get; init; }
    public int[] RageDamage { get; init; }
}

public struct ClassArchetypeDatum
{
    public string ID { get; init; }
    private string _name;
    public string Name { get => _name ??= Library.Archetypes.ResourceManager.GetName(ID); init => _name = value; }
    public string _description;
    public string Description { get => _description ??= Library.Archetypes.ResourceManager.GetDescription(ID); init => _description = value; }

    public IReadOnlyList<string>[] FeaturesTable { get; init; }
    public IReadOnlyList<string>[] AlwaysPreparedSpellsTable { get; init; }
    //public int MinimumLevel { get; init; }


    public override string ToString()
    {
        return Name;
    }
}

