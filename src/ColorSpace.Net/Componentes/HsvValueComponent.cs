using System.Drawing;

namespace ColorSpace.Net.Componentes;

/// <summary>
/// Represents a component for the Value (brightness) value in the HSV color space.
/// </summary>
internal class HsvValueComponent : NormalComponent
{
    /// <inheritdoc/>
    public override int MinValue => 0;

    /// <inheritdoc/>
    public override int MaxValue => 100;

    /// <inheritdoc/>
    public override string Name => "Hsv_Value";

    /// <inheritdoc/>
    public override bool IsNormalIndependantOfColor => false;

    /// <inheritdoc/>
    public override byte[] GenerateNormalMapFromColor(Color color, int width, int height, int stride)
    {
        var pixels = new byte[stride * height];
        var iRowUnit = 1.0 / height;
        var iRowCurrent = 1.0;
        var hue = HsvModel.HComponent(color);
        var saturation = HsvModel.SComponent(color);
        var index = 0;

        for (var row = 0; row < height; ++row)
        {
            var rgb = HsvModel.Color(hue, saturation, iRowCurrent);

            for (var col = 0; col < width; ++col)
            {
                pixels[index++] = rgb.B; // Blue
                pixels[index++] = rgb.G; // Green
                pixels[index++] = rgb.R; // Red
            }

            iRowCurrent -= iRowUnit;
        }

        return pixels;
    }

    /// <inheritdoc/>
    public override byte[] GenerateNormalMapFromValue(int value, int width, int height, int stride)
    {
        var pixels = new byte[stride * height];
        var iRowUnit = 1.0 / height;
        var iColUnit = 360.0 / width;
        var brightness = (double)value / 100;
        var iRowCurrent = 1.0;
        var r = 0.0;
        var g = 0.0;
        var b = 0.0;
        var index = 0;

        for (var row = 0; row < height; ++row)
        {
            var iColCurrent = 359.0;
            for (var col = 0; col < width; ++col)
            {
                var hue = iColCurrent;
                var saturation = iRowCurrent;

                // Calculate R, G, B components based on hue, saturation, and brightness
                if (saturation == 0) r = g = b = brightness;
                else
                {
                    var sectorPos = hue / 60.0;
                    var sectorNumber = (int)Math.Floor(sectorPos);
                    var fractionalSector = sectorPos - sectorNumber;

                    var p = brightness * (1.0 - saturation);
                    var q = brightness * (1.0 - saturation * fractionalSector);
                    var t = brightness * (1.0 - saturation * (1 - fractionalSector));

                    switch (sectorNumber)
                    {
                        case 0:
                            r = brightness;
                            g = t;
                            b = p;
                            break;
                        case 1:
                            r = q;
                            g = brightness;
                            b = p;
                            break;
                        case 2:
                            r = p;
                            g = brightness;
                            b = t;
                            break;
                        case 3:
                            r = p;
                            g = q;
                            b = brightness;
                            break;
                        case 4:
                            r = t;
                            g = p;
                            b = brightness;
                            break;
                        case 5:
                            r = brightness;
                            g = p;
                            b = q;
                            break;
                    }
                }

                pixels[index++] = (byte)(g * 255); // Blue
                pixels[index++] = (byte)(b * 255); // Green
                pixels[index++] = (byte)(r * 255); // Red

                iColCurrent -= iColUnit;
            }

            iRowCurrent -= iRowUnit;
        }

        return pixels;
    }

    /// <inheritdoc/>
    public override Color ColorAtPoint(Point selectionPoint, int colorComponentValue)
    {
        var hue = 359 * selectionPoint.X / 255;
        var brightness = (double)colorComponentValue / 100;
        var saturation = 1 - (double)selectionPoint.Y / 255;
        return HsvModel.Color(hue, saturation, brightness);
    }

    /// <inheritdoc/>
    public override Point PointFromColor(Color color)
    {
        int x = System.Convert.ToInt32(HsvModel.HComponent(color) / 359 * 255);
        int y = 255 - System.Convert.ToInt32(HsvModel.SComponent(color) * 255);
        return new Point(x, y);
    }
}