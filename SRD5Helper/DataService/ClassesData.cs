using SRD5Helper.DataModels;
using SRD5Helper.ViewModels;
using Library = SRD5Helper.Resources.Library;

namespace SRD5Helper.Data;

public partial class DataService
{
    private IReadOnlyList<ClassArchetypeDatum> _classArchetypesData = new List<ClassArchetypeDatum>
    {
        // Clerc
        //new()
        //{
        //    ID = Library.Archetypes.pretre_vie_soins,
        //    AlwaysPreparedSpellsTable = new List<string>[]
        //    {
        //        new() { Library.Spells.soin_des_blessures, }, // 1
        //        new() { }, // 2
        //        new() { Library.Spells.restauration_inferieure, }, // 3
        //        new() { }, // 4
        //        new() { }, //"vitalite", }, // 5
        //        new() { }, // 6
        //        new() { }, //"panacee", }, // 7
        //        new() { }, // 8
        //        new() { }, //"restauration-superieure", }, // 9
        //        new() { }, // 10
        //        new() { }, // 11
        //        new() { }, // 12
        //        new() { }, // 13
        //        new() { }, // 14
        //        new() { }, // 15
        //        new() { }, // 16
        //        new() { }, // 17
        //        new() { }, // 18
        //        new() { }, // 19
        //        new() { }, // 20
        //    },
        //    FeaturesTable = new List<string>[]
        //    {
        //        new () {}, // 1
        //        new () { Library.Features.canalisation_d_energie_divine, Library.Features.salve_de_guerison, }, // 2
        //        new () {}, // 3
        //        new () {}, // 4
        //        new () {}, // 5
        //        new () {}, // 6
        //        new () {}, // 7
        //        new () {}, // 8
        //        new () {}, // 9
        //        new () {}, // 10
        //        new () {}, // 11
        //        new () {}, // 12
        //        new () {}, // 13
        //        new () {}, // 14
        //        new () {}, // 15
        //        new () {}, // 16
        //        new () {}, // 17
        //        new () {}, // 18
        //        new () {}, // 19
        //        new () {}, // 20
        //    },
        //},
        // Druide
        //new()
        //{
        //    ID = Library.Archetypes.cercle_des_profondeurs,
        //    FeaturesTable = new List<string>[]
        //    {
        //        new () {}, // 1
        //        new () { Library.Features.enfant_des_tenebres, Library.Features.forme_monstrueuse, }, // 2
        //        new () {}, // 3
        //        new () {}, // 4
        //        new () {}, // 5
        //        new () { "pouvoir-des-profondeurs", }, // 6
        //        new () {}, // 7
        //        new () {}, // 8
        //        new () {}, // 9
        //        new () { "magie-des-profondeurs", }, // 10
        //        new () {}, // 11
        //        new () {}, // 12
        //        new () {}, // 13
        //        new () { "deplacement-souterrain", }, // 14
        //        new () {}, // 15
        //        new () {}, // 16
        //        new () {}, // 17
        //        new () {}, // 18
        //        new () {}, // 19
        //        new () {}, // 20
        //    },
        //},
        // Ensorceleur
        //new()
        //{
        //    ID = Library.Archetypes.lignee_infernale,
        //    FeaturesTable = new List<string>[]
        //    {
        //        new () { Library.Features.ancetre_fielon, Library.Features.resistance_des_fielons, }, // 1
        //        new () {}, // 2
        //        new () {}, // 3
        //        new () {}, // 4
        //        new () {}, // 5
        //        new () { "magie-du-sang" }, // 6
        //        new () {}, // 7
        //        new () {}, // 8
        //        new () {}, // 9
        //        new () {}, // 10
        //        new () {}, // 11
        //        new () {}, // 12
        //        new () {}, // 13
        //        new () { "resistance-superieure" }, // 14
        //        new () {}, // 15
        //        new () {}, // 16
        //        new () {}, // 17
        //        new () { "forme-infernale", }, // 18
        //        new () {}, // 19
        //        new () {}, // 20
        //    },
        //},
        // Guerrier
        //new()
        //{
        //    ID = Library.Archetypes.champion,
        //    FeaturesTable = new List<string>[]
        //    {
        //        new () {}, // 1
        //        new () {}, // 2
        //        new () { Library.Features.critique_ameliore, }, // 3
        //        new () {}, // 4
        //        new () {}, // 5
        //        new () {}, // 6
        //        new () { "athlete-remarquable", }, // 7
        //        new () {}, // 8
        //        new () {}, // 9
        //        new () { "style-de-combat-supplementaire" }, // 10
        //        new () {}, // 11
        //        new () {}, // 12
        //        new () {}, // 13
        //        new () {}, // 14
        //        new () { "critique-superieur", }, // 15
        //        new () {}, // 16
        //        new () {}, // 17
        //        new () { "survivant", }, // 18
        //        new () {}, // 19
        //        new () {}, // 20
        //    },
        //},
        // Paladin
        //new()
        //{
        //    ID = Library.Archetypes.serment_de_devotion,
        //    FeaturesTable = new List<string>[]
        //    {
        //        new () {}, // 1
        //        new () {}, // 2
        //        new () { Library.Features.canalisation_d_energie_divine, Library.Features.arme_sacree, Library.Features.renvoi_des_impies, }, // 3
        //        new () {}, // 4
        //        new () {}, // 5
        //        new () {}, // 6
        //        new () { "aura-de-devotion", }, // 7
        //        new () {}, // 8
        //        new () {}, // 9
        //        new () {}, // 10
        //        new () {}, // 11
        //        new () {}, // 12
        //        new () {}, // 13
        //        new () {}, // 14
        //        new () { "purete-de-l-esprit", }, // 15
        //        new () {}, // 16
        //        new () {}, // 17
        //        new () {}, // 18
        //        new () {}, // 19
        //        new () { "halo-sacre", }, // 20
        //    },
        //    AlwaysPreparedSpellsTable = new List<string>[]
        //    {
        //        new() { }, // 1
        //        new() { }, // 2
        //        new() { "protection-contre-le-mal-et-le-bien", Library.Spells.sanctuaire, }, // 3
        //        new() { }, // 4
        //        new() { Library.Spells.restauration_inferieure, "zone-de-verite", }, // 5
        //        new() { }, // 6
        //        new() { }, // 7
        //        new() { }, // 8
        //        new() { "lueur-d-espoir", "dissipation-de-la-magie", }, // 9
        //        new() { }, // 10
        //        new() { }, // 11
        //        new() { }, // 12
        //        new() { "liberte-de-mouvement", "gardien-de-la-foi", }, // 13
        //        new() { }, // 14
        //        new() { }, // 15
        //        new() { }, // 16
        //        new() { "communion", "colonne-de-flamme", }, // 17
        //        new() { }, // 18
        //        new() { }, // 19
        //        new() { }, // 20
        //    },
        //},
        //new()
        //{
        //    ID = Library.Archetypes.serment_d_obedience,
        //    FeaturesTable = new List<string>[]
        //    {
        //        new () {}, // 1
        //        new () {}, // 2
        //        new () { Library.Features.canalisation_d_energie_divine, Library.Features.porte_etendard, Library.Features.tacticien, }, // 3
        //        new () {}, // 4
        //        new () {}, // 5
        //        new () {}, // 6
        //        new () { "cri-de-ralliement", }, // 7
        //        new () {}, // 8
        //        new () {}, // 9
        //        new () {}, // 10
        //        new () {}, // 11
        //        new () {}, // 12
        //        new () {}, // 13
        //        new () {}, // 14
        //        new () { "charge-heroique", }, // 15
        //        new () {}, // 16
        //        new () {}, // 17
        //        new () {}, // 18
        //        new () {}, // 19
        //        new () { "heros-de-guerre", }, // 20
        //    },
        //    AlwaysPreparedSpellsTable = new List<string>[]
        //    {
        //        new() { }, // 1
        //        new() { }, // 2
        //        new() { "alarme", Library.Spells.heroisme, }, // 3
        //        new() { }, // 4
        //        new() { Library.Spells.aide, "lien-de-protection", }, // 5
        //        new() { }, // 6
        //        new() { }, // 7
        //        new() { }, // 8
        //        new() { "envoi-de-message", "lueur-d-espoir", }, // 9
        //        new() { }, // 10
        //        new() { }, // 11
        //        new() { }, // 12
        //        new() { "liberte-de-mouvement", "terrain-hallucinatoire", }, // 13
        //        new() { }, // 14
        //        new() { }, // 15
        //        new() { }, // 16
        //        new() { "communion-avec-la-nature", "soin-des-blessures-de-groupe", }, // 17
        //        new() { }, // 18
        //        new() { }, // 19
        //        new() { }, // 20
        //    },
        //},
        // Rôdeur
        //new()
        //{
        //    ID = Library.Archetypes.archer_arcanique,
        //    FeaturesTable = new List<string>[]
        //    {
        //        new () {}, // 1
        //        new () {}, // 2
        //        new () { Library.Features.fleche_arcanique, }, // 3
        //        new () {}, // 4
        //        new () {}, // 5
        //        new () {}, // 6
        //        new () { "fleche-infaillible", }, // 7
        //        new () {}, // 8
        //        new () {}, // 9
        //        new () {}, // 10
        //        new () { "fleche-intangible", }, // 11
        //        new () {}, // 12
        //        new () {}, // 13
        //        new () {}, // 14
        //        new () { "fleche-tueuse", }, // 15
        //        new () {}, // 16
        //        new () {}, // 17
        //        new () {}, // 18
        //        new () {}, // 19
        //        new () {}, // 20
        //    },
        //},
        // Roublard
        //new()
        //{
        //    ID = Library.Archetypes.voleur,
        //    FeaturesTable = new List<string>[]
        //    {
        //        new () {}, // 1
        //        new () {}, // 2
        //        new () { Library.Features.mains_lestes, Library.Features.monte_en_l_air, }, // 3
        //        new () {}, // 4
        //        new () {}, // 5
        //        new () {}, // 6
        //        new () {}, // 7
        //        new () {}, // 8
        //        new () { "furtivite-supreme", }, // 9
        //        new () {}, // 10
        //        new () {}, // 11
        //        new () {}, // 12
        //        new () { "utilisation-d-objets-magiques", }, // 13
        //        new () {}, // 14
        //        new () {}, // 15
        //        new () {}, // 16
        //        new () { "reflexes-de-voleur", }, // 17
        //        new () {}, // 18
        //        new () {}, // 19
        //        new () {}, // 20
        //    },
        //},
        //new()
        //{
        //    ID = Library.Archetypes.shadowblade,
        //    FeaturesTable = new List<string>[]
        //    {
        //        new() {}, // 1
        //        new() {}, // 2
        //        new() { Library.Features.initie, Library.Features.incantations, Library.Features.enfant_de_l_ombre, }, // 3
        //        new() {}, // 4
        //        new() {}, // 5
        //        new() {}, // 6
        //        new() {}, // 7
        //        new() {}, // 8
        //        new() { "energie-de-l-ombre", "frappe-maudite", }, // 9
        //        new() {}, // 10
        //        new() {}, // 11
        //        new() {}, // 12
        //        new() { "ombre-et-magie", }, // 13
        //        new() {}, // 14
        //        new() {}, // 15
        //        new() {}, // 16
        //        new() { "maitre-de-l-ombre", }, // 17
        //        new() {}, // 18
        //        new() {}, // 19
        //        new() {}, // 20
        //    },
        //},
    };

