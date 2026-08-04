// ITI LECTURE - C# Fundamentals - ArrayList
// File 1 - ArrayListBasics.cs

using System.Collections;

namespace CsharpFundamentals.DataStructures
{
    internal class ArrayListBasics
    {
        public static void Run()
        {
            Console.WriteLine("========== ARRAYLIST ==========\n");

            BasicOperations();

            SearchingOperations();

            SortingOperations();

            ConversionOperations();

            Console.WriteLine("\n===============================");
        }

        //---------------------------------------------------------
        // Add - Insert - Remove - Clear
        //---------------------------------------------------------
        static void BasicOperations()
        {
            Console.WriteLine("========== Basic Operations ==========");

            ArrayList list = new ArrayList();

            //-------------------------------------------------
            // Add
            //-------------------------------------------------

            list.Add(10);
            list.Add(20);
            list.Add(30);
            list.Add("Ahmed");
            list.Add(true);

            Console.WriteLine("After Add():");

            Print(list);

            //-------------------------------------------------
            // Insert
            //-------------------------------------------------

            list.Insert(1, 100);

            Console.WriteLine("\nAfter Insert():");

            Print(list);

            //-------------------------------------------------
            // Remove
            //-------------------------------------------------

            list.Remove(20);

            Console.WriteLine("\nAfter Remove(20):");

            Print(list);

            //-------------------------------------------------
            // RemoveAt
            //-------------------------------------------------

            list.RemoveAt(0);

            Console.WriteLine("\nAfter RemoveAt(0):");

            Print(list);

            //-------------------------------------------------
            // Contains
            //-------------------------------------------------

            Console.WriteLine();

            Console.WriteLine($"Contains Ahmed : {list.Contains("Ahmed")}");

            Console.WriteLine($"Contains 500   : {list.Contains(500)}");

            //-------------------------------------------------
            // Count
            //-------------------------------------------------

            Console.WriteLine();

            Console.WriteLine($"Count : {list.Count}");

            //-------------------------------------------------
            // Clear
            //-------------------------------------------------

            list.Clear();

            Console.WriteLine();

            Console.WriteLine($"Count After Clear : {list.Count}");

            Console.WriteLine();
        }

        //---------------------------------------------------------
        // IndexOf - LastIndexOf
        //---------------------------------------------------------
        static void SearchingOperations()
        {
            Console.WriteLine("========== Searching ==========");

            ArrayList list = new ArrayList()
            {
                10,
                20,
                30,
                20,
                40,
                50
            };

            Print(list);

            Console.WriteLine();

            Console.WriteLine($"IndexOf(20)     : {list.IndexOf(20)}");

            Console.WriteLine($"LastIndexOf(20) : {list.LastIndexOf(20)}");

            Console.WriteLine($"IndexOf(100)    : {list.IndexOf(100)}");

            Console.WriteLine();
        }

        //---------------------------------------------------------
        // Sort - Reverse
        //---------------------------------------------------------
        static void SortingOperations()
        {
            Console.WriteLine("========== Sort & Reverse ==========");

            ArrayList list = new ArrayList()
            {
                60,
                15,
                90,
                40,
                10,
                80
            };

            Console.WriteLine("Original:");

            Print(list);

            //-------------------------------------------------
            // Sort
            //-------------------------------------------------

            list.Sort();

            Console.WriteLine("\nAfter Sort():");

            Print(list);

            //-------------------------------------------------
            // Reverse
            //-------------------------------------------------

            list.Reverse();

            Console.WriteLine("\nAfter Reverse():");

            Print(list);

            Console.WriteLine();
        }

        //---------------------------------------------------------
        // ToArray - Clone
        //---------------------------------------------------------
        static void ConversionOperations()
        {
            Console.WriteLine("========== Conversion ==========");

            ArrayList list = new ArrayList()
            {
                10,
                20,
                30,
                40,
                50
            };

            //-------------------------------------------------
            // Clone
            //-------------------------------------------------

            ArrayList copy = (ArrayList)list.Clone();

            Console.WriteLine("Cloned List:");

            Print(copy);

            //-------------------------------------------------
            // ToArray
            //-------------------------------------------------

            object[] array = list.ToArray();

            Console.WriteLine();

            Console.WriteLine("Array:");

            foreach (object item in array)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine();

            Console.WriteLine();
        }

        //---------------------------------------------------------
        // Print ArrayList
        //---------------------------------------------------------
        static void Print(ArrayList list)
        {
            foreach (object item in list)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine();
        }
    }
}