
namespace CsharpFundamentals.ObjectOrientedProgramming
{
    internal static class CopySemantics
    {
        public static void Run()
        {
            Console.WriteLine("========== Copy Semantics ==========");


            CopyPerson original = new CopyPerson(
                "Ahmed",
                new Address("Cairo")
            );


            // ========================================================
            // 1. Reference Copy
            // ========================================================
            //
            // Both variables point to the SAME object.
            // ========================================================

            CopyPerson copy = original;

            copy.Name = "Mohamed";

            Console.WriteLine(original.Name);
            // Mohamed


            // ========================================================
            // 2. Shallow Copy
            // ========================================================
            //
            // Creates a new Person object,
            // but nested reference objects are still shared.
            // ========================================================

            CopyPerson shallowCopy = original.ShallowCopy();

            shallowCopy.Address.City = "Giza";

            Console.WriteLine(original.Address.City);
            // Giza


            // ========================================================
            // 3. Deep Copy
            // ========================================================
            //
            // Creates a new Person object AND
            // a new Address object.
            //
            // The objects are completely independent.
            // ========================================================

            CopyPerson deepCopy = new CopyPerson(original);

            deepCopy.Address.City = "Alexandria";

            Console.WriteLine(original.Address.City);
            // Giza

            Console.WriteLine(deepCopy.Address.City);
            // Alexandria
        }
    }


    // ============================================================
    // ADDRESS
    // ============================================================

    class Address
    {
        public string City { get; set; }


        public Address(string city)
        {
            City = city;
        }


        // Copy constructor
        public Address(Address other)
        {
            City = other.City;
        }
    }


    // ============================================================
    // PERSON
    // ============================================================

    class CopyPerson
    {
        public string Name { get; set; }

        public Address Address { get; set; }


        public CopyPerson(string name, Address address)
        {
            Name = name;
            Address = address;
        }


        // ========================================================
        // Deep Copy
        // ========================================================
        //
        // Creates a new Person
        // and a new Address.
        // ========================================================

        public CopyPerson(CopyPerson other)
        {
            Name = other.Name;

            Address = new Address(other.Address);
        }


        // ========================================================
        // Shallow Copy
        // ========================================================
        //
        // Creates a new Person,
        // but Address is still shared.
        // ========================================================

        public CopyPerson ShallowCopy()
        {
            return (CopyPerson)MemberwiseClone();
        }
    }
}

