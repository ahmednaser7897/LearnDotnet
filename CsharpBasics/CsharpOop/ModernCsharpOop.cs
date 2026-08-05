namespace CsharpFundamentals.CsharpOop;

internal static class ModernCsharpOop
{
    public static void Run()
    {
        Console.WriteLine("\n========== Modern C# OOP Syntax ==========");

        ModernPerson person = new("  Farah  ") { Nickname = "Fifi" };
        Console.WriteLine($"Primary constructor and field-backed property: {person.Name}");

        ModernPerson? optionalPerson = person;
        optionalPerson?.Nickname = "Fofa"; // C# 14 null-conditional assignment.
        Console.WriteLine($"Null-conditional assignment: {person.Nickname}");

        int[] values = [1, 2, 3, 4]; // Collection expression.
        Console.WriteLine($"Extension property: {values.IsEmpty}");
        Console.WriteLine($"Extension method: {values.SecondOrDefault()}");
        Console.WriteLine($"Unbound generic nameof: {nameof(Dictionary<,>)}");

        // These examples require the .NET 10 SDK with C# 14 enabled.
    }

    private sealed class ModernPerson(string name)
    {
        public string Name
        {
            get;
            set => field = ValidateName(value);
        } = ValidateName(name);

        public string? Nickname { get; set; }

        private static string ValidateName(string value) =>
            string.IsNullOrWhiteSpace(value)
                ? throw new ArgumentException("Name is required.", nameof(value))
                : value.Trim();
    }
}

internal static class EnumerableOopExtensions
{
    // C# 14 extension blocks can declare extension properties and extension methods together.
    extension<T>(IEnumerable<T> source)
    {
        public bool IsEmpty => !source.Any();
        public T? SecondOrDefault() => source.Skip(1).FirstOrDefault();
    }
}
