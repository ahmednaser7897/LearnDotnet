namespace CsharpFundamentals.CsharpBasics
{

    class Selections
    {
        public static void Run()
        {
            IfStatement();
            IfElseStatement();
            ElseIfLadder();
            NestedIfStatement();
            TernaryOperator();
            SwitchStatement();
            SwitchExpression();
            PatternMatching();
            NullChecks();
            NullCoalescing();
            AdvancedPatterns();
        }


        static void IfStatement()
        {
            Console.WriteLine("\n=== If Statement ===");

            int age = 20;

            if (age >= 18)
            {
                Console.WriteLine("Adult");
            }
        }

        static void IfElseStatement()
        {
            Console.WriteLine("\n=== If Else Statement ===");

            int age = 15;

            if (age >= 18)
            {
                Console.WriteLine("Adult");
            }
            else
            {
                Console.WriteLine("Minor");
            }
        }

        static void ElseIfLadder()
        {
            Console.WriteLine("\n=== Else If Ladder ===");

            int score = 85;

            if (score >= 90)
                Console.WriteLine("A");
            else if (score >= 80)
                Console.WriteLine("B");
            else if (score >= 70)
                Console.WriteLine("C");
            else if (score >= 60)
                Console.WriteLine("D");
            else
                Console.WriteLine("F");
        }

        static void NestedIfStatement()
        {
            Console.WriteLine("\n=== Nested If Statement ===");

            int age = 25;
            bool hasLicense = true;

            if (age >= 18)
            {
                if (hasLicense)
                {
                    Console.WriteLine("Can Drive");
                }
                else
                {
                    Console.WriteLine("Need License");
                }
            }
        }

        static void TernaryOperator()
        {
            Console.WriteLine("\n=== Ternary Operator ===");

            int age = 20;

            string result =
                age >= 18
                    ? "Adult"
                    : "Minor";

            Console.WriteLine(result);
        }

        static void SwitchStatement()
        {
            Console.WriteLine("\n=== Switch Statement ===");

            int day = 2;

            switch (day)
            {
                case 1:
                    Console.WriteLine("Saturday");
                    break;

                case 2:
                    Console.WriteLine("Sunday");
                    break;

                case 3:
                    Console.WriteLine("Monday");
                    break;

                default:
                    Console.WriteLine("Unknown");
                    break;
            }
        }

        static void SwitchExpression()
        {
            Console.WriteLine("\n=== Switch Expression ===");

            int day = 3;

            string result = day switch
            {
                1 => "Saturday",
                2 => "Sunday",
                3 => "Monday",
                _ => "Unknown"
            };

            Console.WriteLine(result);
        }

        static void PatternMatching()
        {
            Console.WriteLine("\n=== Pattern Matching ===");

            object value = 100;

            if (value is int number)
            {
                Console.WriteLine(number);
            }

            object nameObj = "Ahmed";

            if (nameObj is string name)
            {
                Console.WriteLine(name);
            }
        }

        static void NullChecks()
        {
            Console.WriteLine("\n=== Null Checks ===");

            string? text = null;

            if (text is null)
            {
                Console.WriteLine("Null");
            }

            if (text is not null)
            {
                Console.WriteLine(text);
            }
        }

        static void NullCoalescing()
        {
            Console.WriteLine("\n=== Null Coalescing ===");

            string? name = null;

            string result = name ?? "Unknown";

            Console.WriteLine(result);

            name ??= "Default Name";

            Console.WriteLine(name);
        }

        static void AdvancedPatterns()
        {
            Console.WriteLine("\n=== Advanced Patterns ===");

            int score = 85;

            string grade = score switch
            {
                >= 90 => "A",
                >= 80 => "B",
                >= 70 => "C",
                >= 60 => "D",
                _ => "F"
            };

            Console.WriteLine(grade);

            object obj = "Ahmed";

            if (obj is string { Length: > 3 } value)
            {
                Console.WriteLine(value);
            }
        }
    }
}
