using System.Reflection;

namespace MySacondExtension
{
    public class SacondReflectionDemo
    {
        public static void PrintAssemblyData()
        {
            Console.WriteLine("===================== Sacond Reflection Assembly Data =====================");
            // The entry code for the program --> CsharpFundamentals
            Console.WriteLine($"Entry Assembly  --> {Assembly.GetEntryAssembly().FullName}");
            // The code that called the code that is is executing now --> MyFirstExtension
            Console.WriteLine($"Calling Assembly  --> {Assembly.GetCallingAssembly().FullName}");
            // The code that is executing now --> MySacondExtension
            Console.WriteLine($"Executing Assembly  --> {Assembly.GetExecutingAssembly().FullName}");
            Console.WriteLine();
        }
    }
}



