using System.Text;
using ColorSpace.Net.Helpers;

namespace ColorSpace.Net.Colors;

/// <summary>
/// Represents a color in the XYZ (CIE 1931) color space.
/// </summary>
public struct Xyz : IColor, IEquatable<Xyz>
{
    #region Fields/Consts

    private struct MILColorM
    {
        public decimal x, y, z;
    };

    private const string _xyzFormat = "G";

    private MILColorM _xyzColor;

    #endregion

    #region Properties

    /// <summary>
    /// Gets or sets the X component of the XYZ color as a decimal-point value in the range [0, 100].
    /// </summary>
    public decimal X
    {
        readonly get => _xyzColor.x;
        set => _xyzColor.x = ClampToXyzRange(value);
    }

    /// <summary>
    /// Gets or sets the Y component of the XYZ color as a decimal-point value in the range [0, 100].
    /// </summary>
    public decimal Y
    {
        readonly get => _xyzColor.y;
        set => _xyzColor.y = ClampToXyzRange(value);
    }

    /// <summary>
    /// Gets or sets the Z component of the XYZ color as a decimal-point value in the range [0, 100].
    /// </summary>
    public decimal Z
    {
        readonly get => _xyzColor.z;
        set => _xyzColor.z = ClampToXyzRange(value);
    }

    #endregion

    #region Constructors

    /// <summary>
    /// Creates a new instance of the XYZ color structure from decimal-point XYZ components.
    /// </summary>
    /// <param name="x">The X component of the XYZ color as a decimal-point value in the range [0, 100].</param>
    /// <param name="y">The Y component of the XYZ color as a decimal-point value in the range [0, 100].</param>
    /// <param name="z">The Z component of the XYZ color as a decimal-point value in the range [0, 100].</param>
    /// <returns>A new instance of the XYZ color structure.</returns>
    public static Xyz FromXyz(decimal x, decimal y, decimal z)
    {
        var xyz = new Xyz();

        xyz._xyzColor.x = ClampToXyzRange(x);
        xyz._xyzColor.y = ClampToXyzRange(y);
        xyz._xyzColor.z = ClampToXyzRange(z);

        return xyz;
    }

    #endregion

    #region Methods

    /// <inheritdoc/>
    public override readonly int GetHashCode()
    {
        return _xyzColor.GetHashCode();
    }

    /// <summary>
    /// Creates a string representation of this object based on the current culture.
    /// </summary>
    /// <returns>
    /// A string representation of this object.
    /// </returns>
    public override readonly string ToString()
    {
        return ConvertToString(_xyzFormat, null);
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
        return ConvertToString(_xyzFormat, provider);
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
                            _xyzColor.x,
                            _xyzColor.y,
                            _xyzColor.z);
        }
        else
        {
            sb.AppendFormat(provider,
                            "{1:" + format + "}{0} {2:" + format + "}{0} {3:" + format + "}{0}",
                            separator,
                            _xyzColor.x,
                            _xyzColor.y,
                            _xyzColor.z);
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
    public static bool AreClose(Xyz color1, Xyz color2)
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
    private readonly bool IsClose(Xyz color)
    {
        var result = true;

        result = result && DecimalHelpers.AreClose(_xyzColor.x, color._xyzColor.x);
        result = result && DecimalHelpers.AreClose(_xyzColor.y, color._xyzColor.y);
        return result && DecimalHelpers.AreClose(_xyzColor.z, color._xyzColor.z);
    }

    private static decimal ClampToXyzRange(decimal val)
    {
        return val < 0 ? 0 : val > 100 ? 100 : val;
    }

    #endregion

    #region Operators

    /// <summary>
    /// Addition operator - Adds each channel of the second color to each channel of the
    /// first and returns the result.
    /// </summary>
    public static Xyz operator +(Xyz color1, Xyz color2)
    {
        return FromXyz(color1._xyzColor.x + color2._xyzColor.x,
                       color1._xyzColor.y + color2._xyzColor.y,
                       color1._xyzColor.z + color2._xyzColor.z);
    }

    /// <summary>
    /// Addition method - Adds each channel of the second color to each channel of the
    /// first and returns the result.
    /// </summary>
    public static Xyz Add(Xyz color1, Xyz color2)
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
    public static Xyz operator -(Xyz color1, Xyz color2)
    {
        return FromXyz(color1._xyzColor.x - color2._xyzColor.x,
                       color1._xyzColor.y - color2._xyzColor.y,
                       color1._xyzColor.z - color2._xyzColor.z);
    }

    /// <summary>
    /// Subtract operator - substracts each channel of the second color from each channel of the
    /// first and returns the result.
    /// </summary>
    /// <param name='color1'>The minuend.</param>
    /// <param name='color2'>The subtrahend.</param>
    /// <returns>Returns the unclamped differnce.</returns>
    public static Xyz Subtract(Xyz color1, Xyz color2)
    {
        return color1 - color2;
    }

    /// <summary>
    /// Multiplication operator - Multiplies each channel of the color by a coefficient and returns the result.
    /// </summary>
    /// <param name='color'>The color.</param>
    /// <param name='coefficient'>The coefficient.</param>
    /// <returns>Returns the unclamped product.</returns>
    public static Xyz operator *(Xyz color, decimal coefficient)
    {
        return FromXyz(color._xyzColor.x * coefficient,
                       color._xyzColor.y * coefficient,
                       color._xyzColor.z * coefficient);
    }

    /// <summary>
    /// Multiplication operator - Multiplies each channel of the color by a coefficient and returns the result.
    /// </summary>
    /// <param name='color'>The color.</param>
    /// <param name='coefficient'>The coefficient.</param>
    /// <returns>Returns the unclamped product.</returns>
    public static Xyz Multiply(Xyz color, decimal coefficient)
    {
        return color * coefficient;
    }

    /// <summary>
    /// IsEqual operator - Compares two colors for exact equality. Note that decimal values can acquire error
    /// when operated upon, such that an exact comparison between two values which are logically
    /// equal may fail. See <see cref="AreClose"/>.
    /// </summary>
    public static bool operator ==(Xyz color1, Xyz color2)
    {
        return color1._xyzColor.x == color2._xyzColor.x
               && color1._xyzColor.y == color2._xyzColor.y
               && color1._xyzColor.z == color2._xyzColor.z;
    }

    /// <summary>
    /// IsEqual operator - Compares two colors for exact equality. Note that decimal values can acquire error
    /// when operated upon, such that an exact comparison between two values which are logically
    /// equal may fail. See <see cref="AreClose"/>.
    /// </summary>
    public static bool Equals(Xyz color1, Xyz color2)
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
    public readonly bool Equals(Xyz color)
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
        return o is Xyz color && this == color;
    }

    /// <summary>
    /// IsNotEqual operator - Compares two colors for exact inequality. Note that decimal values can acquire error
    /// when operated upon, such that an exact comparison between two values which are logically
    /// equal may fail. See <see cref="AreClose"/>.
    /// </summary>
    public static bool operator !=(Xyz color1, Xyz color2)
    {
        return !(color1 == color2);
    }

    #endregion
}