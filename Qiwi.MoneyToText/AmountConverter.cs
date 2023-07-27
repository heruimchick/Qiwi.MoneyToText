using Qiwi.MoneyToText.Converters;
namespace Qiwi.MoneyToText;

public class AmountConverter : IAmountConverter
{
    private readonly INumeralConverter _numeralConverter;
    private readonly ICurrencyConverter _currencyConverter;
    private const string Separator = "AND";
    public AmountConverter (INumeralConverter numeralConverter, ICurrencyConverter currencyConverter)
    {
        _numeralConverter = numeralConverter;
        _currencyConverter = currencyConverter;
    }

    public string ConvertToText(Amount amount)
    {
        if (amount.Value <= 0)
        {
            throw new ArgumentException("Amount must be positive");
        }
        
        (string mainNumeral, string fractionalNumeral) = _numeralConverter.Convert(amount.Value);
        (string mainCurrencyPart, string minorUnitPart) = _currencyConverter.Convert(amount.Currency, amount.Value);
        return $"{mainNumeral} {mainCurrencyPart.ToUpper()} {Separator} {fractionalNumeral} {minorUnitPart.ToUpper()}";
    }
}