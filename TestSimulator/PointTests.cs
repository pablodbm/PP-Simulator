using Simulator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSimulator;
public class PointTests
{
    [Theory]
    [InlineData(0, 0, Direction.Up, 0, -1)]
    [InlineData(1, 1, Direction.Right, 2, 1)]
    [InlineData(2, 2, Direction.Down, 2, 3)]
    [InlineData(3, 3, Direction.Left, 2, 3)]
    public void TestNext(int x, int y, Direction dir, int expectedX, int expectedY)
    {
        var point = new Point(x, y);
        var result = point.Next(dir);
        Assert.Equal(new Point(expectedX, expectedY), result);
    }

    [Theory]
    [InlineData(0, 0, Direction.Up, 1, -1)]
    [InlineData(1, 1, Direction.Right, 2, 0)]
    [InlineData(2, 2, Direction.Down, 1, 3)]
    [InlineData(3, 3, Direction.Left, 2, 2)]
    public void TestNextDiagonal(int x, int y, Direction dir, int expectedX, int expectedY)
    {
        var point = new Point(x, y);
        var result = point.NextDiagonal(dir);
        Assert.Equal(new Point(expectedX, expectedY), result);
    }
}

