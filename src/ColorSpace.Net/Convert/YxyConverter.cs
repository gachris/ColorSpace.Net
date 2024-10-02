using ColorSpace.Net.Colors;
using ColorSpace.Net.Convert.Extensions;

namespace ColorSpace.Net.Convert;

/// <summary>
/// Converter class to convert various color models to the CIE 1931 xyY color model.
/// </summary>
internal class YxyConverter : ColorConverter<Yxy>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="YxyConverter"/> class with specified options.
    /// </summary>
    /// <param name="options">Options for the color converter.</param>
    public YxyConverter(ColorConverterOptions options) : base(options)
    {
    }

    /// <summary>
    /// Converts a CMY color to Yxy.
    /// </summary>
    /// <param name="value">The CMY color to convert.</param>
    /// <returns>The converted Yxy color.</returns>
    public override Yxy ConvertFrom(Cmy value)
    {
        var rgb = value.ToRgb();
        return ConvertFrom(rgb);
    }

    /// <summary>
    /// Converts a CMYK color to Yxy.
    /// </summary>
    /// <param name="value">The CMYK color to convert.</param>
    /// <returns>The converted Yxy color.</returns>
    public override Yxy ConvertFrom(Cmyk value)
    {
        var rgb = value.ToRgb();
        return ConvertFrom(rgb);
    }

    /// <summary>
    /// Converts an HSL color to Yxy.
    /// </summary>
    /// <param name="value">The HSL color to convert.</param>
    /// <returns>The converted Yxy color.</returns>
    public override Yxy ConvertFrom(Hsl value)
    {
        var rgb = value.ToRgb();
        return ConvertFrom(rgb);
    }

    /// <summary>
    /// Converts an HSV color to Yxy.
    /// </summary>
    /// <param name="value">The HSV color to convert.</param>
    /// <returns>The converted Yxy color.</returns>
    public override Yxy ConvertFrom(Hsv value)
    {
        var rgb = value.ToRgb();
        return ConvertFrom(rgb);
    }

    /// <summary>
    /// Converts a Hunter Lab color to Yxy.
    /// </summary>
    /// <param name="value">The Hunter Lab color to convert.</param>
    /// <returns>The converted Yxy color.</returns>
    public override Yxy ConvertFrom(HunterLab value)
    {
        var rgb = value.ToXyz().ToRgb();
        return ConvertFrom(rgb);
    }

    /// <summary>
    /// Converts a Lab color to Yxy.
    /// </summary>
    /// <param name="value">The Lab color to convert.</param>
    /// <returns>The converted Yxy color.</returns>
    public override Yxy ConvertFrom(Lab value)
    {
        var xyz = value.ToXyz(Options.Illuminant);
        return ConvertFrom(xyz);
    }

    /// <summary>
    /// Converts an Lch color to Yxy.
    /// </summary>
    /// <param name="value">The Lch color to convert.</param>
    /// <returns>The converted Yxy color.</returns>
    public override Yxy ConvertFrom(Lch value)
    {
        var lab = value.ToLab();
        return ConvertFrom(lab);
    }

    /// <summary>
    /// Converts an Luv color to Yxy.
    /// </summary>
    /// <param name="value">The Luv color to convert.</param>
    /// <returns>The converted Yxy color.</returns>
    public override Yxy ConvertFrom(Luv value)
    {
        var xyz = value.ToXyz(Options.Illuminant);
        return ConvertFrom(xyz);
    }

    /// <summary>
    /// Converts an RGB color to Yxy.
    /// </summary>
    /// <param name="value">The RGB color to convert.</param>
    /// <returns>The converted Yxy color.</returns>
    public override Yxy ConvertFrom(Rgb value)
    {
        var xyz = value.ToXyz();
        return ConvertFrom(xyz);
    }

    /// <summary>
    /// Returns the same Yxy color (no conversion).
    /// </summary>
    /// <param name="value">The Yxy color to return.</param>
    /// <returns>The same Yxy color.</returns>
    public override Yxy ConvertFrom(Yxy value)
    {
        return value;
    }

    /// <summary>
    /// Converts an XYZ color to Yxy.
    /// </summary>
    /// <param name="value">The XYZ color to convert.</param>
    /// <returns>The converted Yxy color.</returns>
    public override Yxy ConvertFrom(Xyz value)
    {
        return value.ToYxy();
    }
}
