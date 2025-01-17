using Simulator;

namespace Simulator;

public class FlyingBird : Animals
{
    public override char Symbol => 'B';

    public FlyingBird(string name) : base(name) {
        Description = name;
    }

    public override void Go(Direction direction)
    {
        if (CurrentMap == null || Position == null)
            throw new InvalidOperationException("Bird is not assigned to a map.");

        var newPosition = CurrentMap.Next(CurrentMap.Next(Position.Value, direction), direction);

        CurrentMap.Move(this, Position.Value, newPosition);
        Position = newPosition;
        CurrentPosition = newPosition;
    }
}