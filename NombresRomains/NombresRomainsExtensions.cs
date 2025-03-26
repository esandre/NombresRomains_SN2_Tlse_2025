namespace NombresRomains;

public static class NombresRomainsExtensions
{
    private static readonly IDictionary<int, string> KnownSymbols = new Dictionary<int, string>()
    {
        { 1, "I" },
        { 5, "V" },
        { 10, "X" },
    };

    public static string ToRomanNumbers(this int number)
    {
        {
            if (KnownSymbols.TryGetValue(number, out var symbol))
                return symbol;
        }

        {
            if (KnownSymbols.TryGetValue(number + 1, out var symbol))
                return ToRomanNumbers(1) + symbol;
        }

        switch (number)
        {
            case <= 3:
                return new string('I', number);
            case <= 8:
                return ToRomanNumbers(5) + ToRomanNumbers(number - 5);
            case <= 13:
                return ToRomanNumbers(10) + ToRomanNumbers(number - 10);
            case 14:
                return "XIV";
            case 15:
                return "XV";
            case 16:
                return "XVI";
            case 17:
                return "XVII";
            case 18:
                return "XVIII";
            case 19:
                return "XIX";
            case 20:
                return "XX";
            case 21:
                return "XXI";
            case 22:
                return "XXII";
            default:
                return "XXIII";
        }
    }
}