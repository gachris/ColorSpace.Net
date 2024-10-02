using ColorSpace.Net.Colors;

namespace ColorSpace.Net.Convert.Extensions;

internal static class LabExtensions
{
    public static Rgb ToRgb(this Lab value, Illuminant illuminant)
    {
        double l = (double)value.L;
        double a = (double)value.A;
        double b = (double)value.B;

        double theta = 6.0 / 29.0;

        double fy = (l + 16) / 116.0;
        double fx = fy + a / 500.0;
        double fz = fy - b / 200.0;

        double x = fx > theta ? illuminant.X / 100 * (fx * fx * fx) : (fx - 16.0 / 116.0) * 3 * (theta * theta) * (illuminant.X / 100);
        double y = fy > theta ? illuminant.Y / 100 * (fy * fy * fy) : (fy - 16.0 / 116.0) * 3 * (theta * theta) * (illuminant.Y / 100);
        double z = fz > theta ? illuminant.Z / 100 * (fz * fz * fz) : (fz - 16.0 / 116.0) * 3 * (theta * theta) * (illuminant.Z / 100);

        x = x > 0.9505 ? 0.9505 : x < 0 ? 0 : x;
        y = y > 1.0 ? 1.0 : y < 0 ? 0 : y;
        z = z > 1.089 ? 1.089 : z < 0 ? 0 : z;

        var clinear = new double[3];
        clinear[0] = x * 3.2410 - y * 1.5374 - z * 0.4986; // red
        clinear[1] = -x * 0.9692 + y * 1.8760 - z * 0.0416; // green
        clinear[2] = x * 0.0556 - y * 0.2040 + z * 1.0570; // blue

        for (int i = 0; i < 3; i++)
        {
            clinear[i] = clinear[i] <= 0.0031308 ? 12.92 * clinear[i] : (1 + 0.055) * Math.Pow(clinear[i], 1.0 / 2.4) - 0.055;
            clinear[i] = Math.Min(clinear[i], 1);
            clinear[i] = Math.Max(clinear[i], 0);
        }

        return Rgb.FromRgb((byte)(clinear[0] * 255.0), (byte)(clinear[1] * 255.0), (byte)(clinear[2] * 255.0));
    }

    public static Xyz ToXyz(this Lab value, Illuminant illuminant)
    {
        var var_Y = ((double)value.L + 16) / 116;
        var var_X = (double)value.A / 500 + var_Y;
        var var_Z = var_Y - (double)value.B / 200;

        var_Y = Math.Pow(var_Y, 3) > 0.008856 ? Math.Pow(var_Y, 3) : (var_Y - 16 / 116) / 7.787;
        var_X = Math.Pow(var_X, 3) > 0.008856 ? Math.Pow(var_X, 3) : (var_X - 16 / 116) / 7.787;
        var_Z = Math.Pow(var_Z, 3) > 0.008856 ? Math.Pow(var_Z, 3) : (var_Z - 16 / 116) / 7.787;

        var x = var_X * illuminant.X;
        var y = var_Y * illuminant.Y;
        var z = var_Z * illuminant.Z;

        return Xyz.FromXyz((decimal)x, (decimal)y, (decimal)z);
    }

    public static Lch ToLch(this Lab value)
    {
        var var_H = Math.Atan2((double)value.B, (double)value.A);
        var_H = var_H > 0 ? var_H / Math.PI * 180 : 360 - Math.Abs(var_H) / Math.PI * 180;

        var l = value.L;
        var c = Math.Sqrt(Math.Pow((double)value.A, 2) + Math.Pow((double)value.B, 2));
        var h = var_H;

        return Lch.FromLch(l, (decimal)c, (decimal)h);
    }
}
