using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps;
public class SmallTorusMap : Map
{
    public int Size { get; }

    public SmallTorusMap(int size)
    {
        if (size < 5 || size > 20)
            throw new ArgumentOutOfRangeException(nameof(size), "Size must be between 5 and 20.");
        Size = size;
    }

    public override bool Exist(Point p)
    {
        return p.X >= 0 && p.X < Size && p.Y >= 0 && p.Y < Size;
    }

    public override Point Next(Point p, Direction d)
    {
        int newX = p.X, newY = p.Y;

        switch (d)
        {
            case Direction.Up: newY = (p.Y + 1) % Size; break;
            case Direction.Down: newY = (p.Y - 1 + Size) % Size; break;
            case Direction.Left: newX = (p.X - 1 + Size) % Size; break;
            case Direction.Right: newX = (p.X + 1) % Size; break;
        }

        return new Point(newX, newY);
    }

    public override Point NextDiagonal(Point p, Direction d)
    {
        int newX = p.X, newY = p.Y;

        switch (d)
        {
            case Direction.Up: newX = (p.X + 1) % Size; newY = (p.Y + 1) % Size; break;
            case Direction.Down: newX = (p.X - 1 + Size) % Size; newY = (p.Y - 1 + Size) % Size; break;
            case Direction.Left: newX = (p.X - 1 + Size) % Size; newY = (p.Y + 1) % Size; break;
            case Direction.Right: newX = (p.X + 1) % Size; newY = (p.Y - 1 + Size) % Size; break;
        }

        return new Point(newX, newY);
    }
}
