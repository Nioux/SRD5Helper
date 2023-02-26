using SRD5Helper.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library = SRD5Helper.Resources.Library;

namespace SRD5Helper.DataModels;

public struct AbilityDatum
{
    public AbilityID ID { get; init; }
    private string _name;
    public string Name { get => _name ??= Library.Abilities.ResourceManager.GetName(ID); init => _name = value; }
    public string _description;
    public string Description { get => _description ??= Library.Abilities.ResourceManager.GetDescription(ID); init => _description = value; }
    public string _brief;
    public string Brief { get => _brief ??= Library.Abilities.ResourceManager.GetBrief(ID); init => _brief = value; }
}