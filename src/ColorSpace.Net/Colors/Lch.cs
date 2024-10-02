using System.Text;
using ColorSpace.Net.Helpers;

namespace ColorSpace.Net.Colors;

/// <summary>
/// Represents a color in the CIE Lch* (Luminance, Chroma, Hue) color space.
/// </summary>
public struct Lch : IColor, IEquatable<Lch>
{
    #region Fields/Consts

    private struct MILColorM
    {
        public decimal l, c, h;
    };

    private const string _lchFormat = "G";

    private MILColorM _lchColor;

    #endregion

    #region Properties

    /// <summary>
    /// Gets or sets the L component of the Lch color as a decimal-point value in the range [0, 100].
    /// </summary>
    public decimal L
    {
        readonly get => _lchColor.l;
        set => _lchColor.l = ClampLToLchRange(value);
    }

    /// <summary>
    /// Gets or sets the C component of the Lch color as a decimal-point value in the range [0, 100].
    /// </summary>
    public decimal C
    {
        readonly get => _lchColor.c;
        set => _lchColor.c = ClampCToLchRange(value);
    }

    /// <summary>
    /// Gets or sets the H component of the Lch color as a decimal-point value in the range [0, 360].
    /// </summary>
    public decimal H
    {
        readonly get => _lchColor.h;
        set => _lchColor.h = ClampHToLchRange(value);
    }

    #endregion

    #region Constructors

    /// <summary>
    /// Creates a new instance of the Lch color structure from decimal-point Lch components.
    /// </summary>
    /// <param name="l">The L component of the Lch color as a decimal-point value in the range [0, 100].</param>
    /// <param name="c">The C component of the Lch color as a decimal-point value in the range [0, 100].</param>
    /// <param name="h">The H component of the Lch color as a decimal-point value in the range [0, 360].</param>
    /// <returns>A new instance of the Lch color structure.</returns>
    public static Lch FromLch(decimal l, decimal c, decimal h)
    {
        var lch = new Lch();

        lch._lchColor.l = ClampLToLchRange(l);
        lch._lchColor.c = ClampCToLchRange(c);
        lch._lchColor.h = ClampHToLchRange(h);

        return lch;
    }

    #endregion

    #region Methods

    /// <inheritdoc/>
    public override readonly int GetHashCode()
    {
        return _lchColor.GetHashCode();
    }

    /// <summary>
    /// Creates a string representation of this object based on the current culture.
    /// </summary>
    /// <returns>
    /// A string representation of this object.
    /// </returns>
    public override readonly string ToString()
    {
        return ConvertToString(_lchFormat, null);
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
        return ConvertToString(_lchFormat, provider);
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
                            _lchColor.l,
                            _lchColor.c,
                            _lchColor.h);
        }
        else
        {
            sb.AppendFormat(provider,
                            "{1:" + format + "}{0} {2:" + format + "}{0} {3:" + format + "}{0}",
                            separator,
                            _lchColor.l,
                            _lchColor.c,
                            _lchColor.h);
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
    public static bool AreClose(Lch color1, Lch color2)
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
    private readonly bool IsClose(Lch color)
    {
        var result = true;

        result = result && DecimalHelpers.AreClose(_lchColor.l, color._lchColor.l);
        result = result && DecimalHelpers.AreClose(_lchColor.c, color._lchColor.c);
        return result && DecimalHelpers.AreClose(_lchColor.h, color._lchColor.h);
    }

    private static decimal ClampLToLchRange(decimal val)
    {
        return val < 0 ? 0 : val > 100 ? 100 : val;
    }

    private static decimal ClampCToLchRange(decimal val)
    {
        return val < 0 ? 0 : val > 100 ? 100 : val;
    }

    private static decimal ClampHToLchRange(decimal val)
    {
        return val < 0 ? 0 : val > 360 ? 360 : val;
    }

    #endregion

    #region Operators

    /// <summary>
    /// Addition operator - Adds each channel of the second color to each channel of the
    /// first and returns the result.
    /// </summary>
    public static Lch operator +(Lch color1, Lch color2)
    {
        return FromLch(color1._lchColor.l + color2._lchColor.l,
                       color1._lchColor.c + color2._lchColor.c,
                       color1._lchColor.h + color2._lchColor.h);
    }

    /// <summary>
    /// Addition method - Adds each channel of the second color to each channel of the
    /// first and returns the result.
    /// </summary>
    public static Lch Add(Lch color1, Lch color2)
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
    public static Lch operator -(Lch color1, Lch color2)
    {
        return FromLch(color1._lchColor.l - color2._lchColor.l,
                       color1._lchColor.c - color2._lchColor.c,
                       color1._lchColor.h - color2._lchColor.h);
    }

    /// <summary>
    /// Subtract operator - substracts each channel of the second color from each channel of the
    /// first and returns the result.
    /// </summary>
    /// <param name='color1'>The minuend.</param>
    /// <param name='color2'>The subtrahend.</param>
    /// <returns>Returns the unclamped differnce.</returns>
    public static Lch Subtract(Lch color1, Lch color2)
    {
        return color1 - color2;
    }

    /// <summary>
    /// Multiplication operator - Multiplies each channel of the color by a coefficient and returns the result.
    /// </summary>
    /// <param name='color'>The color.</param>
    /// <param name='coefficient'>The coefficient.</param>
    /// <returns>Returns the unclamped product.</returns>
    public static Lch operator *(Lch color, decimal coefficient)
    {
        return FromLch(color._lchColor.l * coefficient,
                       color._lchColor.c * coefficient,
                       color._lchColor.h * coefficient);
    }

    /// <summary>
    /// Multiplication operator - Multiplies each channel of the color by a coefficient and returns the result.
    /// </summary>
    /// <param name='color'>The color.</param>
    /// <param name='coefficient'>The coefficient.</param>
    /// <returns>Returns the unclamped product.</returns>
    public static Lch Multiply(Lch color, decimal coefficient)
    {
        return color * coefficient;
    }

    /// <summary>
    /// IsEqual operator - Compares two colors for exact equality. Note that decimal values can acquire error
    /// when operated upon, such that an exact comparison between two values which are logically
    /// equal may fail. See <see cref="AreClose"/>.
    /// </summary>
    public static bool operator ==(Lch color1, Lch color2)
    {
        return color1._lchColor.l == color2._lchColor.l
               && color1._lchColor.c == color2._lchColor.c
               && color1._lchColor.h == color2._lchColor.h;
    }

    /// <summary>
    /// IsEqual operator - Compares two colors for exact equality. Note that decimal values can acquire error
    /// when operated upon, such that an exact comparison between two values which are logically
    /// equal may fail. See <see cref="AreClose"/>.
    /// </summary>
    public static bool Equals(Lch color1, Lch color2)
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
    public readonly bool Equals(Lch color)
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
        return o is Lch color && this == color;
    }

    /// <summary>
    /// IsNotEqual operator - Compares two colors for exact inequality. Note that decimal values can acquire error
    /// when operated upon, such that an exact comparison between two values which are logically
    /// equal may fail. See <see cref="AreClose"/>.
    /// </summary>
    public static bool operator !=(Lch color1, Lch color2)
    {
        return !(color1 == color2);
    }

    #endregion
}