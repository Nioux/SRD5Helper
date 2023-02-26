
using SRD5Helper.Resources.Library;
using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;
using YamlDotNet.Serialization;
using System.Text.Json.Serialization;
using SRD5Helper.DataModels;

namespace SRD5Helper.ViewModels;

public class SpellGroupByLevel : List<Spell>
{
    public int Level { get; init; }
    public int SlotCount { get; init; }
    public int MaxSlotCount { get; init; }
    public SpellGroupByLevel(int level, int slotCount, int maxSlotCount, List<Spell> spellRefs) : base(spellRefs)
    {
        Level = level;
        SlotCount = slotCount;
        MaxSlotCount = maxSlotCount;
    }
}
public class Spell : DatumReference<string, SpellDatum>
{
    //[YamlMember(Alias = "id", Order = 0)]
    //public string ID { get; set; }
    public Spell() { }
    public Spell(string _id) { ID = _id; }
    //public static implicit operator Spell(string x) { return new Spell(x); }

    [YamlIgnore, JsonIgnore]
    public override SpellDatum Datum => Property.Calculated(() => SpellsData[ID]);

    [YamlIgnore, JsonIgnore]
    public string Name => Property.Calculated(() => Datum.Name);
    [YamlIgnore, JsonIgnore]
    public int Level => Property.Calculated(() => Datum.Level);

    public string ClassID { get => Property.Get<string>(() => null); set => Property.Set(value); }
    public string ArchetypeID { get => Property.Get<string>(() => null); set => Property.Set(value); }
    //public Class Class { get; set; } //=> PC.Classes[ClassID];
    [YamlIgnore, JsonIgnore]
    public Class Class => Property.Calculated(() => PC.Classes.Where(cl => cl.ID == ClassID).FirstOrDefault());

    [YamlIgnore, JsonIgnore]
    public bool IsKnown => Property.Calculated(() => AlwaysKnown || (Class?.KnownSpells?.Contains(ID)) == true);

    [YamlIgnore, JsonIgnore]
    public bool AlwaysKnown => Property.Calculated(() => Class.Datum.SpellsAlwaysKnown && Level >= 1);

    [YamlIgnore, JsonIgnore]
    public bool IsPrepared => Property.Calculated(() => AlwaysPrepared || (Class?.PreparedSpells?.Contains(ID) == true) );

    [YamlIgnore, JsonIgnore]
    public bool AlwaysPrepared => Property.Calculated(() => Class?.AlwaysPreparedSpells?.Contains(this.ID) == true);
        //var spells = Class.Archetypes.SelectMany(archetype => archetype.AlwaysPreparedSpellsTable == null ? new List<string>() : archetype.AlwaysPreparedSpellsTable.SelectMany(table => table));
        //return spells.Any(spellid => spellid == this.ID);

    [YamlIgnore, JsonIgnore]
    public bool IsAvailable => Property.Calculated(() => Class?.IsSpellLevelAvailable(Datum.Level)) == true;

    [YamlIgnore, JsonIgnore]
    public bool IsCastable => Property.Calculated(() => IsAvailable && IsPrepared && IsKnown);

    public override string ToString() => ID;
}
public class SpellRefs : ObservableCollection<Spell>
{

}

