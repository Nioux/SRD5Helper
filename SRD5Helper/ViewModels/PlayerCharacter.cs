using SRD5Helper.DataModels;
using System.Collections;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;
using YamlDotNet.Serialization;
using Library = SRD5Helper.Resources.Library;

namespace SRD5Helper.ViewModels;

public class PlayerCharacterObjectFactory : YamlDotNet.Serialization.IObjectFactory 
    {
    public PlayerCharacter PC = null;
    public object Create(Type type)
    {
        var obj = Activator.CreateInstance(type);
        if (obj is PlayerCharacter)
        {
            PC = obj as PlayerCharacter;
        }
        if (obj is BaseModel)
        {
            (obj as BaseModel).PC = PC;
        }
        return obj;
    }

    public T Create<T, TKey, TDatum>(Type type, TKey id) where T : BaseModel where TDatum : struct
    {
        var obj = Create(type) as T;
        var dr = obj as DatumReference<TKey, TDatum>;
        if (dr != null)
        {
            dr.ID = id;
        }
        return obj;
    }

    public Origin CreateOrigin(string id)
    {
        var obj = Create(typeof(Origin)) as Origin;
        obj.ID = id;
        return obj;
    }

    public Background CreateBackground(string id)
    {
        var obj = Create(typeof(Background)) as Background;
        obj.ID = id;
        return obj;
    }

    public Class CreateClass(string id, int level)
    {
        var obj = Create(typeof(Class)) as Class;
        obj.ID = id;
        obj.Level = level;
        //while (obj.Level < level)
        //{
        //    obj.UpLevel();
        //}
        return obj;
    }

    public Equipment CreateEquipment(string id, bool isEquipped = false, int quantity = 1)
    {
        var obj = Create(typeof(Equipment)) as Equipment;
        obj.ID = id;
        obj.IsEquipped = isEquipped;
        obj.Quantity = quantity;
        return obj;
    }

    public Feature CreateFeature(string id, int? level = null, bool? isEnabled = null)
    {
        var obj = Create(typeof(Feature)) as Feature;
        obj.ID = id;
        if (level.HasValue)
        {
            obj.Level = level;
        }
        if (isEnabled.HasValue)
        {
            obj.IsEnabled = isEnabled.Value;
        }
        return obj;
    }
    public Abilities CreateAbilities()
    {
        return Create(typeof(Abilities)) as Abilities;
    }

    public Ability CreateAbility(AbilityID id)
    {
        var obj = Create(typeof(Ability)) as Ability;
        obj.ID = id;
        return obj;
    }
    public Skills CreateSkills()
    {
        return Create(typeof(Skills)) as Skills;
    }
    public Skill CreateSkill(SkillID id)
    {
        var obj = Create(typeof(Skill)) as Skill;
        obj.ID = id;
        return obj;
    }

    public Conditions CreateConditions()
    {
        return Create(typeof(Conditions)) as Conditions;
    }
    public Condition CreateCondition(ConditionID id)
    {
        var obj = Create(typeof(Condition)) as Condition;
        obj.ID = id;
        return obj;
    }

    public Spell CreateSpell(string id, string classID, string archetypeID = null)
    {
        var obj = Create(typeof(Spell)) as Spell;
        obj.ID = id;
        obj.ClassID = classID;
        obj.ArchetypeID = archetypeID;
        return obj;
    }

    public object CreatePrimitive(Type type) {
        throw new NotImplementedException();
    }

    public bool GetDictionary(IObjectDescriptor descriptor, out IDictionary dictionary, out Type[] genericArguments) {
        throw new NotImplementedException();
    }

    public Type GetValueType(Type type) {
        throw new NotImplementedException();
    }
}

public partial class PlayerCharacter : BaseModel
{
    [YamlIgnore, JsonIgnore]
    public PlayerCharacterObjectFactory Factory = new PlayerCharacterObjectFactory();

    public PlayerCharacter()
    {
        PC = this;
        Factory.PC = this;
    }


    /// <summary>
    /// Caractéristiques
    /// </summary>
    public Abilities Abilities { get => Property.Get(() => Factory.CreateAbilities()); init => Property.Set(value); }

    /// <summary>
    /// Niveau
    /// </summary>
    [DisplayName("Niveau")]
    [YamlIgnore, JsonIgnore]
    public int Level => Property.Calculated(() => Classes.Sum(cl => cl.Level));


