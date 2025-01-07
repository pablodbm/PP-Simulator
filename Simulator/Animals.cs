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
            if (_descriptionInitialized)
            {
                throw new InvalidOperationException("Cannot set description more then once");
            }

            value = value?.Trim() ?? string.Empty;

            if (value.Length < 3)
            {
                value = value.PadRight(3, '#');
            }

            if (value.Length > 15)
            {
                value = value.Substring(0, 15).TrimEnd();
            }

            if (value.Length < 3)
            {
                value = value.PadRight(3, '#');
            }

            if (char.IsLower(value[0]))
            {
                value = char.ToUpper(value[0]) + value.Substring(1);
            }

            _description = value;
            _descriptionInitialized = true;
        }
    }

    public uint Size { get; set; } = 3;

    public string Info => $"{Description} <{Size}>";
}
