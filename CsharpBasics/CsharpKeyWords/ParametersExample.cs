

namespace CsharpFundamentals.CsharpKeyWords
{
    // ============================================================
    // METHOD PARAMETERS
    // ============================================================
    //
    // ref
    // out
    // in
    // params
    // ============================================================


    class ParametersExample
    {
        public static void Run()
        {
            // ref
            int number = 10;

            Increase(ref number);

            Console.WriteLine(number);
            // 11


            // out
            GetNumber(out int result);

            Console.WriteLine(result);
            // 100


            // in
            PrintNumber(in number);


            // params
            Console.WriteLine(Sum(1, 2, 3));

            Console.WriteLine(Sum(10, 20, 30, 40));
        }
        // ========================================================
        // ref
        // ========================================================
        //
        // ref passes the original variable.
        // The method can read and modify it.
        // ========================================================

        public static void Increase(ref int number)
        {
            number++;
        }


        // ========================================================
        // out
        // ========================================================
        //
        // out passes a variable that must be assigned
        // inside the method.
        // ========================================================

        public static void GetNumber(out int number)
        {
            number = 100;
        }


        // ========================================================
        // in
        // ========================================================
        //
        // in passes by reference but is read-only.
        // ========================================================

        public static void PrintNumber(in int number)
        {
            Console.WriteLine(number);

            // number++; // ERROR
        }


        // ========================================================
        // params
        // ========================================================
        //
        // params allows passing multiple values.
        // ========================================================

        public static int Sum(params int[] numbers)
        {
            int sum = 0;

            foreach (int number in numbers)
            {
                sum += number;
            }

            return sum;
        }




    }
}
