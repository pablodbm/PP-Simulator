namespace Simulator;

public class Orc : Creature
{
    private int _rage;
    private int _huntCount;

    public int Rage
    {
        get => _rage;
        set => _rage = Validator.Limiter(value, 0, 10);
    }

    public Orc() { }

    public Orc(string name, int level = 1, int rage = 1)
        : base(name, level)
    {
        Rage = rage;
        _huntCount = 0;
    }

    public override void SayHi()
    {
        Console.WriteLine($"I am {Name}, a orc at level {Level} with rage {Rage}.");
    }

    public override string Info => $"{Name} [{Level}] [Rage: {Rage}]";

    public void Hunt()
    {
        _huntCount++;
        Console.WriteLine($"{Name} is hunting.");

        if (_huntCount % 2 == 0)
        {
            Rage++;
        }
    }
    public override int Power => 7 * Level + 3 * Rage;
}
