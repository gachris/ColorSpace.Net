using ColorSpace.Net.Tests.Converters.Colors;

namespace ColorSpace.Net.Tests.Colors;

public class LabTest
{
    [Fact]
    public void ParseLab()
    {
        var l = 47.189868224870494m;
        var a = -30.856615797228564m;
        var b = 8.91988579563332m;

        var color = Lab.FromLab(l, a, b);

        Assert.Equal(LabColors.Amazon.L, color.L);
        Assert.Equal(LabColors.Amazon.A, color.A);
        Assert.Equal(LabColors.Amazon.B, color.B);
    }
}