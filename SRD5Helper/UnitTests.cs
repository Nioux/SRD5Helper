using CommunityToolkit.Mvvm.DependencyInjection;
using SRD5Helper.Data;
using SRD5Helper.DataModels;
using SRD5Helper.Tools;
using SRD5Helper.ViewModels;
using System.Diagnostics;
using System.util;
using Library = SRD5Helper.Resources.Library;

namespace SRD5Helper;

internal class UnitTests
{
    public void TestU()
    {
        var storage = Ioc.Default.GetRequiredService<DataService>();

        TestUFull(storage.PlayerCharacters["selmays"], TestUSelmays, TestUSelmaysUpLevel);
        TestUFull(storage.PlayerCharacters["beric"], TestUBeric, TestUBericUpLevel);
        TestUFull(storage.PlayerCharacters["siam"], TestUSiam, TestUSiamUpLevel);
        TestUFull(storage.PlayerCharacters["rhingann"], TestURhingann, TestURhingannUpLevel);
        TestUFull(storage.PlayerCharacters["ilzaach"], TestUIlzaach, TestUIlzaachUpLevel);
        TestUFull(storage.PlayerCharacters["leowen"], TestULeowen, TestULeowenUpLevel);
        TestUFull(storage.PlayerCharacters["darkna"], TestUDarkna, TestUDarknaUpLevel);
        TestUFull(storage.PlayerCharacters["ozyias"], TestUOzyias, TestUOzyiasUpLevel);
        TestUFull(storage.PlayerCharacters["galefrin"], TestUGalefrin, TestUGalefrinUpLevel);
        TestUFull(storage.PlayerCharacters["malathor"], TestUMalathor, TestUMalathorUpLevel);

        //TestUSelmaysFull();
        //TestUBericFull();
        //TestUSiamFull();
        //TestURhingannFull();
        //TestUIlzaachFull();
        //TestULeowenFull();
        //TestUDarknaFull();
        //TestUOzyiasFull();
        //TestUGalefrinFull();
        //TestUMalathorFull();
    }

    public void TestLevel(PlayerCharacter pc, Action<PlayerCharacter> actionTestU, Action<PlayerCharacter> actionTestUUpLevel, int level)
    {
        var yaml = Serializers.ClassToYaml(pc);
        var pcyaml = Serializers.YamlToClass<PlayerCharacter>(yaml);
        while(pcyaml.PrimaryClass.Level < level)
        {
            if(actionTestUUpLevel != null)
            {
                actionTestUUpLevel.Invoke(pcyaml);
            }
            else
            {
                pcyaml.PrimaryClass.UpLevel();
            }
        }
        actionTestU(pc);
        actionTestU(pcyaml);
    }
    public void TestUFull(PlayerCharacter pc, Action<PlayerCharacter> actionTestU, Action<PlayerCharacter> actionTestUUpLevel = null)
    {
        if (pc.PrimaryClass.Level == 1)
        {
            TestLevel(pc, actionTestU, actionTestUUpLevel, 1);
        }
        TestLevel(pc, actionTestU, actionTestUUpLevel, 2);
        TestLevel(pc, actionTestU, actionTestUUpLevel, 3);
        TestLevel(pc, actionTestU, actionTestUUpLevel, 4);
    }

    void TestUSelmaysUpLevel(PlayerCharacter pc) 
    {
        pc.PrimaryClass.UpLevel();
        if(pc.Level == 4) 
        {
            pc.PrimaryClass.SelectedFeatures.Add(pc.Factory.CreateFeature(id: Library.Features.amelioration_de_caracteristique_intelligence));
            pc.PrimaryClass.SelectedFeatures.Add(pc.Factory.CreateFeature(id: Library.Features.amelioration_de_caracteristique_intelligence));
        }
    }

    void TestUSelmays(PlayerCharacter pc)
    {
        Debug.Assert(pc.CharacterName == "Selmays");

        Debug.Assert(pc.ProficiencyBonus == 2);
        Debug.Assert(pc.PassiveWisdom == 12);
        Debug.Assert(pc.ArmorClass == 11); // errata
        Debug.Assert(pc.Initiative == 1);
        Debug.Assert(pc.MeleeAttackBonus == 1);
        Debug.Assert(pc.RangedAttackBonus == 3);
        Debug.Assert(pc.SpellAttackBonus == (pc.Level < 4 ? 6 : 7));
        Debug.Assert(pc.SpellSaveDC == (pc.Level < 4 ? 14 : 15));
        Debug.Assert(pc.TotalCurrentHitPoints == 6 + 2 * pc.Level);
        Debug.Assert(pc.HitDice == 6);

        Debug.Assert(pc.Abilities.Strength.Score == 8);
        Debug.Assert(pc.Abilities.Strength.Mod == -1);
        Debug.Assert(pc.Abilities.Strength.Save == -1);
        Debug.Assert(pc.Abilities.Strength.SaveProficiency == false);
        Debug.Assert(pc.Abilities.Dexterity.Score == 12);
        Debug.Assert(pc.Abilities.Dexterity.Mod == 1);
        Debug.Assert(pc.Abilities.Dexterity.Save == 1);
        Debug.Assert(pc.Abilities.Dexterity.SaveProficiency == false);
        Debug.Assert(pc.Abilities.Constitution.Score == 14);
        Debug.Assert(pc.Abilities.Constitution.Mod == 2);
        Debug.Assert(pc.Abilities.Constitution.Save == 2);
        Debug.Assert(pc.Abilities.Constitution.SaveProficiency == false);
        Debug.Assert(pc.Abilities.Intelligence.Score == (pc.Level < 4 ? 18 : 20));
        Debug.Assert(pc.Abilities.Intelligence.Mod == (pc.Level < 4 ? 4 : 5));
        Debug.Assert(pc.Abilities.Intelligence.Save == (pc.Level < 4 ? 6 : 7));
        Debug.Assert(pc.Abilities.Intelligence.SaveProficiency == true);
        Debug.Assert(pc.Abilities.Wisdom.Score == 14);
        Debug.Assert(pc.Abilities.Wisdom.Mod == 2);
        Debug.Assert(pc.Abilities.Wisdom.Save == 4);
        Debug.Assert(pc.Abilities.Wisdom.SaveProficiency == true);
        Debug.Assert(pc.Abilities.Charisma.Score == 13);
        Debug.Assert(pc.Abilities.Charisma.Mod == 1);
        Debug.Assert(pc.Abilities.Charisma.Save == 1);
        Debug.Assert(pc.Abilities.Charisma.SaveProficiency == false);

        Debug.Assert(pc.Skills.Acrobatics.Mod == 1);
        Debug.Assert(pc.Skills.Acrobatics.Proficiency == false);
        Debug.Assert(pc.Skills.Arcana.Mod == (pc.Level < 4 ? 6 : 7));
        Debug.Assert(pc.Skills.Arcana.Proficiency == true);
        Debug.Assert(pc.Skills.Athletics.Mod == -1);
        Debug.Assert(pc.Skills.Athletics.Proficiency == false);
        Debug.Assert(pc.Skills.Stealth.Mod == 1);
        Debug.Assert(pc.Skills.Stealth.Proficiency == false);
        Debug.Assert(pc.Skills.AnimalHandling.Mod == 2);
        Debug.Assert(pc.Skills.AnimalHandling.Proficiency == false);
        Debug.Assert(pc.Skills.SleightOfHand.Mod == 1);
        Debug.Assert(pc.Skills.SleightOfHand.Proficiency == false);
        Debug.Assert(pc.Skills.History.Mod == (pc.Level < 4 ? 6 : 7));
        Debug.Assert(pc.Skills.History.Proficiency == true);
        Debug.Assert(pc.Skills.Intimidation.Mod == 1);
        Debug.Assert(pc.Skills.Intimidation.Proficiency == false);
        Debug.Assert(pc.Skills.Investigation.Mod == (pc.Level < 4 ? 6 : 7));
        Debug.Assert(pc.Skills.Investigation.Proficiency == true);
        Debug.Assert(pc.Skills.Medicine.Mod == 2);
        Debug.Assert(pc.Skills.Medicine.Proficiency == false);
        Debug.Assert(pc.Skills.Nature.Mod == (pc.Level < 4 ? 4 : 5));
        Debug.Assert(pc.Skills.Nature.Proficiency == false);
        Debug.Assert(pc.Skills.Perception.Mod == 4);
        Debug.Assert(pc.Skills.Perception.Proficiency == true);
        Debug.Assert(pc.Skills.Insight.Mod == 4);
        Debug.Assert(pc.Skills.Insight.Proficiency == true);
        Debug.Assert(pc.Skills.Persuasion.Mod == 1);
        Debug.Assert(pc.Skills.Persuasion.Proficiency == false);
        Debug.Assert(pc.Skills.Religion.Mod == (pc.Level < 4 ? 4 : 5));
        Debug.Assert(pc.Skills.Religion.Proficiency == false);
        Debug.Assert(pc.Skills.Performance.Mod == 1);
        Debug.Assert(pc.Skills.Performance.Proficiency == false);
        Debug.Assert(pc.Skills.Deception.Mod == 1);
        Debug.Assert(pc.Skills.Deception.Proficiency == false);
        Debug.Assert(pc.Skills.Survival.Mod == 2);
        Debug.Assert(pc.Skills.Survival.Proficiency == false);

        Debug.Assert(pc.Weapons[0].ID == Library.Equipments.dagger);
        Debug.Assert(pc.Weapons[0].MeleeAttackModifier == 3);
        Debug.Assert(pc.Weapons[0].MeleeDamage.Value.DiceCount == null);
        Debug.Assert(pc.Weapons[0].MeleeDamage.Value.Dice == 4);
        Debug.Assert(pc.Weapons[0].MeleeDamage.Value.Modifier == 1);
        Debug.Assert(pc.Weapons[0].MeleeDamage.Value.Type == DamageType.Piercing);
        Debug.Assert(pc.Weapons[0].RangeAttackModifier == 3);
        Debug.Assert(pc.Weapons[0].RangeDamage.Value.DiceCount == null);
        Debug.Assert(pc.Weapons[0].RangeDamage.Value.Dice == 4);
        Debug.Assert(pc.Weapons[0].RangeDamage.Value.Modifier == 1);
        Debug.Assert(pc.Weapons[0].RangeDamage.Value.Type == DamageType.Piercing);
        Debug.Assert(pc.Weapons[0].Proficiency == true);
        Debug.Assert(pc.Weapons[0].ProficiencyBonus == 2);
        Debug.Assert(pc.Weapons.Count == 1);

        //Debug.Assert(pc.SpellRefs[0].ID == Library.Spells.lumiere);
        //Debug.Assert(pc.SpellRefs[0].IsKnown == true);
        //Debug.Assert(pc.SpellRefs[1].ID == Library.Spells.main_du_mage);
        //Debug.Assert(pc.SpellRefs[1].IsKnown == false);
        //Debug.Assert(pc.SpellRefs[2].ID == Library.Spells.poigne_electrique);
        //Debug.Assert(pc.SpellRefs[2].IsKnown == true);
        //Debug.Assert(pc.SpellRefs[3].ID == Library.Spells.porte_bonheur);
        //Debug.Assert(pc.SpellRefs[3].IsKnown == false);
        //Debug.Assert(pc.SpellRefs[4].ID == Library.Spells.prestidigitation);
        //Debug.Assert(pc.SpellRefs[4].IsKnown == false);
        //Debug.Assert(pc.SpellRefs[5].ID == Library.Spells.rayon_de_givre);
        //Debug.Assert(pc.SpellRefs[5].IsKnown == true);
        //Debug.Assert(pc.SpellRefs[6].ID == Library.Spells.armure_du_mage);
        //Debug.Assert(pc.SpellRefs[6].IsKnown == true);
        //Debug.Assert(pc.SpellRefs[7].ID == Library.Spells.charme_personne);
        //Debug.Assert(pc.SpellRefs[7].IsKnown == false);
        //Debug.Assert(pc.SpellRefs[8].ID == Library.Spells.comprehension_des_langues);
        //Debug.Assert(pc.SpellRefs[8].IsKnown == true);
        //Debug.Assert(pc.SpellRefs[9].ID == Library.Spells.couleurs_dansantes);
        //Debug.Assert(pc.SpellRefs[9].IsKnown == false);
        //Debug.Assert(pc.SpellRefs[10].ID == Library.Spells.detection_de_la_magie);
        //Debug.Assert(pc.SpellRefs[10].IsKnown == true);
        //Debug.Assert(pc.SpellRefs[11].ID == Library.Spells.identification);
        //Debug.Assert(pc.SpellRefs[11].IsKnown == false);
        //Debug.Assert(pc.SpellRefs[12].ID == Library.Spells.mains_brulantes);
        //Debug.Assert(pc.SpellRefs[12].IsKnown == true);
        //Debug.Assert(pc.SpellRefs[13].ID == Library.Spells.projectile_magique);
        //Debug.Assert(pc.SpellRefs[13].IsKnown == true);
        //Debug.Assert(pc.SpellRefs[14].ID == Library.Spells.sommeil);
        //Debug.Assert(pc.SpellRefs[14].IsKnown == true);

        //if (pc.Level >= 3)
        //{ 
        //    Debug.Assert(pc.SpellRefs[15].ID == Library.Spells.fleche_acide);
        //    Debug.Assert(pc.SpellRefs[11].IsKnown == false);
        //    Debug.Assert(pc.SpellRefs[16].ID == Library.Spells.flou);
        //    Debug.Assert(pc.SpellRefs[11].IsKnown == false);
        //    Debug.Assert(pc.SpellRefs[17].ID == Library.Spells.immobiliser_un_humanoide);
        //    Debug.Assert(pc.SpellRefs[11].IsKnown == false);
        //    Debug.Assert(pc.SpellRefs[18].ID == Library.Spells.invisibilite);
        //    Debug.Assert(pc.SpellRefs[11].IsKnown == false);
        //    Debug.Assert(pc.SpellRefs[19].ID == Library.Spells.pattes_d_araignee);
        //    Debug.Assert(pc.SpellRefs[11].IsKnown == false);
        //    Debug.Assert(pc.SpellRefs[20].ID == Library.Spells.rayon_affaiblissant);
        //    Debug.Assert(pc.SpellRefs[11].IsKnown == false);
        //    Debug.Assert(pc.SpellRefs[21].ID == Library.Spells.suggestion);
        //    Debug.Assert(pc.SpellRefs[11].IsKnown == false);
        //    Debug.Assert(pc.SpellRefs[22].ID == Library.Spells.tenebres);
        //    Debug.Assert(pc.SpellRefs[11].IsKnown == false);
        //    Debug.Assert(pc.SpellRefs[23].ID == Library.Spells.toile_d_araignee);
        //    Debug.Assert(pc.SpellRefs[11].IsKnown == false);
        //    Debug.Assert(pc.SpellRefs.Count == 24);
        //}
        //Debug.Assert(pc.SpellRefs.Count == (pc.Level < 3 ? 15 : 24));
        //Debug.Assert(pc.SpellRefs.Any(spell => spell.AlwaysPrepared) == false);
    }

