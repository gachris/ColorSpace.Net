using System.Drawing;

namespace ColorSpace.Net.Componentes;

/// <summary>
/// Represents a component for the blue value in the RGB color space.
/// </summary>
internal class RgbBlueComponent : NormalComponent
{
    /// <inheritdoc/>
    public override int MinValue => 0;

    /// <inheritdoc/>
    public override int MaxValue => 255;

    /// <inheritdoc/>
    public override string Name => "Rgb_Blue";

    /// <inheritdoc/>
    public override bool IsNormalIndependantOfColor => false;

    /// <inheritdoc/>
    public override byte[] GenerateNormalMapFromColor(Color color, int width, int height, int stride)
    {
        var index = 0;
        var pixels = new byte[stride * height];

        for (var row = 0; row < height; ++row)
        {
            for (var col = 0; col < width; ++col)
            {
                pixels[index++] = (byte)(255 - row); // Blue
                pixels[index++] = color.G; // Green
                pixels[index++] = color.R; // Red
            }
        }

        return pixels;
    }

    /// <inheritdoc/>
    public override byte[] GenerateNormalMapFromValue(int normalComponentValue, int width, int height, int stride)
    {
        var index = 0;
        var pixels = new byte[stride * height];

        for (var row = 0; row < height; ++row)
        {
            for (var col = 0; col < width; ++col)
            {
                pixels[index++] = (byte)normalComponentValue; // Blue
                pixels[index++] = (byte)(255 - row); // Green
                pixels[index++] = (byte)col; // Red
            }
        }

        return pixels;
    }

    /// <inheritdoc/>
    public override Color ColorAtPoint(Point point, int colorComponentValue)
    {
        var R = (byte)point.X;
        var G = (byte)(255 - point.Y);
        var B = (byte)colorComponentValue;
        return Color.FromArgb(R, G, B);
    }

    /// <inheritdoc/>
    public override Point PointFromColor(Color color)
    {
        return new Point(color.R, 255 - color.G);
    }
}
