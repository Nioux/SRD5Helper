using SRD5Helper.DataModels;
using Library = SRD5Helper.Resources.Library;

namespace SRD5Helper.Data;

public partial class DataService
{
    private IReadOnlyList<LanguageDatum> _languageData = new List<LanguageDatum>
    {
        new()
        {
            ID = Library.Languages.commun,
        },
        new()
        {
            ID = Library.Languages.elfe,
        },
        new()
        {
            ID = Library.Languages.geant,
        },
        new()
        {
            ID = Library.Languages.gnome,
        },
        new()
        {
            ID = Library.Languages.gobelin,
        },
        new()
        {
            ID = Library.Languages.halfelin,
        },
        new()
        {
            ID = Library.Languages.nain,
        },
        new()
        {
            ID = Library.Languages.orc,
        },
        new()
        {
            ID = Library.Languages.abyssal,
        },
        new()
        {
            ID = Library.Languages.celeste,
        },
        new()
        {
            ID = Library.Languages.commun_des_profondeurs,
        },
        new()
        {
            ID = Library.Languages.draconique,
        },
        new()
        {
            ID = Library.Languages.infernal,
        },
        new()
        {
            ID = Library.Languages.primordial,
        },
        new()
        {
            ID = Library.Languages.noir_parler,
        },
        new()
        {
            ID = Library.Languages.sseslish,
        },
        new()
        {
            ID = Library.Languages.sylvestre,
        },
    };
    public IReadOnlyDictionary<string, LanguageDatum> _languagesDataMap = null;
    public IReadOnlyDictionary<string, LanguageDatum> LanguagesData => _languagesDataMap ??= _languageData.ToDictionary(s => s.ID, s => s);
}