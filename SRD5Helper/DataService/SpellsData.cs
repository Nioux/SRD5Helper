using SRD5Helper.DataModels;
using Library = SRD5Helper.Resources.Library;
namespace SRD5Helper.Data;
public partial class DataService
{
    private IReadOnlyList<SpellDatum> _spellsData = new List<SpellDatum>
    {
        new()
        {
            ID = Library.Spells.acid_arrow,
            Level = 2,
            Classes = new()
            {
                Library.Classes.druid,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.acid_splash,
            Level = 0,
            Classes = new()
            {
                Library.Classes.sorcerer,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.aid,
            Level = 2,
            Classes = new()
            {
                Library.Classes.cleric,
                Library.Classes.paladin,
            },
        },
        new()
        {
            ID = Library.Spells.alarm,
            Level = 1,
            Classes = new()
            {
                Library.Classes.ranger,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.alter_self,
            Level = 2,
            Classes = new()
            {
                Library.Classes.sorcerer,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.animal_friendship,
            Level = 1,
            Classes = new()
            {
                Library.Classes.bard,
                Library.Classes.druid,
                Library.Classes.ranger,
            },
        },
        new()
        {
            ID = Library.Spells.animal_messenger,
            Level = 2,
            Classes = new()
            {
                Library.Classes.bard,
                Library.Classes.druid,
                Library.Classes.ranger,
            },
        },
        new()
        {
            ID = Library.Spells.animal_shapes,
            Level = 8,
            Classes = new()
            {
                Library.Classes.druid,
            },
        },
        new()
        {
            ID = Library.Spells.animate_dead,
            Level = 3,
            Classes = new()
            {
                Library.Classes.cleric,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.animate_objects,
            Level = 5,
            Classes = new()
            {
                Library.Classes.bard,
                Library.Classes.sorcerer,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.antilife_shell,
            Level = 5,
            Classes = new()
            {
                Library.Classes.druid,
            },
        },
        new()
        {
            ID = Library.Spells.antimagic_field,
            Level = 8,
            Classes = new()
            {
                Library.Classes.cleric,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.antipathysympathy,
            Level = 8,
            Classes = new()
            {
                Library.Classes.druid,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.arcane_eye,
            Level = 4,
            Classes = new()
            {
                Library.Classes.cleric,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.arcane_hand,
            Level = 5,
            Classes = new()
            {
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.arcane_lock,
            Level = 2,
            Classes = new()
            {
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.arcane_sword,
            Level = 7,
            Classes = new()
            {
                Library.Classes.bard,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.arcanists_magic_aura,
            Level = 2,
            Classes = new()
            {
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.astral_projection,
            Level = 9,
            Classes = new()
            {
                Library.Classes.cleric,
                Library.Classes.warlock,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.augury,
            Level = 2,
            Classes = new()
            {
                Library.Classes.cleric,
            },
        },
        new()
        {
            ID = Library.Spells.awaken,
            Level = 5,
            Classes = new()
            {
                Library.Classes.bard,
                Library.Classes.druid,
            },
        },
        new()
        {
            ID = Library.Spells.bane,
            Level = 1,
            Classes = new()
            {
                Library.Classes.bard,
                Library.Classes.cleric,
                Library.Classes.paladin,
            },
        },
        new()
        {
            ID = Library.Spells.banishment,
            Level = 4,
            Classes = new()
            {
                Library.Classes.cleric,
                Library.Classes.paladin,
                Library.Classes.sorcerer,
                Library.Classes.warlock,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.barkskin,
            Level = 2,
            Classes = new()
            {
                Library.Classes.cleric,
                Library.Classes.druid,
                Library.Classes.ranger,
            },
        },
        new()
        {
            ID = Library.Spells.beacon_of_hope,
            Level = 3,
            Classes = new()
            {
                Library.Classes.cleric,
                Library.Classes.paladin,
            },
        },
        new()
        {
            ID = Library.Spells.bestow_curse,
            Level = 3,
            Classes = new()
            {
                Library.Classes.bard,
                Library.Classes.cleric,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.black_tentacles,
            Level = 4,
            Classes = new()
            {
                Library.Classes.warlock,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.blade_barrier,
            Level = 6,
            Classes = new()
            {
                Library.Classes.cleric,
            },
        },
        new()
        {
            ID = Library.Spells.bless,
            Level = 1,
            Classes = new()
            {
                Library.Classes.cleric,
                Library.Classes.paladin,
            },
        },
        new()
        {
            ID = Library.Spells.blight,
            Level = 4,
            Classes = new()
            {
                Library.Classes.druid,
                Library.Classes.sorcerer,
                Library.Classes.warlock,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.blindnessdeafness,
            Level = 2,
            Classes = new()
            {
                Library.Classes.bard,
                Library.Classes.cleric,
                Library.Classes.sorcerer,
                Library.Classes.warlock,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.blink,
            Level = 3,
            Classes = new()
            {
                Library.Classes.cleric,
                Library.Classes.sorcerer,
                Library.Classes.warlock,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.blur,
            Level = 2,
            Classes = new()
            {
                Library.Classes.druid,
                Library.Classes.sorcerer,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.branding_smite,
            Level = 2,
            Classes = new()
            {
                Library.Classes.paladin,
            },
        },
        new()
        {
            ID = Library.Spells.burning_hands,
            Level = 1,
            Classes = new()
            {
                Library.Classes.cleric,
                Library.Classes.sorcerer,
                Library.Classes.warlock,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.call_lightning,
            Level = 3,
            Classes = new()
            {
                Library.Classes.cleric,
                Library.Classes.druid,
            },
        },
        new()
        {
            ID = Library.Spells.calm_emotions,
            Level = 2,
            Classes = new()
            {
                Library.Classes.bard,
                Library.Classes.cleric,
                Library.Classes.warlock,
            },
        },
        new()
        {
            ID = Library.Spells.chain_lightning,
            Level = 6,
            Classes = new()
            {
                Library.Classes.sorcerer,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.charm_person,
            Level = 1,
            Classes = new()
            {
                Library.Classes.bard,
                Library.Classes.cleric,
                Library.Classes.druid,
                Library.Classes.sorcerer,
                Library.Classes.warlock,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.chill_touch,
            Level = 0,
            Classes = new()
            {
                Library.Classes.sorcerer,
                Library.Classes.warlock,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.circle_of_death,
            Level = 6,
            Classes = new()
            {
                Library.Classes.sorcerer,
                Library.Classes.warlock,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.clairvoyance,
            Level = 3,
            Classes = new()
            {
                Library.Classes.bard,
                Library.Classes.cleric,
                Library.Classes.sorcerer,
                Library.Classes.warlock,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.clone,
            Level = 8,
            Classes = new()
            {
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.cloudkill,
            Level = 5,
            Classes = new()
            {
                Library.Classes.druid,
                Library.Classes.sorcerer,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.color_spray,
            Level = 1,
            Classes = new()
            {
                Library.Classes.sorcerer,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.command,
            Level = 1,
            Classes = new()
            {
                Library.Classes.cleric,
                Library.Classes.paladin,
                Library.Classes.warlock,
            },
        },
        new()
        {
            ID = Library.Spells.commune,
            Level = 5,
            Classes = new()
            {
                Library.Classes.cleric,
                Library.Classes.paladin,
            },
        },
        new()
        {
            ID = Library.Spells.commune_with_nature,
            Level = 5,
            Classes = new()
            {
                Library.Classes.druid,
                Library.Classes.paladin,
                Library.Classes.ranger,
            },
        },
        new()
        {
            ID = Library.Spells.comprehend_languages,
            Level = 1,
            Classes = new()
            {
                Library.Classes.bard,
                Library.Classes.sorcerer,
                Library.Classes.warlock,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.compulsion,
            Level = 4,
            Classes = new()
            {
                Library.Classes.bard,
            },
        },
        new()
        {
            ID = Library.Spells.cone_of_cold,
            Level = 5,
            Classes = new()
            {
                Library.Classes.druid,
                Library.Classes.sorcerer,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.confusion,
            Level = 4,
            Classes = new()
            {
                Library.Classes.bard,
                Library.Classes.cleric,
                Library.Classes.druid,
                Library.Classes.sorcerer,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.conjure_animals,
            Level = 3,
            Classes = new()
            {
                Library.Classes.druid,
                Library.Classes.ranger,
            },
        },
        new()
        {
            ID = Library.Spells.conjure_celestial,
            Level = 7,
            Classes = new()
            {
                Library.Classes.cleric,
            },
        },
        new()
        {
            ID = Library.Spells.conjure_elemental,
            Level = 5,
            Classes = new()
            {
                Library.Classes.druid,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.conjure_fey,
            Level = 6,
            Classes = new()
            {
                Library.Classes.druid,
                Library.Classes.warlock,
            },
        },
        new()
        {
            ID = Library.Spells.conjure_minor_elementals,
            Level = 4,
            Classes = new()
            {
                Library.Classes.druid,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.conjure_woodland_beings,
            Level = 4,
            Classes = new()
            {
                Library.Classes.druid,
                Library.Classes.ranger,
            },
        },
        new()
        {
            ID = Library.Spells.contact_other_plane,
            Level = 5,
            Classes = new()
            {
                Library.Classes.warlock,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.contagion,
            Level = 5,
            Classes = new()
            {
                Library.Classes.cleric,
                Library.Classes.druid,
            },
        },
        new()
        {
            ID = Library.Spells.contingency,
            Level = 6,
            Classes = new()
            {
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.continual_flame,
            Level = 2,
            Classes = new()
            {
                Library.Classes.cleric,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.control_water,
            Level = 4,
            Classes = new()
            {
                Library.Classes.cleric,
                Library.Classes.druid,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.control_weather,
            Level = 8,
            Classes = new()
            {
                Library.Classes.cleric,
                Library.Classes.druid,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.counterspell,
            Level = 3,
            Classes = new()
            {
                Library.Classes.paladin,
                Library.Classes.sorcerer,
                Library.Classes.warlock,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.create_food_and_water,
            Level = 3,
            Classes = new()
            {
                Library.Classes.cleric,
                Library.Classes.druid,
                Library.Classes.paladin,
            },
        },
        new()
        {
            ID = Library.Spells.create_undead,
            Level = 6,
            Classes = new()
            {
                Library.Classes.cleric,
                Library.Classes.warlock,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.create_or_destroy_water,
            Level = 1,
            Classes = new()
            {
                Library.Classes.cleric,
                Library.Classes.druid,
            },
        },
        new()
        {
            ID = Library.Spells.creation,
            Level = 5,
            Classes = new()
            {
                Library.Classes.sorcerer,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.cure_wounds,
            Level = 1,
            Classes = new()
            {
                Library.Classes.bard,
                Library.Classes.cleric,
                Library.Classes.druid,
                Library.Classes.paladin,
                Library.Classes.ranger,
            },
        },
        new()
        {
            ID = Library.Spells.dancing_lights,
            Level = 0,
            Classes = new()
            {
                Library.Classes.bard,
                Library.Classes.sorcerer,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.darkness,
            Level = 2,
            Classes = new()
            {
                Library.Classes.druid,
                Library.Classes.sorcerer,
                Library.Classes.warlock,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.darkvision,
            Level = 2,
            Classes = new()
            {
                Library.Classes.druid,
                Library.Classes.ranger,
                Library.Classes.sorcerer,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.daylight,
            Level = 3,
            Classes = new()
            {
                Library.Classes.cleric,
                Library.Classes.druid,
                Library.Classes.paladin,
                Library.Classes.ranger,
                Library.Classes.sorcerer,
            },
        },
        new()
        {
            ID = Library.Spells.death_ward,
            Level = 4,
            Classes = new()
            {
                Library.Classes.cleric,
                Library.Classes.paladin,
            },
        },
        new()
        {
            ID = Library.Spells.delayed_blast_fireball,
            Level = 7,
            Classes = new()
            {
                Library.Classes.sorcerer,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.demiplane,
            Level = 8,
            Classes = new()
            {
                Library.Classes.warlock,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.detect_evil_and_good,
            Level = 1,
            Classes = new()
            {
                Library.Classes.cleric,
                Library.Classes.paladin,
            },
        },
        new()
        {
            ID = Library.Spells.detect_magic,
            Level = 1,
            Classes = new()
            {
                Library.Classes.bard,
                Library.Classes.cleric,
                Library.Classes.druid,
                Library.Classes.paladin,
                Library.Classes.ranger,
                Library.Classes.sorcerer,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.detect_poison_and_disease,
            Level = 1,
            Classes = new()
            {
                Library.Classes.cleric,
                Library.Classes.druid,
                Library.Classes.paladin,
                Library.Classes.ranger,
            },
        },
        new()
        {
            ID = Library.Spells.detect_thoughts,
            Level = 2,
            Classes = new()
            {
                Library.Classes.bard,
                Library.Classes.sorcerer,
                Library.Classes.warlock,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.dimension_door,
            Level = 4,
            Classes = new()
            {
                Library.Classes.bard,
                Library.Classes.cleric,
                Library.Classes.paladin,
                Library.Classes.sorcerer,
                Library.Classes.warlock,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.disguise_self,
            Level = 1,
            Classes = new()
            {
                Library.Classes.bard,
                Library.Classes.cleric,
                Library.Classes.sorcerer,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.disintegrate,
            Level = 6,
            Classes = new()
            {
                Library.Classes.sorcerer,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.dispel_evil_and_good,
            Level = 5,
            Classes = new()
            {
                Library.Classes.cleric,
                Library.Classes.paladin,
            },
        },
        new()
        {
            ID = Library.Spells.dispel_magic,
            Level = 3,
            Classes = new()
            {
                Library.Classes.bard,
                Library.Classes.cleric,
                Library.Classes.druid,
                Library.Classes.paladin,
                Library.Classes.sorcerer,
                Library.Classes.warlock,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.divination,
            Level = 4,
            Classes = new()
            {
                Library.Classes.cleric,
                Library.Classes.druid,
            },
        },
        new()
        {
            ID = Library.Spells.divine_favor,
            Level = 1,
            Classes = new()
            {
                Library.Classes.cleric,
                Library.Classes.paladin,
            },
        },
        new()
        {
            ID = Library.Spells.divine_word,
            Level = 7,
            Classes = new()
            {
                Library.Classes.cleric,
            },
        },
        new()
        {
            ID = Library.Spells.dominate_beast,
            Level = 4,
            Classes = new()
            {
                Library.Classes.cleric,
                Library.Classes.druid,
                Library.Classes.sorcerer,
                Library.Classes.warlock,
            },
        },
        new()
        {
            ID = Library.Spells.dominate_monster,
            Level = 8,
            Classes = new()
            {
                Library.Classes.bard,
                Library.Classes.sorcerer,
                Library.Classes.warlock,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.dominate_person,
            Level = 5,
            Classes = new()
            {
                Library.Classes.bard,
                Library.Classes.cleric,
                Library.Classes.sorcerer,
                Library.Classes.warlock,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.dream,
            Level = 5,
            Classes = new()
            {
                Library.Classes.bard,
                Library.Classes.druid,
                Library.Classes.warlock,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.druidcraft,
            Level = 0,
            Classes = new()
            {
                Library.Classes.druid,
            },
        },
        new()
        {
            ID = Library.Spells.earthquake,
            Level = 8,
            Classes = new()
            {
                Library.Classes.cleric,
                Library.Classes.druid,
                Library.Classes.sorcerer,
            },
        },
        new()
        {
            ID = Library.Spells.eldritch_blast,
            Level = 0,
            Classes = new()
            {
                Library.Classes.warlock,
            },
        },
        new()
        {
            ID = Library.Spells.enhance_ability,
            Level = 2,
            Classes = new()
            {
                Library.Classes.bard,
                Library.Classes.cleric,
                Library.Classes.druid,
                Library.Classes.sorcerer,
            },
        },
        new()
        {
            ID = Library.Spells.enlargereduce,
            Level = 2,
            Classes = new()
            {
                Library.Classes.sorcerer,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.entangle,
            Level = 1,
            Classes = new()
            {
                Library.Classes.druid,
            },
        },
        new()
        {
            ID = Library.Spells.enthrall,
            Level = 2,
            Classes = new()
            {
                Library.Classes.bard,
                Library.Classes.warlock,
            },
        },
        new()
        {
            ID = Library.Spells.etherealness,
            Level = 7,
            Classes = new()
            {
                Library.Classes.bard,
                Library.Classes.cleric,
                Library.Classes.sorcerer,
                Library.Classes.warlock,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.expeditious_retreat,
            Level = 1,
            Classes = new()
            {
                Library.Classes.sorcerer,
                Library.Classes.warlock,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.eyebite,
            Level = 6,
            Classes = new()
            {
                Library.Classes.bard,
                Library.Classes.sorcerer,
                Library.Classes.warlock,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.fabricate,
            Level = 4,
            Classes = new()
            {
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.faerie_fire,
            Level = 1,
            Classes = new()
            {
                Library.Classes.bard,
                Library.Classes.cleric,
                Library.Classes.druid,
                Library.Classes.warlock,
            },
        },
        new()
        {
            ID = Library.Spells.faithful_hound,
            Level = 4,
            Classes = new()
            {
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.false_life,
            Level = 1,
            Classes = new()
            {
                Library.Classes.sorcerer,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.fear,
            Level = 3,
            Classes = new()
            {
                Library.Classes.bard,
                Library.Classes.sorcerer,
                Library.Classes.warlock,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.feather_fall,
            Level = 1,
            Classes = new()
            {
                Library.Classes.bard,
                Library.Classes.sorcerer,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.feeblemind,
            Level = 8,
            Classes = new()
            {
                Library.Classes.bard,
                Library.Classes.druid,
                Library.Classes.warlock,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.find_familiar,
            Level = 1,
            Classes = new()
            {
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.find_steed,
            Level = 2,
            Classes = new()
            {
                Library.Classes.paladin,
            },
        },
        new()
        {
            ID = Library.Spells.find_traps,
            Level = 2,
            Classes = new()
            {
                Library.Classes.cleric,
                Library.Classes.druid,
                Library.Classes.ranger,
            },
        },
        new()
        {
            ID = Library.Spells.find_the_path,
            Level = 6,
            Classes = new()
            {
                Library.Classes.bard,
                Library.Classes.cleric,
                Library.Classes.druid,
            },
        },
        new()
        {
            ID = Library.Spells.finger_of_death,
            Level = 7,
            Classes = new()
            {
                Library.Classes.sorcerer,
                Library.Classes.warlock,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.fire_bolt,
            Level = 0,
            Classes = new()
            {
                Library.Classes.sorcerer,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.fire_shield,
            Level = 4,
            Classes = new()
            {
                Library.Classes.warlock,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.fire_storm,
            Level = 7,
            Classes = new()
            {
                Library.Classes.cleric,
                Library.Classes.druid,
                Library.Classes.sorcerer,
            },
        },
        new()
        {
            ID = Library.Spells.fireball,
            Level = 3,
            Classes = new()
            {
                Library.Classes.cleric,
                Library.Classes.sorcerer,
                Library.Classes.warlock,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.flame_blade,
            Level = 2,
            Classes = new()
            {
                Library.Classes.druid,
            },
        },
        new()
        {
            ID = Library.Spells.flame_strike,
            Level = 5,
            Classes = new()
            {
                Library.Classes.cleric,
                Library.Classes.paladin,
                Library.Classes.warlock,
            },
        },
        new()
        {
            ID = Library.Spells.flaming_sphere,
            Level = 2,
            Classes = new()
            {
                Library.Classes.cleric,
                Library.Classes.druid,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.flesh_to_stone,
            Level = 6,
            Classes = new()
            {
                Library.Classes.warlock,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.floating_disk,
            Level = 1,
            Classes = new()
            {
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.fly,
            Level = 3,
            Classes = new()
            {
                Library.Classes.sorcerer,
                Library.Classes.warlock,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.fog_cloud,
            Level = 1,
            Classes = new()
            {
                Library.Classes.cleric,
                Library.Classes.druid,
                Library.Classes.ranger,
                Library.Classes.sorcerer,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.forbiddance,
            Level = 6,
            Classes = new()
            {
                Library.Classes.cleric,
            },
        },
        new()
        {
            ID = Library.Spells.forcecage,
            Level = 7,
            Classes = new()
            {
                Library.Classes.bard,
                Library.Classes.warlock,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.foresight,
            Level = 9,
            Classes = new()
            {
                Library.Classes.bard,
                Library.Classes.druid,
                Library.Classes.warlock,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.freedom_of_movement,
            Level = 4,
            Classes = new()
            {
                Library.Classes.bard,
                Library.Classes.cleric,
                Library.Classes.druid,
                Library.Classes.paladin,
                Library.Classes.ranger,
            },
        },
        new()
        {
            ID = Library.Spells.freezing_sphere,
            Level = 6,
            Classes = new()
            {
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.gaseous_form,
            Level = 3,
            Classes = new()
            {
                Library.Classes.druid,
                Library.Classes.sorcerer,
                Library.Classes.warlock,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.gate,
            Level = 9,
            Classes = new()
            {
                Library.Classes.cleric,
                Library.Classes.sorcerer,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.geas,
            Level = 5,
            Classes = new()
            {
                Library.Classes.bard,
                Library.Classes.cleric,
                Library.Classes.druid,
                Library.Classes.paladin,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.gentle_repose,
            Level = 2,
            Classes = new()
            {
                Library.Classes.cleric,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.giant_insect,
            Level = 4,
            Classes = new()
            {
                Library.Classes.druid,
            },
        },
        new()
        {
            ID = Library.Spells.glibness,
            Level = 8,
            Classes = new()
            {
                Library.Classes.bard,
                Library.Classes.warlock,
            },
        },
        new()
        {
            ID = Library.Spells.globe_of_invulnerability,
            Level = 6,
            Classes = new()
            {
                Library.Classes.sorcerer,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.glyph_of_warding,
            Level = 3,
            Classes = new()
            {
                Library.Classes.bard,
                Library.Classes.cleric,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.goodberry,
            Level = 1,
            Classes = new()
            {
                Library.Classes.druid,
                Library.Classes.ranger,
            },
        },
        new()
        {
            ID = Library.Spells.grease,
            Level = 1,
            Classes = new()
            {
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.greater_invisibility,
            Level = 4,
            Classes = new()
            {
                Library.Classes.bard,
                Library.Classes.druid,
                Library.Classes.sorcerer,
                Library.Classes.warlock,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.greater_restoration,
            Level = 5,
            Classes = new()
            {
                Library.Classes.bard,
                Library.Classes.cleric,
                Library.Classes.druid,
            },
        },
        new()
        {
            ID = Library.Spells.guardian_of_faith,
            Level = 4,
            Classes = new()
            {
                Library.Classes.cleric,
            },
        },
        new()
        {
            ID = Library.Spells.guards_and_wards,
            Level = 6,
            Classes = new()
            {
                Library.Classes.bard,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.guidance,
            Level = 0,
            Classes = new()
            {
                Library.Classes.cleric,
                Library.Classes.druid,
            },
        },
        new()
        {
            ID = Library.Spells.guiding_bolt,
            Level = 1,
            Classes = new()
            {
                Library.Classes.cleric,
            },
        },
        new()
        {
            ID = Library.Spells.gust_of_wind,
            Level = 2,
            Classes = new()
            {
                Library.Classes.cleric,
                Library.Classes.druid,
                Library.Classes.sorcerer,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.hallow,
            Level = 5,
            Classes = new()
            {
                Library.Classes.cleric,
                Library.Classes.warlock,
            },
        },
        new()
        {
            ID = Library.Spells.hallucinatory_terrain,
            Level = 4,
            Classes = new()
            {
                Library.Classes.bard,
                Library.Classes.druid,
                Library.Classes.warlock,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.harm,
            Level = 6,
            Classes = new()
            {
                Library.Classes.cleric,
            },
        },
        new()
        {
            ID = Library.Spells.haste,
            Level = 3,
            Classes = new()
            {
                Library.Classes.druid,
                Library.Classes.paladin,
                Library.Classes.sorcerer,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.heal,
            Level = 6,
            Classes = new()
            {
                Library.Classes.cleric,
                Library.Classes.druid,
            },
        },
        new()
        {
            ID = Library.Spells.healing_word,
            Level = 1,
            Classes = new()
            {
                Library.Classes.bard,
                Library.Classes.cleric,
                Library.Classes.druid,
            },
        },
        new()
        {
            ID = Library.Spells.heat_metal,
            Level = 2,
            Classes = new()
            {
                Library.Classes.bard,
                Library.Classes.druid,
            },
        },
        new()
        {
            ID = Library.Spells.hellish_rebuke,
            Level = 1,
            Classes = new()
            {
                Library.Classes.paladin,
                Library.Classes.warlock,
            },
        },
        new()
        {
            ID = Library.Spells.heroes_feast,
            Level = 6,
            Classes = new()
            {
                Library.Classes.cleric,
                Library.Classes.druid,
            },
        },
        new()
        {
            ID = Library.Spells.heroism,
            Level = 1,
            Classes = new()
            {
                Library.Classes.bard,
                Library.Classes.paladin,
            },
        },
        new()
        {
            ID = Library.Spells.hideous_laughter,
            Level = 1,
            Classes = new()
            {
                Library.Classes.bard,
                Library.Classes.warlock,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.hold_monster,
            Level = 5,
            Classes = new()
            {
                Library.Classes.bard,
                Library.Classes.cleric,
                Library.Classes.paladin,
                Library.Classes.sorcerer,
                Library.Classes.warlock,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.hold_person,
            Level = 2,
            Classes = new()
            {
                Library.Classes.bard,
                Library.Classes.cleric,
                Library.Classes.druid,
                Library.Classes.paladin,
                Library.Classes.sorcerer,
                Library.Classes.warlock,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.holy_aura,
            Level = 8,
            Classes = new()
            {
                Library.Classes.cleric,
            },
        },
        new()
        {
            ID = Library.Spells.hunters_mark,
            Level = 1,
            Classes = new()
            {
                Library.Classes.paladin,
                Library.Classes.ranger,
            },
        },
        new()
        {
            ID = Library.Spells.hypnotic_pattern,
            Level = 3,
            Classes = new()
            {
                Library.Classes.bard,
                Library.Classes.sorcerer,
                Library.Classes.warlock,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.ice_storm,
            Level = 4,
            Classes = new()
            {
                Library.Classes.cleric,
                Library.Classes.druid,
                Library.Classes.paladin,
                Library.Classes.sorcerer,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.identify,
            Level = 1,
            Classes = new()
            {
                Library.Classes.bard,
                Library.Classes.cleric,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.illusory_script,
            Level = 1,
            Classes = new()
            {
                Library.Classes.bard,
                Library.Classes.warlock,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.imprisonment,
            Level = 9,
            Classes = new()
            {
                Library.Classes.warlock,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.incendiary_cloud,
            Level = 8,
            Classes = new()
            {
                Library.Classes.sorcerer,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.inflict_wounds,
            Level = 1,
            Classes = new()
            {
                Library.Classes.cleric,
            },
        },
        new()
        {
            ID = Library.Spells.insect_plague,
            Level = 5,
            Classes = new()
            {
                Library.Classes.cleric,
                Library.Classes.druid,
                Library.Classes.sorcerer,
            },
        },
        new()
        {
            ID = Library.Spells.instant_summons,
            Level = 6,
            Classes = new()
            {
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.invisibility,
            Level = 2,
            Classes = new()
            {
                Library.Classes.bard,
                Library.Classes.druid,
                Library.Classes.sorcerer,
                Library.Classes.warlock,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.irresistible_dance,
            Level = 6,
            Classes = new()
            {
                Library.Classes.bard,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.jump,
            Level = 1,
            Classes = new()
            {
                Library.Classes.druid,
                Library.Classes.ranger,
                Library.Classes.sorcerer,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.knock,
            Level = 2,
            Classes = new()
            {
                Library.Classes.bard,
                Library.Classes.sorcerer,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.legend_lore,
            Level = 5,
            Classes = new()
            {
                Library.Classes.bard,
                Library.Classes.cleric,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.lesser_restoration,
            Level = 2,
            Classes = new()
            {
                Library.Classes.bard,
                Library.Classes.cleric,
                Library.Classes.druid,
                Library.Classes.paladin,
                Library.Classes.ranger,
            },
        },
        new()
        {
            ID = Library.Spells.levitate,
            Level = 2,
            Classes = new()
            {
                Library.Classes.sorcerer,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.light,
            Level = 0,
            Classes = new()
            {
                Library.Classes.bard,
                Library.Classes.cleric,
                Library.Classes.sorcerer,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.lightning_bolt,
            Level = 3,
            Classes = new()
            {
                Library.Classes.druid,
                Library.Classes.sorcerer,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.locate_animals_or_plants,
            Level = 2,
            Classes = new()
            {
                Library.Classes.bard,
                Library.Classes.druid,
                Library.Classes.ranger,
            },
        },
        new()
        {
            ID = Library.Spells.locate_creature,
            Level = 4,
            Classes = new()
            {
                Library.Classes.bard,
                Library.Classes.cleric,
                Library.Classes.druid,
                Library.Classes.paladin,
                Library.Classes.ranger,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.locate_object,
            Level = 2,
            Classes = new()
            {
                Library.Classes.bard,
                Library.Classes.cleric,
                Library.Classes.druid,
                Library.Classes.paladin,
                Library.Classes.ranger,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.longstrider,
            Level = 1,
            Classes = new()
            {
                Library.Classes.bard,
                Library.Classes.druid,
                Library.Classes.ranger,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.mage_armor,
            Level = 1,
            Classes = new()
            {
                Library.Classes.sorcerer,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.mage_hand,
            Level = 0,
            Classes = new()
            {
                Library.Classes.bard,
                Library.Classes.sorcerer,
                Library.Classes.warlock,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.magic_circle,
            Level = 3,
            Classes = new()
            {
                Library.Classes.cleric,
                Library.Classes.paladin,
                Library.Classes.warlock,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.magic_jar,
            Level = 6,
            Classes = new()
            {
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.magic_missile,
            Level = 1,
            Classes = new()
            {
                Library.Classes.sorcerer,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.magic_mouth,
            Level = 2,
            Classes = new()
            {
                Library.Classes.bard,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.magic_weapon,
            Level = 2,
            Classes = new()
            {
                Library.Classes.cleric,
                Library.Classes.paladin,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.magnificent_mansion,
            Level = 7,
            Classes = new()
            {
                Library.Classes.bard,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.major_image,
            Level = 3,
            Classes = new()
            {
                Library.Classes.bard,
                Library.Classes.sorcerer,
                Library.Classes.warlock,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.mass_cure_wounds,
            Level = 5,
            Classes = new()
            {
                Library.Classes.bard,
                Library.Classes.cleric,
                Library.Classes.druid,
            },
        },
        new()
        {
            ID = Library.Spells.mass_heal,
            Level = 9,
            Classes = new()
            {
                Library.Classes.cleric,
            },
        },
        new()
        {
            ID = Library.Spells.mass_healing_word,
            Level = 3,
            Classes = new()
            {
                Library.Classes.cleric,
            },
        },
        new()
        {
            ID = Library.Spells.mass_suggestion,
            Level = 6,
            Classes = new()
            {
                Library.Classes.bard,
                Library.Classes.sorcerer,
                Library.Classes.warlock,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.maze,
            Level = 8,
            Classes = new()
            {
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.meld_into_stone,
            Level = 3,
            Classes = new()
            {
                Library.Classes.cleric,
                Library.Classes.druid,
            },
        },
        new()
        {
            ID = Library.Spells.mending,
            Level = 0,
            Classes = new()
            {
                Library.Classes.cleric,
                Library.Classes.bard,
                Library.Classes.druid,
                Library.Classes.sorcerer,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.message,
            Level = 0,
            Classes = new()
            {
                Library.Classes.bard,
                Library.Classes.sorcerer,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.meteor_swarm,
            Level = 9,
            Classes = new()
            {
                Library.Classes.sorcerer,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.mind_blank,
            Level = 8,
            Classes = new()
            {
                Library.Classes.bard,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.minor_illusion,
            Level = 0,
            Classes = new()
            {
                Library.Classes.bard,
                Library.Classes.sorcerer,
                Library.Classes.warlock,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.mirage_arcane,
            Level = 7,
            Classes = new()
            {
                Library.Classes.bard,
                Library.Classes.druid,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.mirror_image,
            Level = 2,
            Classes = new()
            {
                Library.Classes.cleric,
                Library.Classes.druid,
                Library.Classes.sorcerer,
                Library.Classes.warlock,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.mislead,
            Level = 5,
            Classes = new()
            {
                Library.Classes.bard,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.misty_step,
            Level = 2,
            Classes = new()
            {
                Library.Classes.druid,
                Library.Classes.paladin,
                Library.Classes.sorcerer,
                Library.Classes.warlock,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.modify_memory,
            Level = 5,
            Classes = new()
            {
                Library.Classes.bard,
                Library.Classes.cleric,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.moonbeam,
            Level = 2,
            Classes = new()
            {
                Library.Classes.druid,
                Library.Classes.paladin,
            },
        },
        new()
        {
            ID = Library.Spells.move_earth,
            Level = 6,
            Classes = new()
            {
                Library.Classes.druid,
                Library.Classes.sorcerer,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.nondetection,
            Level = 3,
            Classes = new()
            {
                Library.Classes.bard,
                Library.Classes.cleric,
                Library.Classes.ranger,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.pass_without_trace,
            Level = 2,
            Classes = new()
            {
                Library.Classes.cleric,
                Library.Classes.druid,
                Library.Classes.ranger,
            },
        },
        new()
        {
            ID = Library.Spells.passwall,
            Level = 5,
            Classes = new()
            {
                Library.Classes.druid,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.phantasmal_killer,
            Level = 4,
            Classes = new()
            {
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.phantom_steed,
            Level = 3,
            Classes = new()
            {
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.planar_ally,
            Level = 6,
            Classes = new()
            {
                Library.Classes.cleric,
            },
        },
        new()
        {
            ID = Library.Spells.planar_binding,
            Level = 5,
            Classes = new()
            {
                Library.Classes.bard,
                Library.Classes.cleric,
                Library.Classes.druid,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.plane_shift,
            Level = 7,
            Classes = new()
            {
                Library.Classes.cleric,
                Library.Classes.sorcerer,
                Library.Classes.warlock,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.plant_growth,
            Level = 3,
            Classes = new()
            {
                Library.Classes.bard,
                Library.Classes.cleric,
                Library.Classes.druid,
                Library.Classes.paladin,
                Library.Classes.ranger,
                Library.Classes.warlock,
            },
        },
        new()
        {
            ID = Library.Spells.poison_spray,
            Level = 0,
            Classes = new()
            {
                Library.Classes.druid,
                Library.Classes.sorcerer,
                Library.Classes.warlock,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.polymorph,
            Level = 4,
            Classes = new()
            {
                Library.Classes.bard,
                Library.Classes.cleric,
                Library.Classes.druid,
                Library.Classes.sorcerer,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.power_word_kill,
            Level = 9,
            Classes = new()
            {
                Library.Classes.bard,
                Library.Classes.sorcerer,
                Library.Classes.warlock,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.power_word_stun,
            Level = 8,
            Classes = new()
            {
                Library.Classes.bard,
                Library.Classes.sorcerer,
                Library.Classes.warlock,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.prayer_of_healing,
            Level = 2,
            Classes = new()
            {
                Library.Classes.cleric,
            },
        },
        new()
        {
            ID = Library.Spells.prestidigitation,
            Level = 0,
            Classes = new()
            {
                Library.Classes.bard,
                Library.Classes.sorcerer,
                Library.Classes.warlock,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.prismatic_spray,
            Level = 7,
            Classes = new()
            {
                Library.Classes.sorcerer,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.prismatic_wall,
            Level = 9,
            Classes = new()
            {
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.private_sanctum,
            Level = 4,
            Classes = new()
            {
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.produce_flame,
            Level = 0,
            Classes = new()
            {
                Library.Classes.druid,
            },
        },
        new()
        {
            ID = Library.Spells.programmed_illusion,
            Level = 6,
            Classes = new()
            {
                Library.Classes.bard,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.project_image,
            Level = 7,
            Classes = new()
            {
                Library.Classes.bard,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.protection_from_energy,
            Level = 3,
            Classes = new()
            {
                Library.Classes.cleric,
                Library.Classes.druid,
                Library.Classes.paladin,
                Library.Classes.ranger,
                Library.Classes.sorcerer,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.protection_from_evil_and_good,
            Level = 1,
            Classes = new()
            {
                Library.Classes.cleric,
                Library.Classes.paladin,
                Library.Classes.warlock,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.protection_from_poison,
            Level = 2,
            Classes = new()
            {
                Library.Classes.cleric,
                Library.Classes.druid,
                Library.Classes.paladin,
                Library.Classes.ranger,
            },
        },
        new()
        {
            ID = Library.Spells.purify_food_and_drink,
            Level = 1,
            Classes = new()
            {
                Library.Classes.cleric,
                Library.Classes.druid,
                Library.Classes.paladin,
            },
        },
        new()
        {
            ID = Library.Spells.raise_dead,
            Level = 5,
            Classes = new()
            {
                Library.Classes.bard,
                Library.Classes.cleric,
                Library.Classes.paladin,
            },
        },
        new()
        {
            ID = Library.Spells.ray_of_enfeeblement,
            Level = 2,
            Classes = new()
            {
                Library.Classes.warlock,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.ray_of_frost,
            Level = 0,
            Classes = new()
            {
                Library.Classes.sorcerer,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.regenerate,
            Level = 7,
            Classes = new()
            {
                Library.Classes.bard,
                Library.Classes.cleric,
                Library.Classes.druid,
            },
        },
        new()
        {
            ID = Library.Spells.reincarnate,
            Level = 5,
            Classes = new()
            {
                Library.Classes.druid,
            },
        },
        new()
        {
            ID = Library.Spells.remove_curse,
            Level = 3,
            Classes = new()
            {
                Library.Classes.cleric,
                Library.Classes.paladin,
                Library.Classes.warlock,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.resilient_sphere,
            Level = 4,
            Classes = new()
            {
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.resistance,
            Level = 0,
            Classes = new()
            {
                Library.Classes.cleric,
                Library.Classes.druid,
            },
        },
        new()
        {
            ID = Library.Spells.resurrection,
            Level = 7,
            Classes = new()
            {
                Library.Classes.bard,
                Library.Classes.cleric,
            },
        },
        new()
        {
            ID = Library.Spells.reverse_gravity,
            Level = 7,
            Classes = new()
            {
                Library.Classes.druid,
                Library.Classes.sorcerer,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.revivify,
            Level = 3,
            Classes = new()
            {
                Library.Classes.cleric,
                Library.Classes.paladin,
            },
        },
        new()
        {
            ID = Library.Spells.rope_trick,
            Level = 2,
            Classes = new()
            {
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.sacred_flame,
            Level = 0,
            Classes = new()
            {
                Library.Classes.cleric,
            },
        },
        new()
        {
            ID = Library.Spells.sanctuary,
            Level = 1,
            Classes = new()
            {
                Library.Classes.cleric,
                Library.Classes.paladin,
            },
        },
        new()
        {
            ID = Library.Spells.scorching_ray,
            Level = 2,
            Classes = new()
            {
                Library.Classes.cleric,
                Library.Classes.sorcerer,
                Library.Classes.warlock,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.scrying,
            Level = 5,
            Classes = new()
            {
                Library.Classes.bard,
                Library.Classes.cleric,
                Library.Classes.druid,
                Library.Classes.paladin,
                Library.Classes.warlock,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.secret_chest,
            Level = 4,
            Classes = new()
            {
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.see_invisibility,
            Level = 2,
            Classes = new()
            {
                Library.Classes.bard,
                Library.Classes.sorcerer,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.seeming,
            Level = 5,
            Classes = new()
            {
                Library.Classes.bard,
                Library.Classes.sorcerer,
                Library.Classes.warlock,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.sending,
            Level = 3,
            Classes = new()
            {
                Library.Classes.bard,
                Library.Classes.cleric,
                Library.Classes.warlock,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.sequester,
            Level = 7,
            Classes = new()
            {
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.shapechange,
            Level = 9,
            Classes = new()
            {
                Library.Classes.druid,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.shatter,
            Level = 2,
            Classes = new()
            {
                Library.Classes.bard,
                Library.Classes.cleric,
                Library.Classes.sorcerer,
                Library.Classes.warlock,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.shield,
            Level = 1,
            Classes = new()
            {
                Library.Classes.sorcerer,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.shield_of_faith,
            Level = 1,
            Classes = new()
            {
                Library.Classes.cleric,
                Library.Classes.paladin,
            },
        },
        new()
        {
            ID = Library.Spells.shillelagh,
            Level = 0,
            Classes = new()
            {
                Library.Classes.druid,
            },
        },
        new()
        {
            ID = Library.Spells.shocking_grasp,
            Level = 0,
            Classes = new()
            {
                Library.Classes.sorcerer,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.silence,
            Level = 2,
            Classes = new()
            {
                Library.Classes.bard,
                Library.Classes.cleric,
                Library.Classes.druid,
                Library.Classes.ranger,
            },
        },
        new()
        {
            ID = Library.Spells.silent_image,
            Level = 1,
            Classes = new()
            {
                Library.Classes.bard,
                Library.Classes.sorcerer,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.simulacrum,
            Level = 7,
            Classes = new()
            {
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.sleep,
            Level = 1,
            Classes = new()
            {
                Library.Classes.bard,
                Library.Classes.sorcerer,
                Library.Classes.warlock,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.sleet_storm,
            Level = 3,
            Classes = new()
            {
                Library.Classes.cleric,
                Library.Classes.druid,
                Library.Classes.sorcerer,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.slow,
            Level = 3,
            Classes = new()
            {
                Library.Classes.druid,
                Library.Classes.sorcerer,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.spare_the_dying,
            Level = 0,
            Classes = new()
            {
                Library.Classes.cleric,
            },
        },
        new()
        {
            ID = Library.Spells.speak_with_animals,
            Level = 1,
            Classes = new()
            {
                Library.Classes.bard,
                Library.Classes.cleric,
                Library.Classes.druid,
                Library.Classes.paladin,
                Library.Classes.ranger,
            },
        },
        new()
        {
            ID = Library.Spells.speak_with_dead,
            Level = 3,
            Classes = new()
            {
                Library.Classes.bard,
                Library.Classes.cleric,
            },
        },
        new()
        {
            ID = Library.Spells.speak_with_plants,
            Level = 3,
            Classes = new()
            {
                Library.Classes.bard,
                Library.Classes.druid,
                Library.Classes.ranger,
            },
        },
        new()
        {
            ID = Library.Spells.spider_climb,
            Level = 2,
            Classes = new()
            {
                Library.Classes.druid,
                Library.Classes.sorcerer,
                Library.Classes.warlock,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.spike_growth,
            Level = 2,
            Classes = new()
            {
                Library.Classes.cleric,
                Library.Classes.druid,
                Library.Classes.ranger,
            },
        },
        new()
        {
            ID = Library.Spells.spirit_guardians,
            Level = 3,
            Classes = new()
            {
                Library.Classes.cleric,
            },
        },
        new()
        {
            ID = Library.Spells.spiritual_weapon,
            Level = 2,
            Classes = new()
            {
                Library.Classes.cleric,
            },
        },
        new()
        {
            ID = Library.Spells.stinking_cloud,
            Level = 3,
            Classes = new()
            {
                Library.Classes.bard,
                Library.Classes.druid,
                Library.Classes.sorcerer,
                Library.Classes.warlock,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.stone_shape,
            Level = 4,
            Classes = new()
            {
                Library.Classes.cleric,
                Library.Classes.druid,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.stoneskin,
            Level = 4,
            Classes = new()
            {
                Library.Classes.cleric,
                Library.Classes.druid,
                Library.Classes.paladin,
                Library.Classes.ranger,
                Library.Classes.sorcerer,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.storm_of_vengeance,
            Level = 9,
            Classes = new()
            {
                Library.Classes.druid,
            },
        },
        new()
        {
            ID = Library.Spells.suggestion,
            Level = 2,
            Classes = new()
            {
                Library.Classes.bard,
                Library.Classes.cleric,
                Library.Classes.sorcerer,
                Library.Classes.warlock,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.sunbeam,
            Level = 6,
            Classes = new()
            {
                Library.Classes.druid,
                Library.Classes.sorcerer,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.sunburst,
            Level = 8,
            Classes = new()
            {
                Library.Classes.druid,
                Library.Classes.sorcerer,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.symbol,
            Level = 7,
            Classes = new()
            {
                Library.Classes.bard,
                Library.Classes.cleric,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.telekinesis,
            Level = 5,
            Classes = new()
            {
                Library.Classes.sorcerer,
                Library.Classes.warlock,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.telepathic_bond,
            Level = 5,
            Classes = new()
            {
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.teleport,
            Level = 7,
            Classes = new()
            {
                Library.Classes.bard,
                Library.Classes.sorcerer,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.teleportation_circle,
            Level = 5,
            Classes = new()
            {
                Library.Classes.bard,
                Library.Classes.sorcerer,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.thaumaturgy,
            Level = 0,
            Classes = new()
            {
                Library.Classes.cleric,
            },
        },
        new()
        {
            ID = Library.Spells.thunderwave,
            Level = 1,
            Classes = new()
            {
                Library.Classes.bard,
                Library.Classes.cleric,
                Library.Classes.druid,
                Library.Classes.sorcerer,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.time_stop,
            Level = 9,
            Classes = new()
            {
                Library.Classes.sorcerer,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.tiny_hut,
            Level = 3,
            Classes = new()
            {
                Library.Classes.bard,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.tongues,
            Level = 3,
            Classes = new()
            {
                Library.Classes.bard,
                Library.Classes.cleric,
                Library.Classes.sorcerer,
                Library.Classes.warlock,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.transport_via_plants,
            Level = 6,
            Classes = new()
            {
                Library.Classes.druid,
            },
        },
        new()
        {
            ID = Library.Spells.tree_stride,
            Level = 5,
            Classes = new()
            {
                Library.Classes.cleric,
                Library.Classes.druid,
                Library.Classes.paladin,
                Library.Classes.ranger,
            },
        },
        new()
        {
            ID = Library.Spells.true_polymorph,
            Level = 9,
            Classes = new()
            {
                Library.Classes.bard,
                Library.Classes.warlock,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.true_resurrection,
            Level = 9,
            Classes = new()
            {
                Library.Classes.cleric,
                Library.Classes.druid,
            },
        },
        new()
        {
            ID = Library.Spells.true_seeing,
            Level = 6,
            Classes = new()
            {
                Library.Classes.bard,
                Library.Classes.cleric,
                Library.Classes.sorcerer,
                Library.Classes.warlock,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.true_strike,
            Level = 0,
            Classes = new()
            {
                Library.Classes.bard,
                Library.Classes.sorcerer,
                Library.Classes.warlock,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.unseen_servant,
            Level = 1,
            Classes = new()
            {
                Library.Classes.bard,
                Library.Classes.warlock,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.vampiric_touch,
            Level = 3,
            Classes = new()
            {
                Library.Classes.warlock,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.vicious_mockery,
            Level = 0,
            Classes = new()
            {
                Library.Classes.bard,
            },
        },
        new()
        {
            ID = Library.Spells.wall_of_fire,
            Level = 4,
            Classes = new()
            {
                Library.Classes.cleric,
                Library.Classes.druid,
                Library.Classes.sorcerer,
                Library.Classes.warlock,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.wall_of_force,
            Level = 5,
            Classes = new()
            {
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.wall_of_ice,
            Level = 6,
            Classes = new()
            {
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.wall_of_stone,
            Level = 5,
            Classes = new()
            {
                Library.Classes.druid,
                Library.Classes.sorcerer,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.wall_of_thorns,
            Level = 6,
            Classes = new()
            {
                Library.Classes.druid,
            },
        },
        new()
        {
            ID = Library.Spells.warding_bond,
            Level = 2,
            Classes = new()
            {
                Library.Classes.cleric,
            },
        },
        new()
        {
            ID = Library.Spells.water_breathing,
            Level = 3,
            Classes = new()
            {
                Library.Classes.druid,
                Library.Classes.ranger,
                Library.Classes.sorcerer,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.water_walk,
            Level = 3,
            Classes = new()
            {
                Library.Classes.cleric,
                Library.Classes.druid,
                Library.Classes.ranger,
                Library.Classes.sorcerer,
            },
        },
        new()
        {
            ID = Library.Spells.web,
            Level = 2,
            Classes = new()
            {
                Library.Classes.druid,
                Library.Classes.sorcerer,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.weird,
            Level = 9,
            Classes = new()
            {
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.wind_walk,
            Level = 6,
            Classes = new()
            {
                Library.Classes.druid,
            },
        },
        new()
        {
            ID = Library.Spells.wind_wall,
            Level = 3,
            Classes = new()
            {
                Library.Classes.cleric,
                Library.Classes.druid,
                Library.Classes.ranger,
            },
        },
        new()
        {
            ID = Library.Spells.wish,
            Level = 9,
            Classes = new()
            {
                Library.Classes.sorcerer,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.word_of_recall,
            Level = 6,
            Classes = new()
            {
                Library.Classes.cleric,
            },
        },
        new()
        {
            ID = Library.Spells.zone_of_truth,
            Level = 2,
            Classes = new()
            {
                Library.Classes.bard,
                Library.Classes.cleric,
                Library.Classes.paladin,
            },
        },
    };
    public IReadOnlyDictionary<string, SpellDatum> _spellsDataMap = null;
    public IReadOnlyDictionary<string, SpellDatum> SpellsData => _spellsDataMap ??= _spellsData.ToDictionary(s => s.ID, s => s);
}