    /// <summary>
    /// Bonus de maîtrise
    /// </summary>
    [YamlIgnore, JsonIgnore]
    public int ProficiencyBonus => Property.Calculated(() => ((Level - 1) / 4) + 2);
    /// <summary>
    /// Perception passive
    /// </summary>
    [YamlIgnore, JsonIgnore]
    public int PassiveWisdom => Property.Calculated(() => 10 + Abilities.Wisdom.Mod);

    /// <summary>
    /// Classe d'armure
    /// </summary>
    [YamlIgnore, JsonIgnore]
    [DisplayName(nameof(Library.Equipments.bouclier_name))]
    public int ArmorClass => Property.Calculated(() =>
    {
        int armor = Armor?.ArmorClass ?? 10;
        int shield = Shield?.ArmorClassModifier ?? 0;
        int dexterity = (Armor?.Heaviness == WeaponHeaviness.Heavy) ? 0 : Abilities.Dexterity.Mod;
        return armor + shield + dexterity + SumRules();
    });

    [YamlIgnore, JsonIgnore]
    public int MeleeAttackBonus => Property.Calculated(() => Abilities.Strength.Mod + ProficiencyBonus);

    [YamlIgnore, JsonIgnore]
    public int RangedAttackBonus => Property.Calculated(() => Abilities.Dexterity.Mod + ProficiencyBonus);

    /// <summary>
    /// Initiative
    /// </summary>
    [YamlIgnore, JsonIgnore]
    public int Initiative => Property.Calculated(() => Abilities.Dexterity.Mod);

    /// <summary>
    /// DD des jets de sauvegarde des sorts
    /// </summary>
    [YamlIgnore, JsonIgnore]
    public int? SpellSaveDC => Property.Calculated(() => SpellAttackBonus != null ? (8 + SpellAttackBonus) : null);
    
    /// <summary>
    /// Bonus attaque magique
    /// </summary>
    [YamlIgnore, JsonIgnore]
    public int? SpellAttackBonus => Property.Calculated<int?>(() => SpellcastingAbility != null ? (SpellcastingAbility.Mod + ProficiencyBonus) : null);


    [YamlIgnore, JsonIgnore]    
    public Class SpellcastingClass => Classes.Where(classLevel => classLevel.SpellcastingAbility != null).FirstOrDefault();
    
    [YamlIgnore, JsonIgnore]    
    public AbilityID? SpellcastingAbilityID => Property.Calculated(() => Classes.FirstOrDefault().SpellcastingAbility);
    
    [YamlIgnore, JsonIgnore]
    public Ability SpellcastingAbility => Property.Calculated(() => SpellcastingAbilityID != null ? Abilities.GetValueOrDefault(SpellcastingAbilityID.Value) : null);

    #region Hit Points
    [YamlIgnore, JsonIgnore]
    public int BonusHitPoints => Property.Calculated(() => Level * Abilities.Constitution.Mod + SumRules());

    [YamlIgnore, JsonIgnore]
    public int TotalCurrentHitPoints => Property.Calculated(() => CurrentHitPoints + BonusHitPoints + SumRules());

    /// <summary>
    /// Points de vie maximum
    /// </summary>
    [YamlIgnore, JsonIgnore]
    public int CurrentHitPoints => Property.Calculated(() => Classes.Sum(cl => cl.HitPoints));

    /// <summary>
    /// Points de vie actuels
    /// </summary>
    [YamlIgnore, JsonIgnore]
    public int TotalTemporaryHitPoints => Property.Calculated(() => TemporaryHitPoints + BonusHitPoints + SumRules());

    public int TemporaryHitPoints { get => Property.Get(0); set => Property.Set(value); }

    /// <summary>
    /// Dés de vie
    /// </summary>
    [YamlIgnore, JsonIgnore]
    public int HitDice => Property.Calculated(() => PrimaryClass.HitDice);
    #endregion Hit Points

    /// <summary>
    /// Compétences
    /// </summary>
    //[YamlIgnore, JsonIgnore]
    public Skills Skills { get => Property.Get(() => Factory.CreateSkills()); init => Property.Set(value); }

    /// <summary>
    /// Nom du personnage
    /// </summary>
    public string CharacterName { get => Property.Get(string.Empty); set => Property.Set(value); }

    /// <summary>
    /// Image du personnage
    /// </summary>
    public string CharacterPicture { get => Property.Get(string.Empty); set => Property.Set(value); }

