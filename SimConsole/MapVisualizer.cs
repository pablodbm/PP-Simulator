using System;
using System.Collections.Generic;
using System.Linq;
using Simulator;
using Simulator.Maps;

namespace SimConsole;

public class MapVisualizer
{
    private readonly Map _map;

    public MapVisualizer(Map map)
    {
        _map = map;
    }

    public void Draw()
    {
        Console.Clear();

        Console.Write(Box.TopLeft);
        for (int x = 0; x < _map.SizeX - 1; x++)
        {
            Console.Write($"{Box.Horizontal}{Box.TopMid}");
        }
        Console.WriteLine($"{Box.Horizontal}{Box.TopRight}");

        for (int y = 0; y < _map.SizeY; y++)
        {
            for (int x = 0; x < _map.SizeX; x++)
            {
                Point point = new Point(x, y);
                var creaturesAtPoint = _map.At(point);

                Console.Write(Box.Vertical);

                if (creaturesAtPoint.Count > 1)
                {
                    Console.Write("X");
                }
                else if (creaturesAtPoint.Count == 1)
                {
                    var creature = creaturesAtPoint.First();
                    Console.Write(creature is Orc ? "O" : "E");
                }
                else
                {
                    Console.Write(" ");
                }
            }
            Console.WriteLine(Box.Vertical);

            if (y < _map.SizeY - 1)
            {
                Console.Write(Box.MidLeft);
                for (int x = 0; x < _map.SizeX - 1; x++)
                {
                    Console.Write($"{Box.Horizontal}{Box.Cross}");
                }
                Console.WriteLine($"{Box.Horizontal}{Box.MidRight}");
            }
        }

        Console.Write(Box.BottomLeft);
        for (int x = 0; x < _map.SizeX - 1; x++)
        {
            Console.Write($"{Box.Horizontal}{Box.BottomMid}");
        }
        Console.WriteLine($"{Box.Horizontal}{Box.BottomRight}");
    }
}
