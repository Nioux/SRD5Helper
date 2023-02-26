using SRD5Helper.DataModels;
using SRD5Helper.Resources;
using Library = SRD5Helper.Resources.Library;
using System.Collections.ObjectModel;
using SRD5Helper.ViewModels;

namespace SRD5Helper.Data;

public partial class DataService
{
    private Dictionary<string, PlayerCharacter> _playerCharacters = new Dictionary<string, PlayerCharacter>();
    public IReadOnlyDictionary<string, PlayerCharacter> PlayerCharacters { get => _playerCharacters; }

    public async Task LoadPlayerCharactersAsync()
    {
        _playerCharacters["dummy"] = LoadDummy();
        _playerCharacters[Library.PlayerCharacters.selmays] = LoadSelmays();
        _playerCharacters[Library.PlayerCharacters.beric] = LoadBeric();
        _playerCharacters[Library.PlayerCharacters.siam] = LoadSiam();
        _playerCharacters[Library.PlayerCharacters.rhingann] = LoadRhingann();
        _playerCharacters[Library.PlayerCharacters.ilzaach] = LoadIlzaach();
        _playerCharacters[Library.PlayerCharacters.leowen] = LoadLeowen();
        _playerCharacters[Library.PlayerCharacters.darkna] = LoadDarkna();
        _playerCharacters[Library.PlayerCharacters.ozyias] = LoadOzyias();
        _playerCharacters[Library.PlayerCharacters.galefrin] = LoadGalefrin();
        _playerCharacters[Library.PlayerCharacters.malathor] = LoadMalathor();
    }
    public static PlayerCharacter LoadDummy()
    {
        var pc = new PlayerCharacter();
        return pc;
    }
    public static PlayerCharacter LoadSelmays()
    {
        var pc = new PlayerCharacter();

        pc.CharacterName = Library.PlayerCharacters.selmays_name;
        pc.CharacterPicture = Library.PlayerCharacters.selmays_picture;
        pc.CharacterSmallPicture = Library.PlayerCharacters.selmays_small_picture;
        pc.Origin = pc.Factory.CreateOrigin(id: Library.Origins.elf);
        pc.Background = pc.Factory.CreateBackground(id: Library.Backgrounds.sage); // erudit ?
        var cl = pc.Factory.CreateClass(id: Library.Classes.wizard, level: 1);
        pc.Classes.Add(cl);
        pc.Gender = GenderID.Female;

        pc.Abilities.Strength.BaseScore = 8;
        pc.Abilities.Dexterity.BaseScore = 10;
        pc.Abilities.Constitution.BaseScore = 14;
        pc.Abilities.Intelligence.BaseScore = 17;
        pc.Abilities.Wisdom.BaseScore = 14;
        pc.Abilities.Charisma.BaseScore = 13;

        cl.SelectedSkillProficiencies.Add(SkillID.Investigation);
        cl.SelectedSkillProficiencies.Add(SkillID.Insight);

        //Skills.Arcana.Proficiency = true;
        //Skills.History.Proficiency = true;
        //Skills.Investigation.Proficiency = true;
        //Skills.Insight.Proficiency = true;

        cl.HitPointsPerLevel.Add(cl.HitDice);
        pc.TemporaryHitPoints = pc.CurrentHitPoints;

        pc.EquipmentRefs.Add(pc.Factory.CreateEquipment(id: Library.Equipments.dagger, isEquipped: true));

        pc.EquipmentRefs.Add(pc.Factory.CreateEquipment(id: Library.Equipments.spellbook));
        pc.EquipmentRefs.Add(pc.Factory.CreateEquipment(id: Library.Equipments.backpack));
        pc.EquipmentRefs.Add(pc.Factory.CreateEquipment(id: Library.Equipments.bedroll));
        pc.EquipmentRefs.Add(pc.Factory.CreateEquipment(id: Library.Equipments.briquet_a_amadou));
        pc.EquipmentRefs.Add(pc.Factory.CreateEquipment(id: Library.Equipments.torche, quantity: 10));
        pc.EquipmentRefs.Add(pc.Factory.CreateEquipment(id: Library.Equipments.rations, quantity: 10));
        pc.EquipmentRefs.Add(pc.Factory.CreateEquipment(id: Library.Equipments.outre));
        pc.EquipmentRefs.Add(pc.Factory.CreateEquipment(id: Library.Equipments.corde_en_chanvre));

        //cl.SelectedFeatures.Add(pc.Factory.CreateFeature(id: Library.Features.amelioration_de_caracteristique_intelligence, minimumLevel: 4));
        //cl.SelectedFeatures.Add(pc.Factory.CreateFeature(id: Library.Features.amelioration_de_caracteristique_intelligence, minimumLevel: 4));

        //cl.KnownSpells.Add(Library.Spells.lumiere);
        //cl.KnownSpells.Add(Library.Spells.poigne_electrique);
        //cl.KnownSpells.Add(Library.Spells.rayon_de_givre);
        //cl.KnownSpells.Add(Library.Spells.armure_du_mage);
        //cl.KnownSpells.Add(Library.Spells.comprehension_des_langues);
        //cl.KnownSpells.Add(Library.Spells.detection_de_la_magie);
        //cl.KnownSpells.Add(Library.Spells.mains_brulantes);
        //cl.KnownSpells.Add(Library.Spells.projectile_magique);
        //cl.KnownSpells.Add(Library.Spells.sommeil);
        //var featAbilities = AllAvailableClassFeatures.Where(feat => feat.ID == Library.Features.amelioration_de_caracteristique).FirstOrDefault();
        //featAbilities.SelectedChoices.Add(Library.Features.amelioration_de_caracteristique_intelligence);
        //featAbilities.SelectedChoices.Add(Library.Features.amelioration_de_caracteristique_intelligence);
        return pc;
    }
    public static PlayerCharacter LoadBeric()
    {
        var pc = new PlayerCharacter();

        pc.CharacterName = Library.PlayerCharacters.beric_name;
        pc.CharacterPicture = Library.PlayerCharacters.beric_picture;
        pc.CharacterSmallPicture = Library.PlayerCharacters.beric_small_picture;
        pc.Origin = pc.Factory.CreateOrigin(id: Library.Origins.human);
        pc.Background = pc.Factory.CreateBackground(id: Library.Backgrounds.heros_du_peuple);
        var cl = pc.Factory.CreateClass(id: Library.Classes.fighter, level: 1);
        pc.Classes.Add(cl);
        //cl.ArchetypeIDs.Add(Library.Archetypes.champion);
        pc.Gender = GenderID.Male;

        pc.Abilities.Strength.BaseScore = 17;
        pc.Abilities.Dexterity.BaseScore = 15;
        pc.Abilities.Constitution.BaseScore = 14;
        pc.Abilities.Intelligence.BaseScore = 12;
        pc.Abilities.Wisdom.BaseScore = 9;
        pc.Abilities.Charisma.BaseScore = 11;

        cl.SelectedSkillProficiencies.Add(SkillID.Athletics);
        cl.SelectedSkillProficiencies.Add(SkillID.Animal_Handling);
        cl.SelectedSkillProficiencies.Add(SkillID.Insight);
        cl.SelectedSkillProficiencies.Add(SkillID.Survival);
        //Skills.Athletics.Proficiency = true;
        //Skills.AnimalHandling.Proficiency = true;
        //Skills.Insight.Proficiency = true;
        //Skills.Survival.Proficiency = true;

        cl.HitPointsPerLevel.Add(cl.HitDice);
        pc.TemporaryHitPoints = pc.CurrentHitPoints;

        pc.EquipmentRefs.Add(pc.Factory.CreateEquipment(id: Library.Equipments.longsword, isEquipped: true));
        pc.EquipmentRefs.Add(pc.Factory.CreateEquipment(id: Library.Equipments.light_crossbow, isEquipped: true));
        pc.EquipmentRefs.Add(pc.Factory.CreateEquipment(id: Library.Equipments.chain_mail, isEquipped: true));
        pc.EquipmentRefs.Add(pc.Factory.CreateEquipment(id: Library.Equipments.shield, isEquipped: true));

        pc.EquipmentRefs.Add(pc.Factory.CreateEquipment(id: Library.Equipments.backpack));
        pc.EquipmentRefs.Add(pc.Factory.CreateEquipment(id: Library.Equipments.pied_de_biche));
        pc.EquipmentRefs.Add(pc.Factory.CreateEquipment(id: Library.Equipments.marteau));
        pc.EquipmentRefs.Add(pc.Factory.CreateEquipment(id: Library.Equipments.piton, quantity: 10));
        pc.EquipmentRefs.Add(pc.Factory.CreateEquipment(id: Library.Equipments.torche, quantity: 10));
        pc.EquipmentRefs.Add(pc.Factory.CreateEquipment(id: Library.Equipments.rations, quantity: 10));
        pc.EquipmentRefs.Add(pc.Factory.CreateEquipment(id: Library.Equipments.outre));
        pc.EquipmentRefs.Add(pc.Factory.CreateEquipment(id: Library.Equipments.corde_en_chanvre));
        pc.EquipmentRefs.Add(pc.Factory.CreateEquipment(id: Library.Equipments.briquet_a_amadou));

        cl.SelectedFeatures.Add(pc.Factory.CreateFeature(id: Library.Features.style_de_combat_defense));
        //cl.SelectedFeatures.Add(pc.Factory.CreateFeature(id: Library.Features.amelioration_de_caracteristique_strength, minimumLevel: 4));
        //cl.SelectedFeatures.Add(pc.Factory.CreateFeature(id: Library.Features.amelioration_de_caracteristique_strength, minimumLevel: 4));

        //var featStyle = AllAvailableClassFeatures.Where(feat => feat.ID == Library.Features.style_de_combat).FirstOrDefault();
        //featStyle.SelectedChoices.Add(Library.Features.style_de_combat_defense);

        //var featAbilities = AllAvailableClassFeatures.Where(feat => feat.ID == Library.Features.amelioration_de_caracteristique).FirstOrDefault();
        //featAbilities.SelectedChoices.Add(Library.Features.amelioration_de_caracteristique_strength);
        //featAbilities.SelectedChoices.Add(Library.Features.amelioration_de_caracteristique_strength);
        return pc;
    }

