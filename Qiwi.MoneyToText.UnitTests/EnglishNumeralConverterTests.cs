using Qiwi.MoneyToText.Converters.English;
namespace Qiwi.MoneyToText.UnitTests;

[TestFixture]
public class EnglishNumeralConverterTests
{
    [TestCase(0, "", "")]
    [TestCase(9, "nine", "")]
    [TestCase(10, "ten", "")]
    [TestCase(19, "nineteen", "")]
    [TestCase(20, "twenty", "")]
    [TestCase(21, "twenty-one", "")]
    [TestCase(99, "ninety-nine", "")]
    [TestCase(100, "one hundred", "")]
    [TestCase(101, "one hundred and one", "")]
    [TestCase(110, "one hundred and ten", "")]
    [TestCase(120, "one hundred and twenty", "")]
    [TestCase(121, "one hundred and twenty-one", "")]
    [TestCase(999, "nine hundred and ninety-nine", "")]
    [TestCase(1000, "one thousand", "")]
    // [TestCase(1001, "one thousand and one", "")]
    // [TestCase(1010, "one thousand and ten", "")]
    // [TestCase(1020, "one thousand and twenty", "")]
    // [TestCase(1021, "one thousand and twenty-one", "")]
    // [TestCase(1100, "one thousand and one hundred", "")]
    [TestCase("1.1", "one", "ten")]
    [TestCase("1.01", "one", "one")]
    [TestCase("1.10", "one", "ten")]
    [TestCase("1.11", "one", "eleven")]
    [TestCase("1.99", "one", "ninety-nine")]
    [TestCase("10.1", "ten", "ten")]
    [TestCase("100.1", "one hundred", "ten")]
    [TestCase("1000.1", "one thousand", "ten")]
    [TestCase("10000.1", "ten thousand", "ten")]
    [TestCase("100000.1", "one hundred thousand", "ten")]
    [TestCase("1000000.1", "one million", "ten")]
    [TestCase("10000000.1", "ten million", "ten")]
    [TestCase("100000000.1", "one hundred million", "ten")]
    [TestCase("1000000000.1", "one billion", "ten")]
    [TestCase("123.45", "one hundred and twenty-three", "forty-five")]
    public void Convert_ShouldReturnCorrectText(decimal input, string expectedMainPart, string expectedFractionalPart)
    {
        // Act
        var result = new EnglishNumeralConverter().Convert(input);

        // Assert
        Assert.Multiple(() =>
        {
            result.MainPart.Should().Be(expectedMainPart);
            result.FractionalPart.Should().Be(expectedFractionalPart);
        });
    }
}