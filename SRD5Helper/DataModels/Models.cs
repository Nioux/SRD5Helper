
using YamlDotNet.Serialization;

namespace SRD5Helper.DataModels;

public class GenderedName
{
    public string Name { get; init; }
    public string FemaleName { get; init; }
    public string MaleName { get; init; }
    public string NeutralName { get; init; }
    public string InclusiveName {  get; init; }
    public string GetDisplayName(GenderID gender)
    {
        var name = Name;
        switch(gender)
        {
            case GenderID.Female:
                name = FemaleName ?? name;
                break;
            case GenderID.Male:
                name = MaleName ?? name;
                break;
            case GenderID.Neutral:
                name = NeutralName ?? name;
                break;
            case GenderID.Inclusive:
                name = InclusiveName ?? name;
                break;
        }
        return name;
    }
    public static implicit operator GenderedName(string x) { return new GenderedName { Name = x}; }

    public static implicit operator string(GenderedName x) { return x?.Name; }

    public override string ToString()
    {
        return Name;
    }

}