    public static PlayerCharacter LoadSiam()
    {
        var pc = new PlayerCharacter();

        pc.CharacterName = Library.PlayerCharacters.siam_name;
        pc.CharacterPicture = Library.PlayerCharacters.siam_picture;
        pc.CharacterSmallPicture = Library.PlayerCharacters.siam_small_picture;
        pc.Origin = pc.Factory.CreateOrigin(id: Library.Origins.felys);
        pc.Background = pc.Factory.CreateBackground(id: Library.Backgrounds.enfant_des_rues);
        var cl = pc.Factory.CreateClass(id: Library.Classes.rogue, level: 1);
        pc.Classes.Add(cl);
        pc.Gender = GenderID.Male;
        //cl.ArchetypeIDs.Add(Library.Archetypes.voleur);

        pc.Abilities.Strength.BaseScore = 13;
        pc.Abilities.Dexterity.BaseScore = 16;
        pc.Abilities.Constitution.BaseScore = 11;
        pc.Abilities.Intelligence.BaseScore = 13;
        pc.Abilities.Wisdom.BaseScore = 7;
        pc.Abilities.Charisma.BaseScore = 15;

        cl.SelectedSkillProficiencies.Add(SkillID.Acrobatics);
        cl.SelectedSkillProficiencies.Add(SkillID.Stealth);
        cl.SelectedSkillProficiencies.Add(SkillID.Sleight_Of_Hand);
        cl.SelectedSkillProficiencies.Add(SkillID.Deception);
        //Skills.Acrobatics.Proficiency = true;
        //Skills.Stealth.Proficiency = true;
        //Skills.SleightOfHand.Proficiency = true;
        //Skills.Deception.Proficiency = true;

        cl.HitPointsPerLevel.Add(cl.HitDice);
        pc.TemporaryHitPoints = pc.CurrentHitPoints;

        pc.EquipmentRefs.Add(pc.Factory.CreateEquipment(id: Library.Equipments.shortsword, isEquipped: true));
        pc.EquipmentRefs.Add(pc.Factory.CreateEquipment(id: Library.Equipments.shortbow, isEquipped: true));
        pc.EquipmentRefs.Add(pc.Factory.CreateEquipment(id: Library.Equipments.dagger, isEquipped: true));
        pc.EquipmentRefs.Add(pc.Factory.CreateEquipment(id: Library.Equipments.leather_armor, isEquipped: true));
        pc.EquipmentRefs.Add(pc.Factory.CreateEquipment(id: Library.Equipments.shield, isEquipped: false));

        pc.EquipmentRefs.Add(pc.Factory.CreateEquipment(id: Library.Equipments.outils_de_voleur));
        pc.EquipmentRefs.Add(pc.Factory.CreateEquipment(id: Library.Equipments.backpack));
        pc.EquipmentRefs.Add(pc.Factory.CreateEquipment(id: Library.Equipments.sac_de_billes, quantity: 1000));
        pc.EquipmentRefs.Add(pc.Factory.CreateEquipment(id: Library.Equipments.ficelle));
        pc.EquipmentRefs.Add(pc.Factory.CreateEquipment(id: Library.Equipments.bougie, quantity: 5));
        pc.EquipmentRefs.Add(pc.Factory.CreateEquipment(id: Library.Equipments.pied_de_biche));
        pc.EquipmentRefs.Add(pc.Factory.CreateEquipment(id: Library.Equipments.marteau));
        pc.EquipmentRefs.Add(pc.Factory.CreateEquipment(id: Library.Equipments.piton, quantity: 10));
        pc.EquipmentRefs.Add(pc.Factory.CreateEquipment(id: Library.Equipments.lanterne_a_capote));
        pc.EquipmentRefs.Add(pc.Factory.CreateEquipment(id: Library.Equipments.flasque_d_huile, quantity: 2));
        pc.EquipmentRefs.Add(pc.Factory.CreateEquipment(id: Library.Equipments.briquet_a_amadou));
        pc.EquipmentRefs.Add(pc.Factory.CreateEquipment(id: Library.Equipments.outre));
        pc.EquipmentRefs.Add(pc.Factory.CreateEquipment(id: Library.Equipments.corde_en_chanvre));

        cl.SelectedFeatures.Add(pc.Factory.CreateFeature(id: Library.Features.expertise_discretion));
        cl.SelectedFeatures.Add(pc.Factory.CreateFeature(id: Library.Features.expertise_outils_de_voleur));

        //cl.SelectedFeatures.Add(pc.Factory.CreateFeature(id: Library.Features.amelioration_de_caracteristique_dexterity, minimumLevel: 4));
        //cl.SelectedFeatures.Add(pc.Factory.CreateFeature(id: Library.Features.amelioration_de_caracteristique_dexterity, minimumLevel: 4));

        //var featExpertise = AllAvailableClassFeatures.Where(feat => feat.ID == Library.Features.expertise_rogue).FirstOrDefault();
        //featExpertise.SelectedChoices.Add(Library.Features.expertise_discretion);
        //featExpertise.SelectedChoices.Add(Library.Features.expertise_outils_de_voleur);

        //var featAbilities = AllAvailableClassFeatures.Where(feat => feat.ID == Library.Features.amelioration_de_caracteristique).FirstOrDefault();
        //featAbilities.SelectedChoices.Add(Library.Features.amelioration_de_caracteristique_dexterity);
        //featAbilities.SelectedChoices.Add(Library.Features.amelioration_de_caracteristique_dexterity);
        return pc;
    }

