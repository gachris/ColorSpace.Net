using ColorSpace.Net.Colors;

namespace ColorSpace.Net.Convert;

/// <summary>
/// Abstract base class for converting various color models to a specific target color model.
/// </summary>
/// <typeparam name="TSourceColor">The target color model type.</typeparam>
internal abstract class ColorConverter<TSourceColor> : IColorConverter<TSourceColor> where TSourceColor : IColor
{
    /// <summary>
    /// Gets the options for the color converter.
    /// </summary>
    protected ColorConverterOptions Options { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="ColorConverter{TSourceColor}"/> class with specified options.
    /// </summary>
    /// <param name="options">Options for the color converter.</param>
    protected internal ColorConverter(ColorConverterOptions options)
    {
        Options = options;
    }

    /// <summary>
    /// Converts a CMYK color to the target color model.
    /// </summary>
    /// <param name="value">The CMYK color to convert.</param>
    /// <returns>The converted color in the target color model.</returns>
    public abstract TSourceColor ConvertFrom(Cmyk value);

    /// <summary>
    /// Converts an HSL color to the target color model.
    /// </summary>
    /// <param name="value">The HSL color to convert.</param>
    /// <returns>The converted color in the target color model.</returns>
    public abstract TSourceColor ConvertFrom(Hsl value);

    /// <summary>
    /// Converts an HSV color to the target color model.
    /// </summary>
    /// <param name="value">The HSV color to convert.</param>
    /// <returns>The converted color in the target color model.</returns>
    public abstract TSourceColor ConvertFrom(Hsv value);

    /// <summary>
    /// Converts a HunterLab color to the target color model.
    /// </summary>
    /// <param name="value">The HunterLab color to convert.</param>
    /// <returns>The converted color in the target color model.</returns>
    public abstract TSourceColor ConvertFrom(HunterLab value);

    /// <summary>
    /// Converts a Lab color to the target color model.
    /// </summary>
    /// <param name="value">The Lab color to convert.</param>
    /// <returns>The converted color in the target color model.</returns>
    public abstract TSourceColor ConvertFrom(Lab value);

    /// <summary>
    /// Converts an Lch color to the target color model.
    /// </summary>
    /// <param name="value">The Lch color to convert.</param>
    /// <returns>The converted color in the target color model.</returns>
    public abstract TSourceColor ConvertFrom(Lch value);

    /// <summary>
    /// Converts a Luv color to the target color model.
    /// </summary>
    /// <param name="value">The Luv color to convert.</param>
    /// <returns>The converted color in the target color model.</returns>
    public abstract TSourceColor ConvertFrom(Luv value);

    /// <summary>
    /// Converts a CMY color to the target color model.
    /// </summary>
    /// <param name="value">The CMY color to convert.</param>
    /// <returns>The converted color in the target color model.</returns>
    public abstract TSourceColor ConvertFrom(Cmy value);

    /// <summary>
    /// Converts an RGB color to the target color model.
    /// </summary>
    /// <param name="value">The RGB color to convert.</param>
    /// <returns>The converted color in the target color model.</returns>
    public abstract TSourceColor ConvertFrom(Rgb value);

    /// <summary>
    /// Converts an XYZ color to the target color model.
    /// </summary>
    /// <param name="value">The XYZ color to convert.</param>
    /// <returns>The converted color in the target color model.</returns>
    public abstract TSourceColor ConvertFrom(Xyz value);

    /// <summary>
    /// Converts a Yxy color to the target color model.
    /// </summary>
    /// <param name="value">The Yxy color to convert.</param>
    /// <returns>The converted color in the target color model.</returns>
    public abstract TSourceColor ConvertFrom(Yxy value);

    /// <summary>
    /// Converts a color of a different color model to the target color model.
    /// </summary>
    /// <typeparam name="TDestinationColor">The type of the source color model.</typeparam>
    /// <param name="value">The color to convert.</param>
    /// <returns>The converted color in the target color model.</returns>
    /// <exception cref="ArgumentException">Thrown if the conversion from the specified color model is not supported.</exception>
    public TSourceColor ConvertFrom<TDestinationColor>(TDestinationColor value) where TDestinationColor : IColor
    {
        return value switch
        {
            Cmyk cmykValue => ConvertFrom(cmykValue),
            Hsl hslValue => ConvertFrom(hslValue),
            Hsv hsvValue => ConvertFrom(hsvValue),
            HunterLab hunterLabValue => ConvertFrom(hunterLabValue),
            Lab labValue => ConvertFrom(labValue),
            Lch lchValue => ConvertFrom(lchValue),
            Luv luvValue => ConvertFrom(luvValue),
            Cmy cmyValue => ConvertFrom(cmyValue),
            Rgb rgbValue => ConvertFrom(rgbValue),
            Xyz xyzValue => ConvertFrom(xyzValue),
            Yxy yxyValue => ConvertFrom(yxyValue),
            _ => throw new ArgumentException($"Conversion from {typeof(TDestinationColor).Name} to {typeof(TSourceColor).Name} not supported."),
        };
    }
}
