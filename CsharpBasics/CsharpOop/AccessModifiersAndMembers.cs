namespace CsharpFundamentals.CsharpOop;

internal static class AccessModifiersAndMembers
{
    public static void Run()
    {
        Console.WriteLine("\n========== Access Modifiers and Members ==========");

        Catalog catalog = new("Main catalog")
        {
            [0] = "Laptop",
            [1] = "Monitor"
        };

        Console.WriteLine($"{catalog.Name}: {catalog[0]}, {catalog[1]}");
        Console.WriteLine($"Maximum items: {Catalog.MaximumItems}");
        Console.WriteLine($"Process started: {Catalog.ProcessStartedAtUtc:O}");

        DerivedVisibilityExample visibility = new();
        visibility.PrintVisibleMembers();
    }

    private sealed class Catalog
    {
        // const is compile-time constant, implicitly static, and limited to constant-compatible values.
        public const int MaximumItems = 100;

        // static readonly is assigned at declaration or in a static constructor at runtime.
        public static readonly DateTime ProcessStartedAtUtc = DateTime.UtcNow;

        // readonly instance fields can be assigned at declaration or in an instance constructor.
        private readonly string[] _items = new string[MaximumItems];

        public Catalog(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }

        // An indexer lets an object be accessed with array-like syntax.
        public string this[int index]
        {
            get => _items[index];
            set => _items[index] = string.IsNullOrWhiteSpace(value)
                ? throw new ArgumentException("Item name is required.", nameof(value))
                : value;
        }
    }

    private class VisibilityBase
    {
        public int PublicValue { get; } = 1;                 // Accessible everywhere.
        internal int InternalValue { get; } = 2;             // Accessible in the same assembly.
        protected int ProtectedValue { get; } = 3;           // Accessible in this type and derived types.
        protected internal int UnionValue { get; } = 4;      // Same assembly OR a derived type elsewhere.
        private protected int IntersectionValue { get; } = 5;// Same assembly AND a derived type.
        private int PrivateValue { get; } = 6;                // Accessible only inside this declaring type.

        protected int ReadPrivateValue() => PrivateValue;
    }

    private sealed class DerivedVisibilityExample : VisibilityBase
    {
        public void PrintVisibleMembers() => Console.WriteLine(
            $"Visible from derived type: {PublicValue}, {InternalValue}, {ProtectedValue}, " +
            $"{UnionValue}, {IntersectionValue}; private through base behavior: {ReadPrivateValue()}");
    }
}

// file limits this top-level type to this source file. It is useful for implementation details.
file sealed class FileScopedImplementationDetail
{
}