    public static PlayerCharacter LoadRhingann()
    {
        var pc = new PlayerCharacter();

        pc.CharacterName = Library.PlayerCharacters.rhingann_name;
        pc.CharacterPicture = Library.PlayerCharacters.rhingann_picture;
        pc.CharacterSmallPicture = Library.PlayerCharacters.rhingann_small_picture;
        pc.Origin = pc.Factory.CreateOrigin(id: Library.Origins.dwarf);
        pc.Background = pc.Factory.CreateBackground(id: Library.Backgrounds.acolyte);
        var cl = pc.Factory.CreateClass(id: Library.Classes.cleric, level: 1);
        pc.Classes.Add(cl);
        pc.Gender = GenderID.Female;
        //cl.ArchetypeIDs.Add(Library.Archetypes.pretre_vie_soins);

        pc.Abilities.Strength.BaseScore = 14;
        pc.Abilities.Dexterity.BaseScore = 10;
        pc.Abilities.Constitution.BaseScore = 16;
        pc.Abilities.Intelligence.BaseScore = 10;
        pc.Abilities.Wisdom.BaseScore = 17;
        pc.Abilities.Charisma.BaseScore = 11;

        cl.SelectedSkillProficiencies.Add(SkillID.Medicine);
        cl.SelectedSkillProficiencies.Add(SkillID.Insight);
        cl.SelectedSkillProficiencies.Add(SkillID.Persuasion);
        cl.SelectedSkillProficiencies.Add(SkillID.Religion);
        //Skills.Medicine.Proficiency = true;
        //Skills.Insight.Proficiency = true;
        //Skills.Persuasion.Proficiency = true;
        //Skills.Religion.Proficiency = true;

        cl.HitPointsPerLevel.Add(cl.HitDice);
        pc.TemporaryHitPoints = pc.CurrentHitPoints;

        pc.EquipmentRefs.Add(pc.Factory.CreateEquipment(id: Library.Equipments.warhammer, isEquipped: true));
        pc.EquipmentRefs.Add(pc.Factory.CreateEquipment(id: Library.Equipments.studded_leather_armor, isEquipped: true));
        pc.EquipmentRefs.Add(pc.Factory.CreateEquipment(id: Library.Equipments.shield, isEquipped: true));

        pc.EquipmentRefs.Add(pc.Factory.CreateEquipment(id: Library.Equipments.backpack));
        pc.EquipmentRefs.Add(pc.Factory.CreateEquipment(id: Library.Equipments.couverture));
        pc.EquipmentRefs.Add(pc.Factory.CreateEquipment(id: Library.Equipments.bougie, quantity: 10));
        pc.EquipmentRefs.Add(pc.Factory.CreateEquipment(id: Library.Equipments.briquet_a_amadou));
        pc.EquipmentRefs.Add(pc.Factory.CreateEquipment(id: Library.Equipments.rations, quantity: 2));
        pc.EquipmentRefs.Add(pc.Factory.CreateEquipment(id: Library.Equipments.outre));

        //cl.SelectedFeatures.Add(pc.Factory.CreateFeature(id: Library.Features.amelioration_de_caracteristique_wisdom, minimumLevel: 4));
        //cl.SelectedFeatures.Add(pc.Factory.CreateFeature(id: Library.Features.amelioration_de_caracteristique_wisdom, minimumLevel: 4));

        //cl.KnownSpells.Add(Library.Spells.assistance);
        //cl.KnownSpells.Add(Library.Spells.flamme_sacree);
        //cl.KnownSpells.Add(Library.Spells.lumiere);

        //var featAbilities = AllAvailableClassFeatures.Where(feat => feat.ID == Library.Features.amelioration_de_caracteristique).FirstOrDefault();
        //featAbilities.SelectedChoices.Add(Library.Features.amelioration_de_caracteristique_wisdom);
        //featAbilities.SelectedChoices.Add(Library.Features.amelioration_de_caracteristique_wisdom);
        return pc;
    }

