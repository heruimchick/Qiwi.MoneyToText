using Qiwi.MoneyToText.Currencies;
namespace Qiwi.MoneyToText.Converters;

public interface ICurrencyConverter
{
    (string, string) Convert(Currency currency, decimal value);
}