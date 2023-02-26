using Markdig;
using Markdig.Extensions.Yaml;
using Markdig.Syntax;
using MauiApp3;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.Serialization;
using YamlDotNet.Core;
using YamlDotNet.Core.Events;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace ClassLibrary1
{
    public class Test
    {
        /*public Dictionary<string, Equipment> TestTest(string yaml)
        {
            var deserializer = new DeserializerBuilder()
                //.IgnoreUnmatchedProperties()
                .WithTypeConverter(new YamlStringEnumConverter())
                .WithNamingConvention(CamelCaseNamingConvention.Instance)
                .Build();
            //var deserializer = new YamlDotNet.Serialization.Deserializer();
            var obj = deserializer.Deserialize<Dictionary<string, Equipment>>(yaml);
            return obj;
        }*/
    }
    public class ObjectMarkdown<T> where T : struct
    {
        public MarkdownDocument Markdown { get; set; }
        public T Object { get; set; }
    }
    public static class Tools
    {
        public static string Test()
        {
            return "ok";
        }
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
                    //.IgnoreUnmatchedProperties()
                    .WithTypeConverter(new YamlStringEnumConverter())
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
                .WithNamingConvention(CamelCaseNamingConvention.Instance)
                //.NullValueHandling = NullValueHandling.Ignore,
                //DefaultValueHandling = DefaultValueHandling.Ignore,                        
                .Build();
            return serializer.Serialize(obj);
        }

        public static string ToYamlMarkdown<T>(ObjectMarkdown<T> objmd) where T : struct
        {
            var yaml = ToYaml(objmd.Object);
            var markdown = objmd.Markdown.ToString();
            return $"---\n{yaml}---\n{markdown}";
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
                if(parsedEnum.Value == "null")
                {
                    return null;
                }
                var value = parsedEnum.Value.Substring(0, 1).ToUpper() + parsedEnum.Value.Substring(1);
                //throw new YamlException(parsedEnum.Start, parsedEnum.End, $"Value '{parsedEnum.Value}' not found in enum '{type.Name}'");
                return Enum.Parse(type, value);
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
}
