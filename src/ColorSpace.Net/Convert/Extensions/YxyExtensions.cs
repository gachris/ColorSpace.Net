using ColorSpace.Net.Colors;

namespace ColorSpace.Net.Convert.Extensions;

internal static class YxyExtensions
{
    public static Xyz ToXyz(this Yxy value)
    {
        var X = value.X * (value.Y1 / value.Y2);
        var Y = value.Y1;
        var Z = (1 - value.X - value.Y2) * (Y / value.Y2);

        return Xyz.FromXyz(X, Y, Z);
    }
}
