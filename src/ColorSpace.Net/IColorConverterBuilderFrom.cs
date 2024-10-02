using ColorSpace.Net.Convert;

namespace ColorSpace.Net;

/// <summary>
/// Represents a builder for creating color converters from a specific target color.
/// </summary>
/// <typeparam name="TTargetColor">The type of the target color.</typeparam>
public interface IColorConverterBuilderFrom<TTargetColor> where TTargetColor : struct
{
    /// <summary>
    /// Builds the color converter for the specified target color.
    /// </summary>
    /// <returns>The built color converter.</returns>
    IColorConverter<TTargetColor> Build();
}
