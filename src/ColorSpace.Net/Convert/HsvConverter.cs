using ColorSpace.Net.Colors;
using ColorSpace.Net.Convert.Extensions;

namespace ColorSpace.Net.Convert;

/// <summary>
/// Converter class to convert various color models to the HSV (Hue, Saturation, Value) color model.
/// </summary>
internal class HsvConverter : ColorConverter<Hsv>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="HsvConverter"/> class with specified options.
    /// </summary>
    /// <param name="options">Options for the color converter.</param>
    public HsvConverter(ColorConverterOptions options) : base(options)
    {
    }

    /// <summary>
    /// Converts a CMY color to HSV.
    /// </summary>
    /// <param name="value">The CMY color to convert.</param>
    /// <returns>The converted HSV color.</returns>
    public override Hsv ConvertFrom(Cmy value)
    {
        var rgb = value.ToRgb();
        return ConvertFrom(rgb);
    }

    /// <summary>
    /// Converts a CMYK color to HSV.
    /// </summary>
    /// <param name="value">The CMYK color to convert.</param>
    /// <returns>The converted HSV color.</returns>
    public override Hsv ConvertFrom(Cmyk value)
    {
        var rgb = value.ToRgb();
        return ConvertFrom(rgb);
    }

    /// <summary>
    /// Converts an HSL color to HSV.
    /// </summary>
    /// <param name="value">The HSL color to convert.</param>
    /// <returns>The converted HSV color.</returns>
    public override Hsv ConvertFrom(Hsl value)
    {
        var rgb = value.ToRgb();
        return ConvertFrom(rgb);
    }

    /// <summary>
    /// Converts an HSV color to HSV (returns the same color).
    /// </summary>
    /// <param name="value">The HSV color to convert.</param>
    /// <returns>The same HSV color.</returns>
    public override Hsv ConvertFrom(Hsv value)
    {
        return value;
    }

    /// <summary>
    /// Converts a HunterLab color to HSV.
    /// </summary>
    /// <param name="value">The HunterLab color to convert.</param>
    /// <returns>The converted HSV color.</returns>
    public override Hsv ConvertFrom(HunterLab value)
    {
        var xyz = value.ToXyz();
        return ConvertFrom(xyz);
    }

    /// <summary>
    /// Converts a Lab color to HSV.
    /// </summary>
    /// <param name="value">The Lab color to convert.</param>
    /// <returns>The converted HSV color.</returns>
    public override Hsv ConvertFrom(Lab value)
    {
        var xyz = value.ToXyz(Options.Illuminant);
        return ConvertFrom(xyz);
    }

    /// <summary>
    /// Converts a Lch color to HSV.
    /// </summary>
    /// <param name="value">The Lch color to convert.</param>
    /// <returns>The converted HSV color.</returns>
    public override Hsv ConvertFrom(Lch value)
    {
        var lab = value.ToLab();
        var xyz = lab.ToXyz(Options.Illuminant);
        return ConvertFrom(xyz);
    }

    /// <summary>
    /// Converts a Luv color to HSV.
    /// </summary>
    /// <param name="value">The Luv color to convert.</param>
    /// <returns>The converted HSV color.</returns>
    public override Hsv ConvertFrom(Luv value)
    {
        var xyz = value.ToXyz(Options.Illuminant);
        return ConvertFrom(xyz);
    }

    /// <summary>
    /// Converts an RGB color to HSV.
    /// </summary>
    /// <param name="value">The RGB color to convert.</param>
    /// <returns>The converted HSV color.</returns>
    public override Hsv ConvertFrom(Rgb value)
    {
        return value.ToHsv();
    }

    /// <summary>
    /// Converts an XYZ color to HSV.
    /// </summary>
    /// <param name="value">The XYZ color to convert.</param>
    /// <returns>The converted HSV color.</returns>
    public override Hsv ConvertFrom(Xyz value)
    {
        var rgb = value.ToRgb();
        return ConvertFrom(rgb);
    }

    /// <summary>
    /// Converts a Yxy color to HSV.
    /// </summary>
    /// <param name="value">The Yxy color to convert.</param>
    /// <returns>The converted HSV color.</returns>
    public override Hsv ConvertFrom(Yxy value)
    {
        var xyz = value.ToXyz();
        return ConvertFrom(xyz);
    }
}
