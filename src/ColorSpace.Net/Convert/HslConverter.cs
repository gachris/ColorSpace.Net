using ColorSpace.Net.Colors;
using ColorSpace.Net.Convert.Extensions;

namespace ColorSpace.Net.Convert;

/// <summary>
/// Converter class to convert various color models to the HSL (Hue, Saturation, Lightness) color model.
/// </summary>
internal class HslConverter : ColorConverter<Hsl>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="HslConverter"/> class with specified options.
    /// </summary>
    /// <param name="options">Options for the color converter.</param>
    public HslConverter(ColorConverterOptions options) : base(options)
    {
    }

    /// <summary>
    /// Converts a CMY color to HSL.
    /// </summary>
    /// <param name="value">The CMY color to convert.</param>
    /// <returns>The converted HSL color.</returns>
    public override Hsl ConvertFrom(Cmy value)
    {
        var rgb = value.ToRgb();
        return ConvertFrom(rgb);
    }

    /// <summary>
    /// Converts a CMYK color to HSL.
    /// </summary>
    /// <param name="value">The CMYK color to convert.</param>
    /// <returns>The converted HSL color.</returns>
    public override Hsl ConvertFrom(Cmyk value)
    {
        var rgb = value.ToRgb();
        return ConvertFrom(rgb);
    }

    /// <summary>
    /// Converts an HSL color to HSL (returns the same color).
    /// </summary>
    /// <param name="value">The HSL color to convert.</param>
    /// <returns>The same HSL color.</returns>
    public override Hsl ConvertFrom(Hsl value)
    {
        return value;
    }

    /// <summary>
    /// Converts an HSV color to HSL.
    /// </summary>
    /// <param name="value">The HSV color to convert.</param>
    /// <returns>The converted HSL color.</returns>
    public override Hsl ConvertFrom(Hsv value)
    {
        var rgb = value.ToRgb();
        return ConvertFrom(rgb);
    }

    /// <summary>
    /// Converts a HunterLab color to HSL.
    /// </summary>
    /// <param name="value">The HunterLab color to convert.</param>
    /// <returns>The converted HSL color.</returns>
    public override Hsl ConvertFrom(HunterLab value)
    {
        var xyz = value.ToXyz();
        return ConvertFrom(xyz);
    }

    /// <summary>
    /// Converts a Lab color to HSL.
    /// </summary>
    /// <param name="value">The Lab color to convert.</param>
    /// <returns>The converted HSL color.</returns>
    public override Hsl ConvertFrom(Lab value)
    {
        var xyz = value.ToXyz(Options.Illuminant);
        return ConvertFrom(xyz);
    }

    /// <summary>
    /// Converts a Lch color to HSL.
    /// </summary>
    /// <param name="value">The Lch color to convert.</param>
    /// <returns>The converted HSL color.</returns>
    public override Hsl ConvertFrom(Lch value)
    {
        var lab = value.ToLab();
        var xyz = lab.ToXyz(Options.Illuminant);
        return ConvertFrom(xyz);
    }

    /// <summary>
    /// Converts a Luv color to HSL.
    /// </summary>
    /// <param name="value">The Luv color to convert.</param>
    /// <returns>The converted HSL color.</returns>
    public override Hsl ConvertFrom(Luv value)
    {
        var xyz = value.ToXyz(Options.Illuminant);
        return ConvertFrom(xyz);
    }

    /// <summary>
    /// Converts an RGB color to HSL.
    /// </summary>
    /// <param name="value">The RGB color to convert.</param>
    /// <returns>The converted HSL color.</returns>
    public override Hsl ConvertFrom(Rgb value)
    {
        return value.ToHsl();
    }

    /// <summary>
    /// Converts an XYZ color to HSL.
    /// </summary>
    /// <param name="value">The XYZ color to convert.</param>
    /// <returns>The converted HSL color.</returns>
    public override Hsl ConvertFrom(Xyz value)
    {
        var rgb = value.ToRgb();
        return ConvertFrom(rgb);
    }

    /// <summary>
    /// Converts a Yxy color to HSL.
    /// </summary>
    /// <param name="value">The Yxy color to convert.</param>
    /// <returns>The converted HSL color.</returns>
    public override Hsl ConvertFrom(Yxy value)
    {
        var xyz = value.ToXyz();
        return ConvertFrom(xyz);
    }
}
