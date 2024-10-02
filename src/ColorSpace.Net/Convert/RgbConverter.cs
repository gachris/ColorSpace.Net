using ColorSpace.Net.Colors;
using ColorSpace.Net.Convert.Extensions;

namespace ColorSpace.Net.Convert;

/// <summary>
/// Converter class to convert various color models to the RGB color model.
/// </summary>
internal class RgbConverter : ColorConverter<Rgb>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="RgbConverter"/> class with specified options.
    /// </summary>
    /// <param name="options">Options for the color converter.</param>
    public RgbConverter(ColorConverterOptions options) : base(options)
    {
    }

    /// <summary>
    /// Converts a CMY color to RGB.
    /// </summary>
    /// <param name="value">The CMY color to convert.</param>
    /// <returns>The converted RGB color.</returns>
    public override Rgb ConvertFrom(Cmy value)
    {
        return value.ToRgb();
    }

    /// <summary>
    /// Converts a CMYK color to RGB.
    /// </summary>
    /// <param name="value">The CMYK color to convert.</param>
    /// <returns>The converted RGB color.</returns>
    public override Rgb ConvertFrom(Cmyk value)
    {
        return value.ToRgb();
    }

    /// <summary>
    /// Converts an HSL color to RGB.
    /// </summary>
    /// <param name="value">The HSL color to convert.</param>
    /// <returns>The converted RGB color.</returns>
    public override Rgb ConvertFrom(Hsl value)
    {
        return value.ToRgb();
    }

    /// <summary>
    /// Converts an HSV color to RGB.
    /// </summary>
    /// <param name="value">The HSV color to convert.</param>
    /// <returns>The converted RGB color.</returns>
    public override Rgb ConvertFrom(Hsv value)
    {
        return value.ToRgb();
    }

    /// <summary>
    /// Converts a Hunter Lab color to RGB.
    /// </summary>
    /// <param name="value">The Hunter Lab color to convert.</param>
    /// <returns>The converted RGB color.</returns>
    public override Rgb ConvertFrom(HunterLab value)
    {
        var xyz = value.ToXyz();
        return ConvertFrom(xyz);
    }

    /// <summary>
    /// Converts a Lab color to RGB.
    /// </summary>
    /// <param name="value">The Lab color to convert.</param>
    /// <returns>The converted RGB color.</returns>
    public override Rgb ConvertFrom(Lab value)
    {
        var xyz = value.ToXyz(Options.Illuminant);
        return ConvertFrom(xyz);
    }

    /// <summary>
    /// Converts an Lch color to RGB.
    /// </summary>
    /// <param name="value">The Lch color to convert.</param>
    /// <returns>The converted RGB color.</returns>
    public override Rgb ConvertFrom(Lch value)
    {
        var lab = value.ToLab();
        return ConvertFrom(lab);
    }

    /// <summary>
    /// Converts an Luv color to RGB.
    /// </summary>
    /// <param name="value">The Luv color to convert.</param>
    /// <returns>The converted RGB color.</returns>
    public override Rgb ConvertFrom(Luv value)
    {
        var xyz = value.ToXyz(Options.Illuminant);
        return ConvertFrom(xyz);
    }

    /// <summary>
    /// Converts an RGB color to RGB (returns the same color).
    /// </summary>
    /// <param name="value">The RGB color to convert.</param>
    /// <returns>The same RGB color.</returns>
    public override Rgb ConvertFrom(Rgb value)
    {
        return value;
    }

    /// <summary>
    /// Converts an XYZ color to RGB.
    /// </summary>
    /// <param name="value">The XYZ color to convert.</param>
    /// <returns>The converted RGB color.</returns>
    public override Rgb ConvertFrom(Xyz value)
    {
        return value.ToRgb();
    }

    /// <summary>
    /// Converts a Yxy color to RGB.
    /// </summary>
    /// <param name="value">The Yxy color to convert.</param>
    /// <returns>The converted RGB color.</returns>
    public override Rgb ConvertFrom(Yxy value)
    {
        var xyz = value.ToXyz();
        return ConvertFrom(xyz);
    }
}
