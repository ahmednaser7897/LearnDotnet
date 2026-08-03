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
            RandomNumbers();
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

        static void RandomNumbers()
        {
            Console.WriteLine("\n=== Random Numbers ===");

            Random random = new Random();

            Console.WriteLine(random.Next());

            Console.WriteLine(random.Next(1, 11));

            Console.WriteLine(random.NextDouble());
        }
    }
}
