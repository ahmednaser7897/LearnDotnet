//ITI LECTURE 2 - C# Fundamentals - NamespaceS
//https://www.youtube.com/watch?v=vOpWgihaIVs&list=PLNFDrRZdysFxcO03JtQeIMed4GHFc2YlT&index=2
namespace CsharpFundamentals.CsharpBasics
{
    public class TestNamespace
    {
        public static void Run()
        {
            Hr.TestNamespace.TestMethod();
            Finance.TestNamespace.TestMethod();
        }
    }
}

namespace CsharpFundamentals.CsharpBasics.Hr
{
    public class TestNamespace
    {
        public static void TestMethod()
        {
            Console.WriteLine("This is a test method in the TestNamespace class in the Hr namespace.");
        }
    }
}

namespace CsharpFundamentals.CsharpBasics.Finance
{
    public class TestNamespace
    {
        public static void TestMethod()
        {
            Console.WriteLine("This is a test method in the TestNamespace class in the Finance namespace.");
        }
    }
}
