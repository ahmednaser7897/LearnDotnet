namespace CsharpFundamentals.CsharpOop;

internal static class Polymorphism
{
    public static void Run()
    {
        Console.WriteLine("\n========== Polymorphism ==========");

        // Runtime polymorphism: one base reference invokes behavior selected by the runtime type.
        Shape[] shapes =
        [
            new Circle(3),
            new Rectangle(4, 5),
            new Triangle(6, 2)
        ];

        foreach (Shape shape in shapes)
        {
            Console.WriteLine($"{shape.Name} area = {shape.Area():F2}");
        }

        // Compile-time polymorphism: overload resolution selects a method from argument types.
        Console.WriteLine(Formatter.Format(42));
        Console.WriteLine(Formatter.Format(12.345m));
        Console.WriteLine(Formatter.Format("C#"));

        Money subtotal = new(100m, "USD");
        Money tax = new(15m, "USD");
        Console.WriteLine($"Operator overload: {subtotal + tax}");
        Console.WriteLine($"Explicit conversion: {(decimal)subtotal:F2}");
    }

    private abstract class Shape
    {
        public abstract string Name { get; }
        public abstract double Area();
    }

    private sealed class Circle(double radius) : Shape
    {
        public override string Name => nameof(Circle);
        public override double Area() => Math.PI * radius * radius;
    }

    private sealed class Rectangle(double width, double height) : Shape
    {
        public override string Name => nameof(Rectangle);
        public override double Area() => width * height;
    }

    private sealed class Triangle(double width, double height) : Shape
    {
        public override string Name => nameof(Triangle);
        public override double Area() => width * height / 2;
    }

    private static class Formatter
    {
        public static string Format(int value) => $"Integer: {value}";
        public static string Format(decimal value) => $"Decimal: {value:F2}";
        public static string Format(string value) => $"Text: {value}";
    }

    private readonly record struct Money(decimal Amount, string Currency)
    {
        public static Money operator +(Money left, Money right)
        {
            if (!string.Equals(left.Currency, right.Currency, StringComparison.Ordinal))
            {
                throw new InvalidOperationException("Currencies must match.");
            }

            return left with { Amount = left.Amount + right.Amount };
        }

        // User-defined conversions should be unsurprising and must not hide expensive work.
        public static explicit operator decimal(Money money) => money.Amount;

        public override string ToString() => $"{Amount:F2} {Currency}";
    }
}
