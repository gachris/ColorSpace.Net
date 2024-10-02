using ColorSpace.Net.Colors;

namespace ColorSpace.Net.Convert.Extensions;

internal static class HsvExtensions
{
    public static Rgb ToRgb(this Hsv value)
    {
        var r = 0.0m;
        var g = 0.0m;
        var b = 0.0m;

        if (value.S == 0) r = g = b = value.V;
        else
        {
            // the color wheel consists of 6 sectors. Figure out which sector you're in.
            var sectorPos = value.H / 60.0m;
            var sectorNumber = (int)Math.Floor(sectorPos);
            // get the fractional part of the sector
            var fractionalSector = sectorPos - sectorNumber;

            // calculate values for the three axes of the color. 
            var p = value.V * (1.0m - value.S);
            var q = value.V * (1.0m - value.S * fractionalSector);
            var t = value.V * (1.0m - value.S * (1 - fractionalSector));

            // assign the fractional colors to r, g, and b based on the sector the angle is in.
            switch (sectorNumber)
            {
                case 0:
                    r = value.V;
                    g = t;
                    b = p;
                    break;
                case 1:
                    r = q;
                    g = value.V;
                    b = p;
                    break;
                case 2:
                    r = p;
                    g = value.V;
                    b = t;
                    break;
                case 3:
                    r = p;
                    g = q;
                    b = value.V;
                    break;
                case 4:
                    r = t;
                    g = p;
                    b = value.V;
                    break;
                case 5:
                    r = value.V;
                    g = p;
                    b = q;
                    break;
            }
        }

        return Rgb.FromRgb(System.Convert.ToByte(r * 255.0m),
                           System.Convert.ToByte(g * 255.0m),
                           System.Convert.ToByte(b * 255.0m));
    }

    public static Hsl ToHsl(this Hsv value)
    {
        var hue = value.H;
        var saturation = value.S;
        var lightness = (value.V + value.S * Math.Min(value.V, 1 - value.V)) / 2;

        return Hsl.FromHsl(hue, saturation, lightness);
    }
}
