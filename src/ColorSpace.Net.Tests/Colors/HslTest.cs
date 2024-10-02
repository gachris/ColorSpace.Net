using ColorSpace.Net.Tests.Converters.Colors;

namespace ColorSpace.Net.Tests.Colors;

public class HslTest
{
    [Fact]
    public void ParseHsl()
    {
        var h = 157.10526282029676m;
        var s = 43.67816024181204m;
        var l = 34.117647260427475m;

        var color = Hsl.FromHsl(h, s, l);

        Assert.Equal(HslColors.Amazon.H, color.H);
        Assert.Equal(HslColors.Amazon.S, color.S);
        Assert.Equal(HslColors.Amazon.L, color.L);
    }
}