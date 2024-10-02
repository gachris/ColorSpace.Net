using ColorSpace.Net.Tests.Converters.Colors;

namespace ColorSpace.Net.Tests.Colors;

public class CmyTest
{
    [Fact]
    public void ParseCmy()
    {
        var c = 0.807843137254902m;
        var m = 0.5098039215686274m;
        var y = 0.6235294117647059m;

        var color = Cmy.FromCmy(c, m, y);

        Assert.Equal(CmyColors.Amazon.C, color.C);
        Assert.Equal(CmyColors.Amazon.M, color.M);
        Assert.Equal(CmyColors.Amazon.Y, color.Y);
    }
}