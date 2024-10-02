using ColorSpace.Net.Colors;
using ColorSpace.Net.Helpers;

namespace ColorSpace.Net.Convert.Extensions;

internal static class LchExtensions
{
    public static Lab ToLab(this Lch value)
    {
        var L = value.L;
        var A = value.C * (decimal)Math.Cos(DoubleHelpers.DegreeToRadian((double)value.H));
        var B = value.C * (decimal)Math.Sin(DoubleHelpers.DegreeToRadian((double)value.H));

        return Lab.FromLab(L, A, B);
    }
}