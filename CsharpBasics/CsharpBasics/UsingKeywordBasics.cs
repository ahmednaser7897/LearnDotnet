// ITI LECTURE - C# Fundamentals - using Keyword
// File - UsingKeywordBasics.cs

using System;
using System.Collections.Generic;

//---------------------------------------------------------
// USING KEYWORD IN C#
//---------------------------------------------------------
/*
 * The "using" keyword has different uses in C#.
 *
 * 1. using Directive
 *    Imports a namespace.
 *
 * 2. using Alias
 *    Gives another name to a namespace or type.
 *
 * 3. using static
 *    Imports static members of a class.
 *
 * 4. global using
 *    Makes a namespace available in all project files.
 *
 * 5. using Statement
 *    Automatically calls Dispose() after a block.
 *
 * 6. using Declaration
 *    Automatically calls Dispose() at the end of the scope.
 *
 * Resource using is commonly used with:
 * - Files and streams
 * - Database connections
 * - Network resources
 */

using EmployeeList = System.Collections.Generic.List<string>;
using TextBuilder = System.Text.StringBuilder;
using static System.Math;

// global using example (normally put in GlobalUsings.cs):
// global using System;
// global using System.Collections.Generic;

namespace CsharpFundamentals.CsharpBasics
{
    internal class UsingKeywordBasics
    {
        public static void Run()
        {
            UsingDirectiveExample();
            Console.WriteLine("=======================================");
            UsingAliasExample();
            Console.WriteLine("=======================================");
            UsingStaticExample();
            Console.WriteLine("=======================================");
            UsingStatementExample();
            Console.WriteLine("=======================================");
            UsingDeclarationExample();
            Console.WriteLine("=======================================");
            MultipleResourcesExample();
            Console.WriteLine("=======================================");
        }

        //---------------------------------------------------------
        // 1. using Directive
        //---------------------------------------------------------
        public static void UsingDirectiveExample()
        {
            Console.WriteLine("------------ using Directive ------------");

            // List can be used directly because we imported
            // System.Collections.Generic.
            List<string> employees = new List<string>()
            {
                "Ahmed",
                "Sara",
                "Omar"
            };

            foreach (string employee in employees)
                Console.WriteLine(employee);

            // Without using, we need the full type name.
            System.Collections.Generic.List<string> departments =
                new System.Collections.Generic.List<string>()
                {
                    "Development",
                    "Marketing"
                };

            Console.WriteLine($"Departments Count --> {departments.Count}");
        }

        //---------------------------------------------------------
        // 2. using Alias
        //---------------------------------------------------------
        public static void UsingAliasExample()
        {
            Console.WriteLine("------------ using Alias ------------");

            // EmployeeList is an alias for List<string>.
            EmployeeList employees = new EmployeeList()
            {
                "Ahmed",
                "Mona",
                "Youssef"
            };

            foreach (string employee in employees)
                Console.WriteLine(employee);

            // TextBuilder is an alias for StringBuilder.
            TextBuilder builder = new TextBuilder();

            builder.Append("ITI ");
            builder.Append("C# ");
            builder.Append("Course");

            Console.WriteLine($"Text --> {builder}");
        }

        //---------------------------------------------------------
        // 3. using static
        //---------------------------------------------------------
        public static void UsingStaticExample()
        {
            Console.WriteLine("------------ using static ------------");

            // Normal call.
            double result1 = Math.Sqrt(25);

            // Because of "using static System.Math",
            // we can call Sqrt without Math.
            double result2 = Sqrt(64);

            Console.WriteLine($"Math.Sqrt(25) --> {result1}");
            Console.WriteLine($"Sqrt(64) --> {result2}");

            int highestSalary = Max(15000, 22000);

            Console.WriteLine($"Highest Salary --> {highestSalary}");
            Console.WriteLine($"PI --> {PI}");
        }

        //---------------------------------------------------------
        // 4. using Statement
        //---------------------------------------------------------
        public static void UsingStatementExample()
        {
            Console.WriteLine("------------ using Statement ------------");

            // Used with IDisposable objects.
            // Dispose() is called when the block finishes.
            using (DemoResource resource =
                new DemoResource("Database Connection"))
            {
                resource.Use();
            }

            Console.WriteLine("Resource is disposed after the block.");
        }

        //---------------------------------------------------------
        // 5. using Declaration
        //---------------------------------------------------------
        public static void UsingDeclarationExample()
        {
            Console.WriteLine("------------ using Declaration ------------");

            // Shorter syntax without a using block.
            // Dispose() runs when this method ends.
            using DemoResource resource =
                new DemoResource("File Resource");

            resource.Use();

            Console.WriteLine("Resource is still available here.");
        }

        //---------------------------------------------------------
        // 6. Multiple using Resources
        //---------------------------------------------------------
        public static void MultipleResourcesExample()
        {
            Console.WriteLine("------------ Multiple Resources ------------");

            using DemoResource file =
                new DemoResource("File");

            using DemoResource database =
                new DemoResource("Database");

            file.Use();
            database.Use();

            // At the end of the method they are disposed
            // automatically in reverse creation order.
        }
    }

    //---------------------------------------------------------
    // IDisposable Example
    //---------------------------------------------------------
    /*
     * IDisposable is used for objects that need cleanup.
     * The using statement/declaration calls Dispose()
     * automatically.
     */
    internal class DemoResource : IDisposable
    {
        public string Name { get; set; }

        public DemoResource(string name)
        {
            Name = name;
            Console.WriteLine($"{Name} opened.");
        }

        public void Use()
        {
            Console.WriteLine($"{Name} is being used.");
        }

        // Called automatically by using.
        public void Dispose()
        {
            Console.WriteLine($"{Name} disposed.");
        }
    }
}

/*
 * QUICK SUMMARY
 * =============
 *
 * using System.Text;
 * -> Imports a namespace.
 *
 * using MyList = System.Collections.Generic.List<string>;
 * -> Creates an alias.
 *
 * using static System.Math;
 * -> Imports static members.
 *
 * global using System.Text;
 * -> Imports a namespace for the whole project.
 *
 * using (resource) { }
 * -> Disposes at the end of the block.
 *
 * using Resource resource = new Resource();
 * -> Disposes at the end of the current scope.
 */