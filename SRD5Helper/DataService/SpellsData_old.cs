using SRD5Helper.DataModels;
using Library = SRD5Helper.Resources.Library;
namespace SRD5Helper.Data;
/*public partial class DataServiceOld
{
    private IReadOnlyList<SpellDatum> _spellsData = new List<SpellDatum>
    {
        new()
        {
            ID = Library.Spells.aide,
            Level = 2,
            Classes = new()
            {
                Library.Classes.cleric,
            },
        },
        new()
        {
            ID = Library.Spells.amitie_avec_les_animaux,
            Level = 1,
            Classes = new()
            {
                Library.Classes.druid,
                Library.Classes.ranger,
            },
        },
        new()
        {
            ID = Library.Spells.arme_spirituelle,
            Level = 2,
            Classes = new()
            {
                Library.Classes.cleric,
            },
        },
        new()
        {
            ID = Library.Spells.armure_du_mage,
            Level = 1,
            Classes = new()
            {
                Library.Classes.sorcerer,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.assistance,
            Level = 0,
            Classes = new()
            {
                Library.Classes.cleric,
                Library.Classes.druid,
            },
        },
        new()
        {
            ID = Library.Spells.augure,
            Level = 2,
            Classes = new()
            {
                Library.Classes.cleric,
            },
        },
        new()
        {
            ID = Library.Spells.aura_du_heros,
            Level = 0,
            Classes = new()
            {
                Library.Classes.sorcerer,
            },
        },
        new()
        {
            ID = Library.Spells.baies_nourricieres,
            Level = 1,
            Classes = new()
            {
                Library.Classes.druid,
                Library.Classes.ranger,
            },
        },
        new()
        {
            ID = Library.Spells.benediction,
            Level = 1,
            Classes = new()
            {
                Library.Classes.cleric,
            },
        },
        new()
        {
            ID = Library.Spells.blessure,
            Level = 1,
            Classes = new()
            {
                Library.Classes.cleric,
            },
        },
        new()
        {
            ID = Library.Spells.bouclier_de_la_foi,
            Level = 1,
            Classes = new()
            {
                Library.Classes.paladin,
            },
        },
        new()
        {
            ID = Library.Spells.bouffee_de_poison,
            Level = 0,
            Classes = new()
            {
                Library.Classes.druid,
            },
        },
        new()
        {
            ID = Library.Spells.bourrasque,
            Level = 2,
            Classes = new()
            {
                Library.Classes.druid,
            },
        },
        new()
        {
            ID = Library.Spells.brulure_du_juste,
            Level = 1,
            Classes = new()
            {
                Library.Classes.paladin,
            },
        },
        new()
        {
            ID = Library.Spells.cecite_surdite,
            Level = 2,
            Classes = new()
            {
                Library.Classes.cleric,
                Library.Classes.sorcerer,
            },
        },
        new()
        {
            ID = Library.Spells.charme_personne,
            Level = 1,
            Classes = new()
            {
                Library.Classes.druid,
                Library.Classes.sorcerer,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.choc_des_titans,
            Level = 1,
            Classes = new()
            {
                Library.Classes.paladin,
            },
        },
        new()
        {
            ID = Library.Spells.comprehension_des_langues,
            Level = 1,
            Classes = new()
            {
                Library.Classes.sorcerer,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.couleurs_dansantes,
            Level = 1,
            Classes = new()
            {
                Library.Classes.sorcerer,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.detection_de_la_magie,
            Level = 1,
            Classes = new()
            {
                Library.Classes.cleric,
                Library.Classes.sorcerer,
                Library.Classes.wizard,
                Library.Classes.paladin,
            },
        },
        new()
        {
            ID = Library.Spells.detection_du_poison_et_des_maladies,
            Level = 1,
            Classes = new()
            {
                Library.Classes.druid,
            },
        },
        new()
        {
            ID = Library.Spells.enchevetrement,
            Level = 1,
            Classes = new()
            {
                Library.Classes.druid,
            },
        },
        new()
        {
            ID = Library.Spells.faveur_divine,
            Level = 1,
            Classes = new()
            {
                Library.Classes.paladin,
            },
        },
        new()
        {
            ID = Library.Spells.flamme_sacree,
            Level = 0,
            Classes = new()
            {
                Library.Classes.cleric,
            },
        },
        new()
        {
            ID = Library.Spells.fleau,
            Level = 1,
            Classes = new()
            {
                Library.Classes.cleric,
            },
        },
        new()
        {
            ID = Library.Spells.fleche_acide,
            Level = 2,
            Classes = new()
            {
                Library.Classes.wizard,
            },
            DamageDiceCount = 4,
            DamageDieType = "acid",
            DamageType = "acid",
        },
        new()
        {
            ID = Library.Spells.flou,
            Level = 2,
            Classes = new()
            {
                Library.Classes.sorcerer,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.geyser_d_energie,
            Level = 1,
            Classes = new()
            {
                Library.Classes.sorcerer,
            },
        },
        new()
        {
            ID = Library.Spells.gourdin_magique,
            Level = 0,
            Classes = new()
            {
                Library.Classes.druid,
            },
        },
        new()
        {
            ID = Library.Spells.graisse,
            Level = 1,
            Classes = new()
            {
                Library.Archetypes.shadowblade,
            },
        },
        new()
        {
            ID = Library.Spells.grande_foulee,
            Level = 1,
            Classes = new()
            {
                Library.Classes.ranger,
            },
        },
        new()
        {
            ID = Library.Spells.heroisme,
            Level = 1,
            Classes = new()
            {
                Library.Classes.paladin,
            },
        },
        new()
        {
            ID = Library.Spells.identification,
            Level = 1,
            Classes = new()
            {
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.illusion_mineure,
            Level = 0,
            Classes = new()
            {
                Library.Classes.sorcerer,
            },
        },
        new()
        {
            ID = Library.Spells.image_miroir,
            Level = 2,
            Classes = new()
            {
                Library.Classes.sorcerer,
            },
        },
        new()
        {
            ID = Library.Spells.immobiliser_un_humanoide,
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
            ID = Library.Spells.injonction,
            Level = 1,
            Classes = new()
            {
                Library.Classes.cleric,
            },
        },
        new()
        {
            ID = Library.Spells.invisibilite,
            Level = 2,
            Classes = new()
            {
                Library.Classes.wizard,
                Library.Classes.sorcerer,
            },
        },
        new()
        {
            ID = Library.Spells.lame_de_feu,
            Level = 2,
            Classes = new()
            {
                Library.Classes.druid,
            },
        },
        new()
        {
            ID = Library.Spells.levitation,
            Level = 2,
            Classes = new()
            {
                Library.Classes.sorcerer,
            },
        },
        new()
        {
            ID = Library.Spells.lumiere,
            Level = 0,
            Classes = new()
            {
                Library.Classes.cleric,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.lumieres_dansantes,
            Level = 0,
            Classes = new()
            {
                Library.Classes.sorcerer,
            },
        },
        new()
        {
            ID = Library.Spells.main_du_mage,
            Level = 0,
            Classes = new()
            {
                Library.Classes.sorcerer,
                Library.Classes.wizard,
                Library.Archetypes.shadowblade,
            },
        },
        new()
        {
            ID = Library.Spells.mains_brulantes,
            Level = 1,
            Classes = new()
            {
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.marque_du_chasseur,
            Level = 1,
            Classes = new()
            {
                Library.Classes.ranger,
            },
        },
        new()
        {
            ID = Library.Spells.messager_animal,
            Level = 2,
            Classes = new()
            {
                Library.Classes.druid,
            },
        },
        new()
        {
            ID = Library.Spells.mot_de_guerison,
            Level = 1,
            Classes = new()
            {
                Library.Classes.cleric,
            },
        },
        new()
        {
            ID = Library.Spells.nappe_de_brouillard,
            Level = 1,
            Classes = new()
            {
                Library.Classes.druid,
                Library.Classes.sorcerer,
                Library.Classes.ranger,
            },
        },
        new()
        {
            ID = Library.Spells.passage_sans_traces,
            Level = 2,
            Classes = new()
            {
                Library.Classes.druid,
            },
        },
        new()
        {
            ID = Library.Spells.pattes_d_araignee,
            Level = 2,
            Classes = new()
            {
                Library.Classes.sorcerer,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.peau_d_ecorce,
            Level = 2,
            Classes = new()
            {
                Library.Classes.druid,
            },
        },
        new()
        {
            ID = Library.Spells.poigne_electrique,
            Level = 0,
            Classes = new()
            {
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.poison_naturel,
            Level = 1,
            Classes = new()
            {
                Library.Archetypes.shadowblade,
            },
        },
        new()
        {
            ID = Library.Spells.porte_bonheur,
            Level = 0,
            Classes = new()
            {
                Library.Classes.sorcerer,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.prestidigitation,
            Level = 0,
            Classes = new()
            {
                Library.Classes.wizard,
                Library.Archetypes.shadowblade,
            },
        },
        new()
        {
            ID = Library.Spells.priere_de_soins,
            Level = 2,
            Classes = new()
            {
                Library.Classes.cleric,
            },
        },
        new()
        {
            ID = Library.Spells.produire_une_flamme,
            Level = 0,
            Classes = new()
            {
                Library.Classes.druid,
            },
        },
        new()
        {
            ID = Library.Spells.projectile_magique,
            Level = 1,
            Classes = new()
            {
                Library.Classes.sorcerer,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.protection_contre_le_poison,
            Level = 2,
            Classes = new()
            {
                Library.Classes.druid,
            },
        },
        new()
        {
            ID = Library.Spells.purification_de_la_nourriture_et_de_l_eau,
            Level = 1,
            Classes = new()
            {
                Library.Classes.druid,
            },
        },
        new()
        {
            ID = Library.Spells.rayon_affaiblissant,
            Level = 2,
            Classes = new()
            {
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.rayon_ardent,
            Level = 2,
            Classes = new()
            {
                Library.Classes.sorcerer,
            },
        },
        new()
        {
            ID = Library.Spells.rayon_de_givre,
            Level = 0,
            Classes = new()
            {
                Library.Classes.sorcerer,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.rayon_de_lune,
            Level = 2,
            Classes = new()
            {
                Library.Classes.druid,
            },
        },
        new()
        {
            ID = Library.Spells.reparation,
            Level = 0,
            Classes = new()
            {
                Library.Classes.cleric,
            },
        },
        new()
        {
            ID = Library.Spells.restauration_inferieure,
            Level = 2,
            Classes = new()
            {
                Library.Classes.cleric,
                Library.Classes.druid,
            },
        },
        new()
        {
            ID = Library.Spells.sanctuaire,
            Level = 1,
            Classes = new()
            {
                Library.Classes.cleric,
            },
        },
        new()
        {
            ID = Library.Spells.saut,
            Level = 1,
            Classes = new()
            {
                Library.Archetypes.shadowblade,
            },
        },
        new()
        {
            ID = Library.Spells.silence,
            Level = 2,
            Classes = new()
            {
                Library.Classes.cleric,
            },
        },
        new()
        {
            ID = Library.Spells.soin_des_blessures,
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
            ID = Library.Spells.sommeil,
            Level = 1,
            Classes = new()
            {
                Library.Classes.sorcerer,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.sphere_de_feu,
            Level = 2,
            Classes = new()
            {
                Library.Classes.druid,
            },
        },
        new()
        {
            ID = Library.Spells.stalagmites_fulgurantes,
            Level = 2,
            Classes = new()
            {
                Library.Classes.sorcerer,
            },
        },
        new()
        {
            ID = Library.Spells.suggestion,
            Level = 2,
            Classes = new()
            {
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.tenebres,
            Level = 2,
            Classes = new()
            {
                Library.Classes.sorcerer,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.toile_d_araignee,
            Level = 2,
            Classes = new()
            {
                Library.Classes.sorcerer,
                Library.Classes.wizard,
            },
        },
        new()
        {
            ID = Library.Spells.trait_de_feu,
            Level = 0,
            Classes = new()
            {
                Library.Classes.sorcerer,
            },
        },
        new()
        {
            ID = Library.Spells.vague_tonnante,
            Level = 1,
            Classes = new()
            {
                Library.Classes.druid,
            },
        },
    };
    public IReadOnlyDictionary<string, SpellDatum> _spellsDataMap = null;
    public IReadOnlyDictionary<string, SpellDatum> SpellsData => _spellsDataMap ??= _spellsData.ToDictionary(s => s.ID, s => s);
}*/
