using System.Drawing;

namespace ColorSpace.Net.Componentes;

/// <summary>
/// Represents a component for the Saturation value in the HSV color space.
/// </summary>
internal class HsvSaturationComponent : NormalComponent
{
    /// <inheritdoc/>
    public override int MinValue => 0;

    /// <inheritdoc/>
    public override int MaxValue => 100;

    /// <inheritdoc/>
    public override string Name => "Hsv_Saturation";

    /// <inheritdoc/>
    public override bool IsNormalIndependantOfColor => false;

    /// <inheritdoc/>
    public override byte[] GenerateNormalMapFromColor(Color color, int width, int height, int stride)
    {
        var pixels = new byte[stride * height];
        var iRowUnit = 1.0 / height;
        var iRowCurrent = 1.0;
        var HSB_H = HsvModel.HComponent(color);
        var HSB_B = HsvModel.BComponent(color);
        var index = 0;

        for (var row = 0; row < height; ++row)
        {
            var rgb = HsvModel.Color((double)HSB_H, (double)iRowCurrent, (double)HSB_B);

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
        var saturation = (double)value / 100;
        var iRowCurrent = 1.0;
        var index = 0;

        for (var row = 0; row < height; ++row)
        {
            var iColCurrent = 359.0;
            for (var col = 0; col < width; ++col)
            {
                var hue = iColCurrent;
                var brightness = iRowCurrent;

                double r, g, b;

                if (saturation == 0)
                {
                    r = g = b = brightness;
                }
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
                        default:
                            r = g = b = brightness;
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
    public override Color ColorAtPoint(Point point, int colorComponentValue)
    {
        var hue = 359 * (double)point.X / 255d;
        var brightness = 1d - point.Y / 255d;
        var saturation = (double)colorComponentValue / 100;
        return HsvModel.Color(hue, saturation, brightness);
    }

    /// <inheritdoc/>
    public override Point PointFromColor(Color color)
    {
        var x = System.Convert.ToInt32(HsvModel.HComponent(color) / 359 * 255);
        var y = 255 - System.Convert.ToInt32(HsvModel.BComponent(color) * 255);
        return new Point(x, y);
    }
}