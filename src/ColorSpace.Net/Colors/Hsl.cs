using System.Text;
using ColorSpace.Net.Helpers;

namespace ColorSpace.Net.Colors;

/// <summary>
/// Represents a color in the Hsl (Hue, Saturation, Lightness) color space.
/// </summary>
public struct Hsl : IColor, IEquatable<Hsl>
{
    #region Fields/Consts

    private struct MILColorM
    {
        public decimal h, s, l;
    };

    private const string _hslFormat = "G";

    private MILColorM _hslColor;

    #endregion

    #region Properties

    /// <summary>
    /// Gets or sets the hue component of the Hsl color as a decimal-point value in the range [0, 360].
    /// </summary>
    public decimal H
    {
        readonly get => _hslColor.h;
        set => _hslColor.h = ClampHToHslRange(value);
    }

    /// <summary>
    /// Gets or sets the saturation component of the Hsl color as a decimal-point value in the range [0, 100].
    /// </summary>
    public decimal S
    {
        readonly get => _hslColor.s;
        set => _hslColor.s = ClampSToHslRange(value);
    }

    /// <summary>
    /// Gets or sets the lightness component of the Hsl color as a decimal-point value in the range [0, 100].
    /// </summary>
    public decimal L
    {
        readonly get => _hslColor.l;
        set => _hslColor.l = ClampLToHslRange(value);
    }

    #endregion

    #region Constructors

    /// <summary>
    /// Creates a new instance of the Hsl color structure from decimal-point Hsl components.
    /// </summary>
    /// <param name="h">The hue component of the Hsl color as a decimal-point value in the range [0, 360].</param>
    /// <param name="s">The saturation component of the Hsl color as a decimal-point value in the range [0, 100].</param>
    /// <param name="l">The lightness component of the Hsl color as a decimal-point value in the range [0, 100].</param>
    /// <returns>A new instance of the Hsl color structure.</returns>
    public static Hsl FromHsl(decimal h, decimal s, decimal l)
    {
        var hsl = new Hsl();

        hsl._hslColor.h = ClampHToHslRange(h);
        hsl._hslColor.s = ClampSToHslRange(s);
        hsl._hslColor.l = ClampLToHslRange(l);

        return hsl;
    }

    #endregion

    #region Methods

    /// <inheritdoc/>
    public override readonly int GetHashCode()
    {
        return _hslColor.GetHashCode();
    }

    /// <summary>
    /// Creates a string representation of this object based on the current culture.
    /// </summary>
    /// <returns>
    /// A string representation of this object.
    /// </returns>
    public override readonly string ToString()
    {
        return ConvertToString(_hslFormat, null);
    }

    /// <summary>
    /// Creates a string representation of this object based on the <see cref="IFormatProvider"/>
    /// passed in. If the provider is null, the CurrentCulture is used.
    /// </summary>
    /// <returns>
    /// A string representation of this object.
    /// </returns>
    public readonly string ToString(IFormatProvider? provider)
    {
        return ConvertToString(_hslFormat, provider);
    }

    /// <summary>
    /// Creates a string representation of this object based on the format string
    /// and <see cref="IFormatProvider"/> passed in.
    /// If the provider is null, the CurrentCulture is used.
    /// See the documentation for <see cref="IFormattable"/> for more information.
    /// </summary>
    /// <returns>
    /// A string representation of this object.
    /// </returns>
    readonly string IFormattable.ToString(string? format, IFormatProvider? provider)
    {
        return ConvertToString(format, provider);
    }

    /// <summary>
    /// Creates a string representation of this object based on the format string
    /// and <see cref="IFormatProvider"/> passed in.
    /// If the provider is null, the CurrentCulture is used.
    /// See the documentation for <see cref="IFormattable"/> for more information.
    /// </summary>
    /// <returns>
    /// A string representation of this object.
    /// </returns>
    private readonly string ConvertToString(string? format, IFormatProvider? provider)
    {
        var sb = new StringBuilder();

        var separator = FormatProviderHelper.GetNumericListSeparator(provider);

        if (format == null)
        {
            sb.AppendFormat(provider,
                            "{1}{0} {2}{0} {3}{0}",
                            separator,
                            _hslColor.h,
                            _hslColor.s,
                            _hslColor.l);
        }
        else
        {
            sb.AppendFormat(provider,
                            "{1:" + format + "}{0} {2:" + format + "}{0} {3:" + format + "}{0}",
                            separator,
                            _hslColor.h,
                            _hslColor.s,
                            _hslColor.l);
        }

        return sb.ToString();
    }

    /// <summary>
    /// Compares two colors for fuzzy equality. This function
    /// helps compensate for the fact that decimal values can
    /// acquire error when operated upon.
    /// </summary>
    /// <param name='color1'>The first color to compare.</param>
    /// <param name='color2'>The second color to compare.</param>
    /// <returns>Whether or not the two colors are equal.</returns>
    public static bool AreClose(Hsl color1, Hsl color2)
    {
        return color1.IsClose(color2);
    }

    /// <summary>
    /// Compares two colors for fuzzy equality. This function
    /// helps compensate for the fact that decimal values can
    /// acquire error when operated upon.
    /// </summary>
    /// <param name='color'>The color to compare to this.</param>
    /// <returns>Whether or not the two colors are equal.</returns>
    private readonly bool IsClose(Hsl color)
    {
        var result = true;

        result = result && DecimalHelpers.AreClose(_hslColor.h, color._hslColor.h);
        result = result && DecimalHelpers.AreClose(_hslColor.s, color._hslColor.s);
        return result && DecimalHelpers.AreClose(_hslColor.l, color._hslColor.l);
    }