    void TestUBericUpLevel(PlayerCharacter pc)
    {
        pc.PrimaryClass.UpLevel();
        if(pc.Level == 3)
        {
            //pc.PrimaryClass.ArchetypeIDs.Add(Library.Archetypes.champion);
        }
        if (pc.Level == 4)
        {
            pc.PrimaryClass.SelectedFeatures.Add(pc.Factory.CreateFeature(id: Library.Features.amelioration_de_caracteristique_strength));
            pc.PrimaryClass.SelectedFeatures.Add(pc.Factory.CreateFeature(id: Library.Features.amelioration_de_caracteristique_strength));
        }
    }
    void TestUBeric(PlayerCharacter pc)
    {
        //var storage = Ioc.Default.GetRequiredService<DataService>();
        //var pc = storage.PlayerCharacters["beric"];

        Debug.Assert(pc.CharacterName == "Beric");

        Debug.Assert(pc.ProficiencyBonus == 2);
        Debug.Assert(pc.PassiveWisdom == 10);
        Debug.Assert(pc.ArmorClass == 19);
        Debug.Assert(pc.Initiative == 3);
        Debug.Assert(pc.MeleeAttackBonus == (pc.Level < 4 ? 6 : 7));
        Debug.Assert(pc.RangedAttackBonus == 5);
        Debug.Assert(pc.SpellAttackBonus == null);
        Debug.Assert(pc.SpellSaveDC == null);
        Debug.Assert(pc.TotalCurrentHitPoints == 10 + 2 * pc.Level);
        Debug.Assert(pc.HitDice == 10);

        Debug.Assert(pc.Abilities.Strength.Score == (pc.Level < 4 ? 18 : 20));
        Debug.Assert(pc.Abilities.Strength.Mod == (pc.Level < 4 ? 4 : 5));
        Debug.Assert(pc.Abilities.Strength.Save == (pc.Level < 4 ? 6 : 7));
        Debug.Assert(pc.Abilities.Strength.SaveProficiency == true);
        Debug.Assert(pc.Abilities.Dexterity.Score == 16);
        Debug.Assert(pc.Abilities.Dexterity.Mod == 3);
        Debug.Assert(pc.Abilities.Dexterity.Save == 3);
        Debug.Assert(pc.Abilities.Dexterity.SaveProficiency == false);
        Debug.Assert(pc.Abilities.Constitution.Score == 15);
        Debug.Assert(pc.Abilities.Constitution.Mod == 2);
        Debug.Assert(pc.Abilities.Constitution.Save == 4);
        Debug.Assert(pc.Abilities.Constitution.SaveProficiency == true);
        Debug.Assert(pc.Abilities.Intelligence.Score == 13);
        Debug.Assert(pc.Abilities.Intelligence.Mod == 1);
        Debug.Assert(pc.Abilities.Intelligence.Save == 1);
        Debug.Assert(pc.Abilities.Intelligence.SaveProficiency == false);
        Debug.Assert(pc.Abilities.Wisdom.Score == 10);
        Debug.Assert(pc.Abilities.Wisdom.Mod == 0);
        Debug.Assert(pc.Abilities.Wisdom.Save == 0);
        Debug.Assert(pc.Abilities.Wisdom.SaveProficiency == false);
        Debug.Assert(pc.Abilities.Charisma.Score == 12);
        Debug.Assert(pc.Abilities.Charisma.Mod == 1);
        Debug.Assert(pc.Abilities.Charisma.Save == 1);
        Debug.Assert(pc.Abilities.Charisma.SaveProficiency == false);

        Debug.Assert(pc.Skills.Acrobatics.Mod == 3);
        Debug.Assert(pc.Skills.Acrobatics.Proficiency == false);
        Debug.Assert(pc.Skills.Arcana.Mod == 1);
        Debug.Assert(pc.Skills.Arcana.Proficiency == false);
        Debug.Assert(pc.Skills.Athletics.Mod == (pc.Level < 4 ? 6 : 7));
        Debug.Assert(pc.Skills.Athletics.Proficiency == true);
        Debug.Assert(pc.Skills.Stealth.Mod == 3);
        Debug.Assert(pc.Skills.Stealth.Proficiency == false);
        Debug.Assert(pc.Skills.AnimalHandling.Mod == 2);
        Debug.Assert(pc.Skills.AnimalHandling.Proficiency == true);
        Debug.Assert(pc.Skills.SleightOfHand.Mod == 3);
        Debug.Assert(pc.Skills.SleightOfHand.Proficiency == false);
        Debug.Assert(pc.Skills.History.Mod == 1);
        Debug.Assert(pc.Skills.History.Proficiency == false);
        Debug.Assert(pc.Skills.Intimidation.Mod == 1);
        Debug.Assert(pc.Skills.Intimidation.Proficiency == false);
        Debug.Assert(pc.Skills.Investigation.Mod == 1);
        Debug.Assert(pc.Skills.Investigation.Proficiency == false);
        Debug.Assert(pc.Skills.Medicine.Mod == 0);
        Debug.Assert(pc.Skills.Medicine.Proficiency == false);
        Debug.Assert(pc.Skills.Nature.Mod == 1);
        Debug.Assert(pc.Skills.Nature.Proficiency == false);
        Debug.Assert(pc.Skills.Perception.Mod == 0);
        Debug.Assert(pc.Skills.Perception.Proficiency == false);
        Debug.Assert(pc.Skills.Insight.Mod == 2);
        Debug.Assert(pc.Skills.Insight.Proficiency == true);
        Debug.Assert(pc.Skills.Persuasion.Mod == 1);
        Debug.Assert(pc.Skills.Persuasion.Proficiency == false);
        Debug.Assert(pc.Skills.Religion.Mod == 1);
        Debug.Assert(pc.Skills.Religion.Proficiency == false);
        Debug.Assert(pc.Skills.Performance.Mod == 1);
        Debug.Assert(pc.Skills.Performance.Proficiency == false);
        Debug.Assert(pc.Skills.Deception.Mod == 1);
        Debug.Assert(pc.Skills.Deception.Proficiency == false);
        Debug.Assert(pc.Skills.Survival.Mod == 2);
        Debug.Assert(pc.Skills.Survival.Proficiency == true);

        Debug.Assert(pc.Weapons[0].ID == Library.Equipments.longsword);
        Debug.Assert(pc.Weapons[0].MeleeAttackModifier == (pc.Level < 4 ? 6 : 7));
        Debug.Assert(pc.Weapons[0].MeleeDamage.Value.DiceCount == null);
        Debug.Assert(pc.Weapons[0].MeleeDamage.Value.Dice == 8);
        Debug.Assert(pc.Weapons[0].MeleeDamage.Value.Modifier == (pc.Level < 4 ? 4 : 5));
        Debug.Assert(pc.Weapons[0].MeleeDamage.Value.Type == DamageType.Slashing);
        Debug.Assert(pc.Weapons[0].Proficiency == true);
        Debug.Assert(pc.Weapons[0].ProficiencyBonus == 2);
        Debug.Assert(pc.Weapons[1].ID == Library.Equipments.light_crossbow);
        Debug.Assert(pc.Weapons[1].RangeAttackModifier == 5);
        Debug.Assert(pc.Weapons[1].RangeDamage.Value.DiceCount == null);
        Debug.Assert(pc.Weapons[1].RangeDamage.Value.Dice == 8);
        Debug.Assert(pc.Weapons[1].RangeDamage.Value.Modifier == 3);
        Debug.Assert(pc.Weapons[1].RangeDamage.Value.Type == DamageType.Piercing);
        Debug.Assert(pc.Weapons[1].Proficiency == true);
        Debug.Assert(pc.Weapons[1].ProficiencyBonus == 2);
        Debug.Assert(pc.Weapons.Count == 2);

        Debug.Assert(pc.SpellRefs.Count == 0);
    }

    void TestUSiamUpLevel(PlayerCharacter pc)
    {
        pc.PrimaryClass.UpLevel();
        if (pc.Level == 4)
        {
            pc.PrimaryClass.SelectedFeatures.Add(pc.Factory.CreateFeature(id: Library.Features.amelioration_de_caracteristique_dexterity));
            pc.PrimaryClass.SelectedFeatures.Add(pc.Factory.CreateFeature(id: Library.Features.amelioration_de_caracteristique_dexterity));
        }
    }
    void TestUSiam(PlayerCharacter pc)
    {
        //var storage = Ioc.Default.GetRequiredService<DataService>();
        //var pc = storage.PlayerCharacters["siam"];

        Debug.Assert(pc.CharacterName == "Siam");

        Debug.Assert(pc.ProficiencyBonus == 2);
        Debug.Assert(pc.PassiveWisdom == 9);
        Debug.Assert(pc.ArmorClass == (pc.Level < 4 ? 15 : 16));
        Debug.Assert(pc.Initiative == (pc.Level < 4 ? 4 : 5));
        Debug.Assert(pc.MeleeAttackBonus == 3);
        Debug.Assert(pc.RangedAttackBonus == (pc.Level < 4 ? 6 : 7));
        Debug.Assert(pc.SpellAttackBonus == null);
        Debug.Assert(pc.SpellSaveDC == null);
        Debug.Assert(pc.TotalCurrentHitPoints == 8 + 0 * pc.Level);
        Debug.Assert(pc.HitDice == 8);

        Debug.Assert(pc.Abilities.Strength.Score == 13);
        Debug.Assert(pc.Abilities.Strength.Mod == 1);
        Debug.Assert(pc.Abilities.Strength.Save == 1);
        Debug.Assert(pc.Abilities.Strength.SaveProficiency == false);
        Debug.Assert(pc.Abilities.Dexterity.Score == (pc.Level < 4 ? 18 : 20));
        Debug.Assert(pc.Abilities.Dexterity.Mod == (pc.Level < 4 ? 4 : 5));
        Debug.Assert(pc.Abilities.Dexterity.Save == (pc.Level < 4 ? 6 : 7));
        Debug.Assert(pc.Abilities.Dexterity.SaveProficiency == true);
        Debug.Assert(pc.Abilities.Constitution.Score == 11);
        Debug.Assert(pc.Abilities.Constitution.Mod == 0);
        Debug.Assert(pc.Abilities.Constitution.Save == 0);
        Debug.Assert(pc.Abilities.Constitution.SaveProficiency == false);
        Debug.Assert(pc.Abilities.Intelligence.Score == 13);
        Debug.Assert(pc.Abilities.Intelligence.Mod == 1);
        Debug.Assert(pc.Abilities.Intelligence.Save == 3);
        Debug.Assert(pc.Abilities.Intelligence.SaveProficiency == true);
        Debug.Assert(pc.Abilities.Wisdom.Score == 8);
        Debug.Assert(pc.Abilities.Wisdom.Mod == -1);
        Debug.Assert(pc.Abilities.Wisdom.Save == -1);
        Debug.Assert(pc.Abilities.Wisdom.SaveProficiency == false);
        Debug.Assert(pc.Abilities.Charisma.Score == 15);
        Debug.Assert(pc.Abilities.Charisma.Mod == 2);
        Debug.Assert(pc.Abilities.Charisma.Save == 2);
        Debug.Assert(pc.Abilities.Charisma.SaveProficiency == false);

        Debug.Assert(pc.Skills.Acrobatics.Mod == (pc.Level < 4 ? 6 : 7));
        Debug.Assert(pc.Skills.Acrobatics.Proficiency == true);
        Debug.Assert(pc.Skills.Arcana.Mod == 1);
        Debug.Assert(pc.Skills.Arcana.Proficiency == false);
        Debug.Assert(pc.Skills.Athletics.Mod == 1);
        Debug.Assert(pc.Skills.Athletics.Proficiency == false);
        Debug.Assert(pc.Skills.Stealth.Mod == (pc.Level < 4 ? 8 : 9));
        Debug.Assert(pc.Skills.Stealth.Proficiency == true);
        Debug.Assert(pc.Skills.AnimalHandling.Mod == -1);
        Debug.Assert(pc.Skills.AnimalHandling.Proficiency == false);
        Debug.Assert(pc.Skills.SleightOfHand.Mod == (pc.Level < 4 ? 6 : 7));
        Debug.Assert(pc.Skills.SleightOfHand.Proficiency == true);
        Debug.Assert(pc.Skills.History.Mod == 1);
        Debug.Assert(pc.Skills.History.Proficiency == false);
        Debug.Assert(pc.Skills.Intimidation.Mod == 2);
        Debug.Assert(pc.Skills.Intimidation.Proficiency == false);
        Debug.Assert(pc.Skills.Investigation.Mod == 1);
        Debug.Assert(pc.Skills.Investigation.Proficiency == false);
        Debug.Assert(pc.Skills.Medicine.Mod == -1);
        Debug.Assert(pc.Skills.Medicine.Proficiency == false);
        Debug.Assert(pc.Skills.Nature.Mod == 1);
        Debug.Assert(pc.Skills.Nature.Proficiency == false);
        Debug.Assert(pc.Skills.Perception.Mod == -1);
        Debug.Assert(pc.Skills.Perception.Proficiency == false);
        Debug.Assert(pc.Skills.Insight.Mod == -1);
        Debug.Assert(pc.Skills.Insight.Proficiency == false);
        Debug.Assert(pc.Skills.Persuasion.Mod == 2);
        Debug.Assert(pc.Skills.Persuasion.Proficiency == false);
        Debug.Assert(pc.Skills.Religion.Mod == 1);
        Debug.Assert(pc.Skills.Religion.Proficiency == false);
        Debug.Assert(pc.Skills.Performance.Mod == 2);
        Debug.Assert(pc.Skills.Performance.Proficiency == false);
        Debug.Assert(pc.Skills.Deception.Mod == 4);
        Debug.Assert(pc.Skills.Deception.Proficiency == true);
        Debug.Assert(pc.Skills.Survival.Mod == -1);
        Debug.Assert(pc.Skills.Survival.Proficiency == false);

        Debug.Assert(pc.Weapons[0].ID == Library.Equipments.shortsword);
        Debug.Assert(pc.Weapons[0].MeleeAttackModifier == (pc.Level < 4 ? 6 : 7));
        Debug.Assert(pc.Weapons[0].MeleeDamage.Value.DiceCount == null);
        Debug.Assert(pc.Weapons[0].MeleeDamage.Value.Dice == 6);
        Debug.Assert(pc.Weapons[0].MeleeDamage.Value.Modifier == (pc.Level < 4 ? 4 : 5));
        Debug.Assert(pc.Weapons[0].MeleeDamage.Value.Type == DamageType.Piercing);
        Debug.Assert(pc.Weapons[0].Proficiency == true);
        Debug.Assert(pc.Weapons[0].ProficiencyBonus == 2);
        Debug.Assert(pc.Weapons[1].ID == Library.Equipments.shortbow);
        Debug.Assert(pc.Weapons[1].RangeAttackModifier == (pc.Level < 4 ? 6 : 7));
        Debug.Assert(pc.Weapons[1].RangeDamage.Value.DiceCount == null);
        Debug.Assert(pc.Weapons[1].RangeDamage.Value.Dice == 6);
        Debug.Assert(pc.Weapons[1].RangeDamage.Value.Modifier == (pc.Level < 4 ? 4 : 5));
        Debug.Assert(pc.Weapons[1].RangeDamage.Value.Type == DamageType.Piercing);
        Debug.Assert(pc.Weapons[1].Proficiency == true);
        Debug.Assert(pc.Weapons[1].ProficiencyBonus == 2);
        Debug.Assert(pc.Weapons[2].ID == Library.Equipments.dagger);
        Debug.Assert(pc.Weapons[2].MeleeAttackModifier == (pc.Level < 4 ? 6 : 7));
        Debug.Assert(pc.Weapons[2].MeleeDamage.Value.DiceCount == null);
        Debug.Assert(pc.Weapons[2].MeleeDamage.Value.Dice == 4);
        Debug.Assert(pc.Weapons[2].MeleeDamage.Value.Modifier == (pc.Level < 4 ? 4 : 5));
        Debug.Assert(pc.Weapons[2].MeleeDamage.Value.Type == DamageType.Piercing);
        Debug.Assert(pc.Weapons[2].RangeAttackModifier == (pc.Level < 4 ? 6 : 7));
        Debug.Assert(pc.Weapons[2].RangeDamage.Value.DiceCount == null);
        Debug.Assert(pc.Weapons[2].RangeDamage.Value.Dice == 4);
        Debug.Assert(pc.Weapons[2].RangeDamage.Value.Modifier == (pc.Level < 4 ? 4 : 5));
        Debug.Assert(pc.Weapons[2].RangeDamage.Value.Type == DamageType.Piercing);
        Debug.Assert(pc.Weapons[2].Proficiency == true);
        Debug.Assert(pc.Weapons[2].ProficiencyBonus == 2);
        Debug.Assert(pc.Weapons.Count == 3);

        Debug.Assert(pc.SpellRefs.Count == 0);
    }

