namespace Simulator;

public static class DirectionParser
{
    public static Direction[] Parse(string directionsString)
    {
        var directionsList = new List<Direction>();

        foreach (var c in directionsString.ToUpper())
        {
            Direction? direction = c switch
            {
                'U' => Direction.Up,
                'R' => Direction.Right,
                'D' => Direction.Down,
                'L' => Direction.Left,
                _ => null
            };

            if (direction.HasValue)
            {
                directionsList.Add(direction.Value);
            }
        }

        return directionsList.ToArray();
    }
}
