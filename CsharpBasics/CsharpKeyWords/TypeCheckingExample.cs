namespace CsharpFundamentals.CsharpKeyWords
{
    // ============================================================
    // TYPE CHECKING
    // ============================================================
    //
    // is
    // as
    // typeof
    // nameof
    // ============================================================


    class TypeCheckingExample
    {
        public static void Run()
        {
            object value = "Ahmed";


            // ========================================================
            // is
            // ========================================================
            //
            // Checks if a value is a specific type.
            // ========================================================

            if (value is string)
            {
                Console.WriteLine("Value is a string");
            }


            // ========================================================
            // is + Pattern Matching
            // ========================================================
            //
            // We can check the type and get the value at the same time.
            // ========================================================

            if (value is string text)
            {
                Console.WriteLine(text);
            }


            object numberValue = 100;

            if (numberValue is int number)
            {
                Console.WriteLine(number);
            }


            // ========================================================
            // as
            // ========================================================
            //
            // Tries to convert to a type.
            // Returns null if conversion fails.
            // ========================================================

            object name = "Ahmed";

            string? textValue = name as string;

            Console.WriteLine(textValue);


            object number2 = 100;

            string? invalid = number2 as string;

            Console.WriteLine(invalid);
            // null


            // ========================================================
            // typeof
            // ========================================================
            //
            // Gets Type information.
            // ========================================================

            Type type = typeof(string);

            Console.WriteLine(type);

            Console.WriteLine(typeof(int));
            Console.WriteLine(typeof(double));


            // ========================================================
            // nameof
            // ========================================================
            //
            // Returns the name of a variable, property,
            // method, class, etc. as a string.
            // ========================================================

            string userName = "Ahmed";

            Console.WriteLine(nameof(userName));

            Console.WriteLine(nameof(TypeCheckingExample));
            Console.WriteLine(nameof(Run));
        }
    }
}

