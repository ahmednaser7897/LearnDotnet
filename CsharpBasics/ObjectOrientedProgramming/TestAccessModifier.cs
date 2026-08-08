
using TestClassLibrary.Models;

namespace CsharpFundamentals.ObjectOrientedProgramming
{
    // ============================================================
    // ACCESS MODIFIERS IN C#
    // ============================================================
    //
    // Access modifiers control WHERE a class, method, property,
    // field, constructor, etc. can be accessed from.
    //
    // Main access modifiers:
    //
    // public
    // private
    // protected
    // internal
    // protected internal
    // private protected
    //
    // ============================================================


    internal class TestAccessModifier
    {
        public static void Run()
        {
            PublicAccessModifier();

            InternalAccessModifier();

            PrivateAccessModifier();

            ProtectedAccessModifier();

            ProtectedInternalAccessModifier();

            PrivateProtectedAccessModifier();
        }


        // ========================================================
        // 1. PUBLIC
        // ========================================================
        //
        // public means:
        //
        // "This member can be accessed from anywhere."
        //
        // It can be accessed:
        // - Inside the same class
        // - From another class
        // - From another namespace
        // - From another project/assembly
        //
        // ========================================================

        public static void PublicAccessModifier()
        {
            Console.WriteLine("\n=== PUBLIC ===");

            // PublicStudent is public,
            // so we can create an object from another project.

            PublicStudent student = new(
                name: "Ahmed",
                age: 30,
                email: "ahmed@gmail.com",
                phone: "1233434",
                address: "Cairo, Egypt"
            );

            // The constructor is public,
            // so we can call it.

            Console.WriteLine(student);

            // If the properties are public,
            // we can access them directly.

            Console.WriteLine(student.Name);
            Console.WriteLine(student.Age);
        }


        // ========================================================
        // 2. INTERNAL
        // ========================================================
        //
        // internal means:
        //
        // "Accessible anywhere inside the SAME assembly/project."
        //
        // It CANNOT normally be accessed from another project.
        //
        // Example:
        //
        // Project A
        //     InternalStudent
        //
        // Project B
        //     Cannot access InternalStudent
        //
        // ========================================================

        public static void InternalAccessModifier()
        {
            Console.WriteLine("\n=== INTERNAL ===");

            // If InternalStudent is defined as:
            //
            // internal class InternalStudent
            //
            // and this code is in another project,
            // this will NOT compile.

            /*
            InternalStudent student = new(
                name: "Ahmed",
                age: 30,
                email: "ahmed@gmail.com",
                phone: "1233434",
                address: "Cairo, Egypt"
            );
            */

            Console.WriteLine(
                "Internal members are accessible only inside the same assembly."
            );
        }


        // ========================================================
        // 3. PRIVATE
        // ========================================================
        //
        // private means:
        //
        // "Accessible ONLY inside the class where it is declared."
        //
        // This is the most restrictive normal access modifier.
        //
        // IMPORTANT:
        //
        // private members are NOT accessible from:
        // - Other classes
        // - Child classes
        // - Other projects
        //
        // ========================================================

        public static void PrivateAccessModifier()
        {
            Console.WriteLine("\n=== PRIVATE ===");

            PublicStudent student = new(
                name: "Ahmed",
                age: 30,
                email: "ahmed@gmail.com",
                phone: "1233434",
                address: "Cairo, Egypt"
            );

            // If Email is private:
            //
            // Console.WriteLine(student.Email);
            //
            // This gives a compile-time error.

            // Private data is usually accessed through
            // public methods or properties.

            Console.WriteLine(student);
        }


        // ========================================================
        // 4. PROTECTED
        // ========================================================
        //
        // protected means:
        //
        // "Accessible inside the class itself AND
        // inside classes that inherit from it."
        //
        // Example:
        //
        // Parent Class
        //      ↓
        // Child Class
        //
        // The child can access protected members.
        //
        // But an unrelated class cannot.
        //
        // ========================================================

        public static void ProtectedAccessModifier()
        {
            Console.WriteLine("\n=== PROTECTED ===");

            Console.WriteLine(
                "Protected members are accessible inside the class "
                + "and its derived classes."
            );
        }


        // ========================================================
        // 5. PROTECTED INTERNAL
        // ========================================================
        //
        // protected internal means:
        //
        // Accessible if EITHER condition is true:
        //
        // 1. The code is inside the SAME assembly
        //
        // OR
        //
        // 2. The code is inside a DERIVED class,
        //    even if the derived class is in another assembly.
        //
        // IMPORTANT:
        //
        // protected internal = protected OR internal
        //
        // ========================================================

        public static void ProtectedInternalAccessModifier()
        {
            Console.WriteLine("\n=== PROTECTED INTERNAL ===");

            Console.WriteLine(
                "Accessible from the same assembly OR "
                + "from derived classes."
            );
        }


        // ========================================================
        // 6. PRIVATE PROTECTED
        // ========================================================
        //
        // private protected means:
        //
        // Accessible only:
        //
        // 1. Inside the containing class
        //
        // OR
        //
        // 2. Inside a derived class that is in the SAME assembly.
        //
        // IMPORTANT:
        //
        // private protected = private + protected
        //
        // AND the derived class must be in the same assembly.
        //
        // ========================================================

