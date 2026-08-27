using Linq.Sets;

namespace Linq;

internal class LinqBasics
{
    public static void Run()
    {
        ImplicitTypedVariables();
        AnonymousTypes();
        // ExpressionVsStatement();
        // PureVsImpureFunctions();
        ImperativeVsDeclarative();
    }
    public static void ImplicitTypedVariables()
    {
        Console.WriteLine("===================== Implicit typed variables ====================");
        // var used to declare a variable and its type is inferred from the right hand side
        // so the type must be know at compile time 
        // and it cant be changed during runtime
        var a = 1;
        //a=1.1 is not allowed because a is declared as int
        var b = 2;
        Console.WriteLine($"a = {a}");
        Console.WriteLine($"b = {b}");
        Console.WriteLine("==========================================");
        Console.WriteLine();
    }
    public static void AnonymousTypes()
    {
        Console.WriteLine("===================== Anonymous Types ====================");
        var employee1 = new Employee() { EmployeeNo = "123456", Name = "John Doe" };
        Console.WriteLine($"Normal class Employee = {employee1}");

        // Anonymous types are immutable, so once an object is created, its properties cannot be changed.
        // Anonymous types override Equals(), GetHashCode(), and ToString().
        // The C# compiler automatically creates the anonymous type.
        // If we create multiple anonymous objects with the same property names and types,
        // the compiler uses the same anonymous type for them.
        // Anonymous types compare objects based on the values of their properties.
        var employee2 = new { EmployeeNo = "123457", Name = "Jane Doe" };
        var employee3 = new { EmployeeNo = "123457", Name = "Jane Doe" };
        var employee4 = new { employeeNo = "123457", name = "Jane Doe" };
        Console.WriteLine($"Anunmas class Employee Data {employee2}");// { EmployeeNo = 123457, Name = Jane Doe }
        Console.WriteLine($"Anunmas class Employee Type {employee2.GetType()}");//  <>f__AnonymousType0`2[System.String,System.String]
        Console.WriteLine($"Anunmas class Employee Name {employee2.Name}");// Jane Doe
        Console.WriteLine($"employee2.GetType()==employee3.GetType() ==> {employee2.GetType() == employee3.GetType()}");//True
        Console.WriteLine($"employee2.Equals(employee3) ==> {employee2.Equals(employee3)}");//True
        Console.WriteLine($"employee2.GetType()==employee4.GetType() ==> {employee2.GetType() == employee4.GetType()}");//True
        Console.WriteLine($"employee2.Equals(employee4) ==> {employee2.Equals(employee4)}");//True

        // Assigning a new value to a property of an anonymous type is not allowed.
        // Anonymous type properties are read-only after the object is created, so they are immutable.
        // employee2.Name = "John Doe"; // Causes a compile-time error.
        Console.WriteLine("==========================================");
        Console.WriteLine();
    }


    // ============================================================
    // Expression vs Statement
    // ============================================================

    public static void ExpressionVsStatement()
    {
        Console.WriteLine("===================== Expression Vs Statement =====================");

        // A statement performs an action and usually ends with ; or a code block.

        // Declaration statement.
        int counter;

        // Assignment statement.
        counter = 1;

        // Declaration and initialization statement.
        const double pi = 3.14159;

        // A foreach statement repeats code for each item.
        foreach (var item in new int[] { 1, 2, 3 })
        {
        }

        // A for statement repeats code while the condition is true.
        for (int i = 0; i < 10; i++)
        {
        }

        // An if statement executes code based on a condition.
        if (true)
        {
        }

        // Other statements include switch, while, do, and jump statements.


        // ============================================================
        // Expressions
        // ============================================================

        // An expression produces a value.
        var radius = 10;

        // This expression calculates and produces the area value.
        var area = 3.14 * (radius * radius);

        // A method call can be an expression even if the method returns void.
        Console.WriteLine(area);

        // Object creation is an expression because it produces a new object.
        var names = new string[] { "Ali", "Ahmad", "Reem" };

        // A statement can contain expressions, but an expression is not always a statement.

        // Method call used as a statement.
        DoSomething();

        void DoSomething()
        {
            // A return statement exits the method.
            return;
        }

        Console.WriteLine("==========================================");
        Console.WriteLine();
    }


