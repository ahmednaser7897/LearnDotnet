namespace CsharpFundamentals.ObjectOrientedProgramming;

internal static class ConstructorsAndInitialization
{
    public static void Run()
    {
        Console.WriteLine("\n========== Constructors and Initialization ==========");

        Customer guest = new();
        Customer registered = new("Salma", "salma@example.com");

        // Object initializers assign accessible members after the constructor runs.
        Product product = new("KB-101")
        {
            Name = "Mechanical Keyboard",
            Price = 125.50m
        };

        Point point = new(4, 7); // Primary constructor syntax.

        Console.WriteLine(guest);
        Console.WriteLine(registered);
        Console.WriteLine($"{product.Sku}: {product.Name} costs {product.Price:C}");
        Console.WriteLine(point.Describe());
    }

    private sealed class Customer
    {
        // This constructor delegates to the main constructor to keep initialization in one place.
        public Customer() : this("Guest", "guest@example.com")
        {
        }

        public Customer(string name, string email)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(name);
            ArgumentException.ThrowIfNullOrWhiteSpace(email);
            Name = name;
            Email = email;
        }

        public string Name { get; }
        public string Email { get; }

        public override string ToString() => $"{Name} <{Email}>";
    }

    private sealed class Product(string sku)
    {
        // A required member must be assigned by an object initializer or a constructor marked appropriately.
        public required string Name { get; init; }

        // init permits assignment only during construction or an object initializer.
        public decimal Price { get; init; }

        public string Sku { get; } = string.IsNullOrWhiteSpace(sku)
            ? throw new ArgumentException("SKU is required.", nameof(sku))
            : sku;
    }

    // Primary constructor parameters are in scope throughout the class body.
    private sealed class Point(int x, int y)
    {
        public int X { get; } = x;
        public int Y { get; } = y;
        public string Describe() => $"Point({X}, {Y})";
    }
}

