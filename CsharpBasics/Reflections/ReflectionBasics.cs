using System.Reflection;

namespace CsharpFundamentals.Reflections
{
    internal class ReflectionBasics
    {
        public static void Run()
        {
            // ReflectionBasics();
            // Console.WriteLine("==========================================");

            // AssemblyBasics();
            // Console.WriteLine("==========================================");

            // EmbeddedResourceBasics();
            // Console.WriteLine("==========================================");

            // GetTypesBasics();
            // Console.WriteLine("==========================================");

            // DateTimeReflection();
            // Console.WriteLine("==========================================");

            IntReflection();

            Console.WriteLine("==========================================");
        }

        /// <summary>
        /// Demonstrates basic information that can be retrieved from an Assembly.
        /// An Assembly is the compiled DLL or EXE that contains our application code.
        /// </summary>
        public static void AssemblyBasics()
        {
            Console.WriteLine("===================== Assembly Basics =====================");

            // Get the Assembly that contains the currently executing code.
            Assembly assembly = Assembly.GetExecutingAssembly();

            // Full name contains the assembly name, version, culture, and public key information.
            Console.WriteLine($"Assembly FullName     --> {assembly.FullName}");

            // Get the simple name of the Assembly.
            Console.WriteLine($"Assembly Name         --> {assembly.GetName().Name}");

            // Get the Assembly version.
            Console.WriteLine($"Assembly Version      --> {assembly.GetName().Version}");

            // Get the complete AssemblyName object information.
            Console.WriteLine($"Assembly FullName     --> {assembly.GetName().FullName}");

            // Get the culture name of the Assembly.
            Console.WriteLine($"Assembly Culture      --> {assembly.GetName().CultureName}");

            Console.WriteLine();
        }

        /// <summary>
        /// Demonstrates how to work with files embedded inside an Assembly.
        /// </summary>
        public static void EmbeddedResourceBasics()
        {
            Console.WriteLine("===================== Embedded Resource Basics =====================");

            // Get the Assembly that contains the currently executing code.
            Assembly assembly = Assembly.GetExecutingAssembly();

            // Get the embedded Arabic resource file.
            Stream? arabicResource = assembly.GetManifestResourceStream(
                "CsharpFundamentals.Reflections.Resources.ar.txt");

            // Get the embedded English resource file.
            Stream? englishResource = assembly.GetManifestResourceStream(
                "CsharpFundamentals.Reflections.Resources.en.txt");

            Console.WriteLine(
                arabicResource == null
                    ? "Arabic resource not found."
                    : "Arabic resource found.");

            Console.WriteLine(
                englishResource == null
                    ? "English resource not found."
                    : "English resource found.");

            // Stop if one of the resources does not exist.
            if (arabicResource == null || englishResource == null)
            {
                return;
            }

            // Read and display the Arabic resource.
            Console.WriteLine("Arabic File:");

            byte[] arabicData = new byte[arabicResource.Length];
            arabicResource.ReadExactly(arabicData);

            foreach (byte character in arabicData)
            {
                Console.Write((char)character);
            }

            Console.WriteLine();

            // Read and display the English resource.
            Console.WriteLine("English File:");

            byte[] englishData = new byte[englishResource.Length];
            englishResource.ReadExactly(englishData);

            foreach (byte character in englishData)
            {
                Console.Write((char)character);
            }

            Console.WriteLine();
        }

        /// <summary>
        /// Demonstrates how to get information about types using Reflection.
        /// </summary>
        public static void GetTypesBasics()
        {
            Console.WriteLine("===================== Get Types Basics =====================");

            // Get information about the System.Object type.
            object value = new object();

            // GetType() returns a Type object representing the runtime type of an object.
            Type objectType = value.GetType();

            Console.WriteLine(
                $"Name      --> {objectType.Name}\n" +
                $"Namespace --> {objectType.Namespace}\n" +
                $"BaseType  --> {objectType.BaseType}");

            // Get the Assembly containing the currently executing code.
            Assembly assembly = Assembly.GetExecutingAssembly();

            // GetExportedTypes() returns only public types from the Assembly.
            Type[] exportedTypes = assembly.GetExportedTypes();

            foreach (Type type in exportedTypes)
            {
                Console.WriteLine(
                    $"Name      --> {type.Name}\n" +
                    $"Namespace --> {type.Namespace}\n" +
                    $"BaseType  --> {type.BaseType}\n");
            }

            // Another way to get type information:
            // typeof(object) returns the Type object directly.
            Type objectTypeUsingTypeof = typeof(object);

            Console.WriteLine(
                $"typeof(object).Name --> {objectTypeUsingTypeof.Name}");

            Console.WriteLine();
        }

