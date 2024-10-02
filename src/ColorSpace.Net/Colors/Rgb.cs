using System.Text;
using ColorSpace.Net.Helpers;

namespace ColorSpace.Net.Colors;

/// <summary>
/// Represents a color in the RGB (Red, Green, Blue) color space.
/// </summary>
public struct Rgb : IColor, IEquatable<Rgb>
{
    #region Fields/Consts

    private struct MILColorF
    {
        public float r, g, b;
    };

    private struct MILColor
    {
        public byte r, g, b;
    }

    private const string _scRgbFormat = "G";

    private MILColorF _scRgbColor;
    private MILColor _rgbColor;
    private bool _isFromScRgb;

    #endregion

    #region Properties

    /// <summary>
    /// Gets or sets the red component of the RGB color.
    /// </summary>
    public byte R
    {
        readonly get => _rgbColor.r;
        set
        {
            _scRgbColor.r = RgbToScRgb(value);
            _rgbColor.r = value;
        }
    }

    /// <summary>
    /// Gets or sets the green component of the RGB color.
    /// </summary>
    public byte G
    {
        readonly get => _rgbColor.g;
        set
        {
            _scRgbColor.g = RgbToScRgb(value);
            _rgbColor.g = value;
        }
    }

    /// <summary>
    /// Gets or sets the blue component of the RGB color.
    /// </summary>
    public byte B
    {
        readonly get => _rgbColor.b;
        set
        {
            _scRgbColor.b = RgbToScRgb(value);
            _rgbColor.b = value;
        }
    }

    /// <summary>
    /// Gets or sets the red component of the RGB color as a floating-point value in the range [0, 1].
    /// </summary>
    public float ScR
    {
        readonly get => _scRgbColor.r;
        set
        {
            _scRgbColor.r = value;
            _rgbColor.r = ScRgbTosRgb(value);
        }
    }

    /// <summary>
    /// Gets or sets the green component of the RGB color as a floating-point value in the range [0, 1].
    /// </summary>
    public float ScG
    {
        readonly get => _scRgbColor.g;
        set
        {
            _scRgbColor.g = value;
            _rgbColor.g = ScRgbTosRgb(value);
        }
    }

    /// <summary>
    /// Gets or sets the blue component of the RGB color as a floating-point value in the range [0, 1].
    /// </summary>
    public float ScB
    {
        readonly get => _scRgbColor.b;
        set
        {
            _scRgbColor.b = value;
            _rgbColor.b = ScRgbTosRgb(value);
        }
    }

    #endregion

    #region Constructors

    /// <summary>
    /// Creates a new instance of the RGB color structure.
    /// </summary>
    /// <param name="r">The red component of the RGB color.</param>
    /// <param name="g">The green component of the RGB color.</param>
    /// <param name="b">The blue component of the RGB color.</param>
    /// <returns>A new instance of the RGB color structure.</returns>
    public static Rgb FromScRgb(float r, float g, float b)
    {
        var rgb = new Rgb();

        rgb._scRgbColor.r = r;
        rgb._scRgbColor.g = g;
        rgb._scRgbColor.b = b;
        rgb._rgbColor.r = ScRgbTosRgb(rgb._scRgbColor.r);
        rgb._rgbColor.g = ScRgbTosRgb(rgb._scRgbColor.g);
        rgb._rgbColor.b = ScRgbTosRgb(rgb._scRgbColor.b);

        rgb._isFromScRgb = true;

        return rgb;
    }

    /// <summary>
    /// Creates a new instance of the RGB color structure.
    /// </summary>
    /// <param name="r">The red component of the RGB color.</param>
    /// <param name="g">The green component of the RGB color.</param>
    /// <param name="b">The blue component of the RGB color.</param>
    /// <returns>A new instance of the RGB color structure.</returns>
    public static Rgb FromRgb(byte r, byte g, byte b)
    {
        var rgb = new Rgb();

        rgb._scRgbColor.r = RgbToScRgb(r);
        rgb._scRgbColor.g = RgbToScRgb(g);
        rgb._scRgbColor.b = RgbToScRgb(b);
        rgb._rgbColor.r = ScRgbTosRgb(rgb._scRgbColor.r);
        rgb._rgbColor.g = ScRgbTosRgb(rgb._scRgbColor.g);
        rgb._rgbColor.b = ScRgbTosRgb(rgb._scRgbColor.b);

        rgb._isFromScRgb = false;

        return rgb;
    }

    #endregion

    #region Methods

    /// <inheritdoc/>
    public override readonly int GetHashCode()
    {
        return _scRgbColor.GetHashCode();
    }

