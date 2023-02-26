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

public static class FeatureExtensions
{
    public static IReadOnlyList<string>[] Merge(this IReadOnlyList<string>[] features1, IReadOnlyList<string>[] features2)
    {
        if (features2 != null)
        {
            var mergedFeatures = new List<List<string>>();
            int index = 0;
            foreach (var feats1 in features1)
            {
                var feats2 = features2[index];
                mergedFeatures.Add(feats1.Concat(feats2).ToList());
                index++;
            }
            return mergedFeatures.ToArray();
        }
        return features1;
    }
}

public class Feature : DatumReference<string, FeatureDatum>
{
    public Feature() { }
    public Feature(string _id) { ID = _id; }
    //public static implicit operator Feature(string x) { return new Feature(x); }

    [YamlIgnore, JsonIgnore]
    public override FeatureDatum Datum => Property.Calculated(() => FeaturesData[ID]);
    [YamlIgnore, JsonIgnore]
    public string Name => Property.Calculated(() => Datum.Name);
    [YamlIgnore, JsonIgnore]
    public string Description => Property.Calculated(() => Datum.Description);

    public bool IsEnabled { get => Property.Get(() => true); set => Property.Set(value); }


    public int? Level { get => Property.Get<int?>(() => 1); set => Property.Set(value); }

    public ObservableCollection<string> SelectedChoices { get => Property.Get(() => new ObservableCollection<string>()); set => Property.Set(value); }

    [YamlIgnore, JsonIgnore]
    public IEnumerable<Feature> SelectedFeatures => Property.Calculated(() =>
    {
        return SelectedChoices?.Select(id => PC.Factory.CreateFeature(id: id, level: Level, isEnabled: IsEnabled)) ?? new List<Feature>();
    });

    public IEnumerable<Rule> SelectedRules => Property.Calculated(() => SelectedChoices.SelectMany(id => FeaturesData[id].Rules.Select(ruleId => RulesData[ruleId]) ?? new Rule[] { }).ToList());

    [YamlIgnore, JsonIgnore]
    public IReadOnlyList<Rule> Rules => Property.Calculated(() =>
    {
        var rules = new List<Rule>();
        if (Datum.Rules != null)
        {
            rules = rules.Concat(Datum.Rules.Select(ruleId => RulesData[ruleId])).ToList();
        }
        rules = rules.Concat(SelectedRules).ToList();
        return rules.ToList();
    });
}
