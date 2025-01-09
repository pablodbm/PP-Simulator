using Simulator.Maps;

namespace Simulator.Maps;

public interface IMappable
{

    string Name { get; set; }
    Point? Position { get; }
    Point CurrentPosition { get; set; }

    Map? CurrentMap { get; set; }

    void AssignToMap(Map map, Point initialPosition);
    void Go(Direction direction);
}
