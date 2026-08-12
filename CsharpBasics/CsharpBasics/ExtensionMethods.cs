using System;

namespace CsharpFundamentals.CsharpBasics
{
    public class ExtensionMethods
    {
        public static void Run()
        {
            // ============================================================
            // USING EXTENSION METHODS
            // ============================================================

            CheckNumber(-10);
            CheckNumber(0);
            CheckNumber(10);
            CheckNumber(100);
            CheckNumber(101);


            // We can also use the extension method
            // like a normal static method.
            if (NumberHelper.IsBetween(5, 0, 100))
            {
                Console.WriteLine($"{5} is a valid number");
            }
            else
            {
                Console.WriteLine($"{5} is not a valid number");
            }


            // ============================================================
            // STRING EXTENSION METHODS
            // ============================================================

            var s = " hi ah med  ";

            // We can chain multiple extension methods together.
            //
            // First: RemoveSpaces()
            // Then: Revers()
            Console.WriteLine(
                $"Clean string is: {s.RemoveSpaces().Revers()}");
        }


        static void CheckNumber(int number)
        {
            // IsBetween() is an extension method for int,
            // so we can call it directly on the integer.
            if (number.IsBetween(0, 100))
            {
                Console.WriteLine($"{number} is a valid number");
            }
            else
            {
                Console.WriteLine($"{number} is not a valid number");
            }
        }
    }


    // ====================================================================
    // EXTENSION METHODS FOR INT
    // ====================================================================

    // To create an Extension Method:
    // 1. The class must be static.
    // 2. The method must be static.
    // 3. The first parameter must use the "this" keyword.
    // 4. The type of the first parameter is the type
    //    that we are extending.
    //
    // Example:
    //
    // this int value
    //
    // "this"  -> tells C# that this is an Extension Method.
    // "int"   -> tells C# that we are extending the int type.
    // "value" -> represents the actual integer that calls the method.
    public static class NumberHelper
    {
        // ================================================================
        // EXTENSION METHOD
        // ================================================================

        public static bool IsBetween(
            this int value,
            int min,
            int max)
        {
            return value >= min && value <= max;
        }
    }


    // ====================================================================
    // EXTENSION METHODS FOR STRING
    // ====================================================================

    public static class StringExtensions
    {
        // This is an Extension Method for string.
        //
        // "this string s" means that we are extending
        // the string type.
        public static string RemoveSpaces(this string s)
        {
            return s.Replace(" ", "");
        }


        // Another Extension Method for string.
        //
        // It reverses the string.
        public static string Revers(this string s)
        {
            var chars = s.ToCharArray();

            Array.Reverse(chars);

            return new string(chars);
        }
    }


    // ====================================================================
    // IMPORTANT EXTENSION METHOD RULE
    // ====================================================================

    // If we create an Extension Method with the same signature
    // as an existing instance method in the same type,
    // C# will ALWAYS use the original instance method.
    //
    // In other words:
    //
    // Original Instance Method
    //          ↓
    //      Has priority
    //          ↓
    // Extension Method
    //          ↓
    //      Not used
    //
    // Extension Methods do NOT override or replace
    // existing instance methods.
}