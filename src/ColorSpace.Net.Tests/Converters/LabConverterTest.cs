using ColorSpace.Net.Tests.Converters.Colors;

namespace ColorSpace.Net.Tests.Converters;

public class LabConverterTest
{
    private readonly IColorConverter<Lab> _converter_C_2;
    private readonly IColorConverter<Lab> _converter_D65_2;

    public static TheoryData<Lab, Cmy> DataCmy =>
       new()
       {
            { LabColors.Amazon, CmyColors.Amazon },
            { LabColors.CelestialBlue, CmyColors.CelestialBlue }
       };

    public static TheoryData<Lab, Cmyk> DataCmyk =>
        new()
        {
            { LabColors.Amazon, CmykColors.Amazon },
            { LabColors.CelestialBlue, CmykColors.CelestialBlue }
        };

    public static TheoryData<Lab, Hsl> DataHsl =>
        new()
        {
            { LabColors.Amazon, HslColors.Amazon },
            { LabColors.CelestialBlue, HslColors.CelestialBlue }
        };

    public static TheoryData<Lab, Hsv> DataHsv =>
        new()
        {
            { LabColors.Amazon, HsvColors.Amazon },
            { LabColors.CelestialBlue, HsvColors.CelestialBlue }
        };

    public static TheoryData<Lab, HunterLab> DataHunterLab =>
        new()
        {
            { LabColors.Amazon, HunterLabColors.Amazon },
            { LabColors.CelestialBlue, HunterLabColors.CelestialBlue }
        };

    public static TheoryData<Lab, Lch> DataLch =>
        new()
        {
            { LabColors.Amazon, LchColors.Amazon },
            { LabColors.CelestialBlue, LchColors.CelestialBlue }
        };

    public static TheoryData<Lab, Luv> DataLuv =>
        new()
        {
            { LabColors.Amazon, LuvColors.Amazon },
            { LabColors.CelestialBlue, LuvColors.CelestialBlue }
        };

    public static TheoryData<Lab, Rgb> DataRgb =>
        new()
        {
            { LabColors.Amazon, RgbColors.Amazon },
            { LabColors.CelestialBlue, RgbColors.CelestialBlue }
        };

    public static TheoryData<Lab, Xyz> DataXyz =>
        new()
        {
            { LabColors.Amazon, XyzColors.Amazon },
            { LabColors.CelestialBlue, XyzColors.CelestialBlue }
        };

    public static TheoryData<Lab, Yxy> DataYxy =>
        new()
        {
            { LabColors.Amazon, YxyColors.Amazon },
            { LabColors.CelestialBlue, YxyColors.CelestialBlue }
        };

    public LabConverterTest()
    {
        _converter_C_2 = ConverterBuilder.Create(new ColorConverterOptions() { Illuminant = Illuminants.C_2 })
                                     .ToColor<Lab>()
                                     .Build();

        _converter_D65_2 = ConverterBuilder.Create(new ColorConverterOptions() { Illuminant = Illuminants.D65_2 })
                                     .ToColor<Lab>()
                                     .Build();
    }

    [Theory]
    [MemberData(nameof(DataCmy))]
    [MemberData(nameof(DataCmyk))]
    [MemberData(nameof(DataHsl))]
    [MemberData(nameof(DataHsv))]
    [MemberData(nameof(DataHunterLab))]
    [MemberData(nameof(DataLch))]
    [MemberData(nameof(DataLuv))]
    [MemberData(nameof(DataRgb))]
    [MemberData(nameof(DataXyz))]
    [MemberData(nameof(DataYxy))]
    public void Convert_D65_2(Lab output, IColor color)
    {
        var convertedColor = _converter_D65_2.ConvertFrom(color);
        var areClose = Lab.AreClose(output, convertedColor);

        Assert.True(areClose);
    }
}