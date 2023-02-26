using SRD5Helper.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using YamlDotNet.Serialization;

namespace SRD5Helper.ViewModels;

public class Language : DatumReference<string, LanguageDatum>
{
    public Language() { }
    public Language(string _id) { ID = _id; }
    //public static implicit operator Language(string x) { return new Language(x); }
    [YamlIgnore, JsonIgnore]
    public override LanguageDatum Datum => LanguagesData[ID];

}
