using ColorSpace.Net.Colors;
using ColorSpace.Net.Convert.Extensions;

namespace ColorSpace.Net.Convert;

/// <summary>
/// Converter class to convert various color models to the CIE L*a*b* (Lab) color model.
/// </summary>
internal class LabConverter : ColorConverter<Lab>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="LabConverter"/> class with specified options.
    /// </summary>
    /// <param name="options">Options for the color converter.</param>
    public LabConverter(ColorConverterOptions options) : base(options)
    {
    }

    /// <summary>
    /// Converts a CMY color to Lab.
    /// </summary>
    /// <param name="value">The CMY color to convert.</param>
    /// <returns>The converted Lab color.</returns>
    public override Lab ConvertFrom(Cmy value)
    {
        var rgb = value.ToRgb();
        return ConvertFrom(rgb);
    }

    /// <summary>
    /// Converts a CMYK color to Lab.
    /// </summary>
    /// <param name="value">The CMYK color to convert.</param>
    /// <returns>The converted Lab color.</returns>
    public override Lab ConvertFrom(Cmyk value)
    {
        var rgb = value.ToRgb();
        return ConvertFrom(rgb);
    }

    /// <summary>
    /// Converts an HSL color to Lab.
    /// </summary>
    /// <param name="value">The HSL color to convert.</param>
    /// <returns>The converted Lab color.</returns>
    public override Lab ConvertFrom(Hsl value)
    {
        var rgb = value.ToRgb();
        return ConvertFrom(rgb);
    }

    /// <summary>
    /// Converts an HSV color to Lab.
    /// </summary>
    /// <param name="value">The HSV color to convert.</param>
    /// <returns>The converted Lab color.</returns>
    public override Lab ConvertFrom(Hsv value)
    {
        var rgb = value.ToRgb();
        return ConvertFrom(rgb);
    }

    /// <summary>
    /// Converts a Hunter Lab color to Lab.
    /// </summary>
    /// <param name="value">The Hunter Lab color to convert.</param>
    /// <returns>The converted Lab color.</returns>
    public override Lab ConvertFrom(HunterLab value)
    {
        var xyz = value.ToXyz();
        return ConvertFrom(xyz);
    }

    /// <summary>
    /// Converts a Lab color to Lab (returns the same color).
    /// </summary>
    /// <param name="value">The Lab color to convert.</param>
    /// <returns>The same Lab color.</returns>
    public override Lab ConvertFrom(Lab value)
    {
        return value;
    }

    /// <summary>
    /// Converts a Lch color to Lab.
    /// </summary>
    /// <param name="value">The Lch color to convert.</param>
    /// <returns>The converted Lab color.</returns>
    public override Lab ConvertFrom(Lch value)
    {
        var lab = value.ToLab();
        return ConvertFrom(lab);
    }

    /// <summary>
    /// Converts a Luv color to Lab.
    /// </summary>
    /// <param name="value">The Luv color to convert.</param>
    /// <returns>The converted Lab color.</returns>
    public override Lab ConvertFrom(Luv value)
    {
        var xyz = value.ToXyz(Options.Illuminant);
        return ConvertFrom(xyz);
    }

    /// <summary>
    /// Converts an RGB color to Lab.
    /// </summary>
    /// <param name="value">The RGB color to convert.</param>
    /// <returns>The converted Lab color.</returns>
    public override Lab ConvertFrom(Rgb value)
    {
        var xyz = value.ToXyz();
        return ConvertFrom(xyz);
    }

    /// <summary>
    /// Converts an XYZ color to Lab.
    /// </summary>
    /// <param name="value">The XYZ color to convert.</param>
    /// <returns>The converted Lab color.</returns>
    public override Lab ConvertFrom(Xyz value)
    {
        return value.ToLab(Options.Illuminant);
    }

    /// <summary>
    /// Converts a Yxy color to Lab.
    /// </summary>
    /// <param name="value">The Yxy color to convert.</param>
    /// <returns>The converted Lab color.</returns>
    public override Lab ConvertFrom(Yxy value)
    {
        var xyz = value.ToXyz();
        return ConvertFrom(xyz);
    }
}
