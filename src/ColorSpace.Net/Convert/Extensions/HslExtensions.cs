using ColorSpace.Net.Colors;

namespace ColorSpace.Net.Convert.Extensions;

internal static class HslExtensions
{
    public static Rgb ToRgb(this Hsl value)
    {
        var hue = (double)value.H;
        var saturation = (double)value.S / 100;
        var lightness = (double)value.L / 100;

        var c = (1 - Math.Abs(2 * lightness - 1)) * saturation;
        var x = c * (1 - Math.Abs(hue / 60 % 2 - 1));
        var m = lightness - c / 2;

        double r, g, b;
        if (hue is >= 0 and < 60)
        {
            r = c;
            g = x;
            b = 0;
        }
        else if (hue is >= 60 and < 120)
        {
            r = x;
            g = c;
            b = 0;
        }
        else if (hue is >= 120 and < 180)
        {
            r = 0;
            g = c;
            b = x;
        }
        else if (hue is >= 180 and < 240)
        {
            r = 0;
            g = x;
            b = c;
        }
        else if (hue is >= 240 and < 300)
        {
            r = x;
            g = 0;
            b = c;
        }
        else
        {
            r = c;
            g = 0;
            b = x;
        }

        r += m;
        g += m;
        b += m;

        return Rgb.FromRgb(System.Convert.ToByte(r * 255.0),
                           System.Convert.ToByte(g * 255.0),
                           System.Convert.ToByte(b * 255.0));
    }
}
