using System.Text;
using ColorSpace.Net.Helpers;

namespace ColorSpace.Net.Colors;

/// <summary>
/// Represents a color in the CMYK (Cyan, Magenta, Yellow, Black) color space.
/// </summary>
public struct Cmyk : IColor, IEquatable<Cmyk>
{
    #region Fields/Consts

    private struct MILColorM
    {
        public decimal c, m, y, k;
    };

    private const string _cmykFormat = "G";

    private MILColorM _cmykColor;

    #endregion

    #region Properties

    /// <summary>
    /// Gets or sets the cyan component of the CMYK color as a decimal-point value in the range [0, 1].
    /// </summary>
    public decimal C
    {
        readonly get => _cmykColor.c;
        set => _cmykColor.c = ClampToCmykRange(value);
    }

    /// <summary>
    /// Gets or sets the magenta component of the CMYK color as a decimal-point value in the range [0, 1].
    /// </summary>
    public decimal M
    {
        readonly get => _cmykColor.m;
        set => _cmykColor.m = ClampToCmykRange(value);
    }

    /// <summary>
    /// Gets or sets the yellow component of the CMYK color as a decimal-point value in the range [0, 1].
    /// </summary>
    public decimal Y
    {
        readonly get => _cmykColor.y;
        set => _cmykColor.y = ClampToCmykRange(value);
    }

    /// <summary>
    /// Gets or sets the black component of the CMYK color as a decimal-point value in the range [0, 1].
    /// </summary>
    public decimal K
    {
        readonly get => _cmykColor.k;
        set => _cmykColor.k = ClampToCmykRange(value);
    }

    #endregion

    #region Constructors

    /// <summary>
    /// Creates a new instance of the CMYK color structure from decimal-point CMYK components.
    /// </summary>
    /// <param name="c">The cyan component of the CMYK color as a decimal-point value in the range [0, 1].</param>
    /// <param name="m">The magenta component of the CMYK color as a decimal-point value in the range [0, 1].</param>
    /// <param name="y">The yellow component of the CMYK color as a decimal-point value in the range [0, 1].</param>
    /// <param name="k">The black component of the CMYK color as a decimal-point value in the range [0, 1].</param>
    /// <returns>A new instance of the CMYK color structure.</returns>
    public static Cmyk FromCmyk(decimal c, decimal m, decimal y, decimal k)
    {
        var cmyk = new Cmyk();

        cmyk._cmykColor.c = ClampToCmykRange(c);
        cmyk._cmykColor.m = ClampToCmykRange(m);
        cmyk._cmykColor.y = ClampToCmykRange(y);
        cmyk._cmykColor.k = ClampToCmykRange(k);

        return cmyk;
    }

    #endregion

    #region Methods

    /// <inheritdoc/>
    public override readonly int GetHashCode()
    {
        return _cmykColor.GetHashCode();
    }