    public static PlayerCharacter LoadIlzaach()
    {
        var pc = new PlayerCharacter();

        pc.CharacterName = Library.PlayerCharacters.ilzaach_name;
        pc.CharacterPicture = Library.PlayerCharacters.ilzaach_picture;
        pc.CharacterSmallPicture = Library.PlayerCharacters.ilzaach_small_picture;
        pc.Origin = pc.Factory.CreateOrigin(id: Library.Origins.dragonborn);
        pc.Background = pc.Factory.CreateBackground(id: Library.Backgrounds.manouvrier);
        var cl = pc.Factory.CreateClass(id: Library.Classes.paladin, level: 2);
        pc.Classes.Add(cl);
        pc.Gender = GenderID.Male;

        pc.Abilities.Strength.BaseScore = 17;
        pc.Abilities.Dexterity.BaseScore = 10;
        pc.Abilities.Constitution.BaseScore = 15;
        pc.Abilities.Intelligence.BaseScore = 11;
        pc.Abilities.Wisdom.BaseScore = 8;
        pc.Abilities.Charisma.BaseScore = 14;

        cl.SelectedSkillProficiencies.Add(SkillID.Athletics);
        cl.SelectedSkillProficiencies.Add(SkillID.Sleight_Of_Hand);
        cl.SelectedSkillProficiencies.Add(SkillID.Intimidation);
        cl.SelectedSkillProficiencies.Add(SkillID.Persuasion);
        //Skills.Athletics.Proficiency = true;
        //Skills.SleightOfHand.Proficiency = true;
        //Skills.Intimidation.Proficiency = true;
        //Skills.Persuasion.Proficiency = true;

        cl.HitPointsPerLevel.Add(cl.HitDice);
        cl.HitPointsPerLevel.Add(2);
        pc.TemporaryHitPoints = pc.CurrentHitPoints;

        pc.EquipmentRefs.Add(pc.Factory.CreateEquipment(id: Library.Equipments.halberd, isEquipped: true));
        pc.EquipmentRefs.Add(pc.Factory.CreateEquipment(id: Library.Equipments.trident, isEquipped: true));
        pc.EquipmentRefs.Add(pc.Factory.CreateEquipment(id: Library.Equipments.dagger, isEquipped: true));
        pc.EquipmentRefs.Add(pc.Factory.CreateEquipment(id: Library.Equipments.splint, isEquipped: true));

        pc.Origin.SelectedFeatures.Add(pc.Factory.CreateFeature(id: Library.Features.resistance_aux_degats_de_froid));
        pc.Origin.SelectedFeatures.Add(pc.Factory.CreateFeature(id: Library.Features.style_de_combat_armes_a_deux_mains));

        //cl.SelectedFeatures.Add(pc.Factory.CreateFeature(id: Library.Features.amelioration_de_caracteristique_strength, minimumLevel: 4));

        //var featDamageResistance = OriginFeatures.Where(feat => feat.ID == Library.Features.resistance_aux_degats).FirstOrDefault();
        //featDamageResistance.SelectedChoices.Add(Library.Features.resistance_aux_degats_de_froid);
        //var featStyle = AllAvailableClassFeatures.Where(feat => feat.ID == Library.Features.style_de_combat).FirstOrDefault();
        //featStyle.SelectedChoices.Add(Library.Features.style_de_combat_armes_a_deux_mains);

        //var featAbilities = AllAvailableClassFeatures.Where(feat => feat.ID == Library.Features.amelioration_de_caracteristique).FirstOrDefault();
        //featAbilities.SelectedChoices.Add(Library.Features.amelioration_de_caracteristique_strength);


        // TODO : augment de carac manquante pour Ilzaach
        //feat.SelectedIDs.Add(Library.Features.amelioration_de_caracteristique_strength);
        return pc;
    }

