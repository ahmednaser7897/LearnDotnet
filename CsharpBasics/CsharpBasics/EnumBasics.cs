//ITI LECTURE 3 - C# Fundamentals -  Enum Basics
//https://www.youtube.com/watch?v=vOpWgihaIVs&list=PLNFDrRZdysFxcO03JtQeIMed4GHFc2YlT&index=3

namespace CsharpFundamentals.CsharpBasics
{
    internal class EnumBasics
    {
        public static void Run()
        {
            Console.WriteLine("Test Enum Data Type");
            // enum is a value data type.
            // it is used to represent a group of named constant values.
            // by default the underlying data type of enum is int.
            EnumDeclaration();
            EnumParsing();
            EnumValidation();
            EnumIteration();
            EnumFlagsExample();
            Console.WriteLine("=======================================");
        }

        // enum declaration
        // every enum member has an integer value.
        // by default the first value starts from 0.
        enum Days
        {
            Saturday,//by defult the value is 0
            Sunday,//1
            Monday,//2
            Tuesday,//3
            Wednesday,//4
            Thursday,//5
            Friday//6
        }

        // enum with custom values
        enum OrderStatus
        {
            Pending = 1,
            Processing = 2,
            Shipped = 3,
            Delivered = 4,
            Cancelled = 5
        }

        // enum with custom underlying data type
        enum Grade : byte // so max value will be 128
        {
            A = 1,
            B = 2,
            C = 3,
            D = 4,
            F = 5
        }

        [Flags]
        enum Permissions
        {
            None = 0,
            Read = 2,
            Write = 10,
            Delete ,// by defult this will be 11
            Execute = 20
        }

        static void EnumDeclaration()
        {
            Console.WriteLine("Enum Declaration");

            // creating enum variables.
            Days today = Days.Monday;
            OrderStatus status = OrderStatus.Pending;

            Console.WriteLine("Today name = " + today);//Today name = Monday
            Console.WriteLine("Order Status name = " + status);//Order Status name = Pending
           
            // we can convert enum to int.
            //this is how to get the value of a enum name
            Console.WriteLine("Today value = " +(int) today);//Today value = 2
            Console.WriteLine("Order Status value = " + (int)status);//Order Status value = 1

            // we can convert int to enum.
            // this will give us the name of the int value of enum
            Console.WriteLine("Today name = " + (Days)2);//Today name = Monday
            //if this value not exist it will be the same value
            Console.WriteLine("Order Status name = " + (Days)9);//Order Status name = 9

        }

        static void EnumParsing()
        {
            Console.WriteLine("Enum Parsing");

            // we can convert a string into an enum using Enum.Parse().
            string input = "Delivered";

            //OrderStatus status =
            //    (OrderStatus)Enum.Parse(typeof(OrderStatus), input);
            OrderStatus status = Enum.Parse<OrderStatus>(input);


            Console.WriteLine(status);

            // Enum.TryParse() is safer because it doesn't throw an exception.
            if (Enum.TryParse("Cancelled", out OrderStatus result))
            {
                Console.WriteLine(result);
            }
        }

        static void EnumValidation()
        {
            Console.WriteLine("Enum Validation");

            // Enum.IsDefined() checks whether a value exists in the enum.
            Console.WriteLine(Enum.IsDefined(typeof(OrderStatus), 3));
            Console.WriteLine(Enum.IsDefined(typeof(OrderStatus), 10));

            Console.WriteLine(Enum.IsDefined(typeof(OrderStatus), "Pending"));
            Console.WriteLine(Enum.IsDefined(typeof(OrderStatus), "Unknown"));
        }

        static void EnumIteration()
        {
            Console.WriteLine("Enum Iteration");

            // Enum.GetValues() returns all values in the enum.
            foreach (Days day in Enum.GetValues(typeof(Days)))
            {
                Console.WriteLine($"{day} = {(int)day}");
            }
        }

        static void EnumFlagsExample()
        {
            Console.WriteLine("Enum Flags Example");
            //we can use bitwise or to compine many enum values
            // this get the bitwise or of the 2 values
            // and show the name of it if the output in the enum 
            // or an int if the output is not in the enum
            OrderStatus orderStatus1 = OrderStatus.Delivered | OrderStatus.Processing;//4|2->6
            Console.WriteLine($"Order Status is {orderStatus1}");
            OrderStatus orderStatus2 = OrderStatus.Cancelled | OrderStatus.Pending;//5|1->5(Cancelled)
            Console.WriteLine($"Order Status is {orderStatus2}");

            // [Flags] attribute allows combining multiple enum values.
            Permissions userPermission = Permissions.Read | Permissions.Write;

            Console.WriteLine(userPermission);

            // HasFlag() checks whether a flag exists.
            Console.WriteLine(userPermission.HasFlag(Permissions.Read));
            Console.WriteLine(userPermission.HasFlag(Permissions.Delete));

            // adding another permission.
            userPermission |= Permissions.Delete;
            Console.WriteLine(userPermission);

            // removing a permission.
            userPermission &= ~Permissions.Write;
            Console.WriteLine(userPermission);
        }
    }
}