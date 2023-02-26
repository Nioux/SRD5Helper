using SRD5Helper.DataModels;
namespace SRD5Helper.Data;

public partial class DataService
{
    private IReadOnlyList<SkillDatum> _skillData = new List<SkillDatum>
    {
        new() 
        { 
            ID = SkillID.Acrobatics, 
            AbilityID = AbilityID.Dexterity 
        },
        new() 
        { 
            ID = SkillID.Arcana, 
            AbilityID = AbilityID.Intelligence 
        },
        new() 
        { 
            ID = SkillID.Athletics, 
            AbilityID = AbilityID.Strength 
        },
        new() 
        { 
            ID = SkillID.Stealth, 
            AbilityID = AbilityID.Dexterity 
        },
        new() 
        { 
            ID = SkillID.Animal_Handling,
            AbilityID = AbilityID.Wisdom 
        },
        new() 
        { 
            ID = SkillID.Sleight_Of_Hand, 
            AbilityID = AbilityID.Dexterity 
        },
        new() 
        { 
            ID = SkillID.History, 
            AbilityID = AbilityID.Intelligence 
        },
        new() 
        { 
            ID = SkillID.Intimidation, 
            AbilityID = AbilityID.Charisma 
        },
        new() 
        { 
            ID = SkillID.Investigation, 
            AbilityID = AbilityID.Intelligence 
        },
        new() 
        { 
            ID = SkillID.Medicine, 
            AbilityID = AbilityID.Wisdom 
        },
        new() 
        { 
            ID = SkillID.Nature, 
            AbilityID = AbilityID.Intelligence 
        },
        new() 
        { 
            ID = SkillID.Perception, 
            AbilityID = AbilityID.Wisdom 
        },
        new() 
        { 
            ID = SkillID.Insight, 
            AbilityID = AbilityID.Wisdom 
        },
        new() 
        { 
            ID = SkillID.Persuasion, 
            AbilityID = AbilityID.Charisma 
        },
        new() 
        { 
            ID = SkillID.Religion, 
            AbilityID = AbilityID.Intelligence 
        },
        new() 
        { 
            ID = SkillID.Performance, 
            AbilityID = AbilityID.Charisma 
        },
        new() 
        { 
            ID = SkillID.Deception, 
            AbilityID = AbilityID.Charisma 
        },
        new() 
        { 
            ID = SkillID.Survival, 
            AbilityID = AbilityID.Wisdom 
        },
    };

    public IReadOnlyDictionary<SkillID, SkillDatum> _skillsDataMap = null;
    public IReadOnlyDictionary<SkillID, SkillDatum> SkillsData => _skillsDataMap ??= _skillData.ToDictionary(s => s.ID, s => s);
}