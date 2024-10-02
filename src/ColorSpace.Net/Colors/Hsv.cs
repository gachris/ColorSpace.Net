using System.Text;
using ColorSpace.Net.Helpers;

namespace ColorSpace.Net.Colors;

/// <summary>
/// Represents a color in the Hsv (Hue, Saturation, Value) color space.
/// </summary>
public struct Hsv : IColor, IEquatable<Hsv>
{
    #region Fields/Consts

    private struct MILColorM
    {
        public decimal h, s, v;
    }

    private const string _hsvFormat = "G";

    private MILColorM _hsvColor;

    #endregion

    #region Properties

    /// <summary>
    /// Gets or sets the hue component of the Hsv color as a decimal-point value in the range [0, 360].
    /// </summary>
    public decimal H
    {
        readonly get => _hsvColor.h;
        set => _hsvColor.h = ClampHToHsvRange(value);
    }

    /// <summary>
    /// Gets or sets the saturation component of the Hsv color as a decimal-point value in the range [0, 1].
    /// </summary>
    public decimal S
    {
        readonly get => _hsvColor.s;
        set => _hsvColor.s = ClampSToHsvRange(value);
    }

    /// <summary>
    /// Gets or sets the value component of the Hsv color as a decimal-point value in the range [0, 1].
    /// </summary>
    public decimal V
    {
        readonly get => _hsvColor.v;
        set => _hsvColor.v = ClampVToHsvRange(value);
    }

    #endregion

    #region Constructors

    /// <summary>
    /// Creates a new instance of the Hsv color structure.
    /// </summary>
    /// <param name="h">The hue component of the Hsv color as a decimal-point value in the range [0, 360].</param>
    /// <param name="s">The saturation component of the Hsv color as a decimal-point value in the range [0, 1].</param>
    /// <param name="v">The value component of the Hsv color as a decimal-point value in the range [0, 1].</param>
    /// <returns>A new instance of the Hsv color structure.</returns>
    public static Hsv FromHsv(decimal h, decimal s, decimal v)
    {
        var hsv = new Hsv();

        hsv._hsvColor.h = ClampHToHsvRange(h);
        hsv._hsvColor.s = ClampSToHsvRange(s);
        hsv._hsvColor.v = ClampVToHsvRange(v);

        return hsv;
    }

    #endregion

    #region Methods

    /// <inheritdoc/>
    public override readonly int GetHashCode()
    {
        return _hsvColor.GetHashCode();
    }

    /// <summary>
    /// Creates a string representation of this object based on the current culture.
    /// </summary>
    /// <returns>
    /// A string representation of this object.
    /// </returns>
    public override readonly string ToString()
    {
        return ConvertToString(_hsvFormat, null);
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
        return ConvertToString(_hsvFormat, provider);
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
                            _hsvColor.h,
                            _hsvColor.s,
                            _hsvColor.v);
        }
        else
        {
            sb.AppendFormat(provider,
                            "{1:" + format + "}{0} {2:" + format + "}{0} {3:" + format + "}{0}",
                            separator,
                            _hsvColor.h,
                            _hsvColor.s,
                            _hsvColor.v);
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
    public static bool AreClose(Hsv color1, Hsv color2)
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
    private readonly bool IsClose(Hsv color)
    {
        var result = true;

        result = result && DecimalHelpers.AreClose(_hsvColor.h, color._hsvColor.h);
        result = result && DecimalHelpers.AreClose(_hsvColor.s, color._hsvColor.s);
        return result && DecimalHelpers.AreClose(_hsvColor.v, color._hsvColor.v);
    }

    private static decimal ClampHToHsvRange(decimal val)
    {
        return val < 0 ? 0 : val > 360 ? 360 : val;
    }

    private static decimal ClampSToHsvRange(decimal val)
    {
        return val < 0 ? 0 : val > 1 ? 1 : val;
    }

    private static decimal ClampVToHsvRange(decimal val)
    {
        return val < 0 ? 0 : val > 1 ? 1 : val;
    }

    #endregion

    #region Operators

    /// <summary>
    /// Addition operator - Adds each channel of the second color to each channel of the
    /// first and returns the result.
    /// </summary>
    public static Hsv operator +(Hsv color1, Hsv color2)
    {
        return FromHsv(color1._hsvColor.h + color2._hsvColor.h,
                       color1._hsvColor.s + color2._hsvColor.s,
                       color1._hsvColor.v + color2._hsvColor.v);
    }

    /// <summary>
    /// Addition method - Adds each channel of the second color to each channel of the
    /// first and returns the result.
    /// </summary>
    public static Hsv Add(Hsv color1, Hsv color2)
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
    public static Hsv operator -(Hsv color1, Hsv color2)
    {
        return FromHsv(color1._hsvColor.h - color2._hsvColor.h,
                       color1._hsvColor.s - color2._hsvColor.s,
                       color1._hsvColor.v - color2._hsvColor.v);
    }

    /// <summary>
    /// Subtract operator - substracts each channel of the second color from each channel of the
    /// first and returns the result.
    /// </summary>
    /// <param name='color1'>The minuend.</param>
    /// <param name='color2'>The subtrahend.</param>
    /// <returns>Returns the unclamped differnce.</returns>
    public static Hsv Subtract(Hsv color1, Hsv color2)
    {
        return color1 - color2;
    }

    /// <summary>
    /// Multiplication operator - Multiplies each channel of the color by a coefficient and returns the result.
    /// </summary>
    /// <param name='color'>The color.</param>
    /// <param name='coefficient'>The coefficient.</param>
    /// <returns>Returns the unclamped product.</returns>
    public static Hsv operator *(Hsv color, decimal coefficient)
    {
        return FromHsv(color._hsvColor.h * coefficient,
                       color._hsvColor.s * coefficient,
                       color._hsvColor.v * coefficient);
    }

    /// <summary>
    /// Multiplication operator - Multiplies each channel of the color by a coefficient and returns the result.
    /// </summary>
    /// <param name='color'>The color.</param>
    /// <param name='coefficient'>The coefficient.</param>
    /// <returns>Returns the unclamped product.</returns>
    public static Hsv Multiply(Hsv color, decimal coefficient)
    {
        return color * coefficient;
    }

    /// <summary>
    /// IsEqual operator - Compares two colors for exact equality. Note that decimal values can acquire error
    /// when operated upon, such that an exact comparison between two values which are logically
    /// equal may fail. See <see cref="AreClose"/>.
    /// </summary>
    public static bool operator ==(Hsv color1, Hsv color2)
    {
        return color1._hsvColor.h == color2._hsvColor.h
               && color1._hsvColor.s == color2._hsvColor.s
               && color1._hsvColor.v == color2._hsvColor.v;
    }

    /// <summary>
    /// IsEqual operator - Compares two colors for exact equality. Note that decimal values can acquire error
    /// when operated upon, such that an exact comparison between two values which are logically
    /// equal may fail. See <see cref="AreClose"/>.
    /// </summary>
    public static bool Equals(Hsv color1, Hsv color2)
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
    public readonly bool Equals(Hsv color)
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
        return o is Hsv color && this == color;
    }

    /// <summary>
    /// IsNotEqual operator - Compares two colors for exact inequality. Note that decimal values can acquire error
    /// when operated upon, such that an exact comparison between two values which are logically
    /// equal may fail. See <see cref="AreClose"/>.
    /// </summary>
    public static bool operator !=(Hsv color1, Hsv color2)
    {
        return !(color1 == color2);
    }

    #endregion
}