// ITI LECTURE - C# Fundamentals - Dictionary<TKey, TValue>
// File - DictionaryBasics.cs
namespace CsharpFundamentals.DataStructures
{
    internal class DictionaryBasics
    {
        public static void Run()
        {
            Console.WriteLine("========== Dictionary<TKey, TValue> ==========\n");

            BasicOperations();

            SearchingOperations();

            IterationOperations();

            ConversionOperations();

            Console.WriteLine("\n==============================================");
        }

        //---------------------------------------------------------
        // Add - Update - Remove - Clear
        //---------------------------------------------------------
        static void BasicOperations()
        {
            Console.WriteLine("========== Basic Operations ==========");

            Dictionary<int, string> students = new Dictionary<int, string>();

            //-------------------------------------------------
            // Add
            //-------------------------------------------------

            students.Add(101, "Ahmed");
            students.Add(102, "Ali");
            students.Add(103, "Sara");

            Console.WriteLine("After Add():");
            Print(students);

            //-------------------------------------------------
            // Update
            //-------------------------------------------------

            students[102] = "Mohamed";

            Console.WriteLine("\nAfter Update:");
            Print(students);

            //-------------------------------------------------
            // Add Using Indexer
            //-------------------------------------------------

            students[104] = "Mona";

            Console.WriteLine("\nAfter Adding With Indexer:");
            Print(students);

            //-------------------------------------------------
            // Remove
            //-------------------------------------------------

            students.Remove(101);

            Console.WriteLine("\nAfter Remove(101):");
            Print(students);

            //-------------------------------------------------
            // Count
            //-------------------------------------------------

            Console.WriteLine($"\nCount = {students.Count}");

            //-------------------------------------------------
            // Clear
            //-------------------------------------------------

            students.Clear();

            Console.WriteLine($"Count After Clear = {students.Count}");

            Console.WriteLine();
        }

        //---------------------------------------------------------
        // Contains - TryGetValue - Access By Key
        //---------------------------------------------------------
        static void SearchingOperations()
        {
            Console.WriteLine("========== Searching ==========");

            Dictionary<int, string> students = new Dictionary<int, string>()
            {
                {101,"Ahmed"},
                {102,"Ali"},
                {103,"Sara"},
                {104,"Mona"}
            };

            //-------------------------------------------------
            // ContainsKey
            //-------------------------------------------------

            Console.WriteLine($"ContainsKey(102) = {students.ContainsKey(102)}");
            Console.WriteLine($"ContainsKey(999) = {students.ContainsKey(999)}");

            //-------------------------------------------------
            // ContainsValue
            //-------------------------------------------------

            Console.WriteLine();

            Console.WriteLine($"ContainsValue(\"Sara\") = {students.ContainsValue("Sara")}");
            Console.WriteLine($"ContainsValue(\"Omar\") = {students.ContainsValue("Omar")}");

            //-------------------------------------------------
            // TryGetValue
            //-------------------------------------------------

            Console.WriteLine();

            if (students.TryGetValue(103, out string? student))
            {
                Console.WriteLine($"Student 103 = {student}");
            }

            if (!students.TryGetValue(999, out _))
            {
                Console.WriteLine("Key 999 Not Found");
            }

            //-------------------------------------------------
            // Access Using Key
            //-------------------------------------------------

            Console.WriteLine();

            Console.WriteLine($"Student 101 = {students[101]}");

            Console.WriteLine();
        }

        //---------------------------------------------------------
        // foreach - Keys - Values
        //---------------------------------------------------------
        static void IterationOperations()
        {
            Console.WriteLine("========== Iteration ==========");

            Dictionary<int, string> students = new Dictionary<int, string>()
            {
                {101,"Ahmed"},
                {102,"Ali"},
                {103,"Sara"},
                {104,"Mona"}
            };

            //-------------------------------------------------
            // foreach
            //-------------------------------------------------

            Console.WriteLine("Dictionary:");

            foreach (KeyValuePair<int, string> item in students)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }

            //-------------------------------------------------
            // Keys
            //-------------------------------------------------

            Console.WriteLine("\nKeys:");

            foreach (int key in students.Keys)
            {
                Console.WriteLine(key);
            }

            //-------------------------------------------------
            // Values
            //-------------------------------------------------

            Console.WriteLine("\nValues:");

            foreach (string value in students.Values)
            {
                Console.WriteLine(value);
            }

            Console.WriteLine();
        }

        //---------------------------------------------------------
        // Copy - ToArray
        //---------------------------------------------------------
        static void ConversionOperations()
        {
            Console.WriteLine("========== Conversion ==========");

            Dictionary<int, string> students = new Dictionary<int, string>()
            {
                {101,"Ahmed"},
                {102,"Ali"},
                {103,"Sara"}
            };

            //-------------------------------------------------
            // Copy Dictionary
            //-------------------------------------------------

            Dictionary<int, string> copy =
                new Dictionary<int, string>(students);

            Console.WriteLine("Copied Dictionary:");

            Print(copy);

            //-------------------------------------------------
            // Keys To Array
            //-------------------------------------------------

            int[] keys = new int[students.Count];

            students.Keys.CopyTo(keys, 0);

            Console.WriteLine("\nKeys Array:");

            foreach (int key in keys)
            {
                Console.Write(key + " ");
            }

            Console.WriteLine();

            //-------------------------------------------------
            // Values To Array
            //-------------------------------------------------

            string[] values = new string[students.Count];

            students.Values.CopyTo(values, 0);

            Console.WriteLine("\nValues Array:");

            foreach (string value in values)
            {
                Console.Write(value + " ");
            }

            Console.WriteLine();

            //-------------------------------------------------
            // Dictionary To List
            //-------------------------------------------------

            List<KeyValuePair<int, string>> list =
                new List<KeyValuePair<int, string>>(students);

            Console.WriteLine("\nDictionary As List:");

            foreach (KeyValuePair<int, string> item in list)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }

            Console.WriteLine();
        }

        //---------------------------------------------------------
        // Print Dictionary
        //---------------------------------------------------------
        static void Print(Dictionary<int, string> dictionary)
        {
            foreach (KeyValuePair<int, string> item in dictionary)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}