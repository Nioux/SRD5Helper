using SRD5Helper.DataModels;
using Library = SRD5Helper.Resources.Library;

namespace SRD5Helper.Data;

public partial class DataService
{
    private IReadOnlyList<ConditionDatum> _conditionsData = new List<ConditionDatum>
    {
        new()
        {
            ID = ConditionID.Prone,
            Rules = new[]
            {
                Library.Rules.condition_prone_attaque_desavantage,
            }
        },
        new()
        {
            ID = ConditionID.Deafened,
        },
        new()
        {
            ID = ConditionID.Blinded,
        },
        new()
        {
            ID = ConditionID.Charmed,
        },
        new()
        {
            ID = ConditionID.Grappled,
        },
        new()
        {
            ID = ConditionID.Poisoned,
        },
        new()
        {
            ID = ConditionID.Restrained,
        },
        new()
        {
            ID = ConditionID.Stunned,
        },
        new()
        {
            ID = ConditionID.Unconscious,
        },
        new()
        {
            ID = ConditionID.Incapacitated,
        },
        new()
        {
            ID = ConditionID.Frightened,
        },
        new()
        {
            ID = ConditionID.Invisible,
        },
        new()
        {
            ID = ConditionID.Paralyzed,
        },
        new()
        {
            ID = ConditionID.Petrified,
        },
        new()
        {
            ID = ConditionID.Special,
        },
        new()
        {
            ID = ConditionID.ExhaustionLevel1,
        },
        new()
        {
            ID = ConditionID.ExhaustionLevel2,
        },
        new()
        {
            ID = ConditionID.ExhaustionLevel3,
        },
        new()
        {
            ID = ConditionID.ExhaustionLevel4,
        },
        new()
        {
            ID = ConditionID.ExhaustionLevel5,
        },
        new()
        {
            ID = ConditionID.ExhaustionLevel6,
        },
        new()
        {
            ID = ConditionID.Exhausted,
        },
    };

    public IReadOnlyDictionary<ConditionID, ConditionDatum> _conditionsDataMap = null;
    public IReadOnlyDictionary<ConditionID, ConditionDatum> ConditionsData => _conditionsDataMap ??= _conditionsData.ToDictionary(s => s.ID, s => s);
}
