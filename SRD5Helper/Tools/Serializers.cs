using Markdig;
using Markdig.Extensions.Yaml;
using Markdig.Syntax;
using SRD5Helper.DataModels;
using SRD5Helper.ViewModels;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json;
using YamlDotNet.Core;
using YamlDotNet.Core.Events;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace SRD5Helper.Tools; 
public class ObjectMarkdown<T> where T : struct
{
    public MarkdownDocument Markdown { get; set; }
    public T Object { get; set; }
}
public static class Serializers
{
    public static ObjectMarkdown<T> ToObjectMarkdown<T>(string yamlmd) where T : struct
    {
        var pipeline = new MarkdownPipelineBuilder()
            .UseYamlFrontMatter()
            .UsePipeTables()
            .Build();
        var markdown = Markdig.Parsers.MarkdownParser.Parse(yamlmd, pipeline);
        var yamlBlock = markdown.Descendants<YamlFrontMatterBlock>().FirstOrDefault();
        if (yamlBlock != null)
        {
            string yaml = yamlmd.Substring(yamlBlock.Span.Start + 4, yamlBlock.Span.Length - 8);

            Debug.WriteLine(yaml);
            var deserializer = new DeserializerBuilder()
                .WithObjectFactory(new PlayerCharacterObjectFactory())
                //.IgnoreUnmatchedProperties()
                .WithTypeConverter(new YamlStringEnumConverter())
                //.WithTypeConverter(new YamlIntegerTypeConverter())
                .WithTypeConverter(new YamlClassTypeConverter())
                .WithNamingConvention(CamelCaseNamingConvention.Instance)
                .Build();
            //var deserializer = new YamlDotNet.Serialization.Deserializer();
            var obj = deserializer.Deserialize<T>(yaml);
            //Debug.WriteLine(spell.Title);

            return new ObjectMarkdown<T> { Markdown = markdown, Object = obj };
        }
        return null;
    }


    public static string ToYaml<T>(T obj) where T: struct
    {
        var serializer = new SerializerBuilder()
            .IncludeNonPublicProperties()
            //.EnsureRoundtrip()
            .ConfigureDefaultValuesHandling(DefaultValuesHandling.OmitNull | DefaultValuesHandling.OmitDefaults)
            .WithNamingConvention(CamelCaseNamingConvention.Instance)
            .WithTypeConverter(new YamlStringEnumConverter())
            //.WithTypeConverter(new YamlIntegerTypeConverter())
            .WithTypeConverter(new YamlClassTypeConverter())
            //.NullValueHandling = NullValueHandling.Ignore,
            //DefaultValueHandling = DefaultValueHandling.Ignore,                        
            .Build();
        return serializer.Serialize(obj);
    }
    public static string ClassToYaml<T>(T obj) where T : class
    {
        var serializer = new SerializerBuilder()
            .IncludeNonPublicProperties()
            //.EnsureRoundtrip()
            //.WithTagMapping(new TagName(nameof(Selmays)), typeof(Selmays))
            .ConfigureDefaultValuesHandling(DefaultValuesHandling.OmitNull | DefaultValuesHandling.OmitDefaults | DefaultValuesHandling.OmitEmptyCollections)
            .WithNamingConvention(CamelCaseNamingConvention.Instance)
            .WithTypeConverter(new YamlStringEnumConverter())
            //.WithTypeConverter(new YamlIntegerTypeConverter())
            .WithTypeConverter(new YamlClassTypeConverter())
            //.NullValueHandling = NullValueHandling.Ignore,
            //DefaultValueHandling = DefaultValueHandling.Ignore,                        
            .Build();
        return serializer.Serialize(obj);
    }
    public static T YamlToClass<T>(string yaml) where T : class
    {
        var deserializer = new DeserializerBuilder()
            .IncludeNonPublicProperties()
            //.ConfigureDefaultValuesHandling(DefaultValuesHandling.OmitNull | DefaultValuesHandling.OmitDefaults)
            .WithObjectFactory(new PlayerCharacterObjectFactory())
            .WithNamingConvention(CamelCaseNamingConvention.Instance)
            .WithTypeConverter(new YamlStringEnumConverter())
            //.WithTypeConverter(new YamlIntegerTypeConverter())
            .WithTypeConverter(new YamlClassTypeConverter())
            //.NullValueHandling = NullValueHandling.Ignore,
            //DefaultValueHandling = DefaultValueHandling.Ignore,                        
            .Build();
        return deserializer.Deserialize<T>(yaml);
    }

    public static string ToYamlMarkdown<T>(ObjectMarkdown<T> objmd) where T : struct
    {
        var yaml = ToYaml(objmd.Object);
        var markdown = objmd.Markdown.ToString();
        return $"---\n{yaml}---\n{markdown}";
    }

