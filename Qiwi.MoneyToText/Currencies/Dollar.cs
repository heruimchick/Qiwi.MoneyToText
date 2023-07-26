namespace Qiwi.MoneyToText.Currencies;

public class Dollar : Currency
{
    public Dollar() : base(CurrencyCode.Dollar, MinorUnit.Cent)
    {
    }
}