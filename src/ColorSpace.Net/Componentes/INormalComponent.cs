using System.Drawing;

namespace ColorSpace.Net.Componentes;

/// <summary>
/// Interface for a normal component, representing a single color component.
/// </summary>
public interface INormalComponent
{
    /// <summary>
    /// Name of the normal component.
    /// </summary>
    string Name { get; }

    /// <summary>
    /// Maximum value of the normal component.
    /// </summary>
    int MaxValue { get; }

    /// <summary>
    /// Minimum value of the normal component.
    /// </summary>
    int MinValue { get; }

    /// <summary>
    /// Indicates whether the normal component is independent of the color.
    /// </summary>
    bool IsNormalIndependantOfColor { get; }

    /// <summary>
    /// Retrieves the color at a specified point given the value of the normal component.
    /// </summary>
    Color ColorAtPoint(Point point, int value);

    /// <summary>
    /// Retrieves the point on the normal component given a color.
    /// </summary>
    Point PointFromColor(Color color);

    /// <summary>
    /// Generates a normal map from a value of the normal component.
    /// </summary>
    byte[] GenerateNormalMapFromValue(int value, int width, int height, int stride);

    /// <summary>
    /// Generates a normal map from a color, assuming this normal component represents the color.
    /// </summary>
    byte[] GenerateNormalMapFromColor(Color color, int width, int height, int stride);

    /// <summary>
    /// Generates a normal map with an alpha channel from a color, assuming this normal component represents the color.
    /// </summary>
    byte[] GenerateNormalMapWithAlphaChannel(Color color, int width, int height, int stride);
}
