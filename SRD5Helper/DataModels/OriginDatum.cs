using SRD5Helper.Tools;
using Library = SRD5Helper.Resources.Library;

namespace SRD5Helper.DataModels;

public struct OriginDatum
{
    public string ID { get; init; }

    private GenderedName _genderedName;
    public GenderedName GenderedName
    {
        get => _genderedName ??=
            new GenderedName
            {
                Name = Library.Origins.ResourceManager.GetName(ID),
                FemaleName = Library.Origins.ResourceManager.GetFName(ID),
                MaleName = Library.Origins.ResourceManager.GetMName(ID),
                NeutralName = Library.Origins.ResourceManager.GetNName(ID),
                InclusiveName = Library.Origins.ResourceManager.GetIName(ID),
            }; init => _genderedName = value;
    }
    public string _description;
    public string Description { get => _description ??= Library.Origins.ResourceManager.GetDescription(ID); init => _description = value; }

    private Dictionary<AbilityID, int> _bonuses;
    public Dictionary<AbilityID, int> Bonuses => _bonuses ??= new Dictionary<AbilityID, int>();
    public int StrengthBonus { get => Bonuses.GetValueOrDefault(AbilityID.Strength); set => Bonuses[AbilityID.Strength] = value; }
    public int DexterityBonus { get => Bonuses.GetValueOrDefault(AbilityID.Dexterity); set => Bonuses[AbilityID.Dexterity] = value; }
    public int ConstitutionBonus { get => Bonuses.GetValueOrDefault(AbilityID.Constitution); set => Bonuses[AbilityID.Constitution] = value; }
    public int IntelligenceBonus { get => Bonuses.GetValueOrDefault(AbilityID.Intelligence); set => Bonuses[AbilityID.Intelligence] = value; }
    public int WisdomBonus { get => Bonuses.GetValueOrDefault(AbilityID.Wisdom); set => Bonuses[AbilityID.Wisdom] = value; }
    public int CharismaBonus { get => Bonuses.GetValueOrDefault(AbilityID.Charisma); set => Bonuses[AbilityID.Charisma] = value; }
    public int AdditionalBonuses { get; init; }
    public List<string> Traits { get; init; }
    public List<string> Languages { get; init; }
    public int AdditionalLanguages { get; init; }
}
