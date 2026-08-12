// ITI LECTURE - C# Fundamentals - List<T>
// File - ListBasics.cs

namespace CsharpFundamentals.DataStructures
{
    internal class ListBasics
    {
        public static void Run()
        {
            Console.WriteLine("========== LIST<T> ==========\n");

            BasicOperations();

            SearchingOperations();

            SortingOperations();

            ConversionOperations();

            Console.WriteLine("\n=============================");
        }

        //---------------------------------------------------------
        // Add - Insert - Remove - Clear
        //---------------------------------------------------------
        static void BasicOperations()
        {
            Console.WriteLine("========== Basic Operations ==========");

            List<int> numbers = new List<int>();

            //-------------------------------------------------
            // Add
            //-------------------------------------------------

            numbers.Add(10);
            numbers.Add(20);
            numbers.Add(30);
            numbers.Add(40);

            Console.WriteLine("After Add():");

            Print(numbers);

            //-------------------------------------------------
            // AddRange
            //-------------------------------------------------

            numbers.AddRange(new List<int> { 50, 60, 70 });

            Console.WriteLine("\nAfter AddRange():");

            Print(numbers);

            //-------------------------------------------------
            // Insert
            //-------------------------------------------------

            numbers.Insert(2, 100);

            Console.WriteLine("\nAfter Insert():");

            Print(numbers);

            //-------------------------------------------------
            // InsertRange
            //-------------------------------------------------

            numbers.InsertRange(1, new List<int> { 1, 2, 3 });

            Console.WriteLine("\nAfter InsertRange():");

            Print(numbers);

            //-------------------------------------------------
            // Remove
            //-------------------------------------------------

            numbers.Remove(2);

            Console.WriteLine("\nAfter Remove(20):");

            Print(numbers);


            //-------------------------------------------------
            // RemoveAt
            //-------------------------------------------------

            numbers.RemoveAt(0);

            Console.WriteLine("\nAfter RemoveAt(0):");

            Print(numbers);

            //-------------------------------------------------
            // RemoveRange
            //-------------------------------------------------

            numbers.RemoveRange(0, 2);

            Console.WriteLine("\nAfter RemoveRange():");

            Print(numbers);

            //-------------------------------------------------
            // RemoveAll
            //-------------------------------------------------
            numbers.AddRange([23, 45, 40,44,67]);
            Console.WriteLine("\nBefore RemoveAll(20):");

            Print(numbers);
            numbers.RemoveAll(x=> x>40);

            Console.WriteLine("\nAfter RemoveAll(20):");

            Print(numbers);

            //-------------------------------------------------
            // Count
            //-------------------------------------------------

            Console.WriteLine($"\nCount : {numbers.Count}");

            //-------------------------------------------------
            // Clear
            //-------------------------------------------------

            numbers.Clear();

            Console.WriteLine($"Count After Clear : {numbers.Count}");

            Console.WriteLine();
        }

        //---------------------------------------------------------
        // Search Operations
        //---------------------------------------------------------
        static void SearchingOperations()
        {
            Console.WriteLine("========== Searching ==========");

            List<int> numbers = new List<int>()
            {
                10,
                20,
                30,
                20,
                40,
                50
            };

            Print(numbers);

            Console.WriteLine();

            Console.WriteLine($"Contains(30)     : {numbers.Contains(30)}");

            Console.WriteLine($"Contains(100)    : {numbers.Contains(100)}");

            Console.WriteLine($"IndexOf(20)      : {numbers.IndexOf(20)}");

            Console.WriteLine($"LastIndexOf(20)  : {numbers.LastIndexOf(20)}");

            Console.WriteLine();

            //-------------------------------------------------
            // Exists
            //-------------------------------------------------

            bool exists = numbers.Exists(x => x > 40);

            Console.WriteLine($"Exists > 40 : {exists}");

            //-------------------------------------------------
            // Find
            //-------------------------------------------------

            int value = numbers.Find(x => x > 25);

            Console.WriteLine($"Find > 25 : {value}");

            //-------------------------------------------------
            // FindAll
            //-------------------------------------------------

            List<int> result = numbers.FindAll(x => x % 20 == 0);

            Console.WriteLine("FindAll (Divisible By 20)");

            Print(result);

            Console.WriteLine();
        }

        //---------------------------------------------------------
        // Sort - Reverse
        //---------------------------------------------------------
        static void SortingOperations()
        {
            Console.WriteLine("========== Sort ==========");

            List<int> numbers = new List<int>()
            {
                50,
                20,
                90,
                10,
                40,
                70
            };

            Console.WriteLine("Original:");

            Print(numbers);

            //-------------------------------------------------
            // Sort
            //-------------------------------------------------

            numbers.Sort();

            Console.WriteLine("\nAfter Sort():");

            Print(numbers);

            //-------------------------------------------------
            // Reverse
            //-------------------------------------------------

            numbers.Reverse();

            Console.WriteLine("\nAfter Reverse():");

            Print(numbers);

            Console.WriteLine();

            //-------------------------------------------------
            // Custom Sort
            //-------------------------------------------------

            numbers.Sort((a, b) => b.CompareTo(a));

            Console.WriteLine("Descending:");

            Print(numbers);

            Console.WriteLine();
        }

        //---------------------------------------------------------
        // Conversion
        //---------------------------------------------------------
        static void ConversionOperations()
        {
            Console.WriteLine("========== Conversion ==========");

            List<int> numbers = new List<int>()
            {
                10,
                20,
                30,
                40,
                50
            };

            //-------------------------------------------------
            // ToArray
            //-------------------------------------------------

            int[] array = numbers.ToArray();

            Console.WriteLine("Array:");

            foreach (int item in array)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine();

            //-------------------------------------------------
            // CopyTo
            //-------------------------------------------------

            int[] destination = new int[numbers.Count];

            numbers.CopyTo(destination);

            Console.WriteLine("\nCopied Array:");

            foreach (int item in destination)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine();

            //-------------------------------------------------
            // Clone (Alternative)
            //-------------------------------------------------

            List<int> copy = new List<int>(numbers);

            Console.WriteLine("\nCopied List:");

            Print(copy);

            Console.WriteLine();
        }

        //---------------------------------------------------------
        // Print List
        //---------------------------------------------------------
        static void Print(List<int> list)
        {
            foreach (int item in list)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine();
        }
    }
}