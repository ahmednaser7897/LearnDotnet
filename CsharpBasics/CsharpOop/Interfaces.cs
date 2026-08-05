namespace CsharpFundamentals.CsharpOop;

internal static class Interfaces
{
    public static void Run()
    {
        Console.WriteLine("\n========== Interfaces ==========");

        INotificationSender sender = new EmailSender();
        sender.Send("mona@example.com", "Your order was shipped.");
        sender.LogProvider(); // Default interface implementation.

        MultiFormatDocument document = new();
        ((ITextExporter)document).Export();
        ((IJsonExporter)document).Export();

        Temperature parsed = Parse<Temperature>("24.5");
        Console.WriteLine($"Static abstract interface member: {parsed.Celsius:F1} C");
    }

    private interface INotificationSender
    {
        void Send(string destination, string message);

        // Default interface members can evolve a contract without forcing every implementation to change.
        void LogProvider() => Console.WriteLine($"Provider: {GetType().Name}");
    }

    private sealed class EmailSender : INotificationSender
    {
        public void Send(string destination, string message) =>
            Console.WriteLine($"Email to {destination}: {message}");
    }

    private interface ITextExporter
    {
        void Export();
    }

    private interface IJsonExporter
    {
        void Export();
    }

    private sealed class MultiFormatDocument : ITextExporter, IJsonExporter
    {
        // Explicit implementations resolve same-signature conflicts and are visible through the interface only.
        void ITextExporter.Export() => Console.WriteLine("Exported as text.");
        void IJsonExporter.Export() => Console.WriteLine("Exported as JSON.");
    }

    private interface IParsableValue<TSelf> where TSelf : IParsableValue<TSelf>
    {
        // Static abstract members enable compile-time polymorphism in generic algorithms.
        static abstract TSelf Parse(string text);
    }

    private readonly record struct Temperature(double Celsius) : IParsableValue<Temperature>
    {
        public static Temperature Parse(string text) =>
            new(double.Parse(text, System.Globalization.CultureInfo.InvariantCulture));
    }

    private static T Parse<T>(string text) where T : IParsableValue<T> => T.Parse(text);
}

