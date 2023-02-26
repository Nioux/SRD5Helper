using SRD5Helper.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library = SRD5Helper.Resources.Library;

namespace SRD5Helper.DataModels;

public struct FeatureDatum
{
    public string ID { get; init; }
    private string _name;
    public string Name { get => _name ??= Library.Features.ResourceManager.GetName(ID); init => _name = value; }
    public string _description;
    public string Description { get => _description ??= Library.Features.ResourceManager.GetDescription(ID); init => _description = value; }

    public int? LongRestNeeded;
    public int? ShortRestNeeded;
    public int? RestNeeded;

    public string[] Rules { get; init; }
    //public Rule[] Rules { get; init; }

    public string[] Choices { get; init; }
    public int ChoiceCount { get; init; }
    public string[] Implies { get; init; }

    public List<string> Origins { get; init; }
    public List<string> Classes { get; init; }

    public override string ToString()
    {
        return Name;
    }
}