    private static decimal ClampHToHslRange(decimal val)
    {
        return val < 0 ? 0 : val > 360 ? 360 : val;
    }

    private static decimal ClampSToHslRange(decimal val)
    {
        return val < 0 ? 0 : val > 100 ? 100 : val;
    }

    private static decimal ClampLToHslRange(decimal val)
    {
        return val < 0 ? 0 : val > 100 ? 100 : val;
    }

    #endregion

    #region Operators

    /// <summary>
    /// Addition operator - Adds each channel of the second color to each channel of the
    /// first and returns the result.
    /// </summary>
    public static Hsl operator +(Hsl color1, Hsl color2)
    {
        return FromHsl(color1._hslColor.h + color2._hslColor.h,
                       color1._hslColor.s + color2._hslColor.s,
                       color1._hslColor.l + color2._hslColor.l);
    }

    /// <summary>
    /// Addition method - Adds each channel of the second color to each channel of the
    /// first and returns the result.
    /// </summary>
    public static Hsl Add(Hsl color1, Hsl color2)
    {
        return color1 + color2;
    }

    /// <summary>
    /// Subtract operator - substracts each channel of the second color from each channel of the
    /// first and returns the result.
    /// </summary>
    /// <param name='color1'>The minuend.</param>
    /// <param name='color2'>The subtrahend.</param>
    /// <returns>Returns the unclamped differnce.</returns>
    public static Hsl operator -(Hsl color1, Hsl color2)
    {
        return FromHsl(color1._hslColor.h - color2._hslColor.h,
                       color1._hslColor.s - color2._hslColor.s,
                       color1._hslColor.l - color2._hslColor.l);
    }

    /// <summary>
    /// Subtract operator - substracts each channel of the second color from each channel of the
    /// first and returns the result.
    /// </summary>
    /// <param name='color1'>The minuend.</param>
    /// <param name='color2'>The subtrahend.</param>
    /// <returns>Returns the unclamped differnce.</returns>
    public static Hsl Subtract(Hsl color1, Hsl color2)
    {
        return color1 - color2;
    }

    /// <summary>
    /// Multiplication operator - Multiplies each channel of the color by a coefficient and returns the result.
    /// </summary>
    /// <param name='color'>The color.</param>
    /// <param name='coefficient'>The coefficient.</param>
    /// <returns>Returns the unclamped product.</returns>
    public static Hsl operator *(Hsl color, decimal coefficient)
    {
        return FromHsl(color._hslColor.h * coefficient,
                       color._hslColor.s * coefficient,
                       color._hslColor.l * coefficient);
    }

    /// <summary>
    /// Multiplication operator - Multiplies each channel of the color by a coefficient and returns the result.
    /// </summary>
    /// <param name='color'>The color.</param>
    /// <param name='coefficient'>The coefficient.</param>
    /// <returns>Returns the unclamped product.</returns>
    public static Hsl Multiply(Hsl color, decimal coefficient)
    {
        return color * coefficient;
    }

    /// <summary>
    /// IsEqual operator - Compares two colors for exact equality. Note that decimal values can acquire error
    /// when operated upon, such that an exact comparison between two values which are logically
    /// equal may fail. See <see cref="AreClose"/>.
    /// </summary>
    public static bool operator ==(Hsl color1, Hsl color2)
    {
        return color1._hslColor.h == color2._hslColor.h
               && color1._hslColor.s == color2._hslColor.s
               && color1._hslColor.l == color2._hslColor.l;
    }

    /// <summary>
    /// IsEqual operator - Compares two colors for exact equality. Note that decimal values can acquire error
    /// when operated upon, such that an exact comparison between two values which are logically
    /// equal may fail. See <see cref="AreClose"/>.
    /// </summary>
    public static bool Equals(Hsl color1, Hsl color2)
    {
        return color1 == color2;
    }

    /// <summary>
    /// Compares two colors for exact equality. Note that decimal values can acquire error
    /// when operated upon, such that an exact comparison between two values which are logically
    /// equal may fail. See <see cref="AreClose"/> for a "fuzzy" version of this comparison.
    /// </summary>
    /// <param name='color'>The color to compare to "this".</param>
    /// <returns>Whether or not the two colors are equal.</returns>
    public readonly bool Equals(Hsl color)
    {
        return this == color;
    }

    /// <summary>
    /// Compares two colors for exact equality. Note that decimal values can acquire error
    /// when operated upon, such that an exact comparison between two values which are logically
    /// equal may fail. See <see cref="AreClose"/> for a "fuzzy" version of this comparison.
    /// </summary>
    /// <param name='o'>The object to compare to "this".</param>
    /// <returns>Whether or not the two colors are equal.</returns>
    public override readonly bool Equals(object? o)
    {
        return o is Hsl color && this == color;
    }

    /// <summary>
    /// IsNotEqual operator - Compares two colors for exact inequality. Note that decimal values can acquire error
    /// when operated upon, such that an exact comparison between two values which are logically
    /// equal may fail. See <see cref="AreClose"/>.
    /// </summary>
    public static bool operator !=(Hsl color1, Hsl color2)
    {
        return !(color1 == color2);
    }

    #endregion
}