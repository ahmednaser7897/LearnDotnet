

namespace CsharpFundamentals.CsharpKeyWords
{
    // ============================================================
    // MAIN
    // ============================================================

    public class PartialKeyWord
    {
        public static void Run()
        {
            // ====================================================
            // PARTIAL CLASS EXAMPLE
            // ====================================================

            PartialEmployee employee = new PartialEmployee
            {
                Id = 1,
                Name = "Ahmed"
            };

            // PrintInfo() is defined in another partial part,
            // but it is still part of the same Employee class.
            employee.PrintInfo();

            employee.SayHello();


            // ====================================================
            // PARTIAL METHOD EXAMPLE
            // ====================================================

            User user = new User
            {
                Name = "Ahmed"
            };

            user.Create();


            // ====================================================
            // PARTIAL STRUCT EXAMPLE
            // ====================================================

            Point point = new Point
            {
                X = 10,
                Y = 20
            };

            point.Print();
        }
    }

    // ============================================================
    // PARTIAL CLASS
    // ============================================================
    //
    // The 'partial' keyword allows us to split ONE class
    // into multiple files.
    //
    // The compiler combines all partial parts into ONE class
    // during compilation.
    // ============================================================

    public partial class PartialEmployee
    {
        // This field belongs to the same Employee class
        // even though it is defined in another file/part.
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;
    }


    // ============================================================
    // ANOTHER PART OF THE SAME CLASS
    // ============================================================
    //
    // In a real project, this would normally be in another file:
    //
    // Employee.Methods.cs
    //
    // Both parts below become ONE Employee class.
    // ============================================================

    public partial class PartialEmployee
    {
        public void PrintInfo()
        {
            Console.WriteLine($"Id: {Id}");
            Console.WriteLine($"Name: {Name}");
        }

        public void SayHello()
        {
            Console.WriteLine($"Hello {Name}");
        }
    }


    // ============================================================
    // PARTIAL METHODS
    // ============================================================
    //
    // A partial method allows one part of a partial class
    // to declare a method and another part to implement it.
    //
    // Partial methods are useful when working with generated code.
    // ============================================================

    public partial class User
    {
        public string Name { get; set; } = string.Empty;

        // Method declaration
        partial void OnUserCreated();

        public void Create()
        {
            Console.WriteLine($"Creating user: {Name}");

            // Call the partial method
            OnUserCreated();
        }
    }


    // ============================================================
    // IMPLEMENTATION OF PARTIAL METHOD
    // ============================================================
    //
    // Normally this would be in another file:
    //
    // User.Events.cs
    // ============================================================

    public partial class User
    {
        partial void OnUserCreated()
        {
            Console.WriteLine("User was created successfully.");
        }
    }


    // ============================================================
    // PARTIAL STRUCT
    // ============================================================
    //
    // The 'partial' keyword can also be used with structs.
    // ============================================================

    public partial struct Point
    {
        public int X { get; set; }
        public int Y { get; set; }
    }


    public partial struct Point
    {
        public void Print()
        {
            Console.WriteLine($"Point: ({X}, {Y})");
        }
    }



}

