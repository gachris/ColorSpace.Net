using System.Text;
using ColorSpace.Net.Helpers;

namespace ColorSpace.Net.Colors;

/// <summary>
/// Represents a color in the CIE Lab* (Lab) color space.
/// </summary>
public struct Lab : IColor, IEquatable<Lab>
{
    #region Fields/Consts

    private struct MILColorΜ
    {
        public decimal l, a, b;
    };

    private const string _labFormat = "G";

    private MILColorΜ _labColor;

    #endregion

    #region Properties

    /// <summary>
    /// Gets or sets the L component of the LAB color as a decimal-point value in the range [0, 100].
    /// </summary>
    public decimal L
    {
        readonly get => _labColor.l;
        set => _labColor.l = ClampLToHunterLabRange(value);
    }

    /// <summary>
    /// Gets or sets the A component of the LAB color as a decimal-point value in the range [-128, 128].
    /// </summary>
    public decimal A
    {
        readonly get => _labColor.a;
        set => _labColor.a = ClampAToHunterLabRange(value);
    }

    /// <summary>
    /// Gets or sets the B component of the LAB color as a decimal-point value in the range [-128, 128].
    /// </summary>
    public decimal B
    {
        readonly get => _labColor.b;
        set => _labColor.b = ClampBToHunterLabRange(value);
    }

    #endregion

    #region Constructors

    /// <summary>
    /// Creates a new instance of the LAB color structure from decimal-point LAB components.
    /// </summary>
    /// <param name="l">The L component of the LAB color as a decimal-point value in the range [0, 100]</param>
    /// <param name="a">The A component of the LAB color as a decimal-point value in the range [-128, 128]</param>
    /// <param name="b">The B component of the LAB color as a decimal-point value in the range [-128, 128]</param>
    /// <returns>A new instance of the LAB color structure.</returns>
    public static Lab FromLab(decimal l, decimal a, decimal b)
    {
        var lab = new Lab();

        lab._labColor.l = ClampLToHunterLabRange(l);
        lab._labColor.a = ClampAToHunterLabRange(a);
        lab._labColor.b = ClampBToHunterLabRange(b);

        return lab;
    }

    #endregion

    #region Methods

    /// <inheritdoc/>
    public override readonly int GetHashCode()
    {
        return _labColor.GetHashCode();
    }

    /// <summary>
    /// Creates a string representation of this object based on the current culture.
    /// </summary>
    /// <returns>
    /// A string representation of this object.
    /// </returns>
    public override readonly string ToString()
    {
        return ConvertToString(_labFormat, null);
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
        return ConvertToString(_labFormat, provider);
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
                            _labColor.l,
                            _labColor.a,
                            _labColor.b);
        }
        else
        {
            sb.AppendFormat(provider,
                            "{1:" + format + "}{0} {2:" + format + "}{0} {3:" + format + "}{0}",
                            separator,
                            _labColor.l,
                            _labColor.a,
                            _labColor.b);
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
    public static bool AreClose(Lab color1, Lab color2)
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
    private readonly bool IsClose(Lab color)
    {
        var result = true;

        result = result && DecimalHelpers.AreClose(_labColor.l, color._labColor.l);
        result = result && DecimalHelpers.AreClose(_labColor.a, color._labColor.a);
        return result && DecimalHelpers.AreClose(_labColor.b, color._labColor.b);
    }

    private static decimal ClampLToHunterLabRange(decimal val)
    {
        return val < 0 ? 0 : val > 100 ? 100 : val;
    }

    private static decimal ClampBToHunterLabRange(decimal val)
    {
        return val < -128 ? -128 : val > 128 ? 128 : val;
    }

    private static decimal ClampAToHunterLabRange(decimal val)
    {
        return val < -128 ? -128 : val > 128 ? 128 : val;
    }

    #endregion

    #region Operators

    /// <summary>
    /// Addition operator - Adds each channel of the second color to each channel of the
    /// first and returns the result.
    /// </summary>
    public static Lab operator +(Lab color1, Lab color2)
    {
        return FromLab(color1._labColor.l + color2._labColor.l,
                         color1._labColor.a + color2._labColor.a,
                         color1._labColor.b + color2._labColor.b);
    }

    /// <summary>
    /// Addition method - Adds each channel of the second color to each channel of the
    /// first and returns the result.
    /// </summary>
    public static Lab Add(Lab color1, Lab color2)
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
    public static Lab operator -(Lab color1, Lab color2)
    {
        return FromLab(color1._labColor.l - color2._labColor.l,
                         color1._labColor.a - color2._labColor.a,
                         color1._labColor.b - color2._labColor.b);
    }

    /// <summary>
    /// Subtract operator - substracts each channel of the second color from each channel of the
    /// first and returns the result.
    /// </summary>
    /// <param name='color1'>The minuend.</param>
    /// <param name='color2'>The subtrahend.</param>
    /// <returns>Returns the unclamped differnce.</returns>
    public static Lab Subtract(Lab color1, Lab color2)
    {
        return color1 - color2;
    }

    /// <summary>
    /// Multiplication operator - Multiplies each channel of the color by a coefficient and returns the result.
    /// </summary>
    /// <param name='color'>The color.</param>
    /// <param name='coefficient'>The coefficient.</param>
    /// <returns>Returns the unclamped product.</returns>
    public static Lab operator *(Lab color, decimal coefficient)
    {
        return FromLab(color._labColor.l * coefficient,
                         color._labColor.a * coefficient,
                         color._labColor.b * coefficient);
    }

    /// <summary>
    /// Multiplication operator - Multiplies each channel of the color by a coefficient and returns the result.
    /// </summary>
    /// <param name='color'>The color.</param>
    /// <param name='coefficient'>The coefficient.</param>
    /// <returns>Returns the unclamped product.</returns>
    public static Lab Multiply(Lab color, decimal coefficient)
    {
        return color * coefficient;
    }

    /// <summary>
    /// IsEqual operator - Compares two colors for exact equality. Note that decimal values can acquire error
    /// when operated upon, such that an exact comparison between two values which are logically
    /// equal may fail. See <see cref="AreClose"/>.
    /// </summary>
    public static bool operator ==(Lab color1, Lab color2)
    {
        return color1._labColor.l == color2._labColor.l
               && color1._labColor.a == color2._labColor.a
               && color1._labColor.b == color2._labColor.b;
    }

    /// <summary>
    /// IsEqual operator - Compares two colors for exact equality. Note that decimal values can acquire error
    /// when operated upon, such that an exact comparison between two values which are logically
    /// equal may fail. See <see cref="AreClose"/>.
    /// </summary>
    public static bool Equals(Lab color1, Lab color2)
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
    public readonly bool Equals(Lab color)
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
        return o is Lab color && this == color;
    }

    /// <summary>
    /// IsNotEqual operator - Compares two colors for exact inequality. Note that decimal values can acquire error
    /// when operated upon, such that an exact comparison between two values which are logically
    /// equal may fail. See <see cref="AreClose"/>.
    /// </summary>
    public static bool operator !=(Lab color1, Lab color2)
    {
        return !(color1 == color2);
    }

    #endregion
}