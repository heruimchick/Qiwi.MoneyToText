namespace Qiwi.MoneyToText;

public interface IAmountConverter
{
    string ConvertToText(Amount amount);
}