namespace ColorSpace.Net.Colors;

/// <summary>
/// Interface for a color representation.
/// </summary>
public interface IColor : IFormattable
{
    /// <summary>
    /// Converts the color to a string representation using the specified format provider.
    /// </summary>
    string ToString(IFormatProvider? provider);
}
