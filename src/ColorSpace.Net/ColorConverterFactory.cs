using ColorSpace.Net.Colors;
using ColorSpace.Net.Convert;

namespace ColorSpace.Net;

/// <summary>
/// Factory class for creating color converters.
/// </summary>
internal class ColorConverterFactory
{
    /// <summary>
    /// Creates a color converter for the specified target color type.
    /// </summary>
    /// <typeparam name="TColor">The target color type.</typeparam>
    /// <param name="converterOptions">Options for the color converter.</param>
    /// <returns>A color converter for the specified target color type.</returns>
    public static IColorConverter<TColor>? CreateConverter<TColor>(ColorConverterOptions converterOptions)
    {
        return typeof(TColor) switch
        {
            Type t when t == typeof(Cmyk) => new CmykConverter(converterOptions) as IColorConverter<TColor>,
            Type t when t == typeof(Hsl) => new HslConverter(converterOptions) as IColorConverter<TColor>,
            Type t when t == typeof(Hsv) => new HsvConverter(converterOptions) as IColorConverter<TColor>,
            Type t when t == typeof(HunterLab) => new HunterLabConverter(converterOptions) as IColorConverter<TColor>,
            Type t when t == typeof(Lab) => new LabConverter(converterOptions) as IColorConverter<TColor>,
            Type t when t == typeof(Lch) => new LchConverter(converterOptions) as IColorConverter<TColor>,
            Type t when t == typeof(Luv) => new LuvConverter(converterOptions) as IColorConverter<TColor>,
            Type t when t == typeof(Cmy) => new CmyConverter(converterOptions) as IColorConverter<TColor>,
            Type t when t == typeof(Rgb) => new RgbConverter(converterOptions) as IColorConverter<TColor>,
            Type t when t == typeof(Xyz) => new XyzConverter(converterOptions) as IColorConverter<TColor>,
            Type t when t == typeof(Yxy) => new YxyConverter(converterOptions) as IColorConverter<TColor>,
            _ => throw new ArgumentException($"Conversion to {typeof(TColor).Name} not supported."),
        };
    }
}
