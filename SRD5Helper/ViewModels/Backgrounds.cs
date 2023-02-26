using SRD5Helper.DataModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using YamlDotNet.Serialization;

namespace SRD5Helper.ViewModels;

public class Background : DatumReference<string, BackgroundDatum>
{
    public Background() { }
    public Background(string _ref) { ID = _ref; }
    //public static implicit operator Background(string x) { return new Background(x); }
    public override BackgroundDatum Datum => Property.Calculated(() => BackgroundsData[ID]);

    public string SubBackgroundID { get => Property.Get<string>(() => null); init => Property.Set(value); }

    [YamlIgnore, JsonIgnore]
    public SubBackgroundDatum? SubBackgroundDatum => Property.Calculated<SubBackgroundDatum?>(() => SubBackgroundID != null ? SubBackgroundsData[SubBackgroundID] : null);

    private IReadOnlySet<SkillID> _selectedSkillProficiencies = null;

    [YamlIgnore, JsonIgnore]
    public IReadOnlySet<SkillID> SelectedSkillProficiencies => Property.Calculated(() => _selectedSkillProficiencies ??= Datum.SkillsProficiencies.ToHashSet());
}
