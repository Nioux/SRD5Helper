using SRD5Helper.DataModels;
using SRD5Helper.ViewModels;
using System.Globalization;

namespace SRD5Helper.Tools; 

public abstract class ValueConverter<TInput, TOutput> : IValueConverter where TInput : class
{
    abstract public TOutput Convert(TInput input);

    object IValueConverter.Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return Convert(value as TInput);
    }

    object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
public abstract class MultiValueConverter<TInput, TOutput> : IMultiValueConverter where TInput: class
{
    abstract public TOutput Convert(IEnumerable<TInput> input);

    object IMultiValueConverter.Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
        var tvalues = values.Select(value => value as TInput);
        return Convert(tvalues);
    }

    object[] IMultiValueConverter.ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
    /*
    object IValueConverter.Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return Convert(value as TInput);
    }

    object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }*/
}
public class FinesseConverter : ValueConverter<Abilities, int>
{
    public WeaponAbility WeaponAbility { get; init; }

    public override int Convert(Abilities abilities)
    {
        if (WeaponAbility == WeaponAbility.Strength)
        {
            return abilities.Strength.Mod;
        }
        else if (WeaponAbility == WeaponAbility.Dexterity)
        {
            return abilities.Dexterity.Mod;
        }
        else
        {
            return Math.Max(abilities.Strength.Mod, abilities.Dexterity.Mod);
        }
    }
}
