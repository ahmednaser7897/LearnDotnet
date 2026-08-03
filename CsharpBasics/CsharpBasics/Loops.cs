namespace CsharpFundamentals.CsharpBasics
{
    using System;

    class Loops
    {
        public static void Run()
        {
            ForLoop();
            ForLoopMultipleVariables();
            NestedForLoop();

            WhileLoop();
            DoWhileLoop();

            ForeachLoop();

            BreakStatement();
            ContinueStatement();

            InfiniteLoop();

            LoopScopeExamples();
        }

        static void ForLoop()
        {
            Console.WriteLine("\n=== For Loop ===");

            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine(i);
            }
        }

        static void ForLoopMultipleVariables()
        {
            Console.WriteLine("\n=== For Loop Multiple Variables ===");

            for (int i = 1, j = 10; i <= 5; i++, j--)
            {
                Console.WriteLine($"i = {i}, j = {j}");
            }
        }

        static void NestedForLoop()
        {
            Console.WriteLine("\n=== Nested For Loop ===");

            for (int row = 1; row <= 3; row++)
            {
                for (int col = 1; col <= 3; col++)
                {
                    Console.Write($"{row},{col}  ");
                }

                Console.WriteLine();
            }
        }

        static void WhileLoop()
        {
            Console.WriteLine("\n=== While Loop ===");

            int i = 1;

            while (i <= 5)
            {
                Console.WriteLine(i);
                i++;
            }
        }

        static void DoWhileLoop()
        {
            Console.WriteLine("\n=== Do While Loop ===");

            int i = 1;

            do
            {
                Console.WriteLine(i);
                i++;
            }
            while (i <= 5);
        }

        static void ForeachLoop()
        {
            Console.WriteLine("\n=== Foreach Loop ===");

            string[] names =
            {
            "Ahmed",
            "Ali",
            "Omar"
        };

            foreach (string name in names)
            {
                Console.WriteLine(name);
            }
        }

        static void BreakStatement()
        {
            Console.WriteLine("\n=== Break Statement ===");

            for (int i = 1; i <= 10; i++)
            {
                if (i == 5)
                    break;

                Console.WriteLine(i);
            }
        }

        static void ContinueStatement()
        {
            Console.WriteLine("\n=== Continue Statement ===");

            for (int i = 1; i <= 10; i++)
            {
                if (i == 5)
                    continue;

                Console.WriteLine(i);
            }
        }

        static void InfiniteLoop()
        {
            Console.WriteLine("\n=== Infinite Loop ===");

            int counter = 0;

            while (true)
            {
                Console.WriteLine(counter);

                counter++;

                if (counter == 3)
                    break;
            }
        }

        static void LoopScopeExamples()
        {
            Console.WriteLine("\n=== Loop Scope Examples ===");

            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(i);
            }

            int x = 0;

            while (x < 3)
            {
                Console.WriteLine(x);
                x++;
            }
        }
    }
}
