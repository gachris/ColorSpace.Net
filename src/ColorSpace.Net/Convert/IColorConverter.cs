using ColorSpace.Net.Colors;

namespace ColorSpace.Net.Convert;

/// <summary>
/// Defines methods for converting various color models to a specific color type.
/// </summary>
/// <typeparam name="TSourceColor">The type of color to convert to.</typeparam>
public interface IColorConverter<TSourceColor>
{
    /// <summary>
    /// Converts a CMYK color to the target color type.
    /// </summary>
    /// <param name="value">The CMYK color to convert.</param>
    /// <returns>The converted color of type <typeparamref name="TSourceColor"/>.</returns>
    TSourceColor ConvertFrom(Cmyk value);

    /// <summary>
    /// Converts an HSL color to the target color type.
    /// </summary>
    /// <param name="value">The HSL color to convert.</param>
    /// <returns>The converted color of type <typeparamref name="TSourceColor"/>.</returns>
    TSourceColor ConvertFrom(Hsl value);

    /// <summary>
    /// Converts an HSV color to the target color type.
    /// </summary>
    /// <param name="value">The HSV color to convert.</param>
    /// <returns>The converted color of type <typeparamref name="TSourceColor"/>.</returns>
    TSourceColor ConvertFrom(Hsv value);

    /// <summary>
    /// Converts a HunterLab color to the target color type.
    /// </summary>
    /// <param name="value">The HunterLab color to convert.</param>
    /// <returns>The converted color of type <typeparamref name="TSourceColor"/>.</returns>
    TSourceColor ConvertFrom(HunterLab value);

    /// <summary>
    /// Converts a Lab color to the target color type.
    /// </summary>
    /// <param name="value">The Lab color to convert.</param>
    /// <returns>The converted color of type <typeparamref name="TSourceColor"/>.</returns>
    TSourceColor ConvertFrom(Lab value);

    /// <summary>
    /// Converts a Lch color to the target color type.
    /// </summary>
    /// <param name="value">The Lch color to convert.</param>
    /// <returns>The converted color of type <typeparamref name="TSourceColor"/>.</returns>
    TSourceColor ConvertFrom(Lch value);

    /// <summary>
    /// Converts a Luv color to the target color type.
    /// </summary>
    /// <param name="value">The Luv color to convert.</param>
    /// <returns>The converted color of type <typeparamref name="TSourceColor"/>.</returns>
    TSourceColor ConvertFrom(Luv value);

    /// <summary>
    /// Converts a CMY color to the target color type.
    /// </summary>
    /// <param name="value">The CMY color to convert.</param>
    /// <returns>The converted color of type <typeparamref name="TSourceColor"/>.</returns>
    TSourceColor ConvertFrom(Cmy value);

    /// <summary>
    /// Converts an RGB color to the target color type.
    /// </summary>
    /// <param name="value">The RGB color to convert.</param>
    /// <returns>The converted color of type <typeparamref name="TSourceColor"/>.</returns>
    TSourceColor ConvertFrom(Rgb value);

    /// <summary>
    /// Converts an XYZ color to the target color type.
    /// </summary>
    /// <param name="value">The XYZ color to convert.</param>
    /// <returns>The converted color of type <typeparamref name="TSourceColor"/>.</returns>
    TSourceColor ConvertFrom(Xyz value);

    /// <summary>
    /// Converts a Yxy color to the target color type.
    /// </summary>
    /// <param name="value">The Yxy color to convert.</param>
    /// <returns>The converted color of type <typeparamref name="TSourceColor"/>.</returns>
    TSourceColor ConvertFrom(Yxy value);

    /// <summary>
    /// Converts a color of a specified type to the target color type.
    /// </summary>
    /// <typeparam name="TDestinationColor">The type of color to convert from.</typeparam>
    /// <param name="value">The color to convert.</param>
    /// <returns>The converted color of type <typeparamref name="TSourceColor"/>.</returns>
    TSourceColor ConvertFrom<TDestinationColor>(TDestinationColor value) where TDestinationColor : IColor;
}
