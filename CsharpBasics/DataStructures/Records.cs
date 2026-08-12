namespace CsharpFundamentals.DataStructures
{
    internal class Records
    {
        public static void Run()
        {
            NormalClassExample();
            Console.WriteLine("=======================================");
            RecordExample();
            Console.WriteLine("=======================================");
            PositionalRecordExample();
            Console.WriteLine("=======================================");
            RecordStructExample();
            Console.WriteLine("=======================================");
            RecordShallowCopy();
            Console.WriteLine("=======================================");
        }

        public static void NormalClassExample()
        {
            Console.WriteLine($"------------ Normal Class Example ------------");
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
            //dic2.Add(c2, "two");

            Console.WriteLine($"dic2.Count --> {dic2.Count}");
        }
        public static void RecordExample()
        {
            Console.WriteLine($"------------ Record Example ------------");
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
        }
        public static void PositionalRecordExample()
        {
            Console.WriteLine($"------------ Positional Record Example ------------");
            // This will not work because c1 is not a positional record.
            //Complex c1 = new Complex(1, 1);
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
        public static void RecordStructExample()
        {
            Console.WriteLine($"------------ Record Struct Example ------------");

            PointRecordStruct p1 = new PointRecordStruct(10, 20);
            PointRecordStruct p2 = new PointRecordStruct(10, 20);

            //-------------------------------------------------
            // Value Equality
            //-------------------------------------------------

            // record struct compares values automatically.
            // We do not need to override Equals() or ==.
            Console.WriteLine($"p1 == p2 --> {p1 == p2}");
            Console.WriteLine($"p1.Equals(p2) --> {p1.Equals(p2)}");

            //-------------------------------------------------
            // ToString
            //-------------------------------------------------

            // record struct gives us a useful ToString()
            // automatically like a normal record.
            Console.WriteLine($"p1 --> {p1}");

            //-------------------------------------------------
            // GetHashCode
            //-------------------------------------------------

            // Equal record structs generate the same hash code.
            Console.WriteLine($"p1.GetHashCode() --> {p1.GetHashCode()}");
            Console.WriteLine($"p2.GetHashCode() --> {p2.GetHashCode()}");

            //-------------------------------------------------
            // Deconstruction
            //-------------------------------------------------

            // Positional record struct supports deconstruction.
            var (x, y) = p1;

            Console.WriteLine($"x --> {x}");
            Console.WriteLine($"y --> {y}");

            //-------------------------------------------------
            // Value Type
            //-------------------------------------------------

            // record struct is a VALUE TYPE.
            // p3 gets its own copy of p1.
            PointRecordStruct p3 = p1;

            Console.WriteLine($"p1 --> {p1}");
            Console.WriteLine($"p3 --> {p3}");

            //-------------------------------------------------
            // Changing Values
            //-------------------------------------------------

            // Unlike a positional record class,
            // positional record struct properties are mutable
            // by default.
            p3.x = 100;

            Console.WriteLine("\nAfter Changing p3:");

            Console.WriteLine($"p1 --> {p1}");
            Console.WriteLine($"p3 --> {p3}");

            // p1 does not change because record struct
            // is a value type and p3 has its own copy.
        }
        public static void RecordShallowCopy()
        {
            Console.WriteLine($"------------ Record Shallow Copy ------------");
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
    // when creating a record its look like creating class with all the next 
    // the makes the class look live value type
    // override object equal
    // override object GetHashCode
    // override object ToString()
    // override object == , !=
    // implemenr IEquatable
    // but by defults it not immutable you can change the mempers values
    // unless you make it get only without set
    // or using Positional records
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


    //---------------------------------------------------------
    // Positional Record Struct
    //---------------------------------------------------------

    // record struct combines features from records and structs.
    //
    // Like record:
    // - Gives value equality automatically.
    // - Overrides Equals().
    // - Overrides GetHashCode().
    // - Overrides ToString().
    // - Supports == and !=.
    // - Supports deconstruction.
    // - Supports "with".
    //
    // Like struct:
    // - It is a VALUE TYPE.
    // - Assignment copies the value instead of the reference.
    //
    // Important:
    // A positional record struct is mutable by default.
    // Its generated properties have get and set.
    //
    // If we want it to be immutable, we can use:
    //
    // readonly record struct PointRecordStruct(int x, int y);
    //
    record struct PointRecordStruct(int x, int y);

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
