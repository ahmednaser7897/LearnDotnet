
using System.Reflection;

namespace CsharpFundamentals.Reflections
{
    internal class ReflectionBasics
    {
        public static void Run()
        {

            //ReflectionBasicsData();
            //Console.WriteLine("==========================================");
            //FirstReflectionDemo.PrintAssemblyData();
            //Console.WriteLine("==========================================");
            EmbeddedResourceBasics();
            Console.WriteLine("==========================================");
        }
        public static void ReflectionBasicsData()
        {
            Console.WriteLine("===================== Reflection Basics Data =====================");
            //Assembly is a project in my sloution 
            //Reflection gives us access on the assembly code (dll) of currunt runig code or onther code
            // we can get the meta data about the currant running assembly
            var assembly = Assembly.GetExecutingAssembly();
            Console.WriteLine($"assembly.FullName --> {assembly.FullName}");
            Console.WriteLine($"assembly.GetName().Name --> {assembly.GetName().Name}");
            Console.WriteLine($"assembly.GetName().Version --> {assembly.GetName().Version}");
            Console.WriteLine($"assembly.GetName().FullName --> {assembly.GetName().FullName}");
            Console.WriteLine($"assembly.GetName().CultureName --> {assembly.GetName().CultureName}");
            Console.WriteLine();

        }
        

        public static void EmbeddedResourceBasics()
        {
            Console.WriteLine("===================== Embedded Resource Basics =====================");
            //if i want my files not to be in LearnDotnet\CsharpBasics\bin\Debug\net10.0 -> the dll output files
            // so the user can not see it after build the project
            //we click in the file and change build action to ->Embedded Resource
            // now it is part of the dll file not beside it so the user can not see or change it
            // we can get the meta data about the currant running assembly
            var assembly = Assembly.GetExecutingAssembly();
            var arStream = assembly.GetManifestResourceStream("CsharpFundamentals.Reflections.Resources.ar.txt");
            Console.WriteLine(arStream==null ? "Ar resource not found": "Ar resource found");
            var enStream = assembly.GetManifestResourceStream("CsharpFundamentals.Reflections.Resources.en.txt");
            Console.WriteLine(arStream == null ? "En resource not found" : "En resource found");
            Console.WriteLine("Ar File");
            byte[] arr = new Byte[arStream.Length];
            arStream.ReadExactly(arr);
            foreach (var item in arr)
            {
                Console.Write((char)item); 
            }
            Console.WriteLine();
            Console.WriteLine("En File");
            byte[] arr2 = new Byte[enStream.Length];
            enStream.ReadExactly(arr);
            foreach (byte item in arr)
            {
                Console.Write((char)item);
            }
            Console.WriteLine();

        }
    }
}
