// ITI LECTURE - C# Fundamentals - LinkedList<T>
// File - LinkedListBasics.cs

namespace CsharpFundamentals.DataStructures
{
    internal class LinkedListBasics
    {
        public static void Run()
        {
            Console.WriteLine("========== LINKEDLIST<T> ==========\n");

            BasicOperations();

            SearchingOperations();

            TraversalOperations();

            ConversionOperations();

            Console.WriteLine("\n===================================");
        }

        //---------------------------------------------------------
        // AddFirst - AddLast - AddBefore - AddAfter - Remove
        //---------------------------------------------------------
        static void BasicOperations()
        {
            Console.WriteLine("========== Basic Operations ==========");

            LinkedList<int> numbers = new LinkedList<int>();

            //-------------------------------------------------
            // AddLast
            //-------------------------------------------------

            numbers.AddLast(10);
            numbers.AddLast(20);
            numbers.AddLast(30);
            numbers.AddLast(40);

            Console.WriteLine("After AddLast():");

            Print(numbers);

            //-------------------------------------------------
            // AddFirst
            //-------------------------------------------------

            numbers.AddFirst(5);

            Console.WriteLine("\nAfter AddFirst():");

            Print(numbers);

            //-------------------------------------------------
            // AddAfter
            //-------------------------------------------------

            LinkedListNode<int>? node20 = numbers.Find(20);

            if (node20 != null)
            {
                numbers.AddAfter(node20, 25);
            }

            Console.WriteLine("\nAfter AddAfter(20, 25):");

            Print(numbers);

            //-------------------------------------------------
            // AddBefore
            //-------------------------------------------------

            LinkedListNode<int>? node30 = numbers.Find(30);

            if (node30 != null)
            {
                numbers.AddBefore(node30, 27);
            }

            Console.WriteLine("\nAfter AddBefore(30, 27):");

            Print(numbers);

            //-------------------------------------------------
            // Remove By Value
            //-------------------------------------------------

            numbers.Remove(20);

            Console.WriteLine("\nAfter Remove(20):");

            Print(numbers);

            //-------------------------------------------------
            // RemoveFirst
            //-------------------------------------------------

            numbers.RemoveFirst();

            Console.WriteLine("\nAfter RemoveFirst():");

            Print(numbers);

            //-------------------------------------------------
            // RemoveLast
            //-------------------------------------------------

            numbers.RemoveLast();

            Console.WriteLine("\nAfter RemoveLast():");

            Print(numbers);

            //-------------------------------------------------
            // Count
            //-------------------------------------------------

            Console.WriteLine($"\nCount : {numbers.Count}");

            //-------------------------------------------------
            // First
            //-------------------------------------------------

            if (numbers.First != null)
            {
                Console.WriteLine($"First Value : {numbers.First.Value}");
            }

            //-------------------------------------------------
            // Last
            //-------------------------------------------------

            if (numbers.Last != null)
            {
                Console.WriteLine($"Last Value : {numbers.Last.Value}");
            }

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

            LinkedList<int> numbers = new LinkedList<int>(
                new int[]
                {
                    10,
                    20,
                    30,
                    20,
                    40,
                    50
                }
            );

            Print(numbers);

            Console.WriteLine();

            //-------------------------------------------------
            // Contains
            //-------------------------------------------------

            Console.WriteLine($"Contains(30)  : {numbers.Contains(30)}");

            Console.WriteLine($"Contains(100) : {numbers.Contains(100)}");

            //-------------------------------------------------
            // Find
            //-------------------------------------------------

            LinkedListNode<int>? first20 = numbers.Find(20);

            if (first20 != null)
            {
                Console.WriteLine($"Find(20)      : {first20.Value}");
            }

            //-------------------------------------------------
            // FindLast
            //-------------------------------------------------

            LinkedListNode<int>? last20 = numbers.FindLast(20);

            if (last20 != null)
            {
                Console.WriteLine($"FindLast(20)  : {last20.Value}");
            }

            Console.WriteLine();
        }

        //---------------------------------------------------------
        // Traversal Operations
        //---------------------------------------------------------
        static void TraversalOperations()
        {
            Console.WriteLine("========== Traversal ==========");

            LinkedList<int> numbers = new LinkedList<int>(
                new int[]
                {
                    10,
                    20,
                    30,
                    40,
                    50
                }
            );

            //-------------------------------------------------
            // Forward Traversal
            //-------------------------------------------------

            Console.WriteLine("Forward:");

            LinkedListNode<int>? current = numbers.First;

            while (current != null)
            {
                Console.Write(current.Value + " ");

                current = current.Next;
            }

            Console.WriteLine();

            //-------------------------------------------------
            // Backward Traversal
            //-------------------------------------------------

            Console.WriteLine("\nBackward:");

            current = numbers.Last;

            while (current != null)
            {
                Console.Write(current.Value + " ");

                current = current.Previous;
            }

            Console.WriteLine();
            Console.WriteLine();
        }

        //---------------------------------------------------------
        // Conversion
        //---------------------------------------------------------
        static void ConversionOperations()
        {
            Console.WriteLine("========== Conversion ==========");

            LinkedList<int> numbers = new LinkedList<int>(
                new int[]
                {
                    10,
                    20,
                    30,
                    40,
                    50
                }
            );

            //-------------------------------------------------
            // CopyTo
            //-------------------------------------------------

            int[] destination = new int[numbers.Count];

            numbers.CopyTo(destination, 0);

            Console.WriteLine("Copied Array:");

            foreach (int item in destination)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine();

            //-------------------------------------------------
            // Create List From LinkedList
            //-------------------------------------------------

            List<int> list = new List<int>(numbers);

            Console.WriteLine("\nConverted To List:");

            foreach (int item in list)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine();

            //-------------------------------------------------
            // Clone (Alternative)
            //-------------------------------------------------

            LinkedList<int> copy = new LinkedList<int>(numbers);

            Console.WriteLine("\nCopied LinkedList:");

            Print(copy);

            Console.WriteLine();
        }

        //---------------------------------------------------------
        // Print LinkedList
        //---------------------------------------------------------
        static void Print(LinkedList<int> list)
        {
            foreach (int item in list)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine();
        }
    }
}