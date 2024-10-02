using ColorSpace.Net.Convert;

namespace ColorSpace.Net;

/// <summary>
/// Represents a builder for creating color converters.
/// </summary>
public class ConverterBuilder : IColorConverterBuilder
{
    private readonly ColorConverterOptions _converterBuilderOptions;

    private ConverterBuilder(ColorConverterOptions? converterBuilderOptions)
    {
        _converterBuilderOptions = converterBuilderOptions ?? new ColorConverterOptions();
    }

    /// <summary>
    /// Creates a new instance of the <see cref="ConverterBuilder"/> with the specified options.
    /// </summary>
    /// <param name="converterBuilderOptions">The options for the converter builder.</param>
    /// <returns>A new instance of the <see cref="ConverterBuilder"/>.</returns>
    public static ConverterBuilder Create(ColorConverterOptions? converterBuilderOptions = null)
    {
        return new ConverterBuilder(converterBuilderOptions);
    }

    /// <summary>
    /// Specifies the target color type for the conversion.
    /// </summary>
    /// <typeparam name="TTargetColor">The type of the target color.</typeparam>
    /// <returns>A builder for specifying the source color type.</returns>
    public IColorConverterBuilderFrom<TTargetColor> ToColor<TTargetColor>() where TTargetColor : struct
    {
        return new ColorConverterBuilderFrom<TTargetColor>(_converterBuilderOptions);
    }

    private class ColorConverterBuilderFrom<TTargetColor> : IColorConverterBuilderFrom<TTargetColor> where TTargetColor : struct
    {
        private readonly ColorConverterOptions _converterBuilderOptions;

        public ColorConverterBuilderFrom(ColorConverterOptions converterBuilderOptions)
        {
            _converterBuilderOptions = converterBuilderOptions;
        }

        /// <summary>
        /// Builds the color converter.
        /// </summary>
        /// <returns>The built color converter.</returns>
        public IColorConverter<TTargetColor> Build()
        {
            return ColorConverterFactory.CreateConverter<TTargetColor>(_converterBuilderOptions) ?? throw new ArgumentNullException(nameof(IColorConverter<TTargetColor>));
        }
    }
}