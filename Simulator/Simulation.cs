using Simulator.Maps;
using Simulator;
using System;
using System.Collections.Generic;

public class Simulation
{
    /// <summary>
    /// Simulation's map.
    /// </summary>
    public Map Map { get; }

    /// <summary>
    /// Creatures moving on the map.
    /// </summary>
    public List<IMappable> Creatures { get; }

    /// <summary>
    /// Starting positions of creatures.
    /// </summary>
    public List<Point> Positions { get; }

    /// <summary>
    /// Cyclic list of creatures moves.
    /// Bad moves are ignored - use DirectionParser.
    /// First move is for first creature, second for second and so on.
    /// When all creatures make moves, 
    /// next move is again for first creature and so on.
    /// </summary>
    public string Moves { get; }

    /// <summary>
    /// Has all moves been done?
    /// </summary>
    public bool Finished { get; private set; }

    private int _currentTurnIndex;

    /// <summary>
    /// Creature which will be moving current turn.
    /// </summary>
    public IMappable CurrentCreature => Creatures[_currentTurnIndex];

    /// <summary>
    /// Lowercase name of direction which will be used in current turn.
    /// </summary>
    public string CurrentMoveName => Moves[_currentTurnIndex].ToString().ToLower();

    /// <summary>
    /// Simulation constructor.
    /// Throw errors:
    /// if creatures' list is empty,
    /// if number of creatures differs from 
    /// number of starting positions.
    /// </summary>
    public Simulation(Map map, List<IMappable> creatures, List<Point> positions, string moves)
    {
        if (creatures == null || creatures.Count == 0)
            throw new ArgumentException("Creatures list cannot be empty.");

        if (positions == null || positions.Count != creatures.Count)
            throw new ArgumentException("Number of starting positions must match number of creatures.");

        if (string.IsNullOrEmpty(moves))
            throw new ArgumentException("Moves cannot be null or empty.");


        Map = map;
        Creatures = creatures;
        Positions = positions;
        Moves = moves;
        _currentTurnIndex = 0;
        Finished = false;

        for (int i = 0; i < Creatures.Count; i++)
        {
            Map.Add(Creatures[i], Positions[i]);
        }
    }

    /// <summary>
    /// Makes one move of current creature in current direction.
    /// Throw error if simulation is finished.
    /// </summary>
    public void Turn()
    {
        if (Finished)
            throw new InvalidOperationException("Simulation has finished. No further moves can be made.");
        var currentMove = Moves[_currentTurnIndex].ToString().ToLower();
        List<Direction> directions = DirectionParser.Parse(currentMove);

        if (directions.Count == 0)
        {
            throw new InvalidOperationException("No valid directions found for the current move.");
        }

        Direction direction = directions.First();
        var currentPosition = Creatures[_currentTurnIndex].CurrentPosition;
        var nextPosition = Map.Next(currentPosition, direction);
        Map.Move(Creatures[_currentTurnIndex], currentPosition, nextPosition);
        _currentTurnIndex++;

        if (_currentTurnIndex >= Creatures.Count)
        {
            _currentTurnIndex = 0;
        }

        if (_currentTurnIndex >= Moves.Length)
        {
            Finished = true;
        }
    }

}
