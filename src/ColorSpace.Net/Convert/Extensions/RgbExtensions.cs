using ColorSpace.Net.Colors;
using ColorSpace.Net.Helpers;

namespace ColorSpace.Net.Convert.Extensions;

internal static class RgbExtensions
{
    public static Lab ToLab(this Rgb rgb, Illuminant illuminant)
    {
        var red = rgb.R;
        var green = rgb.G;
        var blue = rgb.B;

        double rLinear = red / 255.0;
        double gLinear = green / 255.0;
        double bLinear = blue / 255.0;

        double r = rLinear > 0.04045 ? Math.Pow((rLinear + 0.055) / (1 + 0.055), 2.2) : rLinear / 12.92;
        double g = gLinear > 0.04045 ? Math.Pow((gLinear + 0.055) / (1 + 0.055), 2.2) : gLinear / 12.92;
        double b = bLinear > 0.04045 ? Math.Pow((bLinear + 0.055) / (1 + 0.055), 2.2) : bLinear / 12.92;

        double CIEX = r * 0.4124 + g * 0.3576 + b * 0.1805;
        double CIEY = r * 0.2126 + g * 0.7152 + b * 0.0722;
        double CIEZ = r * 0.0193 + g * 0.1192 + b * 0.9505;

        double CIEL = 116.0 * DoubleHelpers.Fxyz(CIEY / (illuminant.Y / 100)) - 16;
        double CIEa = 500.0 * (DoubleHelpers.Fxyz(CIEX / (illuminant.X / 100)) - DoubleHelpers.Fxyz(CIEY / (illuminant.Y / 100)));
        double CIEb = 200.0 * (DoubleHelpers.Fxyz(CIEY / (illuminant.Y / 100)) - DoubleHelpers.Fxyz(CIEZ / (illuminant.Z / 100)));

        return Lab.FromLab((decimal)CIEL, (decimal)CIEa, (decimal)CIEb);
    }

    public static Xyz ToXyz(this Rgb value)
    {
        var var_R = value.R / 255d;
        var var_G = value.G / 255d;
        var var_B = value.B / 255d;

        if (var_R > 0.04045)
            var_R = Math.Pow((var_R + 0.055) / 1.055, 2.4);
        else
            var_R /= 12.92;

        if (var_G > 0.04045)
            var_G = Math.Pow((var_G + 0.055) / 1.055, 2.4);
        else
            var_G /= 12.92;

        if (var_B > 0.04045)
            var_B = Math.Pow((var_B + 0.055) / 1.055, 2.4);
        else
            var_B /= 12.92;

        var X = var_R * 0.4124 + var_G * 0.3576 + var_B * 0.1805;
        var Y = var_R * 0.2126 + var_G * 0.7152 + var_B * 0.0722;
        var Z = var_R * 0.0193 + var_G * 0.1192 + var_B * 0.9505;

        return Xyz.FromXyz((decimal)X * 100, (decimal)Y * 100, (decimal)Z * 100);
    }

    public static Hsl ToHsl(this Rgb value)
    {
        var R = value.R / 255d;
        var G = value.G / 255d;
        var B = value.B / 255d;

        var colors = new double[] { R, G, B };

        var Cmax = colors.Max();
        var Cmin = colors.Min();

        var D = Cmax - Cmin;

        var hue = D == 0 ?
            0 : Cmax == R ?
            (G - B) / D : Cmax == G ?
            2.0d + (B - R) / D : Cmax == B ?
            4.0d + (R - G) / D : 0;

        hue *= 60;
        if (hue < 0) hue += 360;

        var lightness = (Cmax + Cmin) / 2;
        var saturation = D == 0 ? 0 : D / (1 - Math.Abs(2 * lightness - 1));

        lightness *= 100;
        saturation *= 100;

        return Hsl.FromHsl((decimal)hue, (decimal)saturation, (decimal)lightness);
    }

    public static HunterLab ToHunterLab(this Rgb value)
    {
        var xyz = value.ToXyz();

        var X = (double)xyz.X;
        var Y = (double)xyz.Y;
        var Z = (double)xyz.Z;

        var L = 10 * Math.Sqrt(Y);
        var a = 17.5 * ((1.02 * X - Y) / Math.Sqrt(Y));
        var b = 7 * ((Y - 0.847 * Z) / Math.Sqrt(Y));

        return HunterLab.FromHunterLab((decimal)L, (decimal)a, (decimal)b);
    }

    public static Hsv ToHsv(this Rgb value)
    {
        var var_R = value.R / 255d;
        var var_G = value.G / 255d;
        var var_B = value.B / 255d;

        var colors = new double[] { var_R, var_G, var_B };

        var var_Max = colors.Max();
        var var_Min = colors.Min();

        var del_Max = var_Max - var_Min;

        var v = var_Max;
        var saturation = del_Max == 0 ? 0 : del_Max / var_Max;
        var hue = del_Max == 0 ?
            0 : var_Max == var_R ?
            (var_G - var_B) / del_Max : var_Max == var_G ?
            2.0d + (var_B - var_R) / del_Max : var_Max == var_B ?
            4.0d + (var_R - var_G) / del_Max : 0;

        hue *= 60;
        if (hue < 0) hue += 360;

        return Hsv.FromHsv((decimal)hue, (decimal)saturation, (decimal)v);
    }

    public static Cmy ToCmy(this Rgb value)
    {
        var R = value.R / 255d;
        var G = value.G / 255d;
        var B = value.B / 255d;

        var colors = new double[] { R, G, B };

        var Cmax = colors.Max();

        var K = 1 - Cmax;
        var C = K == 1 ? 0 : (1 - R - K) / (1 - K);
        var M = K == 1 ? 0 : (1 - G - K) / (1 - K);
        var Y = K == 1 ? 0 : (1 - B - K) / (1 - K);

        C = C * (1 - K) + K;
        M = M * (1 - K) + K;
        Y = Y * (1 - K) + K;

        return Cmy.FromCmy((decimal)C, (decimal)M, (decimal)Y);
    }

    public static Cmyk ToCmyk(this Rgb value)
    {
        var R = value.R / 255m;
        var G = value.G / 255m;
        var B = value.B / 255m;

        var colors = new decimal[] { R, G, B };

        var Cmax = colors.Max();

        var K = 1.0m - Cmax;
        var C = K == 1 ? 0 : (1.0m - R - K) / (1 - K);
        var M = K == 1 ? 0 : (1.0m - G - K) / (1 - K);
        var Y = K == 1 ? 0 : (1.0m - B - K) / (1 - K);

        return Cmyk.FromCmyk(C, M, Y, K);
    }
}