    void TestURhingannUpLevel(PlayerCharacter pc)
    {
        pc.PrimaryClass.UpLevel();
        if (pc.Level == 4)
        {
            pc.PrimaryClass.SelectedFeatures.Add(pc.Factory.CreateFeature(id: Library.Features.amelioration_de_caracteristique_wisdom));
            pc.PrimaryClass.SelectedFeatures.Add(pc.Factory.CreateFeature(id: Library.Features.amelioration_de_caracteristique_wisdom));
        }
    }
    void TestURhingann(PlayerCharacter pc)
    {
        //var storage = Ioc.Default.GetRequiredService<DataService>();
        //var pc = storage.PlayerCharacters["rhingann"];

        Debug.Assert(pc.CharacterName == "Rhingann");

        Debug.Assert(pc.ProficiencyBonus == 2);
        Debug.Assert(pc.PassiveWisdom == (pc.Level < 4 ? 14 : 15));
        Debug.Assert(pc.ArmorClass == 14);
        Debug.Assert(pc.Initiative == 0);
        Debug.Assert(pc.MeleeAttackBonus == 4);
        Debug.Assert(pc.RangedAttackBonus == 2);
        Debug.Assert(pc.SpellAttackBonus == (pc.Level < 4 ? 6 : 7));
        Debug.Assert(pc.SpellSaveDC == (pc.Level < 4 ? 14 : 15));
        Debug.Assert(pc.TotalCurrentHitPoints == 8 + 5 * pc.Level);
        Debug.Assert(pc.HitDice == 8);

        Debug.Assert(pc.Abilities.Strength.Score == 14);
        Debug.Assert(pc.Abilities.Strength.Mod == 2);
        Debug.Assert(pc.Abilities.Strength.Save == 2);
        Debug.Assert(pc.Abilities.Strength.SaveProficiency == false);
        Debug.Assert(pc.Abilities.Dexterity.Score == 10);
        Debug.Assert(pc.Abilities.Dexterity.Mod == 0);
        Debug.Assert(pc.Abilities.Dexterity.Save == 0);
        Debug.Assert(pc.Abilities.Dexterity.SaveProficiency == false);
        Debug.Assert(pc.Abilities.Constitution.Score == 18);
        Debug.Assert(pc.Abilities.Constitution.Mod == 4);
        Debug.Assert(pc.Abilities.Constitution.Save == 4);
        Debug.Assert(pc.Abilities.Constitution.SaveProficiency == false);
        Debug.Assert(pc.Abilities.Intelligence.Score == 10);
        Debug.Assert(pc.Abilities.Intelligence.Mod == 0);
        Debug.Assert(pc.Abilities.Intelligence.Save == 0);
        Debug.Assert(pc.Abilities.Intelligence.SaveProficiency == false);
        Debug.Assert(pc.Abilities.Wisdom.Score == (pc.Level < 4 ? 18 : 20));
        Debug.Assert(pc.Abilities.Wisdom.Mod == (pc.Level < 4 ? 4 : 5));
        Debug.Assert(pc.Abilities.Wisdom.Save == (pc.Level < 4 ? 6 : 7));
        Debug.Assert(pc.Abilities.Wisdom.SaveProficiency == true);
        Debug.Assert(pc.Abilities.Charisma.Score == 11);
        Debug.Assert(pc.Abilities.Charisma.Mod == 0);
        Debug.Assert(pc.Abilities.Charisma.Save == 2);
        Debug.Assert(pc.Abilities.Charisma.SaveProficiency == true);

        Debug.Assert(pc.Skills.Acrobatics.Mod == 0);
        Debug.Assert(pc.Skills.Acrobatics.Proficiency == false);
        Debug.Assert(pc.Skills.Arcana.Mod == 0);
        Debug.Assert(pc.Skills.Arcana.Proficiency == false);
        Debug.Assert(pc.Skills.Athletics.Mod == 2);
        Debug.Assert(pc.Skills.Athletics.Proficiency == false);
        Debug.Assert(pc.Skills.Stealth.Mod == 0);
        Debug.Assert(pc.Skills.Stealth.Proficiency == false);
        Debug.Assert(pc.Skills.AnimalHandling.Mod == (pc.Level < 4 ? 4 : 5));
        Debug.Assert(pc.Skills.AnimalHandling.Proficiency == false);
        Debug.Assert(pc.Skills.SleightOfHand.Mod == 0);
        Debug.Assert(pc.Skills.SleightOfHand.Proficiency == false);
        Debug.Assert(pc.Skills.History.Mod == 0);
        Debug.Assert(pc.Skills.History.Proficiency == false);
        Debug.Assert(pc.Skills.Intimidation.Mod == 0);
        Debug.Assert(pc.Skills.Intimidation.Proficiency == false);
        Debug.Assert(pc.Skills.Investigation.Mod == 0);
        Debug.Assert(pc.Skills.Investigation.Proficiency == false);
        Debug.Assert(pc.Skills.Medicine.Mod == (pc.Level < 4 ? 8 : 9));
        Debug.Assert(pc.Skills.Medicine.Proficiency == true);
        Debug.Assert(pc.Skills.Nature.Mod == 0);
        Debug.Assert(pc.Skills.Nature.Proficiency == false);
        Debug.Assert(pc.Skills.Perception.Mod == (pc.Level < 4 ? 4 : 5));
        Debug.Assert(pc.Skills.Perception.Proficiency == false);
        Debug.Assert(pc.Skills.Insight.Mod == (pc.Level < 4 ? 6 : 7));
        Debug.Assert(pc.Skills.Insight.Proficiency == true);
        Debug.Assert(pc.Skills.Persuasion.Mod == 2);
        Debug.Assert(pc.Skills.Persuasion.Proficiency == true);
        Debug.Assert(pc.Skills.Religion.Mod == 2);
        Debug.Assert(pc.Skills.Religion.Proficiency == true);
        Debug.Assert(pc.Skills.Performance.Mod == 0);
        Debug.Assert(pc.Skills.Performance.Proficiency == false);
        Debug.Assert(pc.Skills.Deception.Mod == 0);
        Debug.Assert(pc.Skills.Deception.Proficiency == false);
        Debug.Assert(pc.Skills.Survival.Mod == (pc.Level < 4 ? 4 : 5));
        Debug.Assert(pc.Skills.Survival.Proficiency == false);

        Debug.Assert(pc.Weapons[0].ID == Library.Equipments.warhammer);
        Debug.Assert(pc.Weapons[0].MeleeAttackModifier == 4);
        Debug.Assert(pc.Weapons[0].MeleeDamage.Value.DiceCount == null);
        Debug.Assert(pc.Weapons[0].MeleeDamage.Value.Dice == 8);
        Debug.Assert(pc.Weapons[0].MeleeDamage.Value.Modifier == 2);
        Debug.Assert(pc.Weapons[0].MeleeDamage.Value.Type == DamageType.Bludgeoning);
        Debug.Assert(pc.Weapons[0].Proficiency == true);
        Debug.Assert(pc.Weapons[0].ProficiencyBonus == 2);
        Debug.Assert(pc.Weapons.Count == 1);

        //Debug.Assert(pc.SpellRefs[0].ID == Library.Spells.assistance);
        //Debug.Assert(pc.SpellRefs[0].AlwaysPrepared == false);
        //Debug.Assert(pc.SpellRefs[0].IsKnown == true);
        //Debug.Assert(pc.SpellRefs[1].ID == Library.Spells.flamme_sacree);
        //Debug.Assert(pc.SpellRefs[1].AlwaysPrepared == false);
        //Debug.Assert(pc.SpellRefs[1].IsKnown == true);
        //Debug.Assert(pc.SpellRefs[2].ID == Library.Spells.lumiere);
        //Debug.Assert(pc.SpellRefs[2].AlwaysPrepared == false);
        //Debug.Assert(pc.SpellRefs[2].IsKnown == true);
        //Debug.Assert(pc.SpellRefs[3].ID == Library.Spells.reparation);
        //Debug.Assert(pc.SpellRefs[3].AlwaysPrepared == false);
        //Debug.Assert(pc.SpellRefs[3].IsKnown == false);
        //Debug.Assert(pc.SpellRefs[4].ID == Library.Spells.benediction);
        //Debug.Assert(pc.SpellRefs[4].AlwaysPrepared == false);
        //Debug.Assert(pc.SpellRefs[4].IsKnown == true);
        //Debug.Assert(pc.SpellRefs[5].ID == Library.Spells.blessure);
        //Debug.Assert(pc.SpellRefs[5].AlwaysPrepared == false);
        //Debug.Assert(pc.SpellRefs[5].IsKnown == true);
        ////Debug.Assert(pc.SpellRefs[0].ID == "bouclier-de-la-foi");//
        //Debug.Assert(pc.SpellRefs[6].ID == Library.Spells.detection_de_la_magie);
        //Debug.Assert(pc.SpellRefs[6].AlwaysPrepared == false);
        //Debug.Assert(pc.SpellRefs[6].IsKnown == true);
        //Debug.Assert(pc.SpellRefs[7].ID == Library.Spells.fleau);
        //Debug.Assert(pc.SpellRefs[7].AlwaysPrepared == false);
        //Debug.Assert(pc.SpellRefs[7].IsKnown == true);
        //Debug.Assert(pc.SpellRefs[8].ID == Library.Spells.injonction);
        //Debug.Assert(pc.SpellRefs[8].AlwaysPrepared == false);
        //Debug.Assert(pc.SpellRefs[8].IsKnown == true);
        //Debug.Assert(pc.SpellRefs[9].ID == Library.Spells.mot_de_guerison);
        //Debug.Assert(pc.SpellRefs[9].AlwaysPrepared == false);
        //Debug.Assert(pc.SpellRefs[9].IsKnown == true);
        //Debug.Assert(pc.SpellRefs[10].ID == Library.Spells.sanctuaire);
        //Debug.Assert(pc.SpellRefs[10].AlwaysPrepared == false);
        //Debug.Assert(pc.SpellRefs[10].IsKnown == true);
        //Debug.Assert(pc.SpellRefs[11].ID == Library.Spells.soin_des_blessures);
        //Debug.Assert(pc.SpellRefs[11].AlwaysPrepared == true);
        //Debug.Assert(pc.SpellRefs[11].IsKnown == true);

        //if (pc.Level >= 3)
        //{
        //    Debug.Assert(pc.SpellRefs[12].ID == Library.Spells.aide);
        //    Debug.Assert(pc.SpellRefs[12].AlwaysPrepared == false);
        //    Debug.Assert(pc.SpellRefs[12].IsKnown == true);
        //    Debug.Assert(pc.SpellRefs[13].ID == Library.Spells.arme_spirituelle);
        //    Debug.Assert(pc.SpellRefs[13].AlwaysPrepared == false);
        //    Debug.Assert(pc.SpellRefs[13].IsKnown == true);
        //    Debug.Assert(pc.SpellRefs[14].ID == Library.Spells.augure);
        //    Debug.Assert(pc.SpellRefs[14].AlwaysPrepared == false);
        //    Debug.Assert(pc.SpellRefs[14].IsKnown == true);
        //    Debug.Assert(pc.SpellRefs[15].ID == Library.Spells.cecite_surdite);
        //    Debug.Assert(pc.SpellRefs[15].AlwaysPrepared == false);
        //    Debug.Assert(pc.SpellRefs[15].IsKnown == true);
        //    Debug.Assert(pc.SpellRefs[16].ID == Library.Spells.immobiliser_un_humanoide);
        //    Debug.Assert(pc.SpellRefs[16].AlwaysPrepared == false);
        //    Debug.Assert(pc.SpellRefs[16].IsKnown == true);
        //    Debug.Assert(pc.SpellRefs[17].ID == Library.Spells.priere_de_soins);
        //    Debug.Assert(pc.SpellRefs[17].AlwaysPrepared == false);
        //    Debug.Assert(pc.SpellRefs[17].IsKnown == true);
        //    Debug.Assert(pc.SpellRefs[18].ID == Library.Spells.restauration_inferieure);
        //    Debug.Assert(pc.SpellRefs[18].AlwaysPrepared == true);
        //    Debug.Assert(pc.SpellRefs[18].IsKnown == true);
        //    Debug.Assert(pc.SpellRefs[19].ID == Library.Spells.silence);
        //    Debug.Assert(pc.SpellRefs[19].AlwaysPrepared == false);
        //    Debug.Assert(pc.SpellRefs[19].IsKnown == true);
        //}
        //Debug.Assert(pc.SpellRefs.Count == (pc.Level < 3 ? 12 : 20));
    }

