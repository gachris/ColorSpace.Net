using ColorSpace.Net.Colors;
using ColorSpace.Net.Convert.Extensions;

namespace ColorSpace.Net.Convert;

/// <summary>
/// Converter class to convert various color models to the CIE L*u*v* (Luv) color model.
/// </summary>
internal class LuvConverter : ColorConverter<Luv>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="LuvConverter"/> class with specified options.
    /// </summary>
    /// <param name="options">Options for the color converter.</param>
    public LuvConverter(ColorConverterOptions options) : base(options)
    {
    }

    /// <summary>
    /// Converts a CMY color to Luv.
    /// </summary>
    /// <param name="value">The CMY color to convert.</param>
    /// <returns>The converted Luv color.</returns>
    public override Luv ConvertFrom(Cmy value)
    {
        var rgb = value.ToRgb();
        return ConvertFrom(rgb);
    }

    /// <summary>
    /// Converts a CMYK color to Luv.
    /// </summary>
    /// <param name="value">The CMYK color to convert.</param>
    /// <returns>The converted Luv color.</returns>
    public override Luv ConvertFrom(Cmyk value)
    {
        var rgb = value.ToRgb();
        return ConvertFrom(rgb);
    }

    /// <summary>
    /// Converts an HSL color to Luv.
    /// </summary>
    /// <param name="value">The HSL color to convert.</param>
    /// <returns>The converted Luv color.</returns>
    public override Luv ConvertFrom(Hsl value)
    {
        var rgb = value.ToRgb();
        return ConvertFrom(rgb);
    }

    /// <summary>
    /// Converts an HSV color to Luv.
    /// </summary>
    /// <param name="value">The HSV color to convert.</param>
    /// <returns>The converted Luv color.</returns>
    public override Luv ConvertFrom(Hsv value)
    {
        var rgb = value.ToRgb();
        return ConvertFrom(rgb);
    }

    /// <summary>
    /// Converts a Hunter Lab color to Luv.
    /// </summary>
    /// <param name="value">The Hunter Lab color to convert.</param>
    /// <returns>The converted Luv color.</returns>
    public override Luv ConvertFrom(HunterLab value)
    {
        var xyz = value.ToXyz();
        return ConvertFrom(xyz);
    }

    /// <summary>
    /// Converts a Lab color to Luv.
    /// </summary>
    /// <param name="value">The Lab color to convert.</param>
    /// <returns>The converted Luv color.</returns>
    public override Luv ConvertFrom(Lab value)
    {
        var xyz = value.ToXyz(Options.Illuminant);
        return ConvertFrom(xyz);
    }

    /// <summary>
    /// Converts an Lch color to Luv.
    /// </summary>
    /// <param name="value">The Lch color to convert.</param>
    /// <returns>The converted Luv color.</returns>
    public override Luv ConvertFrom(Lch value)
    {
        var lab = value.ToLab();
        var xyz = lab.ToXyz(Options.Illuminant);
        return ConvertFrom(xyz);
    }

    /// <summary>
    /// Converts an Luv color to Luv (returns the same color).
    /// </summary>
    /// <param name="value">The Luv color to convert.</param>
    /// <returns>The same Luv color.</returns>
    public override Luv ConvertFrom(Luv value)
    {
        return value;
    }

    /// <summary>
    /// Converts an RGB color to Luv.
    /// </summary>
    /// <param name="value">The RGB color to convert.</param>
    /// <returns>The converted Luv color.</returns>
    public override Luv ConvertFrom(Rgb value)
    {
        var xyz = value.ToXyz();
        return ConvertFrom(xyz);
    }

    /// <summary>
    /// Converts an XYZ color to Luv.
    /// </summary>
    /// <param name="value">The XYZ color to convert.</param>
    /// <returns>The converted Luv color.</returns>
    public override Luv ConvertFrom(Xyz value)
    {
        return value.ToLuv(Options.Illuminant);
    }

    /// <summary>
    /// Converts a Yxy color to Luv.
    /// </summary>
    /// <param name="value">The Yxy color to convert.</param>
    /// <returns>The converted Luv color.</returns>
    public override Luv ConvertFrom(Yxy value)
    {
        var xyz = value.ToXyz();
        return ConvertFrom(xyz);
    }
}
