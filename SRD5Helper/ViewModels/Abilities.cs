using CommunityToolkit.Mvvm.ComponentModel;
using Nito.Mvvm.CalculatedProperties;
using SRD5Helper.DataModels;
using System.Collections;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;
using YamlDotNet.Serialization;

namespace SRD5Helper.ViewModels;

public class Ability : DatumReference<AbilityID, AbilityDatum>
{
    public Ability() { }
    public Ability(AbilityID _id) { ID = _id; }
    //public static implicit operator Ability(AbilityID x) { return new Ability(x); }

    [YamlIgnore, JsonIgnore]
    public override AbilityDatum Datum => Property.Calculated(() => AbilitiesData[ID]);

    [YamlIgnore, JsonIgnore]
    public string Name => Property.Calculated(() => Datum.Name);

    [YamlIgnore, JsonIgnore]
    public override AbilityID ID { get => base.ID; set => base.ID = value; }


    [YamlIgnore, JsonIgnore]
    public bool SaveProficiency => Property.Calculated(() => PC?.AbilitiesSaveProficiencies?.Contains(ID) == true);


    [YamlMember(Alias = nameof(BaseScore))]
    public int? _baseScore = null;
    [YamlIgnore, JsonIgnore]
    //public int BaseScore { get => _baseScore ?? 11; set => SetProperty(ref _baseScore, value); }
    public int BaseScore { get => Property.Get(_baseScore ?? 11); set { _baseScore = value; Property.Set(value); } }

    [YamlIgnore, JsonIgnore]
    public int OriginBonus => Property.Calculated(() => PC?.Origin?.GetBonus(ID) ?? 0);

    [YamlIgnore, JsonIgnore]
    public int RuledScore => Property.Calculated(() => SumRules(nameof(Score)));

    [YamlIgnore, JsonIgnore]
    public int Score => Property.Calculated(() => BaseScore + OriginBonus + RuledScore); 

    [YamlIgnore, JsonIgnore]
    public int Mod => Property.Calculated(() => (Score / 2) - 5);

    [YamlIgnore, JsonIgnore]
    public int Save => Property.Calculated(() => Mod + (SaveProficiency ? PC.ProficiencyBonus : 0));
    public override string ToString()
    {
        return $"{BaseScore} / {Score} / {Mod} / {Save} / {SaveProficiency}";
    }
}


public class Abilities : BaseModel
{
    [YamlIgnore, JsonIgnore]
    Dictionary<AbilityID, Func<Ability>> _abilities;
    public Abilities()
    {
        _abilities = new Dictionary<AbilityID, Func<Ability>>
        {
            [AbilityID.Null] = () => null,
            [AbilityID.Strength] = () => Strength,
            [AbilityID.Dexterity] = () => Dexterity,
            [AbilityID.Constitution] = () => Constitution,
            [AbilityID.Intelligence] = () => Intelligence,
            [AbilityID.Wisdom] = () => Wisdom,
            [AbilityID.Charisma] = () => Charisma,
        };
    }
    public Ability Get(AbilityID id, [CallerMemberName] string propertyName = null!)
    {
        return Property.Get(() => PC.Factory.CreateAbility(id), propertyName: propertyName);
    }
    public void Set(AbilityID id, Ability ability, [CallerMemberName] string propertyName = null!)
    {
        ability.ID = id;
        Property.Set(ability, propertyName: propertyName);
    }
    public Ability Strength { get => Get(AbilityID.Strength); init => Set(AbilityID.Strength, value); }
    public Ability Dexterity { get => Get(AbilityID.Dexterity); init => Set(AbilityID.Dexterity, value); }
    public Ability Constitution { get => Get(AbilityID.Constitution); init => Set(AbilityID.Constitution, value); }
    public Ability Intelligence { get => Get(AbilityID.Intelligence); init => Set(AbilityID.Intelligence, value); }
    public Ability Wisdom { get => Get(AbilityID.Wisdom); init => Set(AbilityID.Wisdom,value); }
    public Ability Charisma { get => Get(AbilityID.Charisma); init => Set(AbilityID.Charisma, value); }

    public Ability GetValueOrDefault(AbilityID id)
    {
        return _abilities[id].Invoke();
    }
}