    void TestUIlzaachUpLevel(PlayerCharacter pc)
    {
        pc.PrimaryClass.UpLevel();
        if (pc.Level == 4)
        {
            pc.PrimaryClass.SelectedFeatures.Add(pc.Factory.CreateFeature(id: Library.Features.amelioration_de_caracteristique_strength));
        }
    }
    void TestUIlzaach(PlayerCharacter pc)
    {
        //var storage = Ioc.Default.GetRequiredService<DataService>();
        //var pc = storage.PlayerCharacters["ilzaach"];

        Debug.Assert(pc.CharacterName == "Ilzaach");

        Debug.Assert(pc.ProficiencyBonus == 2);
        Debug.Assert(pc.PassiveWisdom == 9);
        Debug.Assert(pc.ArmorClass == 17);
        Debug.Assert(pc.Initiative == 0);
        Debug.Assert(pc.MeleeAttackBonus == (pc.Level < 4 ? 6 : 7));
        Debug.Assert(pc.RangedAttackBonus == 2);
        Debug.Assert(pc.SpellAttackBonus == 4);
        Debug.Assert(pc.SpellSaveDC == 12);
        Debug.Assert(pc.TotalCurrentHitPoints == 10 + 2 + 2 * pc.Level);
        Debug.Assert(pc.HitDice == 10);

        Debug.Assert(pc.Abilities.Strength.Score == (pc.Level < 4 ? 19 : 20));
        Debug.Assert(pc.Abilities.Strength.Mod == (pc.Level < 4 ? 4 : 5));
        Debug.Assert(pc.Abilities.Strength.Save == (pc.Level < 4 ? 4 : 5));
        Debug.Assert(pc.Abilities.Strength.SaveProficiency == false);
        Debug.Assert(pc.Abilities.Dexterity.Score == 10);
        Debug.Assert(pc.Abilities.Dexterity.Mod == 0);
        Debug.Assert(pc.Abilities.Dexterity.Save == 0);
        Debug.Assert(pc.Abilities.Dexterity.SaveProficiency == false);
        Debug.Assert(pc.Abilities.Constitution.Score == 15);
        Debug.Assert(pc.Abilities.Constitution.Mod == 2);
        Debug.Assert(pc.Abilities.Constitution.Save == 2);
        Debug.Assert(pc.Abilities.Constitution.SaveProficiency == false);
        Debug.Assert(pc.Abilities.Intelligence.Score == 11);
        Debug.Assert(pc.Abilities.Intelligence.Mod == 0);
        Debug.Assert(pc.Abilities.Intelligence.Save == 0);
        Debug.Assert(pc.Abilities.Intelligence.SaveProficiency == false);
        Debug.Assert(pc.Abilities.Wisdom.Score == 8);
        Debug.Assert(pc.Abilities.Wisdom.Mod == -1);
        Debug.Assert(pc.Abilities.Wisdom.Save == 1);
        Debug.Assert(pc.Abilities.Wisdom.SaveProficiency == true);
        Debug.Assert(pc.Abilities.Charisma.Score == 15);
        Debug.Assert(pc.Abilities.Charisma.Mod == 2);
        Debug.Assert(pc.Abilities.Charisma.Save == 4);
        Debug.Assert(pc.Abilities.Charisma.SaveProficiency == true);

        Debug.Assert(pc.Skills.Acrobatics.Mod == 0);
        Debug.Assert(pc.Skills.Acrobatics.Proficiency == false);
        Debug.Assert(pc.Skills.Arcana.Mod == 0);
        Debug.Assert(pc.Skills.Arcana.Proficiency == false);
        Debug.Assert(pc.Skills.Athletics.Mod == (pc.Level < 4 ? 6 : 7));
        Debug.Assert(pc.Skills.Athletics.Proficiency == true);
        Debug.Assert(pc.Skills.Stealth.Mod == 0);
        Debug.Assert(pc.Skills.Stealth.Proficiency == false);
        Debug.Assert(pc.Skills.AnimalHandling.Mod == -1);
        Debug.Assert(pc.Skills.AnimalHandling.Proficiency == false);
        Debug.Assert(pc.Skills.SleightOfHand.Mod == 2);
        Debug.Assert(pc.Skills.SleightOfHand.Proficiency == true);
        Debug.Assert(pc.Skills.History.Mod == 0);
        Debug.Assert(pc.Skills.History.Proficiency == false);
        Debug.Assert(pc.Skills.Intimidation.Mod == 4);
        Debug.Assert(pc.Skills.Intimidation.Proficiency == true);
        Debug.Assert(pc.Skills.Investigation.Mod == 0);
        Debug.Assert(pc.Skills.Investigation.Proficiency == false);
        Debug.Assert(pc.Skills.Medicine.Mod == -1);
        Debug.Assert(pc.Skills.Medicine.Proficiency == false);
        Debug.Assert(pc.Skills.Nature.Mod == 0);
        Debug.Assert(pc.Skills.Nature.Proficiency == false);
        Debug.Assert(pc.Skills.Perception.Mod == -1);
        Debug.Assert(pc.Skills.Perception.Proficiency == false);
        Debug.Assert(pc.Skills.Insight.Mod == -1);
        Debug.Assert(pc.Skills.Insight.Proficiency == false);
        Debug.Assert(pc.Skills.Persuasion.Mod == 4);
        Debug.Assert(pc.Skills.Persuasion.Proficiency == true);
        Debug.Assert(pc.Skills.Religion.Mod == 0);
        Debug.Assert(pc.Skills.Religion.Proficiency == false);
        Debug.Assert(pc.Skills.Performance.Mod == 2);
        Debug.Assert(pc.Skills.Performance.Proficiency == false);
        Debug.Assert(pc.Skills.Deception.Mod == 2);
        Debug.Assert(pc.Skills.Deception.Proficiency == false);
        Debug.Assert(pc.Skills.Survival.Mod == -1);
        Debug.Assert(pc.Skills.Survival.Proficiency == false);

        Debug.Assert(pc.Weapons[0].ID == Library.Equipments.halberd);
        Debug.Assert(pc.Weapons[0].MeleeAttackModifier == (pc.Level < 4 ? 6 : 7));
        Debug.Assert(pc.Weapons[0].TwoHandledMeleeDamage.Value.DiceCount == null);
        Debug.Assert(pc.Weapons[0].TwoHandledMeleeDamage.Value.Dice == 10);
        Debug.Assert(pc.Weapons[0].TwoHandledMeleeDamage.Value.Modifier == (pc.Level < 4 ? 4 : 5));
        Debug.Assert(pc.Weapons[0].TwoHandledMeleeDamage.Value.Type == DamageType.Slashing);
        Debug.Assert(pc.Weapons[0].Proficiency == true);
        Debug.Assert(pc.Weapons[0].ProficiencyBonus == 2);
        Debug.Assert(pc.Weapons[1].ID == Library.Equipments.trident);
        Debug.Assert(pc.Weapons[1].MeleeAttackModifier == (pc.Level < 4 ? 6 : 7));
        Debug.Assert(pc.Weapons[1].MeleeDamage.Value.DiceCount == null);
        Debug.Assert(pc.Weapons[1].MeleeDamage.Value.Dice == 6);
        Debug.Assert(pc.Weapons[1].MeleeDamage.Value.Modifier == (pc.Level < 4 ? 4 : 5));
        Debug.Assert(pc.Weapons[1].MeleeDamage.Value.Type == DamageType.Piercing);
        Debug.Assert(pc.Weapons[1].RangeAttackModifier == (pc.Level < 4 ? 6 : 7));
        Debug.Assert(pc.Weapons[1].RangeDamage.Value.DiceCount == null);
        Debug.Assert(pc.Weapons[1].RangeDamage.Value.Dice == 6);
        Debug.Assert(pc.Weapons[1].RangeDamage.Value.Modifier == (pc.Level < 4 ? 4 : 5));
        Debug.Assert(pc.Weapons[1].RangeDamage.Value.Type == DamageType.Piercing);
        Debug.Assert(pc.Weapons[1].Proficiency == true);
        Debug.Assert(pc.Weapons[1].ProficiencyBonus == 2);
        Debug.Assert(pc.Weapons[2].ID == Library.Equipments.dagger);
        Debug.Assert(pc.Weapons[2].MeleeAttackModifier == (pc.Level < 4 ? 6 : 7));
        Debug.Assert(pc.Weapons[2].MeleeDamage.Value.DiceCount == null);
        Debug.Assert(pc.Weapons[2].MeleeDamage.Value.Dice == 4);
        Debug.Assert(pc.Weapons[2].MeleeDamage.Value.Modifier == (pc.Level < 4 ? 4 : 5));
        Debug.Assert(pc.Weapons[2].MeleeDamage.Value.Type == DamageType.Piercing);
        Debug.Assert(pc.Weapons[2].RangeAttackModifier == (pc.Level < 4 ? 6 : 7));
        Debug.Assert(pc.Weapons[2].RangeDamage.Value.DiceCount == null);
        Debug.Assert(pc.Weapons[2].RangeDamage.Value.Dice == 4);
        Debug.Assert(pc.Weapons[2].RangeDamage.Value.Modifier == (pc.Level < 4 ? 4 : 5));
        Debug.Assert(pc.Weapons[2].RangeDamage.Value.Type == DamageType.Piercing);
        Debug.Assert(pc.Weapons[2].Proficiency == true);
        Debug.Assert(pc.Weapons[2].ProficiencyBonus == 2);
        Debug.Assert(pc.Weapons.Count == 3);

        //Debug.Assert(pc.SpellRefs[0].ID == Library.Spells.bouclier_de_la_foi);
        //Debug.Assert(pc.SpellRefs[0].IsKnown == true);
        //Debug.Assert(pc.SpellRefs[1].ID == Library.Spells.brulure_du_juste);
        //Debug.Assert(pc.SpellRefs[1].IsKnown == true);
        //Debug.Assert(pc.SpellRefs[2].ID == Library.Spells.choc_des_titans);
        //Debug.Assert(pc.SpellRefs[2].IsKnown == true);
        //Debug.Assert(pc.SpellRefs[3].ID == Library.Spells.detection_de_la_magie);
        //Debug.Assert(pc.SpellRefs[3].IsKnown == true);
        //Debug.Assert(pc.SpellRefs[4].ID == Library.Spells.faveur_divine);
        //Debug.Assert(pc.SpellRefs[4].IsKnown == true);
        //Debug.Assert(pc.SpellRefs[5].ID == Library.Spells.heroisme);
        //Debug.Assert(pc.SpellRefs[5].IsKnown == true);
        //Debug.Assert(pc.SpellRefs[6].ID == Library.Spells.soin_des_blessures); // "soinS des blessures" à remonter en errata
        //Debug.Assert(pc.SpellRefs[6].IsKnown == true);
        //Debug.Assert(pc.SpellRefs.Count == 7);
        //Debug.Assert(pc.SpellRefs.Any(spell => spell.AlwaysPrepared) == false);


        //Debug.Assert(pc.AllAvailableClassFeatures.Any(feat => feat.Datum.Choices == null));
        //Debug.Assert(pc.AllAvailableClassFeatures.Any(feat => feat.Datum.Choices == null));
    }

