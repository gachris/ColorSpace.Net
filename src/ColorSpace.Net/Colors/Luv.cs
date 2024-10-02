using System.Text;
using ColorSpace.Net.Helpers;

namespace ColorSpace.Net.Colors;

/// <summary>
/// Represents a color in the CIELUV (CIE 1976 Luv*) color space.
/// </summary>
public struct Luv : IColor, IEquatable<Luv>
{
    #region Fields/Consts

    private struct MILColorM
    {
        public decimal l, u, v;
    };

    private const string _luvFormat = "G";

    private MILColorM _luvColor;

    #endregion

    #region Properties

    /// <summary>
    /// Gets or sets the L component of the Luv color as a decimal-point value in the range [0, 100].
    /// </summary>
    public decimal L
    {
        readonly get => _luvColor.l;
        set => _luvColor.l = ClampLToHunterLuvRange(value);
    }

    /// <summary>
    /// Gets or sets the U component of the Luv color as a decimal-point value in the range [-134, 224].
    /// </summary>
    public decimal U
    {
        readonly get => _luvColor.u;
        set => _luvColor.u = ClampUToHunterLuvRange(value);
    }

    /// <summary>
    /// Gets or sets the V component of the Luv color as a decimal-point value in the range [-140, 122].
    /// </summary>
    public decimal V
    {
        readonly get => _luvColor.v;
        set => _luvColor.v = ClampVToHunterLuvRange(value);
    }

    #endregion

    #region Constructors

    /// <summary>
    /// Creates a new instance of the Luv color structure from decimal-point Luv components.
    /// </summary>
    /// <param name="l">The L component of the Luv color as a decimal-point value in the range [0, 100].</param>
    /// <param name="u">The U component of the Luv color as a decimal-point value in the range [-134, 224].</param>
    /// <param name="v">The V component of the Luv color as a decimal-point value in the range [-140, 122].</param>
    /// <returns>A new instance of the Luv color structure.</returns>
    public static Luv FromLuv(decimal l, decimal u, decimal v)
    {
        var luv = new Luv();

        luv._luvColor.l = ClampLToHunterLuvRange(l);
        luv._luvColor.u = ClampUToHunterLuvRange(u);
        luv._luvColor.v = ClampVToHunterLuvRange(v);

        return luv;
    }

    #endregion

    #region Methods

    /// <inheritdoc/>
    public override readonly int GetHashCode()
    {
        return _luvColor.GetHashCode();
    }

    /// <summary>
    /// Creates a string representation of this object based on the current culture.
    /// </summary>
    /// <returns>
    /// A string representation of this object.
    /// </returns>
    public override readonly string ToString()
    {
        return ConvertToString(_luvFormat, null);
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
        return ConvertToString(_luvFormat, provider);
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
                            _luvColor.l,
                            _luvColor.u,
                            _luvColor.v);
        }
        else
        {
            sb.AppendFormat(provider,
                            "{1:" + format + "}{0} {2:" + format + "}{0} {3:" + format + "}{0}",
                            separator,
                            _luvColor.l,
                            _luvColor.u,
                            _luvColor.v);
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
    public static bool AreClose(Luv color1, Luv color2)
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
    private readonly bool IsClose(Luv color)
    {
        var result = true;

        result = result && DecimalHelpers.AreClose(_luvColor.l, color._luvColor.l);
        result = result && DecimalHelpers.AreClose(_luvColor.u, color._luvColor.u);
        return result && DecimalHelpers.AreClose(_luvColor.v, color._luvColor.v);
    }

    private static decimal ClampLToHunterLuvRange(decimal val)
    {
        return val < 0 ? 0 : val > 100 ? 100 : val;
    }

    private static decimal ClampUToHunterLuvRange(decimal val)
    {
        return val < -134 ? -134 : val > 224 ? 224 : val;
    }

    private static decimal ClampVToHunterLuvRange(decimal val)
    {
        return val < -140 ? -140 : val > 122 ? 122 : val;
    }

    #endregion

    #region Operators

    /// <summary>
    /// Addition operator - Adds each channel of the second color to each channel of the
    /// first and returns the result.
    /// </summary>
    public static Luv operator +(Luv color1, Luv color2)
    {
        return FromLuv(color1._luvColor.l + color2._luvColor.l,
                       color1._luvColor.u + color2._luvColor.u,
                       color1._luvColor.v + color2._luvColor.v);
    }

    /// <summary>
    /// Addition method - Adds each channel of the second color to each channel of the
    /// first and returns the result.
    /// </summary>
    public static Luv Add(Luv color1, Luv color2)
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
    public static Luv operator -(Luv color1, Luv color2)
    {
        return FromLuv(color1._luvColor.l - color2._luvColor.l,
                       color1._luvColor.u - color2._luvColor.u,
                       color1._luvColor.v - color2._luvColor.v);
    }

    /// <summary>
    /// Subtract operator - substracts each channel of the second color from each channel of the
    /// first and returns the result.
    /// </summary>
    /// <param name='color1'>The minuend.</param>
    /// <param name='color2'>The subtrahend.</param>
    /// <returns>Returns the unclamped differnce.</returns>
    public static Luv Subtract(Luv color1, Luv color2)
    {
        return color1 - color2;
    }

    /// <summary>
    /// Multiplication operator - Multiplies each channel of the color by a coefficient and returns the result.
    /// </summary>
    /// <param name='color'>The color.</param>
    /// <param name='coefficient'>The coefficient.</param>
    /// <returns>Returns the unclamped product.</returns>
    public static Luv operator *(Luv color, decimal coefficient)
    {
        return FromLuv(color._luvColor.l * coefficient,
                       color._luvColor.u * coefficient,
                       color._luvColor.v * coefficient);
    }

    /// <summary>
    /// Multiplication operator - Multiplies each channel of the color by a coefficient and returns the result.
    /// </summary>
    /// <param name='color'>The color.</param>
    /// <param name='coefficient'>The coefficient.</param>
    /// <returns>Returns the unclamped product.</returns>
    public static Luv Multiply(Luv color, decimal coefficient)
    {
        return color * coefficient;
    }

    /// <summary>
    /// IsEqual operator - Compares two colors for exact equality. Note that decimal values can acquire error
    /// when operated upon, such that an exact comparison between two values which are logically
    /// equal may fail. See <see cref="AreClose"/>.
    /// </summary>
    public static bool operator ==(Luv color1, Luv color2)
    {
        return color1._luvColor.l == color2._luvColor.l
               && color1._luvColor.u == color2._luvColor.u
               && color1._luvColor.v == color2._luvColor.v;
    }

    /// <summary>
    /// IsEqual operator - Compares two colors for exact equality. Note that decimal values can acquire error
    /// when operated upon, such that an exact comparison between two values which are logically
    /// equal may fail. See <see cref="AreClose"/>.
    /// </summary>
    public static bool Equals(Luv color1, Luv color2)
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
    public readonly bool Equals(Luv color)
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
        return o is Luv color && this == color;
    }

    /// <summary>
    /// IsNotEqual operator - Compares two colors for exact inequality. Note that decimal values can acquire error
    /// when operated upon, such that an exact comparison between two values which are logically
    /// equal may fail. See <see cref="AreClose"/>.
    /// </summary>
    public static bool operator !=(Luv color1, Luv color2)
    {
        return !(color1 == color2);
    }

    #endregion
}