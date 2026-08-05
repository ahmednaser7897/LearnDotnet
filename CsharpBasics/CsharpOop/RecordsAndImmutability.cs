namespace CsharpFundamentals.CsharpOop;

internal static class RecordsAndImmutability
{
    public static void Run()
    {
        Console.WriteLine("\n========== Records and Immutability ==========");

        Address address = new("Cairo", "Nasr City");
        Address sameAddress = new("Cairo", "Nasr City");
        Address movedAddress = address with { District = "New Cairo" };

        Console.WriteLine($"Value equality: {address == sameAddress}");
        Console.WriteLine($"Original: {address}");
        Console.WriteLine($"Copy: {movedAddress}");

        var (city, district) = movedAddress;
        Console.WriteLine($"Deconstructed: {city}, {district}");

        Coordinate coordinate = new(10, 20);
        Coordinate shifted = coordinate with { X = 15 };
        Console.WriteLine($"Record struct: {shifted}");

        Result result = new Success("Saved");
        Console.WriteLine(Describe(result));
    }

    // A record class is a reference type with compiler-generated value equality and copy support.
    private sealed record Address(string City, string District);

    // A readonly record struct is a value type suited to small immutable values.
    private readonly record struct Coordinate(int X, int Y);

    // Record inheritance is useful for small closed-by-convention result hierarchies.
    private abstract record Result;
    private sealed record Success(string Message) : Result;
    private sealed record Failure(string Error) : Result;

    private static string Describe(Result result) => result switch
    {
        Success(var message) => $"Success: {message}",
        Failure(var error) => $"Failure: {error}",
        _ => throw new ArgumentOutOfRangeException(nameof(result))
    };
}

