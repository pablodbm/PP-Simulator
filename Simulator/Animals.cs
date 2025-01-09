using Simulator.Maps;

namespace Simulator;

public class Animals : IMappable
{
    private string _description = "Unknown";
    private bool _descriptionInitialized = false;
    private string name;

    public Animals(string name)
    {
        this.name = name;
    }

    public string Description
    {
        get => _description;
        init
        {
            _description = Validator.Shortener(value, 1, 15);
            _descriptionInitialized = true;
        }
    }

    public uint Size { get; set; } = 3;

    public string Name => $"{Description} ({Size})";

    public virtual char Symbol => 'A'; 

    public Point? Position { get; set; }
    public Point CurrentPosition { get; set; }
    public Map? CurrentMap { get; set; }

    public virtual string Info => $"{Description} <{Size}>";

    string IMappable.Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public override string ToString()
    {
        return $"{GetType().Name.ToUpper()}: {Info}";
    }
    public void AssignToMap(Map map, Point initialPosition)
    {
        if (!map.Exist(initialPosition))
            throw new ArgumentException("Invalid position on the map.");

        CurrentMap = map;
        Position = initialPosition;
        CurrentPosition = initialPosition;
        map.Add(this, initialPosition);
    }

    public virtual void Go(Direction direction)
    {
        if (CurrentMap == null || Position == null)
            throw new InvalidOperationException("Animal is not assigned to a map.");

        var newPosition = CurrentMap.Next(Position.Value, direction);

        CurrentMap.Move(this, Position.Value, newPosition);
        Position = newPosition;
        CurrentPosition = newPosition;
    }
}