    public static PlayerCharacter LoadLeowen()
    {
        var pc = new PlayerCharacter();

        pc.CharacterName = Library.PlayerCharacters.leowen_name;
        pc.CharacterPicture = Library.PlayerCharacters.leowen_picture;
        pc.CharacterSmallPicture = Library.PlayerCharacters.leowen_small_picture;
        pc.Origin = pc.Factory.CreateOrigin(id: Library.Origins.halfelf);
        pc.Background = pc.Factory.CreateBackground(id: Library.Backgrounds.dummy); //.sang_bleu };
        var cl = pc.Factory.CreateClass(id: Library.Classes.ranger, level: 2);
        pc.Classes.Add(cl);
        pc.Gender = GenderID.Female;
        //cl.ArchetypeIDs.Add(Library.Archetypes.archer_arcanique);

        pc.Abilities.Strength.BaseScore = 12;
        pc.Abilities.Dexterity.BaseScore = 17;
        pc.Abilities.Constitution.BaseScore = 14;
        pc.Abilities.Intelligence.BaseScore = 11;
        pc.Abilities.Wisdom.BaseScore = 15;
        pc.Abilities.Charisma.BaseScore = 8;

        //PrimaryClass.SelectedSkillProficiencies.Add(SkillID.Investigation);
        //PrimaryClass.SelectedSkillProficiencies.Add(SkillID.Insight);
        cl.SelectedSkillProficiencies.Add(SkillID.Athletics);
        cl.SelectedSkillProficiencies.Add(SkillID.Stealth);
        cl.SelectedSkillProficiencies.Add(SkillID.Animal_Handling);
        cl.SelectedSkillProficiencies.Add(SkillID.Insight);
        cl.SelectedSkillProficiencies.Add(SkillID.Persuasion);
        cl.SelectedSkillProficiencies.Add(SkillID.Survival);
        //Skills.Athletics.Proficiency = true;
        //Skills.Stealth.Proficiency = true;
        //Skills.AnimalHandling.Proficiency = true;
        //Skills.Insight.Proficiency = true;
        //Skills.Persuasion.Proficiency = true;
        //Skills.Survival.Proficiency = true;

        cl.HitPointsPerLevel.Add(cl.HitDice);
        cl.HitPointsPerLevel.Add(9);
        pc.TemporaryHitPoints = pc.CurrentHitPoints;
        //TemporaryHitPoints = CurrentHitPoints = 19;
        //PrimaryClass.UsedHitDie = 2;

        pc.EquipmentRefs.Add(pc.Factory.CreateEquipment(id: Library.Equipments.shortsword, isEquipped: true));
        pc.EquipmentRefs.Add(pc.Factory.CreateEquipment(id: Library.Equipments.dagger, isEquipped: true));
        pc.EquipmentRefs.Add(pc.Factory.CreateEquipment(id: Library.Equipments.longbow, isEquipped: true));
        pc.EquipmentRefs.Add(pc.Factory.CreateEquipment(id: Library.Equipments.studded_leather_armor, isEquipped: true));

        cl.SelectedFeatures.Add(pc.Factory.CreateFeature(id: Library.Features.style_de_combat_archerie));

        //cl.SelectedFeatures.Add(pc.Factory.CreateFeature(id: Library.Features.amelioration_de_caracteristique_dexterity, minimumLevel: 4));
        //cl.SelectedFeatures.Add(pc.Factory.CreateFeature(id: Library.Features.amelioration_de_caracteristique_dexterity, minimumLevel: 4));

        //cl.KnownSpells.Add(Library.Spells.amitie_avec_les_animaux);
        //cl.KnownSpells.Add(Library.Spells.marque_du_chasseur);

        //var featStyle = AllAvailableClassFeatures.Where(feat => feat.ID == Library.Features.style_de_combat).FirstOrDefault();
        //featStyle.SelectedChoices.Add(Library.Features.style_de_combat_archerie);

        //var featAbilities = AllAvailableClassFeatures.Where(feat => feat.ID == Library.Features.amelioration_de_caracteristique).FirstOrDefault();
        //featAbilities.SelectedChoices.Add(Library.Features.amelioration_de_caracteristique_dexterity);
        //featAbilities.SelectedChoices.Add(Library.Features.amelioration_de_caracteristique_dexterity);
        return pc;
    }

