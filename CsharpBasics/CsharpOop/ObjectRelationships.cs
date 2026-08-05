namespace CsharpFundamentals.CsharpOop;

internal static class ObjectRelationships
{
    public static void Run()
    {
        Console.WriteLine("\n========== Object Relationships ==========");

        Teacher teacher = new("Nadia");
        Course course = new("OOP", teacher); // Association: both can exist independently.

        Department department = new("Engineering");
        department.Add(teacher); // Aggregation: the department groups externally owned teachers.

        Car car = new("Electric"); // Composition: the car creates and owns its engine.
        car.Start();

        Invoice invoice = new(750m);
        InvoicePrinter.Print(invoice); // Dependency: a method temporarily uses another object.

        Checkout checkout = new(new PercentageDiscount(0.10m));
        Console.WriteLine($"Discounted total: {checkout.TotalAfterDiscount(200m):C}");

        Console.WriteLine($"{course.Title} is taught by {course.Teacher.Name}.");
        Console.WriteLine($"{department.Name} teachers: {department.TeacherCount}");
    }

    private sealed record Teacher(string Name);

    private sealed record Course(string Title, Teacher Teacher);

    private sealed class Department(string name)
    {
        private readonly List<Teacher> _teachers = [];
        public string Name { get; } = name;
        public int TeacherCount => _teachers.Count;
        public void Add(Teacher teacher) => _teachers.Add(teacher);
    }

    private sealed class Engine(string kind)
    {
        public void Start() => Console.WriteLine($"{kind} engine started.");
    }

    private sealed class Car
    {
        private readonly Engine _engine;

        public Car(string engineKind)
        {
            _engine = new Engine(engineKind);
        }

        public void Start() => _engine.Start();
    }

    private sealed record Invoice(decimal Total);

    private static class InvoicePrinter
    {
        public static void Print(Invoice invoice) => Console.WriteLine($"Invoice total: {invoice.Total:C}");
    }

    private interface IDiscountPolicy
    {
        decimal Apply(decimal total);
    }

    private sealed class PercentageDiscount(decimal rate) : IDiscountPolicy
    {
        public decimal Apply(decimal total) => total * (1m - rate);
    }

    private sealed class Checkout(IDiscountPolicy discountPolicy)
    {
        // Composition makes the policy replaceable without subclassing Checkout.
        public decimal TotalAfterDiscount(decimal total) => discountPolicy.Apply(total);
    }
}
