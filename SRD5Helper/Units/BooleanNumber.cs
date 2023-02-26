using System.Diagnostics.CodeAnalysis;
using System.Globalization;

namespace SRD5Helper.Units;
/*
public class BooleanNumber : INumber<BooleanNumber>
{
    public bool Value { get; private init; }
    
    public static BooleanNumber True => new BooleanNumber { Value = true };
    
    public static BooleanNumber False => new BooleanNumber { Value = false };

    public static BooleanNumber One => new BooleanNumber { Value = true };

    public static BooleanNumber Zero => new BooleanNumber { Value = false };

    public static BooleanNumber AdditiveIdentity => throw new NotImplementedException();

    public static BooleanNumber MultiplicativeIdentity => throw new NotImplementedException();

    public static BooleanNumber Abs(BooleanNumber value)
    {
        throw new NotImplementedException();
    }

    public static BooleanNumber Clamp(BooleanNumber value, BooleanNumber min, BooleanNumber max)
    {
        throw new NotImplementedException();
    }

    public static BooleanNumber Create<TOther>(TOther value) where TOther : INumber<TOther>
    {
        throw new NotImplementedException();
    }

    public static BooleanNumber CreateSaturating<TOther>(TOther value) where TOther : INumber<TOther>
    {
        throw new NotImplementedException();
    }

    public static BooleanNumber CreateTruncating<TOther>(TOther value) where TOther : INumber<TOther>
    {
        throw new NotImplementedException();
    }

    public static (BooleanNumber Quotient, BooleanNumber Remainder) DivRem(BooleanNumber left, BooleanNumber right)
    {
        throw new NotImplementedException();
    }

    public static BooleanNumber Max(BooleanNumber x, BooleanNumber y)
    {
        return x > y ? x : y;
    }

    public static BooleanNumber Min(BooleanNumber x, BooleanNumber y)
    {
        return x < y ? x : y;
    }

    public static BooleanNumber Parse(string s, NumberStyles style, IFormatProvider provider)
    {
        throw new NotImplementedException();
    }

    public static BooleanNumber Parse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider provider)
    {
        throw new NotImplementedException();
    }

    public static BooleanNumber Parse(ReadOnlySpan<char> s, IFormatProvider provider)
    {
        throw new NotImplementedException();
    }

    public static BooleanNumber Parse(string s, IFormatProvider provider)
    {
        throw new NotImplementedException();
    }

    public static BooleanNumber Sign(BooleanNumber value)
    {
        throw new NotImplementedException();
    }

    public static bool TryCreate<TOther>(TOther value, out BooleanNumber result) where TOther : INumber<TOther>
    {
        throw new NotImplementedException();
    }

    public static bool TryParse([NotNullWhen(true)] string s, NumberStyles style, IFormatProvider provider, out BooleanNumber result)
    {
        bool value;
        if (bool.TryParse(s, out value))
        {
            result = new BooleanNumber { Value = value };
            return true;
        }
        result = null;
        return false;
    }

    public static bool TryParse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider provider, out BooleanNumber result)
    {
        bool value;
        if (bool.TryParse(s, out value))
        {
            result = new BooleanNumber { Value = value };
            return true;
        }
        result = null;
        return false;
    }

    public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider provider, out BooleanNumber result)
    {
        bool value;
        if (bool.TryParse(s, out value))
        {
            result = new BooleanNumber { Value = value };
            return true;
        }
        result = null;
        return false;
    }

    public static bool TryParse([NotNullWhen(true)] string s, IFormatProvider provider, out BooleanNumber result)
    {
        bool value;
        if (bool.TryParse(s, out value))
        {
            result = new BooleanNumber { Value = value };
            return true;
        }
        result = null;
        return false;
    }

    public int CompareTo(object obj)
    {
        return Value.CompareTo(obj);
    }

    public int CompareTo(BooleanNumber other)
    {
        return Value.CompareTo(other.Value);
    }

    public bool Equals(BooleanNumber other)
    {
        return Value.Equals(other.Value);
    }

    public string ToString(string format, IFormatProvider formatProvider)
    {
        return Value.ToString();
    }

    public bool TryFormat(Span<char> destination, out int charsWritten, ReadOnlySpan<char> format, IFormatProvider provider)
    {
        throw new NotImplementedException();
    }

    public static BooleanNumber operator +(BooleanNumber value)
    {
        return value;
    }

    public static BooleanNumber operator +(BooleanNumber left, BooleanNumber right)
    {
        return new BooleanNumber { Value = left.Value | right.Value };
    }

    public static BooleanNumber operator -(BooleanNumber value)
    {
        return new BooleanNumber { Value = !value.Value };
    }

    public static BooleanNumber operator -(BooleanNumber left, BooleanNumber right)
    {
        return new BooleanNumber { Value = left.Value ^ right.Value };
    }

    public static BooleanNumber operator ++(BooleanNumber value)
    {
        return new BooleanNumber { Value = true };
    }

    public static BooleanNumber operator --(BooleanNumber value)
    {
        return new BooleanNumber { Value = false };
    }

    public static BooleanNumber operator *(BooleanNumber left, BooleanNumber right)
    {
        throw new NotImplementedException();
    }

    public static BooleanNumber operator /(BooleanNumber left, BooleanNumber right)
    {
        throw new NotImplementedException();
    }

    public static BooleanNumber operator %(BooleanNumber left, BooleanNumber right)
    {
        throw new NotImplementedException();
    }

    public static bool operator ==(BooleanNumber left, BooleanNumber right)
    {
        return left.Value == right.Value;
    }

    public static bool operator !=(BooleanNumber left, BooleanNumber right)
    {
        return left.Value != right.Value;
    }

    public static bool operator <(BooleanNumber left, BooleanNumber right)
    {
        return (left.Value ? 1 : 0) < (right.Value ? 1 : 0);
    }

    public static bool operator >(BooleanNumber left, BooleanNumber right)
    {
        return (left.Value ? 1 : 0) > (right.Value ? 1 : 0);
    }

    public static bool operator <=(BooleanNumber left, BooleanNumber right)
    {
        return (left.Value ? 1 : 0) <= (right.Value ? 1 : 0);
    }

    public static bool operator >=(BooleanNumber left, BooleanNumber right)
    {
        return (left.Value ? 1 : 0) >= (right.Value ? 1 : 0);
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

        return this == obj as BooleanNumber;
    }

    public override int GetHashCode()
    {
        throw new NotImplementedException();
    }
}
*/