using Simulator;

namespace Simulator;
public class Rabbit : Animals
{
    public override char Symbol => 'A';

    public Rabbit(string name) : base(name)
    {
        Description = name;
    }


    public override void Go(Direction direction)
    {
        if (CurrentMap == null || Position == null)
            throw new InvalidOperationException("Animal is not assigned to a map.");

        var newPosition = CurrentMap.Next(Position.Value, direction);

        CurrentMap.Move(this, Position.Value, newPosition);
        Position = newPosition;
        CurrentPosition = newPosition;
    }
}
