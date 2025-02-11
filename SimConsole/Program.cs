﻿using SimConsole;
using Simulator;
using Simulator.Maps;

namespace SimConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                TorusMap map = new(8, 6);

                List<IMappable> mappables = new List<IMappable>
        {
            new Elf("Elandor"),
            new Orc("Gorbag"),
            new Rabbit("Rabbit1"),
            new Rabbit("Rabbit2"),
            new FlyingBird("Eagle1"),
            new FlyingBird("Eagle2"),
            new NonFlyingBird("Ostrich1"),
            new NonFlyingBird("Ostrich2")
        };

                List<Point> positions = new List<Point>
        {
            new Point(2, 2),
            new Point(3, 1),
            new Point(1, 1),
            new Point(4, 4),
            new Point(5, 0),
            new Point(0, 5),
            new Point(3, 3),
            new Point(6, 2)
        };

                for (int i = 0; i < mappables.Count; i++)
                {
                    mappables[i].AssignToMap(map, positions[i]);
                }

                string moves = "dlrludlrludlru";

                Simulation simulation = new(map, mappables, positions, moves);
                SimulationHistory history = new(simulation);

                history.Run();

                LogVisualizer logVisualizer = new(history);

                for (int i = 0; i < history.TurnLogs.Count; i++)
                {
                    logVisualizer.Draw(i);
                    Thread.Sleep(1000); 
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

    }
}