    /// <summary>
    /// Creates a string representation of this object based on the current culture.
    /// </summary>
    /// <returns>
    /// A string representation of this object.
    /// </returns>
    public override readonly string ToString()
    {
        return ConvertToString(_cmykFormat, null);
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
        return ConvertToString(_cmykFormat, provider);
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
                            "{1}{0} {2}{0} {3}{0} {4}{0}",
                            separator,
                            _cmykColor.c,
                            _cmykColor.m,
                            _cmykColor.y,
                            _cmykColor.k);
        }
        else
        {
            sb.AppendFormat(provider,
                            "{1:" + format + "}{0} {2:" + format + "}{0} {3:" + format + "}{0} {4:" + format + "}{0}",
                            separator,
                            _cmykColor.c,
                            _cmykColor.m,
                            _cmykColor.y,
                            _cmykColor.k);
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
    public static bool AreClose(Cmyk color1, Cmyk color2)
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
    private readonly bool IsClose(Cmyk color)
    {
        var result = true;

        result = result && DecimalHelpers.AreClose(_cmykColor.c, color._cmykColor.c);
        result = result && DecimalHelpers.AreClose(_cmykColor.m, color._cmykColor.m);
        result = result && DecimalHelpers.AreClose(_cmykColor.y, color._cmykColor.y);
        return result && DecimalHelpers.AreClose(_cmykColor.k, color._cmykColor.k);
    }

    private static decimal ClampToCmykRange(decimal val)
    {
        return val < 0 ? 0 : val > 1 ? 1 : val;
    }

    #endregion

    #region Operators

    /// <summary>
    /// Addition operator - Adds each channel of the second color to each channel of the
    /// first and returns the result.
    /// </summary>
    public static Cmyk operator +(Cmyk color1, Cmyk color2)
    {
        return FromCmyk(color1._cmykColor.c + color2._cmykColor.c,
                        color1._cmykColor.m + color2._cmykColor.m,
                        color1._cmykColor.y + color2._cmykColor.y,
                        color1._cmykColor.k + color2._cmykColor.k);
    }

    /// <summary>
    /// Addition method - Adds each channel of the second color to each channel of the
    /// first and returns the result.
    /// </summary>
    public static Cmyk Add(Cmyk color1, Cmyk color2)
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
    public static Cmyk operator -(Cmyk color1, Cmyk color2)
    {
        return FromCmyk(color1._cmykColor.c - color2._cmykColor.c,
                        color1._cmykColor.m - color2._cmykColor.m,
                        color1._cmykColor.y - color2._cmykColor.y,
                        color1._cmykColor.k - color2._cmykColor.k);
    }

    /// <summary>
    /// Subtract operator - substracts each channel of the second color from each channel of the
    /// first and returns the result.
    /// </summary>
    /// <param name='color1'>The minuend.</param>
    /// <param name='color2'>The subtrahend.</param>
    /// <returns>Returns the unclamped differnce.</returns>
    public static Cmyk Subtract(Cmyk color1, Cmyk color2)
    {
        return color1 - color2;
    }

    /// <summary>
    /// Multiplication operator - Multiplies each channel of the color by a coefficient and returns the result.
    /// </summary>
    /// <param name='color'>The color.</param>
    /// <param name='coefficient'>The coefficient.</param>
    /// <returns>Returns the unclamped product.</returns>
    public static Cmyk operator *(Cmyk color, decimal coefficient)
    {
        return FromCmyk(color._cmykColor.c * coefficient,
                        color._cmykColor.m * coefficient,
                        color._cmykColor.y * coefficient,
                        color._cmykColor.k * coefficient);
    }

    /// <summary>
    /// Multiplication operator - Multiplies each channel of the color by a coefficient and returns the result.
    /// </summary>
    /// <param name='color'>The color.</param>
    /// <param name='coefficient'>The coefficient.</param>
    /// <returns>Returns the unclamped product.</returns>
    public static Cmyk Multiply(Cmyk color, decimal coefficient)
    {
        return color * coefficient;
    }

    /// <summary>
    /// IsEqual operator - Compares two colors for exact equality. Note that decimal values can acquire error
    /// when operated upon, such that an exact comparison between two values which are logically
    /// equal may fail. See <see cref="AreClose"/>.
    /// </summary>
    public static bool operator ==(Cmyk color1, Cmyk color2)
    {
        return color1._cmykColor.c == color2._cmykColor.c
               && color1._cmykColor.m == color2._cmykColor.m
               && color1._cmykColor.y == color2._cmykColor.y
               && color1._cmykColor.k == color2._cmykColor.k;
    }

    /// <summary>
    /// IsEqual operator - Compares two colors for exact equality. Note that decimal values can acquire error
    /// when operated upon, such that an exact comparison between two values which are logically
    /// equal may fail. See <see cref="AreClose"/>.
    /// </summary>
    public static bool Equals(Cmyk color1, Cmyk color2)
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
    public readonly bool Equals(Cmyk color)
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
        return o is Cmyk color && this == color;
    }

    /// <summary>
    /// IsNotEqual operator - Compares two colors for exact inequality. Note that decimal values can acquire error
    /// when operated upon, such that an exact comparison between two values which are logically
    /// equal may fail. See <see cref="AreClose"/>.
    /// </summary>
    public static bool operator !=(Cmyk color1, Cmyk color2)
    {
        return !(color1 == color2);
    }

    #endregion
}
