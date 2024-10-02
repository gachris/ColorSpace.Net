using ColorSpace.Net.Colors;
using ColorSpace.Net.Convert.Extensions;

namespace ColorSpace.Net.Convert;

/// <summary>
/// Converter class to convert various color models to the CIE 1931 XYZ color model.
/// </summary>
internal class XyzConverter : ColorConverter<Xyz>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="XyzConverter"/> class with specified options.
    /// </summary>
    /// <param name="options">Options for the color converter.</param>
    public XyzConverter(ColorConverterOptions options) : base(options)
    {
    }

    /// <summary>
    /// Converts a CMY color to XYZ.
    /// </summary>
    /// <param name="value">The CMY color to convert.</param>
    /// <returns>The converted XYZ color.</returns>
    public override Xyz ConvertFrom(Cmy value)
    {
        var rgb = value.ToRgb();
        return ConvertFrom(rgb);
    }

    /// <summary>
    /// Converts a CMYK color to XYZ.
    /// </summary>
    /// <param name="value">The CMYK color to convert.</param>
    /// <returns>The converted XYZ color.</returns>
    public override Xyz ConvertFrom(Cmyk value)
    {
        var rgb = value.ToRgb();
        return ConvertFrom(rgb);
    }

    /// <summary>
    /// Converts an HSL color to XYZ.
    /// </summary>
    /// <param name="value">The HSL color to convert.</param>
    /// <returns>The converted XYZ color.</returns>
    public override Xyz ConvertFrom(Hsl value)
    {
        var rgb = value.ToRgb();
        return ConvertFrom(rgb);
    }

    /// <summary>
    /// Converts an HSV color to XYZ.
    /// </summary>
    /// <param name="value">The HSV color to convert.</param>
    /// <returns>The converted XYZ color.</returns>
    public override Xyz ConvertFrom(Hsv value)
    {
        var rgb = value.ToRgb();
        return ConvertFrom(rgb);
    }

    /// <summary>
    /// Converts a Hunter Lab color to XYZ.
    /// </summary>
    /// <param name="value">The Hunter Lab color to convert.</param>
    /// <returns>The converted XYZ color.</returns>
    public override Xyz ConvertFrom(HunterLab value)
    {
        var rgb = value.ToXyz().ToRgb();
        return ConvertFrom(rgb);
    }

    /// <summary>
    /// Converts a Lab color to XYZ.
    /// </summary>
    /// <param name="value">The Lab color to convert.</param>
    /// <returns>The converted XYZ color.</returns>
    public override Xyz ConvertFrom(Lab value)
    {
        return value.ToXyz(Options.Illuminant);
    }

    /// <summary>
    /// Converts an Lch color to XYZ.
    /// </summary>
    /// <param name="value">The Lch color to convert.</param>
    /// <returns>The converted XYZ color.</returns>
    public override Xyz ConvertFrom(Lch value)
    {
        var lab = value.ToLab();
        return ConvertFrom(lab);
    }

    /// <summary>
    /// Converts an Luv color to XYZ.
    /// </summary>
    /// <param name="value">The Luv color to convert.</param>
    /// <returns>The converted XYZ color.</returns>
    public override Xyz ConvertFrom(Luv value)
    {
        return value.ToXyz(Options.Illuminant);
    }

    /// <summary>
    /// Converts an RGB color to XYZ.
    /// </summary>
    /// <param name="value">The RGB color to convert.</param>
    /// <returns>The converted XYZ color.</returns>
    public override Xyz ConvertFrom(Rgb value)
    {
        return value.ToXyz();
    }

    /// <summary>
    /// Returns the same XYZ color (no conversion).
    /// </summary>
    /// <param name="value">The XYZ color to return.</param>
    /// <returns>The same XYZ color.</returns>
    public override Xyz ConvertFrom(Xyz value)
    {
        return value;
    }

    /// <summary>
    /// Converts a Yxy color to XYZ.
    /// </summary>
    /// <param name="value">The Yxy color to convert.</param>
    /// <returns>The converted XYZ color.</returns>
    public override Xyz ConvertFrom(Yxy value)
    {
        return value.ToXyz();
    }
}
