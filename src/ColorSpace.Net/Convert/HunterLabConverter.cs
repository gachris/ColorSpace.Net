using ColorSpace.Net.Colors;
using ColorSpace.Net.Convert.Extensions;

namespace ColorSpace.Net.Convert;

/// <summary>
/// Converter class to convert various color models to the Hunter Lab color model.
/// </summary>
internal class HunterLabConverter : ColorConverter<HunterLab>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="HunterLabConverter"/> class with specified options.
    /// </summary>
    /// <param name="options">Options for the color converter.</param>
    public HunterLabConverter(ColorConverterOptions options) : base(options)
    {
    }

    /// <summary>
    /// Converts a CMY color to Hunter Lab.
    /// </summary>
    /// <param name="value">The CMY color to convert.</param>
    /// <returns>The converted Hunter Lab color.</returns>
    public override HunterLab ConvertFrom(Cmy value)
    {
        var rgb = value.ToRgb();
        return ConvertFrom(rgb);
    }

    /// <summary>
    /// Converts a CMYK color to Hunter Lab.
    /// </summary>
    /// <param name="value">The CMYK color to convert.</param>
    /// <returns>The converted Hunter Lab color.</returns>
    public override HunterLab ConvertFrom(Cmyk value)
    {
        var rgb = value.ToRgb();
        return ConvertFrom(rgb);
    }

    /// <summary>
    /// Converts an HSL color to Hunter Lab.
    /// </summary>
    /// <param name="value">The HSL color to convert.</param>
    /// <returns>The converted Hunter Lab color.</returns>
    public override HunterLab ConvertFrom(Hsl value)
    {
        var rgb = value.ToRgb();
        return ConvertFrom(rgb);
    }

    /// <summary>
    /// Converts an HSV color to Hunter Lab.
    /// </summary>
    /// <param name="value">The HSV color to convert.</param>
    /// <returns>The converted Hunter Lab color.</returns>
    public override HunterLab ConvertFrom(Hsv value)
    {
        var rgb = value.ToRgb();
        return ConvertFrom(rgb);
    }

    /// <summary>
    /// Converts a Hunter Lab color to Hunter Lab (returns the same color).
    /// </summary>
    /// <param name="value">The Hunter Lab color to convert.</param>
    /// <returns>The same Hunter Lab color.</returns>
    public override HunterLab ConvertFrom(HunterLab value)
    {
        return value;
    }

    /// <summary>
    /// Converts a Lab color to Hunter Lab.
    /// </summary>
    /// <param name="value">The Lab color to convert.</param>
    /// <returns>The converted Hunter Lab color.</returns>
    public override HunterLab ConvertFrom(Lab value)
    {
        var xyz = value.ToXyz(Options.Illuminant);
        return ConvertFrom(xyz);
    }

    /// <summary>
    /// Converts a Lch color to Hunter Lab.
    /// </summary>
    /// <param name="value">The Lch color to convert.</param>
    /// <returns>The converted Hunter Lab color.</returns>
    public override HunterLab ConvertFrom(Lch value)
    {
        var lab = value.ToLab();
        var xyz = lab.ToXyz(Options.Illuminant);
        return ConvertFrom(xyz);
    }

    /// <summary>
    /// Converts a Luv color to Hunter Lab.
    /// </summary>
    /// <param name="value">The Luv color to convert.</param>
    /// <returns>The converted Hunter Lab color.</returns>
    public override HunterLab ConvertFrom(Luv value)
    {
        var xyz = value.ToXyz(Options.Illuminant);
        return ConvertFrom(xyz);
    }

    /// <summary>
    /// Converts an RGB color to Hunter Lab.
    /// </summary>
    /// <param name="value">The RGB color to convert.</param>
    /// <returns>The converted Hunter Lab color.</returns>
    public override HunterLab ConvertFrom(Rgb value)
    {
        return value.ToHunterLab();
    }

    /// <summary>
    /// Converts an XYZ color to Hunter Lab.
    /// </summary>
    /// <param name="value">The XYZ color to convert.</param>
    /// <returns>The converted Hunter Lab color.</returns>
    public override HunterLab ConvertFrom(Xyz value)
    {
        var rgb = value.ToRgb();
        return ConvertFrom(rgb);
    }

    /// <summary>
    /// Converts a Yxy color to Hunter Lab.
    /// </summary>
    /// <param name="value">The Yxy color to convert.</param>
    /// <returns>The converted Hunter Lab color.</returns>
    public override HunterLab ConvertFrom(Yxy value)
    {
        var xyz = value.ToXyz();
        return ConvertFrom(xyz);
    }
}
