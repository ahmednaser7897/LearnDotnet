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
        //this enable the var of type Permissions to holde more the one value
        // to make it work we must set some rulse
        // 1- use [Flags] attribute
        // 2- start with none value=0
        // 3- each value must be a power of 2--> 1,2,4,8,16,32,64,128
        // we do this so any value can not be the some of 2 or more other values in the enum
        // so any combination of values will be unique and we can check if a value is in the combination or not
        // so we can use bitwise or to combine many values
        // unless i want to use a value that is the same as the combination of 2 or more values in the enum
        // like Weekend = Saturday | Sunday,//1|2=3 -->1+2=3
        [Flags]
        enum WeekDays
        {   None = 0 ,          //0b_0000_0000 -> 0
            Saturday = 1,       //0b_0000_0001 -> 1
            Sunday = 2 ,        //0b_0000_0010 -> 2
            Monday = 4 ,        //0b_0000_0100 -> 4
            Tuesday = 8 ,       //0b_0000_1000 -> 8
            Wednesday = 16 ,    //0b_0001_0000 -> 16
            Thursday = 32 ,     //0b_0010_0000 -> 32
            Friday = 64 ,       //0b_0100_0000 -> 64
            Weekend = Saturday | Sunday,//1|2=3 
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
            Console.WriteLine("Today value = " + (int)today);//Today value = 2
            Console.WriteLine("Order Status value = " + (int)status);//Order Status value = 1

            // we can convert int to enum.
            // this will give us the name of the int value of enum
            Console.WriteLine("Today name = " + (Days)2);//Today name = Monday
            //if this value not exist it will be the same value
            Console.WriteLine("Order Status name = " + (Days)9);//Order Status name = 9

            //converting enum to string
            Console.WriteLine("Today as string = " + today.ToString());
            //converting string to enum
            Console.WriteLine(Enum.Parse(typeof(Days), "Monday",true));//Monday)

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
                Console.Write($"{day} = {(int)day} \t");
            }
            Console.WriteLine();
        }

        static void EnumFlagsExample()
        {
            Console.WriteLine("Enum Flags Example");
            //we can use bitwise or to compine many enum values
            // this get the bitwise or of the 2 values
            // and show the name of it if the output in the enum 
            // or an int if the output is not in the enum

            //1- Bitwis Or -> combine 2 or more values
            WeekDays day1 = WeekDays.Friday | WeekDays.Saturday;
            //WeekDays.Friday   |   WeekDays.Saturday 
            //0b_0100_0000      |   0b_0000_0001    -> 0b_0100_0001 -> 1 | 64 -> 1 + 64 -> 65
            Console.WriteLine($"WeekDays.Friday | WeekDays.Saturday -> 0b_0100_0000 | 0b_0000_0001 => {0b_0100_0000} | {0b_0000_0001} => {0b_0100_0000} + {0b_0000_0001} => {0b_0100_0000 | 0b_0000_0001}");
            Console.WriteLine($"WeekDays.Friday | WeekDays.Saturday -> {day1}");
            //2- Bitwise And -> get the common values between 2 values
            WeekDays day2 = WeekDays.Friday | WeekDays.Saturday;
            WeekDays day3 = WeekDays.Friday | WeekDays.Wednesday;
            Console.WriteLine($"day2(Friday | Saturday) & day3(Friday | Wednesday) -> {day2 & day3}");
            // check if a value is in the combination of values using bitwise and
            Console.WriteLine($"day2(Friday | Saturday) & Friday -> {day2 & WeekDays.Friday}");
            Console.WriteLine($"day2(Friday | Saturday) & Friday -> {day2 & WeekDays.Wednesday}");
            //to make it bool
            bool isDayExist = (day2 & WeekDays.Friday) == WeekDays.Friday;
            Console.WriteLine($"day2(Friday | Saturday) & Friday -> {isDayExist}");

            //3- ~ Bitwise Not -> remove a value from the combination of values using bitwise and with not
            WeekDays day4 = WeekDays.Friday | WeekDays.Wednesday | WeekDays.Sunday| WeekDays.Thursday;
            Console.WriteLine($"day4(Friday | Wednesday | Sunday | Thursday) -> {day4}");
            Console.WriteLine($"day4(Friday | Wednesday | Sunday | Thursday) & ~WeekDays.Sunday -> {day4 & ~WeekDays.Sunday}");

            //4- togel operator ^ -> if the value exist in the combination it will remove it, if not it will add it
            WeekDays day5 = WeekDays.Friday | WeekDays.Wednesday | WeekDays.Sunday | WeekDays.Thursday;
            Console.WriteLine($"day5(Friday | Wednesday | Sunday | Thursday) -> {day5}");
            Console.WriteLine($"day5(Friday | Wednesday | Sunday | Thursday) ^WeekDays.Sunday -> {day5 ^ WeekDays.Sunday}");
            Console.WriteLine($"day5(Friday | Wednesday | Sunday | Thursday) ^WeekDays.Sunday -> {day5 ^ WeekDays.Tuesday}");

            // HasFlag() checks whether a flag exists.
            Console.WriteLine(day1.HasFlag(WeekDays.Saturday));
            Console.WriteLine(day1.HasFlag(WeekDays.Monday));

        }
    }
}