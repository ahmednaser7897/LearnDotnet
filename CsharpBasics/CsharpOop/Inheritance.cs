namespace CsharpFundamentals.CsharpOop;

internal static class Inheritance
{
    public static void Run()
    {
        Console.WriteLine("\n========== Inheritance ==========");

        Employee employee = new("E-101", "Hassan", 10_000m);
        Manager manager = new("M-201", "Laila", 15_000m, 4_000m);

        Console.WriteLine(employee.GetDescription());
        Console.WriteLine(manager.GetDescription());
        Console.WriteLine($"Manager pay: {manager.CalculateMonthlyPay():C}");

        // Upcasting is implicit and safe because every Manager is an Employee.
        Employee upcast = manager;
        Console.WriteLine($"Runtime type: {upcast.GetType().Name}");

        // A non-virtual member can be hidden with new, but the selected member depends on the variable type.
        Console.WriteLine(manager.GetPolicyLabel());
        Console.WriteLine(upcast.GetPolicyLabel());
    }

    private class Employee
    {
        private readonly decimal _baseSalary;

        public Employee(string id, string name, decimal baseSalary)
        {
            Id = id;
            Name = name;
            _baseSalary = baseSalary;
        }

        public string Id { get; }
        public string Name { get; protected set; }

        // virtual permits a derived class to replace the implementation.
        public virtual decimal CalculateMonthlyPay() => _baseSalary;

        public virtual string GetDescription() => $"Employee {Id}: {Name}";

        public string GetPolicyLabel() => "Base employee policy";

        protected decimal GetBaseSalary() => _baseSalary;
    }

    private sealed class Manager : Employee
    {
        private readonly decimal _monthlyBonus;

        // base invokes a base-class constructor before this constructor body runs.
        public Manager(string id, string name, decimal baseSalary, decimal monthlyBonus)
            : base(id, name, baseSalary)
        {
            _monthlyBonus = monthlyBonus;
        }

        public override decimal CalculateMonthlyPay() => GetBaseSalary() + _monthlyBonus;

        // sealed override prevents further overrides even if the class itself were not sealed.
        public sealed override string GetDescription() => $"Manager {Id}: {Name}";

        // new explicitly acknowledges member hiding. Prefer overriding when polymorphism is intended.
        public new string GetPolicyLabel() => "Manager policy";
    }
}

