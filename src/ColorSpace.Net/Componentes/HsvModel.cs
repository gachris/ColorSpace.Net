using System.Drawing;

namespace ColorSpace.Net.Componentes;

internal class HsvModel
{
    public static Color Color(double hue, double saturation, double brightness)
    {
        double r = 0;
        double g = 0;
        double b = 0;

        if (saturation == 0)
        {
            r = g = b = brightness;
        }
        else
        {
            // the color wheel consists of 6 sectors. Figure out which sector you're in.
            double sectorPos = hue / 60.0;
            int sectorNumber = (int)Math.Floor(sectorPos);
            // get the fractional part of the sector
            double fractionalSector = sectorPos - sectorNumber;

            // calculate values for the three axes of the color. 
            double p = brightness * (1.0 - saturation);
            double q = brightness * (1.0 - saturation * fractionalSector);
            double t = brightness * (1.0 - saturation * (1 - fractionalSector));

            // assign the fractional colors to r, g, and b based on the sector the angle is in.
            switch (sectorNumber)
            {
                case 0:
                    r = brightness;
                    g = t;
                    b = p;
                    break;
                case 1:
                    r = q;
                    g = brightness;
                    b = p;
                    break;
                case 2:
                    r = p;
                    g = brightness;
                    b = t;
                    break;
                case 3:
                    r = p;
                    g = q;
                    b = brightness;
                    break;
                case 4:
                    r = t;
                    g = p;
                    b = brightness;
                    break;
                case 5:
                    r = brightness;
                    g = p;
                    b = q;
                    break;
            }
        }

        return System.Drawing.Color.FromArgb(System.Convert.ToByte(r * 255.0),
                                             System.Convert.ToByte(g * 255.0),
                                             System.Convert.ToByte(b * 255.0));
    }

    public static double HComponent(Color color)
    {
        var c = System.Drawing.Color.FromArgb(255, color.R, color.G, color.B);
        return c.GetHue();
    }

    public static double SComponent(Color color)
    {
        var max = (double)Math.Max(Math.Max(color.R, color.G), color.B) / 255;
        if (max == 0) return 0;
        var min = (double)Math.Min(Math.Min(color.R, color.G), color.B) / 255;
        return (max - min) / max;
    }

    public static double BComponent(Color color)
    {
        return (double)Math.Max(Math.Max(color.R, color.G), color.B) / 255;
    }
}
