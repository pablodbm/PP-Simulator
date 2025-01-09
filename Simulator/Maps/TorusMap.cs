namespace Simulator.Maps
{

    public class TorusMap : Map
    {
        public TorusMap(int sizeX, int sizeY) : base(sizeX, sizeY) { }

        public override Point Next(Point p, Direction d)
        {
            int newX = p.X;
            int newY = p.Y;

            switch (d)
            {
                case Direction.Up:
                    newY = (newY - 1 + SizeY) % SizeY;
                    break;
                case Direction.Down:
                    newY = (newY + 1) % SizeY;
                    break;
                case Direction.Right:
                    newX = (newX + 1) % SizeX;
                    break;
                case Direction.Left:
                    newX = (newX - 1 + SizeX) % SizeX;
                    break;
            }

            return new Point(newX, newY);
        }

        public override Point NextDiagonal(Point p, Direction d)
        {
            int newX = p.X;
            int newY = p.Y;

            switch (d)
            {
                case Direction.Up:
                    newX = (newX - 1 + SizeX) % SizeX;
                    newY = (newY - 1 + SizeY) % SizeY;
                    break;
                case Direction.Down:
                    newX = (newX + 1) % SizeX;
                    newY = (newY + 1) % SizeY;
                    break;
                case Direction.Right:
                    newX = (newX + 1) % SizeX;
                    newY = (newY - 1 + SizeY) % SizeY;
                    break;
                case Direction.Left:
                    newX = (newX - 1 + SizeX) % SizeX;
                    newY = (newY + 1) % SizeY;
                    break;
            }

            return new Point(newX, newY);
        }
    }
}
