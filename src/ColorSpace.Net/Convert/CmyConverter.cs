using ColorSpace.Net.Colors;
using ColorSpace.Net.Convert.Extensions;

namespace ColorSpace.Net.Convert;

/// <summary>
/// Provides methods to convert various color models to CMY color model.
/// </summary>
internal class CmyConverter : ColorConverter<Cmy>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CmyConverter"/> class with specified options.
    /// </summary>
    /// <param name="options">Options for the color converter.</param>
    public CmyConverter(ColorConverterOptions options) : base(options)
    {
    }

    /// <summary>
    /// Converts a CMY color to a CMY color (identity conversion).
    /// </summary>
    /// <param name="value">The CMY color to convert.</param>
    /// <returns>The same CMY color.</returns>
    public override Cmy ConvertFrom(Cmy value)
    {
        return value;
    }

    /// <summary>
    /// Converts a CMYK color to a CMY color.
    /// </summary>
    /// <param name="value">The CMYK color to convert.</param>
    /// <returns>The converted CMY color.</returns>
    public override Cmy ConvertFrom(Cmyk value)
    {
        return value.ToCmy();
    }

    /// <summary>
    /// Converts an HSL color to a CMY color.
    /// </summary>
    /// <param name="value">The HSL color to convert.</param>
    /// <returns>The converted CMY color.</returns>
    public override Cmy ConvertFrom(Hsl value)
    {
        var rgb = value.ToRgb();
        return ConvertFrom(rgb);
    }

    /// <summary>
    /// Converts an HSV color to a CMY color.
    /// </summary>
    /// <param name="value">The HSV color to convert.</param>
    /// <returns>The converted CMY color.</returns>
    public override Cmy ConvertFrom(Hsv value)
    {
        var rgb = value.ToRgb();
        return ConvertFrom(rgb);
    }

    /// <summary>
    /// Converts a HunterLab color to a CMY color.
    /// </summary>
    /// <param name="value">The HunterLab color to convert.</param>
    /// <returns>The converted CMY color.</returns>
    public override Cmy ConvertFrom(HunterLab value)
    {
        var xyz = value.ToXyz();
        return ConvertFrom(xyz);
    }

    /// <summary>
    /// Converts a Lab color to a CMY color.
    /// </summary>
    /// <param name="value">The Lab color to convert.</param>
    /// <returns>The converted CMY color.</returns>
    public override Cmy ConvertFrom(Lab value)
    {
        var xyz = value.ToXyz(Options.Illuminant);
        return ConvertFrom(xyz);
    }

    /// <summary>
    /// Converts an Lch color to a CMY color.
    /// </summary>
    /// <param name="value">The Lch color to convert.</param>
    /// <returns>The converted CMY color.</returns>
    public override Cmy ConvertFrom(Lch value)
    {
        var lab = value.ToLab();
        var xyz = lab.ToXyz(Options.Illuminant);
        return ConvertFrom(xyz);
    }

    /// <summary>
    /// Converts a Luv color to a CMY color.
    /// </summary>
    /// <param name="value">The Luv color to convert.</param>
    /// <returns>The converted CMY color.</returns>
    public override Cmy ConvertFrom(Luv value)
    {
        var xyz = value.ToXyz(Options.Illuminant);
        return ConvertFrom(xyz);
    }

    /// <summary>
    /// Converts an RGB color to a CMY color.
    /// </summary>
    /// <param name="value">The RGB color to convert.</param>
    /// <returns>The converted CMY color.</returns>
    public override Cmy ConvertFrom(Rgb value)
    {
        return value.ToCmy();
    }

    /// <summary>
    /// Converts an XYZ color to a CMY color.
    /// </summary>
    /// <param name="value">The XYZ color to convert.</param>
    /// <returns>The converted CMY color.</returns>
    public override Cmy ConvertFrom(Xyz value)
    {
        var rgb = value.ToRgb();
        return ConvertFrom(rgb);
    }

    /// <summary>
    /// Converts a Yxy color to a CMY color.
    /// </summary>
    /// <param name="value">The Yxy color to convert.</param>
    /// <returns>The converted CMY color.</returns>
    public override Cmy ConvertFrom(Yxy value)
    {
        var xyz = value.ToXyz();
        return ConvertFrom(xyz);
    }
}
