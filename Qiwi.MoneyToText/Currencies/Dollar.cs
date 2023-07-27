namespace Qiwi.MoneyToText.Currencies;

public sealed class Dollar : Currency
{
    public Dollar() : base(CurrencyCode.Dollar, MinorUnit.Cent)
    {
    }
}