    // ============================================================
    // Pure vs Impure Functions
    // ============================================================

    public static void PureVsImpureFunctions()
    {
        Console.WriteLine("===================== Pure Vs Impure Functions =====================");

        // A pure function gives the same output for the same input.
        // A pure function does not change anything outside itself.

        var numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

        // Print the original list.
        Print(numbers);

        // This method changes the external list, so it is impure.
        AddInteger1(3);

        // This value will be changed through the ref parameter.
        var x = 2;

        // This method changes the parameter and the external list, so it is impure.
        AddInteger2(ref x);

        // This method uses Random, so its result depends on external state.
        AddInteger3();

        // This method creates a new list instead of changing the original list.
        var newList = AddInteger4(numbers, 3);

        Console.WriteLine("Old list");
        Print(numbers);

        Console.WriteLine("New list");
        Print(newList);

        Console.WriteLine("==========================================");
        Console.WriteLine();


        // Prints all numbers in the list.
        void Print(List<int> source)
        {
            foreach (var item in source)
            {
                Console.Write($" {item}");
            }

            Console.WriteLine();
        }


        // Changes the external list, so this function is impure.
        void AddInteger1(int num)
        {
            numbers.Add(num);
        }


        // Changes the ref parameter and the external list, so this function is impure.
        void AddInteger2(ref int num)
        {
            num++;
            numbers.Add(num);
        }


        // Uses Random, which depends on external state, so this function is impure.
        void AddInteger3()
        {
            numbers.Add(new Random().Next());
        }


        // Creates a new list and keeps the original list unchanged, so it is pure.
        List<int> AddInteger4(List<int> source, int num)
        {
            var result = new List<int>(source);
            result.Add(num);

            return result;
        }
    }


    // ============================================================
    // Imperative vs Declarative
    // ============================================================

    public static void ImperativeVsDeclarative()
    {
        Console.WriteLine("===================== Imperative Vs Declarative =====================");

        // Create a collection of people.
        IEnumerable<Person> people = new[]
        {
            new Person
            {
                Name = "Ali Saleh",
                Age = 34,
                Telephone = "+1(123)456-7890"
            },

            new Person
            {
                Name = "Rim Salem",
                Age = 19,
                Telephone = "+1(123)456-7891"
            },

            new Person
            {
                Name = "Ola Salam",
                Age = 44,
                Telephone = "+1(123)456-7892"
            },

            new Person
            {
                Name = "Huda Mohd",
                Age = 32,
                Telephone = "+1(123)456-7893"
            },

            new Person
            {
                Name = "Omar Kadi",
                Age = 28,
                Telephone = "+1(123)456-7894"
            }
        };


        // A predicate describes the condition we want to apply.
        Func<Person, bool> predicate = person => person.Age >= 32;

        // Filter the people using the condition.
        var result = Filter(people, predicate);

        Console.WriteLine("Age >= 32");
        Console.WriteLine("---------------");

        // Print the filtered people.
        Print(result);

        Console.WriteLine("==========================================");
        Console.WriteLine();
    }


    // Filters people based on the condition passed to the method.
    static IEnumerable<Person> Filter(
        IEnumerable<Person> people,
        Func<Person, bool> predicate)
    {
        // Check every person in the collection.
        foreach (var person in people)
        {
            // Return the person when the condition is true.
            if (predicate(person))
            {
                yield return person;
            }
        }
    }


    // A method that can be passed as an Action.
    static void Method1()
    {
        Console.WriteLine("Method 1");
    }


    // Executes the received method and then continues execution.
    static void Method2(Action method)
    {
        method();

        Console.WriteLine("Method 2");
    }


    // Prints all people in the collection.
    static void Print(IEnumerable<Person> people)
    {
        foreach (var person in people)
        {
            Console.Write(" {");
            Console.Write($" Name: \"{person.Name}\"");
            Console.Write($", Age: {person.Age}");
            Console.Write($", Telephone: \"{person.Telephone}\"");
            Console.Write(" }");

            Console.WriteLine();
        }
    }


    // Represents a person with basic information.
    class Person
    {
        // The person's name.
        public string Name { get; set; }

        // The person's age.
        public int Age { get; set; }

        // The person's telephone number.
        public string Telephone { get; set; }
    }
}
