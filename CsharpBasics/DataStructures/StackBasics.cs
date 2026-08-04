// ITI LECTURE - C# Fundamentals - Stack<T>
// File - StackBasics.cs

namespace CsharpFundamentals.DataStructures
{
    internal class StackBasics
    {
        public static void Run()
        {
            Console.WriteLine("========== STACK<T> ==========\n");

            BasicOperations();

            PeekContainsOperations();

            IterationOperations();

            ConversionOperations();

            Console.WriteLine("\n==============================");
        }

        //---------------------------------------------------------
        // Push - Pop - Clear
        //---------------------------------------------------------
        static void BasicOperations()
        {
            Console.WriteLine("========== Basic Operations ==========");

            Stack<int> numbers = new Stack<int>();

            //-------------------------------------------------
            // Push
            //-------------------------------------------------

            numbers.Push(10);
            numbers.Push(20);
            numbers.Push(30);
            numbers.Push(40);

            Console.WriteLine("After Push():");

            Print(numbers);

            //-------------------------------------------------
            // Pop
            //-------------------------------------------------

            int removed = numbers.Pop();

            Console.WriteLine($"\nPop() = {removed}");

            Console.WriteLine("After Pop():");

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
        // Peek - Contains - TryPeek - TryPop
        //---------------------------------------------------------
        static void PeekContainsOperations()
        {
            Console.WriteLine("========== Peek & Contains ==========");

            Stack<int> numbers = new Stack<int>();

            numbers.Push(10);
            numbers.Push(20);
            numbers.Push(30);
            numbers.Push(40);

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

            if (numbers.TryPeek(out int top))
            {
                Console.WriteLine($"TryPeek() = {top}");
            }

            //-------------------------------------------------
            // TryPop
            //-------------------------------------------------

            if (numbers.TryPop(out int value))
            {
                Console.WriteLine($"TryPop() = {value}");
            }

            Console.WriteLine();

            Console.WriteLine("After TryPop():");

            Print(numbers);

            Console.WriteLine();
        }

        //---------------------------------------------------------
        // foreach
        //---------------------------------------------------------
        static void IterationOperations()
        {
            Console.WriteLine("========== Iteration ==========");

            Stack<string> names = new Stack<string>();

            names.Push("Ahmed");
            names.Push("Ali");
            names.Push("Sara");
            names.Push("Mona");

            Console.WriteLine("Stack:");

            foreach (string name in names)
            {
                Console.WriteLine(name);
            }

            Console.WriteLine();

            Console.WriteLine("Notice:");

            Console.WriteLine("Stack is iterated from Top to Bottom.");

            Console.WriteLine();
        }

        //---------------------------------------------------------
        // ToArray - Copy - ToList
        //---------------------------------------------------------
        static void ConversionOperations()
        {
            Console.WriteLine("========== Conversion ==========");

            Stack<int> numbers = new Stack<int>();

            numbers.Push(10);
            numbers.Push(20);
            numbers.Push(30);
            numbers.Push(40);

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
            // Copy Stack
            //-------------------------------------------------

            Stack<int> copy = new Stack<int>(numbers);

            Console.WriteLine("\nCopied Stack:");

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
        // Print Stack
        //---------------------------------------------------------
        static void Print(Stack<int> stack)
        {
            foreach (int item in stack)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine();
        }
    }
}