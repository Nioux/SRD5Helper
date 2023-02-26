using CommunityToolkit.Mvvm.DependencyInjection;
using CommunityToolkit.Mvvm.Input;
using SRD5Helper.DataModels;
using System.Collections;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;
using YamlDotNet.Serialization;

namespace SRD5Helper.ViewModels;

public class Skill : DatumReference<SkillID, SkillDatum>
{
    [YamlIgnore, JsonIgnore]
    private static Dictionary<SkillID, AbilityID> _skillsAbility = new Dictionary<SkillID, AbilityID>
    {
        [SkillID.Null] = AbilityID.Null,
        [SkillID.Acrobatics] = AbilityID.Dexterity,
        [SkillID.Arcana] = AbilityID.Intelligence,
        [SkillID.Athletics] = AbilityID.Strength,
        [SkillID.Stealth] = AbilityID.Dexterity,
        [SkillID.Animal_Handling] = AbilityID.Wisdom,
        [SkillID.Sleight_Of_Hand] = AbilityID.Dexterity,
        [SkillID.History] = AbilityID.Intelligence,
        [SkillID.Intimidation] = AbilityID.Charisma,
        [SkillID.Investigation] = AbilityID.Intelligence,
        [SkillID.Medicine] = AbilityID.Wisdom,
        [SkillID.Nature] = AbilityID.Intelligence,
        [SkillID.Perception] = AbilityID.Wisdom,
        [SkillID.Insight] = AbilityID.Wisdom,
        [SkillID.Persuasion] = AbilityID.Charisma,
        [SkillID.Religion] = AbilityID.Intelligence,
        [SkillID.Performance] = AbilityID.Charisma,
        [SkillID.Deception] = AbilityID.Charisma,
        [SkillID.Survival] = AbilityID.Wisdom,
    };

    public Skill() { }
    public Skill(SkillID _id) { ID = _id; }
    
    [YamlIgnore, JsonIgnore]
    public override SkillDatum Datum => SkillsData[ID];
    [YamlIgnore, JsonIgnore]
    public string Name => Datum.Name;
    [YamlIgnore, JsonIgnore]
    public override SkillID ID { get => base.ID; set => base.ID = value; }


    [YamlIgnore, JsonIgnore]
    public AbilityID AbilityID => Property.Calculated(() => _skillsAbility[ID]);
    [YamlIgnore, JsonIgnore]
    public Ability Ability => Property.Calculated(() => PC.Abilities.GetValueOrDefault(AbilityID));

    [YamlIgnore, JsonIgnore]
    public bool Proficiency => Property.Calculated(() => PC.SkillsProficiencies.Contains(ID) || AnyRules());


    #region Mod

    [YamlIgnore, JsonIgnore]
    private AnnotatedNumber<int> ModBase => Property.Calculated(() => new AnnotatedNumber<int> { Value = Ability.Mod, Description = $"{Ability.Mod:+0;-#} ({Ability.Name})" });

    [YamlIgnore, JsonIgnore]
    private AnnotatedNumber<int> ModProficiency => Property.Calculated(() => new AnnotatedNumber<int> { Value = (Proficiency ? PC.ProficiencyBonus : 0), Description = (Proficiency ? $"{PC.ProficiencyBonus:+0;-#} (Maitrise)" : "") });

    [YamlIgnore, JsonIgnore]
    private AnnotatedNumber<int> ModRulesSum => Property.Calculated(() => SumRules(nameof(Mod)));

    [YamlIgnore, JsonIgnore]
    public AnnotatedNumber<int> Mod => Property.Calculated(() => ModBase + ModProficiency + ModRulesSum);

    #endregion Mod


    public override string ToString()
    {
        return $"{ID} ({Ability})";
    }
}

public class Skills : BaseModel
{
    [YamlIgnore, JsonIgnore]
    private Dictionary<SkillID, Func<Skill>> _skills = new Dictionary<SkillID, Func<Skill>>();

