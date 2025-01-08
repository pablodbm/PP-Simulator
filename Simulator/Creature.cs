namespace Simulator;

public abstract class Creature
{
    private string _name = "Unknown";
    private int _level = 1;
    private bool _nameInitialized = false;

    public abstract int Power { get; }
    public string Name
    {
        get => _name;
        set
        {

            value = Validator.Shortener(value, 3, 25);

            _name = value;
            _nameInitialized = true;
        }
    }

    public int Level
    {
        get => _level;
        set
        {
            _level = Validator.Limiter(value, 1 ,10);
        }
    }

    public Creature(string name, int level = 1)
    {
        Name = name; 
        Level = level;
    }

    public Creature() { }

    public abstract string Info { get; }

    public override string ToString()
    {
        return $"{GetType().Name.ToUpper()}: {Info}";
    }

    public abstract string Greeting();

    public void Upgrade()
    {
        if(Level < 10)
        {
            Level++;
        }
    }

    public string Go(Direction direction)
    {
        return $"{direction.ToString().ToLower()}";
    }

    public void Go(Direction[] directions)
    {
        foreach (var direction in directions)
        {
            Go(direction);
        }
    }
    public void Go(string directionsString)
    {
        var directions = DirectionParser.Parse(directionsString);
        Go(directions);
    }
}
