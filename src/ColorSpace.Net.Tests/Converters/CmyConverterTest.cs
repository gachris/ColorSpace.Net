using ColorSpace.Net.Tests.Converters.Colors;

namespace ColorSpace.Net.Tests.Converters;

public class CmyConverterTest
{
    private readonly IColorConverter<Cmy> _converter_D65_2;
    private readonly IColorConverter<Cmy> _converter_C_2;

    public static TheoryData<Cmy, Cmyk> DataCmyk =>
        new()
        {
            { CmyColors.Amazon, CmykColors.Amazon },
            { CmyColors.CelestialBlue, CmykColors.CelestialBlue }
        };

    public static TheoryData<Cmy, Hsl> DataHsl =>
        new()
        {
            { CmyColors.Amazon, HslColors.Amazon },
            { CmyColors.CelestialBlue, HslColors.CelestialBlue }
        };

    public static TheoryData<Cmy, Hsv> DataHsv =>
        new()
        {
            { CmyColors.Amazon, HsvColors.Amazon },
            { CmyColors.CelestialBlue, HsvColors.CelestialBlue }
        };

    public static TheoryData<Cmy, HunterLab> DataHunterLab =>
        new()
        {
            { CmyColors.Amazon, HunterLabColors.Amazon },
            { CmyColors.CelestialBlue, HunterLabColors.CelestialBlue }
        };

    public static TheoryData<Cmy, Lab> DataLab =>
        new()
        {
            { CmyColors.Amazon, LabColors.Amazon },
            { CmyColors.CelestialBlue, LabColors.CelestialBlue }
        };

    public static TheoryData<Cmy, Lch> DataLch =>
        new()
        {
            { CmyColors.Amazon, LchColors.Amazon },
            { CmyColors.CelestialBlue, LchColors.CelestialBlue }
        };

    public static TheoryData<Cmy, Luv> DataLuv =>
        new()
        {
            { CmyColors.Amazon, LuvColors.Amazon },
            { CmyColors.CelestialBlue, LuvColors.CelestialBlue }
        };

    public static TheoryData<Cmy, Rgb> DataRgb =>
        new()
        {
            { CmyColors.Amazon, RgbColors.Amazon },
            { CmyColors.CelestialBlue, RgbColors.CelestialBlue }
        };

    public static TheoryData<Cmy, Xyz> DataXyz =>
        new()
        {
            { CmyColors.Amazon, XyzColors.Amazon },
            { CmyColors.CelestialBlue, XyzColors.CelestialBlue }
        };

    public static TheoryData<Cmy, Yxy> DataYxy =>
        new()
        {
            { CmyColors.Amazon, YxyColors.Amazon },
            { CmyColors.CelestialBlue, YxyColors.CelestialBlue }
        };

    public CmyConverterTest()
    {
        _converter_D65_2 = ConverterBuilder.Create(new ColorConverterOptions() { Illuminant = Illuminants.D65_2 })
                                     .ToColor<Cmy>()
                                     .Build();

        _converter_C_2 = ConverterBuilder.Create(new ColorConverterOptions() { Illuminant = Illuminants.C_2 })
                                     .ToColor<Cmy>()
                                     .Build();
    }

    [Theory]
    [MemberData(nameof(DataCmyk))]
    [MemberData(nameof(DataHsl))]
    [MemberData(nameof(DataHsv))]
    [MemberData(nameof(DataLab))]
    [MemberData(nameof(DataLch))]
    [MemberData(nameof(DataLuv))]
    [MemberData(nameof(DataRgb))]
    [MemberData(nameof(DataXyz))]
    [MemberData(nameof(DataYxy))]
    public void Convert_D65_2(Cmy output, IColor color)
    {
        var convertedColor = _converter_D65_2.ConvertFrom(color);
        var areClose = Cmy.AreClose(output, convertedColor);

        Assert.True(areClose);
    }

    [Theory]
    [MemberData(nameof(DataHunterLab))]
    public void Convert_C_2(Cmy output, IColor color)
    {
        var convertedColor = _converter_C_2.ConvertFrom(color);
        var areClose = Cmy.AreClose(convertedColor, output);

        Assert.True(areClose);
    }
}