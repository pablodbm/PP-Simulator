using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;

public class SimulationHistory
{
    private readonly Simulation _simulation;

    public int SizeX { get; }
    public int SizeY { get; }
    public List<SimulationTurnLog> TurnLogs { get; } = new();

    public SimulationHistory(Simulation simulation)
    {
        _simulation = simulation ??
            throw new ArgumentNullException(nameof(simulation));

        SizeX = _simulation.Map.SizeX;
        SizeY = _simulation.Map.SizeY;

        CaptureInitialState();
    }

    private void CaptureInitialState()
    {
        var initialSymbols = GenerateSymbolDictionary();
        TurnLogs.Add(new SimulationTurnLog
        {
            Mappable = "Initial State",
            Move = "None",
            Symbols = initialSymbols
        });
    }

    public void Run()
    {
        foreach (var move in _simulation.Moves)
        {
            var activeObject = _simulation.Turn();

            var symbols = GenerateSymbolDictionary();
            TurnLogs.Add(new SimulationTurnLog
            {
                Mappable = activeObject.ToString(),
                Move = move.ToString(),
                Symbols = symbols
            });
        }
    }

    private Dictionary<Point, char> GenerateSymbolDictionary()
    {
        var symbols = new Dictionary<Point, char>();

        for (int y = 0; y < SizeY; y++)
        {
            for (int x = 0; x < SizeX; x++)
            {
                var point = new Point(x, y);
                var objectsAtPoint = _simulation.Map.At(point);

                if (objectsAtPoint.Any())
                {
                    var symbol = objectsAtPoint.First().Symbol; // Wyświetlanie pierwszego obiektu
                    symbols[point] = symbol;
                }
            }
        }

        return symbols;
    }
}

