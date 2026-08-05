namespace CsharpFundamentals.CsharpOop;

internal static class CopySemantics
{
    public static void Run()
    {
        Console.WriteLine("\n========== Copy Semantics ==========");

        Person original = new("Karim", new Address("Cairo"));
        Person alias = original;
        Person shallowCopy = original.ShallowCopy();
        Person deepCopy = new(original);

        alias.Name = "Karim Ali";
        shallowCopy.Address.City = "Giza";
        deepCopy.Address.City = "Alexandria";

        Console.WriteLine($"Original name changed through alias: {original.Name}");
        Console.WriteLine($"Original city changed through shallow copy: {original.Address.City}");
        Console.WriteLine($"Deep-copy city is independent: {deepCopy.Address.City}");
    }

    private sealed class Address
    {
        public Address(string city)
        {
            City = city;
        }

        // A copy constructor creates an independent nested object.
        public Address(Address other) : this(other.City)
        {
        }

        public string City { get; set; }
    }

    private sealed class Person
    {
        public Person(string name, Address address)
        {
            Name = name;
            Address = address;
        }

        // This copy constructor performs a deep copy of the mutable Address object.
        public Person(Person other) : this(other.Name, new Address(other.Address))
        {
        }

        public string Name { get; set; }
        public Address Address { get; }

        // MemberwiseClone copies fields. Referenced nested objects are still shared.
        public Person ShallowCopy() => (Person)MemberwiseClone();
    }
}