    /// <summary>
    /// Creates a string representation of this object based on the current culture.
    /// </summary>
    /// <returns>
    /// A string representation of this object.
    /// </returns>
    public override readonly string ToString()
    {
        var format = _isFromScRgb ? _scRgbFormat : null;
        return ConvertToString(format, null);
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
        var format = _isFromScRgb ? _scRgbFormat : null;
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
                            _rgbColor.r,
                            _rgbColor.g,
                            _rgbColor.b);
        }
        else
        {
            sb.AppendFormat(provider,
                            "{1:" + format + "}{0} {2:" + format + "}{0} {3:" + format + "}{0}",
                            separator,
                            _scRgbColor.r,
                            _scRgbColor.g,
                            _scRgbColor.b);
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
    public static bool AreClose(Rgb color1, Rgb color2)
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
    private readonly bool IsClose(Rgb color)
    {
        var result = true;

        result = result && FloatHelpers.AreClose(_scRgbColor.r, color._scRgbColor.r);
        result = result && FloatHelpers.AreClose(_scRgbColor.g, color._scRgbColor.g);
        return result && FloatHelpers.AreClose(_scRgbColor.b, color._scRgbColor.b);
    }

    ///<summary>
    /// Clamp - the color channels to the gamut [0..1]. If a channel is out
    /// of gamut, it will be set to 1, which represents full saturation.
    ///</summary>
    public void Clamp()
    {
        _scRgbColor.r = _scRgbColor.r < 0 ? 0 : _scRgbColor.r > 1.0f ? 1.0f : _scRgbColor.r;
        _scRgbColor.g = _scRgbColor.g < 0 ? 0 : _scRgbColor.g > 1.0f ? 1.0f : _scRgbColor.g;
        _scRgbColor.b = _scRgbColor.b < 0 ? 0 : _scRgbColor.b > 1.0f ? 1.0f : _scRgbColor.b;
        _rgbColor.r = ScRgbTosRgb(_scRgbColor.r);
        _rgbColor.g = ScRgbTosRgb(_scRgbColor.g);
        _rgbColor.b = ScRgbTosRgb(_scRgbColor.b);
    }

    private static float RgbToScRgb(byte bval)
    {
        var val = bval / 255.0f;
        return !(val > 0.0) ? 0.0f : val <= 0.04045 ? val / 12.92f : val < 1.0f ? (float)Math.Pow(((double)val + 0.055) / 1.055, 2.4) : 1.0f;
    }

    private static byte ScRgbTosRgb(float val)
    {
        return !(val > 0.0) ? (byte)0 :
                val <= 0.0031308 ? (byte)(255.0f * val * 12.92f + 0.5f) :
                val < 1.0 ? (byte)(255.0f * (1.055f * (float)Math.Pow((double)val, 1.0 / 2.4) - 0.055f) + 0.5f) : (byte)255;
    }

    #endregion

    #region Operators

    /// <summary>
    /// Addition operator - Adds each channel of the second color to each channel of the
    /// first and returns the result.
    /// </summary>
    public static Rgb operator +(Rgb color1, Rgb color2)
    {
        return FromScRgb(color1._scRgbColor.r + color2._scRgbColor.r,
                         color1._scRgbColor.g + color2._scRgbColor.g,
                         color1._scRgbColor.b + color2._scRgbColor.b);
    }

    /// <summary>
    /// Addition method - Adds each channel of the second color to each channel of the
    /// first and returns the result.
    /// </summary>
    public static Rgb Add(Rgb color1, Rgb color2)
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
    public static Rgb operator -(Rgb color1, Rgb color2)
    {
        return FromScRgb(color1._scRgbColor.r - color2._scRgbColor.r,
                         color1._scRgbColor.g - color2._scRgbColor.g,
                         color1._scRgbColor.b - color2._scRgbColor.b);
    }

    /// <summary>
    /// Subtract operator - substracts each channel of the second color from each channel of the
    /// first and returns the result.
    /// </summary>
    /// <param name='color1'>The minuend.</param>
    /// <param name='color2'>The subtrahend.</param>
    /// <returns>Returns the unclamped differnce.</returns>
    public static Rgb Subtract(Rgb color1, Rgb color2)
    {
        return color1 - color2;
    }

    /// <summary>
    /// Multiplication operator - Multiplies each channel of the color by a coefficient and returns the result.
    /// </summary>
    /// <param name='color'>The color.</param>
    /// <param name='coefficient'>The coefficient.</param>
    /// <returns>Returns the unclamped product.</returns>
    public static Rgb operator *(Rgb color, float coefficient)
    {
        return FromScRgb(color._scRgbColor.r * coefficient,
                         color._scRgbColor.g * coefficient,
                         color._scRgbColor.b * coefficient);
    }

    /// <summary>
    /// Multiplication operator - Multiplies each channel of the color by a coefficient and returns the result.
    /// </summary>
    /// <param name='color'>The color.</param>
    /// <param name='coefficient'>The coefficient.</param>
    /// <returns>Returns the unclamped product.</returns>
    public static Rgb Multiply(Rgb color, float coefficient)
    {
        return color * coefficient;
    }

    /// <summary>
    /// IsEqual operator - Compares two colors for exact equality. Note that decimal values can acquire error
    /// when operated upon, such that an exact comparison between two values which are logically
    /// equal may fail. See <see cref="AreClose"/>.
    /// </summary>
    public static bool operator ==(Rgb color1, Rgb color2)
    {
        return color1._scRgbColor.r == color2._scRgbColor.r
               && color1._scRgbColor.g == color2._scRgbColor.g
               && color1._scRgbColor.b == color2._scRgbColor.b;
    }

    /// <summary>
    /// IsEqual operator - Compares two colors for exact equality. Note that decimal values can acquire error
    /// when operated upon, such that an exact comparison between two values which are logically
    /// equal may fail. See <see cref="AreClose"/>.
    /// </summary>
    public static bool Equals(Rgb color1, Rgb color2)
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
    public readonly bool Equals(Rgb color)
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
        return o is Rgb color && this == color;
    }

    /// <summary>
    /// IsNotEqual operator - Compares two colors for exact inequality. Note that decimal values can acquire error
    /// when operated upon, such that an exact comparison between two values which are logically
    /// equal may fail. See <see cref="AreClose"/>.
    /// </summary>
    public static bool operator !=(Rgb color1, Rgb color2)
    {
        return !(color1 == color2);
    }

    #endregion
}