    public static async Task<string> GetResourceAsStringAsync(string resourcePath)
    {
        var filePath = resourcePath; // $"Resources/{resourcePath}";
        Stream stream;
        if (Device.RuntimePlatform == Device.Android)
        {
            stream = await FileSystem.OpenAppPackageFileAsync(filePath);
        }
        else
        {
            stream = await FileSystem.OpenAppPackageFileAsync(filePath);
            //stream = await FileSystem.OpenAppPackageFileAsync("Assets/" + filePath);
        }
        //using var stream = await Microsoft.Maui.Essentials.FileSystem.OpenAppPackageFileAsync("MauiResources/Library/arme-spirituelle.md");
        var sr = new StreamReader(stream, Encoding.UTF8);
        var text = await sr.ReadToEndAsync();
        return text;
        //var buffer = new byte[stream.Length];
        //await stream.ReadAsync(buffer);
        //stream.Dispose();
        //Debug.WriteLine(buffer.Length);
        //return Encoding.UTF8.GetString(buffer, 0, buffer.Length); //Convert.ToString(buffer);
    }
}

//internal sealed class YamlIntegerTypeConverter : IYamlTypeConverter
//{
//    // https://www.cyotek.com/blog/using-custom-type-converters-with-csharp-and-yamldotnet-part-1
//    public bool Accepts(Type type)
//    {
//        return type == typeof(Number);
//    }

//    public object ReadYaml(IParser parser, Type type)
//    {
//        var parsed = parser.Consume<Scalar>();
//        var value = parsed.Value;
//        if (value == "null")
//        {
//            return null;
//        }
//        return new Number(Convert.ToInt32(value));
//    }

//    public void WriteYaml(IEmitter emitter, object value, Type type)
//    {
//        emitter.Emit(new Scalar(value.ToString()));
//    }
//}

internal sealed class YamlClassTypeConverter : IYamlTypeConverter
{
    // https://www.cyotek.com/blog/using-custom-type-converters-with-csharp-and-yamldotnet-part-1
    public bool Accepts(Type type)
    {
        return type == typeof(ClassDatum);
    }

    public object ReadYaml(IParser parser, Type type)
    {
        var parsed = parser.Consume<Scalar>();
        var value = parsed.Value;
        if (value == "null")
        {
            return null;
        }
        //return new Number(Convert.ToInt32(value));
        return Convert.ToInt32(value);
    }

    public void WriteYaml(IEmitter emitter, object value, Type type)
    {
        emitter.Emit(new Scalar(value.ToString()));
    }
}

public class YamlStringEnumConverter : IYamlTypeConverter
{
    public bool Accepts(Type type) => type.IsEnum;

    public object ReadYaml(IParser parser, Type type)
    {
        var parsedEnum = parser.Consume<Scalar>();
        //var parsedEnum = parser.Expect<Scalar>();
        var serializableValues = type.GetMembers()
            .Select(m => new KeyValuePair<string, MemberInfo>(m.GetCustomAttributes<YamlMemberAttribute>(true).Select(ema => ema.Alias).FirstOrDefault(), m))
            .Where(pa => !String.IsNullOrEmpty(pa.Key)).ToDictionary(pa => pa.Key, pa => pa.Value);
        if (!serializableValues.ContainsKey(parsedEnum.Value))
        {
            if (parsedEnum.Value == "null")
            {
                return null;
            }
            var value = parsedEnum.Value.Substring(0, 1).ToUpper() + parsedEnum.Value.Substring(1);
            //throw new YamlException(parsedEnum.Start, parsedEnum.End, $"Value '{parsedEnum.Value}' not found in enum '{type.Name}'");
            var enumValue = Enum.Parse(type, value);
            return enumValue;
        }

        return Enum.Parse(type, serializableValues[parsedEnum.Value].Name);
    }
    //public object ReadYaml(IParser parser, Type type)
    //{
    //    var parsedEnum = parser.Consume<Scalar>();
    //    //var parsedEnum = parser.Expect<Scalar>();
    //    var serializableValues = type.GetMembers()
    //        .Select(m => new KeyValuePair<string, MemberInfo>(m.GetCustomAttributes<EnumMemberAttribute>(true).Select(ema => ema.Value).FirstOrDefault(), m))
    //        .Where(pa => !String.IsNullOrEmpty(pa.Key)).ToDictionary(pa => pa.Key, pa => pa.Value);
    //    if (!serializableValues.ContainsKey(parsedEnum.Value))
    //    {
    //        if (parsedEnum.Value == "null")
    //        {
    //            return null;
    //        }
    //        var value = parsedEnum.Value.Substring(0, 1).ToUpper() + parsedEnum.Value.Substring(1);
    //        //throw new YamlException(parsedEnum.Start, parsedEnum.End, $"Value '{parsedEnum.Value}' not found in enum '{type.Name}'");
    //        return Enum.Parse(type, value);
    //    }

    //    return Enum.Parse(type, serializableValues[parsedEnum.Value].Name);
    //}

    public void WriteYaml(IEmitter emitter, object value, Type type)
    {
        var enumMember = type.GetMember(value.ToString()).FirstOrDefault();
        var yamlValue = enumMember?.GetCustomAttributes<EnumMemberAttribute>(true).Select(ema => ema.Value).FirstOrDefault() ?? value.ToString();
        emitter.Emit(new Scalar(yamlValue));
    }


}
