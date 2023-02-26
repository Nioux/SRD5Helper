using SRD5Helper.DataModels;
using System.Collections;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;
using YamlDotNet.Serialization;

namespace SRD5Helper.ViewModels;

public class Condition : DatumReference<ConditionID, ConditionDatum>
{
    public Condition() { }
    public Condition(ConditionID _id) { ID = _id; }
    //public static implicit operator Condition(ConditionID x) { return new Condition(x); }
    [YamlIgnore, JsonIgnore]
    public override ConditionDatum Datum => Property.Calculated(() => ConditionsData[ID]);
    [YamlIgnore, JsonIgnore]
    public string Name => Property.Calculated(() => Datum.Name);
    [YamlIgnore, JsonIgnore]
    public string Description => Property.Calculated(() => Datum.Description);
    [YamlIgnore, JsonIgnore]
    public override ConditionID ID { get => base.ID; set => base.ID = value; }


    [YamlMember(Alias = nameof(IsEnabled))]
    public bool? _isEnabled;
    [YamlIgnore, JsonIgnore]
    public bool IsEnabled { get => Property.Get(() => _isEnabled ?? false); set => Property.Set(value); }
}

public class Conditions : BaseModel//: IReadOnlyCollection<Condition>
{
    [YamlIgnore, JsonIgnore]
    private Dictionary<ConditionID, Func<Condition>> _conditions = new Dictionary<ConditionID, Func<Condition>>();

    public Conditions()
    {
        /*Prone = new Condition { ID = ConditionID.Prone };
        Deafened = new Condition { ID = ConditionID.Deafened };
        Blinded = new Condition { ID = ConditionID.Blinded };
        Charmed = new Condition { ID = ConditionID.Charmed };
        Grappled = new Condition { ID = ConditionID.Grappled };
        Poisoned = new Condition { ID = ConditionID.Poisoned };
        Restrained = new Condition { ID = ConditionID.Restrained };
        Stunned = new Condition { ID = ConditionID.Stunned };
        Unconscious = new Condition { ID = ConditionID.Unconscious };
        Invisible = new Condition { ID = ConditionID.Invisible };
        Incapacitated = new Condition { ID = ConditionID.Incapacitated };
        Paralyzed = new Condition { ID = ConditionID.Paralyzed };
        Petrified = new Condition { ID = ConditionID.Petrified };
        Frightened = new Condition { ID = ConditionID.Frightened };
        Special = new Condition { ID = ConditionID.Special };*/

        _conditions = new Dictionary<ConditionID, Func<Condition>>
        {
            [ConditionID.Prone] = () => Prone,
            [ConditionID.Deafened] = () => Deafened,
            [ConditionID.Blinded] = () => Blinded,
            [ConditionID.Charmed] = () => Charmed,
            [ConditionID.Grappled] = () => Grappled,
            [ConditionID.Poisoned] = () => Poisoned,
            [ConditionID.Restrained] = () => Restrained,
            [ConditionID.Stunned] = () => Stunned,
            [ConditionID.Unconscious] = () => Unconscious,
            [ConditionID.Invisible] = () => Invisible,
            [ConditionID.Incapacitated] = () => Incapacitated,
            [ConditionID.Paralyzed] = () => Paralyzed,
            [ConditionID.Petrified] = () => Petrified,
            [ConditionID.Frightened] = () => Frightened,
            [ConditionID.Special] = () => Special,
        };
    }

    public Condition Blinded { get => Get(ConditionID.Blinded); set => Set(ConditionID.Blinded, value); }
    public Condition Charmed { get => Get(ConditionID.Charmed); set => Set(ConditionID.Charmed, value); }
    public Condition Deafened { get => Get(ConditionID.Deafened); set => Set(ConditionID.Deafened, value); }
    public Condition Frightened { get => Get(ConditionID.Frightened); set => Set(ConditionID.Frightened, value); }
    public Condition Grappled { get => Get(ConditionID.Grappled); set => Set(ConditionID.Grappled, value); }
    public Condition Incapacitated { get => Get(ConditionID.Incapacitated); set => Set(ConditionID.Incapacitated, value); }
    public Condition Invisible { get => Get(ConditionID.Invisible); set => Set(ConditionID.Invisible, value); }
    public Condition Paralyzed { get => Get(ConditionID.Paralyzed); set => Set(ConditionID.Paralyzed, value); }
    public Condition Petrified { get => Get(ConditionID.Petrified); set => Set(ConditionID.Petrified, value); }
    public Condition Poisoned { get => Get(ConditionID.Poisoned); set => Set(ConditionID.Poisoned, value); }
    public Condition Prone { get => Get(ConditionID.Prone); set => Set(ConditionID.Prone, value); }
    public Condition Restrained { get => Get(ConditionID.Restrained); set => Set(ConditionID.Restrained, value); }
    public Condition Stunned { get => Get(ConditionID.Stunned); set => Set(ConditionID.Stunned, value); }
    public Condition Unconscious { get => Get(ConditionID.Unconscious); set => Set(ConditionID.Unconscious, value); }
    public Condition Special { get => Get(ConditionID.Special); set => Set(ConditionID.Special, value); }

    //[YamlIgnore, JsonIgnore]
    //public int Count => _conditions.Count;

    /*public IEnumerator<Condition> GetEnumerator()
    {
        return _conditions.Values.GetEnumerator();
    }*/

    public List<Condition> ToList()
    {
        return _conditions.Values.Select(func => func.Invoke()).ToList();
    }

    public void Set(ConditionID conditionID, Condition condition, [CallerMemberName] string propertyName = null!)
    {
        Property.Set(condition, propertyName: propertyName);
    }

    public Condition Get(ConditionID id, [CallerMemberName] string propertyName = null!)
    {
        return Property.Get(() => PC.Factory.CreateCondition(id), propertyName: propertyName);
    }

    //IEnumerator IEnumerable.GetEnumerator()
    //{
    //    return GetEnumerator();
    //}
}
