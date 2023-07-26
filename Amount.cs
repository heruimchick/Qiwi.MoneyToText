namespace Qiwi.MoneyToText;

public struct Amount
{
    public CurrencyCode CurrencyCode { get; }
    public decimal Value { get; }

    public Amount (CurrencyCode currencyCode, decimal value)
    {
        CurrencyCode = currencyCode;
        Value = value;
    }
}