
namespace CsharpFundamentals.CsharpBasics
{
    using System;
    using System.Linq;

    class Arrays
    {
        public static void Run()
        {
            ArrayDeclaration();
            ArrayInitialization();
            AccessingElements();
            ModifyingElements();
            ArrayLength();
            IteratingArrays();

            MultidimensionalArrays();
            JaggedArrays();

            ArrayCopying();
            ArraySorting();
            ArrayReversing();
            ArraySearching();

            ArrayMinMaxSumAverage();

            PassingArraysToMethods();

            ParamsKeyword();

            ArrayClassMethods();
        }

        static void ArrayDeclaration()
        {
            Console.WriteLine("\n=== Array Declaration ===");

            int[] numbers;

            string[] names;

            double[] grades;
        }

        static void ArrayInitialization()
        {
            Console.WriteLine("\n=== Array Initialization ===");

            int[] numbers = new int[5];

            int[] values = { 10, 20, 30, 40, 50 };

            string[] names =
            {
            "Ahmed",
            "Ali",
            "Omar"
        };

            Console.WriteLine(values[0]);
            Console.WriteLine(names[1]);
        }

        static void AccessingElements()
        {
            Console.WriteLine("\n=== Accessing Elements ===");

            int[] numbers = { 10, 20, 30, 40, 50 };

            Console.WriteLine(numbers[0]);

            Console.WriteLine(numbers[2]);

            Console.WriteLine(numbers[^1]); // Last Element

            Console.WriteLine(numbers[^2]); // Second From End
        }

        static void ModifyingElements()
        {
            Console.WriteLine("\n=== Modifying Elements ===");

            int[] numbers = { 10, 20, 30 };

            numbers[1] = 999;

            Console.WriteLine(numbers[1]);
        }

        static void ArrayLength()
        {
            Console.WriteLine("\n=== Array Length ===");

            int[] numbers = { 1, 2, 3, 4, 5 };

            Console.WriteLine(numbers.Length);
        }

        static void IteratingArrays()
        {
            Console.WriteLine("\n=== Iterating Arrays ===");

            int[] numbers = { 10, 20, 30, 40, 50 };

            Console.WriteLine("For Loop");

            for (int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine(numbers[i]);
            }

            Console.WriteLine("Foreach Loop");

            foreach (int number in numbers)
            {
                Console.WriteLine(number);
            }
        }

        static void MultidimensionalArrays()
        {
            Console.WriteLine("\n=== Multidimensional Arrays ===");

            int[,] matrix =
            {
            {1,2,3},
            {4,5,6}
        };

            Console.WriteLine(matrix[0, 0]);

            Console.WriteLine(matrix[1, 2]);

            Console.WriteLine(matrix.GetLength(0)); // Rows

            Console.WriteLine(matrix.GetLength(1)); // Columns
        }

        static void JaggedArrays()
        {
            Console.WriteLine("\n=== Jagged Arrays ===");

            int[][] numbers =
            {
            new int[] {1,2},
            new int[] {3,4,5},
            new int[] {6,7,8,9}
        };

            Console.WriteLine(numbers[0][1]);

            Console.WriteLine(numbers[2][3]);
        }

        static void ArrayCopying()
        {
            Console.WriteLine("\n=== Array Copying ===");

            int[] source = { 1, 2, 3, 4, 5 };

            int[] destination = new int[source.Length];

            Array.Copy(source, destination, source.Length);

            foreach (int item in destination)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine();
        }

        static void ArraySorting()
        {
            Console.WriteLine("\n=== Array Sorting ===");

            int[] numbers = { 5, 1, 3, 2, 4 };

            Array.Sort(numbers);

            foreach (int item in numbers)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine();
        }

        static void ArrayReversing()
        {
            Console.WriteLine("\n=== Array Reversing ===");

            int[] numbers = { 1, 2, 3, 4, 5 };
            // this will not work because the Reverse() method is an extension method of the IEnumerable<T> interface
            // and it returns a new sequence in reverse order, but it does not modify the original array.
            //numbers.Reverse();

            // to reverse the array in place, we can use the Array.Reverse() method
            Array.Reverse(numbers);

            foreach (int item in numbers)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine();
        }

        static void ArraySearching()
        {
            Console.WriteLine("\n=== Array Searching ===");

            int[] numbers = { 10, 20, 30, 40, 50 };

            Console.WriteLine(Array.IndexOf(numbers, 30));
            Console.WriteLine(numbers.IndexOf(30));

            Console.WriteLine(Array.IndexOf(numbers, 999));

            Console.WriteLine(Array.BinarySearch(numbers, 40));
        }

        static void ArrayMinMaxSumAverage()
        {
            Console.WriteLine("\n=== LINQ Operations ===");

            int[] numbers = { 10, 20, 30, 40, 50 };

            Console.WriteLine(numbers.Min());

            Console.WriteLine(numbers.Max());

            Console.WriteLine(numbers.Sum());

            Console.WriteLine(numbers.Average());
        }

        static void PassingArraysToMethods()
        {
            Console.WriteLine("\n=== Passing Arrays To Methods ===");

            int[] numbers = { 10, 20, 30 };
            Console.WriteLine($"arr[0] before the PrintArray function is {numbers[0]}");
            // When we pass an array to a method, we are passing a reference to the array, not a copy of the array.
            //so when we modify the array inside the method, we are modifying the original array.
            PrintArray(numbers);
            Console.WriteLine($"arr[0] after the PrintArray function is {numbers[0]}");
        }

        static void PrintArray(int[] arr)
        {
            foreach (int item in arr)
            {
                Console.WriteLine(item);
            }
            arr[0] = 100;
            Console.WriteLine($"arr[0] in the PrintArray function is {arr[0]}");
        }

        static void ParamsKeyword()
        {
            Console.WriteLine("\n=== Params Keyword ===");

            int result = Sum(1, 2, 3, 4, 5);

            Console.WriteLine(result);
        }
        // The params keyword allows you to pass a variable number of arguments to a method.

        static int Sum(params int[] numbers)
        {
            int sum = 0;

            foreach (int number in numbers)
            {
                sum += number;
            }

            return sum;
        }

        static void ArrayClassMethods()
        {
            Console.WriteLine("\n=== Array Class Methods ===");

            int[] numbers = { 5, 2, 8, 1, 9 };

            Console.WriteLine(Array.Exists(numbers, n => n > 7));

            Console.WriteLine(Array.Find(numbers, n => n > 7));

            Console.WriteLine(Array.FindIndex(numbers, n => n == 8));

            Console.WriteLine(Array.TrueForAll(numbers, n => n > 0));
        }
    }
}
