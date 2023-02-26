using SRD5Helper.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library = SRD5Helper.Resources.Library;

namespace SRD5Helper.DataModels;

public struct SubBackgroundDatum
{
    public string ID { get; init; }
    private string _name;
    public string Name { get => _name ??= Library.SubBackgrounds.ResourceManager.GetName(ID); init => _name = value; }
    public string _description;
    public string Description { get => _description ??= Library.SubBackgrounds.ResourceManager.GetDescription(ID); init => _description = value; }

}
public struct BackgroundDatum
{
    public string ID { get; init; }
    private string _name;
    public string Name { get => _name ??= Library.Backgrounds.ResourceManager.GetName(ID); init => _name = value; }
    public string _description;
    public string Description { get => _description ??= Library.Backgrounds.ResourceManager.GetDescription(ID); init => _description = value; }

    public SkillID[] SkillsProficiencies { get; init; }
    public SkillID[] SkillsProficienciesChoices { get; init; }
    public string[] ToolsProficienciesChoices { get; init; }
    public string[] LanguagesChoices { get; init; }
    public string[] InitialEquipment { get; init; }
    public Money InitialMoney { get; init; }

}
