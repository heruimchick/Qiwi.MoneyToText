using Qiwi.MoneyToText.Converters;
namespace Qiwi.MoneyToText;

public class AmountConverter : IAmountConverter
{
    private readonly INumeralConverter _numeralConverter;
    private readonly ICurrencyConverter _currencyConverter;
    public AmountConverter (INumeralConverter numeralConverter, ICurrencyConverter currencyConverter)
    {
        _numeralConverter = numeralConverter;
        _currencyConverter = currencyConverter;
    }

    public string ConvertToText(Amount amount)
    {
        return $"{_numeralConverter.Convert(amount.Value)} {_currencyConverter.Convert(amount.Currency, amount.Value)}";
    }
}