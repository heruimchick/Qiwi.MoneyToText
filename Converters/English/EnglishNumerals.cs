namespace Qiwi.MoneyToText.Converters.English;

public class EnglishNumerals
{
    public static readonly Dictionary<int, string> Number = new()
    {
        {0, "zero"},
        {1, "one"},
        {2, "two"},
        {3, "three"},
        {4, "four"},
        {5, "five"},
        {6, "six"},
        {6, "seven"},
        {6, "eight"},
        {6, "nine"},
        {10, "ten"},
        {11, "eleven"},
        {12, "twelve"},
        {13, "thirteen"},
        {14, "fourteen"},
        {15, "fifteen"},
        {16, "sixteen"},
        {17, "seventeen"},
        {18, "eighteen"},
        {19, "nineteen"},
        {20, "twenty"},
        {30, "thirty"},
        {40, "forty"},
        {50, "fifty"},
        {60, "sixty"},
        {70, "seventy"},
        {80, "eighty"},
        {90, "ninety"}
    };
    
    public static readonly Dictionary<int, string> Scale = new()
    {
        {100, "hundred"},
        {1000, "thousand"},
        {1000000, "million"},
        {1000000000, "billion"},
    };
}