    public static PlayerCharacter LoadDarkna()
    {
        var pc = new PlayerCharacter();

        pc.CharacterName = Library.PlayerCharacters.darkna_name;
        pc.CharacterPicture = Library.PlayerCharacters.darkna_picture;
        pc.CharacterSmallPicture = Library.PlayerCharacters.darkna_small_picture;
        pc.Origin = pc.Factory.CreateOrigin(id: Library.Origins.halforc);
        pc.Background = pc.Factory.CreateBackground(id: Library.Backgrounds.primitif); // ou solitaire
        var cl = pc.Factory.CreateClass(id: Library.Classes.druid, level: 2);
        pc.Classes.Add(cl);
        pc.Gender = GenderID.Female;
        //cl.ArchetypeIDs.Add(Library.Archetypes.cercle_des_profondeurs);

        pc.Abilities.Strength.BaseScore = 12;
        pc.Abilities.Dexterity.BaseScore = 13;
        pc.Abilities.Constitution.BaseScore = 12;
        pc.Abilities.Intelligence.BaseScore = 13;
        pc.Abilities.Wisdom.BaseScore = 14;
        pc.Abilities.Charisma.BaseScore = 11;

        cl.SelectedSkillProficiencies.Add(SkillID.Arcana);
        cl.SelectedSkillProficiencies.Add(SkillID.Animal_Handling);
        cl.SelectedSkillProficiencies.Add(SkillID.Intimidation);
        cl.SelectedSkillProficiencies.Add(SkillID.Medicine);
        cl.SelectedSkillProficiencies.Add(SkillID.Survival);
        //Skills.Arcana.Proficiency = true;
        //Skills.AnimalHandling.Proficiency = true;
        //Skills.Intimidation.Proficiency = true;
        //Skills.Medicine.Proficiency = true;
        //Skills.Survival.Proficiency = true;

        cl.HitPointsPerLevel.Add(cl.HitDice);
        cl.HitPointsPerLevel.Add(5);
        pc.TemporaryHitPoints = pc.CurrentHitPoints;
        //TemporaryHitPoints = CurrentHitPoints = 13;
        //PrimaryClass.UsedHitDie = 2;

        pc.EquipmentRefs.Add(pc.Factory.CreateEquipment(id: Library.Equipments.club, isEquipped: true));
        pc.EquipmentRefs.Add(pc.Factory.CreateEquipment(id: Library.Equipments.scimitar, isEquipped: true));
        pc.EquipmentRefs.Add(pc.Factory.CreateEquipment(id: Library.Equipments.dagger, isEquipped: true));
        pc.EquipmentRefs.Add(pc.Factory.CreateEquipment(id: Library.Equipments.javelin, isEquipped: true));
        pc.EquipmentRefs.Add(pc.Factory.CreateEquipment(id: Library.Equipments.hide_armor, isEquipped: true));

        //cl.SelectedFeatures.Add(pc.Factory.CreateFeature(id: Library.Features.amelioration_de_caracteristique_wisdom, minimumLevel: 4));
        //cl.SelectedFeatures.Add(pc.Factory.CreateFeature(id: Library.Features.amelioration_de_caracteristique_wisdom, minimumLevel: 4));

        //cl.KnownSpells.Add(Library.Spells.assistance);
        //cl.KnownSpells.Add(Library.Spells.gourdin_magique);

        //var featAbilities = AllAvailableClassFeatures.Where(feat => feat.ID == Library.Features.amelioration_de_caracteristique).FirstOrDefault();
        //featAbilities.SelectedChoices.Add(Library.Features.amelioration_de_caracteristique_wisdom);
        //featAbilities.SelectedChoices.Add(Library.Features.amelioration_de_caracteristique_wisdom);
        return pc;
    }

