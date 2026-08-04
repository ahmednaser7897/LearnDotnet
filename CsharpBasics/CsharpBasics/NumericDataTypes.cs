namespace CsharpFundamentals.CsharpBasics
{
    using System;

    class NumericDataTypes
    {
        public static void Run()
        {
            NumericTypesInfo();
            IntegerTypes();
            FloatingPointTypes();
            DecimalType();
            MinMaxValues();
            TypeCasting();
            ArithmeticOperators();
            IncrementDecrement();
            DivisionExamples();
            ModulusOperator();
            MathClassExamples();
            ParsingNumbers();
            NumberFormatting();
            CheckedUnchecked();
            RandomClassMethods();
        }

        static void NumericTypesInfo()
        {
            Console.WriteLine("\n=== Numeric Types Info ===");

            Console.WriteLine($"byte   : {sizeof(byte)} bytes");
            Console.WriteLine($"sbyte  : {sizeof(sbyte)} bytes");
            Console.WriteLine($"short  : {sizeof(short)} bytes");
            Console.WriteLine($"ushort : {sizeof(ushort)} bytes");
            Console.WriteLine($"int    : {sizeof(int)} bytes");
            Console.WriteLine($"uint   : {sizeof(uint)} bytes");
            Console.WriteLine($"long   : {sizeof(long)} bytes");
            Console.WriteLine($"ulong  : {sizeof(ulong)} bytes");
            Console.WriteLine($"float  : {sizeof(float)} bytes");
            Console.WriteLine($"double : {sizeof(double)} bytes");
            Console.WriteLine($"decimal: {sizeof(decimal)} bytes");
        }

        static void IntegerTypes()
        {
            Console.WriteLine("\n=== Integer Types ===");

            byte b = 255;
            short s = 32000;
            int i = 100000;
            long l = 10000000000L;

            Console.WriteLine($"byte  = {b}");
            Console.WriteLine($"short = {s}");
            Console.WriteLine($"int   = {i}");
            Console.WriteLine($"long  = {l}");
        }

        static void FloatingPointTypes()
        {
            Console.WriteLine("\n=== Floating Point Types ===");

            float f = 10.5f;
            double d = 10.5;

            Console.WriteLine($"float  = {f}");
            Console.WriteLine($"double = {d}");
        }

        static void DecimalType()
        {
            Console.WriteLine("\n=== Decimal Type ===");

            decimal money = 10.99m;

            Console.WriteLine($"decimal = {money}");

            // يستخدم غالباً في التطبيقات المالية
        }

        static void MinMaxValues()
        {
            Console.WriteLine("\n=== Min / Max Values ===");

            Console.WriteLine($"int.MinValue = {int.MinValue}");
            Console.WriteLine($"int.MaxValue = {int.MaxValue}");

            Console.WriteLine($"long.MinValue = {long.MinValue}");
            Console.WriteLine($"long.MaxValue = {long.MaxValue}");

            Console.WriteLine($"double.MinValue = {double.MinValue}");
            Console.WriteLine($"double.MaxValue = {double.MaxValue}");
        }

        static void TypeCasting()
        {
            Console.WriteLine("\n=== Type Casting ===");

            int x = 100;

            long y = x; // Implicit

            Console.WriteLine($"long y = {y}");

            double d = 123.75;

            int n = (int)d; // Explicit

            Console.WriteLine($"int n = {n}");
        }

        static void ArithmeticOperators()
        {
            Console.WriteLine("\n=== Arithmetic Operators ===");

            int a = 10;
            int b = 3;

            Console.WriteLine($"a + b = {a + b}");
            Console.WriteLine($"a - b = {a - b}");
            Console.WriteLine($"a * b = {a * b}");
            Console.WriteLine($"a / b = {a / b}");
            Console.WriteLine($"a % b = {a % b}");
        }

        static void IncrementDecrement()
        {
            Console.WriteLine("\n=== Increment / Decrement ===");

            int x = 5;

            Console.WriteLine($"x = {x}");

            Console.WriteLine($"x++ = {x++}");
            Console.WriteLine($"after x++ = {x}");

            Console.WriteLine($"++x = {++x}");

            Console.WriteLine($"x-- = {x--}");
            Console.WriteLine($"after x-- = {x}");

            Console.WriteLine($"--x = {--x}");
        }

        static void DivisionExamples()
        {
            Console.WriteLine("\n=== Division ===");

            int a = 10;
            int b = 3;

            Console.WriteLine(a / b);

            Console.WriteLine((double)a / b);
        }

        static void ModulusOperator()
        {
            Console.WriteLine("\n=== Modulus Operator ===");

            Console.WriteLine(10 % 3);

            Console.WriteLine(20 % 2);

            Console.WriteLine(25 % 2);
        }

        static void MathClassExamples()
        {
            Console.WriteLine("\n=== Math Class ===");

            Console.WriteLine($"Abs(-5) = {Math.Abs(-5)}");

            Console.WriteLine($"Pow(2,3) = {Math.Pow(2, 3)}");

            Console.WriteLine($"Sqrt(25) = {Math.Sqrt(25)}");

            Console.WriteLine($"Round(10.6) = {Math.Round(10.6)}");

            Console.WriteLine($"Floor(10.9) = {Math.Floor(10.9)}");

            Console.WriteLine($"Ceiling(10.1) = {Math.Ceiling(10.1)}");

            Console.WriteLine($"Max(5,10) = {Math.Max(5, 10)}");

            Console.WriteLine($"Min(5,10) = {Math.Min(5, 10)}");
        }

        static void ParsingNumbers()
        {
            Console.WriteLine("\n=== Parsing Numbers ===");

            int number = int.Parse("123");

            Console.WriteLine(number);

            double price = double.Parse("10.5");

            Console.WriteLine(price);

            if (int.TryParse("456", out int result))
            {
                Console.WriteLine(result);
            }
        }

        static void NumberFormatting()
        {
            Console.WriteLine("\n=== Number Formatting ===");

            double number = 12345.6789;

            Console.WriteLine(number.ToString("F2"));

            Console.WriteLine(number.ToString("N"));

            Console.WriteLine(number.ToString("E"));

            Console.WriteLine(number.ToString("P"));
        }

        static void CheckedUnchecked()
        {
            Console.WriteLine("\n=== Checked / Unchecked ===");

            try
            {
                checked
                {
                    int x = int.MaxValue;
                    x++;

                    Console.WriteLine(x);
                }
            }
            catch (OverflowException)
            {
                Console.WriteLine("Overflow detected");
            }

            unchecked
            {
                int x = int.MaxValue;
                x++;

                Console.WriteLine($"Unchecked = {x}");
            }
        }

        static void RandomClassMethods()
        {
            Console.WriteLine("\n========== Random Class ==========");

            // Create a Random object
            Random random = new Random();

            // Random integer (0 to int.MaxValue)
            int value1 = random.Next();
            Console.WriteLine($"Next() = {value1}");

            // Random integer from 0 to 9
            int value2 = random.Next(10);
            Console.WriteLine($"Next(10) = {value2}");

            // Random integer from 10 to 20 (20 is excluded)
            int value3 = random.Next(10, 20);
            Console.WriteLine($"Next(10, 20) = {value3}");

            // Random double between 0.0 and 1.0
            double value4 = random.NextDouble();
            Console.WriteLine($"NextDouble() = {value4}");

            // Random double between 1 and 100
            double value5 = random.NextDouble() * 99 + 1;
            Console.WriteLine($"Random double (1-100) = {value5:F2}");

            // Random byte array
            byte[] bytes = new byte[5];
            random.NextBytes(bytes);

            Console.Write("NextBytes() = ");
            foreach (byte b in bytes)
            {
                Console.Write($"{b} ");
            }
            Console.WriteLine();

            // Generate a random lowercase letter
            char randomLetter = (char)random.Next('a', 'z' + 1);
            Console.WriteLine($"Random Letter = {randomLetter}");

            // Generate a random uppercase letter
            char randomUpper = (char)random.Next('A', 'Z' + 1);
            Console.WriteLine($"Random Upper Letter = {randomUpper}");

            // Random boolean
            bool randomBool = random.Next(2) == 1;
            Console.WriteLine($"Random Boolean = {randomBool}");

            // Simulate rolling a dice
            int dice = random.Next(1, 7);
            Console.WriteLine($"Dice Roll = {dice}");

            // Simulate flipping a coin
            string coin = random.Next(2) == 0 ? "Heads" : "Tails";
            Console.WriteLine($"Coin Flip = {coin}");
        }
    }
}
