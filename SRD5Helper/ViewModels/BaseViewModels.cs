using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.DependencyInjection;
using Nito.Mvvm.CalculatedProperties;
using SRD5Helper.Data;
using SRD5Helper.DataModels;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;
using YamlDotNet.Serialization;

namespace SRD5Helper.ViewModels;
/*
public class DescribedProperty<T> where T : INumber<T>
{
    public string Name { get; set; }
    public T Value { get; set; }
    public string Description { get; set; }
}

public class EditableProperty<T> : ObservableObject where T : INumber<T>
{
    public string Name { get; init; }
    public Func<T> ComputedValue { get; init; }
    public T Value { get; set; }
    public string Description { get; set; }
}

public class IntEditableProperty : EditableProperty<int>
{

}
*/
public class BaseModel : ObservableObject
{
    protected readonly PropertyHelper Property;

    public BaseModel()
    {
        Property = new PropertyHelper(OnPropertyChanged);
    }

    private WeakReference<PlayerCharacter> _weakPC;
    [YamlIgnore, JsonIgnore]
    
    public PlayerCharacter PC
    {
        get
        {
            if (_weakPC?.TryGetTarget(out PlayerCharacter pc) == true)
            {
                return pc;
            }
            return null;
        }
        set
        {
            _weakPC = new WeakReference<PlayerCharacter>(value);
        }
    }

    private DataService _storageService = null;
    private DataService StorageService => _storageService ??= Ioc.Default.GetRequiredService<DataService>();

    
    [YamlIgnore, JsonIgnore]
    protected IReadOnlyDictionary<AbilityID, AbilityDatum> AbilitiesData => StorageService.AbilitiesData;
    
    [YamlIgnore, JsonIgnore]
    protected IReadOnlyDictionary<string, SpellDatum> SpellsData => StorageService.SpellsData;
    
    [YamlIgnore, JsonIgnore]
    protected IReadOnlyDictionary<string, ClassDatum> ClassesData => StorageService.ClassesData;
    
    [YamlIgnore, JsonIgnore]
    protected IReadOnlyDictionary<string, ClassArchetypeDatum> ClassArchetypesData => StorageService.ClassArchetypesData;
    
    [YamlIgnore, JsonIgnore]
    protected IReadOnlyDictionary<string, EquipmentDatum> EquipmentsData => StorageService.EquipmentsData;
    
    [YamlIgnore, JsonIgnore]
    protected IReadOnlyDictionary<string, FeatureDatum> FeaturesData => StorageService.FeaturesData;

    [YamlIgnore, JsonIgnore]
    protected IReadOnlyDictionary<string, Rule> RulesData => StorageService.RulesData;

    [YamlIgnore, JsonIgnore]
    protected IReadOnlyDictionary<string, OriginDatum> OriginsData => StorageService.OriginsData;
    
    [YamlIgnore, JsonIgnore]
    protected IReadOnlyDictionary<string, LanguageDatum> LanguagesData => StorageService.LanguagesData;
    
    [YamlIgnore, JsonIgnore]
    protected IReadOnlyDictionary<SkillID, SkillDatum> SkillsData => StorageService.SkillsData;
    
    [YamlIgnore, JsonIgnore]
    protected IReadOnlyDictionary<ConditionID, ConditionDatum> ConditionsData => StorageService.ConditionsData;
    
    [YamlIgnore, JsonIgnore]
    protected IReadOnlyDictionary<string, BackgroundDatum> BackgroundsData => StorageService.BackgroundsData;
    
    [YamlIgnore, JsonIgnore]
    protected IReadOnlyDictionary<string, SubBackgroundDatum> SubBackgroundsData => StorageService.SubBackgroundsData;

    /*public bool SetPropertyAndSave<T>([NotNullIfNotNull("newValue")] ref T field, T newValue, [CallerMemberName] string? propertyName = null)
    {
        if(SetProperty(ref field, newValue, propertyName))
        {
            if (PC != null)
            {
                PC.HasChanged = true;
            }
            return true;
        }
        return false;
    }*/