    void TestULeowenUpLevel(PlayerCharacter pc)
    {
        pc.PrimaryClass.UpLevel();
        if(pc.Level == 3)
        {
            //pc.PrimaryClass.ArchetypeIDs.Add(Library.Archetypes.archer_arcanique);
        }
        if (pc.Level == 4)
        {
            pc.PrimaryClass.SelectedFeatures.Add(pc.Factory.CreateFeature(id: Library.Features.amelioration_de_caracteristique_dexterity));
            pc.PrimaryClass.SelectedFeatures.Add(pc.Factory.CreateFeature(id: Library.Features.amelioration_de_caracteristique_dexterity));
        }
    }
    void TestULeowen(PlayerCharacter pc)
    {
        //var storage = Ioc.Default.GetRequiredService<DataService>();
        //var pc = storage.PlayerCharacters["leowen"];

        Debug.Assert(pc.CharacterName == "Leowen");

        Debug.Assert(pc.ProficiencyBonus == 2);
        Debug.Assert(pc.PassiveWisdom == 12);
        Debug.Assert(pc.ArmorClass == (pc.Level < 4 ? 15 : 16));
        Debug.Assert(pc.Initiative == (pc.Level < 4 ? 3 : 4));
        Debug.Assert(pc.MeleeAttackBonus == 3);
        Debug.Assert(pc.RangedAttackBonus == (pc.Level < 4 ? 5 : 6));
        Debug.Assert(pc.SpellAttackBonus == 4);
        Debug.Assert(pc.SpellSaveDC == 12);
        Debug.Assert(pc.TotalCurrentHitPoints == 10 + 9 + 2 * pc.Level);
        Debug.Assert(pc.HitDice == 10);

        Debug.Assert(pc.Abilities.Strength.Score == 12);
        Debug.Assert(pc.Abilities.Strength.Mod == 1);
        Debug.Assert(pc.Abilities.Strength.Save == 3);
        Debug.Assert(pc.Abilities.Strength.SaveProficiency == true);
        Debug.Assert(pc.Abilities.Dexterity.Score == (pc.Level < 4 ? 17 : 19));
        Debug.Assert(pc.Abilities.Dexterity.Mod == (pc.Level < 4 ? 3 : 4));
        Debug.Assert(pc.Abilities.Dexterity.Save == (pc.Level < 4 ? 5 : 6));
        Debug.Assert(pc.Abilities.Dexterity.SaveProficiency == true);
        Debug.Assert(pc.Abilities.Constitution.Score == 14);
        Debug.Assert(pc.Abilities.Constitution.Mod == 2);
        Debug.Assert(pc.Abilities.Constitution.Save == 2);
        Debug.Assert(pc.Abilities.Constitution.SaveProficiency == false);
        Debug.Assert(pc.Abilities.Intelligence.Score == 11);
        Debug.Assert(pc.Abilities.Intelligence.Mod == 0);
        Debug.Assert(pc.Abilities.Intelligence.Save == 0);
        Debug.Assert(pc.Abilities.Intelligence.SaveProficiency == false);
        Debug.Assert(pc.Abilities.Wisdom.Score == 15);
        Debug.Assert(pc.Abilities.Wisdom.Mod == 2);
        Debug.Assert(pc.Abilities.Wisdom.Save == 2);
        Debug.Assert(pc.Abilities.Wisdom.SaveProficiency == false);
        Debug.Assert(pc.Abilities.Charisma.Score == 10);
        Debug.Assert(pc.Abilities.Charisma.Mod == 0);
        Debug.Assert(pc.Abilities.Charisma.Save == 0);
        Debug.Assert(pc.Abilities.Charisma.SaveProficiency == false);

        Debug.Assert(pc.Skills.Acrobatics.Mod == (pc.Level < 4 ? 3 : 4));
        Debug.Assert(pc.Skills.Acrobatics.Proficiency == false);
        Debug.Assert(pc.Skills.Arcana.Mod == 0);
        Debug.Assert(pc.Skills.Arcana.Proficiency == false);
        Debug.Assert(pc.Skills.Athletics.Mod == 3);
        Debug.Assert(pc.Skills.Athletics.Proficiency == true);
        Debug.Assert(pc.Skills.Stealth.Mod == (pc.Level < 4 ? 5 : 6));
        Debug.Assert(pc.Skills.Stealth.Proficiency == true);
        Debug.Assert(pc.Skills.AnimalHandling.Mod == 4);
        Debug.Assert(pc.Skills.AnimalHandling.Proficiency == true);
        Debug.Assert(pc.Skills.SleightOfHand.Mod == (pc.Level < 4 ? 3 : 4));
        Debug.Assert(pc.Skills.SleightOfHand.Proficiency == false);
        Debug.Assert(pc.Skills.History.Mod == 0);
        Debug.Assert(pc.Skills.History.Proficiency == false);  // TODO : problème avec leowen = sang bleu
        Debug.Assert(pc.Skills.Intimidation.Mod == 0);
        Debug.Assert(pc.Skills.Intimidation.Proficiency == false);
        Debug.Assert(pc.Skills.Investigation.Mod == 0);
        Debug.Assert(pc.Skills.Investigation.Proficiency == false);
        Debug.Assert(pc.Skills.Medicine.Mod == 2);
        Debug.Assert(pc.Skills.Medicine.Proficiency == false);
        Debug.Assert(pc.Skills.Nature.Mod == 0);
        Debug.Assert(pc.Skills.Nature.Proficiency == false);
        Debug.Assert(pc.Skills.Perception.Mod == 2);
        Debug.Assert(pc.Skills.Perception.Proficiency == false);
        Debug.Assert(pc.Skills.Insight.Mod == 4);
        Debug.Assert(pc.Skills.Insight.Proficiency == true);
        Debug.Assert(pc.Skills.Persuasion.Mod == 2);
        Debug.Assert(pc.Skills.Persuasion.Proficiency == true);
        Debug.Assert(pc.Skills.Religion.Mod == 0);
        Debug.Assert(pc.Skills.Religion.Proficiency == false);
        Debug.Assert(pc.Skills.Performance.Mod == 0);
        Debug.Assert(pc.Skills.Performance.Proficiency == false);
        Debug.Assert(pc.Skills.Deception.Mod == 0);
        Debug.Assert(pc.Skills.Deception.Proficiency == false);
        Debug.Assert(pc.Skills.Survival.Mod == 4);
        Debug.Assert(pc.Skills.Survival.Proficiency == true);

        Debug.Assert(pc.Weapons[0].ID == Library.Equipments.shortsword);
        Debug.Assert(pc.Weapons[0].MeleeAttackModifier == (pc.Level < 4 ? 5 : 6));
        Debug.Assert(pc.Weapons[0].MeleeDamage.Value.DiceCount == null);
        Debug.Assert(pc.Weapons[0].MeleeDamage.Value.Dice == 6);
        Debug.Assert(pc.Weapons[0].MeleeDamage.Value.Modifier == (pc.Level < 4 ? 3 : 4));
        Debug.Assert(pc.Weapons[0].MeleeDamage.Value.Type == DamageType.Piercing);
        Debug.Assert(pc.Weapons[0].Proficiency == true);
        Debug.Assert(pc.Weapons[0].ProficiencyBonus == 2);
        Debug.Assert(pc.Weapons[1].ID == Library.Equipments.dagger);
        Debug.Assert(pc.Weapons[1].MeleeAttackModifier == (pc.Level < 4 ? 5 : 6));
        Debug.Assert(pc.Weapons[1].MeleeDamage.Value.DiceCount == null);
        Debug.Assert(pc.Weapons[1].MeleeDamage.Value.Dice == 4);
        Debug.Assert(pc.Weapons[1].MeleeDamage.Value.Modifier == (pc.Level < 4 ? 3 : 4));
        Debug.Assert(pc.Weapons[1].MeleeDamage.Value.Type == DamageType.Piercing);
        Debug.Assert(pc.Weapons[1].RangeAttackModifier == (pc.Level < 4 ? 7 : 8));
        Debug.Assert(pc.Weapons[1].RangeDamage.Value.DiceCount == null);
        Debug.Assert(pc.Weapons[1].RangeDamage.Value.Dice == 4);
        Debug.Assert(pc.Weapons[1].RangeDamage.Value.Modifier == (pc.Level < 4 ? 3 : 4));
        Debug.Assert(pc.Weapons[1].RangeDamage.Value.Type == DamageType.Piercing);
        Debug.Assert(pc.Weapons[1].Proficiency == true);
        Debug.Assert(pc.Weapons[1].ProficiencyBonus == 2);
        Debug.Assert(pc.Weapons[2].ID == Library.Equipments.longbow);
        Debug.Assert(pc.Weapons[2].RangeAttackModifier == (pc.Level < 4 ? 7 : 8));
        Debug.Assert(pc.Weapons[2].RangeDamage.Value.DiceCount == null);
        Debug.Assert(pc.Weapons[2].RangeDamage.Value.Dice == 8);
        Debug.Assert(pc.Weapons[2].RangeDamage.Value.Modifier == (pc.Level < 4 ? 3 : 4));
        Debug.Assert(pc.Weapons[2].RangeDamage.Value.Type == DamageType.Piercing);
        Debug.Assert(pc.Weapons[2].Proficiency == true);
        Debug.Assert(pc.Weapons[2].ProficiencyBonus == 2);
        Debug.Assert(pc.Weapons.Count == 3);

        //Debug.Assert(pc.SpellRefs[0].ID == Library.Spells.amitie_avec_les_animaux);
        //Debug.Assert(pc.SpellRefs[0].IsKnown == true);
        //Debug.Assert(pc.SpellRefs[1].ID == Library.Spells.baies_nourricieres);
        //Debug.Assert(pc.SpellRefs[1].IsKnown == false);
        //Debug.Assert(pc.SpellRefs[2].ID == Library.Spells.grande_foulee);
        //Debug.Assert(pc.SpellRefs[2].IsKnown == false);
        //Debug.Assert(pc.SpellRefs[3].ID == Library.Spells.marque_du_chasseur);
        //Debug.Assert(pc.SpellRefs[3].IsKnown == true);
        //Debug.Assert(pc.SpellRefs[4].ID == Library.Spells.nappe_de_brouillard);
        //Debug.Assert(pc.SpellRefs[4].IsKnown == false);
        //Debug.Assert(pc.SpellRefs.Count == 5);
        //Debug.Assert(pc.SpellRefs.Any(spell => spell.AlwaysPrepared) == false);
    }

