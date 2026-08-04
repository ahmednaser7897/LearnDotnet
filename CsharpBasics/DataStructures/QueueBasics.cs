// ITI LECTURE - C# Fundamentals - Queue<T>
// File - QueueBasics.cs

namespace CsharpFundamentals.DataStructures
{
    internal class QueueBasics
    {
        public static void Run()
        {
            Console.WriteLine("========== QUEUE<T> ==========\n");

            BasicOperations();

            PeekContainsOperations();

            IterationOperations();

            ConversionOperations();

            Console.WriteLine("\n==============================");
        }

        //---------------------------------------------------------
        // Enqueue - Dequeue - Clear
        //---------------------------------------------------------
        static void BasicOperations()
        {
            Console.WriteLine("========== Basic Operations ==========");

            Queue<int> numbers = new Queue<int>();

            //-------------------------------------------------
            // Enqueue
            //-------------------------------------------------

            numbers.Enqueue(10);
            numbers.Enqueue(20);
            numbers.Enqueue(30);
            numbers.Enqueue(40);

            Console.WriteLine("After Enqueue():");

            Print(numbers);

            //-------------------------------------------------
            // Dequeue
            //-------------------------------------------------

            int removed = numbers.Dequeue();

            Console.WriteLine($"\nDequeue() = {removed}");

            Console.WriteLine("After Dequeue():");

            Print(numbers);

            //-------------------------------------------------
            // Count
            //-------------------------------------------------

            Console.WriteLine($"\nCount = {numbers.Count}");

            //-------------------------------------------------
            // Clear
            //-------------------------------------------------

            numbers.Clear();

            Console.WriteLine($"Count After Clear = {numbers.Count}");

            Console.WriteLine();
        }

        //---------------------------------------------------------
        // Peek - Contains - TryPeek - TryDequeue
        //---------------------------------------------------------
        static void PeekContainsOperations()
        {
            Console.WriteLine("========== Peek & Contains ==========");

            Queue<int> numbers = new Queue<int>();

            numbers.Enqueue(10);
            numbers.Enqueue(20);
            numbers.Enqueue(30);
            numbers.Enqueue(40);

            //-------------------------------------------------
            // Peek
            //-------------------------------------------------

            Console.WriteLine($"Peek() = {numbers.Peek()}");

            //-------------------------------------------------
            // Contains
            //-------------------------------------------------

            Console.WriteLine();

            Console.WriteLine($"Contains(20) = {numbers.Contains(20)}");
            Console.WriteLine($"Contains(100) = {numbers.Contains(100)}");

            //-------------------------------------------------
            // TryPeek
            //-------------------------------------------------

            Console.WriteLine();

            if (numbers.TryPeek(out int front))
            {
                Console.WriteLine($"TryPeek() = {front}");
            }

            //-------------------------------------------------
            // TryDequeue
            //-------------------------------------------------

            if (numbers.TryDequeue(out int value))
            {
                Console.WriteLine($"TryDequeue() = {value}");
            }

            Console.WriteLine();

            Console.WriteLine("After TryDequeue():");

            Print(numbers);

            Console.WriteLine();
        }

        //---------------------------------------------------------
        // foreach
        //---------------------------------------------------------
        static void IterationOperations()
        {
            Console.WriteLine("========== Iteration ==========");

            Queue<string> names = new Queue<string>();

            names.Enqueue("Ahmed");
            names.Enqueue("Ali");
            names.Enqueue("Sara");
            names.Enqueue("Mona");

            Console.WriteLine("Queue:");

            foreach (string name in names)
            {
                Console.WriteLine(name);
            }

            Console.WriteLine();

            Console.WriteLine("Notice:");

            Console.WriteLine("Queue is iterated from Front to Rear.");

            Console.WriteLine();
        }

        //---------------------------------------------------------
        // ToArray - Copy - ToList
        //---------------------------------------------------------
        static void ConversionOperations()
        {
            Console.WriteLine("========== Conversion ==========");

            Queue<int> numbers = new Queue<int>();

            numbers.Enqueue(10);
            numbers.Enqueue(20);
            numbers.Enqueue(30);
            numbers.Enqueue(40);

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
            // Copy Queue
            //-------------------------------------------------

            Queue<int> copy = new Queue<int>(numbers);

            Console.WriteLine("\nCopied Queue:");

            Print(copy);

            //-------------------------------------------------
            // Convert To List
            //-------------------------------------------------

            List<int> list = new List<int>(numbers);

            Console.WriteLine("\nList:");

            foreach (int item in list)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine("\n");
        }

        //---------------------------------------------------------
        // Print Queue
        //---------------------------------------------------------
        static void Print(Queue<int> queue)
        {
            foreach (int item in queue)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine();
        }
    }
}