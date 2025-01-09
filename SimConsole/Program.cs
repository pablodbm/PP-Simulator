using SimConsole;
using Simulator.Maps;
using Simulator;

namespace SimConsole;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            SmallSquareMap map = new SmallSquareMap(5);

            List<Creature> creatures = new List<Creature>
                {
                    new Orc { Name = "Gorbag" },
                    new Elf { Name = "Elandor" }
                };

            List<Point> positions = new List<Point>
                {
                    new Point(1, 1),
                    new Point(2, 1)
                };

            string moves = "rrdd";

            Simulation simulation = new Simulation(map, creatures, positions, moves);

            MapVisualizer mapVisualizer = new MapVisualizer(map);

            mapVisualizer.Draw();

            foreach (char move in moves)
            {
                Console.WriteLine("Press Enter to make the next move...");
                while (Console.ReadKey(true).Key != ConsoleKey.Enter) { }

                simulation.Turn();
                mapVisualizer.Draw();
            }
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}