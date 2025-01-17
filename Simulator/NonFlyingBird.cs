using Simulator;

namespace Simulator;
public class NonFlyingBird : Animals
{
    public override char Symbol => 'b';

    public NonFlyingBird(string name) : base(name) {
        Description = name;
    }

    public override void Go(Direction direction)
    {
        if (CurrentMap == null || Position == null)
            throw new InvalidOperationException("Bird is not assigned to a map.");

        var newPosition = CurrentMap.NextDiagonal(Position.Value, direction);

        CurrentMap.Move(this, Position.Value, newPosition);
        Position = newPosition;
        CurrentPosition = newPosition;
    }
}
