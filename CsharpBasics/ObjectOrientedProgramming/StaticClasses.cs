namespace CsharpFundamentals.ObjectOrientedProgramming
{
    internal class StaticClasses
    {
        public static void Run()
        {
            // ============================================================
            // STATIC CLASS
            // ============================================================

            // We cannot create an object from a static class.
            //
            // MathHelper helper = new MathHelper(); // ❌ Compile-time error

            // We access static members directly using the class name.
            int sum = MathHelper.Add(10, 20);

            Console.WriteLine($"Sum: {sum}");

            Console.WriteLine();


            // ============================================================
            // STATIC FIELD
            // ============================================================

            // Static fields belong to the class itself,
            // not to a specific object.
            Console.WriteLine($"Company Name: CompanyInfo.Name");

            Console.WriteLine($"Employees: {CompanyInfo.EmployeeCount}");

            Console.WriteLine();


            // ============================================================
            // STATIC PROPERTY
            // ============================================================

            CompanyInfo.EmployeeCount = 100;

            Console.WriteLine(
                $"Employees After Update: {CompanyInfo.EmployeeCount}");

            Console.WriteLine();


            // ============================================================
            // STATIC METHOD
            // ============================================================

            Console.WriteLine(
                $"Square: {MathHelper.Square(5)}");

            Console.WriteLine();


            // ============================================================
            // STATIC CONSTANT
            // ============================================================

            Console.WriteLine(
                $"PI: {MathHelper.PI}");


            // ============================================================
            // STATIC CLASS WITH DIFFERENT MEMBERS
            // ============================================================

            Console.WriteLine(
                $"Application: ApplicationInfo.Name");

            Console.WriteLine(
                $"Version: {ApplicationInfo.Version}");

            ApplicationInfo.PrintInfo();
        }
    }


    // ====================================================================
    // STATIC CLASS
    // ====================================================================

    // A static class cannot be instantiated.
    // A static class cannot be inherited
    // It is normally used to group related utility methods and data.
    static class MathHelper
    {
        // ================================================================
        // STATIC FIELD
        // ================================================================

        // A static field belongs to the class itself.
        public static int Number = 10;


        // ================================================================
        // STATIC CONSTANT
        // ================================================================

        // Constants are static by nature.
        // We don't need to write the "static" keyword.
        public const double PI = 3.14159;


        // ================================================================
        // STATIC METHOD
        // ================================================================

        // A static method can be called directly using
        // the class name.
        public static int Add(int x, int y)
        {
            return x + y;
        }


        public static int Square(int number)
        {
            return number * number;
        }


        // ================================================================
        // STATIC PROPERTY
        // ================================================================

        public static int DoubleNumber
        {
            get
            {
                return Number * 2;
            }
        }


        // ================================================================
        // STATIC CONSTRUCTOR
        // ================================================================

        // A static constructor runs automatically once,
        // before the class is used for the first time.
        //
        // It has:
        // - No access modifier
        // - No parameters
        // - The same name as the class
        static MathHelper()
        {
            Console.WriteLine("MathHelper Static Constructor");
            Number = 100;
        }
    }


    // ====================================================================
    // STATIC CLASS WITH SHARED DATA
    // ====================================================================

    static class CompanyInfo
    {
        // Static field.
        // There is only ONE copy of this field.
        public static string Name = "Microsoft";


        // Static property.
        public static int EmployeeCount { get; set; }


        // Static constructor.
        static CompanyInfo()
        {
            Console.WriteLine("CompanyInfo Static Constructor");

            EmployeeCount = 50;
        }
    }


    // ====================================================================
    // ANOTHER STATIC CLASS
    // ====================================================================

    static class ApplicationInfo
    {
        // Static properties.
        public static string Name { get; } = "My Application";

        public static string Version { get; } = "1.0.0";


        // Static method.
        public static void PrintInfo()
        {
            Console.WriteLine($"Application: {Name}");
            Console.WriteLine($"Version: {Version}");
        }
    }
}