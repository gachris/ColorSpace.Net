using System.Drawing;
using ColorSpace.Net.Colors;
using ColorSpace.Net.Convert.Extensions;

namespace ColorSpace.Net.Componentes;

/// <summary>
/// Represents a component for the B value in the Lab color space.
/// </summary>
internal class LabBComponent : NormalComponent
{
    private const double D65X = 0.9505;
    private const double D65Y = 1.0;
    private const double D65Z = 1.0890;

    /// <inheritdoc/>
    public override int MinValue => -128;

    /// <inheritdoc/>
    public override int MaxValue => 127;

    /// <inheritdoc/>
    public override string Name => "Lab_B";

    /// <inheritdoc/>
    public override bool IsNormalIndependantOfColor => false;

    /// <inheritdoc/>
    public override byte[] GenerateNormalMapFromColor(Color color, int width, int height, int stride)
    {
        var pixels = new byte[stride * height];
        var iRowUnit = (MaxValue - MinValue) / (double)height;
        var iRowCurrent = 100.0;
        var index = 0;
        var lab = Rgb.FromRgb(color.R, color.G, color.B).ToLab(Illuminants.D65_2);

        for (var row = 0; row < height; ++row)
        {
            var rgb = Lab.FromLab(lab.L, lab.A, (int)iRowCurrent).ToRgb(Illuminants.D65_2);

            for (var col = 0; col < width; ++col)
            {
                pixels[index++] = rgb.B; // Blue
                pixels[index++] = rgb.G; // Green
                pixels[index++] = rgb.R; // Red
            }

            iRowCurrent -= iRowUnit;
        }

        return [.. pixels];
    }

    /// <inheritdoc/>
    public override byte[] GenerateNormalMapFromValue(int normalComponentValue, int width, int height, int stride)
    {
        var pixels = new byte[stride * height];
        var iRowUnit = 100.0 / height;
        var iColUnit = 255.0 / width;
        var iRowCurrent = 100.0;
        var b = normalComponentValue;
        var index = 0;

        for (var row = 0; row < height; ++row)
        {
            var l = iRowCurrent;
            var iColCurrent = -128.0;

            for (var col = 0; col < width; ++col)
            {
                var theta = 6.0 / 29.0;
                var a = iColCurrent;
                var fy = (l + 16) / 116.0;
                var fx = fy + a / 500.0;
                var fz = fy - b / 200.0;

                var x = fx > theta ? D65X * Math.Pow(fx, 3) : (fx - 16.0 / 116.0) * 3 * Math.Pow(theta, 2) * D65X;
                var y = fy > theta ? D65Y * Math.Pow(fy, 3) : (fy - 16.0 / 116.0) * 3 * Math.Pow(theta, 2) * D65Y;
                var z = fz > theta ? D65Z * Math.Pow(fz, 3) : (fz - 16.0 / 116.0) * 3 * Math.Pow(theta, 2) * D65Z;

                x = Math.Min(Math.Max(x, 0), D65X);
                y = Math.Min(Math.Max(y, 0), D65Y);
                z = Math.Min(Math.Max(z, 0), D65Z);

                var Clinear = new double[3];
                Clinear[0] = x * 3.2410 - y * 1.5374 - z * 0.4986;  // Red
                Clinear[1] = -x * 0.9692 + y * 1.8760 - z * 0.0416; // Green
                Clinear[2] = x * 0.0556 - y * 0.2040 + z * 1.0570;  // Blue

                for (int i = 0; i < 3; i++)
                {
                    Clinear[i] = Clinear[i] <= 0.0031308 ? 12.92 * Clinear[i] : (1 + 0.055) * Math.Pow(Clinear[i], 1.0 / 2.4) - 0.055;
                    Clinear[i] = Math.Min(Clinear[i], 1);
                    Clinear[i] = Math.Max(Clinear[i], 0);
                }

                pixels[index++] = (byte)(Clinear[2] * 255); // Blue
                pixels[index++] = (byte)(Clinear[1] * 255); // Green
                pixels[index++] = (byte)(Clinear[0] * 255); // Red

                iColCurrent += iColUnit;
            }

            iRowCurrent -= iRowUnit;
        }

        return [.. pixels];
    }

    /// <inheritdoc/>
    public override Color ColorAtPoint(Point point, int colorComponentValue)
    {
        var l = 100 - (double)point.Y * 100 / 256;
        var a = (double)point.X - 128;
        var b = colorComponentValue;
        var rgb = Lab.FromLab((int)l, (int)a, b).ToRgb(Illuminants.D65_2);
        return Color.FromArgb(rgb.R, rgb.G, rgb.B);
    }

    /// <inheritdoc/>
    public override Point PointFromColor(Color color)
    {
        var lab = Rgb.FromRgb(color.R, color.G, color.B).ToXyz().ToLab(Illuminants.D65_2);
        var x = 128 + (int)lab.A;
        var y = 100 - (int)lab.L;
        return new Point(x, y);
    }
}
