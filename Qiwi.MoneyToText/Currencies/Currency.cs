namespace Qiwi.MoneyToText.Currencies;

public class Currency
{
    public CurrencyCode CurrencyCode { get; }
    public MinorUnit MinorUnit { get; }

    public Currency(CurrencyCode currencyCode, MinorUnit minorUnit)
    {
        CurrencyCode = currencyCode;
        MinorUnit = minorUnit;
    }
}