//name space is a way to organize code and avoid naming conflicts.
//It allows you to group related classes, interfaces, and other types together under a common name.
//In C#, namespaces are defined using the "namespace" keyword followed by the desired name.


using CsharpFundamentals.CsharpBasics;
using CsharpFundamentals.DataStructures;
using CsharpFundamentals.FileHandling;
using CsharpFundamentals.ObjectOrientedProgramming;
using CsharpFundamentals.Solid;
namespace CsharpFundamentals
{
    class Program
    {
        static void Main(string[] args)
        {
            //BasicsProgram.Run();
            //OopProgram.Run();
            //OopProgram.Run();
            SolidProgram.Run();
            //DataStructuresProgram.Run();
            //FileHandlingProgram.Run();
        }
    }
}
