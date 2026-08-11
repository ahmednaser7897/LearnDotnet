using System.Reflection;

namespace CsharpFundamentals.Reflections
{
    internal class LoadDLL
    {
        public static void Run()
        {
            LoadDll();
            Console.WriteLine("==========================================");
            TestCopyObjects();
            Console.WriteLine("==========================================");
        }

        public static void LoadDll()
        {
            // This is one of the main benefits of Reflection.
            // We can load external DLLs and work with their types and methods.

            // Get the location of the Assembly that called this method.
            // var location = @"D:\programing\dotnet\LearnDotnet\CsharpBasics\bin\Debug\net10.0\Extension";
            // var assembly = Assembly.GetExecutingAssembly();

            var assemblyLocation = Assembly.GetCallingAssembly().Location;

            Console.WriteLine($"Assembly Location -> {assemblyLocation}");

            // Get the path of the Extension folder.
            var folderLocation = Path.Combine(
                Path.GetDirectoryName(assemblyLocation) ?? "",
                "Extension");

            Console.WriteLine($"Folder Location -> {folderLocation}");
            Console.WriteLine();

            // Get all files inside the Extension folder.
            foreach (var file in Directory.GetFiles(folderLocation))
            {
                Console.WriteLine(
                    $"===================== {file.Split("\\").Last()} =====================");

                // Load the Assembly from the file path.
                var assembly = Assembly.LoadFrom(file);

                // The type name should look like this:
                // MyFirstExtension.EntryPoint

                // Get the EntryPoint type from the Assembly.
                var type = assembly.GetType(
                    $"{assembly.GetName().Name}.EntryPoint");

                Console.WriteLine($"Type -> {type}");

                // Get the Execute method from the type.
                var method = type.GetMethod("Execute");

                // Invoke the method using Reflection.
                // The first parameter is null because Execute is a static method.
                // The second parameter is null because Execute has no parameters.
                method.Invoke(null, null);

                Console.WriteLine("==========================================");
                Console.WriteLine();
            }

            Console.WriteLine();
        }

        public static void TestCopyObjects()
        {
            var employee1 = new Employee
            {
                Name = "ahmed",
                Id = 1,
                Address = "Cairo",
                BirthDate = DateTime.Now
            };

            var employee2 = new Employee();

            Console.WriteLine(
                "===================== Print using ToString() =====================");

            Console.WriteLine(employee1);
            Console.WriteLine(employee2);

            CopyObjects(employee1, employee2);

            Console.WriteLine(
                "===================== Print using PrintObjectDetails() after copying =====================");

            PrintObjectDetails(employee1);
            PrintObjectDetails(employee2);

            Console.WriteLine("==========================================");

            var product = new Product();

            PrintObjectDetails(product);

            CopyObjects(employee1, product);

            PrintObjectDetails(product);
        }

        public static void PrintObjectDetails(object obj)
        {
            // Get the type information of the object.
            var type = obj.GetType();

            // Get all properties of the object.
            foreach (var item in type.GetProperties())
            {
                // Get the value of each property at runtime.
                Console.WriteLine($"{item.Name} -> {item.GetValue(obj)}");
            }
        }

        public static void CopyObjects(object src, object dest)
        {
            // Get all properties from the source object.
            foreach (var srcProperties in src.GetType().GetProperties())
            {
                // Find a property in the destination object
                // with the same name as the source property.
                var distProperties =
                    dest.GetType().GetProperty(srcProperties.Name);

                // If a property with the same name exists,
                // get its value from the source and set it in the destination.
                if (distProperties != null)
                {
                    var value = srcProperties.GetValue(src, null);

                    distProperties.SetValue(dest, value, null);
                }
            }
        }
    }
}
