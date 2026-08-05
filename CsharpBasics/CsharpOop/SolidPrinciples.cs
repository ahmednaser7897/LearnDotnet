namespace CsharpFundamentals.CsharpOop;

internal static class SolidPrinciples
{
    public static void Run()
    {
        Console.WriteLine("\n========== SOLID Principles ==========");

        Invoice invoice = new([100m, 250m]);
        InvoiceCalculator calculator = new();
        InvoiceFormatter formatter = new();
        Console.WriteLine(formatter.Format(calculator.Total(invoice)));

        IReadOnlyList<AreaShape> shapes = [new Circle(2), new Square(3)];
        Console.WriteLine($"Open/Closed total area: {shapes.Sum(shape => shape.Area()):F2}");

        Bird bird = new Sparrow();
        bird.Eat(); // A subtype preserves the behavior promised by the base abstraction.

        IPrinter printer = new SimplePrinter();
        printer.Print("Interface Segregation keeps contracts focused.");

        MessageService service = new(new ConsoleMessageSender());
        service.Notify("Dependency Inversion depends on an abstraction.");
    }

    // SRP: calculating and formatting have separate reasons to change.
    private sealed record Invoice(IReadOnlyCollection<decimal> Lines);

    private sealed class InvoiceCalculator
    {
        public decimal Total(Invoice invoice) => invoice.Lines.Sum();
    }

    private sealed class InvoiceFormatter
    {
        public string Format(decimal total) => $"Invoice total: {total:C}";
    }

    // OCP: add a new AreaShape implementation without modifying the area summation.
    private interface AreaShape
    {
        double Area();
    }

    private sealed record Circle(double Radius) : AreaShape
    {
        public double Area() => Math.PI * Radius * Radius;
    }

    private sealed record Square(double Side) : AreaShape
    {
        public double Area() => Side * Side;
    }

    // LSP: derived types must preserve the valid expectations of the base contract.
    private abstract class Bird
    {
        public void Eat() => Console.WriteLine("Bird is eating.");
    }

    private sealed class Sparrow : Bird
    {
    }

    // ISP: clients should not depend on methods they do not use.
    private interface IPrinter
    {
        void Print(string text);
    }

    private interface IScanner
    {
        string Scan();
    }

    private sealed class SimplePrinter : IPrinter
    {
        public void Print(string text) => Console.WriteLine(text);
    }

    // DIP: high-level policy receives a contract instead of constructing a low-level dependency.
    private interface IMessageSender
    {
        void Send(string message);
    }

    private sealed class ConsoleMessageSender : IMessageSender
    {
        public void Send(string message) => Console.WriteLine(message);
    }

    private sealed class MessageService(IMessageSender sender)
    {
        public void Notify(string message) => sender.Send(message);
    }
}
