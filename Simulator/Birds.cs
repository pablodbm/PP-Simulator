namespace Simulator;

public class Birds : Animals
{
    public Birds(string name) : base(name)
    {
    }

    public bool CanFly { get; set; } = true;

    public override string Info
    {
        get
        {
            string flyStatus = CanFly ? "fly+" : "fly-";
            return $"{Description} ({flyStatus}) <{Size}>";
        }
    }
}