    public static PlayerCharacter LoadOzyias()
    {
        var pc = new PlayerCharacter();

        pc.CharacterName = Library.PlayerCharacters.ozyias_name;
        pc.CharacterPicture = Library.PlayerCharacters.ozyias_picture;
        pc.CharacterSmallPicture = Library.PlayerCharacters.ozyias_small_picture;
        pc.Origin = pc.Factory.CreateOrigin(id: Library.Origins.gnome);
        pc.Background = pc.Factory.CreateBackground(id: Library.Backgrounds.membre_de_guilde);
        var cl = pc.Factory.CreateClass(id: Library.Classes.sorcerer, level: 2);
        pc.Classes.Add(cl);
        pc.Gender = GenderID.Male;
        //cl.ArchetypeIDs.Add(Library.Archetypes.lignee_infernale);

        pc.Abilities.Strength.BaseScore = 9;
        pc.Abilities.Dexterity.BaseScore = 11;
        pc.Abilities.Constitution.BaseScore = 13;
        pc.Abilities.Intelligence.BaseScore = 11;
        pc.Abilities.Wisdom.BaseScore = 15;
        pc.Abilities.Charisma.BaseScore = 16;

        cl.SelectedSkillProficiencies.Add(SkillID.Arcana);
        cl.SelectedSkillProficiencies.Add(SkillID.Insight);
        cl.SelectedSkillProficiencies.Add(SkillID.Persuasion);
        cl.SelectedSkillProficiencies.Add(SkillID.Religion);
        //Skills.Arcana.Proficiency = true;
        //Skills.Insight.Proficiency = true;
        //Skills.Persuasion.Proficiency = true;
        //Skills.Religion.Proficiency = true;

        cl.HitPointsPerLevel.Add(cl.HitDice);
        cl.HitPointsPerLevel.Add(5);
        pc.TemporaryHitPoints = pc.CurrentHitPoints;
        //TemporaryHitPoints = CurrentHitPoints = 11;
        //PrimaryClass.UsedHitDie = 2;

        pc.EquipmentRefs.Add(pc.Factory.CreateEquipment(id: Library.Equipments.dagger, isEquipped: true));
        pc.EquipmentRefs.Add(pc.Factory.CreateEquipment(id: Library.Equipments.light_crossbow, isEquipped: true));

        //cl.SelectedFeatures.Add(pc.Factory.CreateFeature(id: Library.Features.amelioration_de_caracteristique_strength, minimumLevel: 4));
        //cl.SelectedFeatures.Add(pc.Factory.CreateFeature(id: Library.Features.amelioration_de_caracteristique_constitution, minimumLevel: 4));

        //cl.KnownSpells.Add(Library.Spells.lumieres_dansantes);
        //cl.KnownSpells.Add(Library.Spells.main_du_mage);
        //cl.KnownSpells.Add(Library.Spells.rayon_de_givre);
        //cl.KnownSpells.Add(Library.Spells.trait_de_feu);
        //cl.KnownSpells.Add(Library.Spells.armure_du_mage);
        //cl.KnownSpells.Add(Library.Spells.projectile_magique);
        //cl.KnownSpells.Add(Library.Spells.sommeil);

        //var featAbilities = AllAvailableClassFeatures.Where(feat => feat.ID == Library.Features.amelioration_de_caracteristique).FirstOrDefault();
        //featAbilities.SelectedChoices.Add(Library.Features.amelioration_de_caracteristique_strength);
        //featAbilities.SelectedChoices.Add(Library.Features.amelioration_de_caracteristique_constitution);
        return pc;
    }

