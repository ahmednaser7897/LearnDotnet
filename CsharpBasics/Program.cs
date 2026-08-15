//name space is a way to organize code and avoid naming conflicts.
//It allows you to group related classes, interfaces, and other types together under a common name.
//In C#, namespaces are defined using the "namespace" keyword followed by the desired name.
using CsharpFundamentals.Threading;

namespace CsharpFundamentals
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //BasicsProgram.Run();
            //OopProgram.Run();
            //KeyWordsProgram.Run();
            //SolidProgram.Run();
            //DataStructuresProgram.Run();
            //FileHandlingProgram.Run();
            //ReflectionProgram.Run();
            //await SerializationProgram.Run();
            //StreamsProgram.Run();
            ThreadingProgram.Run();
            //AsynchronizationProgram.Run();
        }
    }
}
