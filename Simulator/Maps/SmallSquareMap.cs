namespace Simulator.Maps
{
    public class SmallSquareMap : SmallMap
    {
        public SmallSquareMap(int size)
            : base(size, size) // Przekazujemy zarówno szerokość, jak i wysokość
        {
        }

        public override Point Next(Point p, Direction d)
        {
            var nextPoint = d switch
            {
                Direction.Up => new Point(p.X, p.Y + 1),
                Direction.Right => new Point(p.X + 1, p.Y),
                Direction.Down => new Point(p.X, p.Y - 1),
                Direction.Left => new Point(p.X - 1, p.Y),
                _ => p
            };

            return Exist(nextPoint) ? nextPoint : p;
        }

        public override Point NextDiagonal(Point p, Direction d)
        {
            var nextPoint = d switch
            {
                Direction.Up => new Point(p.X + 1, p.Y + 1),
                Direction.Right => new Point(p.X + 1, p.Y - 1),
                Direction.Down => new Point(p.X - 1, p.Y - 1),
                Direction.Left => new Point(p.X - 1, p.Y + 1),
                _ => p
            };

            return Exist(nextPoint) ? nextPoint : p;
        }

        public void MoveCreature(Creature creature, Direction direction)
        {
            if (creature.CurrentMap != this)
                throw new InvalidOperationException("The creature is not on this map.");

            var currentPoint = creature.CurrentPosition;
            var nextPoint = Next(currentPoint, direction);

            if (!currentPoint.Equals(nextPoint))
            {
                Move(creature, currentPoint, nextPoint);
                creature.CurrentPosition = nextPoint;
            }
        }

        public override string ToString()
        {
            return $"SmallSquareMap with size {SizeX}x{SizeY}";
        }
    }
}
