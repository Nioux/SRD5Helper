using SRD5Helper.DataModels;
using Library = SRD5Helper.Resources.Library;

namespace SRD5Helper.Data;

public partial class DataService
{
    private IReadOnlyList<OriginDatum> _originData = new List<OriginDatum>
    {
        new()
        {
            ID = Library.Origins.dwarf,
            ConstitutionBonus = 2,
            WisdomBonus = 1,
            Traits = new()
            {
                Library.Features.vision_dans_le_noir,
                Library.Features.resistance_naine,
                Library.Features.entrainement_aux_armes_naines,
                Library.Features.maitrise_des_outils,
                Library.Features.connaissance_de_la_pierre,
                Library.Features.tenacite_naine,
            },
            Languages = new()
            {
                Library.Languages.commun,
                Library.Languages.nain,
            },
        },
        new()
        {
            ID = Library.Origins.elf,
            DexterityBonus = 2,
            IntelligenceBonus = 1,
            Traits = new()
            {
                Library.Features.vision_dans_le_noir,
                Library.Features.sens_aiguises_elfe,
                Library.Features.ascendance_feerique,
                Library.Features.transe,
                Library.Features.entrainement_aux_armes_elfiques,
                Library.Features.tour_de_magie,
                Library.Features.langue_supplementaire,
            },
            Languages = new()
            {
                Library.Languages.commun,
                Library.Languages.elfe,
            },
        },
        new()
        {
            ID = Library.Origins.halfling,
            DexterityBonus = 2,
            CharismaBonus = 1,
            Traits = new()
            {
                Library.Features.chanceux,
                Library.Features.brave,
                Library.Features.agilite_halfeline,
                Library.Features.discretion_naturelle,
            },
            Languages = new()
            {
                Library.Languages.commun,
                Library.Languages.halfelin,
            },
        },
        new()
        {
            ID = Library.Origins.human,
            StrengthBonus = 1,
            DexterityBonus = 1,
            ConstitutionBonus = 1,
            IntelligenceBonus = 1,
            WisdomBonus = 1,
            CharismaBonus = 1,
            Traits = new()
            {

            },
            Languages = new()
            {
                Library.Languages.commun,
            }
        },
        new()
        {
            ID = Library.Origins.dragonborn,
            StrengthBonus = 2,
            CharismaBonus = 1,
            Traits = new()
            {
                Library.Features.ascendance_draconique,
                Library.Features.souffle,
                Library.Features.resistance_aux_degats,
            },
            Languages = new()
            {
                Library.Languages.commun,
                Library.Languages.draconique,
            }
        },
        new()
        {
            ID = Library.Origins.gnome,
            IntelligenceBonus = 1,
            DexterityBonus = 2,
            Traits = new()
            {
                Library.Features.vision_dans_le_noir,
                Library.Features.ruse_gnome,
                Library.Features.sens_aiguises_gnome_des_fees,
                Library.Features.projection_spirituelle,
            },
            Languages = new()
            {
                Library.Languages.commun,
                Library.Languages.gnome,
            },
        },
        new()
        {
            ID = Library.Origins.halfelf,
            CharismaBonus = 2,
            AdditionalBonuses = 2,
            Traits = new()
            {
                Library.Features.vision_dans_le_noir,
                Library.Features.ascendance_feerique,
                Library.Features.polyvalence,
            },
            Languages = new()
            {
                Library.Languages.commun,
                Library.Languages.elfe,
            },
            AdditionalLanguages = 1,
        },
        new()
        {
            ID = Library.Origins.halforc,
            StrengthBonus = 2,
            ConstitutionBonus = 1,
            Traits = new()
            {
                Library.Features.vision_dans_le_noir,
                Library.Features.menacant,
                Library.Features.acharnement,
                Library.Features.sauvagerie,
            },
            Languages = new()
            {
                Library.Languages.commun,
                Library.Languages.orc,
            }
        },
        new()
        {
            ID = Library.Origins.tiefling,
            CharismaBonus = 2,
            IntelligenceBonus = 1,
            Traits = new()
            {
                Library.Features.vision_dans_le_noir,
                Library.Features.resistance_infernale,
                Library.Features.ascendance_infernale,
            },
            Languages = new()
            {
                Library.Languages.commun,
                Library.Languages.infernal,
            }
        },
        new()
        {
            ID = Library.Origins.felys,
            DexterityBonus = 2,
            WisdomBonus = 1,
            Traits = new()
            {
                Library.Features.vision_dans_le_noir,
                Library.Features.sixieme_sens,
                Library.Features.agilite_feline,
                Library.Features.griffes_du_fauve,
                Library.Features.toujours_sur_ses_pattes,
                Library.Features.difficile_a_croire,
            },
            Languages = new()
            {
                Library.Languages.commun,
            },
            AdditionalLanguages = 1,
        },
    };

    private IReadOnlyDictionary<string, OriginDatum> _originsDataMap = null;
    public IReadOnlyDictionary<string, OriginDatum> OriginsData => _originsDataMap ??= _originData.ToDictionary(s => s.ID, s => s);
}
