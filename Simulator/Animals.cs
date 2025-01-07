namespace Simulator;

public class Animals
{
    private string _description = "Unknown";
    private bool _descriptionInitialized = false;

    public string Description
    {
        get => _description;
        init
        {
            _description = Validator.Shortener(value, 1, 15);
            _descriptionInitialized = true;
        }
    }

    public uint Size { get; set; } = 3;

    public virtual string Info => $"{Description} <{Size}>";
    public override string ToString()
    {
        return $"{GetType().Name.ToUpper()}: {Info}";
    }
}
