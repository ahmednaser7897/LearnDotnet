namespace CsharpFundamentals.Keywords
{
    // ============================================================
    // STATIC
    // ============================================================
    //
    // static members belong to the class itself,
    // not to a specific object.
    // ============================================================
    class StaticExample
    {
        public static void Run()
        {
            // Create objects.
            Counter first = new Counter("Ahmed");
            Counter second = new Counter("Ali");

            first.PrintName();
            second.PrintName();

            // Static member belongs to the class.
            Counter.PrintCount();


            // Static class.
            int result = MathHelper.Add(10, 20);

            Console.WriteLine(result);


            // Static constructor runs automatically.
            Console.WriteLine(Configuration.AppName);
        }
    }


    class Counter
    {
        // Shared by all objects.
        public static int Count = 0;

        // Instance property.
        public string Name { get; set; }

        public Counter(string name)
        {
            Name = name;

            Count++;
        }


        public static void PrintCount()
        {
            Console.WriteLine($"Objects created: {Count}");
        }


        public void PrintName()
        {
            Console.WriteLine($"Name: {Name}");
        }
    }


    // ============================================================
    // STATIC CLASS
    // ============================================================
    //
    // - Cannot create an object from it.
    // - Can contain only static members.
    // ============================================================

    static class MathHelper
    {
        public static int Add(int a, int b)
        {
            return a + b;
        }


        public static int Multiply(int a, int b)
        {
            return a * b;
        }


        public static double Square(double number)
        {
            return number * number;
        }
    }


    // ============================================================
    // STATIC CONSTRUCTOR
    // ============================================================
    //
    // - Runs automatically once.
    // - Runs before the class is used for the first time.
    // - Cannot have parameters.
    // ============================================================

    class Configuration
    {
        public static string AppName;

        static Configuration()
        {
            AppName = "My Application";

            Console.WriteLine("Static constructor called");
        }
    }
}

