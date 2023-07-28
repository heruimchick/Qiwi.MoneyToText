using Qiwi.MoneyToText.Currencies;
namespace Qiwi.MoneyToText.Converters.English;

public class EnglishCurrencyConverter : ICurrencyConverter
{
    public (string MainCurrencyPart, string MinorUnitPart) Convert(Currency currency, decimal value)
    {
        int mainPart = (int) value;
        int fractionalPart = (int) ((value - mainPart) * 100);

        return (FormatCurrencyPart(mainPart, currency.CurrencyCode.ToString().ToLower()),
            FormatCurrencyPart(fractionalPart, currency.MinorUnit.ToString().ToLower()));
    }

    private static string FormatCurrencyPart(int value, string name)
    {
        return value == 1 ? $"{name}" : $"{name}s";
    }
}