using SRD5Helper.Tools;
using Library = SRD5Helper.Resources.Library;

namespace SRD5Helper.DataModels;

public struct LanguageDatum
{
    public string ID { get; init; }
    private GenderedName _genderedName;
    public GenderedName GenderedName
    {
        get => _genderedName ??=
            new GenderedName
            {
                Name = Library.Languages.ResourceManager.GetName(ID),
                FemaleName = Library.Languages.ResourceManager.GetFName(ID),
                MaleName = Library.Languages.ResourceManager.GetMName(ID),
                NeutralName = Library.Languages.ResourceManager.GetNName(ID),
                InclusiveName = Library.Languages.ResourceManager.GetIName(ID),
            }; init => _genderedName = value;
    }
    public string _description;
    public string Description { get => _description ??= Library.Languages.ResourceManager.GetDescription(ID); init => _description = value; }
}
