namespace CsharpFundamentals.CsharpOop;

internal static class ClassesAndObjects
{
    public static void Run()
    {
        Console.WriteLine("\n========== Classes and Objects ==========");

        // A class is a reference-type blueprint. An object is one runtime instance of it.
        Student first = new Student("Mona", 101);
        Student second = new("Omar", 102); // Target-typed new expression.

        first.Enroll("C# OOP");
        second.Enroll("Algorithms");

        Console.WriteLine(first.GetSummary());
        Console.WriteLine(second.GetSummary());
        Console.WriteLine($"Students created: {Student.CreatedCount}");

        // Both variables now reference the same object. Mutating through one is visible through the other.
        Student alias = first;
        alias.Enroll("Design Patterns");
        Console.WriteLine($"Same object: {ReferenceEquals(first, alias)}");
        Console.WriteLine(first.GetSummary());

        Container.NestedHelper.PrintOwner();

        Profile profile = new("Nora");
        profile.PrintIdentity();
        profile.PrintPreferences();
    }

    private sealed class Student
    {
        // Instance fields belong to each object. Keep fields private by default.
        private readonly List<string> _courses = [];

        // A static field belongs to the type, not to any single object.
        private static int _createdCount;

        public Student(string name, int id)
        {
            Name = name;
            Id = id;
            _createdCount++;
        }

        public string Name { get; }
        public int Id { get; }
        public IReadOnlyList<string> Courses => _courses;
        public static int CreatedCount => _createdCount;

        public void Enroll(string course)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(course);
            _courses.Add(course);
        }

        public string GetSummary() => $"#{Id} {Name}: {string.Join(", ", _courses)}";
    }

    private static class Container
    {
        // A nested type is scoped inside its containing type.
        internal static class NestedHelper
        {
            public static void PrintOwner() => Console.WriteLine($"Nested inside {nameof(Container)}");
        }
    }

    // Partial declarations let generated code and handwritten code share one type.
    private sealed partial class Profile(string name)
    {
        public string Name { get; } = name;
        public void PrintIdentity() => Console.WriteLine($"Profile: {Name}");
    }

    private sealed partial class Profile
    {
        public void PrintPreferences() => Console.WriteLine("Preferences loaded by another partial declaration.");
    }
}

