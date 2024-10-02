using System.Drawing;

namespace ColorSpace.Net.Componentes;

/// <summary>
/// Abstract base class for components representing a color space.
/// </summary>
internal abstract class NormalComponent : INormalComponent
{
    /// <inheritdoc/>
    public abstract string Name { get; }

    /// <inheritdoc/>
    public abstract int MaxValue { get; }

    /// <inheritdoc/>
    public abstract int MinValue { get; }

    /// <inheritdoc/>
    public abstract bool IsNormalIndependantOfColor { get; }

    /// <inheritdoc/>
    public abstract byte[] GenerateNormalMapFromValue(int value, int width, int height, int stride);

    /// <inheritdoc/>
    public abstract byte[] GenerateNormalMapFromColor(Color color, int width, int height, int stride);

    /// <inheritdoc/>
    public virtual byte[] GenerateNormalMapWithAlphaChannel(Color color, int width, int height, int stride)
    {
        var index = 0;
        var pixels = new byte[stride * height];

        for (var row = 0; row < height; ++row)
        {
            for (var col = 0; col < width; ++col)
            {
                pixels[index++] = color.B;           // Blue
                pixels[index++] = color.G;           // Green
                pixels[index++] = color.R;           // Red
                pixels[index++] = (byte)(255 - row); // Alpha
            }
        }

        return pixels;
    }

    /// <inheritdoc/>
    public abstract Color ColorAtPoint(Point point, int value);

    /// <inheritdoc/>
    public abstract Point PointFromColor(Color color);
}
