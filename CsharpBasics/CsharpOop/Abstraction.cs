namespace CsharpFundamentals.CsharpOop;

internal static class Abstraction
{
    public static void Run()
    {
        Console.WriteLine("\n========== Abstraction ==========");

        Report report = new SalesReport([120m, 90m, 150m]);

        // The caller uses the high-level operation and does not know the report's internal steps.
        report.Export();
    }

    private abstract class Report
    {
        public abstract string Title { get; }

        // This template method fixes the algorithm while delegating one step to subclasses.
        public void Export()
        {
            Console.WriteLine($"Report: {Title}");
            string body = BuildBody();
            Console.WriteLine(body);
            OnExported();
        }

        // An abstract member is a required behavior with no base implementation.
        protected abstract string BuildBody();

        // A virtual hook provides optional customization.
        protected virtual void OnExported() => Console.WriteLine("Export completed.");
    }

    private sealed class SalesReport(IReadOnlyCollection<decimal> sales) : Report
    {
        public override string Title => "Sales summary";

        protected override string BuildBody() =>
            $"Orders: {sales.Count}, Total: {sales.Sum():C}";

        protected override void OnExported()
        {
            base.OnExported();
            Console.WriteLine("Sales team notified.");
        }
    }
}