    /// <summary>
    /// Petit image du personnage
    /// </summary>
    public string CharacterSmallPicture { get => Property.Get(string.Empty); set => Property.Set(value); }

    /// <summary>
    /// Nom du joueur
    /// </summary>
    public string PlayerName { get => Property.Get(string.Empty); set => Property.Set(value); }

    public GenderID Gender { get => Property.Get(GenderID.Null); set => Property.Set(value); }

    /// <summary>
    /// Classes et niveau par classe
    /// </summary>
    public ObservableCollection<Class> Classes { get => Property.Get(() => new ObservableCollection<Class>()); set => Property.Set(value); }
    
    [YamlIgnore, JsonIgnore]
    public Class PrimaryClass => Property.Calculated(() => Classes.FirstOrDefault());

    /// <summary>
    /// Origine du personnage
    /// </summary>
    [YamlMember(Alias = nameof(Origin))]
    public Origin Origin { get => Property.Get<Origin>(() => null); set => Property.Set(value); }

    /// <summary>
    /// Histoire personnelle
    /// </summary>
    [YamlMember(Alias = nameof(Background))]
    public Background Background { get => Property.Get<Background>(() => null); set => Property.Set(value); }

    /// <summary>
    /// Autres compétences et languages
    /// </summary>
    public string OtherProficiencies { get => Property.Get(string.Empty); set => Property.Set(value); }

    public string Languages { get => Property.Get(string.Empty); set => Property.Set(value); }



    #region Equipment
    /// <summary>
    /// Toutes les armes équipées
    /// </summary>
    [YamlIgnore, JsonIgnore]
    public IReadOnlyList<Equipment> Weapons => Property.Calculated(() => EquipmentRefs.Where(slot => slot.IsEquipped && EquipmentType.Weapon.HasFlag(slot.Type)).ToList());
    
    /// <summary>
    /// Le bouclier équipé avec le meilleur mod
    /// </summary>
    [YamlIgnore, JsonIgnore]
    public Equipment Shield => Property.Calculated(() => EquipmentRefs.Where(slot => slot.IsEquipped && EquipmentType.Shield.HasFlag(slot.Type)).MaxBy(slot => slot.ArmorClassModifier));
    
    /// <summary>
    /// L'armure équipée avec la meilleure CA
    /// </summary>
    [YamlIgnore, JsonIgnore]
    public Equipment Armor => Property.Calculated(() => EquipmentRefs.Where(slot => slot.IsEquipped && EquipmentType.Armor.HasFlag(slot.Type)).MaxBy(slot => slot.ArmorClass));
    

    /// <summary>
    /// Equipement
    /// </summary>
    public EquipmentRefs EquipmentRefs { get => Property.Get(() => new EquipmentRefs()); init => Property.Set(value); }
    #endregion Equipment



    #region Proficiencies
    [YamlIgnore, JsonIgnore]
    public IReadOnlySet<EquipmentTypeRef> EquipmentProficienciesRules => Property.Calculated(() => EquipmentRules(nameof(EquipmentProficiencies)));

    //[YamlIgnore, JsonIgnore]
    //private HashSet<EquipmentTypeRef> _equipmentProficiencies = null;

    /// <summary>
    /// Maitrises d'équipement
    /// </summary>
    [YamlIgnore, JsonIgnore]
    //public IReadOnlySet<EquipmentTypeRef> EquipmentProficiencies => Property.Calculated(() => _equipmentProficiencies ??= PrimaryClass?.EquipmentProficiencies?.Union(EquipmentProficienciesRules)?.ToHashSet() ?? new HashSet<EquipmentTypeRef>());
    public IReadOnlySet<EquipmentTypeRef> EquipmentProficiencies => Property.Calculated(() => Classes.SelectMany((Class cl) => cl?.EquipmentProficiencies)?.Union(EquipmentProficienciesRules)?.ToHashSet() ?? new HashSet<EquipmentTypeRef>());

    [YamlIgnore, JsonIgnore]
    public IReadOnlySet<SkillID> SkillsProficiencies => Property.Calculated(() => Classes.SelectMany(cl => cl.SelectedSkillProficiencies).Concat(Background?.SelectedSkillProficiencies ?? new HashSet<SkillID>()).ToHashSet());
    //public IReadOnlySet<SkillID> SkillsProficiencies => Property.Calculated(() => PrimaryClass.SelectedSkillProficiencies.Concat(Background.SelectedSkillProficiencies).ToHashSet());