        /// <summary>
        /// Demonstrates how to inspect the members and properties of a type.
        /// </summary>
        public static void DateTimeReflection()
        {
            Console.WriteLine("===================== DateTime Reflection =====================");

            // typeof() gives us the Type object for DateTime.
            Type dateTimeType = typeof(DateTime);

            // GetMembers() returns methods, properties, fields, events, constructors, etc.
            // BindingFlags allow us to filter which members we want.
            MemberInfo[] staticNonPublicMembers =
                dateTimeType.GetMembers(
                    BindingFlags.Static | BindingFlags.NonPublic);

            Console.WriteLine("Static Non-Public Members:");

            foreach (MemberInfo member in staticNonPublicMembers)
            {
                Console.WriteLine(
                    $"Name --> {member.Name}, Type --> {member.MemberType}");
            }

            Console.WriteLine();

            // GetProperties() returns only properties.
            PropertyInfo[] publicStaticProperties =
                dateTimeType.GetProperties(
                    BindingFlags.Static | BindingFlags.Public);

            Console.WriteLine("Static Public Properties:");

            foreach (PropertyInfo property in publicStaticProperties)
            {
                // SetMethod == null means that the property has no setter.
                bool isReadOnly = property.SetMethod == null;

                Console.WriteLine(
                    $"Name --> {property.Name}, " +
                    $"Type --> {property.PropertyType}, " +
                    $"Read Only --> {isReadOnly}");
            }

            Console.WriteLine();

            // Similar Reflection methods exist for other members:
            //
            // GetMethods()       -> Methods
            // GetFields()        -> Fields
            // GetEvents()        -> Events
            // GetConstructors()  -> Constructors
        }

        /// <summary>
        /// Demonstrates how to find and invoke methods using Reflection.
        /// </summary>
        public static void IntReflection()
        {
            Console.WriteLine("===================== Integer Reflection =====================");

            // Get the Type object representing System.Int32 (int).
            Type intType = typeof(int);

            // Get a method by its name.
            MethodInfo? minMethod = intType.GetMethod("Min");

            if (minMethod == null)
            {
                Console.WriteLine("Min method was not found.");
                return;
            }

            // Get information about the method parameters.
            ParameterInfo[] parameters = minMethod.GetParameters();

            foreach (ParameterInfo parameter in parameters)
            {
                Console.WriteLine(
                    $"Parameter Name --> {parameter.Name}, " +
                    $"Parameter Type --> {parameter.ParameterType}");
            }

            // Call the method normally.
            Console.WriteLine($"int.Min(5, 10) --> {int.Min(5, 10)}");

            // Call the same method using Reflection.
            //
            // Invoke() receives:
            // 1. The object on which the method should be called.
            //    For static methods, this is null.
            //
            // 2. The method parameters.
            object? minimumValue = minMethod.Invoke(null, [5, 10]);

            Console.WriteLine(
                $"minMethod.Invoke(null, [5, 10]) --> {minimumValue}");

            Console.WriteLine();

            // ---------------------------------------------------------
            // Calling an instance method using Reflection
            // ---------------------------------------------------------

            // Get the Type object for DateTime.
            Type dateTimeType = typeof(DateTime);

            // Find the AddDays instance method.
            MethodInfo? addDaysMethod = dateTimeType.GetMethod("AddDays");

            if (addDaysMethod == null)
            {
                Console.WriteLine("AddDays method was not found.");
                return;
            }

            // Create a DateTime object.
            DateTime currentDate = DateTime.Now;

            Console.WriteLine($"Current Date --> {currentDate}");

            // AddDays is an instance method, so we pass the object
            // that should execute the method as the first argument.
            object? newDate = addDaysMethod.Invoke(
                currentDate,
                [10]);

            Console.WriteLine(
                $"Date After 10 Days --> {newDate}");

            Console.WriteLine();
        }
    }
}
