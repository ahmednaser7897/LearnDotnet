namespace CsharpFundamentals.ObjectOrientedProgramming;

internal static class ObjectMethodsAndEquality
{
    public static void Run()
    {
        Console.WriteLine(
            "\n========== Object Methods and Equality ==========");


        // ================================================================
        // CREATE OBJECTS
        // ================================================================

        CustomerId first = new(1001);
        CustomerId second = new(1001);
        CustomerId third = new(2002);


        // ================================================================
        // ToString()
        // ================================================================

        // ToString() returns a string representation of the object.
        Console.WriteLine($"First: {first}");
        Console.WriteLine($"Second: {second}");


        // ================================================================
        // VALUE EQUALITY
        // ================================================================

        // Equals() checks whether two objects have the same value
        // according to the class's equality implementation.
        Console.WriteLine(
            $"Value equality: {first.Equals(second)}");


        Console.WriteLine(
            $"Different values: {first.Equals(third)}");


        // ================================================================
        // == OPERATOR
        // ================================================================

        // We overloaded == in CustomerId.
        //
        // So == compares the CustomerId values,
        // not just the object references.
        Console.WriteLine(
            $"Operator equality: {first == second}");

        Console.WriteLine(
            $"Operator inequality: {first != third}");


        // ================================================================
        // REFERENCE EQUALITY
        // ================================================================

        // ReferenceEquals() checks whether two variables
        // refer to the EXACT SAME OBJECT in memory.
        //
        // first and second contain the same value,
        // but they are two different objects.
        Console.WriteLine(
            $"Reference equality: {ReferenceEquals(first, second)}");


        // Both variables point to the same object.
        CustomerId sameReference = first;

        Console.WriteLine(
            $"Same reference: {ReferenceEquals(first, sameReference)}");


        // ================================================================
        // GETTYPE()
        // ================================================================

        // GetType() returns the actual runtime type of the object.
        Console.WriteLine(
            $"Runtime type: {first.GetType().FullName}");


        // ================================================================
        // OBJECT.EQUALS
        // ================================================================

        // object.Equals() is a static method.
        //
        // It safely compares two objects, including null values.
        Console.WriteLine(
            $"object.Equals: {object.Equals(first, second)}");


        // ================================================================
        // EQUALITYCOMPARER<T>
        // ================================================================

        // EqualityComparer<T>.Default uses the equality implementation
        // provided by the type.
        //
        // Since CustomerId implements IEquatable<CustomerId>,
        // the comparer uses that implementation.
        bool areEqual =
            EqualityComparer<CustomerId>.Default.Equals(first, second);

        Console.WriteLine(
            $"EqualityComparer equality: {areEqual}");


        // ================================================================
        // GETHASHCODE()
        // ================================================================

        // Equal objects must return the same hash code.
        Console.WriteLine(
            $"First hash code: {first.GetHashCode()}");

        Console.WriteLine(
            $"Second hash code: {second.GetHashCode()}");


        // ================================================================
        // HASHSET
        // ================================================================

        // HashSet does not allow duplicate values according to
        // equality and hash code.
        //
        // first and second have the same Value,
        // so HashSet considers them equal.
        HashSet<CustomerId> ids =
            new() { first, second, third };

        Console.WriteLine(
            $"HashSet count: {ids.Count}");


        // ================================================================
        // ICOMPARABLE<T>
        // ================================================================

        Console.WriteLine(
            "\n========== IComparable<T> ==========");

        CustomerId small = new(10);
        CustomerId large = new(20);

        // CompareTo() defines the default ordering of CustomerId.
        int compareResult = small.CompareTo(large);

        Console.WriteLine(
            $"10.CompareTo(20): {compareResult}");


        // CompareTo() returns:
        //
        // Negative -> this object comes BEFORE the other object.
        // Zero     -> both objects are equal for ordering.
        // Positive -> this object comes AFTER the other object.


        if (compareResult < 0)
        {
            Console.WriteLine("10 comes before 20");
        }
        else if (compareResult == 0)
        {
            Console.WriteLine("10 and 20 are equal");
        }
        else
        {
            Console.WriteLine("10 comes after 20");
        }


        // ================================================================
        // SORTING USING ICOMPARABLE<T>
        // ================================================================

        Console.WriteLine(
            "\n========== Sorting ==========");

        List<CustomerId> customers =
            new()
            {
                new CustomerId(50),
                new CustomerId(10),
                new CustomerId(40),
                new CustomerId(20),
                new CustomerId(30)
            };

        Console.WriteLine("Before sorting:");

        foreach (CustomerId customer in customers)
        {
            Console.WriteLine(customer);
        }


        // Sort() uses CustomerId.CompareTo()
        // because CustomerId implements IComparable<CustomerId>.
        customers.Sort();


        Console.WriteLine("After sorting:");

        foreach (CustomerId customer in customers)
        {
            Console.WriteLine(customer);
        }


        // ================================================================
        // ICOMPARER<T>
        // ================================================================

        Console.WriteLine(
            "\n========== IComparer<T> ==========");


        // IComparable<T> defines the DEFAULT comparison.
        //
        // IComparer<T> allows us to provide a DIFFERENT comparison.
        customers.Sort(new CustomerIdDescendingComparer());


        Console.WriteLine("Descending order:");

        foreach (CustomerId customer in customers)
        {
            Console.WriteLine(customer);
        }
    }