    public bool OnPropertiesChanged(params string[] properties)
    {
        if (properties != null)
        {
            foreach (var property in properties)
            {
                OnPropertyChanged(property);
            }
        }
        return true;
    }
    /*
    public PropertyPath GetPropertyPath(string? propertyName = null)
    {
        PropertyPath target = new PropertyPath();
        if (BasePath.HasValue)
        {
            target = BasePath.Value;
        }
        target = target.Concat(propertyName);
        return target;
    }*/
    public AnnotatedNumber<int> SumRules([CallerMemberName] string? propertyName = null)
    {
        var sum = new AnnotatedNumber<int>();
        var rules = GetRules(propertyName).ToArray();
        if(rules.Length > 0)
        {
            foreach(var rule in rules)
            {
                var result = (AnnotatedNumber<int>)rule.GetResult(this);
                sum = sum + result;
            }
            return sum;
        }
        return GetRules(propertyName).Sum(rule => (AnnotatedNumber<int>)rule.GetResult(this));
        //int output = 0;
        //foreach (var rule in GetRules(propertyName))
        //{
        //    output += (int)rule.GetResult(this);
        //}
        //return output;
    }
    public bool AnyRules([CallerMemberName] string? propertyName = null)
    {
        return GetRules(propertyName).Any(rule => (bool)rule.GetResult(this));
        //bool output = false;
        //foreach (var rule in GetRules(propertyName))
        //{
        //    output |= (bool)rule.GetResult(this);
        //}
        //return output;
    }
    public IEnumerable<string> StringsRules([CallerMemberName] string? propertyName = null)
    {
        return GetRules(propertyName).Select(rule => (string)rule.GetResult(this)).ToList();
        //List<string> output = new List<string>();
        //foreach (var rule in GetRules(propertyName))
        //{
        //    output.Add((string)rule.GetResult(this));
        //}
        //return output;
    }

    public IReadOnlySet<EquipmentTypeRef> EquipmentRules([CallerMemberName] string? propertyName = null)
    {
        return GetRules(propertyName).Select(rule => (EquipmentTypeRef)rule.GetResult(this)).ToHashSet();
        //List<string> output = new List<string>();
        //foreach (var rule in GetRules(propertyName))
        //{
        //    output.Add((string)rule.GetResult(this));
        //}
        //return output;
    }

    public IEnumerable<Rule> GetRules([CallerMemberName] string? propertyName = null)
    {
        if (PC?.Rules != null)
        {
            return PC.Rules.Where(rule => rule.IsRuled(propertyName, this));
        }
        return new Rule[] {};
    }


    /*public DescribedProperty<int> ApplyRules<T>(DescribedProperty<int> input, [CallerMemberName] string? propertyName = null)
        //where T : INumber<T>
    {
        var value = input.Value;
        var description = input.Description;
        if (PC?.Rules != null)
        {
            foreach (var rule in PC.Rules.Where(rule => rule.IsRuled(propertyName, this)))
            {
                var newvalue = (int)rule.GetResult(this);
                if (newvalue != 0)
                {
                    //if(!newvalue.Equals(value))
                    //{
                    //description += $"{newvalue - value:+0;-#} ({rule.Name})";
                    description += $"{newvalue:+0;-#} ({rule.Name})";
                    //}
                }
                value += newvalue;
            }
        }        
        return new DescribedProperty<int> { Value = value, Description = description };
    }*/


    //public virtual PropertyPath? BasePath { get => null; }
    //public virtual string BaseID { get => null; }
}

public class BaseCollectionModel<T> : ObservableCollection<T> where T : class
{

}

public class BaseReadOnlyCollectionModel<T> : ObservableCollection<T> where T : class
{

}

public class DatumReference<TKey, T> : BaseModel where T : struct
{
    public virtual TKey ID { get => Property.Get<TKey>(null); set => Property.Set(value); }

    [YamlIgnore, JsonIgnore]
    public virtual T Datum { get => default(T); }


    //public Reference<T>() { }
    //public Reference<T>(int value) { Value = value; }


    // Custom cast from "int":
    public static implicit operator DatumReference<TKey, T>(TKey x) { return new DatumReference<TKey, T>() { ID = x }; }

    // Custom cast to "int":
    //public static implicit operator Int32(Number x) { return x.Value; }

    //public virtual string BaseID => ID.ToString();

    public override string ToString()
    {
        return $"{ID}";
    }
}