    public static PlayerCharacter LoadGalefrin()
    {
        var pc = new PlayerCharacter();

        pc.CharacterName = Library.PlayerCharacters.galefrin_name;
        pc.CharacterPicture = Library.PlayerCharacters.galefrin_picture;
        pc.CharacterSmallPicture = Library.PlayerCharacters.galefrin_small_picture;
        pc.Origin = pc.Factory.CreateOrigin(id: Library.Origins.halfling);
        pc.Background = pc.Factory.CreateBackground(id: Library.Backgrounds.explorateur);
        var cl = pc.Factory.CreateClass(id: Library.Classes.rogue, level: 2);
        pc.Classes.Add(cl);
        pc.Gender = GenderID.Male;
        //cl.ArchetypeIDs.Add(Library.Archetypes.shadowblade);

        pc.Abilities.Strength.BaseScore = 9;
        pc.Abilities.Dexterity.BaseScore = 16;
        pc.Abilities.Constitution.BaseScore = 11;
        pc.Abilities.Intelligence.BaseScore = 12;
        pc.Abilities.Wisdom.BaseScore = 14;
        pc.Abilities.Charisma.BaseScore = 13;

        cl.SelectedSkillProficiencies.Add(SkillID.Stealth);
        cl.SelectedSkillProficiencies.Add(SkillID.Sleight_Of_Hand);
        cl.SelectedSkillProficiencies.Add(SkillID.History);
        cl.SelectedSkillProficiencies.Add(SkillID.Insight);
        cl.SelectedSkillProficiencies.Add(SkillID.Deception);
        cl.SelectedSkillProficiencies.Add(SkillID.Survival);
        //Skills.Stealth.Proficiency = true;
        //Skills.SleightOfHand.Proficiency = true;
        //Skills.History.Proficiency = true;
        //Skills.Insight.Proficiency = true;
        //Skills.Deception.Proficiency = true;
        //Skills.Survival.Proficiency = true;

        cl.HitPointsPerLevel.Add(cl.HitDice);
        cl.HitPointsPerLevel.Add(7);
        pc.TemporaryHitPoints = pc.CurrentHitPoints;
        //TemporaryHitPoints = CurrentHitPoints = 15;
        //PrimaryClass.UsedHitDie = 2;

        pc.EquipmentRefs.Add(pc.Factory.CreateEquipment(id: Library.Equipments.dagger, isEquipped: true));
        pc.EquipmentRefs.Add(pc.Factory.CreateEquipment(id: Library.Equipments.rapier, isEquipped: true));
        pc.EquipmentRefs.Add(pc.Factory.CreateEquipment(id: Library.Equipments.shortsword, isEquipped: true));
        pc.EquipmentRefs.Add(pc.Factory.CreateEquipment(id: Library.Equipments.hand_crossbow, isEquipped: true));
        pc.EquipmentRefs.Add(pc.Factory.CreateEquipment(id: Library.Equipments.studded_leather_armor, isEquipped: true));

        cl.SelectedFeatures.Add(pc.Factory.CreateFeature(id: Library.Features.expertise_discretion));
        cl.SelectedFeatures.Add(pc.Factory.CreateFeature(id: Library.Features.expertise_supercherie));

        //cl.SelectedFeatures.Add(pc.Factory.CreateFeature(id: Library.Features.amelioration_de_caracteristique_strength, minimumLevel: 4));
        //cl.SelectedFeatures.Add(pc.Factory.CreateFeature(id: Library.Features.amelioration_de_caracteristique_constitution, minimumLevel: 4));


        //var featExpertise = AllAvailableClassFeatures.Where(feat => feat.ID == Library.Features.expertise_rogue).FirstOrDefault();
        //featExpertise.SelectedChoices.Add(Library.Features.expertise_discretion);
        //featExpertise.SelectedChoices.Add(Library.Features.expertise_supercherie);

        //var featAbilities = AllAvailableClassFeatures.Where(feat => feat.ID == Library.Features.amelioration_de_caracteristique).FirstOrDefault();
        //featAbilities.SelectedChoices.Add(Library.Features.amelioration_de_caracteristique_strength);
        //featAbilities.SelectedChoices.Add(Library.Features.amelioration_de_caracteristique_constitution);
        return pc;
    }

    public static PlayerCharacter LoadMalathor()
    {
        var pc = new PlayerCharacter();

        pc.CharacterName = Library.PlayerCharacters.malathor_name;
        pc.CharacterPicture = Library.PlayerCharacters.malathor_picture;
        pc.CharacterSmallPicture = Library.PlayerCharacters.malathor_small_picture;
        pc.Origin = pc.Factory.CreateOrigin(id: Library.Origins.human);
        pc.Background = pc.Factory.CreateBackground(id: Library.Backgrounds.militaire);
        // hommedeloi ou
        // membredeguilde ou sub artisan ou sub commercant ou
        // militaire ou sub garde ou sub officier
        var cl = pc.Factory.CreateClass(id: Library.Classes.paladin, level: 2);
        pc.Classes.Add(cl);
        pc.Gender = GenderID.Male;

        pc.Abilities.Strength.BaseScore = 17;
        pc.Abilities.Dexterity.BaseScore = 9;
        pc.Abilities.Constitution.BaseScore = 13;
        pc.Abilities.Intelligence.BaseScore = 9;
        pc.Abilities.Wisdom.BaseScore = 13;
        pc.Abilities.Charisma.BaseScore = 16;

        cl.SelectedSkillProficiencies.Add(SkillID.Athletics);
        cl.SelectedSkillProficiencies.Add(SkillID.Intimidation);
        cl.SelectedSkillProficiencies.Add(SkillID.Insight);
        cl.SelectedSkillProficiencies.Add(SkillID.Persuasion);
        //Skills.Athletics.Proficiency = true;
        //Skills.Intimidation.Proficiency = true;
        //Skills.Insight.Proficiency = true;
        //Skills.Persuasion.Proficiency = true;

        cl.HitPointsPerLevel.Add(cl.HitDice);
        cl.HitPointsPerLevel.Add(5);
        pc.TemporaryHitPoints = pc.CurrentHitPoints;
        //TemporaryHitPoints = CurrentHitPoints = 15;
        //PrimaryClass.UsedHitDie = 2;

        pc.EquipmentRefs.Add(pc.Factory.CreateEquipment(id: Library.Equipments.epee_ardente1, isEquipped: true));
        pc.EquipmentRefs.Add(pc.Factory.CreateEquipment(id: Library.Equipments.dagger, isEquipped: true));
        pc.EquipmentRefs.Add(pc.Factory.CreateEquipment(id: Library.Equipments.harnois_nain, isEquipped: true));

        //cl.SelectedFeatures.Add(pc.Factory.CreateFeature(id: Library.Features.amelioration_de_caracteristique_strength, minimumLevel: 4));
        //cl.SelectedFeatures.Add(pc.Factory.CreateFeature(id: Library.Features.amelioration_de_caracteristique_strength, minimumLevel: 4));


        //var featAbilities = AllAvailableClassFeatures.Where(feat => feat.ID == Library.Features.amelioration_de_caracteristique).FirstOrDefault();
        //featAbilities.SelectedChoices.Add(Library.Features.amelioration_de_caracteristique_strength);
        //featAbilities.SelectedChoices.Add(Library.Features.amelioration_de_caracteristique_strength);
        return pc;
    }
}



