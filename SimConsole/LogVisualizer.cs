using Simulator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimConsole;
public class LogVisualizer
{
    private readonly SimulationHistory _log;

    public LogVisualizer(SimulationHistory log)
    {
        _log = log ?? throw new ArgumentNullException(nameof(log));
    }

    public void Draw(int turnIndex)
    {
        if (turnIndex < 0 || turnIndex >= _log.TurnLogs.Count)
            throw new ArgumentOutOfRangeException(nameof(turnIndex), "Invalid turn index.");

        Console.Clear();
        var currentTurnLog = _log.TurnLogs[turnIndex];

        Console.Write(Box.TopLeft);
        for (int x = 0; x < _log.SizeX - 1; x++)
        {
            Console.Write($"{Box.Horizontal}{Box.TopMid}");
        }
        Console.WriteLine($"{Box.Horizontal}{Box.TopRight}");

        for (int y = 0; y < _log.SizeY; y++)
        {
            for (int x = 0; x < _log.SizeX; x++)
            {
                Point point = new Point(x, y);
                Console.Write(Box.Vertical);

                if (currentTurnLog.Symbols.TryGetValue(point, out var symbol))
                {
                    Console.Write(symbol);
                }
                else
                {
                    Console.Write(" ");
                }
            }
            Console.WriteLine(Box.Vertical);

            if (y < _log.SizeY - 1)
            {
                Console.Write(Box.MidLeft);
                for (int x = 0; x < _log.SizeX - 1; x++)
                {
                    Console.Write($"{Box.Horizontal}{Box.Cross}");
                }
                Console.WriteLine($"{Box.Horizontal}{Box.MidRight}");
            }
        }

        Console.Write(Box.BottomLeft);
        for (int x = 0; x < _log.SizeX - 1; x++)
        {
            Console.Write($"{Box.Horizontal}{Box.BottomMid}");
        }
        Console.WriteLine($"{Box.Horizontal}{Box.BottomRight}");

        Console.WriteLine($"\nTurn {turnIndex + 1}/{_log.TurnLogs.Count}");
        Console.WriteLine($"Moved: {currentTurnLog.Mappable}");
        Console.WriteLine($"Move: {currentTurnLog.Move}");
    }
}