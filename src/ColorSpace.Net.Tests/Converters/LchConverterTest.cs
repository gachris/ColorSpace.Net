using ColorSpace.Net.Tests.Converters.Colors;

namespace ColorSpace.Net.Tests.Converters;

public class LchConverterTest
{
    private readonly IColorConverter<Lch> _converter_D65_2;
    private readonly IColorConverter<Lch> _converter_C_2;

    public static TheoryData<Lch, Cmy> DataCmy =>
       new()
       {
            { LchColors.Amazon, CmyColors.Amazon },
            { LchColors.CelestialBlue, CmyColors.CelestialBlue }
       };

    public static TheoryData<Lch, Cmyk> DataCmyk =>
        new()
        {
            { LchColors.Amazon, CmykColors.Amazon },
            { LchColors.CelestialBlue, CmykColors.CelestialBlue }
        };

    public static TheoryData<Lch, Hsl> DataHsl =>
        new()
        {
            { LchColors.Amazon, HslColors.Amazon },
            { LchColors.CelestialBlue, HslColors.CelestialBlue }
        };

    public static TheoryData<Lch, Hsv> DataHsv =>
        new()
        {
            { LchColors.Amazon, HsvColors.Amazon },
            { LchColors.CelestialBlue, HsvColors.CelestialBlue }
        };

    public static TheoryData<Lch, HunterLab> DataHunterLab =>
        new()
        {
            { LchColors.Amazon, HunterLabColors.Amazon },
            { LchColors.CelestialBlue, HunterLabColors.CelestialBlue }
        };

    public static TheoryData<Lch, Lab> DataLab =>
        new()
        {
            { LchColors.Amazon, LabColors.Amazon },
            { LchColors.CelestialBlue, LabColors.CelestialBlue }
        };

    public static TheoryData<Lch, Luv> DataLuv =>
        new()
        {
            { LchColors.Amazon, LuvColors.Amazon },
            { LchColors.CelestialBlue, LuvColors.CelestialBlue }
        };

    public static TheoryData<Lch, Rgb> DataRgb =>
        new()
        {
            { LchColors.Amazon, RgbColors.Amazon },
            { LchColors.CelestialBlue, RgbColors.CelestialBlue }
        };

    public static TheoryData<Lch, Xyz> DataXyz =>
        new()
        {
            { LchColors.Amazon, XyzColors.Amazon },
            { LchColors.CelestialBlue, XyzColors.CelestialBlue }
        };

    public static TheoryData<Lch, Yxy> DataYxy =>
        new()
        {
            { LchColors.Amazon, YxyColors.Amazon },
            { LchColors.CelestialBlue, YxyColors.CelestialBlue }
        };

    public LchConverterTest()
    {
        _converter_D65_2 = ConverterBuilder.Create(new ColorConverterOptions() { Illuminant = Illuminants.D65_2 })
                                     .ToColor<Lch>()
                                     .Build();

        _converter_C_2 = ConverterBuilder.Create(new ColorConverterOptions() { Illuminant = Illuminants.C_2 })
            .ToColor<Lch>()
            .Build();
    }

    [Theory]
    [MemberData(nameof(DataCmy))]
    [MemberData(nameof(DataCmyk))]
    [MemberData(nameof(DataHsl))]
    [MemberData(nameof(DataHsv))]
    [MemberData(nameof(DataHunterLab))]
    [MemberData(nameof(DataLab))]
    [MemberData(nameof(DataLuv))]
    [MemberData(nameof(DataRgb))]
    [MemberData(nameof(DataXyz))]
    [MemberData(nameof(DataYxy))]
    public void Convert_D65_2(Lch output, IColor color)
    {
        var convertedColor = _converter_D65_2.ConvertFrom(color);
        var areClose = Lch.AreClose(output, convertedColor);

        Assert.True(areClose);
    }
}