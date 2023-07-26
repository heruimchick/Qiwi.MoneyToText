namespace Qiwi.MoneyToText.Currencies;

public abstract class Currency
{
    public CurrencyCode CurrencyCode { get; }
    public MinorUnit MinorUnit { get; }

    protected Currency(CurrencyCode currencyCode, MinorUnit minorUnit)
    {
        CurrencyCode = currencyCode;
        MinorUnit = minorUnit;
    }
}