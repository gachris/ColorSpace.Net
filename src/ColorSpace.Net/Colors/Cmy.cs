using System.Text;
using ColorSpace.Net.Helpers;

namespace ColorSpace.Net.Colors;

/// <summary>
/// Represents a color in the CMY (Cyan, Magenta, Yellow) color space.
/// </summary>
public struct Cmy : IColor, IEquatable<Cmy>
{
    #region Fields/Consts

    private struct MILColorM
    {
        public decimal c, m, y;
    };

    private const string _cmyFormat = "G";

    private MILColorM _cmyColor;

    #endregion

    #region Properties

    /// <summary>
    /// Gets or sets the cyan component of the CMY color as a decimal-point value in the range [0, 1].
    /// </summary>
    public decimal C
    {
        readonly get => _cmyColor.c;
        set => _cmyColor.c = ClampToCmyRange(value);
    }

    /// <summary>
    /// Gets or sets the magenta component of the CMY color as a decimal-point value in the range [0, 1].
    /// </summary>
    public decimal M
    {
        readonly get => _cmyColor.m;
        set => _cmyColor.m = ClampToCmyRange(value);
    }

    /// <summary>
    /// Gets or sets the yellow component of the CMY color as a decimal-point value in the range [0, 1].
    /// </summary>
    public decimal Y
    {
        readonly get => _cmyColor.y;
        set => _cmyColor.y = ClampToCmyRange(value);
    }

    #endregion

    #region Constructors

    /// <summary>
    /// Creates a new instance of the CMY color structure from decimal-point CMY components.
    /// </summary>
    /// <param name="c">The cyan component of the CMY color as a decimal-point value in the range [0, 1].</param>
    /// <param name="m">The magenta component of the CMY color as a decimal-point value in the range [0, 1].</param>
    /// <param name="y">The yellow component of the CMY color as a decimal-point value in the range [0, 1].</param>
    /// <returns>A new instance of the CMY color structure.</returns>
    public static Cmy FromCmy(decimal c, decimal m, decimal y)
    {
        var cmy = new Cmy();

        cmy._cmyColor.c = ClampToCmyRange(c);
        cmy._cmyColor.m = ClampToCmyRange(m);
        cmy._cmyColor.y = ClampToCmyRange(y);

        return cmy;
    }

    #endregion

    #region Methods

    /// <inheritdoc/>
    public override readonly int GetHashCode()
    {
        return _cmyColor.GetHashCode();
    }

    /// <summary>
    /// Creates a string representation of this object based on the current culture.
    /// </summary>
    /// <returns>
    /// A string representation of this object.
    /// </returns>
    public override readonly string ToString()
    {
        return ConvertToString(_cmyFormat, null);
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
        return ConvertToString(_cmyFormat, provider);
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
                            _cmyColor.c,
                            _cmyColor.m,
                            _cmyColor.y);
        }
        else
        {
            sb.AppendFormat(provider,
                            "{1:" + format + "}{0} {2:" + format + "}{0} {3:" + format + "}{0}",
                            separator,
                            _cmyColor.c,
                            _cmyColor.m,
                            _cmyColor.y);
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
    public static bool AreClose(Cmy color1, Cmy color2)
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
    private readonly bool IsClose(Cmy color)
    {
        var result = true;

        result = result && DecimalHelpers.AreClose(_cmyColor.c, color._cmyColor.c);
        result = result && DecimalHelpers.AreClose(_cmyColor.m, color._cmyColor.m);
        return result && DecimalHelpers.AreClose(_cmyColor.y, color._cmyColor.y);
    }

    private static decimal ClampToCmyRange(decimal val)
    {
        return val < 0 ? 0 : val > 1 ? 1 : val;
    }

    #endregion

    #region Operators

    /// <summary>
    /// Addition operator - Adds each channel of the second color to each channel of the
    /// first and returns the result.
    /// </summary>
    public static Cmy operator +(Cmy color1, Cmy color2)
    {
        return FromCmy(color1._cmyColor.c + color2._cmyColor.c,
                       color1._cmyColor.m + color2._cmyColor.m,
                       color1._cmyColor.y + color2._cmyColor.y);
    }

    /// <summary>
    /// Addition method - Adds each channel of the second color to each channel of the
    /// first and returns the result.
    /// </summary>
    public static Cmy Add(Cmy color1, Cmy color2)
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
    public static Cmy operator -(Cmy color1, Cmy color2)
    {
        return FromCmy(color1._cmyColor.c - color2._cmyColor.c,
                       color1._cmyColor.m - color2._cmyColor.m,
                       color1._cmyColor.y - color2._cmyColor.y);
    }

    /// <summary>
    /// Subtract operator - substracts each channel of the second color from each channel of the
    /// first and returns the result.
    /// </summary>
    /// <param name='color1'>The minuend.</param>
    /// <param name='color2'>The subtrahend.</param>
    /// <returns>Returns the unclamped differnce.</returns>
    public static Cmy Subtract(Cmy color1, Cmy color2)
    {
        return color1 - color2;
    }

    /// <summary>
    /// Multiplication operator - Multiplies each channel of the color by a coefficient and returns the result.
    /// </summary>
    /// <param name='color'>The color.</param>
    /// <param name='coefficient'>The coefficient.</param>
    /// <returns>Returns the unclamped product.</returns>
    public static Cmy operator *(Cmy color, decimal coefficient)
    {
        return FromCmy(color._cmyColor.c * coefficient,
                       color._cmyColor.m * coefficient,
                       color._cmyColor.y * coefficient);
    }

    /// <summary>
    /// Multiplication operator - Multiplies each channel of the color by a coefficient and returns the result.
    /// </summary>
    /// <param name='color'>The color.</param>
    /// <param name='coefficient'>The coefficient.</param>
    /// <returns>Returns the unclamped product.</returns>
    public static Cmy Multiply(Cmy color, decimal coefficient)
    {
        return color * coefficient;
    }

    /// <summary>
    /// IsEqual operator - Compares two colors for exact equality. Note that decimal values can acquire error
    /// when operated upon, such that an exact comparison between two values which are logically
    /// equal may fail. See <see cref="AreClose"/>.
    /// </summary>
    public static bool operator ==(Cmy color1, Cmy color2)
    {
        return color1._cmyColor.c == color2._cmyColor.c
               && color1._cmyColor.m == color2._cmyColor.m
               && color1._cmyColor.y == color2._cmyColor.y;
    }

    /// <summary>
    /// IsEqual operator - Compares two colors for exact equality. Note that decimal values can acquire error
    /// when operated upon, such that an exact comparison between two values which are logically
    /// equal may fail. See <see cref="AreClose"/>.
    /// </summary>
    public static bool Equals(Cmy color1, Cmy color2)
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
    public readonly bool Equals(Cmy color)
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
        return o is Cmy color && this == color;
    }

    /// <summary>
    /// IsNotEqual operator - Compares two colors for exact inequality. Note that decimal values can acquire error
    /// when operated upon, such that an exact comparison between two values which are logically
    /// equal may fail. See <see cref="AreClose"/>.
    /// </summary>
    public static bool operator !=(Cmy color1, Cmy color2)
    {
        return !(color1 == color2);
    }

    #endregion
}