using System.Drawing;

namespace ColorSpace.Net.Componentes;

/// <summary>
/// Represents a component for the green value in the RGB color space.
/// </summary>
internal class RgbGreenComponent : NormalComponent
{
    /// <inheritdoc/>
    public override int MinValue => 0;

    /// <inheritdoc/>
    public override int MaxValue => 255;

    /// <inheritdoc/>
    public override string Name => "Rgb_Green";

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
                pixels[index++] = color.G; // Green
                pixels[index++] = (byte)(255 - row); // Blue
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
                pixels[index++] = (byte)col; // Blue
                pixels[index++] = (byte)normalComponentValue; // Green
                pixels[index++] = (byte)(255 - row); // Red
            }
        }

        return pixels;
    }

    /// <inheritdoc/>
    public override Color ColorAtPoint(Point point, int colorComponentValue)
    {
        var R = (byte)(255 - point.Y);
        var G = (byte)colorComponentValue;
        var B = (byte)point.X;
        return Color.FromArgb(R, G, B);
    }

    /// <inheritdoc/>
    public override Point PointFromColor(Color color)
    {
        return new Point(color.B, 255 - color.R);
    }
}
