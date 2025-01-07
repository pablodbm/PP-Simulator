namespace Simulator;
public static class Validator
{
    public static int Limiter(int value, int min, int max)
    {
        if (value < min)
        {
            return min;
        }
        else if (value > max)
        {
            return max;
        }
        return value;
    }

    public static string Shortener(string value, int min, int max, char placeholder = '#')
    {
        value = value.Trim();

        if (value.Length < min)
        {
            value = value.PadRight(min, placeholder);
        }
        if (value.Length > max)
        {
            value = value.Substring(0, max);
        }

        if (value.Length < min)
        {
            value = value.PadRight(min, placeholder);
        }

        return value;
    }
}
