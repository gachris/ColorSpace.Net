using ColorSpace.Net.Colors;
using ColorSpace.Net.Helpers;

namespace ColorSpace.Net.Convert.Extensions;

internal static class XyzExtensions
{
    public static Yxy ToYxy(this Xyz value)
    {
        var y1 = value.Y;
        var x = value.X / (value.X + y1 + value.Z);
        var y2 = value.Y / (value.X + y1 + value.Z);

        return Yxy.FromYxy(y1, x, y2);
    }

    public static Rgb ToRgb(this Xyz value)
    {
        var X = (double)value.X / 100;
        var Y = (double)value.Y / 100;
        var Z = (double)value.Z / 100;

        var var_R = X * 3.2406 + Y * -1.5372 + Z * -0.4986;
        var var_G = X * -0.9689 + Y * 1.8758 + Z * 0.0415;
        var var_B = X * 0.0557 + Y * -0.2040 + Z * 1.0570;

        if (var_R > 0.0031308)
            var_R = 1.055 * Math.Pow(var_R, 1 / 2.4) - 0.055;
        else
            var_R *= 12.92;

        if (var_G > 0.0031308)
            var_G = 1.055 * Math.Pow(var_G, 1 / 2.4) - 0.055;
        else
            var_G *= 12.92;

        if (var_B > 0.0031308)
            var_B = 1.055 * Math.Pow(var_B, 1 / 2.4) - 0.055;
        else
            var_B *= 12.92;

        var R = (byte)Math.Round(var_R * 255);
        var G = (byte)Math.Round(var_G * 255);
        var B = (byte)Math.Round(var_B * 255);

        return Rgb.FromRgb(R, G, B);
    }

    public static Lab ToLab(this Xyz value, Illuminant illuminant)
    {
        var x = DoubleHelpers.PivotXyz((double)value.X / illuminant.X);
        var y = DoubleHelpers.PivotXyz((double)value.Y / illuminant.Y);
        var z = DoubleHelpers.PivotXyz((double)value.Z / illuminant.Z);

        var l = Math.Max(0, 116 * y - 16);
        var a = 500 * (x - y);
        var b = 200 * (y - z);

        return Lab.FromLab((decimal)l, (decimal)a, (decimal)b);
    }

    public static Lch ToLch(this Xyz value, Illuminant illuminant)
    {
        var lab = value.ToLab(illuminant);

        var c = Math.Sqrt((double)(lab.A * lab.A) + (double)(lab.B * lab.B));
        var hRadians = Math.Atan2((double)lab.B, (double)lab.A);
        var hDegrees = hRadians * 180 / Math.PI;

        // Ensure hue is in the range [0, 360]
        if (hDegrees < 0)
            hDegrees += 360;

        return Lch.FromLch(lab.L, (decimal)c, (decimal)hDegrees);
    }

    public static Luv ToLuv(this Xyz value, Illuminant illuminant)
    {
        var X = (double)value.X;
        var Y = (double)value.Y;
        var Z = (double)value.Z;

        var var_U = 4 * X / (X + 15 * Y + 3 * Z);
        var var_V = 9 * Y / (X + 15 * Y + 3 * Z);

        var var_Y = Y / 100;
        var_Y = var_Y > 0.008856 ? Math.Pow(var_Y, 1.0 / 3.0) : 7.787 * var_Y + 16 / 116;

        var ref_U = 4 * illuminant.X / (illuminant.X + 15 * illuminant.Y + 3 * illuminant.Z);
        var ref_V = 9 * illuminant.Y / (illuminant.X + 15 * illuminant.Y + 3 * illuminant.Z);

        var L = 116 * var_Y - 16;
        var u = 13 * L * (var_U - ref_U);
        var v = 13 * L * (var_V - ref_V);

        return Luv.FromLuv((decimal)L, (decimal)u, (decimal)v);
    }
}