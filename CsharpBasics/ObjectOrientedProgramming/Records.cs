namespace CsharpFundamentals.ObjectOrientedProgramming
{
    internal class Records
    {
        public static void Run()
        {
            NormalClassExample();
            Console.WriteLine("=======================================");

            RecordExample();
            Console.WriteLine("=======================================");

            RecordShallowCopy();
            Console.WriteLine("=======================================");
        }

        public static void NormalClassExample()
        {
            // Dictionary works using HashCode.
            // So, if we try to add a key whose hash code already exists
            // for another key with the same hash code.

            Console.WriteLine($"1 == 1 --> {1 == 1}");
            Console.WriteLine($"1.Equals(1) --> {1.Equals(1)}");
            Console.WriteLine($"1.GetHashCode() --> {1.GetHashCode()}");

            var dic1 = new Dictionary<int, string>();

            dic1.Add(1, "one");
            dic1.Add(2, "two");

            // This will cause an error because the key 1 already exists in the Dictionary.
            // dic1.Add(1, "three");

            Console.WriteLine($"dic1.Count --> {dic1.Count}");

            Complex c1 = new Complex(1, 1);
            Complex c2 = new Complex(1, 1);

            Console.WriteLine($"c1 == c2 --> {c1 == c2}");
            Console.WriteLine($"c1.Equals(c2) --> {c1.Equals(c2)}");
            Console.WriteLine($"c1.GetHashCode() --> {c1.GetHashCode()}");
            Console.WriteLine($"c2.GetHashCode() --> {c2.GetHashCode()}");

            var dic2 = new Dictionary<Complex, string>();

            dic2.Add(c1, "one");

            // For now, this will not cause an error because even though c1 == c2,
            // they do not have an overridden GetHashCode() with the same value.
            // For now, I am using the base value:
            // return base.GetHashCode();
            //
            // If I change this logic so that Equals() for Complex objects
            // returns true, I have to update GetHashCode() to return
            // a fixed hash code for equal Complex objects.
            //
            // For example:
            // return HashCode.Combine(Real, Img);
            //
            // This will cause an error.
            dic2.Add(c2, "two");

            Console.WriteLine($"dic2.Count --> {dic2.Count}");
        }

        public static void RecordExample()
        {
            ComplexRecord c1 = new ComplexRecord(1, 1);
            ComplexRecord c2 = new ComplexRecord(1, 1);

            // Record gives us a good string representation without overriding ToString().
            Console.WriteLine($"c1 --> {c1}");

            // Record compares values by default without overriding == operator or Equals().
            Console.WriteLine($"c1 == c2 --> {c1 == c2}");
            Console.WriteLine($"c1.Equals(c2) --> {c1.Equals(c2)}");

            // Record returns the same hash code by default
            // if the records have the same public attribute values.
            Console.WriteLine($"c1.GetHashCode() --> {c1.GetHashCode()}");
            Console.WriteLine($"c2.GetHashCode() --> {c2.GetHashCode()}");

            var dic1 = new Dictionary<ComplexRecord, string>();

            dic1.Add(c1, "one");

            // For now, this will cause an error because c1 == c2
            // and they have the same hash code because
            // the two records have the same public attribute values.
            // dic1.Add(c2, "two");

            Console.WriteLine($"dic2.Count --> {dic1.Count}");

            // This will not work because c1 is not a positional record.
            // var (x, y) = c1;

            var c3 = new PointRecord(2, 4);

            // This will work because c3 is a positional record.
            var (x, y) = c3;

            Console.WriteLine($"c3 --> {c3}");
            Console.WriteLine($"x and y --> {x} - {y}");

            // We cannot change positional record values once it is created.
            // c3.x = 10; // Will not work.

            // But we can copy it --> values copy.

            // Copy it as it is.
            var c4 = c3;

            Console.WriteLine($"c4 --> {c4}");

            // Copy it by changing values.
            var c5 = c3 with { x = 10 };

            Console.WriteLine($"c5 --> {c5}");
        }

        public static void RecordShallowCopy()
        {
            Student student = new Student(
                "ahmed",
                25,
                new StudentAddress("cairo", "helwan")
            );

            Console.WriteLine(student);

            // We cannot change positional record values once it is created
            // because it is immutable.
            // So this will not work.
            // student.name = "mohamed";

            // But it has shallow immutability.
            // It does not make reference types immutable.
            // So this will work.
            student.address.City = "Alex";

            Console.WriteLine(student);
        }
    }

    record ComplexRecord
    {
        public int Real;
        public int Img;

        public ComplexRecord(int Real, int Img)
        {
            this.Real = Real;
            this.Img = Img;
        }
    }

    // Positional records have simple syntax.
    // All fields are init-only; once the record is created, they cannot be changed.
    // It helps us enable deconstruction.
    // It helps us enable immutability.
    record PointRecord(int x, int y);

    record Student(string name, int age, StudentAddress address);

    // This is called a primary constructor.
    class StudentAddress(string city, string street)
    {
        public string City { get; set; } = city;
        public string Street { get; set; } = street;

        public override string ToString()
        {
            return $"city is {City} - street is {Street}";
        }
    }
}
