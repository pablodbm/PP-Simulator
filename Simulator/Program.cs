using Simulator.Maps;

namespace Simulator;
internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Starting Simulator!\n");

        Lab5b();
    }

    public static void Lab5a()
    {
        try
        {
            
            Rectangle rect1 = new Rectangle(1, 2, 5, 6);
            Console.WriteLine(rect1);
            Point p1 = new Point(3, 4);
            Console.WriteLine($"Point {p1} inside rect1: {rect1.Contains(p1)}");

            
            Point p2 = new Point(0, 0);
            Point p3 = new Point(10, 10);
            Rectangle rect2 = new Rectangle(p2, p3);
            Console.WriteLine(rect2);
            Point p4 = new Point(5, 5);
            Console.WriteLine($"Point {p4} inside rect2: {rect2.Contains(p4)}");

            
            Rectangle rect3 = new Rectangle(1, 2, 1, 5);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Błąd: {ex.Message}");
        }
    }
    public static void Lab5b()
    {
        try
        {
            Console.WriteLine("Testowanie mapy o rozmiarze 10x10:");
            var map = new SmallSquareMap(10);
            Console.WriteLine(map);
            Console.WriteLine("Mapa stworzona pomyślnie!\n");

            // Tworzymy punkt początkowy (5, 5)
            var startPoint = new Point(5, 5);
            Console.WriteLine($"Punkt początkowy: {startPoint}");

            // Testowanie ruchów
            var nextPoint = map.Next(startPoint, Direction.Up);
            Console.WriteLine($"Po ruchu w górę: {nextPoint}");//(5, 6)

            nextPoint = map.Next(nextPoint, Direction.Right);
            Console.WriteLine($"Po ruchu w prawo: {nextPoint}");//(6, 5)

            nextPoint = map.Next(nextPoint, Direction.Down);
            Console.WriteLine($"Po ruchu w dół: {nextPoint}");//(5, 4)

            nextPoint = map.Next(nextPoint, Direction.Left);
            Console.WriteLine($"Po ruchu w lewo: {nextPoint}");//(4, 5)

            var outOfBoundsPoint = new Point(9, 9);
            var outOfBounds = map.Next(outOfBoundsPoint, Direction.Right);
            Console.WriteLine($"Po próbie ruchu poza mapę: {outOfBounds}");//Oczekiwany punkt (9, 9)

            var nextDiagonalPoint = map.NextDiagonal(startPoint, Direction.Up);
            Console.WriteLine($"Po ruchu w górę po skosie: {nextDiagonalPoint}");//Oczekiwany punkt (6, 6)

            nextDiagonalPoint = map.NextDiagonal(startPoint, Direction.Right);
            Console.WriteLine($"Po ruchu w prawo po skosie: {nextDiagonalPoint}");//Oczekiwany punkt (6, 4)

            nextDiagonalPoint = map.NextDiagonal(startPoint, Direction.Down);
            Console.WriteLine($"Po ruchu w dół po skosie: {nextDiagonalPoint}");//Oczekiwany punkt (4, 4)

            nextDiagonalPoint = map.NextDiagonal(startPoint, Direction.Left);
            Console.WriteLine($"Po ruchu w lewo po skosie: {nextDiagonalPoint}"); //Oczekiwany punkt (4, 6)

            Console.WriteLine($"Czy punkt {startPoint} znajduje się na mapie? {map.Exist(startPoint)}");  //true
            Console.WriteLine($"Czy punkt (10, 10) znajduje się na mapie? {map.Exist(new Point(10, 10))}");  //false

            try
            {
                var invalidMap = new SmallSquareMap(21);  //zły rozmiar
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"Błąd przy tworzeniu mapy: {ex.Message}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Wystąpił błąd: {ex.Message}");
        }
    }
}