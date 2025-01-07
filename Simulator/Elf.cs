namespace Simulator;

public class Elf : Creature
{
    private int _agility;
    private int _singCount;

    public int Agility
    {
        get => _agility;
        private set => _agility = value < 0 ? 0 : value > 10 ? 10 : value;
    }

    public Elf() { }

    public Elf(string name, int level = 1, int agility = 1)
        : base(name, level)
    {
        Agility = agility;
        _singCount = 0;
    }

    public override void SayHi()
    {
        Console.WriteLine($"I am {Name}, an elf at level {Level} with agility {Agility}.");
    }

    public void Sing()
    {
        _singCount++;
        Console.WriteLine($"{Name} is singing.");

        if (_singCount % 3 == 0)
        {
            Agility++;
        }
    }
    public override int Power => 8 * Level + 2 * Agility;
}
