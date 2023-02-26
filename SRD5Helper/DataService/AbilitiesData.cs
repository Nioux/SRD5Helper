using SRD5Helper.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRD5Helper.Data;

public partial class DataService
{
    private IReadOnlyList<AbilityDatum> _abilitiesData = new List<AbilityDatum>
    {
        new()
        {
            ID = AbilityID.Strength,
        },
        new()
        {
            ID = AbilityID.Dexterity,
        },
        new()
        {
            ID = AbilityID.Constitution,
        },
        new()
        {
            ID = AbilityID.Intelligence,
        },
        new()
        {
            ID = AbilityID.Wisdom,
        },
        new()
        {
            ID = AbilityID.Charisma,
        },
    };
    public IReadOnlyDictionary<AbilityID, AbilityDatum> _abilitiesDataMap = null;
    public IReadOnlyDictionary<AbilityID, AbilityDatum> AbilitiesData => _abilitiesDataMap ??= _abilitiesData.ToDictionary(s => s.ID, s => s);
}
