using Qiwi.MoneyToText.Currencies;
namespace Qiwi.MoneyToText.Converters;

public interface ICurrencyConverter
{
    (string MainCurrencyPart, string MinorUnitPart) Convert(Currency currency, decimal value);
}