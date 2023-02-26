// See https://aka.ms/new-console-template for more information

using ICSharpCode.Decompiler.Util;
using MauiApp3;
using System.Text.Json;
using SRD5Importer.Open5e;

SRD.ExtractSpells();

return;

var json = File.ReadAllText(@"sortsInitiation.json");
var options = new JsonSerializerOptions();
options.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
//options.Converters.Add(new JsonStringEnumConverter());
options.Converters.Add(new RollJsonConverter());
var spells = JsonSerializer.Deserialize<MauiApp3.Spell[]>(json, options);

using (ResXResourceWriter resx = new ResXResourceWriter(@"Spells.resx"))
{
    foreach (var spell in spells)
    {
        spell.AddToResource(resx);
    }
}

using (var spellsStream = File.CreateText(@"SpellsData.cs"))
{
    spellsStream.Write($@"using Library = RolenPlay.Resources.Library;
namespace RolenPlay;
public partial class DataService
{{
    private IReadOnlyList<SpellDatum> _spellsData = new List<SpellDatum>
    {{");

    foreach (var spell in spells)
    {
        spellsStream.Write(spell.ToCSharp());
        /*spellsStream.Write($@"
        new()
        {{
            ID = Library.Spells.{spell.ID.Replace("-", "_")},
            Level = {spell.Level},
            Classes = new()
            {{");
        foreach (var cl in spell.classes)
        {
            //spellsStream.WriteLine($"                ClassID.{cl.Substring(0,1).ToUpper() + cl.Substring(1)},");
            if (cl == "shadowblade")
            {
                spellsStream.Write($@"
                Library.Archetypes.{cl.ToLower()},");
            }
            else
            {
                spellsStream.Write($@"
                Library.Classes.{cl.ToLower()},");
            }
        }
        spellsStream.Write($@"
            }},
        }},");*/
    }

    spellsStream.Write($@"
    }};
    public IReadOnlyDictionary<string, SpellDatum> _spellsDataMap = null;
    public IReadOnlyDictionary<string, SpellDatum> SpellsData => _spellsDataMap ??= _spellsData.ToDictionary(s => s.ID, s => s);
}}");
}
/*
// Instantiate an Automobile object.
Automobile car1 = new Automobile("Ford", "Model N", 1906, 0, 4);
    Automobile car2 = new Automobile("Ford", "Model T", 1909, 2, 4);
    // Define a resource file named CarResources.resx.
    
    using (ResXResourceWriter resx = new ResXResourceWriter(@".\CarResources.resx"))
    {
    var truc = new System.Collections.Specialized.ListDictionary();
    truc.Add("machin", "chose");
    truc.Add("bidule", "truc");
    truc.Add("encore", "un");
    resx.AddResource("test", truc);
        resx.AddResource("Title", "Classic American Cars");
        resx.AddResource("HeaderString1", "Make");
        resx.AddResource("HeaderString2", "Model");
        resx.AddResource("HeaderString3", "Year");
        resx.AddResource("HeaderString4", "Doors");
        resx.AddResource("HeaderString5", "Cylinders");
        resx.AddResource("Information", SystemIcons.Information);
        resx.AddResource("EarlyAuto1", car1);
        resx.AddResource("EarlyAuto2", car2);
    }
*/
/*
var yaml = System.IO.File.ReadAllText(@"C:\Users\fr19960\source\repos\MauiApp3\ConsoleApp1\equipment.yaml");
var truc = new Test().TestTest(yaml);
foreach(var equipment in truc)
{
    var key = equipment.Key;
    var value = equipment.Value;
    Console.WriteLine($"[\"{key}\"] = new Equipment");
    Console.WriteLine("{");
    Console.WriteLine($"Name = \"{value.Name}\",");
    Console.WriteLine($"Type = EquipmentType.{value.Type},");
    Console.WriteLine($"Description = \"{value.Description}\",");
    Console.WriteLine($"Weight = \"{value.Weight}\",");
    Console.WriteLine($"Cost = \"{value.Cost}\",");
    Console.WriteLine($"Quantity = \"{value.Quantity}\",");
    Console.WriteLine($"MeleeDamage = \"{value.MeleeDamage}\",");
    Console.WriteLine($"VersatileDamage = \"{value.VersatileDamage}\",");
    Console.WriteLine($"RangeDamage = \"{value.RangeDamage}\",");
    Console.WriteLine($"ThrowingDamage = \"{value.ThrowingDamage}\",");
    Console.WriteLine($"WeaponAbility = \"{value.WeaponAbility}\",");
    Console.WriteLine($"HandCount = \"{value.HandCount}\",");
    Console.WriteLine($"Heaviness = \"{value.Heaviness}\",");
    Console.WriteLine($"ArmorClass = \"{value.ArmorClass}\",");
    Console.WriteLine($"ArmorClassModifier = \"{value.ArmorClassModifier}\",");
    Console.WriteLine($"UseDexterityModifier = \"{value.UseDexterityModifier}\",");
    Console.WriteLine($"MaxDexterityModifier = \"{value.MaxDexterityModifier}\",");
    Console.WriteLine($"Strength = \"{value.Strength}\",");
    Console.WriteLine($"StealthDisadvantage = \"{value.StealthDisadvantage}\",");
    Console.WriteLine("},");
}
Console.WriteLine(truc);
*/
