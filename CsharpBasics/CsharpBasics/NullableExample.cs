
namespace CsharpFundamentals.CsharpBasics
{
    // ============================================================
    // NULLABLE
    // ============================================================
    //
    // ?
    // !
    // ??
    // ??=
    // ============================================================


    class NullableExample
    {
        public static void Run()
        {
            // ========================================================
            // Nullable Reference Type ?
            // ========================================================
            //
            // string? can contain null.
            // ========================================================

            string? name = null;

            Console.WriteLine(name);


            // ========================================================
            // Nullable Value Type ?
            // ========================================================
            //
            // int normally cannot contain null.
            // int? can contain null.
            // ========================================================

            int? age = null;

            Console.WriteLine(age);


            // ========================================================
            // Null-Forgiving Operator !
            // ========================================================
            //
            // ! tells the compiler:
            // "I know this value is not null."
            //
            // Be careful: ! does NOT prevent null at runtime.
            // ========================================================

            string? email = "ahmed@gmail.com";

            Console.WriteLine(email!.Length);


            // ========================================================
            // Null-Coalescing Operator ??
            // ========================================================
            //
            // If the left side is null,
            // use the right side.
            // ========================================================

            string? username = null;

            string result = username ?? "Guest";

            Console.WriteLine(result);


            // ========================================================
            // Null-Coalescing Assignment ??=
            // ========================================================
            //
            // Assign a value only if the variable is null.
            // ========================================================

            string? city = null;

            city ??= "Cairo";

            Console.WriteLine(city);

            // city is already not null,
            // so this will not change it.
            city ??= "Alexandria";

            Console.WriteLine(city);
        }
    }
}

