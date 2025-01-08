using Simulator;

namespace TestSimulator;
public class RectangleTests
{
    [Fact]
    public void Constructor_ValidCoordinates()
    {
        int x1 = 0, y1 = 0, x2 = 5, y2 = 5;
        var rect = new Rectangle(x1, y1, x2, y2);
        Assert.Equal(x1, rect.X1);
        Assert.Equal(y1, rect.Y1);
        Assert.Equal(x2, rect.X2);
        Assert.Equal(y2, rect.Y2);
    }

    [Fact]
    public void Constructor_InvalidCoordinates()
    {
        int x1 = 0, y1 = 0, x2 = 0, y2 = 5;
        Assert.Throws<ArgumentException>(() => new Rectangle(x1, y1, x2, y2));
    }

    [Fact]
    public void Constructor_PointConstructor()
    {
        var p1 = new Point(0, 0);
        var p2 = new Point(5, 5);
        var rect = new Rectangle(p1, p2);
        Assert.Equal(0, rect.X1);
        Assert.Equal(0, rect.Y1);
        Assert.Equal(5, rect.X2);
        Assert.Equal(5, rect.Y2);
    }

    [Theory]
    [InlineData(3, 3, true)]
    [InlineData(0, 0, true)]
    [InlineData(6, 6, false)]
    public void Contains(int x, int y, bool expected)
    {
        var rect = new Rectangle(0, 0, 5, 5);
        var point = new Point(x, y);
        var result = rect.Contains(point);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void ToString_Test()
    {
        var rect = new Rectangle(1, 2, 4, 6);
        var result = rect.ToString();
        Assert.Equal("(1, 2):(4, 6)", result);
    }
}


