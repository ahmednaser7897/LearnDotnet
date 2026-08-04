//name space is a way to organize code and avoid naming conflicts.
//It allows you to group related classes, interfaces, and other types together under a common name.
//In C#, namespaces are defined using the "namespace" keyword followed by the desired name.


using CsharpFundamentals.CsharpBasics;
using CsharpFundamentals.DataStructures;
using CsharpFundamentals.FileHandling;

namespace CsharpFundamentals
{
    class Program
    {
        static void Main(string[] args)
        {
            TestNamespace.Run();
            Operators.Run();
            CharDataType.Run();
            StringDataType.Run();
            NumericDataTypes.Run();
            Selections.Run();
            Loops.Run();
            Arrays.Run();
            Methods.Run();
            ExceptionHandling.Run();
            FileBasics.Run();
            DirectoryAndPath.Run();
            ArrayListBasics.Run();
            ListBasics.Run();
            DictionaryBasics.Run();
            ValueDataTypsBasics.Run();
            EnumBasics.Run();
            StructBasics.Run();
            ReferenceDataTypes.Run();
        }
    }
}
