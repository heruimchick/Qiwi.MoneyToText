using Qiwi.MoneyToText.Converters.English;
using Qiwi.MoneyToText.Currencies;
namespace Qiwi.MoneyToText.UnitTests;

[TestFixture]
public class AmountConverterTests
{
    [TestCase(1357256.32, "one million, three hundred and fifty-seven thousand, two hundred and fifty-six DOLLARS AND thirty-two CENTS")]
    [TestCase(0, "zero DOLLARS AND zero CENTS")]
    [TestCase(1, "one DOLLAR AND zero CENTS")]
    [TestCase(1.1, "one DOLLAR AND ten CENTS")]
    [TestCase(1.01, "one DOLLAR AND one CENT")]
    [TestCase(123.45, "one hundred and twenty-three DOLLARS AND forty-five CENTS")]
    [TestCase(1234.56, "one thousand, two hundred and thirty-four DOLLARS AND fifty-six CENTS")]
    [TestCase(12345.67, "twelve thousand, three hundred and forty-five DOLLARS AND sixty-seven CENTS")]
    [TestCase(123456.78, "one hundred and twenty-three thousand, four hundred and fifty-six DOLLARS AND seventy-eight CENTS")]
    [TestCase(1234567.89, "one million, two hundred and thirty-four thousand, five hundred and sixty-seven DOLLARS AND eighty-nine CENTS")]
    [TestCase(12345678.90, "twelve million, three hundred and forty-five thousand, six hundred and seventy-eight DOLLARS AND ninety CENTS")]
    [TestCase(123456789.01, "one hundred and twenty-three million, four hundred and fifty-six thousand, seven hundred and eighty-nine DOLLARS AND one CENT")]
    [TestCase(1234567890.12, "one billion, two hundred and thirty-four million, five hundred and sixty-seven thousand, eight hundred and ninety DOLLARS AND twelve CENTS")]
    public void ConvertToText_WhenCurrencyIsDollarAndLanguageIsEnglish_ShouldReturnsCorrectSpelling(decimal amountValue, string expected)
    {
        // Arrange
        var amountConverter = new AmountConverter(new EnglishNumeralConverter(), new EnglishCurrencyConverter());
        var amount = new Amount(new Dollar(), amountValue); 
            
        // Act
        var actual = amountConverter.ConvertToText(amount);

        // Assert
        actual.Should().Be(expected);
    }
}