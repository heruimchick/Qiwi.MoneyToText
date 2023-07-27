using Qiwi.MoneyToText.Converters.English;
namespace Qiwi.MoneyToText.UnitTests;

[TestFixture]
public class EnglishNumeralConverterTests
{
    [TestCase("1357256.32", "one million, three hundred and fifty-seven thousand, two hundred and fifty-six", "thirty-two")]
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
    [TestCase(1001, "one thousand, one", "")]
    [TestCase(1010, "one thousand, ten", "")]
    [TestCase(1020, "one thousand, twenty", "")]
    [TestCase(1021, "one thousand, twenty-one", "")]
    [TestCase(1100, "one thousand, one hundred", "")]
    [TestCase("1.1", "one", "ten")]
    [TestCase("1.01", "one", "one")]
    [TestCase("1.10", "one", "ten")]
    [TestCase("1.11", "one", "eleven")]
    [TestCase("1.99", "one", "ninety-nine")]
    [TestCase("10.1", "ten", "ten")]
    [TestCase("100", "one hundred", "")]
    [TestCase("1000", "one thousand", "")]
    [TestCase("10000", "ten thousand", "")]
    [TestCase("100000", "one hundred thousand", "")]
    [TestCase("1000000", "one million", "")]
    [TestCase("10000000", "ten million", "")]
    [TestCase("100000000", "one hundred million", "")]
    [TestCase("1000000000", "one billion", "")]
    [TestCase("100.1", "one hundred", "ten")]
    [TestCase("1000.1", "one thousand", "ten")]
    [TestCase("10000.1", "ten thousand", "ten")]
    [TestCase("100000.1", "one hundred thousand", "ten")]
    [TestCase("1000000.1", "one million", "ten")]
    [TestCase("10000000.1", "ten million", "ten")]
    [TestCase("100000000.1", "one hundred million", "ten")]
    [TestCase("1000000000.1", "one billion", "ten")]
    [TestCase("1234567890.12", "one billion, two hundred and thirty-four million, five hundred and sixty-seven thousand, eight hundred and ninety", "twelve")]
    [TestCase("123456789.09", "one hundred and twenty-three million, four hundred and fifty-six thousand, seven hundred and eighty-nine", "nine")]
    [TestCase("12345678.90", "twelve million, three hundred and forty-five thousand, six hundred and seventy-eight", "ninety")]
    [TestCase("1234567.89", "one million, two hundred and thirty-four thousand, five hundred and sixty-seven", "eighty-nine")]
    [TestCase("123456.78", "one hundred and twenty-three thousand, four hundred and fifty-six", "seventy-eight")]
    [TestCase("12345.67", "twelve thousand, three hundred and forty-five", "sixty-seven")]
    [TestCase("1234.56", "one thousand, two hundred and thirty-four", "fifty-six")]
    [TestCase("123.45", "one hundred and twenty-three", "forty-five")]
    [TestCase("12.34", "twelve", "thirty-four")]
    [TestCase("1.23", "one", "twenty-three")]
    [TestCase("2000000000", "two billion", "")]
    [TestCase("2000000000.00", "two billion", "")]
    [TestCase("2000000000.01", "two billion", "one")]
    [TestCase("2000000000.10", "two billion", "ten")]
    [TestCase("2123123123.11", "two billion, one hundred and twenty-three million, one hundred and twenty-three thousand, one hundred and twenty-three", "eleven")] 
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