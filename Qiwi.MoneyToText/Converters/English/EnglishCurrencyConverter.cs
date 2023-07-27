using Qiwi.MoneyToText.Currencies;
namespace Qiwi.MoneyToText.Converters.English;

public class EnglishCurrencyConverter : ICurrencyConverter
{
    public (string MainCurrencyPart, string MinorUnitPart) Convert(Currency currency, decimal value)
    {
        int dollars = (int) value;
        int cents = (int) ((value - dollars) * 100);

        return (FormatCurrencyPart(dollars, currency.CurrencyCode.ToString().ToLower()),
            FormatCurrencyPart(cents, currency.MinorUnit.ToString().ToLower()));
    }

    private static string FormatCurrencyPart(int value, string name)
    {
        return value == 1 ? $"{name}" : $"{name}s";
    }
}