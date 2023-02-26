using SRD5Helper.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library = SRD5Helper.Resources.Library;

namespace SRD5Helper.Data;

public partial class DataService
{
    private IReadOnlyList<SubBackgroundDatum> _subBackgroundsData = new List<SubBackgroundDatum>
    {
    };

    private IReadOnlyDictionary<string, SubBackgroundDatum> _subBackgroundsDataMap = null;
    public IReadOnlyDictionary<string, SubBackgroundDatum> SubBackgroundsData => _subBackgroundsDataMap ??= _subBackgroundsData.ToDictionary(s => s.ID, s => s);

    private IReadOnlyList<BackgroundDatum> _backgroundsData = new List<BackgroundDatum>
    {
        new()
        {
            ID = Library.Backgrounds.erudit,
            SkillsProficiencies = new[]
            {
                SkillID.Arcana,
                SkillID.History,
            },
            LanguagesChoices = new string[]
            {
                //Resources.Library.Languages.
            },
            InitialEquipment = new[]
            {
                Library.Equipments.bougie,
                //...
            },
            InitialMoney = Money.FromGP(20),
        },
        new()
        {
            ID = Library.Backgrounds.sage,
            SkillsProficiencies = new[]
            {
                SkillID.Arcana,
                SkillID.History,
            },
            LanguagesChoices = new string[]
            {
                //Resources.Library.Languages.
            },
            InitialEquipment = new[]
            {
                Library.Equipments.bougie,
                //...
            },
            InitialMoney = Money.FromGP(20),
        },
        new()
        {
            ID = Library.Backgrounds.heros_du_peuple,
            SkillsProficiencies = new SkillID[]
            {
                SkillID.Animal_Handling,
                SkillID.Survival,
            },
            SkillsProficienciesChoices = new SkillID[]
            {
                //Resources.Library.Skills.arcana,
                //Resources.Library.Skills.history,
            },
            LanguagesChoices = new string[]
            {
            },
            InitialEquipment = new string[]
            {
                //...
            },
            InitialMoney = Money.FromGP(20),
        },
        new()
        {
            ID = Library.Backgrounds.enfant_des_rues, // orphelin
            SkillsProficiencies = new[]
            {
                SkillID.Sleight_Of_Hand,
            },
            SkillsProficienciesChoices = new[]
            {
                SkillID.Acrobatics,
                SkillID.Stealth,
            },
            LanguagesChoices = new string[]
            {
            },
            InitialEquipment = new string[]
            {
                //...
            },
            InitialMoney = Money.FromGP(5),
        },
        new()
        {
            ID = Library.Backgrounds.acolyte,
            SkillsProficiencies = new[]
            {
                SkillID.Insight,
                SkillID.Religion,
            },
            LanguagesChoices = new string[]
            {
            },
            InitialEquipment = new string[]
            {
                //...
            },
            InitialMoney = Money.FromGP(10),
        },
        new()
        {
            ID = Library.Backgrounds.manouvrier,
            SkillsProficiencies = new[]
            {
                SkillID.Athletics,
                SkillID.Sleight_Of_Hand,
            },
            LanguagesChoices = new string[]
            {
            },
            InitialEquipment = new string[]
            {
                //...
            },
            InitialMoney = Money.FromGP(10),
        },
        new()
        {
            ID = Library.Backgrounds.sang_bleu,
            SkillsProficiencies = new[]
            {
                SkillID.History,
                SkillID.Persuasion,
            },
            LanguagesChoices = new string[]
            {
            },
            InitialEquipment = new string[]
            {
                //...
            },
            InitialMoney = Money.FromGP(20),
        },
        new()
        {
            ID = Library.Backgrounds.primitif,
            SkillsProficiencies = new[]
            {
                SkillID.Animal_Handling,
                SkillID.Survival,
            },
            LanguagesChoices = new string[]
            {
            },
            InitialEquipment = new string[]
            {
                //...
            },
            InitialMoney = Money.FromGP(10),
        },
        new()
        {
            ID = Library.Backgrounds.membre_de_guilde,
            SkillsProficiencies = new[]
            {
                SkillID.Insight,
                SkillID.Persuasion,
            },
            LanguagesChoices = new string[]
            {
            },
            InitialEquipment = new string[]
            {
                //...
            },
            InitialMoney = Money.FromGP(20),
        },
        new()
        {
            ID = Library.Backgrounds.explorateur,
            SkillsProficiencies = new SkillID[]
            {
            },
            SkillsProficienciesChoices = new[]
            {
                SkillID.Athletics,
                SkillID.Survival,
            },
            LanguagesChoices = new string[]
            {
            },
            InitialEquipment = new string[]
            {
                //...
            },
            InitialMoney = Money.FromGP(15),
        },
        new()
        {
            ID = Library.Backgrounds.militaire,
            SkillsProficiencies = new SkillID[]
            {
            },
            SkillsProficienciesChoices = new[]
            {
                SkillID.Athletics,
                SkillID.Intimidation,
            },
            LanguagesChoices = new string[]
            {
            },
            InitialEquipment = new string[]
            {
                //...
            },
            InitialMoney = Money.FromGP(15),
        },
        new()
        {
            ID = Library.Backgrounds.dummy,
            SkillsProficiencies = new SkillID[]
            {
            },
            SkillsProficienciesChoices = new SkillID[]
            {
            },
            LanguagesChoices = new string[]
            {
            },
            InitialEquipment = new string[]
            {
                //...
            },
            InitialMoney = Money.FromGP(20),
        },
    };

    private IReadOnlyDictionary<string, BackgroundDatum> _backgroundsDataMap = null;
    public IReadOnlyDictionary<string, BackgroundDatum> BackgroundsData => _backgroundsDataMap ??= _backgroundsData.ToDictionary(s => s.ID, s => s);
}
