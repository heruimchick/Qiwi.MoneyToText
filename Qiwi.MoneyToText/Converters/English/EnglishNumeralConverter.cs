namespace Qiwi.MoneyToText.Converters.English;

public class EnglishNumeralConverter : INumeralConverter
{
    public (string MainPart, string FractionalPart) Convert(decimal value)
    {
        int mainPart = (int) value;
        int fractionalPart = (int) ((value - mainPart) * 100);

        return (Convert(mainPart), Convert(fractionalPart));
    }

    private string Convert(int number)
    {
        switch (number)
        {
            case 0:
                return string.Empty;
            case < 20:
                return EnglishNumerals.Simple[number];
            case < 100:
                return EnglishNumerals.Tens[RoundDownToNearestTen(number)] 
                       + GetRemainderTextIfNeeded(number, "-", 10);
            case < 1000:
                return EnglishNumerals.Simple[number / 100] 
                       + " " + EnglishNumerals.Scales[100] 
                       + GetRemainderTextIfNeeded(number, " and ", 100);
        }
        foreach (int scale in EnglishNumerals.Scales.Keys.OrderByDescending(x => x))
        {
            if (number < scale) continue;
            return Convert(number / scale) 
                   + " " + EnglishNumerals.Scales[scale]
                   + GetRemainderTextIfNeeded(number, ", ", scale);
        }

        throw new ArgumentException("Number is too large to convert to words");
    }
    
    private static int RoundDownToNearestTen(int number) => number / 10 * 10;
    private string GetRemainderTextIfNeeded(int number, string separator, int divider)
    {
        return number % divider != 0 
            ? separator + Convert(number % divider) 
            : string.Empty;
    }
}