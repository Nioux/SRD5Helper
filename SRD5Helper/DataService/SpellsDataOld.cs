using SRD5Helper.DataModels;
using System.Diagnostics;
using YamlDotNet.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Runtime.Serialization;

namespace SRD5Helper.Data;

public partial class DataService
{
    //public async Task<IReadOnlyDictionary<string, SpellDatum>> LoadSpellsAsync()
    //{
    //    try
    //    {
    //        //                var filePath = "Resources/Library/arme-spirituelle.md";
    //        //#if ANDROID
    //        //                using var stream = await Microsoft.Maui.Essentials.FileSystem.OpenAppPackageFileAsync(filePath);
    //        //#else
    //        //                using var stream = await Microsoft.Maui.Essentials.FileSystem.OpenAppPackageFileAsync("Assets/" + filePath);

    //        //#endif
    //        //                //using var stream = await Microsoft.Maui.Essentials.FileSystem.OpenAppPackageFileAsync("MauiResources/Library/arme-spirituelle.md");
    //        //                var buffer = new byte[stream.Length];
    //        //                await stream.ReadAsync(buffer);
    //        //                Debug.WriteLine(buffer.Length);
    //        //                var yamlmd = Encoding.UTF8.GetString(buffer, 0, buffer.Length); //Convert.ToString(buffer);

    //        try
    //        {
    //            //var json = await Serializers.GetResourceAsStringAsync("sortsBI_retouchee.json");
    //            var json = await Serializers.GetResourceAsStringAsync("sortsInitiation.json");
    //            var objSpells = JsonSerializer.Deserialize<List<SpellDatum>>(json, 
    //                new JsonSerializerOptions { 
    //                    PropertyNameCaseInsensitive = true,
    //                    Converters =
    //                    {
    //                        //new JsonStringEnumConverter(JsonNamingPolicy.CamelCase),
    //                        new JsonStringEnumMemberConverter(options: new JsonStringEnumMemberConverterOptions(JsonNamingPolicy.CamelCase))
    //                    }
    //                });

    //            SpellsDataOld = objSpells.ToDictionary(s => s.ID, s => s);


    //            /*
    //            var yamlmd = await Serializers.GetResourceAsStringAsync("Library/amitie-avec-les-animaux.md");
    //            var objmd = Serializers.ToObjectMarkdown<Spell>(yamlmd);
    //            var spell = objmd.Object;

    //            var yamlmd2 = await Serializers.GetResourceAsStringAsync("Library/arme-spirituelle.md");
    //            var objmd2 = Serializers.ToObjectMarkdown<Spell>(yamlmd2);
    //            var spell2 = objmd2.Object;

    //            var y = Serializers.ToYaml(spell2);*/
    //            /*Spellbook = new Dictionary<string, Spell>
    //            {
    //                [spell.Title] = spell,
    //                [spell2.Title] = spell2
    //            };*/
    //        }
    //        catch(Exception ex)
    //        {
    //            Debug.WriteLine(ex);
    //        }
    //        return SpellsData;

    //        /*                var pipeline = new MarkdownPipelineBuilder()
    //                            .UseYamlFrontMatter()
    //                            .UsePipeTables()
    //                            .Build();
    //                        var markdown = Markdig.Parsers.MarkdownParser.Parse(yamlmd, pipeline);
    //                        var yamlBlock = markdown.Descendants<YamlFrontMatterBlock>().FirstOrDefault();

    //                        if (yamlBlock != null)
    //                        {
    //                            string yaml = yamlmd.Substring(yamlBlock.Span.Start + 4, yamlBlock.Span.Length - 8);

    //                            Debug.WriteLine(yaml);
    //                            var deserializer = new DeserializerBuilder()
    //                                .IgnoreUnmatchedProperties()
    //                                .Build();
    //                            //var deserializer = new YamlDotNet.Serialization.Deserializer();
    //                            var spell = deserializer.Deserialize<Spell>(yaml);
    //                            Debug.WriteLine(spell.Title);


    //                            var storage = Ioc.Default.GetRequiredService<StorageService>();
    //                            var serializer = new SerializerBuilder()
    //                                .IncludeNonPublicProperties()
    //                                //.NullValueHandling = NullValueHandling.Ignore,
    //                                //DefaultValueHandling = DefaultValueHandling.Ignore,                        
    //                                .Build();
    //                            var pc = storage.EquipmentStore["shortbow"];
    //                            var bowyaml = serializer.Serialize(pc);
    //                            Debug.WriteLine(bowyaml);

    //                            return new Dictionary<string, Spell> { [spell.Title] = spell };
    //                        }*/
    //    }
    //    catch (Exception ex)
    //    {
    //        Debug.WriteLine(ex);
    //    }
    //    return new Dictionary<string, SpellDatum> { };
    //    //Microsoft.Maui.Essentials.OpenPackageFileAsync()
    //}
    //public IReadOnlyDictionary<string, SpellDatum> SpellsDataOld { get; private set; }
}