    [YamlIgnore, JsonIgnore]
    public IReadOnlySet<AbilityID> AbilitiesSaveProficiencies => Property.Calculated(() => Classes.SelectMany(cl => cl?.SavesProficiencies).ToHashSet());
    #endregion Proficiencies

    public Money Treasure { get; set; }


    #region Rules
    [YamlIgnore, JsonIgnore]
    public IReadOnlyList<Rule> ClassRules => Property.Calculated(() => ClassFeatures.SelectMany(feature => feature?.Rules ?? new Rule[] { })?.ToList());

    [YamlIgnore, JsonIgnore]
    public IReadOnlyList<Rule> OriginRules => Property.Calculated(() => OriginFeatures.SelectMany(feature => feature?.Rules ?? new Rule[] { })?.ToList());

    [YamlIgnore, JsonIgnore]
    public IReadOnlyList<Rule> SelectedRules => Property.Calculated(() => SelectedFeaturesForLevel.SelectMany(feature => feature?.Rules ?? new Rule[] { })?.ToList());

    [YamlIgnore, JsonIgnore]
    public IReadOnlyList<Rule> Rules => Property.Calculated(() => OriginRules.Concat(ClassRules).Concat(SelectedRules).ToList());
    #endregion Rules

    #region Features
    [YamlIgnore, JsonIgnore]
    public IReadOnlyList<Feature> AllAvailableClassFeatures => Property.Calculated(() =>
    {
        return Classes.SelectMany(cl => cl.AllFeatures).ToList();
    });

    [YamlIgnore, JsonIgnore]
    public IReadOnlyList<Feature> ClassFeatures => Property.Calculated(() =>
    {
        return Classes.SelectMany(cl => cl.Features ?? new List<Feature>()).ToList();
    });

    [YamlIgnore, JsonIgnore]
    public IReadOnlyList<Feature> OriginFeatures => Property.Calculated(() => Origin?.Features ?? new List<Feature>());

    public ObservableCollection<Feature> SelectedFeatures { get => Property.Get(() => new ObservableCollection<Feature>()); set => Property.Set(value); }

    [YamlIgnore, JsonIgnore]
    public IReadOnlyList<Feature> SelectedFeaturesForLevel => Property.Calculated(() => SelectedFeatures.Where(feat => (feat.Level ?? 1) <= Level).ToList());

    [YamlIgnore, JsonIgnore]
    public IReadOnlyList<Feature> Features => Property.Calculated(() => OriginFeatures.Concat(ClassFeatures).Concat(SelectedFeaturesForLevel).ToList());

    #endregion Features


    public int DeathSaves { get; set; }
    public string PersonalityTraits { get; set; }
    public string Ideals { get; set; }
    public string Bonds { get; set; }
    public string Flaws { get; set; }



    public string Speed { get; set; }
    
    public string Attacks { get; set; }


    #region Spells

    /// <summary>
    /// Liste des sorts accessibles pour cette classe (pas de multiclassing pour l'instant)
    /// La liste est initialisée et stockée, nécessite donc un reset en cas de changement de classe
    /// Par contre, elle comprend tous les niveaux, donc pas de changement en cas d'up level
    /// </summary>
    [YamlIgnore, JsonIgnore]
    public IReadOnlyList<Spell> AllAvailableSpells => Property.Calculated(() =>
    {
        return Classes.SelectMany(cl => cl?.Spells.OrderBy(s => s.Level).ToList() ?? new List<Spell>()).ToList();
    });

    [YamlIgnore, JsonIgnore]
    public IReadOnlyList<Spell> SpellRefs => Property.Calculated(() => AllAvailableSpells.Where(spell => spell.IsAvailable).ToList());

    /*[YamlIgnore, JsonIgnore]
    public int[] SpellSlotsByLevel => Property.Calculated(() =>
    {
        return PrimaryClass.SpellSlotsByLevel;
    });

    [YamlIgnore, JsonIgnore]
    public int[] FreeSpellSlotsByLevel
    {
        get
        {
            return new int[] { 0, 3, 2, 1 };
        }
    }*/

