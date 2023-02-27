using ICSharpCode.Decompiler.Util;
using MauiApp3;
using System.Text.Json;
using System.Xml.Linq;

namespace SRD5Importer.Open5e;

public struct Spell
{
    public string slug { get; set; }
    public string name { get; set; }
    public string desc { get; set; }
    public string higher_level { get; set; }
    public string page { get; set; }
    public string range { get; set; }
    public string components { get; set; }
    public string material { get; set; }
    public string ritual { get; set; }
    public string duration { get; set; }
    public string concentration { get; set; }
    public string casting_time { get; set; }
    public string level { get; set; }
    public int level_int { get; set; }
    public string school { get; set; }
    public string dnd_class { get; set; }
    public string archetype { get; set; }
    public string circles { get; set; }
    public string document__slug { get; set; }
    public string document__title { get; set; }
    public string document__license_url { get; set; }

    public string ToCSharp()
    {
        var result = $@"
        new()
        {{
            ID = Library.Spells.{slug.Replace("-", "_")},
            Level = {level_int},
            Classes = new()
            {{";
        var classes = this.dnd_class.Split(", ");
        foreach (var cl in classes)
        {
            if (!cl.Equals("Ritual Caster"))
            {
                result += $@"
                Library.Classes.{cl.Replace(" ", "_").ToLower()},";
            }
        }
        result += $@"
            }},
        }},";

        return result;
    }

    public void AddToResource(ResXResourceWriter resx)
    {
        resx.AddResource(slug, slug);
        resx.AddResource(slug + "-name", name);
        resx.AddResource(slug + "-description", desc);
        //resx.AddResource(slug + "-details", Body.ToString());
    }

}


public static class SRD
{
    public static void ExtractSpells()
    {
        var json = File.ReadAllText(@"spells_srd.json");
        var options = new JsonSerializerOptions();
        //options.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
        ////options.Converters.Add(new JsonStringEnumConverter());
        //options.Converters.Add(new RollJsonConverter());
        var spells = JsonSerializer.Deserialize<Spell[]>(json, options);
        using (ResXResourceWriter resx = new ResXResourceWriter(@"Spells.resx"))
        {
            foreach (var spell in spells)
            {
                spell.AddToResource(resx);
            }
        }

        using (var spellsStream = File.CreateText(@"SpellsData.cs"))
        {
            spellsStream.Write($@"using SRD5Helper.DataModels;
using Library = SRD5Helper.Resources.Library;
namespace SRD5Helper.Data;
public partial class DataService
{{
    private IReadOnlyList<SpellDatum> _spellsData = new List<SpellDatum>
    {{");

            foreach (var spell in spells)
            {
                spellsStream.Write(spell.ToCSharp());
            }

            spellsStream.Write($@"
    }};
    public IReadOnlyDictionary<string, SpellDatum> _spellsDataMap = null;
    public IReadOnlyDictionary<string, SpellDatum> SpellsData => _spellsDataMap ??= _spellsData.ToDictionary(s => s.ID, s => s);
}}");
        }

    }
}