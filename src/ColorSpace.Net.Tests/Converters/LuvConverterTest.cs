using ColorSpace.Net.Tests.Converters.Colors;

namespace ColorSpace.Net.Tests.Converters;

public class LuvConverterTest
{
    private readonly IColorConverter<Luv> _converter_D65_2;
    private readonly IColorConverter<Luv> _converter_C_2;

    public static TheoryData<Luv, Cmy> DataCmy =>
       new()
       {
            { LuvColors.Amazon, CmyColors.Amazon },
            { LuvColors.CelestialBlue, CmyColors.CelestialBlue }
       };

    public static TheoryData<Luv, Cmyk> DataCmyk =>
        new()
        {
            { LuvColors.Amazon, CmykColors.Amazon },
            { LuvColors.CelestialBlue, CmykColors.CelestialBlue }
        };

    public static TheoryData<Luv, Hsl> DataHsl =>
        new()
        {
            { LuvColors.Amazon, HslColors.Amazon },
            { LuvColors.CelestialBlue, HslColors.CelestialBlue }
        };

    public static TheoryData<Luv, Hsv> DataHsv =>
        new()
        {
            { LuvColors.Amazon, HsvColors.Amazon },
            { LuvColors.CelestialBlue, HsvColors.CelestialBlue }
        };

    public static TheoryData<Luv, HunterLab> DataHunterLab =>
        new()
        {
            { LuvColors.Amazon, HunterLabColors.Amazon },
            { LuvColors.CelestialBlue, HunterLabColors.CelestialBlue }
        };

    public static TheoryData<Luv, Lab> DataLab =>
        new()
        {
            { LuvColors.Amazon, LabColors.Amazon },
            { LuvColors.CelestialBlue, LabColors.CelestialBlue }
        };

    public static TheoryData<Luv, Lch> DataLch =>
        new()
        {
            { LuvColors.Amazon, LchColors.Amazon },
            { LuvColors.CelestialBlue, LchColors.CelestialBlue }
        };

    public static TheoryData<Luv, Rgb> DataRgb =>
        new()
        {
            { LuvColors.Amazon, RgbColors.Amazon },
            { LuvColors.CelestialBlue, RgbColors.CelestialBlue }
        };

    public static TheoryData<Luv, Xyz> DataXyz =>
        new()
        {
            { LuvColors.Amazon, XyzColors.Amazon },
            { LuvColors.CelestialBlue, XyzColors.CelestialBlue }
        };

    public static TheoryData<Luv, Yxy> DataYxy =>
        new()
        {
            { LuvColors.Amazon, YxyColors.Amazon },
            { LuvColors.CelestialBlue, YxyColors.CelestialBlue }
        };

    public LuvConverterTest()
    {
        _converter_D65_2 = ConverterBuilder.Create(new ColorConverterOptions() { Illuminant = Illuminants.D65_2 })
                                     .ToColor<Luv>()
                                     .Build();

        _converter_C_2 = ConverterBuilder.Create(new ColorConverterOptions() { Illuminant = Illuminants.C_2 })
            .ToColor<Luv>()
            .Build();
    }

    [Theory]
    [MemberData(nameof(DataCmy))]
    [MemberData(nameof(DataCmyk))]
    [MemberData(nameof(DataHsl))]
    [MemberData(nameof(DataHsv))]
    [MemberData(nameof(DataHunterLab))]
    [MemberData(nameof(DataLab))]
    [MemberData(nameof(DataLch))]
    [MemberData(nameof(DataRgb))]
    [MemberData(nameof(DataXyz))]
    [MemberData(nameof(DataYxy))]
    public void Convert_D65_2(Luv output, IColor color)
    {
        var convertedColor = _converter_D65_2.ConvertFrom(color);
        var areClose = Luv.AreClose(output, convertedColor);

        Assert.True(areClose);
    }
}