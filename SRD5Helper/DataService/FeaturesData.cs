using SRD5Helper.DataModels;
using Library = SRD5Helper.Resources.Library;

namespace SRD5Helper.Data;

public partial class DataService
{
    private IReadOnlyList<FeatureDatum> _featureData = new List<FeatureDatum>
    {
        // Origin Traits

        new()
        {
            ID = Library.Features.acharnement,
            Rules = new[]
            {
                Library.Rules.acharnement,
            },
        },
        new()
        {
            ID = Library.Features.agilite_feline,
        },
        new()
        {
            ID = Library.Features.agilite_halfeline,
        },
        new()
        {
            ID = Library.Features.ascendance_draconique,
        },
        new()
        {
            ID = Library.Features.ascendance_feerique,
        },
        new()
        {
            ID = Library.Features.ascendance_infernale,
        },
        new()
        {
            ID = Library.Features.ancetre_fielon,
        },
        new()
        {
            ID = Library.Features.brave,
        },
        new()
        {
            ID = Library.Features.chanceux,
        },
        new()
        {
            ID = Library.Features.connaissance_de_la_pierre,
        },
        new()
        {
            ID = Library.Features.difficile_a_croire,
        },
        new()
        {
            ID = Library.Features.discretion_naturelle,
        },
        new()
        {
            ID = Library.Features.entrainement_aux_armes_elfiques,
            Rules = new[]
            {
                Library.Rules.maitrise_epee_longue,
                Library.Rules.maitrise_epee_courte,
                Library.Rules.maitrise_arc_long,
                Library.Rules.maitrise_arc_court,
            },
        },
        new()
        {
            ID = Library.Features.entrainement_aux_armes_naines,
            Rules = new[]
            { 
                Library.Rules.maitrise_hachette,
                Library.Rules.maitrise_hache_a_deux_mains,
                Library.Rules.maitrise_hache_d_armes,
                Library.Rules.maitrise_marteau_de_guerre,
                Library.Rules.maitrise_marteau_leger,
            },
        },
        new()
        {
            ID = Library.Features.griffes_du_fauve,
        },
        new()
        {
            ID = Library.Features.langue_supplementaire,
        },
        new()
        {
            ID = Library.Features.maitrise_des_outils,
        },
        new()
        {
            ID = Library.Features.menacant,
        },
        new()
        {
            ID = Library.Features.polyvalence,
        },
        new()
        {
            ID = Library.Features.projection_spirituelle,
        },
        new()
        {
            ID = Library.Features.resistance_aux_degats,
            Choices = new[]
            {
                Library.Features.resistance_aux_degats_de_froid,
            }
        },
        new()
        {
            ID = Library.Features.resistance_aux_degats_de_froid,
        },
        new()
        {
            ID = Library.Features.resistance_infernale,
        },
        new()
        {
            ID = Library.Features.resistance_naine,
        },
        new()
        {
            ID = Library.Features.ruse_gnome,
        },
        new()
        {
            ID = Library.Features.sauvagerie,
        },
        new()
        {
            ID = Library.Features.sens_aiguises_elfe,
            Rules = new[]
            {
                Library.Rules.sens_aiguises_elfe,
            },
        },
        new()
        {
            ID = Library.Features.sens_aiguises_gnome_des_fees,
        },
        new()
        {
            ID = Library.Features.sixieme_sens,
        },
        new()
        {
            ID = Library.Features.souffle,
            Choices = new[]
            {
                Library.Features.souffle_argent,
            },
        },
        new()
        {
            ID = Library.Features.souffle_argent,
        },
        new()
        {
            ID = Library.Features.tenacite_naine,
            Rules = new[]
            {
                Library.Rules.tenacite_naine,
            },
        },
        new()
        {
            ID = Library.Features.toujours_sur_ses_pattes,
        },
        new()
        {
            ID = Library.Features.tour_de_magie,
        },
        new()
        {
            ID = Library.Features.transe,
        },
        new()
        {
            ID = Library.Features.vision_dans_le_noir,
        },


        // Class Features

        new()
        {
            ID = Library.Features.acces_aux_sorts_niveau_2,
        },
        new()
        {
            ID = Library.Features.amelioration_de_caracteristique,
            ChoiceCount = 2,
            Choices = new[]
            {
                Library.Features.amelioration_de_caracteristique_strength,
                Library.Features.amelioration_de_caracteristique_dexterity,
                Library.Features.amelioration_de_caracteristique_constitution,
                Library.Features.amelioration_de_caracteristique_intelligence,
                Library.Features.amelioration_de_caracteristique_wisdom,
                Library.Features.amelioration_de_caracteristique_charisma,
            },
        },
        new()
        {
            ID = Library.Features.amelioration_de_caracteristique_strength,
            Rules = new[]
            {
                Library.Rules.amelioration_de_caracteristique_strength,
            },
        },
        new()
        {
            ID = Library.Features.amelioration_de_caracteristique_dexterity,
            Rules = new[]
            {
                Library.Rules.amelioration_de_caracteristique_dexterity,
            },
        },
        new()
        {
            ID = Library.Features.amelioration_de_caracteristique_constitution,
            Rules = new[]
            {
                Library.Rules.amelioration_de_caracteristique_constitution,
            },
        },
        new()
        {
            ID = Library.Features.amelioration_de_caracteristique_intelligence,
            Rules = new[]
            {
                Library.Rules.amelioration_de_caracteristique_intelligence,
            },
        },
        new()
        {
            ID = Library.Features.amelioration_de_caracteristique_wisdom,
            Rules = new[]
            {
                Library.Rules.amelioration_de_caracteristique_wisdom,
            },
        },
        new()
        {
            ID = Library.Features.amelioration_de_caracteristique_charisma,
            Rules = new[]
            {
                Library.Rules.amelioration_de_caracteristique_charisma,
            },
        },
        new()
        {
            ID = Library.Features.archetype_de_rodeur,
        },
        new()
        {
            ID = Library.Features.archetype_de_roublard,
        },
        new()
        {
            ID = Library.Features.argot_des_voleurs,
        },
        new()
        {
            ID = Library.Features.attaque_sournoise,
        },
        new()
        {
            ID = Library.Features.canalisation_d_energie_divine,
        },
        new()
        {
            ID = Library.Features.cercle_druidique,
        },
        new()
        {
            ID = Library.Features.chatiment_divin,
        },
        new()
        {
            ID = Library.Features.critique_ameliore,
        },
        new()
        {
            ID = Library.Features.defense_sans_armure,
        },
        new()
        {
            ID = Library.Features.domaine_d_influence_vie_soins,
            Rules = new[]
            {
                Library.Rules.expertise_vie_soins,
            },
        },
        new()
        {
            ID = Library.Features.druidique,
        },
        new()
        {
            ID = Library.Features.enfant_de_l_ombre,
        },
        new()
        {
            ID = Library.Features.enfant_des_tenebres,
        },
        new()
        {
            ID = Library.Features.ennemi_jure,
            Choices = new[]
            {
                Library.Features.ennemi_jure_mort_vivants,
            },
        },
        new()
        {
            ID = Library.Features.ennemi_jure_mort_vivants,
        },
        new()
        {
            ID = Library.Features.expertise,
        },
        new()
        {
            ID = Library.Features.expertise_rogue,
            ChoiceCount = 2,
            Choices = new[]
            {
                Library.Features.expertise_discretion,
                Library.Features.expertise_supercherie,
                Library.Features.expertise_outils_de_voleur,
            },
        },
        new()
        {
            ID = Library.Features.explorateur_ne,
            Choices = new[]
            {
                //Library.Features.explorateur_ne_arctique,
                //Library.Features.explorateur_ne_littoral,
                //Library.Features.explorateur_ne_desert,
                Library.Features.explorateur_ne_foret,
                //Library.Features.explorateur_ne_plaine,
                //Library.Features.explorateur_ne_montagne,
                //Library.Features.explorateur_ne_marais,
            }
        },
        //new()
        //{
        //    ID = Library.Features.explorateur_ne_arctique,
        //},
        //new()
        //{
        //    ID = Library.Features.explorateur_ne_littoral,
        //},
        //new()
        //{
        //    ID = Library.Features.explorateur_ne_desert,
        //},
        new()
        {
            ID = Library.Features.explorateur_ne_foret,
        },
        //new()
        //{
        //    ID = Library.Features.explorateur_ne_plaine,
        //},
        //new()
        //{
        //    ID = Library.Features.explorateur_ne_montagne,
        //},
        //new()
        //{
        //    ID = Library.Features.explorateur_ne_marais,
        //},
        new()
        {
            ID = Library.Features.fleche_arcanique,
        },
        new()
        {
            ID = Library.Features.forme_monstrueuse,
        },
        new()
        {
            ID = Library.Features.forme_sauvage,
        },
        new()
        {
            ID = Library.Features.forme_sauvage_amelioree,
        },
        new()
        {
            ID = Library.Features.grimoire_plus_2_sorts,
        },
        new()
        {
            ID = Library.Features.imposition_des_mains,
        },
        new()
        {
            ID = Library.Features.incantations,
        },
        new()
        {
            ID = Library.Features.initie,
        },
        new()
        {
            ID = Library.Features.inspiration_bardique_d6,
        },
        new()
        {
            ID = Library.Features.mains_lestes,
        },
        new()
        {
            ID = Library.Features.maitrise_des_elements,
        },
        new()
        {
            ID = Library.Features.expertise_discretion,
            Rules = new[]
            {
                Library.Rules.expertise_discretion,
            },
        },
        new()
        {
            ID = Library.Features.expertise_outils_de_voleur,
            Rules = new string[]
            {

            },
        },
        new()
        {
            ID = Library.Features.expertise_supercherie,
            Rules = new[]
            {
                Library.Rules.expertise_supercherie,
            },
        },
        new()
        {
            ID = Library.Features.maitrise_armures,
            Rules = new[]
            {
                Library.Rules.maitrise_armures,
                /*new FuncRule
                {
                    Name = Library.Features.maitrise_armures,
                    Description = (self, sender) => Library.Features.trucmuche,
                    TargetObjectType = typeof(PlayerCharacter),
                    TargetPropertyName = nameof(PlayerCharacter.ArmorProficiency),
                    CustomCondition = (self, sender) => sender.PC.Armor != null,
                    BoolCallback = True,
                }*/
            }
        },
        new()
        {
            ID = Library.Features.metamagie,
            Choices = new[]
            {
                //Library.Features.metamagie_invocation_prudente,
                Library.Features.metamagie_sort_distant,
                //Library.Features.metamagie_sort_puissant,
                //Library.Features.metamagie_sort_etendu,
                //Library.Features.metamagie_sort_intense,
                //Library.Features.metamagie_sort_accelere,
                //Library.Features.metamagie_sort_subtil,
                Library.Features.metamagie_sort_jumeau,
            },
        },
        new()
        {
            ID = Library.Features.metamagie_sort_distant,
        },
        new()
        {
            ID = Library.Features.metamagie_sort_jumeau,
        },
        new()
        {
            ID = Library.Features.monte_en_l_air,
        },
        new()
        {
            ID = Library.Features.ombrelame,
        },
        new()
        {
            ID = Library.Features.origine_magique,
            Choices = new[]
            {
                //Library.Features.origine_magique_draconique, 
                //Library.Features.origine_magique_celeste, 
                //Library.Features.origine_magique_feerique,
                Library.Features.resistance_des_fielons,
            },
        },
        new()
        {
            ID = Library.Features.resistance_des_fielons,
            //Implies = new[]
            //{
            //    Library.Features.ancetre_fielon,
            //    Library.Features.resistance_des_fielons,
            //},
        },
        new()
        {
            ID = Library.Features.points_de_sorcellerie,
        },
        new()
        {
            ID = Library.Features.rage,
        },
        new()
        {
            ID = Library.Features.renvoi_des_morts_vivants,
        },
        new()
        {
            ID = Library.Features.restauration_magique,
        },
        new()
        {
            ID = Library.Features.ruse,
        },
        new()
        {
            ID = Library.Features.salve_de_guerison,
        },
        new()
        {
            ID = Library.Features.sante_divine,
        },
        new()
        {
            ID = Library.Features.second_souffle,
        },
        new()
        {
            ID = Library.Features.sens_divin,
        },
        new()
        {
            ID = Library.Features.serment_sacre,
        },
        new()
        {   // Incantations ??
            ID = Library.Features.sortileges,
        },
        new()
        {   // Incantations ??
            ID = Library.Features.sorts,
        },
        new()
        {
            ID = Library.Features.style_de_combat,
            // TODO: choisir un style de combat
            Choices = new[]
            {
                Library.Features.style_de_combat_archerie,
                Library.Features.style_de_combat_armes_a_deux_mains,
                Library.Features.style_de_combat_defense,
            },
        },
        new()
        {
            ID = Library.Features.style_de_combat_archerie,
            Rules = new[]
            {
                Library.Features.style_de_combat_archerie,
            },
        },
        new()
        {
            ID = Library.Features.style_de_combat_armes_a_deux_mains,
        },
        new()
        {
            ID = Library.Features.style_de_combat_defense,
            Rules = new[]
            {
                Library.Features.style_de_combat_defense,
            },
        },
        new()
        {
            ID = Library.Features.sursaut_d_activite,
        },
        new()
        {
            ID = Library.Features.vigilance_primitive,
        },

    };

    private IReadOnlyDictionary<string, FeatureDatum> _featuresDataMap = null;
    public IReadOnlyDictionary<string, FeatureDatum> FeaturesData => _featuresDataMap ??= _featureData.ToDictionary(s => s.ID, s => s);
}
