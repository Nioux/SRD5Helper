using SRD5Helper.DataModels;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text.Json.Serialization;
using YamlDotNet.Serialization;
using Library = SRD5Helper.Resources.Library;

namespace SRD5Helper.ViewModels;

/*public class ClassLevel : BaseModel
{
    public Class Class { get; init; }
    //public ClassNameEnum ClassName { get; init; }
    public int _level = 1;
    public int Level { get => _level; set => SetProperty(ref _level, value); }

    public int _usedHitDie = 0;
    public int UsedHitDie { get => _usedHitDie; set => SetProperty(ref _usedHitDie, value); }

}*/

/*
public class ClassLevel : DatumReference<string, ClassDatum>//, IFeaturesBag
{
    public ClassLevel() { }
    public ClassLevel(string _id) { ID = _id; }
    //public static implicit operator Class(string x) { return PC.Factory.CreateClass(x); }

    [YamlIgnore, JsonIgnore]
    public override ClassDatum Datum => Property.Calculated(() => ClassesData[ID]);

    [YamlIgnore, JsonIgnore]
    public string Name => Property.Calculated(() => Datum.GenderedName.GetDisplayName(PC.Gender));

    public int Level { get => Property.Get(1); set => Property.Set(value); }
}
*/
public interface IFeaturesBag
{
    public IReadOnlyList<Feature> Features { get; }
}
public class Class : DatumReference<string, ClassDatum>, IFeaturesBag
{
    public Class() { }
    public Class(string _id) { ID = _id; }
    //public static implicit operator Class(string x) { return PC.Factory.CreateClass(x); }

    [YamlIgnore, JsonIgnore]
    public override ClassDatum Datum => Property.Calculated(() => ClassesData[ID]);

    [YamlIgnore, JsonIgnore]
    public string Name => Property.Calculated(() => Datum.GenderedName.GetDisplayName(PC.Gender));

    public int Level { get => Property.Get(1); set => Property.Set(value); }

    [YamlIgnore, JsonIgnore]
    public int HitDice => Property.Calculated(() => Datum.HitDice);
    [YamlIgnore, JsonIgnore]
    public IReadOnlyList<AbilityID> SavesProficiencies => Property.Calculated(() => Datum.SavesProficiencies);
    [YamlIgnore, JsonIgnore]
    public AbilityID? SpellcastingAbility => Property.Calculated(() => Datum.SpellcastingAbility);
    [YamlIgnore, JsonIgnore]
    public IReadOnlyList<EquipmentTypeRef> EquipmentProficiencies => Property.Calculated(() => Datum.EquipmentProficiencies);

    [YamlMember(Alias = nameof(HitPointsPerLevel))]
    //public List<int> _hitPointsPerLevel = null;
    //[YamlIgnore, JsonIgnore]
    public ObservableCollection<int> HitPointsPerLevel { get => Property.Get(() => new ObservableCollection<int>()); private set => Property.Set(value); }

    [YamlIgnore, JsonIgnore]
    public int HitPoints => Property.Calculated(() => HitPointsPerLevel.Sum());

    [YamlIgnore, JsonIgnore]
    public IReadOnlyList<ClassArchetypeDatum> Archetypes => Property.Calculated(() => ArchetypeIDs != null ? ArchetypeIDs.Select(id => ClassArchetypesData[id]).ToList() : new List<ClassArchetypeDatum>());

    public ObservableCollection<string> ArchetypeIDs { get => Property.Get(() => new ObservableCollection<string>()); init => Property.Set(value); }

    [YamlIgnore, JsonIgnore]
    public IReadOnlyList<string>[] FeaturesTable => Property.Calculated(() =>
    {
        var featuresTable = Datum.FeaturesTable;
        foreach (var archetype in Archetypes)
        {
            featuresTable = featuresTable.Merge(archetype.FeaturesTable);
        }
        return featuresTable;
    });

    //public IReadOnlyList<string> InheritedFeatureIDs => FeaturesTable.SelectMany((featuresByLevel, level) => featuresByLevel).ToList();



