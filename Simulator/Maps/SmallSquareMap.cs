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

            if (!Exist(nextPoint))
                return p;

            return nextPoint;
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

            if (!Exist(nextPoint))
                return p;

            return nextPoint;
        }

        public override string ToString()
        {
            return $"SmallSquareMap with size {SizeX}x{SizeY}";
        }
    }
}
