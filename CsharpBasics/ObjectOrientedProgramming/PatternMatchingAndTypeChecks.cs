namespace CsharpFundamentals.ObjectOrientedProgramming;

internal static class PatternMatchingAndTypeChecks
{
    public static void Run()
    {
        Console.WriteLine("\n========== Pattern Matching and Type Checks ==========");

        object value = new PremiumCustomer("Aya", 1200);

        // is tests the runtime type and introduces a safely typed local variable.
        if (value is PremiumCustomer customer)
        {
            Console.WriteLine($"Premium customer: {customer.Name}");
        }

        // as returns null instead of throwing when a reference conversion is not possible.
        CustomerBase? maybeCustomer = value as CustomerBase;
        Console.WriteLine($"Safe cast: {maybeCustomer?.Name}");

        Console.WriteLine(Describe(value));
        Console.WriteLine(GetShippingCost(new OrderSummary(250m, "EG", true)));

        int[] numbers = [1, 2, 3];
        Console.WriteLine(numbers is [1, 2, 3] ? "Exact list pattern" : "Different values");

        // Avoid direct casts unless failure truly indicates a programming error.
        // PremiumCustomer direct = (PremiumCustomer)value;
    }

    private abstract record CustomerBase(string Name);
    private sealed record RegularCustomer(string Name) : CustomerBase(Name);
    private sealed record PremiumCustomer(string Name, int Points) : CustomerBase(Name);
    private sealed record OrderSummary(decimal Total, string CountryCode, bool IsPriority);

    private static string Describe(object value) => value switch
    {
        PremiumCustomer { Points: >= 1_000 } premium => $"VIP: {premium.Name}",
        PremiumCustomer premium => $"Premium: {premium.Name}",
        RegularCustomer regular => $"Regular: {regular.Name}",
        null => "No customer",
        _ => $"Unknown type: {value.GetType().Name}"
    };

    private static decimal GetShippingCost(OrderSummary order) => order switch
    {
        { Total: >= 500m } => 0m,
        { CountryCode: "EG", IsPriority: true } => 60m,
        { CountryCode: "EG" } => 35m,
        _ => 120m
    };
}