    // ====================================================================
    // CUSTOMER ID
    // ====================================================================

    private sealed class CustomerId :
        IEquatable<CustomerId>,
        IComparable<CustomerId>
    {
        public CustomerId(int value)
        {
            // CustomerId must be greater than zero.
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(value);

            Value = value;
        }


        // ================================================================
        // PROPERTY
        // ================================================================

        public int Value { get; }


        // ================================================================
        // ToString()
        // ================================================================

        // ToString() provides a useful textual representation.
        public override string ToString()
        {
            return $"Customer-{Value}";
        }


        // ================================================================
        // IEquatable<T>
        // ================================================================

        // IEquatable<T> provides strongly typed equality.
        //
        // It avoids the need to compare through object.
        //
        // Two CustomerId objects are equal when their Value is equal.
        public bool Equals(CustomerId? other)
        {
            return other is not null &&
                   Value == other.Value;
        }


        // ================================================================
        // Equals(object)
        // ================================================================

        // Override object.Equals() so normal object equality
        // follows the same CustomerId equality rules.
        public override bool Equals(object? obj)
        {
            return obj is CustomerId other &&
                   Equals(other);
        }


        // ================================================================
        // GetHashCode()
        // ================================================================

        // Equal objects MUST return the same hash code.
        //
        // This is important when using:
        // - HashSet<T>
        // - Dictionary<TKey, TValue>
        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }


        // ================================================================
        // == OPERATOR
        // ================================================================

        // Overload == so CustomerId objects can be compared using ==.
        public static bool operator ==(
            CustomerId? left,
            CustomerId? right)
        {
            return EqualityComparer<CustomerId>.Default.Equals(
                left,
                right);
        }


        // ================================================================
        // != OPERATOR
        // ================================================================

        // != should represent the opposite of ==.
        public static bool operator !=(
            CustomerId? left,
            CustomerId? right)
        {
            return !(left == right);
        }


        // ================================================================
        // IComparable<T>
        // ================================================================

        // CompareTo() defines the DEFAULT sorting order.
        //
        // Here we sort CustomerId by Value.
        public int CompareTo(CustomerId? other)
        {
            if (other is null)
            {
                // Any CustomerId is considered greater than null.
                return 1;
            }

            return Value.CompareTo(other.Value);
        }
    }


    // ====================================================================
    // ICOMPARER<T>
    // ====================================================================

    // This class provides an alternative comparison.
    //
    // Instead of changing CustomerId.CompareTo(),
    // we can create another comparer.
    private class CustomerIdDescendingComparer :
        IComparer<CustomerId>
    {
        public int Compare(
            CustomerId? x,
            CustomerId? y)
        {
            if (x is null && y is null)
                return 0;

            if (x is null)
                return -1;

            if (y is null)
                return 1;

            // Reverse the normal comparison.
            return y.Value.CompareTo(x.Value);
        }
    }
}