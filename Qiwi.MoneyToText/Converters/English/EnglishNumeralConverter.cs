using System.Text;
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
        var sb = new StringBuilder();
        switch (number)
        {
            case 0:
                return string.Empty;
            case < 20:
                return EnglishNumerals.Simple[number];
            case < 100:
                sb.Append(EnglishNumerals.Tens[RoundDownToNearestTen(number)]); 
                AppendRemainderTextIfNeeded(sb, number, "-", 10);
                return sb.ToString();
            case < 1000:
                sb.Append(EnglishNumerals.Simple[number / 100]);
                sb.Append(' ');
                sb.Append(EnglishNumerals.Scales[100]); 
                AppendRemainderTextIfNeeded(sb, number, " and ", 100);
                return sb.ToString();
        }
        foreach (int scale in EnglishNumerals.Scales.Keys.OrderByDescending(x => x))
        {
            if (number < scale) continue;
            sb.Append(Convert(number / scale));
            sb.Append(' ');
            sb.Append(EnglishNumerals.Scales[scale]);
            AppendRemainderTextIfNeeded(sb, number, ", ", scale);
            return sb.ToString();
        }

        throw new ArgumentException("Number is too large to convert to words");
    }
    
    private static int RoundDownToNearestTen(int number) => number / 10 * 10;
    private void AppendRemainderTextIfNeeded(StringBuilder sb, int number, string separator, int divider)
    {
        if (number % divider == 0)
            return;
        
        sb.Append(separator);
        sb.Append(Convert(number % divider));
    }
}