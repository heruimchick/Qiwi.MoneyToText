using System.Globalization;
using Qiwi.MoneyToText;
using Qiwi.MoneyToText.Converters.English;
using Qiwi.MoneyToText.Currencies;

while (true)
{
    Console.WriteLine("\nEnter amount (or enter 'q' to quit):");
    var input = Console.ReadLine();

    if (string.Equals(input, "q", StringComparison.OrdinalIgnoreCase))
    {
        break;
    }

    if (Validate(input ?? string.Empty))
    {
        var amount = decimal.Parse(input, NumberStyles.Any, CultureInfo.InvariantCulture);
        var amountConverter = new AmountConverter(new EnglishNumeralConverter(), new EnglishCurrencyConverter());
        var amountText = amountConverter.ConvertToText(new Amount(new Dollar(), amount));

        Console.WriteLine("Amount in words:");
        Console.WriteLine(amountText);
    }
}

bool Validate(string input)
{
    if (string.IsNullOrWhiteSpace(input))
    {
        Console.WriteLine("Amount is required");
        return false;
    }

    if (!decimal.TryParse(input, NumberStyles.Any, CultureInfo.InvariantCulture, out var amount))
    {
        Console.WriteLine("Amount is invalid");
        return false;
    }

    if (amount < 0)
    {
        Console.WriteLine("Amount must be positive");
        return false;
    }

    if (amount > 2_000_000_000m)
    {
        Console.WriteLine("Amount is too large");
        return false;
    }

    return true;
}