    public Skills()
    {
        _skills = new Dictionary<SkillID, Func<Skill>>
        {
            [SkillID.Acrobatics] = () => Acrobatics,
            [SkillID.Arcana] = () => Arcana,
            [SkillID.Athletics] = () => Athletics,
            [SkillID.Stealth] = () => Stealth,
            [SkillID.Animal_Handling] = () => AnimalHandling,
            [SkillID.Sleight_Of_Hand] = () => SleightOfHand,
            [SkillID.History] = () => History,
            [SkillID.Intimidation] = () => Intimidation,
            [SkillID.Investigation] = () => Investigation,
            [SkillID.Medicine] = () => Medicine,
            [SkillID.Nature] = () => Nature,
            [SkillID.Perception] = () => Perception,
            [SkillID.Insight] = () => Insight,
            [SkillID.Persuasion] = () => Persuasion,
            [SkillID.Religion] = () => Religion,
            [SkillID.Performance] = () => Performance,
            [SkillID.Deception] = () => Deception,
            [SkillID.Survival] = () => Survival,
        };
    }

    public Skill Get(SkillID id, [CallerMemberName] string propertyName = null!)
    {
        return Property.Get(() => PC.Factory.CreateSkill(id), propertyName: propertyName);
    }
    public void Set(SkillID id, Skill skill, [CallerMemberName] string propertyName = null!)
    {
        skill.ID = id;
        Property.Set(skill, propertyName: propertyName);
    }

    /// <summary>
    /// Acrobaties
    /// </summary>
    public Skill Acrobatics { get => Get(SkillID.Acrobatics); set => Set(SkillID.Acrobatics, value); }
    /// <summary>
    /// Dressage
    /// </summary>
    public Skill AnimalHandling { get => Get(SkillID.Animal_Handling); set => Set(SkillID.Animal_Handling, value); }
    /// <summary>
    /// Arcanes
    /// </summary>
    public Skill Arcana { get => Get(SkillID.Arcana); set => Set(SkillID.Arcana, value); }
    /// <summary>
    /// Athlétisme
    /// </summary>
    public Skill Athletics { get => Get(SkillID.Athletics); set => Set(SkillID.Athletics, value); }
    /// <summary>
    /// Supercherie
    /// </summary>
    public Skill Deception { get => Get(SkillID.Deception); set => Set(SkillID.Deception, value); }
    /// <summary>
    /// Histoire
    /// </summary>
    public Skill History { get => Get(SkillID.History); set => Set(SkillID.History, value); }
    /// <summary>
    /// Perspicacité
    /// </summary>
    public Skill Insight { get => Get(SkillID.Insight); set => Set(SkillID.Insight, value); }
    /// <summary>
    /// Intimidation
    /// </summary>
    public Skill Intimidation { get => Get(SkillID.Intimidation); set => Set(SkillID.Intimidation, value); }
    /// <summary>
    /// Investigation
    /// </summary>
    public Skill Investigation { get => Get(SkillID.Investigation); set => Set(SkillID.Investigation, value); }
    /// <summary>
    /// Médecine
    /// </summary>
    public Skill Medicine { get => Get(SkillID.Medicine); set => Set(SkillID.Medicine, value); }
    /// <summary>
    /// Nature
    /// </summary>
    public Skill Nature { get => Get(SkillID.Nature); set => Set(SkillID.Nature, value); }
    /// <summary>
    /// Perception
    /// </summary>
    public Skill Perception { get => Get(SkillID.Perception); set => Set(SkillID.Perception, value); }
    /// <summary>
    /// Représentation
    /// </summary>
    public Skill Performance { get => Get(SkillID.Performance); set => Set(SkillID.Performance, value); }
    /// <summary>
    /// Persuasion
    /// </summary>
    public Skill Persuasion { get => Get(SkillID.Persuasion); set => Set(SkillID.Persuasion, value); }
    /// <summary>
    /// Religion
    /// </summary>
    public Skill Religion { get => Get(SkillID.Religion); set => Set(SkillID.Religion, value); }
    /// <summary>
    /// Escamotage
    /// </summary>
    public Skill SleightOfHand { get => Get(SkillID.Sleight_Of_Hand); set => Set(SkillID.Sleight_Of_Hand, value); }
    /// <summary>
    /// Discrétion
    /// </summary>
    public Skill Stealth { get => Get(SkillID.Stealth); set => Set(SkillID.Stealth, value); }
    /// <summary>
    /// Survie
    /// </summary>
    public Skill Survival { get => Get(SkillID.Survival); set => Set(SkillID.Survival, value); }

    public List<Skill> ToList()
    {
        return _skills.Values.Select(func => func.Invoke()).ToList();
    }

    //[YamlIgnore]
    //public int Count => _skills.Values.Count;
}
