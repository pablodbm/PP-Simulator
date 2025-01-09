using Simulator.Maps;

namespace Simulator;

public abstract class Creature : IMappable
{
    private string _name = "Unknown";
    private int _level = 1;

    public Map? CurrentMap { get; set; }
    public Point? Position { get; private set; }
    public Point CurrentPosition { get; set; }

    public abstract int Power { get; }
    public string Name
    {
        get => _name;
        set
        {
            value = Validator.Shortener(value, 3, 25);
            _name = value;
        }
    }

    public int Level
    {
        get => _level;
        set => _level = Validator.Limiter(value, 1, 10);
    }

    public Creature(string name, int level = 1)
    {
        Name = name;
        Level = level;
    }

    public Creature() { }

    public abstract string Info { get; }

    public override string ToString()
    {
        return $"{GetType().Name.ToUpper()}: {Info}";
    }

    public abstract string Greeting();

    public void Upgrade()
    {
        if (Level < 10)
        {
            Level++;
        }
    }

    public void AssignToMap(Map map, Point initialPosition)
    {
        if (!map.Exist(initialPosition))
            throw new ArgumentException("Invalid position on the map.");

        CurrentMap = map;
        Position = initialPosition;
        map.Add(this, initialPosition);
    }

    public void Go(Direction direction)
    {
        if (CurrentMap == null || Position == null)
            throw new InvalidOperationException("Creature is not assigned to a map.");

        var newPosition = CurrentMap.Next(Position.Value, direction);

        CurrentMap.Move(this, Position.Value, newPosition);
        Position = newPosition;
    }
}