        public static void PrivateProtectedAccessModifier()
        {
            Console.WriteLine("\n=== PRIVATE PROTECTED ===");

            Console.WriteLine(
                "Accessible inside the class and derived classes "
                + "within the same assembly."
            );
        }
    }


    // ============================================================
    // PRACTICAL EXAMPLE
    // ============================================================

    public class Parent
    {
        // --------------------------------------------------------
        // PUBLIC
        // --------------------------------------------------------
        //
        // Accessible from anywhere.
        // --------------------------------------------------------

        public string PublicValue = "Public";


        // --------------------------------------------------------
        // PRIVATE
        // --------------------------------------------------------
        //
        // Accessible ONLY inside Parent.
        // --------------------------------------------------------

        private string PrivateValue = "Private";


        // --------------------------------------------------------
        // PROTECTED
        // --------------------------------------------------------
        //
        // Accessible inside Parent and derived classes.
        // --------------------------------------------------------

        protected string ProtectedValue = "Protected";


        // --------------------------------------------------------
        // INTERNAL
        // --------------------------------------------------------
        //
        // Accessible anywhere in the same assembly.
        // --------------------------------------------------------

        internal string InternalValue = "Internal";


        // --------------------------------------------------------
        // PROTECTED INTERNAL
        // --------------------------------------------------------
        //
        // Accessible:
        // Same assembly
        // OR
        // Derived class
        // --------------------------------------------------------

        protected internal string ProtectedInternalValue =
            "Protected Internal";


        // --------------------------------------------------------
        // PRIVATE PROTECTED
        // --------------------------------------------------------
        //
        // Accessible:
        // Same class
        // OR
        // Derived class in the same assembly.
        // --------------------------------------------------------

        private protected string PrivateProtectedValue =
            "Private Protected";


        // ========================================================
        // ACCESS FROM THE SAME CLASS
        // ========================================================

        public void TestInsideParent()
        {
            // All members can be accessed here.

            Console.WriteLine(PublicValue);

            Console.WriteLine(PrivateValue);

            Console.WriteLine(ProtectedValue);

            Console.WriteLine(InternalValue);

            Console.WriteLine(ProtectedInternalValue);

            Console.WriteLine(PrivateProtectedValue);
        }
    }


    // ============================================================
    // DERIVED CLASS
    // ============================================================
    //
    // Child class inherits from Parent.
    // ============================================================

    public class Child : Parent
    {
        public void TestInsideChild()
        {
            // ----------------------------------------------------
            // PUBLIC
            // ----------------------------------------------------

            Console.WriteLine(PublicValue);


            // ----------------------------------------------------
            // PROTECTED
            // ----------------------------------------------------
            //
            // Accessible because Child inherits from Parent.
            // ----------------------------------------------------

            Console.WriteLine(ProtectedValue);


            // ----------------------------------------------------
            // INTERNAL
            // ----------------------------------------------------
            //
            // Accessible if Child is in the same assembly.
            // ----------------------------------------------------

            Console.WriteLine(InternalValue);


            // ----------------------------------------------------
            // PROTECTED INTERNAL
            // ----------------------------------------------------
            //
            // Accessible because Child inherits from Parent
            // and/or because it is in the same assembly.
            // ----------------------------------------------------

            Console.WriteLine(ProtectedInternalValue);


            // ----------------------------------------------------
            // PRIVATE PROTECTED
            // ----------------------------------------------------
            //
            // Accessible because Child is derived from Parent
            // AND is in the same assembly.
            // ----------------------------------------------------

            Console.WriteLine(PrivateProtectedValue);


            // ----------------------------------------------------
            // PRIVATE
            // ----------------------------------------------------
            //
            // NOT accessible here.
            // ----------------------------------------------------

            // Console.WriteLine(PrivateValue); // ERROR
        }
    }


    // ============================================================
    // UNRELATED CLASS
    // ============================================================
    //
    // This class does NOT inherit from Parent.
    // ============================================================

    public class AnotherClass
    {
        public void Test()
        {
            Parent parent = new Parent();


            // ----------------------------------------------------
            // PUBLIC
            // ----------------------------------------------------
            //
            // Accessible.
            // ----------------------------------------------------

            Console.WriteLine(parent.PublicValue);


            // ----------------------------------------------------
            // INTERNAL
            // ----------------------------------------------------
            //
            // Accessible if this class is in the same assembly.
            // ----------------------------------------------------

            Console.WriteLine(parent.InternalValue);


            // ----------------------------------------------------
            // PRIVATE
            // ----------------------------------------------------
            //
            // NOT accessible.
            // ----------------------------------------------------

            // Console.WriteLine(parent.PrivateValue); // ERROR


            // ----------------------------------------------------
            // PROTECTED
            // ----------------------------------------------------
            //
            // NOT accessible because AnotherClass
            // does not inherit from Parent.
            // ----------------------------------------------------

            // Console.WriteLine(parent.ProtectedValue); // ERROR


            // ----------------------------------------------------
            // PROTECTED INTERNAL
            // ----------------------------------------------------
            //
            // Accessible here if this class is in the same assembly.
            // ----------------------------------------------------

            Console.WriteLine(parent.ProtectedInternalValue);


            // ----------------------------------------------------
            // PRIVATE PROTECTED
            // ----------------------------------------------------
            //
            // NOT accessible because AnotherClass is not derived
            // from Parent.
            // ----------------------------------------------------

            // Console.WriteLine(parent.PrivateProtectedValue); // ERROR
        }
    }
}
