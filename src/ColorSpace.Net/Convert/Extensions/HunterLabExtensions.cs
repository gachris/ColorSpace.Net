using ColorSpace.Net.Colors;

namespace ColorSpace.Net.Convert.Extensions;

internal static class HunterLabExtensions
{
    //public static Xyz ToXyz(this HunterLab value, Illuminant illuminant)
    //{
    //    var L = (double)value.L;
    //    var a = (double)value.A;
    //    var b = (double)value.B;
    //    double Xn = illuminant.X, Yn = illuminant.Y, Zn = illuminant.Z;

    //    var Ka = illuminant == Illuminants.C_2 ? 175 : 100 * (175 / 198.04) * ((illuminant.X + illuminant.Y) / 100);
    //    var Kb = illuminant == Illuminants.C_2 ? 70 : 100 * (70 / 218.11) * ((illuminant.Y + illuminant.Z) / 100);

    //    var Y = Math.Pow(L / 100d, 2) * Yn;
    //    var X = (a / Ka * Math.Sqrt(Y / Yn) + Y / Yn) * Xn;
    //    var Z = (b / Kb * Math.Sqrt(Y / Yn) - Y / Yn) * -Zn;

    //    return Xyz.FromXyz((decimal)X, (decimal)Y, (decimal)Z);
    //}

    public static Xyz ToXyz(this HunterLab value)
    {
        var x = (double)value.A / 17.5 * ((double)value.L / 10.0);
        var itemL_10 = (double)value.L / 10.0;
        var y = itemL_10 * itemL_10;
        var z = (double)value.B / 7.0 * (double)value.L / 10.0;

        var X = (x + y) / 1.02;
        var Y = y;
        var Z = -(z - y) / .847;

        return Xyz.FromXyz((decimal)X, (decimal)Y, (decimal)Z);
    }
}
