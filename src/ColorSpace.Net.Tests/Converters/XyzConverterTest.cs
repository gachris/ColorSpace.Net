using ColorSpace.Net.Tests.Converters.Colors;

namespace ColorSpace.Net.Tests.Converters;

public class XyzConverterTest
{
    private readonly IColorConverter<Xyz> _converter_D65_2;
    private readonly IColorConverter<Xyz> _converter_C_2;

    public static TheoryData<Xyz, Cmy> DataCmy =>
       new()
       {
            { XyzColors.Amazon, CmyColors.Amazon },
            { XyzColors.CelestialBlue, CmyColors.CelestialBlue }
       };

    public static TheoryData<Xyz, Cmyk> DataCmyk =>
        new()
        {
            { XyzColors.Amazon, CmykColors.Amazon },
            { XyzColors.CelestialBlue, CmykColors.CelestialBlue }
        };

    public static TheoryData<Xyz, Hsl> DataHsl =>
        new()
        {
            { XyzColors.Amazon, HslColors.Amazon },
            { XyzColors.CelestialBlue, HslColors.CelestialBlue }
        };

    public static TheoryData<Xyz, Hsv> DataHsv =>
        new()
        {
            { XyzColors.Amazon, HsvColors.Amazon },
            { XyzColors.CelestialBlue, HsvColors.CelestialBlue }
        };

    public static TheoryData<Xyz, HunterLab> DataHunterLab =>
        new()
        {
            { XyzColors.Amazon, HunterLabColors.Amazon },
            { XyzColors.CelestialBlue, HunterLabColors.CelestialBlue }
        };

    public static TheoryData<Xyz, Lab> DataLab =>
        new()
        {
            { XyzColors.Amazon, LabColors.Amazon },
            { XyzColors.CelestialBlue, LabColors.CelestialBlue }
        };

    public static TheoryData<Xyz, Lch> DataLch =>
        new()
        {
            { XyzColors.Amazon, LchColors.Amazon },
            { XyzColors.CelestialBlue, LchColors.CelestialBlue }
        };

    public static TheoryData<Xyz, Luv> DataLuv =>
        new()
        {
            { XyzColors.Amazon, LuvColors.Amazon },
            { XyzColors.CelestialBlue, LuvColors.CelestialBlue }
        };

    public static TheoryData<Xyz, Rgb> DataRgb =>
        new()
        {
            { XyzColors.Amazon, RgbColors.Amazon },
            { XyzColors.CelestialBlue, RgbColors.CelestialBlue }
        };

    public static TheoryData<Xyz, Yxy> DataYxy =>
        new()
        {
            { XyzColors.Amazon, YxyColors.Amazon },
            { XyzColors.CelestialBlue, YxyColors.CelestialBlue }
        };

    public XyzConverterTest()
    {
        _converter_D65_2 = ConverterBuilder.Create(new ColorConverterOptions() { Illuminant = Illuminants.D65_2 })
            .ToColor<Xyz>()
            .Build();

        _converter_C_2 = ConverterBuilder.Create(new ColorConverterOptions() { Illuminant = Illuminants.C_2 })
            .ToColor<Xyz>()
            .Build();
    }

    [Theory]
    [MemberData(nameof(DataCmy))]
    [MemberData(nameof(DataCmyk))]
    [MemberData(nameof(DataHsl))]
    [MemberData(nameof(DataHsv))]
    [MemberData(nameof(DataLab))]
    [MemberData(nameof(DataLch))]
    [MemberData(nameof(DataLuv))]
    [MemberData(nameof(DataRgb))]
    [MemberData(nameof(DataYxy))]
    public void Convert_D65_2(Xyz output, IColor color)
    {
        var convertedColor = _converter_D65_2.ConvertFrom(color);
        var areClose = Xyz.AreClose(output, convertedColor);

        Assert.True(areClose);
    }

    [Theory]
    [MemberData(nameof(DataHunterLab))]
    public void Convert_C_2(Xyz output, IColor color)
    {
        var convertedColor = _converter_C_2.ConvertFrom(color);
        var areClose = Xyz.AreClose(convertedColor, output);

        Assert.True(areClose);
    }
}