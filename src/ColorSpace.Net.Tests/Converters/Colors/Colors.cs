namespace ColorSpace.Net.Tests.Converters.Colors;

public class CmyColors
{
    public static readonly Cmy Amazon = Cmy.FromCmy(0.807843137254902m, 0.5098039215686274m, 0.6235294117647059m);
    public static readonly Cmy CelestialBlue = Cmy.FromCmy(0.6862745098039216m, 0.39607843137254906m, 0.16078431372549018m);
}

public class CmykColors
{
    public static readonly Cmyk Amazon = Cmyk.FromCmyk(0.6080000000000001m, 0m, 0.23200000000000007m, 0.5098039215686274m);
    public static readonly Cmyk CelestialBlue = Cmyk.FromCmyk(0.6261682242990654m, 0.28037383177570097m, 0m, 0.16078431372549018m);
}

public class HslColors
{
    public static readonly Hsl Amazon = Hsl.FromHsl(157.10526282029676m, 43.67816024181204m, 34.117647260427475m);
    public static readonly Hsl CelestialBlue = Hsl.FromHsl(206.86566951386934m, 62.037036539437395m, 57.64705937867072m);
}

public class HsvColors
{
    public static readonly Hsv Amazon = Hsv.FromHsv(157.10526282029676m, 0.608m, 0.49019607843137253m);
    public static readonly Hsv CelestialBlue = Hsv.FromHsv(206.86566951386934m, 0.6261682242990654m, 0.8392156862745098m);
}

public class HunterLabColors
{
    public static readonly HunterLab Amazon = HunterLab.FromHunterLab(40.20538180594155m, -22.803267175110125m, 8.055881563113791m);
    public static readonly HunterLab CelestialBlue = HunterLab.FromHunterLab(54.471749823994394m, -6.843704847415613m, -35.800205153372765m);
}

public class LabColors
{
    public static readonly Lab Amazon = Lab.FromLab(47.189868224870494m, -30.856615797228564m, 8.91988579563332m);
    public static readonly Lab CelestialBlue = Lab.FromLab(61.369930534899865m, -4.801215681831838m, -37.49265882050048m);
}

public class LchColors
{
    public static readonly Lch Amazon = Lch.FromLch(47.189868224870494m, 32.12001091321291m, 163.87672383227132m);
    public static readonly Lch CelestialBlue = Lch.FromLch(61.369930534899865m, 37.798824551220115m, 262.7025630290027m);
}

public class LuvColors
{
    public static readonly Luv Amazon = Luv.FromLuv(47.189868224870494m, -31.97898099901001m, 16.208655339897803m);
    public static readonly Luv CelestialBlue = Luv.FromLuv(61.369930534899865m, -30.341528283633533m, -58.40580420071801m);
}

public class RgbColors
{
    public static readonly Rgb Amazon = Rgb.FromRgb(49, 125, 96);
    public static readonly Rgb CelestialBlue = Rgb.FromRgb(80, 154, 214);
}

public class XyzColors
{
    public static readonly Xyz Amazon = Xyz.FromXyz(10.711558585907511m, 16.164727261615358m, 13.621877454623712m);
    public static readonly Xyz CelestialBlue = Xyz.FromXyz(27.001465530734052m, 29.67171528887834m, 67.92241337466149m);
}

public class YxyColors
{
    public static readonly Yxy Amazon = Yxy.FromYxy(16.164727261615358m, 0.26449492304110866m, 0.39914716973741265m);
    public static readonly Yxy CelestialBlue = Yxy.FromYxy(29.67171528887834m, 0.21671284370322444m, 0.2381441774145974m);
}