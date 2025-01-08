using Simulator.Maps;
using Simulator;

namespace TestSimulator;

public class SmallSquareMapTests
{
    [Fact]
    public void TestSize()
    {
        int size = 10;
        var map = new SmallSquareMap(size);
        Assert.Equal(size, map.Size);
    }

    [Theory]
    [InlineData(4)]
    [InlineData(21)]
    public void TestInvalidSize(int size)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new SmallSquareMap(size));
    }

    [Theory]
    [InlineData(0, 0, 5, true)]
    [InlineData(4, 4, 5, true)]
    [InlineData(5, 5, 5, false)]
    [InlineData(-1, 0, 5, false)]
    [InlineData(0, -1, 5, false)]
    public void TestExist(int x, int y, int size, bool expected)
    {
        var map = new SmallSquareMap(size);
        var point = new Point(x, y);
        Assert.Equal(expected, map.Exist(point));
    }

    [Theory]
    [InlineData(0, 0, Direction.Up, 0, 1)]
    [InlineData(4, 4, Direction.Right, 4, 4)]
    [InlineData(0, 0, Direction.Left, 0, 0)]
    [InlineData(3, 3, Direction.Down, 3, 2)]
    [InlineData(4, 3, Direction.Right, 4, 3)]
    public void TestNext(int x, int y, Direction dir, int expectedX, int expectedY)
    {
        var map = new SmallSquareMap(5);
        var point = new Point(x, y);
        Assert.Equal(new Point(expectedX, expectedY), map.Next(point, dir));
    }

    [Theory]
    [InlineData(0, 0, Direction.Up, 1, 1)]
    [InlineData(4, 4, Direction.Up, 4, 4)]
    [InlineData(0, 0, Direction.Left, 0, 0)]
    [InlineData(3, 3, Direction.Right, 4, 2)]
    [InlineData(4, 3, Direction.Down, 3, 2)]
    public void TestNextDiag(int x, int y, Direction dir, int expectedX, int expectedY)
    {
        var map = new SmallSquareMap(5);
        var point = new Point(x, y);
        Assert.Equal(new Point(expectedX, expectedY), map.NextDiagonal(point, dir));
    }

    [Fact]
    public void TestExistNeg()
    {
        var map = new SmallSquareMap(10);
        var point = new Point(-1, -1);
        Assert.False(map.Exist(point));
    }

    [Fact]
    public void TestNextOutOfBounds()
    {
        var map = new SmallSquareMap(5);
        var point = new Point(0, 0);
        Assert.Equal(point, map.Next(point, Direction.Left));
    }

    [Fact]
    public void TestNextDiagOutOfBounds()
    {
        var map = new SmallSquareMap(5);
        var point = new Point(4, 4);
        Assert.Equal(point, map.NextDiagonal(point, Direction.Up));
    }
}
