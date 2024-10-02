using ColorSpace.Net.Colors;
using ColorSpace.Net.Convert.Extensions;

namespace ColorSpace.Net.Convert;

/// <summary>
/// Converter class to convert various color models to the CIE L*C*h* (Lch) color model.
/// </summary>
internal class LchConverter : ColorConverter<Lch>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="LchConverter"/> class with specified options.
    /// </summary>
    /// <param name="options">Options for the color converter.</param>
    public LchConverter(ColorConverterOptions options) : base(options)
    {
    }

    /// <summary>
    /// Converts a CMY color to Lch.
    /// </summary>
    /// <param name="value">The CMY color to convert.</param>
    /// <returns>The converted Lch color.</returns>
    public override Lch ConvertFrom(Cmy value)
    {
        var rgb = value.ToRgb();
        return ConvertFrom(rgb);
    }

    /// <summary>
    /// Converts a CMYK color to Lch.
    /// </summary>
    /// <param name="value">The CMYK color to convert.</param>
    /// <returns>The converted Lch color.</returns>
    public override Lch ConvertFrom(Cmyk value)
    {
        var rgb = value.ToRgb();
        return ConvertFrom(rgb);
    }

    /// <summary>
    /// Converts an HSL color to Lch.
    /// </summary>
    /// <param name="value">The HSL color to convert.</param>
    /// <returns>The converted Lch color.</returns>
    public override Lch ConvertFrom(Hsl value)
    {
        var rgb = value.ToRgb();
        return ConvertFrom(rgb);
    }

    /// <summary>
    /// Converts an HSV color to Lch.
    /// </summary>
    /// <param name="value">The HSV color to convert.</param>
    /// <returns>The converted Lch color.</returns>
    public override Lch ConvertFrom(Hsv value)
    {
        var rgb = value.ToRgb();
        return ConvertFrom(rgb);
    }

    /// <summary>
    /// Converts a Hunter Lab color to Lch.
    /// </summary>
    /// <param name="value">The Hunter Lab color to convert.</param>
    /// <returns>The converted Lch color.</returns>
    public override Lch ConvertFrom(HunterLab value)
    {
        var xyz = value.ToXyz();
        return ConvertFrom(xyz);
    }

    /// <summary>
    /// Converts a Lab color to Lch.
    /// </summary>
    /// <param name="value">The Lab color to convert.</param>
    /// <returns>The converted Lch color.</returns>
    public override Lch ConvertFrom(Lab value)
    {
        return value.ToLch();
    }

    /// <summary>
    /// Converts an Lch color to Lch (returns the same color).
    /// </summary>
    /// <param name="value">The Lch color to convert.</param>
    /// <returns>The same Lch color.</returns>
    public override Lch ConvertFrom(Lch value)
    {
        return value;
    }

    /// <summary>
    /// Converts a Luv color to Lch.
    /// </summary>
    /// <param name="value">The Luv color to convert.</param>
    /// <returns>The converted Lch color.</returns>
    public override Lch ConvertFrom(Luv value)
    {
        var xyz = value.ToXyz(Options.Illuminant);
        return ConvertFrom(xyz);
    }

    /// <summary>
    /// Converts an RGB color to Lch.
    /// </summary>
    /// <param name="value">The RGB color to convert.</param>
    /// <returns>The converted Lch color.</returns>
    public override Lch ConvertFrom(Rgb value)
    {
        var xyz = value.ToXyz();
        return ConvertFrom(xyz);
    }

    /// <summary>
    /// Converts an XYZ color to Lch.
    /// </summary>
    /// <param name="value">The XYZ color to convert.</param>
    /// <returns>The converted Lch color.</returns>
    public override Lch ConvertFrom(Xyz value)
    {
        return value.ToLch(Options.Illuminant);
    }

    /// <summary>
    /// Converts a Yxy color to Lch.
    /// </summary>
    /// <param name="value">The Yxy color to convert.</param>
    /// <returns>The converted Lch color.</returns>
    public override Lch ConvertFrom(Yxy value)
    {
        var xyz = value.ToXyz();
        return ConvertFrom(xyz);
    }
}