    private IReadOnlyDictionary<string, ClassArchetypeDatum> _classArchetypesDataMap = null;
    public IReadOnlyDictionary<string, ClassArchetypeDatum> ClassArchetypesData => _classArchetypesDataMap ??= _classArchetypesData.ToDictionary(s => s.ID, s => s);

    private IReadOnlyList<ClassDatum> _classData = new List<ClassDatum>
    {
        new()
        {
            ID = Library.Classes.barbarian,
            HitDice = 12,
            HitPointsAbilityBonus = AbilityID.Constitution,
            EquipmentProficiencies = new List<EquipmentTypeRef>()
            {
                EquipmentType.Light_Armor,
                EquipmentType.Medium_Armor,
                EquipmentType.Shield,

                EquipmentType.Simple_Weapon,
                EquipmentType.Melee_Weapon,
            },
            SavesProficiencies = new List<AbilityID>()
            {
            },
            SkillProficienciesCount = 2,
            AllowedSkillProficiencies = new List<SkillID>()
            {
                SkillID.Athletics,
                SkillID.Animal_Handling,
                SkillID.Intimidation,
                SkillID.Nature,
                SkillID.Perception,
                SkillID.Survival,
            },
            FeaturesTable = new List<string>[]
            {
                new() { Library.Features.rage, Library.Features.defense_sans_armure, },
                // TODO : ....
            },
            Rages = new int[]
            {
                2, 2, 3, 3, 3, 4, 4, 4, 4, 4, 4, 5, 5, 5, 5, 5, 6, 6, 6, int.MaxValue,
            },
            RageDamage = new int[]
            {
                2, 2, 2, 2, 2, 2, 2, 2, 3, 3, 3, 3, 3, 3, 3, 4, 4, 4, 4, 4,
            }

        },
        new()
        {
            ID = Library.Classes.bard,
            HitDice = 8,
            HitPointsAbilityBonus = AbilityID.Constitution,
            EquipmentProficiencies = new List<EquipmentTypeRef>()
            {
                EquipmentType.Light_Armor,

                EquipmentType.Simple_Weapon,
                Library.Equipments.hand_crossbow,
                Library.Equipments.longsword,
                Library.Equipments.rapier,
                Library.Equipments.shortsword,
            },
            SavesProficiencies = new List<AbilityID>()
            {
                AbilityID.Dexterity,
                AbilityID.Charisma,
            },
            SkillProficienciesCount = 3,
            FeaturesTable = new List<string>[]
            {
                new () { Library.Features.incantations, Library.Features.inspiration_bardique_d6, },
                // TODO : ....
            },
            SpellcastingAbility = AbilityID.Charisma,
            SpellcastingFocus = EquipmentType.Musical_Instrument,
            CantripsKnown = new int[]
            {
                2, 2, 2, 3, 3, 3, 3, 3, 3, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4,
            },
            SpellsKnown = new int[]
            {
                4, 5, 6, 7, 8, 9, 10, 11, 12, 14, 15, 15, 16, 18, 19, 19, 20, 22, 22, 22,
            },
            SpellSlotsPerSpellLevelTable = new int[,] 
            { 
                { 2, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 3, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 4, 2, 0, 0, 0, 0, 0, 0, 0 },
                { 4, 3, 0, 0, 0, 0, 0, 0, 0 },
                { 4, 3, 2, 0, 0, 0, 0, 0, 0 },
                { 4, 3, 3, 0, 0, 0, 0, 0, 0 },
                { 4, 3, 3, 1, 0, 0, 0, 0, 0 },
                { 4, 3, 3, 2, 0, 0, 0, 0, 0 },
                { 4, 3, 3, 3, 1, 0, 0, 0, 0 },
                { 4, 3, 3, 3, 2, 0, 0, 0, 0 },
                { 4, 3, 3, 3, 2, 1, 0, 0, 0 },
                { 4, 3, 3, 3, 2, 1, 0, 0, 0 },
                { 4, 3, 3, 3, 2, 1, 1, 0, 0 },
                { 4, 3, 3, 3, 2, 1, 1, 0, 0 },
                { 4, 3, 3, 3, 2, 1, 1, 1, 0 },
                { 4, 3, 3, 3, 2, 1, 1, 1, 0 },
                { 4, 3, 3, 3, 2, 1, 1, 1, 1 },
                { 4, 3, 3, 3, 3, 1, 1, 1, 1 },
                { 4, 3, 3, 3, 3, 2, 1, 1, 1 },
                { 4, 3, 3, 3, 3, 2, 2, 1, 1 },
            },
        },
        new()
        {
            ID = Library.Classes.cleric,
            HitDice = 8,
            HitPointsAbilityBonus = AbilityID.Constitution,
            EquipmentProficiencies = new List<EquipmentTypeRef>()
            {
                EquipmentType.Light_Armor,
                EquipmentType.Medium_Armor,
                EquipmentType.Shield,

                EquipmentType.Simple_Weapon,
            },
            SavesProficiencies = new List<AbilityID>()
            {
                AbilityID.Wisdom,
                AbilityID.Charisma,
            },
            AllowedSkillProficiencies = new List<SkillID>()
            {
                SkillID.History,
                SkillID.Medicine,
                SkillID.Insight,
                SkillID.Persuasion,
                SkillID.Religion,
            },
            SkillProficienciesCount = 2,
            FeaturesTable = new List<string>[]
            {
                new () { Library.Features.sortileges, Library.Features.domaine_d_influence_vie_soins, },
                new () { Library.Features.renvoi_des_morts_vivants, },
                new () { Library.Features.acces_aux_sorts_niveau_2 },
                //new () { Library.Features.amelioration_de_caracteristique_wisdom, Library.Features.amelioration_de_caracteristique_wisdom, }
                new () { Library.Features.amelioration_de_caracteristique, }
            },
            SpellcastingAbility = AbilityID.Wisdom,
            SpellcastingFocus = EquipmentType.Holy_Symbol,
            SpellsAlwaysKnown = true,
            CantripsKnown = new int[]
            {
                3, 3, 3, 4, 4, 4, 4, 4, 4, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 
            },
            SpellSlotsPerSpellLevelTable = new int[,]
            {
                { 2, 0, 0, 0, 0, 0, 0, 0, 0, },
                { 3, 0, 0, 0, 0, 0, 0, 0, 0, },
                { 4, 2, 0, 0, 0, 0, 0, 0, 0, },
                { 4, 3, 0, 0, 0, 0, 0, 0, 0, },
                { 4, 3, 2, 0, 0, 0, 0, 0, 0, },
                { 4, 3, 3, 0, 0, 0, 0, 0, 0, },
                { 4, 3, 3, 1, 0, 0, 0, 0, 0, },
                { 4, 3, 3, 2, 0, 0, 0, 0, 0, },
                { 4, 3, 3, 3, 1, 0, 0, 0, 0, },
                { 4, 3, 3, 3, 2, 0, 0, 0, 0, },
                { 4, 3, 3, 3, 2, 1, 0, 0, 0, },
                { 4, 3, 3, 3, 2, 1, 0, 0, 0, },
                { 4, 3, 3, 3, 2, 1, 1, 0, 0, },
                { 4, 3, 3, 3, 2, 1, 1, 0, 0, },
                { 4, 3, 3, 3, 2, 1, 1, 1, 0, },
                { 4, 3, 3, 3, 2, 1, 1, 1, 0, },
                { 4, 3, 3, 3, 2, 1, 1, 1, 1, },
                { 4, 3, 3, 3, 3, 1, 1, 1, 1, },
                { 4, 3, 3, 3, 3, 2, 1, 1, 1, },
                { 4, 3, 3, 3, 3, 2, 2, 1, 1, },
            },
        },
        new()
        {
            ID = Library.Classes.druid,
            HitDice = 8,
            HitPointsAbilityBonus = AbilityID.Constitution,
            EquipmentProficiencies = new List<EquipmentTypeRef>()
            {
                EquipmentType.Light_Armor,
                EquipmentType.Medium_Armor,
                EquipmentType.Shield,

                Library.Equipments.greatclub,
                Library.Equipments.dagger,
                Library.Equipments.dart,
                Library.Equipments.javelin,
                Library.Equipments.quarterstaff,
                Library.Equipments.club,
                Library.Equipments.scimitar,
                Library.Equipments.sickle,
                Library.Equipments.sling,
                Library.Equipments.lance,

                "materiel-dherboriste",
            },
            SavesProficiencies = new List<AbilityID>()
            {
                AbilityID.Intelligence,
                AbilityID.Wisdom,
            },
            AllowedSkillProficiencies = new List<SkillID>()
            {
                SkillID.Arcana,
                SkillID.Animal_Handling,
                SkillID.Medicine,
                SkillID.Nature,
                SkillID.Perception,
                SkillID.Insight,
                SkillID.Religion,
                SkillID.Survival,
            },
            SkillProficienciesCount = 2,
            FeaturesTable = new List<string>[]
            {
                new () { Library.Features.druidique, Library.Features.incantations, },
                new () { Library.Features.forme_sauvage, Library.Features.cercle_druidique, },
                new () { },
                new () { Library.Features.forme_sauvage_amelioree, Library.Features.amelioration_de_caracteristique, },
            },
            SpellcastingAbility = AbilityID.Wisdom,
            SpellcastingFocus = EquipmentType.Druidic_Focus,
            SpellsAlwaysKnown = true,
            CantripsKnown = new int[]
            {
                2, 2, 2, 3, 3, 3, 3, 3, 3, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4,
            },
            SpellSlotsPerSpellLevelTable = new int[,]
            {
                { 2, 0, 0, 0, 0, 0, 0, 0, 0, },
                { 3, 0, 0, 0, 0, 0, 0, 0, 0, },
                { 4, 2, 0, 0, 0, 0, 0, 0, 0, },
                { 4, 3, 0, 0, 0, 0, 0, 0, 0, },
                { 4, 3, 2, 0, 0, 0, 0, 0, 0, },
                { 4, 3, 3, 0, 0, 0, 0, 0, 0, },
                { 4, 3, 3, 1, 0, 0, 0, 0, 0, },
                { 4, 3, 3, 2, 0, 0, 0, 0, 0, },
                { 4, 3, 3, 3, 1, 0, 0, 0, 0, },
                { 4, 3, 3, 3, 2, 0, 0, 0, 0, },
                { 4, 3, 3, 3, 2, 1, 0, 0, 0, },
                { 4, 3, 3, 3, 2, 1, 0, 0, 0, },
                { 4, 3, 3, 3, 2, 1, 1, 0, 0, },
                { 4, 3, 3, 3, 2, 1, 1, 0, 0, },
                { 4, 3, 3, 3, 2, 1, 1, 1, 0, },
                { 4, 3, 3, 3, 2, 1, 1, 1, 0, },
                { 4, 3, 3, 3, 2, 1, 1, 1, 1, },
                { 4, 3, 3, 3, 3, 1, 1, 1, 1, },
                { 4, 3, 3, 3, 3, 2, 1, 1, 1, },
                { 4, 3, 3, 3, 3, 2, 2, 1, 1, },
            },
        },
        new()
        {
            ID = Library.Classes.sorcerer,
            HitDice = 6,
            HitPointsAbilityBonus = AbilityID.Constitution,
            EquipmentProficiencies = new List<EquipmentTypeRef>()
            {
                Library.Equipments.dagger,
                Library.Equipments.dart,
                Library.Equipments.sling,
                Library.Equipments.club,
                Library.Equipments.light_crossbow,
            },
            SavesProficiencies = new List<AbilityID>()
            {
                AbilityID.Constitution,
                AbilityID.Charisma,
            },
            AllowedSkillProficiencies = new List<SkillID>()
            {
                SkillID.Arcana,
                SkillID.Intimidation,
                SkillID.Insight,
                SkillID.Persuasion,
                SkillID.Religion,
                SkillID.Deception,
            },
            SkillProficienciesCount = 2,
            FeaturesTable = new List<string>[]
            {
                new () { Library.Features.incantations, Library.Features.origine_magique, },
                new () { Library.Features.points_de_sorcellerie, },
                new () { Library.Features.metamagie, },
                new () { Library.Features.amelioration_de_caracteristique, },
            },
            SpellcastingAbility = AbilityID.Charisma,
            SpellcastingFocus = EquipmentType.Arcane_Focus,
            SorceryPoints = new int[]
            {
                0, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20,
            },
            CantripsKnown = new int[]
            {
                4, 4, 4, 5, 5, 5, 5, 5, 5, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6,
            },
            SpellsKnown = new int[]
            {
                2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 12, 13, 13, 14, 14, 15, 15, 15, 15,
            },
            SpellSlotsPerSpellLevelTable = new int[,]
            {
                { 2, 0, 0, 0, 0, 0, 0, 0, 0, },
                { 3, 0, 0, 0, 0, 0, 0, 0, 0, },
                { 4, 2, 0, 0, 0, 0, 0, 0, 0, },
                { 4, 3, 0, 0, 0, 0, 0, 0, 0, },
                { 4, 3, 2, 0, 0, 0, 0, 0, 0, },
                { 4, 3, 3, 0, 0, 0, 0, 0, 0, },
                { 4, 3, 3, 1, 0, 0, 0, 0, 0, },
                { 4, 3, 3, 2, 0, 0, 0, 0, 0, },
                { 4, 3, 3, 3, 1, 0, 0, 0, 0, },
                { 4, 3, 3, 3, 2, 0, 0, 0, 0, },
                { 4, 3, 3, 3, 2, 1, 0, 0, 0, },
                { 4, 3, 3, 3, 2, 1, 0, 0, 0, },
                { 4, 3, 3, 3, 2, 1, 1, 0, 0, },
                { 4, 3, 3, 3, 2, 1, 1, 0, 0, },
                { 4, 3, 3, 3, 2, 1, 1, 1, 0, },
                { 4, 3, 3, 3, 2, 1, 1, 1, 0, },
                { 4, 3, 3, 3, 2, 1, 1, 1, 1, },
                { 4, 3, 3, 3, 3, 1, 1, 1, 1, },
                { 4, 3, 3, 3, 3, 2, 1, 1, 1, },
                { 4, 3, 3, 3, 3, 2, 2, 1, 1, },
            }
        },
        new()
        {
            ID = Library.Classes.fighter,
            HitDice = 10,
            HitPointsAbilityBonus = AbilityID.Constitution,
            EquipmentProficiencies = new List<EquipmentTypeRef>()
            {
                EquipmentType.Armor,
                EquipmentType.Shield,

                EquipmentType.Simple_Weapon,
                EquipmentType.Melee_Weapon,
            },
            SavesProficiencies = new List<AbilityID>()
            {
                AbilityID.Strength,
                AbilityID.Constitution,
            },
            AllowedSkillProficiencies = new List<SkillID>()
            {
                SkillID.Acrobatics,
                SkillID.Athletics,
                SkillID.Animal_Handling,
                SkillID.History,
                SkillID.Intimidation,
                SkillID.Perception,
                SkillID.Insight,
                SkillID.Survival,
            },
            SkillProficienciesCount = 2,
            FeaturesTable = new List<string>[]
            {
                new () { Library.Features.second_souffle, Library.Features.style_de_combat, },
                new () { Library.Features.sursaut_d_activite, },
                new () { Library.Features.critique_ameliore, },
                new () { Library.Features.amelioration_de_caracteristique, },
            },
        },
        new()
        {
            ID = Library.Classes.wizard,
            HitDice = 6,
            HitPointsAbilityBonus = AbilityID.Constitution,
            EquipmentProficiencies = new List<EquipmentTypeRef>()
            {
                Library.Equipments.dagger,
                Library.Equipments.dart,
                Library.Equipments.sling,
                Library.Equipments.club,
                Library.Equipments.light_crossbow,
            },
            SavesProficiencies = new List<AbilityID>()
            {
                AbilityID.Intelligence,
                AbilityID.Wisdom,
            },
            AllowedSkillProficiencies = new List<SkillID>()
            {
                SkillID.History,
                SkillID.Investigation,
                SkillID.Medicine,
                SkillID.Insight,
                SkillID.Perception,
                SkillID.Religion,
            },
            SkillProficienciesCount = 2,
            FeaturesTable = new List<string>[]
            {
                new () { Library.Features.sorts, Library.Features.restauration_magique, },
                new () { Library.Features.maitrise_des_elements, Library.Features.grimoire_plus_2_sorts, },
                new () { Library.Features.grimoire_plus_2_sorts, Library.Features.acces_aux_sorts_niveau_2, },
                new () { Library.Features.grimoire_plus_2_sorts, Library.Features.amelioration_de_caracteristique, },
            },
            SpellcastingAbility = AbilityID.Intelligence,
            SpellcastingFocus = EquipmentType.Arcane_Focus,
            CantripsKnown = new int[]
            {
                3, 3, 3, 4, 4, 4, 4, 4, 4, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 
            },
            SpellSlotsPerSpellLevelTable = new int[,]
            {
                { 2, 0, 0, 0, 0, 0, 0, 0, 0, },
                { 3, 0, 0, 0, 0, 0, 0, 0, 0, },
                { 4, 2, 0, 0, 0, 0, 0, 0, 0, },
                { 4, 3, 0, 0, 0, 0, 0, 0, 0, },
                { 4, 3, 2, 0, 0, 0, 0, 0, 0, },
                { 4, 3, 3, 0, 0, 0, 0, 0, 0, },
                { 4, 3, 3, 1, 0, 0, 0, 0, 0, },
                { 4, 3, 3, 2, 0, 0, 0, 0, 0, },
                { 4, 3, 3, 3, 1, 0, 0, 0, 0, },
                { 4, 3, 3, 3, 2, 0, 0, 0, 0, },
                { 4, 3, 3, 3, 2, 1, 0, 0, 0, },
                { 4, 3, 3, 3, 2, 1, 0, 0, 0, },
                { 4, 3, 3, 3, 2, 1, 1, 0, 0, },
                { 4, 3, 3, 3, 2, 1, 1, 0, 0, },
                { 4, 3, 3, 3, 2, 1, 1, 1, 0, },
                { 4, 3, 3, 3, 2, 1, 1, 1, 0, },
                { 4, 3, 3, 3, 2, 1, 1, 1, 1, },
                { 4, 3, 3, 3, 3, 1, 1, 1, 1, },
                { 4, 3, 3, 3, 3, 2, 1, 1, 1, },
                { 4, 3, 3, 3, 3, 2, 2, 1, 1, },
            },
        },
        new()
        {
            ID = Library.Classes.monk,
            SavesProficiencies = new List<AbilityID>()
            {
            },
            FeaturesTable = new List<string>[]
            {
            },
            MartialArts = new Roll[]
            {
                new Roll(4),
                new Roll(4),
                new Roll(4),
                new Roll(4),
                new Roll(6),
                new Roll(6),
                new Roll(6),
                new Roll(6),
                new Roll(6),
                new Roll(6),
                new Roll(8),
                new Roll(8),
                new Roll(8),
                new Roll(8),
                new Roll(8),
                new Roll(8),
                new Roll(10),
                new Roll(10),
                new Roll(10),
                new Roll(10),
            },
            KiPoints = new int[]
            {
                0, 2 ,3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20,
            },
            UnarmoredMovement = new Distance[]
            {
                Distance.FromMeters(0),
                Distance.FromMeters(3),
                Distance.FromMeters(3),
                Distance.FromMeters(3),
                Distance.FromMeters(3),
                Distance.FromMeters(4, 50),
                Distance.FromMeters(4, 50),
                Distance.FromMeters(4, 50),
                Distance.FromMeters(4, 50),
                Distance.FromMeters(6),
                Distance.FromMeters(6),
                Distance.FromMeters(6),
                Distance.FromMeters(6),
                Distance.FromMeters(7, 50),
                Distance.FromMeters(7, 50),
                Distance.FromMeters(7, 50),
                Distance.FromMeters(7, 50),
                Distance.FromMeters(9),
                Distance.FromMeters(9),
                Distance.FromMeters(9),
            },
        },
        new()
        {
            ID = Library.Classes.paladin,
            HitDice = 10,
            HitPointsAbilityBonus = AbilityID.Constitution,
            EquipmentProficiencies = new List<EquipmentTypeRef>()
            {
                EquipmentType.Armor,
                EquipmentType.Shield,

                EquipmentType.Simple_Weapon,
                EquipmentType.Martial_Weapon,
            },
            SavesProficiencies = new List<AbilityID>()
            {
                AbilityID.Wisdom,
                AbilityID.Charisma,
            },
            AllowedSkillProficiencies = new List<SkillID>()
            {
                SkillID.Athletics,
                SkillID.Intimidation,
                SkillID.Medicine,
                SkillID.Insight,
                SkillID.Persuasion,
                SkillID.Religion,
            },
            SkillProficienciesCount = 2,
            FeaturesTable = new List<string>[]
            {
                new () { Library.Features.sens_divin, Library.Features.imposition_des_mains, },
                new () { Library.Features.style_de_combat, Library.Features.incantations, Library.Features.chatiment_divin, },
                new () { Library.Features.sante_divine, Library.Features.serment_sacre, },
                new () { Library.Features.amelioration_de_caracteristique, },
            },
            SpellcastingAbility = AbilityID.Charisma,
            SpellcastingFocus = EquipmentType.Holy_Symbol,
            SpellsAlwaysKnown = true,
            SpellSlotsPerSpellLevelTable = new int[,]
            {
                { 0, 0, 0, 0, 0, },
                { 2, 0, 0, 0, 0, },
                { 3, 0, 0, 0, 0, },
                { 3, 0, 0, 0, 0, },
                { 4, 2, 0, 0, 0, },
                { 4, 2, 0, 0, 0, },
                { 4, 3, 0, 0, 0, },
                { 4, 3, 0, 0, 0, },
                { 4, 3, 2, 0, 0, },
                { 4, 3, 2, 0, 0, },
                { 4, 3, 3, 0, 0, },
                { 4, 3, 3, 0, 0, },
                { 4, 3, 3, 1, 0, },
                { 4, 3, 3, 1, 0, },
                { 4, 3, 3, 2, 0, },
                { 4, 3, 3, 2, 0, },
                { 4, 3, 3, 3, 1, },
                { 4, 3, 3, 3, 1, },
                { 4, 3, 3, 3, 2, },
                { 4, 3, 3, 3, 2, },
            }
        },
        new()
        {
            ID = Library.Classes.ranger,
            HitDice = 10,
            HitPointsAbilityBonus = AbilityID.Constitution,
            EquipmentProficiencies = new List<EquipmentTypeRef>()
            {
                EquipmentType.Light_Armor,
                EquipmentType.Medium_Armor,
                EquipmentType.Shield,

                EquipmentType.Simple_Weapon,
                EquipmentType.Martial_Weapon,
            },
            SavesProficiencies = new List<AbilityID>()
            {
                AbilityID.Strength,
                AbilityID.Dexterity,
            },
            AllowedSkillProficiencies = new List<SkillID>()
            {
                SkillID.Athletics,
                SkillID.Stealth,
                SkillID.Animal_Handling,
                SkillID.Investigation,
                SkillID.Nature,
                SkillID.Perception,
                SkillID.Insight,
                SkillID.Survival,
            },
            SkillProficienciesCount = 3,
            FeaturesTable = new List<string>[]
            {
                new () { Library.Features.ennemi_jure, Library.Features.explorateur_ne },
                new () { Library.Features.style_de_combat, Library.Features.incantations },
                new () { Library.Features.archetype_de_rodeur, Library.Features.fleche_arcanique, Library.Features.vigilance_primitive },
                new () { Library.Features.amelioration_de_caracteristique },
            },
            Archetypes = new[] { "chasseur", Library.Archetypes.archer_arcanique, "exile", "traqueur", },
            SpellcastingAbility = AbilityID.Wisdom,
            SpellsKnown = new int[]
            {
                0, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7, 8, 8, 9, 9, 10, 10, 11, 11,
            },
            SpellSlotsPerSpellLevelTable = new int[,]
            {
                { 0, 0, 0, 0, 0, },
                { 2, 0, 0, 0, 0, },
                { 3, 0, 0, 0, 0, },
                { 3, 0, 0, 0, 0, },
                { 4, 2, 0, 0, 0, },
                { 4, 2, 0, 0, 0, },
                { 4, 3, 0, 0, 0, },
                { 4, 3, 0, 0, 0, },
                { 4, 3, 2, 0, 0, },
                { 4, 3, 2, 0, 0, },
                { 4, 3, 3, 0, 0, },
                { 4, 3, 3, 0, 0, },
                { 4, 3, 3, 1, 0, },
                { 4, 3, 3, 1, 0, },
                { 4, 3, 3, 2, 0, },
                { 4, 3, 3, 2, 0, },
                { 4, 3, 3, 3, 1, },
                { 4, 3, 3, 3, 1, },
                { 4, 3, 3, 3, 2, },
                { 4, 3, 3, 3, 2, },
            }
        },
        new()
        {
            ID = Library.Classes.rogue,
            HitDice = 8,
            HitPointsAbilityBonus = AbilityID.Constitution,
            EquipmentProficiencies = new List<EquipmentTypeRef>()
            {
                EquipmentType.Light_Armor,

                EquipmentType.Simple_Weapon,
                Library.Equipments.hand_crossbow,
                Library.Equipments.longsword,
                Library.Equipments.rapier,
                Library.Equipments.shortsword,

                Library.Equipments.outils_de_voleur,
            },
            SavesProficiencies = new List<AbilityID>()
            {
                AbilityID.Dexterity,
                AbilityID.Intelligence,
            },
            AllowedSkillProficiencies = new List<SkillID>()
            {
                SkillID.Acrobatics,
                SkillID.Athletics,
                SkillID.Stealth,
                SkillID.Sleight_Of_Hand,
                SkillID.Intimidation,
                SkillID.Investigation,
                SkillID.Perception,
                SkillID.Insight,
                SkillID.Persuasion,
                SkillID.Performance,
                SkillID.Deception,
            },
            SkillProficienciesCount = 4,
            SneakAttack = new Roll[]
            {
                new Roll(6, 1),
                new Roll(6, 1),
                new Roll(6, 2),
                new Roll(6, 2),
            },
            FeaturesTable = new List<string>[]
            {
                new () { Library.Features.expertise_rogue, Library.Features.attaque_sournoise, Library.Features.argot_des_voleurs },
                new () { Library.Features.ruse, },
                new () { Library.Features.archetype_de_roublard, },
                //new () { Library.Features.archetype_de_roublard, Library.Features.mains_lestes, Library.Features.monte_en_l_air, Library.Features.ombrelame, Library.Features.enfant_de_l_ombre, },
                new () { Library.Features.amelioration_de_caracteristique, },
            },
        },
        new()
        {
            ID = Library.Classes.warlock,
            SpellcastingAbility = AbilityID.Charisma,
            SpellcastingFocus = EquipmentType.Arcane_Focus,
            SavesProficiencies = new List<AbilityID>()
            {
            },
            FeaturesTable = new List<string>[]
            {
            },
        },
    };

    private IReadOnlyDictionary<string, ClassDatum> _classesDataMap = null;
    public IReadOnlyDictionary<string, ClassDatum> ClassesData => _classesDataMap ??= _classData.ToDictionary(s => s.ID, s => s);
}
