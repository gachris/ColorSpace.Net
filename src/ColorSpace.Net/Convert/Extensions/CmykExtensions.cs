using ColorSpace.Net.Colors;
using ColorSpace.Net.Helpers;

namespace ColorSpace.Net.Convert.Extensions;

internal static class CmykExtensions
{
    public static Cmy ToCmy(this Cmyk value)
    {
        var C = value.C * (1.0m - value.K) + value.K;
        var M = value.M * (1.0m - value.K) + value.K;
        var Y = value.Y * (1.0m - value.K) + value.K;

        return Cmy.FromCmy(C, M, Y);
    }

    public static Rgb ToRgb(this Cmyk value)
    {
        var r = DecimalHelpers.RestrictToByte(255.0m * (1 - value.C) * (1 - value.K));
        var g = DecimalHelpers.RestrictToByte(255.0m * (1 - value.M) * (1 - value.K));
        var b = DecimalHelpers.RestrictToByte(255.0m * (1 - value.Y) * (1 - value.K));

        return Rgb.FromRgb(r, g, b);
    }
}
