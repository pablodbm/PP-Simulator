namespace Simulator;

public class Creature
{
    private string _name = "Unknown";
    private int _level = 1;
    private bool _nameInitialized = false;

    public string Name
    {
        get => _name;
        set
        {
            if (_nameInitialized)
            {
                throw new InvalidOperationException("Cannot set name more then once");
            }

            value = value?.Trim() ?? string.Empty;

            if (value.Length < 3)
            {
                value = value.PadRight(3, '#');
            }

            if (value.Length > 25)
            {
                value = value.Substring(0, 25).TrimEnd();
            }

            if (value.Length < 3)
            {
                value = value.PadRight(3, '#');
            }

            if (char.IsLower(value[0]))
            {
                value = char.ToUpper(value[0]) + value.Substring(1);
            }

            _name = value;
            _nameInitialized = true;
        }
    }

    public int Level
    {
        get => _level;
        set
        {
            if (value < 1)
            {
                value = 1;
            }
            else if (value > 10)
            {
                value = 10;
            }

            _level = value;
        }
    }

    public Creature(string name, int level = 1)
    {
        Name = name; 
        Level = level;
    }

    public Creature() { }

    public string Info => $"{Name} [Level: {Level}]";

    public void SayHi()
    {
        Console.WriteLine($"Hi! I am {Name} and I am at level {Level}.");
    }

    public void Upgrade()
    {
        if(Level < 10)
        {
            Level++;
        }
    }
}
