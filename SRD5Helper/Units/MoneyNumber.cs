using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YamlDotNet.Serialization;

namespace SRD5Helper.Units;

/*class machin
{
    void truc()
    {
        MoneyNumber sous = new MoneyNumber { CP = 200 };
        sous += MoneyNumber.FromGP(3);
    }

}*/
public enum Coins : long
{
    CP = 1,
    SP = 10,
    EP = 50,
    GP = 100,
    PP = 1000,
}
public class MoneyNumber //: INumber<MoneyNumber>
{
    public MoneyNumber()
    {
        CP = null;
        SP = null;
        EP = null;
        GP = null;
        PP = null;
    }
    /// <summary>
    /// Copper / Cuivre
    /// </summary>
    [YamlMember(Alias = "cp")]
    public long? CP { get; init; }
    /// <summary>
    /// Silver / Argent
    /// </summary>
    [YamlMember(Alias = "sp")]
    public long? SP { get; init; }
    /// <summary>
    /// Electrum
    /// </summary>
    [YamlMember(Alias = "ep")]
    public long? EP { get; init; }
    /// <summary>
    /// Gold / Or
    /// </summary>
    [YamlMember(Alias = "gp")]
    public long? GP { get; init; }
    /// <summary>
    /// Platinum / Platine
    /// </summary>
    [YamlMember(Alias = "pp")]
    public long? PP { get; init; }
    /*
    public static MoneyNumber One => throw new NotImplementedException();

    public static MoneyNumber Zero => throw new NotImplementedException();

    public static MoneyNumber AdditiveIdentity => throw new NotImplementedException();

    public static MoneyNumber MultiplicativeIdentity => throw new NotImplementedException();
    */
    public static MoneyNumber FromCP(long cp) => new MoneyNumber { CP = cp };
    public static MoneyNumber FromSP(long sp) => new MoneyNumber { SP = sp };
    public static MoneyNumber FromEP(long ep) => new MoneyNumber { EP = ep };
    public static MoneyNumber FromGP(long gp) => new MoneyNumber { GP = gp };
    public static MoneyNumber FromPP(long pp) => new MoneyNumber { PP = pp };
    public long ToLongCP()
    {
        return (CP ?? 0) * ((long)Coins.CP)
            + (SP ?? 0) * ((long)Coins.SP)
            + (EP ?? 0) * ((long)Coins.EP)
            + (GP ?? 0) * ((long)Coins.GP)
            + (PP ?? 0) * ((long)Coins.PP);
    }
    /*
    public static MoneyNumber Abs(MoneyNumber value)
    {
        throw new NotImplementedException();
    }

    public static MoneyNumber Clamp(MoneyNumber value, MoneyNumber min, MoneyNumber max)
    {
        throw new NotImplementedException();
    }

    public static MoneyNumber Create<TOther>(TOther value) where TOther : INumber<TOther>
    {
        throw new NotImplementedException();
    }

    public static MoneyNumber CreateSaturating<TOther>(TOther value) where TOther : INumber<TOther>
    {
        throw new NotImplementedException();
    }

    public static MoneyNumber CreateTruncating<TOther>(TOther value) where TOther : INumber<TOther>
    {
        throw new NotImplementedException();
    }

    public static (MoneyNumber Quotient, MoneyNumber Remainder) DivRem(MoneyNumber left, MoneyNumber right)
    {
        throw new NotImplementedException();
    }

    public static MoneyNumber Max(MoneyNumber x, MoneyNumber y)
    {
        throw new NotImplementedException();
    }

    public static MoneyNumber Min(MoneyNumber x, MoneyNumber y)
    {
        throw new NotImplementedException();
    }

    public static MoneyNumber Parse(string s, NumberStyles style, IFormatProvider provider)
    {
        throw new NotImplementedException();
    }

    public static MoneyNumber Parse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider provider)
    {
        throw new NotImplementedException();
    }

    public static MoneyNumber Sign(MoneyNumber value)
    {
        throw new NotImplementedException();
    }

    public static bool TryCreate<TOther>(TOther value, out MoneyNumber result) where TOther : INumber<TOther>
    {
        throw new NotImplementedException();
    }

    public static bool TryParse([NotNullWhen(true)] string s, NumberStyles style, IFormatProvider provider, out MoneyNumber result)
    {
        throw new NotImplementedException();
    }

    public static bool TryParse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider provider, out MoneyNumber result)
    {
        throw new NotImplementedException();
    }

    public int CompareTo(object obj)
    {
        throw new NotImplementedException();
    }

    public int CompareTo(MoneyNumber other)
    {
        throw new NotImplementedException();
    }

    public bool Equals(MoneyNumber other)
    {
        throw new NotImplementedException();
    }

    public bool TryFormat(Span<char> destination, out int charsWritten, ReadOnlySpan<char> format, IFormatProvider provider)
    {
        throw new NotImplementedException();
    }

    public string ToString(string format, IFormatProvider formatProvider)
    {
        throw new NotImplementedException();
    }

    public static MoneyNumber Parse(ReadOnlySpan<char> s, IFormatProvider provider)
    {
        throw new NotImplementedException();
    }

    public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider provider, out MoneyNumber result)
    {
        throw new NotImplementedException();
    }

    public static MoneyNumber Parse(string s, IFormatProvider provider)
    {
        throw new NotImplementedException();
    }

    public static bool TryParse([NotNullWhen(true)] string s, IFormatProvider provider, out MoneyNumber result)
    {
        throw new NotImplementedException();
    }

    public static MoneyNumber operator +(MoneyNumber left, MoneyNumber right)
    {
        throw new NotImplementedException();
    }

    public static bool operator <(MoneyNumber left, MoneyNumber right)
    {
        throw new NotImplementedException();
    }

    public static bool operator <=(MoneyNumber left, MoneyNumber right)
    {
        throw new NotImplementedException();
    }

    public static bool operator >(MoneyNumber left, MoneyNumber right)
    {
        throw new NotImplementedException();
    }

    public static bool operator >=(MoneyNumber left, MoneyNumber right)
    {
        throw new NotImplementedException();
    }

    public static bool operator ==(MoneyNumber left, MoneyNumber right)
    {
        throw new NotImplementedException();
    }

    public static bool operator !=(MoneyNumber left, MoneyNumber right)
    {
        throw new NotImplementedException();
    }

    public static MoneyNumber operator --(MoneyNumber value)
    {
        throw new NotImplementedException();
    }

    public static MoneyNumber operator /(MoneyNumber left, MoneyNumber right)
    {
        throw new NotImplementedException();
    }

    public static MoneyNumber operator ++(MoneyNumber value)
    {
        throw new NotImplementedException();
    }

    public static MoneyNumber operator %(MoneyNumber left, MoneyNumber right)
    {
        throw new NotImplementedException();
    }

    public static MoneyNumber operator *(MoneyNumber left, MoneyNumber right)
    {
        throw new NotImplementedException();
    }

    public static MoneyNumber operator -(MoneyNumber left, MoneyNumber right)
    {
        throw new NotImplementedException();
    }

    public static MoneyNumber operator -(MoneyNumber value)
    {
        throw new NotImplementedException();
    }

    public static MoneyNumber operator +(MoneyNumber value)
    {
        throw new NotImplementedException();
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(this, obj))
        {
            return true;
        }

        if (ReferenceEquals(obj, null))
        {
            return false;
        }

        throw new NotImplementedException();
    }

    public override int GetHashCode()
    {
        throw new NotImplementedException();
    }*/
    /*
public Money ToCP()
{
var intCP = ToIntCP();
CP = 0;
}*/
}
