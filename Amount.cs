using Qiwi.MoneyToText.Currencies;
namespace Qiwi.MoneyToText;

public struct Amount
{
    public Currency Currency { get; }
    public decimal Value { get; }

    public Amount (Currency currency, decimal value)
    {
        Currency = currency;
        Value = value;
    }
}