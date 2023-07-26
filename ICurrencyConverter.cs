namespace Qiwi.MoneyToText;

public interface ICurrencyConverter
{
    string Convert(CurrencyCode currencyCode, decimal value);
}