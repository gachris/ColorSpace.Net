namespace ColorSpace.Net;

/// <summary>
/// Represents a builder for color converters.
/// </summary>
public interface IColorConverterBuilder
{
    /// <summary>
    /// Specifies the target color type for the conversion.
    /// </summary>
    /// <typeparam name="TTargetColor">The type of the target color.</typeparam>
    /// <returns>A builder for specifying the source color type.</returns>
    IColorConverterBuilderFrom<TTargetColor> ToColor<TTargetColor>() where TTargetColor : struct;
}
