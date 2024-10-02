using ColorSpace.Net.Colors;

namespace ColorSpace.Net.Convert.Extensions;

internal static class LuvExtensions
{
    public static Xyz ToXyz(this Luv value, Illuminant illuminant)
    {
        var L = value.L;
        var u = value.U;
        var v = value.V;

        var u0 = 4 * illuminant.X / (illuminant.X + 15 * illuminant.Y + 3 * illuminant.Z);
        var v0 = 9 * illuminant.Y / (illuminant.X + 15 * illuminant.Y + 3 * illuminant.Z);

        var Y = (double)L > CIEConstants.Kappa * CIEConstants.Epsilon
            ? (double)Math.Pow(((double)L + 16) / 116d, 3)
            : (double)L / CIEConstants.Kappa;

        var a = (52 * (double)L / ((double)u + 13 * (double)L * u0) - 1) / 3;
        var b = -5 * Y;
        var c = -1 / 3d;
        var d = Y * (39 * (double)L / ((double)v + 13 * (double)L * v0) - 5);

        var X = (d - b) / (a - c);
        var Z = X * a + b;

        if (double.IsNaN(X) || X < 0)
            X = 0;

        if (double.IsNaN(Y) || Y < 0)
            Y = 0;

        if (double.IsNaN(Z) || Z < 0)
            Z = 0;

        return Xyz.FromXyz((decimal)X * 100, (decimal)Y * 100, (decimal)Z * 100);
    }
}