    [YamlIgnore, JsonIgnore]
    private IReadOnlyList<Feature> _allFeatures = null;
    [YamlIgnore, JsonIgnore]
    public IReadOnlyList<Feature> AllFeatures => Property.Calculated(() =>
    {
        return _allFeatures ??= FeaturesTable.SelectMany((featuresByLevel, level) => featuresByLevel.Select((featureid) => PC.Factory.CreateFeature(id: featureid, level: level + 1))).ToList();
    });

    [YamlIgnore, JsonIgnore]
    public IReadOnlyList<Feature> Features => Property.Calculated(() =>
    {
        return AllFeatures.Concat(SelectedFeatures).ToList();
    });

    public ObservableCollection<Feature> SelectedFeatures { get => Property.Get(() => new ObservableCollection<Feature>()); init => Property.Set(value); }

    [YamlIgnore, JsonIgnore]
    public IReadOnlyList<Spell> Spells => Property.Calculated(() =>
    {
        var spells = SpellsData.Values
            .Where(datum => datum.Classes.Contains(ID))
            .Select(spell => PC.Factory.CreateSpell(id: spell.ID, classID: ID))
            .ToList();

        foreach (var archetype in Archetypes)
        {
            spells.AddRange(SpellsData.Values
                .Where(datum => datum.Classes.Contains(archetype.ID))
                .Select(spell => PC.Factory.CreateSpell(id: spell.ID, classID: ID, archetypeID: archetype.ID))
                .ToList());
        }
        return spells;
    });

    [YamlIgnore, JsonIgnore]
    public IReadOnlyList<Spell> AvailableSpells => Property.Calculated(() => Spells.Where(spell => spell.Level <= this.Level).ToList());

    [YamlIgnore, JsonIgnore]
    public IEnumerable<string> AlwaysPreparedSpells => Property.Calculated(() =>
    {
        return Archetypes.SelectMany(archetype => archetype.AlwaysPreparedSpellsTable == null ? new List<string>() : archetype.AlwaysPreparedSpellsTable.SelectMany(table => table));
    });


    [YamlIgnore, JsonIgnore]
    public int[] SpellSlotsByLevel => Property.Calculated<int[]>(() =>
    {
        var slots = new List<int>();
        if (Datum.SpellSlotsPerSpellLevelTable != null)
        {
            slots.Add(0);
            for (int i = 0; i < Datum.SpellSlotsPerSpellLevelTable.GetLength(1); i++)
            {
                slots.Add(Datum.SpellSlotsPerSpellLevelTable[Level - 1, i]);
            }
        }
        return slots.ToArray();
    });

    public ObservableCollection<string> PreparedSpells { get => Property.Get(() => new ObservableCollection<string>()); set => Property.Set(value); }

    public ObservableCollection<string> KnownSpells { get => Property.Get(() => new ObservableCollection<string>()); set => Property.Set(value); }

    public int[] UsedSpellSlotsByLevel { get => Property.Get(() => new int[10]); set => Property.Set(value); }

    public bool IsSpellLevelAvailable(int spellLevel)
    {
        if (Datum.SpellSlotsPerSpellLevelTable != null)
        {
            if (spellLevel == 0 || Datum.SpellSlotsPerSpellLevelTable[Level - 1, spellLevel - 1] > 0)
            {
                return true;
            }
        }
        foreach (var archetype in Archetypes)
        {
            // TODO : traitement correct des archetypes / sorts
            //if(archetype.AlwaysPreparedSpellsTable != null)
            //{
            //    return true;
            //}
            if (archetype.ID == Library.Archetypes.shadowblade)
            {
                //if (Level >= 3)
                //{
                    return true;
                //}
            }
        }
        return false;
    }

    public HashSet<SkillID> SelectedSkillProficiencies { get => Property.Get(() => new HashSet<SkillID>()); set => Property.Set(value); }


    public void UpLevel()
    {
        Level++;
    }
}

