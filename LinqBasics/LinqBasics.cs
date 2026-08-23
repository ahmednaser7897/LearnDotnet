namespace Linq;

internal class LinqBasics
{
    public static void Run()
    {
        ExpressionVsStatement();
        PureVsImpureFunctions();
        ImparativeVsDeclarative();
    }

    public static void ExpressionVsStatement()
    {
        Console.WriteLine("===================== Expression Vs Statement =====================");
        // Declaration statement.
        int counter;

        // Assignment statement.
        counter = 1;

        // Declare and initialize
        const double pi = 3.14159; // Declare and initialize  constant.

        // foreach statement
        foreach (var item in new int[] { 1, 2, 3 })
        {

        }

        // for statement
        for (int i = 0; i < 10; i++)
        {

        }

        // if , if - else if -else , 
        if (true)
        {

        }

        // switch, jump, do, while 


        // Expresion 
        var radius = 10;

        var area = 3.14 * (radius * radius); // expression  3.14 * (radius * radius) yield a value

        // method invocation (this method yield void
        Console.WriteLine(area);

        // new object creation 
        var names = new string[] { "ali", "ahmad", "reem" };

        // statement can include expression and not the other way around

        DoSomething();
        Console.WriteLine("==========================================");
        Console.WriteLine();
    }
    static void DoSomething()
    {
        return;
    }
    public static void PureVsImpureFunctions()
    {
        Console.WriteLine("===================== Pure Vs Impure Functions =====================");
        //Print(numbers);

        // AddInteger1(3);

        //var x = 2;
        //AddInteger2(ref x);

        //AddInteger3();

        var newList = AddInteger4(numbers, 3);
        Console.WriteLine("old list");
        Print(numbers);
        Console.WriteLine("new list");
        Print(newList);

        Console.WriteLine("==========================================");
        Console.WriteLine();
    }
    static List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
    static void Print(List<int> source)
    {
        foreach (var item in source)
        {
            Console.Write($" {item}");
        }
        Console.WriteLine();
    }

    static void AddInteger1(int num)
    {
        numbers.Add(num); // impure mutate global variable
    }

    static void AddInteger2(ref int num)
    {
        num++; // impure mutate parameter
        numbers.Add(num);
    }

    static void AddInteger3()
    {
        numbers.Add(new Random().Next()); // impure interation with outside world
    }

    static List<int> AddInteger4(List<int> numbers, int num)
    {
        var result = new List<int>(numbers); // 
        result.Add(num);
        return result;
    }

    public static void ImparativeVsDeclarative()
    {
        Console.WriteLine("===================== ImparativeVsDeclarative =====================");
        IEnumerable<Person> people = new[]
             {
                new Person { Name =  "Ali Saleh", Age = 34, Telephone = "+1(123)456-7890"},
                new Person { Name =  "Rim Salem", Age = 19, Telephone = "+1(123)456-7891"},
                new Person { Name =  "Ola Salam", Age = 44, Telephone = "+1(123)456-7892"},
                new Person { Name =  "Huda Mohd", Age = 32, Telephone = "+1(123)456-7893"},
                new Person { Name =  "Omar Kadi", Age = 28, Telephone = "+1(123)456-7894"}
            };

        // Print(people);

        //var result = FilterPeopleWithAgeLessThan(people, 30);
        //Console.WriteLine("Age Less Than 30");
        //Console.WriteLine("---------------");

        //var result = FilterPeopleWithAgeEqual(people, 32);
        //Console.WriteLine("Age = 32");
        //Console.WriteLine("---------------");
        //Print(result);

        //Method2(Method1);

        Func<Person, bool> predicate = p => p.Age >= 32;

        var result = Filter(people, predicate);
        Console.WriteLine("Age >= 32");
        Console.WriteLine("---------------");
        Print(result);
        Console.WriteLine("==========================================");
        Console.WriteLine();
    }
    static IEnumerable<Person> Filter(IEnumerable<Person> people, Func<Person, bool> predicate)
    {
        foreach (var item in people)
        {
            if (predicate(item))
                yield return item;
        }
    }


    static void Method1()
    {
        Console.WriteLine("Method 1");
    }

    static void Method2(Action method1)
    {
        method1();
        Console.WriteLine("Method 2");
    }
    static void Print(IEnumerable<Person> people)
    {
        foreach (Person p in people)
        {
            Console.Write(" {");
            Console.Write($" Name: \"{p.Name}\"");
            Console.Write($", Age: {p.Age}");
            Console.Write($", Telephone: \"{p.Telephone}\"");
            Console.Write(" }");
            Console.WriteLine();
        }
    }
    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Telephone { get; set; }
    }

}