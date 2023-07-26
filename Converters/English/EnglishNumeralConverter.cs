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
            case < 20:
                return EnglishNumerals.Number[number];
            case < 100:
                return EnglishNumerals.Number[number / 10 * 10] + (number % 10 != 0 ? "-" + EnglishNumerals.Number[number % 10] : "");
            case < 1000:
                return EnglishNumerals.Number[number / 100] + " " + EnglishNumerals.Scale[100] + (number % 100 != 0 ? " and " + Convert(number % 100) : "");
            default:
            {
                var scaleValue = EnglishNumerals.Scale.Keys.Where(k => k <= number).Max();

                return Convert(number / scaleValue) + " " + EnglishNumerals.Scale[scaleValue] + (number % scaleValue != 0 ? " " + Convert(number % scaleValue) : "");
            }
        }
    }
}