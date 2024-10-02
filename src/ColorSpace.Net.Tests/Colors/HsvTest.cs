using ColorSpace.Net.Tests.Converters.Colors;

namespace ColorSpace.Net.Tests.Colors;

public class HsvTest
{
    [Fact]
    public void ParseHsv()
    {
        var h = 157.10526282029676m;
        var s = 0.608m;
        var v = 0.49019607843137253m;

        var color = Hsv.FromHsv(h, s, v);

        Assert.Equal(HsvColors.Amazon.H, color.H);
        Assert.Equal(HsvColors.Amazon.S, color.S);
        Assert.Equal(HsvColors.Amazon.V, color.V);
    }
}