
using SRD5Helper.DataModels;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;
using YamlDotNet.Serialization;

namespace SRD5Helper.ViewModels;

public class Origin : DatumReference<string, OriginDatum>, IFeaturesBag
{
    public Origin() { }
    public Origin(string _ref) { ID = _ref; }
   //public static implicit operator Origin(string x) { return new Origin(x); }
    [YamlIgnore, JsonIgnore]
    public override OriginDatum Datum => OriginsData[ID];

    [YamlIgnore, JsonIgnore]
    public string Name => Datum.GenderedName.GetDisplayName(PC.Gender);

    [YamlIgnore, JsonIgnore]
    public Dictionary<AbilityID, int> Bonuses { get; } = new Dictionary<AbilityID, int>();

    public int GetBonus(AbilityID name) => Bonuses.ContainsKey(name)? Bonuses[name] : Datum.Bonuses.GetValueOrDefault(name);

    [YamlIgnore, JsonIgnore]
    public int StrengthBonus { get => Bonuses.ContainsKey(AbilityID.Strength) ? Bonuses[AbilityID.Strength] : Datum.StrengthBonus; set => Bonuses[AbilityID.Strength] = value; }
    [YamlIgnore, JsonIgnore]
    public int DexterityBonus { get => Bonuses.ContainsKey(AbilityID.Dexterity) ? Bonuses[AbilityID.Dexterity] : Datum.DexterityBonus; set => Bonuses[AbilityID.Dexterity] = value; }
    [YamlIgnore, JsonIgnore]
    public int ConstitutionBonus { get => Bonuses.ContainsKey(AbilityID.Constitution) ? Bonuses[AbilityID.Constitution] : Datum.ConstitutionBonus; set => Bonuses[AbilityID.Constitution] = value; }
    [YamlIgnore, JsonIgnore]
    public int IntelligenceBonus { get => Bonuses.ContainsKey(AbilityID.Intelligence) ? Bonuses[AbilityID.Intelligence] : Datum.IntelligenceBonus; set => Bonuses[AbilityID.Intelligence] = value; }
    [YamlIgnore, JsonIgnore]
    public int WisdomBonus { get => Bonuses.ContainsKey(AbilityID.Wisdom) ? Bonuses[AbilityID.Wisdom] : Datum.WisdomBonus; set => Bonuses[AbilityID.Wisdom] = value; }
    [YamlIgnore, JsonIgnore]
    public int CharismaBonus { get => Bonuses.ContainsKey(AbilityID.Charisma) ? Bonuses[AbilityID.Charisma] : Datum.CharismaBonus; set => Bonuses[AbilityID.Charisma] = value; }

    private IReadOnlyList<Feature> _features = null;
    [YamlIgnore, JsonIgnore]
    public IReadOnlyList<Feature> Features { get => _features ??= Datum.Traits?.Select((string id) => PC.Factory.CreateFeature(id: id))?.Concat(SelectedFeatures)?.ToList(); }

    public ObservableCollection<Feature> SelectedFeatures { get; set; } = new ObservableCollection<Feature>();
}
