namespace CsharpFundamentals.ObjectOrientedProgramming;

internal static class ObjectMethodsAndEquality
{
    public static void Run()
    {
        Console.WriteLine("\n========== Object Methods and Equality ==========");

        CustomerId first = new(1001);
        CustomerId second = new(1001);

        Console.WriteLine(first);
        Console.WriteLine($"Value equality: {first.Equals(second)}");
        Console.WriteLine($"Operator equality: {first == second}");
        Console.WriteLine($"Reference equality: {ReferenceEquals(first, second)}");
        Console.WriteLine($"Runtime type: {first.GetType().FullName}");

        HashSet<CustomerId> ids = [first, second];
        Console.WriteLine($"HashSet count: {ids.Count}");
    }

    private sealed class CustomerId : IEquatable<CustomerId>
    {
        public CustomerId(int value)
        {
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(value);
            Value = value;
        }

        public int Value { get; }

        // Override ToString to provide a useful textual representation.
        public override string ToString() => $"Customer-{Value}";

        // IEquatable<T> avoids boxing and defines strongly typed equality.
        public bool Equals(CustomerId? other) => other is not null && Value == other.Value;

        public override bool Equals(object? obj) => obj is CustomerId other && Equals(other);

        // Equal objects must always return the same hash code.
        public override int GetHashCode() => Value.GetHashCode();

        public static bool operator ==(CustomerId? left, CustomerId? right) =>
            EqualityComparer<CustomerId>.Default.Equals(left, right);

        public static bool operator !=(CustomerId? left, CustomerId? right) => !(left == right);
    }
}

