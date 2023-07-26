namespace Qiwi.MoneyToText.Converters;

public interface INumeralConverter
{
    (string MainPart, string FractionalPart) Convert(decimal value);
}