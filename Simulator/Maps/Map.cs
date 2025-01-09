
namespace Simulator.Maps;

/// <summary>
/// Map of points.
/// </summary>
public abstract class Map
{
    public int SizeX { get; }
    public int SizeY { get; }

    private readonly Dictionary<Point, List<IMappable>> _creaturePositions;

    protected Map(int sizeX, int sizeY)
    {
        if (sizeX < 5 || sizeY < 5)
            throw new ArgumentOutOfRangeException("Map dimensions must be at least 5x5.");

        SizeX = sizeX;
        SizeY = sizeY;
        _creaturePositions = new Dictionary<Point, List<IMappable>>();
    }

    /// <summary>
    /// Check if give point belongs to the map.
    /// </summary>
    /// <param name="p">Point to check.</param>
    public bool Exist(Point p)
    {
        return p.X >= 0 && p.X < SizeX && p.Y >= 0 && p.Y < SizeY;
    }

    public virtual void Add(IMappable creature, Point point)
    {
        if (!Exist(point))
            throw new ArgumentOutOfRangeException("Point is outside the map boundaries.");

        if (!_creaturePositions.ContainsKey(point))
        {
            _creaturePositions[point] = new List<IMappable>();
        }

        _creaturePositions[point].Add(creature);
        creature.CurrentMap = this;
        creature.CurrentPosition = point;
    }

    public virtual void Remove(IMappable creature, Point point)
    {
        if (_creaturePositions.ContainsKey(point))
        {
            _creaturePositions[point].Remove(creature);
            if (_creaturePositions[point].Count == 0)
            {
                _creaturePositions.Remove(point);
            }
        }
    }

    public virtual void Move(IMappable creature, Point from, Point to)
    {
        if (!Exist(to))
            throw new ArgumentOutOfRangeException("Destination point is outside the map boundaries.");

        Remove(creature, from);
        Add(creature, to);
    }

    public virtual List<IMappable> At(Point point)
    {
        return _creaturePositions.TryGetValue(point, out var creatures) ? creatures : new List<IMappable>();
    }

    public virtual List<IMappable> At(int x, int y)
    {
        return At(new Point(x, y));
    }

    /// <summary>
    /// Next position to the point in a given direction.
    /// </summary>
    /// <param name="p">Starting point.</param>
    /// <param name="d">Direction.</param>
    /// <returns>Next point.</returns>
    public abstract Point Next(Point p, Direction d);

    /// <summary>
    /// Next diagonal position to the point in a given direction 
    /// rotated 45 degrees clockwise.
    /// </summary>
    /// <param name="p">Starting point.</param>
    /// <param name="d">Direction.</param>
    /// <returns>Next point.</returns>
    public abstract Point NextDiagonal(Point p, Direction d);
}