    void TestUDarknaUpLevel(PlayerCharacter pc)
    {
        pc.PrimaryClass.UpLevel();
        if(pc.Level == 2)
        {
            //pc.PrimaryClass.ArchetypeIDs.Add(Library.Archetypes.cercle_des_profondeurs);
        }
        if (pc.Level == 4)
        {
            pc.PrimaryClass.SelectedFeatures.Add(pc.Factory.CreateFeature(id: Library.Features.amelioration_de_caracteristique_wisdom));
            pc.PrimaryClass.SelectedFeatures.Add(pc.Factory.CreateFeature(id: Library.Features.amelioration_de_caracteristique_wisdom));
        }
    }
    void TestUDarkna(PlayerCharacter pc)
    {
        //var storage = Ioc.Default.GetRequiredService<DataService>();
        //var pc = storage.PlayerCharacters["darkna"];

        Debug.Assert(pc.CharacterName == "Darkna");

        Debug.Assert(pc.ProficiencyBonus == 2);
        Debug.Assert(pc.PassiveWisdom == (pc.Level < 4 ? 12 : 13));
        Debug.Assert(pc.ArmorClass == 13);
        Debug.Assert(pc.Initiative == 1);
        Debug.Assert(pc.MeleeAttackBonus == 4);
        Debug.Assert(pc.RangedAttackBonus == 3);
        Debug.Assert(pc.SpellAttackBonus == (pc.Level < 4 ? 4 : 5));
        Debug.Assert(pc.SpellSaveDC == (pc.Level < 4 ? 12 : 13)); // ajouter errata ?
        Debug.Assert(pc.TotalCurrentHitPoints == 8 + 5 + 1 * pc.Level);
        Debug.Assert(pc.HitDice == 8);

        Debug.Assert(pc.Abilities.Strength.Score == 14);
        Debug.Assert(pc.Abilities.Strength.Mod == 2);
        Debug.Assert(pc.Abilities.Strength.Save == 2);
        Debug.Assert(pc.Abilities.Strength.SaveProficiency == false);
        Debug.Assert(pc.Abilities.Dexterity.Score == 13);
        Debug.Assert(pc.Abilities.Dexterity.Mod == 1);
        Debug.Assert(pc.Abilities.Dexterity.Save == 1);
        Debug.Assert(pc.Abilities.Dexterity.SaveProficiency == false);
        Debug.Assert(pc.Abilities.Constitution.Score == 13);
        Debug.Assert(pc.Abilities.Constitution.Mod == 1);
        Debug.Assert(pc.Abilities.Constitution.Save == 1);
        Debug.Assert(pc.Abilities.Constitution.SaveProficiency == false);
        Debug.Assert(pc.Abilities.Intelligence.Score == 13);
        Debug.Assert(pc.Abilities.Intelligence.Mod == 1);
        Debug.Assert(pc.Abilities.Intelligence.Save == 3);
        Debug.Assert(pc.Abilities.Intelligence.SaveProficiency == true);
        Debug.Assert(pc.Abilities.Wisdom.Score == (pc.Level < 4 ? 14 : 16));
        Debug.Assert(pc.Abilities.Wisdom.Mod == (pc.Level < 4 ? 2 : 3));
        Debug.Assert(pc.Abilities.Wisdom.Save == (pc.Level < 4 ? 4 : 5));
        Debug.Assert(pc.Abilities.Wisdom.SaveProficiency == true);
        Debug.Assert(pc.Abilities.Charisma.Score == 11);
        Debug.Assert(pc.Abilities.Charisma.Mod == 0);
        Debug.Assert(pc.Abilities.Charisma.Save == 0);
        Debug.Assert(pc.Abilities.Charisma.SaveProficiency == false);

        Debug.Assert(pc.Skills.Acrobatics.Mod == 1);
        Debug.Assert(pc.Skills.Acrobatics.Proficiency == false);
        Debug.Assert(pc.Skills.Arcana.Mod == 3);
        Debug.Assert(pc.Skills.Arcana.Proficiency == true);
        Debug.Assert(pc.Skills.Athletics.Mod == 2);
        Debug.Assert(pc.Skills.Athletics.Proficiency == false);
        Debug.Assert(pc.Skills.Stealth.Mod == 1);
        Debug.Assert(pc.Skills.Stealth.Proficiency == false);
        Debug.Assert(pc.Skills.AnimalHandling.Mod == (pc.Level < 4 ? 4 : 5));
        Debug.Assert(pc.Skills.AnimalHandling.Proficiency == true);
        Debug.Assert(pc.Skills.SleightOfHand.Mod == 1);
        Debug.Assert(pc.Skills.SleightOfHand.Proficiency == false);
        Debug.Assert(pc.Skills.History.Mod == 1);
        Debug.Assert(pc.Skills.History.Proficiency == false);
        Debug.Assert(pc.Skills.Intimidation.Mod == 2);
        Debug.Assert(pc.Skills.Intimidation.Proficiency == true);
        Debug.Assert(pc.Skills.Investigation.Mod == 1);
        Debug.Assert(pc.Skills.Investigation.Proficiency == false);
        Debug.Assert(pc.Skills.Medicine.Mod == (pc.Level < 4 ? 4 : 5));
        Debug.Assert(pc.Skills.Medicine.Proficiency == true);
        Debug.Assert(pc.Skills.Nature.Mod == 1);
        Debug.Assert(pc.Skills.Nature.Proficiency == false);
        Debug.Assert(pc.Skills.Perception.Mod == (pc.Level < 4 ? 2 : 3));
        Debug.Assert(pc.Skills.Perception.Proficiency == false);
        Debug.Assert(pc.Skills.Insight.Mod == (pc.Level < 4 ? 2 : 3));
        Debug.Assert(pc.Skills.Insight.Proficiency == false);
        Debug.Assert(pc.Skills.Persuasion.Mod == 0);
        Debug.Assert(pc.Skills.Persuasion.Proficiency == false);
        Debug.Assert(pc.Skills.Religion.Mod == 1);
        Debug.Assert(pc.Skills.Religion.Proficiency == false);
        Debug.Assert(pc.Skills.Performance.Mod == 0);
        Debug.Assert(pc.Skills.Performance.Proficiency == false);
        Debug.Assert(pc.Skills.Deception.Mod == 0);
        Debug.Assert(pc.Skills.Deception.Proficiency == false);
        Debug.Assert(pc.Skills.Survival.Mod == (pc.Level < 4 ? 4 : 5));
        Debug.Assert(pc.Skills.Survival.Proficiency == true);

        Debug.Assert(pc.Weapons[0].ID == Library.Equipments.club);
        Debug.Assert(pc.Weapons[0].MeleeAttackModifier == 4);
        Debug.Assert(pc.Weapons[0].MeleeDamage.Value.DiceCount == null);
        Debug.Assert(pc.Weapons[0].MeleeDamage.Value.Dice == 6);
        Debug.Assert(pc.Weapons[0].MeleeDamage.Value.Modifier == 2);
        Debug.Assert(pc.Weapons[0].MeleeDamage.Value.Type == DamageType.Bludgeoning);
        Debug.Assert(pc.Weapons[0].Proficiency == true);
        Debug.Assert(pc.Weapons[0].ProficiencyBonus == 2);
        Debug.Assert(pc.Weapons[1].ID == Library.Equipments.scimitar);
        Debug.Assert(pc.Weapons[1].MeleeAttackModifier == 4);
        Debug.Assert(pc.Weapons[1].MeleeDamage.Value.DiceCount == null);
        Debug.Assert(pc.Weapons[1].MeleeDamage.Value.Dice == 6);
        Debug.Assert(pc.Weapons[1].MeleeDamage.Value.Modifier == 2);
        Debug.Assert(pc.Weapons[1].MeleeDamage.Value.Type == DamageType.Slashing);
        Debug.Assert(pc.Weapons[1].Proficiency == true);
        Debug.Assert(pc.Weapons[1].ProficiencyBonus == 2);
        Debug.Assert(pc.Weapons[2].ID == Library.Equipments.dagger);
        Debug.Assert(pc.Weapons[2].MeleeAttackModifier == 4);
        Debug.Assert(pc.Weapons[2].MeleeDamage.Value.DiceCount == null);
        Debug.Assert(pc.Weapons[2].MeleeDamage.Value.Dice == 4);
        Debug.Assert(pc.Weapons[2].MeleeDamage.Value.Modifier == 2);
        Debug.Assert(pc.Weapons[2].MeleeDamage.Value.Type == DamageType.Piercing);
        Debug.Assert(pc.Weapons[2].RangeAttackModifier == 4);
        Debug.Assert(pc.Weapons[2].RangeDamage.Value.DiceCount == null);
        Debug.Assert(pc.Weapons[2].RangeDamage.Value.Dice == 4);
        Debug.Assert(pc.Weapons[2].RangeDamage.Value.Modifier == 2);
        Debug.Assert(pc.Weapons[2].RangeDamage.Value.Type == DamageType.Piercing);
        Debug.Assert(pc.Weapons[2].Proficiency == true);
        Debug.Assert(pc.Weapons[2].ProficiencyBonus == 2);
        Debug.Assert(pc.Weapons[3].ID == Library.Equipments.javelin);
        Debug.Assert(pc.Weapons[3].MeleeAttackModifier == 4);
        Debug.Assert(pc.Weapons[3].MeleeDamage.Value.DiceCount == null);
        Debug.Assert(pc.Weapons[3].MeleeDamage.Value.Dice == 6);
        Debug.Assert(pc.Weapons[3].MeleeDamage.Value.Modifier == 2);
        Debug.Assert(pc.Weapons[3].MeleeDamage.Value.Type == DamageType.Piercing);
        Debug.Assert(pc.Weapons[3].RangeAttackModifier == 4);
        Debug.Assert(pc.Weapons[3].RangeDamage.Value.DiceCount == null);
        Debug.Assert(pc.Weapons[3].RangeDamage.Value.Dice == 6);
        Debug.Assert(pc.Weapons[3].RangeDamage.Value.Modifier == 2);
        Debug.Assert(pc.Weapons[3].RangeDamage.Value.Type == DamageType.Piercing);
        Debug.Assert(pc.Weapons[3].Proficiency == true);
        Debug.Assert(pc.Weapons[3].ProficiencyBonus == 2);
        Debug.Assert(pc.Weapons.Count == 4);

        //Debug.Assert(pc.SpellRefs[0].ID == Library.Spells.assistance);
        //Debug.Assert(pc.SpellRefs[0].IsKnown == true);
        //Debug.Assert(pc.SpellRefs[1].ID == Library.Spells.bouffee_de_poison);
        //Debug.Assert(pc.SpellRefs[1].IsKnown == false);
        //Debug.Assert(pc.SpellRefs[2].ID == Library.Spells.gourdin_magique);
        //Debug.Assert(pc.SpellRefs[2].IsKnown == true);
        //Debug.Assert(pc.SpellRefs[3].ID == Library.Spells.produire_une_flamme);
        //Debug.Assert(pc.SpellRefs[3].IsKnown == false);
        //Debug.Assert(pc.SpellRefs[4].ID == Library.Spells.amitie_avec_les_animaux);
        //Debug.Assert(pc.SpellRefs[4].IsKnown == true);
        //Debug.Assert(pc.SpellRefs[5].ID == Library.Spells.baies_nourricieres);
        //Debug.Assert(pc.SpellRefs[5].IsKnown == true);
        //Debug.Assert(pc.SpellRefs[6].ID == Library.Spells.charme_personne);
        //Debug.Assert(pc.SpellRefs[6].IsKnown == true);
        //Debug.Assert(pc.SpellRefs[7].ID == Library.Spells.detection_du_poison_et_des_maladies);
        //Debug.Assert(pc.SpellRefs[7].IsKnown == true);
        //Debug.Assert(pc.SpellRefs[8].ID == Library.Spells.enchevetrement);
        //Debug.Assert(pc.SpellRefs[8].IsKnown == true);
        //Debug.Assert(pc.SpellRefs[9].ID == Library.Spells.nappe_de_brouillard);
        //Debug.Assert(pc.SpellRefs[9].IsKnown == true);
        //Debug.Assert(pc.SpellRefs[10].ID == Library.Spells.purification_de_la_nourriture_et_de_l_eau);
        //Debug.Assert(pc.SpellRefs[10].IsKnown == true);
        //Debug.Assert(pc.SpellRefs[11].ID == Library.Spells.soin_des_blessures); // soinS à remonter en errata
        //Debug.Assert(pc.SpellRefs[11].IsKnown == true);
        //Debug.Assert(pc.SpellRefs[12].ID == Library.Spells.vague_tonnante);
        //Debug.Assert(pc.SpellRefs[12].IsKnown == true);

        //if (pc.Level >= 3)
        //{
        //    Debug.Assert(pc.SpellRefs[13].ID == Library.Spells.bourrasque);
        //    Debug.Assert(pc.SpellRefs[13].IsKnown == true);
        //    Debug.Assert(pc.SpellRefs[14].ID == Library.Spells.immobiliser_un_humanoide);
        //    Debug.Assert(pc.SpellRefs[14].IsKnown == true);
        //    Debug.Assert(pc.SpellRefs[15].ID == Library.Spells.lame_de_feu);
        //    Debug.Assert(pc.SpellRefs[15].IsKnown == true);
        //    Debug.Assert(pc.SpellRefs[16].ID == Library.Spells.messager_animal);
        //    Debug.Assert(pc.SpellRefs[16].IsKnown == true);
        //    Debug.Assert(pc.SpellRefs[17].ID == Library.Spells.passage_sans_traces);
        //    Debug.Assert(pc.SpellRefs[17].IsKnown == true);
        //    Debug.Assert(pc.SpellRefs[18].ID == Library.Spells.peau_d_ecorce);
        //    Debug.Assert(pc.SpellRefs[18].IsKnown == true);
        //    Debug.Assert(pc.SpellRefs[19].ID == Library.Spells.protection_contre_le_poison);
        //    Debug.Assert(pc.SpellRefs[19].IsKnown == true);
        //    Debug.Assert(pc.SpellRefs[20].ID == Library.Spells.rayon_de_lune);
        //    Debug.Assert(pc.SpellRefs[20].IsKnown == true);
        //    Debug.Assert(pc.SpellRefs[21].ID == Library.Spells.restauration_inferieure);
        //    Debug.Assert(pc.SpellRefs[21].IsKnown == true);
        //    Debug.Assert(pc.SpellRefs[22].ID == Library.Spells.sphere_de_feu);
        //    Debug.Assert(pc.SpellRefs[22].IsKnown == true);
        //}
        //Debug.Assert(pc.SpellRefs.Count == (pc.Level < 3 ? 13 : 23));
        //Debug.Assert(pc.SpellRefs.Any(spell => spell.AlwaysPrepared) == false);
    }

