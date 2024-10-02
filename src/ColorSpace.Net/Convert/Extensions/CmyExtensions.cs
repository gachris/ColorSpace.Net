using ColorSpace.Net.Colors;
using ColorSpace.Net.Helpers;

namespace ColorSpace.Net.Convert.Extensions;

internal static class CmyExtensions
{
    public static Cmyk ToCmyk(this Cmy value)
    {
        var var_K = 1m;

        var C = value.C;
        var M = value.M;
        var Y = value.Y;

        if (C < var_K) var_K = C;
        if (M < var_K) var_K = M;
        if (Y < var_K) var_K = Y;

        if (var_K == 1)
        {
            C = 0;     //Black only
            M = 0;
            Y = 0;
        }
        else
        {
            C = (C - var_K) / (1 - var_K);
            M = (M - var_K) / (1 - var_K);
            Y = (Y - var_K) / (1 - var_K);
        }

        var K = var_K;

        return Cmyk.FromCmyk(C, M, Y, K);
    }

    public static Rgb ToRgb(this Cmy value)
    {
        var r = DecimalHelpers.RestrictToByte((1 - value.C) * 255.0m);
        var g = DecimalHelpers.RestrictToByte((1 - value.M) * 255.0m);
        var b = DecimalHelpers.RestrictToByte((1 - value.Y) * 255.0m);

        return Rgb.FromRgb(r, g, b);
    }
}
