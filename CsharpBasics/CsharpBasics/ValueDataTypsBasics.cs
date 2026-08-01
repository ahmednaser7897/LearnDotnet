//ITI LECTURE 2 - C# Fundamentals - Value Data Types Basics
//https://www.youtube.com/watch?v=vOpWgihaIVs&list=PLNFDrRZdysFxcO03JtQeIMed4GHFc2YlT&index=2

namespace CsharpFundamentals.CsharpBasics
{
    internal class ValueDataTypsBasics
    {
        public static void Run()
        {
            //by default, the value data types are stored in the stack memory, and the reference data types are stored in the heap memory.
            Console.WriteLine("Test Value Data Types");
            // value data types -> primitive data types
            // its any data type that stores the actual value of the variable in memory.
            // any data type that is created using struct or enum is a value data type.
            // int , float, double, char, bool, decimal, long, short, byte
            IntDataType();
            BoolDataType();
            FloatDataType();
            DoubleDataType();
            Defaultvalue();
            Concatenation();
            TestOutVsRef();
            TestNullableDataTypes();
            discardVariable();
            ReadFromConsole();

            Console.WriteLine("=======================================");
        }
        static void IntDataType()
        {
            Console.WriteLine("int Data Type");
            // int data type is a 32-bit signed integer that can store values from -2,147,483,648 to 2,147,483,647.
            // this is a c# way of declaring a variable and initializing it with a value of type int.
            int x = 5;
            // this is a intermidate language (IL) way of declaring a variable and initializing it with a value of type int.
            Int32 y = 10;
            Console.WriteLine(x + y);
        }
        static void BoolDataType()
        {
            Console.WriteLine("bool Data Type");
            // bool data type is a 1-bit signed integer that can store values from 0 to 1.
            bool flag = true;
            Console.WriteLine(flag);

        }
        static void FloatDataType()
        {
            Console.WriteLine("float Data Type");
            // float data type is a 32-bit signed integer that can store values from -3.402823e38 to 3.402823e38.
            // by defult if we write a decimal number in c#, it will be considered as double data type,
            // so we need to add "f" at the end of the number to make it a float data type.
            // float f = 5.5;// compiler error: cannot implicitly convert type 'double' to 'float'. An explicit conversion exists (are you missing a cast?)
            float f = 5.5f;
            float f2 = (float)5.5;
            Console.WriteLine(f);
            Console.WriteLine(f2);
        }
        static void DoubleDataType()
        {
            Console.WriteLine("double Data Type");
            // double data type is a 64-bit signed integer that can store values from -1.7976931348623157e308 to 1.7976931348623157e308.
            double d = 5.5;
            Console.WriteLine(d);
        }
        static void Defaultvalue()
        {
            Console.WriteLine("Default Value");
            //the data typs has a default value, if we don't initialize the variable with a value,
            //it will take the default value of the data type.
            // its 0 for int, 0.0 for float, 0.0 for double, '\0' for char, false for bool, 0.0 for decimal, 0 for long, 0 for short, 0 for byte
            // we can use the "default" keyword to get the default value of a data type.
            bool flag = default;
            Console.WriteLine("default value for bool " + flag);
            Console.WriteLine("default value for int " + default(int));
        }
        static void Concatenation()
        {
            Console.WriteLine("Concatenation");
            // we can concatenate the value data types using the "+" operator.
            int x = 5;
            int y = 10;
            // 1-st way of concatenation
            Console.WriteLine("x = " + x + " y = " + y);
            // 2-nd way of concatenation
            Console.WriteLine("x = {0} y = {1}", x, y);
            //Console.WriteLine("x = {0} y = {2}", x,y );// this will give an error because we are trying to access the index 2 which is not available in the format string.
            // 3-rd way of concatenation
            Console.WriteLine($"x = {x} y = {y}");
        }
        static void ReadFromConsole()
        {
            Console.WriteLine("Read From Console");
            // we can read the value data types from the console using the "Console.ReadLine()" method.
            // we need to convert the string value to the required data type using the "Convert" class.
            Console.WriteLine("Enter a number: ");
            string? st = Console.ReadLine();
            Console.WriteLine("X1: " + int.Parse(st ?? "0 "));
            int t;
            //we can send a var that declared before
            Console.WriteLine("X2: " + int.TryParse(st, out t));
            Console.WriteLine("X2: " + t);
            // or we can declare a var in the out parameter
            if (int.TryParse(st, out int z))
            {
                Console.WriteLine("X3: " + z);
            }
            Console.WriteLine("X4: " + Convert.ToInt32(st));
        }
        static void TestOutVsRef()
        {
            Console.WriteLine("Test Out Vs Ref");
            // out and ref are used to pass the value data types by reference.
            // out is used to return multiple values from a method.
            // out enable us to send value that is not initialized
            // to a method and the method will initialize it and send it back to the caller.
            // ref is used to pass the value data types by reference.
            int x = 10;
            int y = 43;
            Console.WriteLine("Before Swap: x = " + x + " y = " + y);
            SwapPrimitev(x, y);
            Console.WriteLine("After Primitev Swap no thing change: x = " + x + " y = " + y);
            SwapRef(ref x, ref y);
            Console.WriteLine("After Ref Swap it changes: x = " + x + " y = " + y);
            int reminder;
            int divide = Divide(x, y, out reminder);
            Console.WriteLine($"Divid of {x} and {y} = {divide} , and  reminder={reminder}");

        }
        static void SwapPrimitev(int a, int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }
        static void SwapRef(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }
        static int Divide(int a, int b, out int remainder)
        {
            remainder = a % b;
            return a / b;
        }
        static void TestNullableDataTypes()
        {
            Console.WriteLine("Test Nullable Data Types");
            // nullable data types are used to represent the value data types that can be null.
            // we can use the "?" operator to make a value data type nullable.
            int? x = null;
            Console.WriteLine("x = " + x);
            x = 5;
            Console.WriteLine("x = " + x);
            // we can use the "HasValue" property to check if a nullable data type has a value or not.
            Console.WriteLine("x has value: " + x.HasValue);
            // we can use the "GetValueOrDefault()" method to get the value of a nullable data type.
            int? y = null;
            Console.WriteLine("y = " + y.GetValueOrDefault());
            // we can use the "??" operator to get the value of a nullable data type or a default value if it is null.
            Console.WriteLine("y = " + (y ?? 9));
            Console.WriteLine("y has value: " + y.HasValue);
        }
        static void discardVariable()
        {
            Console.WriteLine("Discard Variable");
            // discard variable is used to ignore the value of a variable.
            // we can use the "_" operator to discard the value of a variable.
            int x = 5;
            int y = 10;
            int z = 15;
            // we can use the discard variable to ignore the value of a variable.
            (int a, int b, _) = (x, y, z);
            Console.WriteLine("a = " + a + " b = " + b);
        }
    }
}
