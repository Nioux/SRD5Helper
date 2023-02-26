using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRD5Helper.Units;

public enum AdvantageDisadvantage
{
    Null = 0,
    Advantage = 1,
    Disadvantage = -1,
}
/*
public class AdvantageNumber : INumber<AdvantageNumber>
{
    public static AdvantageNumber Advantage { get; } = new AdvantageNumber { HasAdvantage = true };

    public static AdvantageNumber Disadvantage { get; } = new AdvantageNumber { HasDisadvantage = true };
    
    public bool HasAdvantage { get; init; }
    
    public bool HasDisadvantage { get; init; }
    
    public AdvantageDisadvantage Balance => HasAdvantage ? (HasDisadvantage ? AdvantageDisadvantage.Null : AdvantageDisadvantage.Advantage) : (HasDisadvantage ? AdvantageDisadvantage.Disadvantage : AdvantageDisadvantage.Null);
    
    public static AdvantageNumber One => Advantage;

    public static AdvantageNumber Zero => Disadvantage;

    public static AdvantageNumber AdditiveIdentity => throw new NotImplementedException();

    public static AdvantageNumber MultiplicativeIdentity => throw new NotImplementedException();

    public static AdvantageNumber Abs(AdvantageNumber value)
    {
        throw new NotImplementedException();
    }

    public static AdvantageNumber Clamp(AdvantageNumber value, AdvantageNumber min, AdvantageNumber max)
    {
        throw new NotImplementedException();
    }

    public static AdvantageNumber Create<TOther>(TOther value) where TOther : INumber<TOther>
    {
        throw new NotImplementedException();
    }

    public static AdvantageNumber CreateSaturating<TOther>(TOther value) where TOther : INumber<TOther>
    {
        throw new NotImplementedException();
    }

    public static AdvantageNumber CreateTruncating<TOther>(TOther value) where TOther : INumber<TOther>
    {
        throw new NotImplementedException();
    }

    public static (AdvantageNumber Quotient, AdvantageNumber Remainder) DivRem(AdvantageNumber left, AdvantageNumber right)
    {
        throw new NotImplementedException();
    }

    public static AdvantageNumber Max(AdvantageNumber x, AdvantageNumber y)
    {
        throw new NotImplementedException();
    }

    public static AdvantageNumber Min(AdvantageNumber x, AdvantageNumber y)
    {
        throw new NotImplementedException();
    }

    public static AdvantageNumber Parse(string s, NumberStyles style, IFormatProvider provider)
    {
        throw new NotImplementedException();
    }

    public static AdvantageNumber Parse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider provider)
    {
        throw new NotImplementedException();
    }

    public static AdvantageNumber Parse(ReadOnlySpan<char> s, IFormatProvider provider)
    {
        throw new NotImplementedException();
    }

    public static AdvantageNumber Parse(string s, IFormatProvider provider)
    {
        throw new NotImplementedException();
    }

    public static AdvantageNumber Sign(AdvantageNumber value)
    {
        throw new NotImplementedException();
    }

    public static bool TryCreate<TOther>(TOther value, out AdvantageNumber result) where TOther : INumber<TOther>
    {
        throw new NotImplementedException();
    }

    public static bool TryParse([NotNullWhen(true)] string s, NumberStyles style, IFormatProvider provider, out AdvantageNumber result)
    {
        throw new NotImplementedException();
    }

    public static bool TryParse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider provider, out AdvantageNumber result)
    {
        throw new NotImplementedException();
    }

    public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider provider, out AdvantageNumber result)
    {
        throw new NotImplementedException();
    }

    public static bool TryParse([NotNullWhen(true)] string s, IFormatProvider provider, out AdvantageNumber result)
    {
        throw new NotImplementedException();
    }

    public int CompareTo(object obj)
    {
        throw new NotImplementedException();
    }

    public int CompareTo(AdvantageNumber other)
    {
        throw new NotImplementedException();
    }

    public bool Equals(AdvantageNumber other)
    {
        throw new NotImplementedException();
    }

    public string ToString(string format, IFormatProvider formatProvider)
    {
        throw new NotImplementedException();
    }

    public bool TryFormat(Span<char> destination, out int charsWritten, ReadOnlySpan<char> format, IFormatProvider provider)
    {
        throw new NotImplementedException();
    }

    public static AdvantageNumber operator +(AdvantageNumber value)
    {
        return value;
    }

    public static AdvantageNumber operator +(AdvantageNumber left, AdvantageNumber right)
    {
        return new AdvantageNumber { HasAdvantage = left.HasAdvantage || right.HasAdvantage, HasDisadvantage = left.HasDisadvantage || right.HasDisadvantage };
    }

    public static AdvantageNumber operator -(AdvantageNumber value)
    {
        throw new NotImplementedException();
    }

    public static AdvantageNumber operator -(AdvantageNumber left, AdvantageNumber right)
    {
        throw new NotImplementedException();
    }

    public static AdvantageNumber operator ++(AdvantageNumber value)
    {
        throw new NotImplementedException();
    }

    public static AdvantageNumber operator --(AdvantageNumber value)
    {
        throw new NotImplementedException();
    }

    public static AdvantageNumber operator *(AdvantageNumber left, AdvantageNumber right)
    {
        throw new NotImplementedException();
    }

    public static AdvantageNumber operator /(AdvantageNumber left, AdvantageNumber right)
    {
        throw new NotImplementedException();
    }

    public static AdvantageNumber operator %(AdvantageNumber left, AdvantageNumber right)
    {
        throw new NotImplementedException();
    }

    public static bool operator ==(AdvantageNumber left, AdvantageNumber right)
    {
        throw new NotImplementedException();
    }

    public static bool operator !=(AdvantageNumber left, AdvantageNumber right)
    {
        throw new NotImplementedException();
    }

    public static bool operator <(AdvantageNumber left, AdvantageNumber right)
    {
        throw new NotImplementedException();
    }

    public static bool operator >(AdvantageNumber left, AdvantageNumber right)
    {
        throw new NotImplementedException();
    }

    public static bool operator <=(AdvantageNumber left, AdvantageNumber right)
    {
        throw new NotImplementedException();
    }

    public static bool operator >=(AdvantageNumber left, AdvantageNumber right)
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
    }
}
*/