namespace CsharpFundamentals.CsharpBasics
{
    internal class Operators
    {
        public static void Run()
        {
            Console.WriteLine("Operators In C#");
            ArithmeticOperators();
            AssignmentOperators();
            ComparisonOperators();
            LogicalOperators();
            BitwiseOperators();
            Console.WriteLine("=======================================");
        }
        static void ArithmeticOperators()
        {
            Console.WriteLine("Arithmetic Operators");
            // +, -, *, /, % ,++ ,--
            int a = 10;
            int b = 3;
            Console.WriteLine($"a + b = {a + b}");
            Console.WriteLine($"a - b = {a - b}");
            Console.WriteLine($"a * b = {a * b}");
            Console.WriteLine($"a / b = {a / b}");
            Console.WriteLine($"a % b = {a % b}");
            Console.WriteLine($"a = {a}");
            Console.WriteLine($"a++ = {a++}");
            Console.WriteLine($"a = {a}");
            Console.WriteLine($"++a = {++a}");
            Console.WriteLine($"a = {a}");
            Console.WriteLine($"a-- = {a--}");
            Console.WriteLine($"a = {a}");
            Console.WriteLine($"a-- = {a--}");

        }
        static void AssignmentOperators()
        {
            Console.WriteLine("Assignment Operators");
            // = , +=, -=, *=, /=, %= ,&= , |=, ^=, <<=, >>=
            int a = 10;
            Console.WriteLine($"a = {a}");//10
            a += 5;
            Console.WriteLine($"a+= 5 = {a}");//15
            a -= 5;
            Console.WriteLine($"a-= 5 = {a}");//10
            a *= 5;
            Console.WriteLine($"a*= 5 = {a}");//50
            a /= 5;
            Console.WriteLine($"a/= 5 = {a}");//10
            a = 36;//100100
            Console.WriteLine($"a = {a}");//36
            a %= 5;//1
            Console.WriteLine($"a%= 5 = {a}");//1

            a &= 5;//100100 & 000101 = 000100
            Console.WriteLine($"a&= 5 = {a}");//4
            a |= 5;//000100 | 000101 = 000101
            Console.WriteLine($"a|= 5 = {a}");//5
            a ^= 5;//000100 ^ 000101 = 000001
            Console.WriteLine($"a^= 5 = {a}");//1
            a <<= 5;//000001 << 5 = 0100000
            Console.WriteLine($"a<<= 5 = {a}");//32
            a >>= 5;//0100000 >> 5 = 0000001
            Console.WriteLine($"a>>= 5 = {a}");//1
        }
        static void ComparisonOperators()
        {
            Console.WriteLine("Comparison Operators");
            // ==, !=, >, <, >=, <=, ?,
            int a = 10;
            int b = 3;

            Console.WriteLine($"a == b = {a == b}");
            Console.WriteLine($"a != b = {a != b}");
            Console.WriteLine($"a > b = {a > b}");
            Console.WriteLine($"a < b = {a < b}");
            Console.WriteLine($"a >= b = {a >= b}");
            Console.WriteLine($"a <= b = {a <= b}");
            Console.WriteLine($"a ? b : c = {(a == 10 ? b : 15)}");
        }
        static void LogicalOperators()
        {
            Console.WriteLine("Logical Operators");
            // &&, ||, !, 
            bool a = true;
            bool b = false;
            // This will execute the second operand only if the first operand is not enough to decide the result
            Console.WriteLine($"a && b = {a && b}");
            Console.WriteLine($"a || b = {a || b}");
            Console.WriteLine($"!a = {!a}");
            // Bitwise Logical Operators
            // This will always execute the second operand even the first decide the result
            Console.WriteLine($"a & b = {a & b}");
            Console.WriteLine($"a | b = {a | b}");
            //xor result true if the operands are different and false if the operands are the same
            Console.WriteLine($"a ^ b = {a ^ b}");

        }
        static void BitwiseOperators()
        {
            Console.WriteLine("Bitwise Operators");
            // &, |, ^, ~, <<, >>
            int a = 10;//1010
            int b = 3;//0011
            Console.WriteLine($"a & b = {a & b}"); //0010 = 2
            Console.WriteLine($"a | b = {a | b}"); //1011 = 11
            Console.WriteLine($"a ^ b = {a ^ b}"); //1001 = 9
            Console.WriteLine($"~a = {~a}"); //1010 -> 0101 = 5
            Console.WriteLine($"a << b = {a << b}"); //1010 << 3 = 010000 = 80
            Console.WriteLine($"a >> b = {a >> b}"); //1010 >> 3 = 0001 = 1
        }
    }
}
