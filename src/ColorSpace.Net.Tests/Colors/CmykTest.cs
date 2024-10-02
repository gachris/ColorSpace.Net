using ColorSpace.Net.Tests.Converters.Colors;

namespace ColorSpace.Net.Tests.Colors;

public class CmykTest
{
    [Fact]
    public void ParseCmyk()
    {
        var c = 0.6080000000000001m;
        var m = 0m;
        var y = 0.23200000000000007m;
        var k = 0.5098039215686274m;

        var color = Cmyk.FromCmyk(c, m, y, k);

        Assert.Equal(CmykColors.Amazon.C, color.C);
        Assert.Equal(CmykColors.Amazon.M, color.M);
        Assert.Equal(CmykColors.Amazon.Y, color.Y);
        Assert.Equal(CmykColors.Amazon.K, color.K);
    }
}