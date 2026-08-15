namespace CsharpFundamentals.ObjectOrientedProgramming;

internal static class MiniProject
{
    public static void Run()
    {
        Console.WriteLine("\n========== OOP Mini-Project: Checkout ==========");

        Product keyboard = new(new ProductId("KB-101"), "Keyboard", Money.Egp(1_500m));
        Product mouse = new(new ProductId("MS-201"), "Mouse", Money.Egp(600m));

        Order order = new(new OrderId(Guid.NewGuid()), new Customer("Mariam", "mariam@example.com"));
        order.AddItem(keyboard, 1);
        order.AddItem(mouse, 2);

        IDiscountPolicy discount = new PercentageDiscountPolicy(0.10m);
        IPaymentMethod payment = new CardPaymentMethod("4242");
        IOrderRepository repository = new InMemoryOrderRepository();

        CheckoutService checkout = new(discount, payment, repository);
        CheckoutResult result = checkout.Place(order);

        Console.WriteLine(result.Message);
        Console.WriteLine($"Order status: {order.Status}");
        Console.WriteLine($"Stored orders: {repository.Count}");
    }

    // Value objects use records because equality depends on their values, not their identities.
    private sealed record ProductId
    {
        public ProductId(string value)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(value);
            Value = value;
        }

        public string Value { get; }
        public override string ToString() => Value;
    }

    private readonly record struct OrderId(Guid Value);

    private readonly record struct Money
    {
        public Money(decimal amount, string currency)
        {
            ArgumentOutOfRangeException.ThrowIfNegative(amount);
            ArgumentException.ThrowIfNullOrWhiteSpace(currency);
            Amount = amount;
            Currency = currency;
        }

        public decimal Amount { get; }
        public string Currency { get; }

        public static Money Egp(decimal amount) => new(amount, "EGP");

        public static Money operator +(Money left, Money right)
        {
            EnsureSameCurrency(left, right);
            return new Money(left.Amount + right.Amount, left.Currency);
        }

        public static Money operator *(Money money, int quantity) =>
            new(money.Amount * quantity, money.Currency);

        public Money Multiply(decimal factor) => new(Amount * factor, Currency);

        private static void EnsureSameCurrency(Money left, Money right)
        {
            if (!string.Equals(left.Currency, right.Currency, StringComparison.Ordinal))
            {
                throw new InvalidOperationException("Currency mismatch.");
            }
        }

        public override string ToString() => $"{Amount:F2} {Currency}";
    }

    // Entities are classes because each instance has an identity and a lifecycle.
    private sealed class Product(ProductId id, string name, Money price)
    {
        public ProductId Id { get; } = id;
        public string Name { get; } = name;
        public Money Price { get; } = price;
    }

    private sealed record Customer(string Name, string Email);

    private sealed class OrderItem(Product product, int quantity)
    {
        public Product Product { get; } = product;
        public int Quantity { get; } = quantity > 0
            ? quantity
            : throw new ArgumentOutOfRangeException(nameof(quantity));
        public Money LineTotal => Product.Price * Quantity;
    }

    private enum OrderStatus
    {
        Draft,
        Paid
    }

    private sealed class Order
    {
        private readonly List<OrderItem> _items = [];

        public Order(OrderId id, Customer customer)
        {
            Id = id;
            Customer = customer;
        }

        public OrderId Id { get; }
        public Customer Customer { get; }
        public OrderStatus Status { get; private set; } = OrderStatus.Draft;
        public IReadOnlyList<OrderItem> Items => _items;

        public void AddItem(Product product, int quantity)
        {
            EnsureDraft();
            _items.Add(new OrderItem(product, quantity));
        }

        public Money CalculateSubtotal()
        {
            if (_items.Count == 0)
            {
                return Money.Egp(0m);
            }

            return _items.Select(item => item.LineTotal).Aggregate((left, right) => left + right);
        }

        public void MarkPaid()
        {
            EnsureDraft();

            if (_items.Count == 0)
            {
                throw new InvalidOperationException("An empty order cannot be paid.");
            }

            Status = OrderStatus.Paid;
        }

        private void EnsureDraft()
        {
            if (Status != OrderStatus.Draft)
            {
                throw new InvalidOperationException("Only draft orders can be changed.");
            }
        }
    }

    private interface IDiscountPolicy
    {
        Money Apply(Money subtotal);
    }

    private sealed class PercentageDiscountPolicy(decimal rate) : IDiscountPolicy
    {
        private readonly decimal _rate = rate is >= 0m and <= 1m
            ? rate
            : throw new ArgumentOutOfRangeException(nameof(rate));

        public Money Apply(Money subtotal) => subtotal.Multiply(1m - _rate);
    }

    private interface IPaymentMethod
    {
        PaymentResult Pay(Money amount);
    }

    private sealed record PaymentResult(bool IsSuccessful, string Reference);

    private sealed class CardPaymentMethod(string lastFourDigits) : IPaymentMethod
    {
        public PaymentResult Pay(Money amount)
        {
            Console.WriteLine($"Charging card ending {lastFourDigits}: {amount}");
            return new PaymentResult(true, $"PAY-{Guid.NewGuid():N}");
        }
    }

    private interface IOrderRepository
    {
        int Count { get; }
        void Save(Order order);
    }

    private sealed class InMemoryOrderRepository : IOrderRepository
    {
        private readonly Dictionary<OrderId, Order> _orders = [];
        public int Count => _orders.Count;
        public void Save(Order order) => _orders[order.Id] = order;
    }

    private sealed record CheckoutResult(bool IsSuccessful, string Message);

    private sealed class CheckoutService(
        IDiscountPolicy discountPolicy,
        IPaymentMethod paymentMethod,
        IOrderRepository repository)
    {
        public CheckoutResult Place(Order order)
        {
            Money subtotal = order.CalculateSubtotal();
            Money total = discountPolicy.Apply(subtotal);
            PaymentResult payment = paymentMethod.Pay(total);

            if (!payment.IsSuccessful)
            {
                return new CheckoutResult(false, "Payment failed.");
            }

            order.MarkPaid();
            repository.Save(order);

            return new CheckoutResult(
                true,
                $"Order {order.Id.Value} paid successfully. Reference: {payment.Reference}");
        }
    }
}
