using System.Text;
using ColorSpace.Net.Helpers;

namespace ColorSpace.Net.Colors;

/// <summary>
/// Represents a color in the YXY (CIE 1931) color space.
/// </summary>
public struct Yxy : IColor, IEquatable<Yxy>
{
    #region Fields/Consts

    private struct MILColorM
    {
        public decimal y1, x, y2;
    };

    private const string _yxyFormat = "G";

    private MILColorM _yxyColor;

    #endregion

    #region Properties

    /// <summary>
    /// Gets or sets the Y1 component of the YXY color as a decimal-point value in the range [0, 100].
    /// </summary>
    public decimal Y1
    {
        readonly get => _yxyColor.y1;
        set => _yxyColor.y1 = ClampY1ToHunterYxyRange(value);
    }

    /// <summary>
    /// Gets or sets the X component of the YXY color as a decimal-point value in the range [0, 1].
    /// </summary>
    public decimal X
    {
        readonly get => _yxyColor.x;
        set => _yxyColor.x = ClampXToHunterYxyRange(value);
    }

    /// <summary>
    /// Gets or sets the Y2 component of the YXY color as a decimal-point value in the range [0, 1].
    /// </summary>
    public decimal Y2
    {
        readonly get => _yxyColor.y2;
        set => _yxyColor.y2 = ClampY2ToHunterYxyRange(value);
    }

    #endregion

    #region Constructors

    /// <summary>
    /// Creates a new instance of the YXY color structure from decimal-point YXY components.
    /// </summary>
    /// <param name="y1">The Y1 component of the YXY color as a decimal-point value in the range [0, 100].</param>
    /// <param name="x">The X component of the YXY color as a decimal-point value in the range [0, 1].</param>
    /// <param name="y2">The Y2 component of the YXY color as a decimal-point value in the range [0, 1].</param>
    /// <returns>A new instance of the YXY color structure.</returns>
    public static Yxy FromYxy(decimal y1, decimal x, decimal y2)
    {
        var yxy = new Yxy();

        yxy._yxyColor.y1 = ClampY1ToHunterYxyRange(y1);
        yxy._yxyColor.x = ClampXToHunterYxyRange(x);
        yxy._yxyColor.y2 = ClampY2ToHunterYxyRange(y2);

        return yxy;
    }

    #endregion

    #region Methods

    /// <inheritdoc/>
    public override readonly int GetHashCode()
    {
        return _yxyColor.GetHashCode();
    }

    /// <summary>
    /// Creates a string representation of this object based on the current culture.
    /// </summary>
    /// <returns>
    /// A string representation of this object.
    /// </returns>
    public override readonly string ToString()
    {
        return ConvertToString(_yxyFormat, null);
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
        return ConvertToString(_yxyFormat, provider);
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
                            _yxyColor.y1,
                            _yxyColor.x,
                            _yxyColor.y2);
        }
        else
        {
            sb.AppendFormat(provider,
                            "{1:" + format + "}{0} {2:" + format + "}{0} {3:" + format + "}{0}",
                            separator,
                            _yxyColor.y1,
                            _yxyColor.x,
                            _yxyColor.y2);
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
    public static bool AreClose(Yxy color1, Yxy color2)
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
    private readonly bool IsClose(Yxy color)
    {
        var result = true;

        result = result && DecimalHelpers.AreClose(_yxyColor.y1, color._yxyColor.y1);
        result = result && DecimalHelpers.AreClose(_yxyColor.x, color._yxyColor.x);
        return result && DecimalHelpers.AreClose(_yxyColor.y2, color._yxyColor.y2);
    }

    private static decimal ClampY1ToHunterYxyRange(decimal val)
    {
        return val < 0 ? 0 : val > 100 ? 100 : val;
    }

    private static decimal ClampXToHunterYxyRange(decimal val)
    {
        return val < 0 ? 0 : val > 1 ? 1 : val;
    }

    private static decimal ClampY2ToHunterYxyRange(decimal val)
    {
        return val < 0 ? 0 : val > 1 ? 1 : val;
    }

    #endregion

    #region Operators

    /// <summary>
    /// Addition operator - Adds each channel of the second color to each channel of the
    /// first and returns the result.
    /// </summary>
    public static Yxy operator +(Yxy color1, Yxy color2)
    {
        return FromYxy(color1._yxyColor.y1 + color2._yxyColor.y1,
                       color1._yxyColor.x + color2._yxyColor.x,
                       color1._yxyColor.y2 + color2._yxyColor.y2);
    }

    /// <summary>
    /// Addition method - Adds each channel of the second color to each channel of the
    /// first and returns the result.
    /// </summary>
    public static Yxy Add(Yxy color1, Yxy color2)
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
    public static Yxy operator -(Yxy color1, Yxy color2)
    {
        return FromYxy(color1._yxyColor.y1 - color2._yxyColor.y1,
                       color1._yxyColor.x - color2._yxyColor.x,
                       color1._yxyColor.y2 - color2._yxyColor.y2);
    }

    /// <summary>
    /// Subtract operator - substracts each channel of the second color from each channel of the
    /// first and returns the result.
    /// </summary>
    /// <param name='color1'>The minuend.</param>
    /// <param name='color2'>The subtrahend.</param>
    /// <returns>Returns the unclamped differnce.</returns>
    public static Yxy Subtract(Yxy color1, Yxy color2)
    {
        return color1 - color2;
    }

    /// <summary>
    /// Multiplication operator - Multiplies each channel of the color by a coefficient and returns the result.
    /// </summary>
    /// <param name='color'>The color.</param>
    /// <param name='coefficient'>The coefficient.</param>
    /// <returns>Returns the unclamped product.</returns>
    public static Yxy operator *(Yxy color, decimal coefficient)
    {
        return FromYxy(color._yxyColor.y1 * coefficient,
                       color._yxyColor.x * coefficient,
                       color._yxyColor.y2 * coefficient);
    }

    /// <summary>
    /// Multiplication operator - Multiplies each channel of the color by a coefficient and returns the result.
    /// </summary>
    /// <param name='color'>The color.</param>
    /// <param name='coefficient'>The coefficient.</param>
    /// <returns>Returns the unclamped product.</returns>
    public static Yxy Multiply(Yxy color, decimal coefficient)
    {
        return color * coefficient;
    }

    /// <summary>
    /// IsEqual operator - Compares two colors for exact equality. Note that decimal values can acquire error
    /// when operated upon, such that an exact comparison between two values which are logically
    /// equal may fail. See <see cref="AreClose"/>.
    /// </summary>
    public static bool operator ==(Yxy color1, Yxy color2)
    {
        return color1._yxyColor.y1 == color2._yxyColor.y1
               && color1._yxyColor.x == color2._yxyColor.x
               && color1._yxyColor.y2 == color2._yxyColor.y2;
    }

    /// <summary>
    /// IsEqual operator - Compares two colors for exact equality. Note that decimal values can acquire error
    /// when operated upon, such that an exact comparison between two values which are logically
    /// equal may fail. See <see cref="AreClose"/>.
    /// </summary>
    public static bool Equals(Yxy color1, Yxy color2)
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
    public readonly bool Equals(Yxy color)
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
        return o is Yxy color && this == color;
    }

    /// <summary>
    /// IsNotEqual operator - Compares two colors for exact inequality. Note that decimal values can acquire error
    /// when operated upon, such that an exact comparison between two values which are logically
    /// equal may fail. See <see cref="AreClose"/>.
    /// </summary>
    public static bool operator !=(Yxy color1, Yxy color2)
    {
        return !(color1 == color2);
    }

    #endregion
}