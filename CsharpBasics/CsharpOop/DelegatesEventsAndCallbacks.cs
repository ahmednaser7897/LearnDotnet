namespace CsharpFundamentals.CsharpOop;

internal static class DelegatesEventsAndCallbacks
{
    public static void Run()
    {
        Console.WriteLine("\n========== Delegates, Events, and Callbacks ==========");

        // A delegate stores one or more compatible method references.
        PriceTransform transform = AddTax;
        transform += AddServiceFee;
        foreach (PriceTransform operation in transform.GetInvocationList().Cast<PriceTransform>())
        {
            Console.WriteLine($"Delegate result: {operation(100m):C}");
        }

        Order order = new("ORD-500");
        order.StatusChanged += (_, args) =>
            Console.WriteLine($"Event: {args.Previous} -> {args.Current}");
        order.MarkPaid();

        PaymentProcessor processor = new(amount => amount <= 1_000m);
        Console.WriteLine($"Strategy callback accepted: {processor.Process(250m)}");
    }

    private delegate decimal PriceTransform(decimal price);

    private static decimal AddTax(decimal price) => price * 1.14m;
    private static decimal AddServiceFee(decimal price) => price + 5m;

    private sealed class OrderStatusChangedEventArgs(string previous, string current) : EventArgs
    {
        public string Previous { get; } = previous;
        public string Current { get; } = current;
    }

    private sealed class Order(string id)
    {
        private string _status = "Pending";

        // Only the declaring class can raise an event. Subscribers can only add or remove handlers.
        public event EventHandler<OrderStatusChangedEventArgs>? StatusChanged;

        public string Id { get; } = id;

        public void MarkPaid()
        {
            string previous = _status;
            _status = "Paid";
            OnStatusChanged(previous, _status);
        }

        private void OnStatusChanged(string previous, string current) =>
            StatusChanged?.Invoke(this, new OrderStatusChangedEventArgs(previous, current));
    }

    private sealed class PaymentProcessor(Func<decimal, bool> paymentStrategy)
    {
        public bool Process(decimal amount) => paymentStrategy(amount);
    }
}