    void TestUOzyiasUpLevel(PlayerCharacter pc)
    {
        pc.PrimaryClass.UpLevel();
        if (pc.Level == 4)
        {
            pc.PrimaryClass.SelectedFeatures.Add(pc.Factory.CreateFeature(id: Library.Features.amelioration_de_caracteristique_strength));
            pc.PrimaryClass.SelectedFeatures.Add(pc.Factory.CreateFeature(id: Library.Features.amelioration_de_caracteristique_constitution));
        }
    }
    void TestUOzyias(PlayerCharacter pc)
    {
        //var storage = Ioc.Default.GetRequiredService<DataService>();
        //var pc = storage.PlayerCharacters["ozyias"];

        Debug.Assert(pc.CharacterName == "Ozyias");

        Debug.Assert(pc.ProficiencyBonus == 2);
        Debug.Assert(pc.PassiveWisdom == 12);
        Debug.Assert(pc.ArmorClass == 11);
        Debug.Assert(pc.Initiative == 1);
        Debug.Assert(pc.MeleeAttackBonus == (pc.Level < 4 ? 1 : 2));
        Debug.Assert(pc.RangedAttackBonus == 3);
        Debug.Assert(pc.SpellAttackBonus == 5);
        Debug.Assert(pc.SpellSaveDC == 13);
        if (pc.Level < 4)
        {
            Debug.Assert(pc.TotalCurrentHitPoints == 6 + 5 + 1 * pc.Level);
        }
        else
        {
            Debug.Assert(pc.TotalCurrentHitPoints == 6 + 5 + 2 * pc.Level);
        }
        Debug.Assert(pc.HitDice == 6);

        Debug.Assert(pc.Abilities.Strength.Score == (pc.Level < 4 ? 9 : 10));
        Debug.Assert(pc.Abilities.Strength.Mod == (pc.Level < 4 ? -1 : 0));
        Debug.Assert(pc.Abilities.Strength.Save == (pc.Level < 4 ? -1 : 0));
        Debug.Assert(pc.Abilities.Strength.SaveProficiency == false);
        Debug.Assert(pc.Abilities.Dexterity.Score == 13);
        Debug.Assert(pc.Abilities.Dexterity.Mod == 1);
        Debug.Assert(pc.Abilities.Dexterity.Save == 1);
        Debug.Assert(pc.Abilities.Dexterity.SaveProficiency == false);
        Debug.Assert(pc.Abilities.Constitution.Score == (pc.Level < 4 ? 13 : 14));
        Debug.Assert(pc.Abilities.Constitution.Mod == (pc.Level < 4 ? 1 : 2));
        Debug.Assert(pc.Abilities.Constitution.Save == (pc.Level < 4 ? 3 : 4));
        Debug.Assert(pc.Abilities.Constitution.SaveProficiency == true);
        Debug.Assert(pc.Abilities.Intelligence.Score == 12);
        Debug.Assert(pc.Abilities.Intelligence.Mod == 1);
        Debug.Assert(pc.Abilities.Intelligence.Save == 1);
        Debug.Assert(pc.Abilities.Intelligence.SaveProficiency == false);
        Debug.Assert(pc.Abilities.Wisdom.Score == 15);
        Debug.Assert(pc.Abilities.Wisdom.Mod == 2);
        Debug.Assert(pc.Abilities.Wisdom.Save == 2);
        Debug.Assert(pc.Abilities.Wisdom.SaveProficiency == false);
        Debug.Assert(pc.Abilities.Charisma.Score == 16);
        Debug.Assert(pc.Abilities.Charisma.Mod == 3);
        Debug.Assert(pc.Abilities.Charisma.Save == 5);
        Debug.Assert(pc.Abilities.Charisma.SaveProficiency == true);

        Debug.Assert(pc.Skills.Acrobatics.Mod == 1);
        Debug.Assert(pc.Skills.Acrobatics.Proficiency == false);
        Debug.Assert(pc.Skills.Arcana.Mod == 3);
        Debug.Assert(pc.Skills.Arcana.Proficiency == true);
        Debug.Assert(pc.Skills.Athletics.Mod == (pc.Level < 4 ? -1 : 0));
        Debug.Assert(pc.Skills.Athletics.Proficiency == false);
        Debug.Assert(pc.Skills.Stealth.Mod == 1);
        Debug.Assert(pc.Skills.Stealth.Proficiency == false);
        Debug.Assert(pc.Skills.AnimalHandling.Mod == 2);
        Debug.Assert(pc.Skills.AnimalHandling.Proficiency == false);
        Debug.Assert(pc.Skills.SleightOfHand.Mod == 1);
        Debug.Assert(pc.Skills.SleightOfHand.Proficiency == false);
        Debug.Assert(pc.Skills.History.Mod == 1);
        Debug.Assert(pc.Skills.History.Proficiency == false);
        Debug.Assert(pc.Skills.Intimidation.Mod == 3);
        Debug.Assert(pc.Skills.Intimidation.Proficiency == false);
        Debug.Assert(pc.Skills.Investigation.Mod == 1);
        Debug.Assert(pc.Skills.Investigation.Proficiency == false);
        Debug.Assert(pc.Skills.Medicine.Mod == 2);
        Debug.Assert(pc.Skills.Medicine.Proficiency == false);
        Debug.Assert(pc.Skills.Nature.Mod == 1);
        Debug.Assert(pc.Skills.Nature.Proficiency == false);
        Debug.Assert(pc.Skills.Perception.Mod == 2);
        Debug.Assert(pc.Skills.Perception.Proficiency == false);
        Debug.Assert(pc.Skills.Insight.Mod == 4);
        Debug.Assert(pc.Skills.Insight.Proficiency == true);
        Debug.Assert(pc.Skills.Persuasion.Mod == 5);
        Debug.Assert(pc.Skills.Persuasion.Proficiency == true);
        Debug.Assert(pc.Skills.Religion.Mod == 3);
        Debug.Assert(pc.Skills.Religion.Proficiency == true);
        Debug.Assert(pc.Skills.Performance.Mod == 3);
        Debug.Assert(pc.Skills.Performance.Proficiency == false);
        Debug.Assert(pc.Skills.Deception.Mod == 3);
        Debug.Assert(pc.Skills.Deception.Proficiency == false);
        Debug.Assert(pc.Skills.Survival.Mod == 2);
        Debug.Assert(pc.Skills.Survival.Proficiency == false);

        Debug.Assert(pc.Weapons[0].ID == Library.Equipments.dagger);
        Debug.Assert(pc.Weapons[0].MeleeAttackModifier == 3);
        Debug.Assert(pc.Weapons[0].MeleeDamage.Value.DiceCount == null);
        Debug.Assert(pc.Weapons[0].MeleeDamage.Value.Dice == 4);
        Debug.Assert(pc.Weapons[0].MeleeDamage.Value.Modifier == 1);
        Debug.Assert(pc.Weapons[0].MeleeDamage.Value.Type == DamageType.Piercing);
        Debug.Assert(pc.Weapons[0].RangeAttackModifier == 3);
        Debug.Assert(pc.Weapons[0].RangeDamage.Value.DiceCount == null);
        Debug.Assert(pc.Weapons[0].RangeDamage.Value.Dice == 4);
        Debug.Assert(pc.Weapons[0].RangeDamage.Value.Modifier == 1);
        Debug.Assert(pc.Weapons[0].RangeDamage.Value.Type == DamageType.Piercing);
        Debug.Assert(pc.Weapons[0].Proficiency == true);
        Debug.Assert(pc.Weapons[0].ProficiencyBonus == 2);
        Debug.Assert(pc.Weapons[1].ID == Library.Equipments.light_crossbow);
        Debug.Assert(pc.Weapons[1].RangeAttackModifier == 3);
        Debug.Assert(pc.Weapons[1].RangeDamage.Value.DiceCount == null);
        Debug.Assert(pc.Weapons[1].RangeDamage.Value.Dice == 8);
        Debug.Assert(pc.Weapons[1].RangeDamage.Value.Modifier == 1);
        Debug.Assert(pc.Weapons[1].RangeDamage.Value.Type == DamageType.Piercing);
        Debug.Assert(pc.Weapons[1].Proficiency == true);
        Debug.Assert(pc.Weapons[1].ProficiencyBonus == 2);
        Debug.Assert(pc.Weapons.Count == 2);

        //Debug.Assert(pc.SpellRefs[0].ID == Library.Spells.aura_du_heros);
        //Debug.Assert(pc.SpellRefs[0].IsKnown == false);
        ////Debug.Assert(pc.SpellRefs[1].ID == "bouffee-de-poison"); // à retirer
        //Debug.Assert(pc.SpellRefs[1].ID == Library.Spells.illusion_mineure); // illusion mineur sans e => errata
        //Debug.Assert(pc.SpellRefs[1].IsKnown == false);
        //Debug.Assert(pc.SpellRefs[2].ID == Library.Spells.lumieres_dansantes);
        //Debug.Assert(pc.SpellRefs[2].IsKnown == true);
        //Debug.Assert(pc.SpellRefs[3].ID == Library.Spells.main_du_mage);
        //Debug.Assert(pc.SpellRefs[3].IsKnown == true);
        //Debug.Assert(pc.SpellRefs[4].ID == Library.Spells.porte_bonheur);
        //Debug.Assert(pc.SpellRefs[4].IsKnown == false);
        //Debug.Assert(pc.SpellRefs[5].ID == Library.Spells.rayon_de_givre);
        //Debug.Assert(pc.SpellRefs[5].IsKnown == true);
        //Debug.Assert(pc.SpellRefs[6].ID == Library.Spells.trait_de_feu);
        //Debug.Assert(pc.SpellRefs[6].IsKnown == true);
        //Debug.Assert(pc.SpellRefs[7].ID == Library.Spells.armure_du_mage);
        //Debug.Assert(pc.SpellRefs[7].IsKnown == true);
        //Debug.Assert(pc.SpellRefs[8].ID == Library.Spells.charme_personne);
        //Debug.Assert(pc.SpellRefs[8].IsKnown == false);
        //Debug.Assert(pc.SpellRefs[9].ID == Library.Spells.comprehension_des_langues);
        //Debug.Assert(pc.SpellRefs[9].IsKnown == false);
        //Debug.Assert(pc.SpellRefs[10].ID == Library.Spells.couleurs_dansantes);
        //Debug.Assert(pc.SpellRefs[10].IsKnown == false);
        //Debug.Assert(pc.SpellRefs[11].ID == Library.Spells.detection_de_la_magie);
        //Debug.Assert(pc.SpellRefs[11].IsKnown == false);
        //Debug.Assert(pc.SpellRefs[12].ID == Library.Spells.geyser_d_energie);
        //Debug.Assert(pc.SpellRefs[12].IsKnown == false);
        //Debug.Assert(pc.SpellRefs[13].ID == Library.Spells.nappe_de_brouillard);
        //Debug.Assert(pc.SpellRefs[13].IsKnown == false);
        //Debug.Assert(pc.SpellRefs[14].ID == Library.Spells.projectile_magique);
        //Debug.Assert(pc.SpellRefs[14].IsKnown == true);
        //Debug.Assert(pc.SpellRefs[15].ID == Library.Spells.sommeil);
        //Debug.Assert(pc.SpellRefs[15].IsKnown == true);

        //if (pc.Level >= 3)
        //{
        //    Debug.Assert(pc.SpellRefs[16].ID == Library.Spells.cecite_surdite);
        //    Debug.Assert(pc.SpellRefs[16].IsKnown == false);
        //    Debug.Assert(pc.SpellRefs[17].ID == Library.Spells.flou);
        //    Debug.Assert(pc.SpellRefs[17].IsKnown == false);
        //    Debug.Assert(pc.SpellRefs[18].ID == Library.Spells.image_miroir);
        //    Debug.Assert(pc.SpellRefs[18].IsKnown == false);
        //    Debug.Assert(pc.SpellRefs[19].ID == Library.Spells.immobiliser_un_humanoide);
        //    Debug.Assert(pc.SpellRefs[19].IsKnown == false);
        //    Debug.Assert(pc.SpellRefs[20].ID == Library.Spells.invisibilite);
        //    Debug.Assert(pc.SpellRefs[20].IsKnown == false);
        //    Debug.Assert(pc.SpellRefs[21].ID == Library.Spells.levitation);
        //    Debug.Assert(pc.SpellRefs[21].IsKnown == false);
        //    Debug.Assert(pc.SpellRefs[22].ID == Library.Spells.pattes_d_araignee);
        //    Debug.Assert(pc.SpellRefs[22].IsKnown == false);
        //    Debug.Assert(pc.SpellRefs[23].ID == Library.Spells.rayon_ardent);
        //    Debug.Assert(pc.SpellRefs[23].IsKnown == false);
        //    Debug.Assert(pc.SpellRefs[24].ID == Library.Spells.stalagmites_fulgurantes);
        //    Debug.Assert(pc.SpellRefs[24].IsKnown == false);
        //    Debug.Assert(pc.SpellRefs[25].ID == Library.Spells.tenebres);
        //    Debug.Assert(pc.SpellRefs[25].IsKnown == false);
        //    Debug.Assert(pc.SpellRefs[26].ID == Library.Spells.toile_d_araignee);
        //    Debug.Assert(pc.SpellRefs[26].IsKnown == false);
        //}
        //Debug.Assert(pc.SpellRefs.Count == (pc.Level < 3 ? 16 : 27));
        //Debug.Assert(pc.SpellRefs.Any(spell => spell.AlwaysPrepared) == false);
    }

    void TestUGalefrinUpLevel(PlayerCharacter pc)
    {
        pc.PrimaryClass.UpLevel();
        if (pc.Level == 3)
        {
            //pc.PrimaryClass.ArchetypeIDs.Add(Library.Archetypes.shadowblade);
        }
        if (pc.Level == 4)
        {
            pc.PrimaryClass.SelectedFeatures.Add(pc.Factory.CreateFeature(id: Library.Features.amelioration_de_caracteristique_strength));
            pc.PrimaryClass.SelectedFeatures.Add(pc.Factory.CreateFeature(id: Library.Features.amelioration_de_caracteristique_constitution));
        }
    }
    void TestUGalefrin(PlayerCharacter pc)
    {
        //var storage = Ioc.Default.GetRequiredService<DataService>();
        //var pc = storage.PlayerCharacters["galefrin"];

        Debug.Assert(pc.CharacterName == "Galefrin");

        Debug.Assert(pc.ProficiencyBonus == 2);
        Debug.Assert(pc.PassiveWisdom == 12);
        Debug.Assert(pc.ArmorClass == 16);
        Debug.Assert(pc.Initiative == 4);
        Debug.Assert(pc.MeleeAttackBonus == (pc.Level < 4 ? 1 : 2));
        Debug.Assert(pc.RangedAttackBonus == 6);
        Debug.Assert(pc.SpellAttackBonus == null);
        Debug.Assert(pc.SpellSaveDC == null);
        if (pc.Level < 4)
        {
            Debug.Assert(pc.TotalCurrentHitPoints == 8 + 7 + 0 * pc.Level);
        }
        else
        {
            Debug.Assert(pc.TotalCurrentHitPoints == 8 + 7 + 1 * pc.Level);
        }
        Debug.Assert(pc.HitDice == 8);

        Debug.Assert(pc.Abilities.Strength.Score == (pc.Level < 4 ? 9 : 10));
        Debug.Assert(pc.Abilities.Strength.Mod == (pc.Level < 4 ? -1 : 0));
        Debug.Assert(pc.Abilities.Strength.Save == (pc.Level < 4 ? -1 : 0));
        Debug.Assert(pc.Abilities.Strength.SaveProficiency == false);
        Debug.Assert(pc.Abilities.Dexterity.Score == 18);
        Debug.Assert(pc.Abilities.Dexterity.Mod == 4);
        Debug.Assert(pc.Abilities.Dexterity.Save == 6);
        Debug.Assert(pc.Abilities.Dexterity.SaveProficiency == true);
        Debug.Assert(pc.Abilities.Constitution.Score == (pc.Level < 4 ? 11 : 12));
        Debug.Assert(pc.Abilities.Constitution.Mod == (pc.Level < 4 ? 0 : 1));
        Debug.Assert(pc.Abilities.Constitution.Save == (pc.Level < 4 ? 0 : 1));
        Debug.Assert(pc.Abilities.Constitution.SaveProficiency == false);
        Debug.Assert(pc.Abilities.Intelligence.Score == 12);
        Debug.Assert(pc.Abilities.Intelligence.Mod == 1);
        Debug.Assert(pc.Abilities.Intelligence.Save == 3);
        Debug.Assert(pc.Abilities.Intelligence.SaveProficiency == true);
        Debug.Assert(pc.Abilities.Wisdom.Score == 14);
        Debug.Assert(pc.Abilities.Wisdom.Mod == 2);
        Debug.Assert(pc.Abilities.Wisdom.Save == 2);
        Debug.Assert(pc.Abilities.Wisdom.SaveProficiency == false);
        Debug.Assert(pc.Abilities.Charisma.Score == 14);
        Debug.Assert(pc.Abilities.Charisma.Mod == 2);
        Debug.Assert(pc.Abilities.Charisma.Save == 2);
        Debug.Assert(pc.Abilities.Charisma.SaveProficiency == false);

        Debug.Assert(pc.Skills.Acrobatics.Mod == 4);
        Debug.Assert(pc.Skills.Acrobatics.Proficiency == false);
        Debug.Assert(pc.Skills.Arcana.Mod == 1);
        Debug.Assert(pc.Skills.Arcana.Proficiency == false);
        Debug.Assert(pc.Skills.Athletics.Mod == (pc.Level < 4 ? -1 : 0));
        Debug.Assert(pc.Skills.Athletics.Proficiency == false);
        Debug.Assert(pc.Skills.Stealth.Mod == 8);
        Debug.Assert(pc.Skills.Stealth.Proficiency == true);
        Debug.Assert(pc.Skills.AnimalHandling.Mod == 2);
        Debug.Assert(pc.Skills.AnimalHandling.Proficiency == false);
        Debug.Assert(pc.Skills.SleightOfHand.Mod == 6);
        Debug.Assert(pc.Skills.SleightOfHand.Proficiency == true);
        Debug.Assert(pc.Skills.History.Mod == 3);
        Debug.Assert(pc.Skills.History.Proficiency == true);
        Debug.Assert(pc.Skills.Intimidation.Mod == 2);
        Debug.Assert(pc.Skills.Intimidation.Proficiency == false);
        Debug.Assert(pc.Skills.Investigation.Mod == 1);
        Debug.Assert(pc.Skills.Investigation.Proficiency == false);
        Debug.Assert(pc.Skills.Medicine.Mod == 2);
        Debug.Assert(pc.Skills.Medicine.Proficiency == false);
        Debug.Assert(pc.Skills.Nature.Mod == 1);
        Debug.Assert(pc.Skills.Nature.Proficiency == false);
        Debug.Assert(pc.Skills.Perception.Mod == 2);
        Debug.Assert(pc.Skills.Perception.Proficiency == false);
        Debug.Assert(pc.Skills.Insight.Mod == 4);
        Debug.Assert(pc.Skills.Insight.Proficiency == true);
        Debug.Assert(pc.Skills.Persuasion.Mod == 2);
        Debug.Assert(pc.Skills.Persuasion.Proficiency == false);
        Debug.Assert(pc.Skills.Religion.Mod == 1);
        Debug.Assert(pc.Skills.Religion.Proficiency == false);
        Debug.Assert(pc.Skills.Performance.Mod == 2);
        Debug.Assert(pc.Skills.Performance.Proficiency == false);
        Debug.Assert(pc.Skills.Deception.Mod == 6);
        Debug.Assert(pc.Skills.Deception.Proficiency == true);
        Debug.Assert(pc.Skills.Survival.Mod == 4);
        Debug.Assert(pc.Skills.Survival.Proficiency == true);

        Debug.Assert(pc.Weapons[0].ID == Library.Equipments.dagger);
        Debug.Assert(pc.Weapons[0].MeleeAttackModifier == 6);
        Debug.Assert(pc.Weapons[0].MeleeDamage.Value.DiceCount == null);
        Debug.Assert(pc.Weapons[0].MeleeDamage.Value.Dice == 4);
        Debug.Assert(pc.Weapons[0].MeleeDamage.Value.Modifier == 4);
        Debug.Assert(pc.Weapons[0].MeleeDamage.Value.Type == DamageType.Piercing);
        Debug.Assert(pc.Weapons[0].RangeAttackModifier == 6);
        Debug.Assert(pc.Weapons[0].RangeDamage.Value.DiceCount == null);
        Debug.Assert(pc.Weapons[0].RangeDamage.Value.Dice == 4);
        Debug.Assert(pc.Weapons[0].RangeDamage.Value.Modifier == 4);
        Debug.Assert(pc.Weapons[0].RangeDamage.Value.Type == DamageType.Piercing);
        Debug.Assert(pc.Weapons[0].Proficiency == true);
        Debug.Assert(pc.Weapons[0].ProficiencyBonus == 2);
        Debug.Assert(pc.Weapons[1].ID == Library.Equipments.rapier);
        Debug.Assert(pc.Weapons[1].MeleeAttackModifier == 6);
        Debug.Assert(pc.Weapons[1].MeleeDamage.Value.DiceCount == null);
        Debug.Assert(pc.Weapons[1].MeleeDamage.Value.Dice == 8);
        Debug.Assert(pc.Weapons[1].MeleeDamage.Value.Modifier == 4);
        Debug.Assert(pc.Weapons[1].MeleeDamage.Value.Type == DamageType.Piercing);
        Debug.Assert(pc.Weapons[1].Proficiency == true);
        Debug.Assert(pc.Weapons[1].ProficiencyBonus == 2);
        Debug.Assert(pc.Weapons[2].ID == Library.Equipments.shortsword);
        Debug.Assert(pc.Weapons[2].MeleeAttackModifier == 6);
        Debug.Assert(pc.Weapons[2].MeleeDamage.Value.DiceCount == null);
        Debug.Assert(pc.Weapons[2].MeleeDamage.Value.Dice == 6);
        Debug.Assert(pc.Weapons[2].MeleeDamage.Value.Modifier == 4);
        Debug.Assert(pc.Weapons[2].MeleeDamage.Value.Type == DamageType.Piercing);
        Debug.Assert(pc.Weapons[2].Proficiency == true);
        Debug.Assert(pc.Weapons[2].ProficiencyBonus == 2);
        Debug.Assert(pc.Weapons[3].ID == Library.Equipments.hand_crossbow);
        Debug.Assert(pc.Weapons[3].RangeAttackModifier == 6);
        Debug.Assert(pc.Weapons[3].RangeDamage.Value.DiceCount == null);
        Debug.Assert(pc.Weapons[3].RangeDamage.Value.Dice == 6);
        Debug.Assert(pc.Weapons[3].RangeDamage.Value.Modifier == 4);
        Debug.Assert(pc.Weapons[3].RangeDamage.Value.Type == DamageType.Piercing);
        Debug.Assert(pc.Weapons[3].Proficiency == true);
        Debug.Assert(pc.Weapons[3].ProficiencyBonus == 2);
        Debug.Assert(pc.Weapons.Count == 4);

        //// TODO checker sorts ombrelame !!!!
        //if (pc.Level >= 3)
        //{
        //    Debug.Assert(pc.SpellRefs[0].ID == Library.Spells.main_du_mage);
        //    Debug.Assert(pc.SpellRefs[0].IsKnown == false);
        //    Debug.Assert(pc.SpellRefs[1].ID == Library.Spells.prestidigitation);
        //    Debug.Assert(pc.SpellRefs[1].IsKnown == false);
        //    Debug.Assert(pc.SpellRefs[2].ID == Library.Spells.graisse);
        //    Debug.Assert(pc.SpellRefs[2].IsKnown == false);
        //    Debug.Assert(pc.SpellRefs[3].ID == Library.Spells.poison_naturel);
        //    Debug.Assert(pc.SpellRefs[3].IsKnown == false);
        //    Debug.Assert(pc.SpellRefs[4].ID == Library.Spells.saut);
        //    Debug.Assert(pc.SpellRefs[4].IsKnown == false);
        //}
        //Debug.Assert(pc.SpellRefs.Count == (pc.Level < 3 ? 0 : 5));
        //Debug.Assert(pc.SpellRefs.Any(spell => spell.AlwaysPrepared) == false);
    }

