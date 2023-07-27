using Qiwi.MoneyToText.Converters.English;
using Qiwi.MoneyToText.Currencies;
namespace Qiwi.MoneyToText.UnitTests;

[TestFixture]
public class EnglishCurrencyConverterTests
{
    [TestCase(1, "dollar", "cents")]
    [TestCase(2, "dollars", "cents")]
    [TestCase(1, "dollar", "cents")]
    [TestCase(1.01, "dollar", "cent")]
    [TestCase(1.02, "dollar", "cents")]
    [TestCase(1.1, "dollar", "cents")]
    [TestCase(2.11, "dollars", "cents")]
    public void Convert_WhenCurrencyIsDollar_ShouldReturnCorrectCurrencySpelling(decimal value, string expectedCurrency, string expectedMinorUnit)
    {
        // Act
        var (actualMainCurrencyPart, actualMinorUnitPart) = new EnglishCurrencyConverter().Convert(new Dollar(), value);

        // Assert
        Assert.Multiple(() =>
        {
            actualMainCurrencyPart.Should().Be(expectedCurrency);
            actualMinorUnitPart.Should().Be(expectedMinorUnit);
        });
    }
}