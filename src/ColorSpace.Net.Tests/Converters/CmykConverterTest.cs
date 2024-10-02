using ColorSpace.Net.Tests.Converters.Colors;

namespace ColorSpace.Net.Tests.Converters;

public class CmykConverterTest
{
    private readonly IColorConverter<Cmyk> _converter_D65_2;
    private readonly IColorConverter<Cmyk> _converter_C_2;

    public static TheoryData<Cmyk, Cmy> DataCmy =>
        new()
        {
            { CmykColors.Amazon, CmyColors.Amazon },
            { CmykColors.CelestialBlue, CmyColors.CelestialBlue }
        };

    public static TheoryData<Cmyk, Hsl> DataHsl =>
        new()
        {
            { CmykColors.Amazon, HslColors.Amazon },
            { CmykColors.CelestialBlue, HslColors.CelestialBlue }
        };

    public static TheoryData<Cmyk, Hsv> DataHsv =>
        new()
        {
            { CmykColors.Amazon, HsvColors.Amazon },
            { CmykColors.CelestialBlue, HsvColors.CelestialBlue }
        };

    public static TheoryData<Cmyk, HunterLab> DataHunterLab =>
        new()
        {
            { CmykColors.Amazon, HunterLabColors.Amazon },
            { CmykColors.CelestialBlue, HunterLabColors.CelestialBlue }
        };

    public static TheoryData<Cmyk, Lab> DataLab =>
        new()
        {
            { CmykColors.Amazon, LabColors.Amazon },
            { CmykColors.CelestialBlue, LabColors.CelestialBlue }
        };

    public static TheoryData<Cmyk, Lch> DataLch =>
        new()
        {
            { CmykColors.Amazon, LchColors.Amazon },
            { CmykColors.CelestialBlue, LchColors.CelestialBlue }
        };

    public static TheoryData<Cmyk, Luv> DataLuv =>
        new()
        {
            { CmykColors.Amazon, LuvColors.Amazon },
            { CmykColors.CelestialBlue, LuvColors.CelestialBlue }
        };

    public static TheoryData<Cmyk, Rgb> DataRgb =>
        new()
        {
            { CmykColors.Amazon, RgbColors.Amazon },
            { CmykColors.CelestialBlue, RgbColors.CelestialBlue }
        };

    public static TheoryData<Cmyk, Xyz> DataXyz =>
        new()
        {
            { CmykColors.Amazon, XyzColors.Amazon },
            { CmykColors.CelestialBlue, XyzColors.CelestialBlue }
        };

    public static TheoryData<Cmyk, Yxy> DataYxy =>
        new()
        {
            { CmykColors.Amazon, YxyColors.Amazon },
            { CmykColors.CelestialBlue, YxyColors.CelestialBlue }
        };

    public CmykConverterTest()
    {
        _converter_D65_2 = ConverterBuilder.Create(new ColorConverterOptions() { Illuminant = Illuminants.D65_2 })
                                 .ToColor<Cmyk>()
                                 .Build();

        _converter_C_2 = ConverterBuilder.Create(new ColorConverterOptions() { Illuminant = Illuminants.C_2 })
                                 .ToColor<Cmyk>()
                                 .Build();
    }

    [Theory]
    [MemberData(nameof(DataCmy))]
    [MemberData(nameof(DataHsl))]
    [MemberData(nameof(DataHsv))]
    [MemberData(nameof(DataLab))]
    [MemberData(nameof(DataLch))]
    [MemberData(nameof(DataLuv))]
    [MemberData(nameof(DataRgb))]
    [MemberData(nameof(DataXyz))]
    [MemberData(nameof(DataYxy))]
    public void Convert_D65_2(Cmyk output, IColor color)
    {
        var convertedColor = _converter_D65_2.ConvertFrom(color);
        var areClose = Cmyk.AreClose(output, convertedColor);

        Assert.True(areClose);
    }

    [Theory]
    [MemberData(nameof(DataHunterLab))]
    public void Convert_C_2(Cmyk output, IColor color)
    {
        var convertedColor = _converter_C_2.ConvertFrom(color);
        var areClose = Cmyk.AreClose(convertedColor, output);

        Assert.True(areClose);
    }
}