    void TestUMalathorUpLevel(PlayerCharacter pc)
    {
        pc.PrimaryClass.UpLevel();
        if (pc.Level == 4)
        {
            pc.PrimaryClass.SelectedFeatures.Add(pc.Factory.CreateFeature(id: Library.Features.amelioration_de_caracteristique_strength));
            pc.PrimaryClass.SelectedFeatures.Add(pc.Factory.CreateFeature(id: Library.Features.amelioration_de_caracteristique_strength));
        }
    }
    void TestUMalathor(PlayerCharacter pc)
    {
        //var storage = Ioc.Default.GetRequiredService<DataService>();
        //var pc = storage.PlayerCharacters["malathor"];

        Debug.Assert(pc.CharacterName == "Malathor");

        Debug.Assert(pc.ProficiencyBonus == 2);
        Debug.Assert(pc.PassiveWisdom == 12);
        Debug.Assert(pc.ArmorClass == 19);
        Debug.Assert(pc.Initiative == 0);
        Debug.Assert(pc.MeleeAttackBonus == (pc.Level < 4 ? 6 : 7));
        Debug.Assert(pc.RangedAttackBonus == 2);
        Debug.Assert(pc.SpellAttackBonus == 5);
        Debug.Assert(pc.SpellSaveDC == 13);
        Debug.Assert(pc.TotalCurrentHitPoints == 10 + 5 + 2 * pc.Level);
        Debug.Assert(pc.HitDice == 10);

        Debug.Assert(pc.Abilities.Strength.Score == (pc.Level < 4 ? 18 : 20));
        Debug.Assert(pc.Abilities.Strength.Mod == (pc.Level < 4 ? 4 : 5));
        Debug.Assert(pc.Abilities.Strength.Save == (pc.Level < 4 ? 4 : 5));
        Debug.Assert(pc.Abilities.Strength.SaveProficiency == false);
        Debug.Assert(pc.Abilities.Dexterity.Score == 10);
        Debug.Assert(pc.Abilities.Dexterity.Mod == 0);
        Debug.Assert(pc.Abilities.Dexterity.Save == 0);
        Debug.Assert(pc.Abilities.Dexterity.SaveProficiency == false);
        Debug.Assert(pc.Abilities.Constitution.Score == 14);
        Debug.Assert(pc.Abilities.Constitution.Mod == 2);
        Debug.Assert(pc.Abilities.Constitution.Save == 2);
        Debug.Assert(pc.Abilities.Constitution.SaveProficiency == false);
        Debug.Assert(pc.Abilities.Intelligence.Score == 10);
        Debug.Assert(pc.Abilities.Intelligence.Mod == 0);
        Debug.Assert(pc.Abilities.Intelligence.Save == 0);
        Debug.Assert(pc.Abilities.Intelligence.SaveProficiency == false);
        Debug.Assert(pc.Abilities.Wisdom.Score == 14);
        Debug.Assert(pc.Abilities.Wisdom.Mod == 2);
        Debug.Assert(pc.Abilities.Wisdom.Save == 4);
        Debug.Assert(pc.Abilities.Wisdom.SaveProficiency == true);
        Debug.Assert(pc.Abilities.Charisma.Score == 17);
        Debug.Assert(pc.Abilities.Charisma.Mod == 3);
        Debug.Assert(pc.Abilities.Charisma.Save == 5);
        Debug.Assert(pc.Abilities.Charisma.SaveProficiency == true);

        Debug.Assert(pc.Skills.Acrobatics.Mod == 0);
        Debug.Assert(pc.Skills.Acrobatics.Proficiency == false);
        Debug.Assert(pc.Skills.Arcana.Mod == 0);
        Debug.Assert(pc.Skills.Arcana.Proficiency == false);
        Debug.Assert(pc.Skills.Athletics.Mod == (pc.Level < 4 ? 6 : 7));
        Debug.Assert(pc.Skills.Athletics.Proficiency == true);
        Debug.Assert(pc.Skills.Stealth.Mod == 0);
        Debug.Assert(pc.Skills.Stealth.Proficiency == false);
        Debug.Assert(pc.Skills.AnimalHandling.Mod == 2);
        Debug.Assert(pc.Skills.AnimalHandling.Proficiency == false);
        Debug.Assert(pc.Skills.SleightOfHand.Mod == 0);
        Debug.Assert(pc.Skills.SleightOfHand.Proficiency == false);
        Debug.Assert(pc.Skills.History.Mod == 0);
        Debug.Assert(pc.Skills.History.Proficiency == false);
        Debug.Assert(pc.Skills.Intimidation.Mod == 5);
        Debug.Assert(pc.Skills.Intimidation.Proficiency == true);
        Debug.Assert(pc.Skills.Investigation.Mod == 0);
        Debug.Assert(pc.Skills.Investigation.Proficiency == false);
        Debug.Assert(pc.Skills.Medicine.Mod == 2);
        Debug.Assert(pc.Skills.Medicine.Proficiency == false);
        Debug.Assert(pc.Skills.Nature.Mod == 0);
        Debug.Assert(pc.Skills.Nature.Proficiency == false);
        Debug.Assert(pc.Skills.Perception.Mod == 2);
        Debug.Assert(pc.Skills.Perception.Proficiency == false);
        Debug.Assert(pc.Skills.Insight.Mod == 4);
        Debug.Assert(pc.Skills.Insight.Proficiency == true);
        Debug.Assert(pc.Skills.Persuasion.Mod == 5);
        Debug.Assert(pc.Skills.Persuasion.Proficiency == true);
        Debug.Assert(pc.Skills.Religion.Mod == 0);
        Debug.Assert(pc.Skills.Religion.Proficiency == false);
        Debug.Assert(pc.Skills.Performance.Mod == 3);
        Debug.Assert(pc.Skills.Performance.Proficiency == false);
        Debug.Assert(pc.Skills.Deception.Mod == 3);
        Debug.Assert(pc.Skills.Deception.Proficiency == false);
        Debug.Assert(pc.Skills.Survival.Mod == 2);
        Debug.Assert(pc.Skills.Survival.Proficiency == false);

        Debug.Assert(pc.Weapons[0].ID == Library.Equipments.epee_ardente1);
        Debug.Assert(pc.Weapons[0].MeleeAttackModifier == (pc.Level < 4 ? 7 : 8));
        Debug.Assert(pc.Weapons[0].MeleeDamage.Value.DiceCount == null);
        Debug.Assert(pc.Weapons[0].MeleeDamage.Value.Dice == 8);
        Debug.Assert(pc.Weapons[0].MeleeDamage.Value.Modifier == (pc.Level < 4 ? 5 : 6));
        Debug.Assert(pc.Weapons[0].MeleeDamage.Value.Type == DamageType.Slashing);
        Debug.Assert(pc.Weapons[0].Proficiency == true);
        Debug.Assert(pc.Weapons[0].ProficiencyBonus == 2);
        Debug.Assert(pc.Weapons[1].ID == Library.Equipments.dagger);
        Debug.Assert(pc.Weapons[1].MeleeAttackModifier == (pc.Level < 4 ? 6 : 7));
        Debug.Assert(pc.Weapons[1].MeleeDamage.Value.DiceCount == null);
        Debug.Assert(pc.Weapons[1].MeleeDamage.Value.Dice == 4);
        Debug.Assert(pc.Weapons[1].MeleeDamage.Value.Modifier == (pc.Level < 4 ? 4 : 5));
        Debug.Assert(pc.Weapons[1].MeleeDamage.Value.Type == DamageType.Piercing);
        Debug.Assert(pc.Weapons[1].RangeAttackModifier == (pc.Level < 4 ? 6 : 7));
        Debug.Assert(pc.Weapons[1].RangeDamage.Value.DiceCount == null);
        Debug.Assert(pc.Weapons[1].RangeDamage.Value.Dice == 4);
        Debug.Assert(pc.Weapons[1].RangeDamage.Value.Modifier == (pc.Level < 4 ? 4 : 5));
        Debug.Assert(pc.Weapons[1].RangeDamage.Value.Type == DamageType.Piercing);
        Debug.Assert(pc.Weapons[1].Proficiency == true);
        Debug.Assert(pc.Weapons[1].ProficiencyBonus == 2);
        Debug.Assert(pc.Weapons.Count == 2);

        //Debug.Assert(pc.SpellRefs[0].ID == Library.Spells.bouclier_de_la_foi);
        //Debug.Assert(pc.SpellRefs[0].IsKnown == true);
        //Debug.Assert(pc.SpellRefs[1].ID == Library.Spells.brulure_du_juste);
        //Debug.Assert(pc.SpellRefs[1].IsKnown == true);
        //Debug.Assert(pc.SpellRefs[2].ID == Library.Spells.choc_des_titans);
        //Debug.Assert(pc.SpellRefs[2].IsKnown == true);
        //Debug.Assert(pc.SpellRefs[3].ID == Library.Spells.detection_de_la_magie);
        //Debug.Assert(pc.SpellRefs[3].IsKnown == true);
        //Debug.Assert(pc.SpellRefs[4].ID == Library.Spells.faveur_divine);
        //Debug.Assert(pc.SpellRefs[4].IsKnown == true);
        //Debug.Assert(pc.SpellRefs[5].ID == Library.Spells.heroisme);
        //Debug.Assert(pc.SpellRefs[5].IsKnown == true);
        //Debug.Assert(pc.SpellRefs[6].ID == Library.Spells.soin_des_blessures); // soinS à remonter en errata
        //Debug.Assert(pc.SpellRefs[6].IsKnown == true);
        //Debug.Assert(pc.SpellRefs.Count == 7);
        //Debug.Assert(pc.SpellRefs.Any(spell => spell.AlwaysPrepared) == false);
    }
}
