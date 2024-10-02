using ColorSpace.Net.Tests.Converters.Colors;

namespace ColorSpace.Net.Tests.Colors;

public class HunterLabTest
{
    [Fact]
    public void ParseHunterLab()
    {
        var l = 40.20538180594155m;
        var a = -22.803267175110125m;
        var b = 8.055881563113791m;

        var color = HunterLab.FromHunterLab(l, a, b);

        Assert.Equal(HunterLabColors.Amazon.L, color.L);
        Assert.Equal(HunterLabColors.Amazon.A, color.A);
        Assert.Equal(HunterLabColors.Amazon.B, color.B);
    }
}