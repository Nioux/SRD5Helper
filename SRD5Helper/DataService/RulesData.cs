using SRD5Helper.DataModels;
using SRD5Helper.ViewModels;
using System.Numerics;
using Library = SRD5Helper.Resources.Library;

namespace SRD5Helper.Data;

public partial class DataService
{
    private IReadOnlyList<Rule> _rulesData = new List<Rule>
    {
        new IntRule
        {            
            ID = Library.Rules.acharnement,
            TargetObject = pc => pc,
            TargetPropertyName = nameof(PlayerCharacter.CurrentHitPoints),
            CustomCondition = sender => ((sender as PlayerCharacter).CurrentHitPoints <= 0),
        },
        new EquipmentRule
        {
            ID = Library.Rules.maitrise_epee_longue,
            TargetObject = pc => pc,
            TargetPropertyName = nameof(PlayerCharacter.EquipmentProficiencies),
            Callback = sender => Library.Equipments.longsword,
        },
        new EquipmentRule
        {
            ID = Library.Rules.maitrise_epee_courte,
            TargetObject = pc => pc,
            TargetPropertyName = nameof(PlayerCharacter.EquipmentProficiencies),
            Callback = sender => Library.Equipments.shortsword,
        },
        new EquipmentRule
        {
            ID = Library.Rules.maitrise_arc_long,
            TargetObject = pc => pc,
            TargetPropertyName = nameof(PlayerCharacter.EquipmentProficiencies),
            Callback = sender => Library.Equipments.longbow,
        },
        new EquipmentRule
        {
            ID = Library.Rules.maitrise_arc_court,
            TargetObject = pc => pc,
            TargetPropertyName = nameof(PlayerCharacter.EquipmentProficiencies),
            Callback = sender => Library.Equipments.shortbow,
        },
        new EquipmentRule
        {
            ID = Library.Rules.maitrise_hachette,
            TargetObject = pc => pc,
            TargetPropertyName = nameof(PlayerCharacter.EquipmentProficiencies),
            Callback = sender => Library.Equipments.handaxe,
        },
        new EquipmentRule
        {
            ID = Library.Rules.maitrise_hache_a_deux_mains,
            TargetObject = pc => pc,
            TargetPropertyName = nameof(PlayerCharacter.EquipmentProficiencies),
            Callback = sender => Library.Equipments.greataxe,
        },
        new EquipmentRule
        {
            ID = Library.Rules.maitrise_hache_d_armes,
            TargetObject = pc => pc,
            TargetPropertyName = nameof(PlayerCharacter.EquipmentProficiencies),
            Callback = sender => Library.Equipments.battleaxe,
        },
        new EquipmentRule
        {
            ID = Library.Rules.maitrise_marteau_de_guerre,
            TargetObject = pc => pc,
            TargetPropertyName = nameof(PlayerCharacter.EquipmentProficiencies),
            Callback = sender => Library.Equipments.warhammer,
        },
        new EquipmentRule
        {
            ID = Library.Rules.maitrise_marteau_leger,
            TargetObject = pc => pc,
            TargetPropertyName = nameof(PlayerCharacter.EquipmentProficiencies),
            Callback = sender => Library.Equipments.light_hammer,
        },
        new BoolRule
        {
            ID = Library.Rules.sens_aiguises_elfe,
            TargetObject = pc => pc.Skills.Perception,
            TargetPropertyName = nameof(Skills.Perception.Proficiency),
            Callback = sender => true, // Const(true),
        },
        new IntRule
        {
            ID = Library.Rules.tenacite_naine,
            TargetObject = pc => pc,
            TargetPropertyName = nameof(PlayerCharacter.BonusHitPoints),
            Callback = TenaciteNaine,
        },
        new IntRule
        {
            ID = Library.Rules.amelioration_de_caracteristique_strength,
            TargetObject = pc => pc.Abilities.Strength,
            TargetPropertyName = nameof(Ability.Score),
            Callback = sender => 1,
        },
        new IntRule
        {
            ID = Library.Rules.amelioration_de_caracteristique_dexterity,
            TargetObject = pc => pc.Abilities.Dexterity,
            TargetPropertyName = nameof(Ability.Score),
            Callback = sender => 1,
        },
        new IntRule
        {
            ID = Library.Rules.amelioration_de_caracteristique_constitution,
            TargetObject = pc => pc.Abilities.Constitution,
            TargetPropertyName = nameof(Ability.Score),
            Callback = sender => 1,
        },
        new IntRule
        {
            ID = Library.Rules.amelioration_de_caracteristique_intelligence,
            TargetObject = pc => pc.Abilities.Intelligence,
            TargetPropertyName = nameof(Ability.Score),
            Callback = sender => 1,
        },
        new IntRule
        {
            ID = Library.Rules.amelioration_de_caracteristique_wisdom,
            TargetObject = pc => pc.Abilities.Wisdom,
            TargetPropertyName = nameof(Ability.Score),
            Callback = sender => 1,
        },
        new IntRule
        {
            ID = Library.Rules.amelioration_de_caracteristique_charisma,
            TargetObject = pc => pc.Abilities.Charisma,
            TargetPropertyName = nameof(Ability.Score),
            Callback = sender => 1,
        },
        new IntRule
        {
            ID = Library.Rules.expertise_vie_soins,
            TargetObject = pc => pc.Skills.Medicine,
            TargetPropertyName = nameof(Skill.Mod),
            CustomCondition = sender => ((sender as Skill).Proficiency),
            Callback = Expertise,
        },
        new IntRule
        {
            ID = Library.Rules.expertise_discretion,
            TargetObject = pc => pc.Skills.Stealth,
            TargetPropertyName = nameof(Skill.Mod),
            CustomCondition = sender => ((sender as Skill).Proficiency),
            Callback = Expertise,
        },
        new IntRule
        {
            ID = Library.Rules.expertise_supercherie,
            TargetObject = pc => pc.Skills.Deception,
            //DependsOn = new [] { "Skills.Deception.Proficiency" },
            TargetPropertyName = nameof(Skill.Mod),
            CustomCondition = sender => ((sender as Skill).Proficiency),
            Callback = Expertise,
        },
        new BoolRule
        {
            ID = Library.Rules.maitrise_armures,
            TargetObjectType = typeof(Equipment),
            TargetPropertyName = nameof(Equipment.Proficiency),
            CustomCondition = (sender) => EquipmentType.Armor.HasFlag((sender as Equipment).Type),
            Callback = sender => true, // Const(true),
        },
        new IntRule
        {
            ID = Library.Rules.style_de_combat_archerie,
            TargetObjectType = typeof(Equipment),
            TargetPropertyName = nameof(Equipment.RangeAttackModifier),
            Callback = Const(2), // (sender) => 2,
        },
        new IntRule
        {
            ID = Library.Rules.style_de_combat_defense,
            TargetObject = pc => pc,
            TargetPropertyName = nameof(PlayerCharacter.ArmorClass),
            Callback = Const(1),
        },
        new IntRule
        {
            ID = Library.Rules.condition_prone_attaque_desavantage,
            TargetObjectType = typeof(Equipment),
            TargetPropertyName = nameof(Equipment.AttackDisadvantage),
            //CustomCondition = (self, sender) => EquipmentType.Armor.HasFlag((sender as Equipment).Datum.Type),
            Callback = sender => 1,
        },
    };

    //static bool True(bool self, BaseModel sender) => true;
    //static int Increment(int self, BaseModel sender) => self + 1;
    //static int SkillExpertise(int self, BaseModel sender) => self + ((sender as Skill).Proficiency.Value ? sender.PC.ProficiencyBonus : 0);
    //static int TenaciteNaine(int self, BaseModel sender) => self + sender.PC.Level;
    //public static Func<BaseModel, T> Const<T>(T val) => (sender) => val;
    public static Func<BaseModel, T> Const<T>(T val) => (sender) => val;
    public static bool True(BaseModel sender) => true;
    public static int Expertise(BaseModel sender) => sender.PC.ProficiencyBonus; // ((sender as Skill).Proficiency.Value ? sender.PC.ProficiencyBonus : 0);
    public static int TenaciteNaine(BaseModel sender) => sender.PC.Level;



    private IReadOnlyDictionary<string, Rule> _rulesDataMap = null;
    public IReadOnlyDictionary<string, Rule> RulesData => _rulesDataMap ??= _rulesData.ToDictionary(s => s.ID, s => s);
}