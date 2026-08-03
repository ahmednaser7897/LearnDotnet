namespace CsharpFundamentals.CsharpBasics
{
    using System;

    class Methods
    {
        public static void Run()
        {
            VoidMethod();
            MethodWithParameters("Ahmed", 25);

            Console.WriteLine(ReturnMethod());

            Console.WriteLine(Add(10, 20));

            OptionalParameters();
            NamedArguments(age: 25, name: "Ahmed");

            MethodOverloading();

            RefParameter();
            OutParameter();

            InParameter();

            ParamsParameter();

            ExpressionBodiedMethods();

            LocalFunctions();

            RecursiveMethod();

            AnonymousMethod();

            LambdaExpression();

            DelegateExample();
        }

        // ==============================
        // Void Method
        // ==============================

        static void VoidMethod()
        {
            Console.WriteLine("\n=== Void Method ===");
            Console.WriteLine("Hello World");
        }

        // ==============================
        // Parameters
        // ==============================

        static void MethodWithParameters(string name, int age)
        {
            Console.WriteLine("\n=== Method With Parameters ===");

            Console.WriteLine($"Name = {name}");
            Console.WriteLine($"Age = {age}");
        }

        // ==============================
        // Return Value
        // ==============================

        static string ReturnMethod()
        {
            Console.WriteLine("\n=== Return Method ===");

            return "Returned Value";
        }

        // ==============================
        // Return With Parameters
        // ==============================

        static int Add(int a, int b)
        {
            return a + b;
        }

        // ==============================
        // Optional Parameters
        // ==============================

        static void OptionalParameters(string name = "Unknown")
        {
            Console.WriteLine("\n=== Optional Parameters ===");

            Console.WriteLine(name);
        }

        // ==============================
        // Named Arguments
        // ==============================

        static void NamedArguments(string name, int age)
        {
            Console.WriteLine("\n=== Named Arguments ===");

            Console.WriteLine($"{name} - {age}");
        }

        // ==============================
        // Method Overloading
        // ==============================

        static void MethodOverloading()
        {
            Console.WriteLine("\n=== Method Overloading ===");

            Console.WriteLine(Multiply(2, 3));

            Console.WriteLine(Multiply(2, 3, 4));
        }

        static int Multiply(int a, int b)
        {
            return a * b;
        }

        static int Multiply(int a, int b, int c)
        {
            return a * b * c;
        }

        // ==============================
        // ref : pass parameter by reference and it must be initialized before passing to the method
        // ==============================

        static void RefParameter()
        {
            Console.WriteLine("\n=== Ref Parameter ===");

            int number = 10;

            Increase(ref number);

            Console.WriteLine(number);
        }

        static void Increase(ref int value)
        {
            value++;
        }

        // ==============================
        // out :pass parameter by reference and it must be initialized in the method before returning
        // the difference between ref and out is that ref requires the variable to be initialized before passing it to the method,
        // while out does not require initialization before passing it to the method.
        // However, out requires the variable to be assigned a value in the method before returning.
        // ==============================

        static void OutParameter()
        {
            Console.WriteLine("\n=== Out Parameter ===");

            GetValues(out int x, out int y);

            Console.WriteLine(x);
            Console.WriteLine(y);
        }

        static void GetValues(out int a, out int b)
        {
            a = 100;
            b = 200;
        }

        // ==============================
        // in :the same pass parameter by reference but it is read-only
        // ==============================

        static void InParameter()
        {
            Console.WriteLine("\n=== In Parameter ===");

            int value = 50;

            PrintValue(in value);
        }

        static void PrintValue(in int value)
        {
            Console.WriteLine(value);

            // value++; // Error
        }

        // ==============================
        // params
        // ==============================

        static void ParamsParameter()
        {
            Console.WriteLine("\n=== Params Parameter ===");

            Console.WriteLine(Sum(1, 2, 3, 4, 5));
        }

        static int Sum(params int[] numbers)
        {
            int sum = 0;

            foreach (int number in numbers)
            {
                sum += number;
            }

            return sum;
        }

        // ==============================
        // Local Functions
        // ==============================

        static void LocalFunctions()
        {
            Console.WriteLine("\n=== Local Functions ===");

            int AddNumbers(int a, int b)
            {
                return a + b;
            }

            Console.WriteLine(AddNumbers(10, 20));
        }

        // ==============================
        // Recursion
        // ==============================

        static void RecursiveMethod()
        {
            Console.WriteLine("\n=== Recursion ===");

            Console.WriteLine(Factorial(5));
        }

        static int Factorial(int n)
        {
            if (n <= 1)
                return 1;

            return n * Factorial(n - 1);
        }

        // ==============================
        // Delegate : is a type that represents references to methods with a specific parameter list and return type.
        // When you instantiate a delegate, you can associate its instance with any method with a compatible signature and return type.
        // You can invoke (or call) the method through the delegate instance.
        // ==============================

        delegate int Operation(int a, int b);

        static void DelegateExample()
        {
            Console.WriteLine("\n=== Delegate Example ===");

            Operation op = AddNumbers;

            Console.WriteLine(op(10, 20));
        }

        static int AddNumbers(int a, int b)
        {
            return a + b;
        }

        // ==============================
        // Expression-Bodied Methods
        // ==============================

        static void ExpressionBodiedMethods()
        {
            Console.WriteLine("\n=== Expression Bodied Method ===");

            Console.WriteLine(Square(5));
        }
        static int Square(int x) => x * x;

        // ==============================
        // Anonymous Method
        // ==============================

        static void AnonymousMethod()
        {
            Console.WriteLine("\n=== Anonymous Method ===");

            Action hello = delegate ()
            {
                Console.WriteLine("Hello");
            };

            hello();
        }

        // ==============================
        // Lambda Expression
        // ==============================

        static void LambdaExpression()
        {
            Console.WriteLine("\n=== Lambda Expression ===");

            //Action is a delegate type that represents a method that takes no parameters and returns void.
            Action hello = () => Console.WriteLine("Hello");
            //Func is a delegate type that represents a method that takes parameters and returns a value.
            Func<int, int> square = x => x * x;


            Console.WriteLine(square(5));
        }


    }
}