    [YamlIgnore, JsonIgnore]
    public IReadOnlyList<SpellGroupByLevel> SpellRefsByLevel => Property.Calculated(() =>
    {
        try
        {
            /*if (SpellSlotsByLevel != null && SpellSlotsByLevel.Length > 0)
            {
                var spells = SpellRefs
                    .GroupBy(spellRef => spellRef.Level)
                    .Select((group) => new SpellGroupByLevel(group.Key, 0, SpellSlotsByLevel[group.Key], group.ToList()))
                    .OrderBy(group => group.Level)
                    .ToList();
                return spells;
            }
            else
            {*/
                return SpellRefs
                    .GroupBy(spellRef => spellRef.Level)
                    .Select((group) => new SpellGroupByLevel(group.Key, 0, 0, group.ToList()))
                    .OrderBy(group => group.Level)
                    .ToList();
            //}
        }
        catch (Exception ex)
        {
            return null;
        }
    });

    public string Spellcasting { get; set; }

    #endregion Spells


    [YamlIgnore, JsonIgnore]
    public IReadOnlyList<PlayerAction> Actions => Property.Calculated(() =>
    {
        var weapons = Weapons.Select(weapon => new PlayerAction { Category = "Attaquer", Name = weapon.Name, Item = weapon });
        var spells = SpellRefs.Where(s => s.IsCastable).Select(spell => new PlayerAction { Category = "Lancer un sort", Name = spell.Name, Item = spell });
        var others = new PlayerAction[]
        {
            new PlayerAction
            {
                Category = "Aider",
                Name = "Un combattant peut apporter son aide à un autre.",
                Description = "Le combattant aidé obtient l’avantage sur son prochain test de caractéristique (même si celui-ci a lieu au round suivant), si ce test correspond à l’action pour laquelle le premier a apporté son aide. En combat, pour aider un allié, il faut se trouver à 1,50 mètre de lui au maximum. Le PJ qui aide, en déconcentrant l’adversaire ou en soutenant son allié, permet au personnage aidé de bénéficier de l’avantage sur son premier jet d’attaque.",
            },
            new PlayerAction
            {
                Category = "Chercher",
                Name = "Cette action consiste à consacrer son tour à la recherche d’un élément particulier.",
            },
            new PlayerAction
            {
                Category = "Esquiver",
            },
            new PlayerAction
            {
                Category = "Se cacher",
            },
            new PlayerAction
            {
                Category = "Se précipiter",
            },
            new PlayerAction
            {
                Category = "Se tenir prêt",
            },
            new PlayerAction
            {
                Category = "Utiliser un objet",
            },
            new PlayerAction
            {
                Category = "Autre chose ?",
            },
        };

        var actions = weapons.Concat(spells).Concat(others);
        return actions.ToList();
    });

    public Conditions Conditions { get => Property.Get(() => PC.Factory.CreateConditions()); init => Property.Set(value); }

    public string Alignment { get; set; }
    public int ExperiencePoints { get; set; }


    public int Age { get; set; }
    public int Height { get; set; }
    public int Weight { get; set; }
    public string Eyes { get; set; }
    public string Skin { get; set; }
    public string Hair { get; set; }
    public string CharacterAppearance { get; set; }
    public string CharacterBackstory { get; set; }
    public string AlliesAndOrganizations { get; set; }

    public override string ToString()
    {
        if (PC == null) return null;
        var md = string.Empty;
        md += $"{CharacterName}\n";
        foreach (var weapon in Weapons)
        {
            if (weapon.MeleeDamage != null || weapon.TwoHandledMeleeDamage != null)
            {
                md += $"{weapon.ID} {weapon.MeleeAttackModifier} {weapon.MeleeDamage ?? weapon.TwoHandledMeleeDamage} {weapon.Proficiency}\n";
            }
            if (weapon.RangeDamage != null)
            {
                md += $"{weapon.ID} (distance) {weapon.RangeAttackModifier} {weapon.RangeDamage} {weapon.Proficiency}\n";
            }
        }
        foreach (var proficiency in EquipmentProficiencies)
        {
            md += $"{proficiency} ";
        }
        md += "\n";
        foreach (var spell in AllAvailableSpells)
        {
            md += $"{spell.ID}\n";
        }
        return md;
    }

    public void Refresh()
    {
        OnPropertiesChanged(nameof(Rules));
        OnPropertiesChanged(null);
    }
}

public class PlayerAction
{
    public BaseModel Item { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Category { get; set; }
}
