using System.Text;

namespace CsharpFundamentals.ObjectOrientedProgramming
{
    internal class StringBuilderBasics
    {   // string is refrance type and immutable when we change on  it create new refrance and assaghn new value to it
        // StringBuilder is refrance type also but its mutable , you can change its value
        public static void Run()
        {
            RunArrayOfCharacterConcept();
            RunStringBuilderProperties();
            RunStringBuilderHowItWorks();
            Console.WriteLine("====================================\n\n\n");
            RunConstructorOverLoad();
            Console.WriteLine("====================================\n\n\n");
            RunStringBuilderMethods();
            Console.WriteLine("====================================\n\n\n");
            Generate();
            Console.WriteLine("====================================\n\n\n");
            TestStringBuilderPerformance();

        }
        static void RunArrayOfCharacterConcept()
        {
            Console.WriteLine("==================   Array Of Character Concept ==================");
            // char[] characters = new char[9];
            char[] characters;
            // Console.WriteLine(characters.Length);  // use of unassigned error

            characters = new char[9];

            characters[0] = 'M';
            characters[1] = 'e';
            characters[2] = 't';
            characters[3] = 'i';
            characters[4] = 'g';
            characters[5] = 'a';
            characters[6] = 't';
            characters[7] = 'o';
            characters[8] = 'r';



            // or
            characters = new char[9] { 'M', 'e', 't', 'i', 'g', 'a', 't', 'o', 'r' };

            // or
            characters = new char[] { 'M', 'e', 't', 'i', 'g', 'a', 't', 'o', 'r' };

            characters[0] = 'm'; // mutate

            Console.WriteLine(characters);
            Console.WriteLine();
        }

        static void RunStringBuilderProperties()
        {
            Console.WriteLine("==================  String Builder Properties ==================");

            var sb = new StringBuilder("Metigator");

            Console.WriteLine(sb.ToString());              // Metigator

            //the characters the object currently contains
            Console.WriteLine($"Length: {sb.Length}");     // 9  

            //  the number of characters that the object can contain.
            Console.WriteLine($"Capacity: {sb.Capacity}"); // 16 (default)

            // the maximum capacity, if it's reached,  OutOfMemoryException
            Console.WriteLine($"MaxCapacity: {sb.MaxCapacity}"); // 2,147,483,647  (default)

            Console.WriteLine($"First Letter: {sb[0]}");     // M  Index out of range exception 
            Console.WriteLine();
        }

        static void RunStringBuilderHowItWorks()
        {
            Console.WriteLine("================== StringBuilder How It Works ==================");
            var sb = new StringBuilder();
            // sb is a StringBuilder object
            // string value is empty, length 0, capacity 16, maxcapacity is 2,147,483,647

            sb.Append("I Love Metigator"); // add 16 character

            Console.WriteLine($"Length: {sb.Length}");           // 16
            Console.WriteLine($"Capacity: {sb.Capacity}");       // 16  (default)
            Console.WriteLine($"MaxCapacity: {sb.MaxCapacity}"); // 2,147,483,647 (default)

            sb.Append("Youtube Channel"); // add 15 character

            Console.WriteLine($"Length: {sb.Length}");           // 31
            Console.WriteLine($"Capacity: {sb.Capacity}");       // 32 (size doubled)
            Console.WriteLine($"MaxCapacity: {sb.MaxCapacity}"); // 2,147,483,647 (default)
            Console.WriteLine();
        }

        static void RunConstructorOverLoad()
        {
            Console.WriteLine("==================   Constructor OverLoads ==================");
            // StringBuilder ();
            var sb1 = new StringBuilder();
            // string value in string.Empty
            // capacity is set to the implementation-specific default 


            sb1.Append("Metigator");

            Console.WriteLine(sb1.ToString());
            Console.WriteLine($"Length: {sb1.Length}");
            Console.WriteLine($"Capacity: {sb1.Capacity}");
            Console.WriteLine($"MaxCapacity: {sb1.MaxCapacity}");
            Console.WriteLine("====================================");

            // StringBuilder (int capacity);
            // capacity is less than zero ArgumentOutOfRangeException  
            // capacity is zero =  default will be taken
            // capacity is extended to the default capacity if it fits
            var sb2 = new StringBuilder(8);

            sb2.Append("Metigator");

            Console.WriteLine(sb2.ToString());
            Console.WriteLine($"Length: {sb2.Length}"); // 9
            Console.WriteLine($"Capacity: {sb2.Capacity}"); // 16
            Console.WriteLine($"MaxCapacity: {sb2.MaxCapacity}"); //21..
            Console.WriteLine("====================================");

            // StringBuilder (string? value);
            // If value is null, the new StringBuilder will contain the empty string 
            var sb3 = new StringBuilder("Metigator");

            Console.WriteLine(sb3);
            Console.WriteLine($"Length: {sb3.Length}");
            Console.WriteLine($"Capacity: {sb3.Capacity}");
            Console.WriteLine($"MaxCapacity: {sb3.MaxCapacity}");
            Console.WriteLine("====================================");

            // StringBuilder (string? value, int capacity);
            // if capacity less than zero => ArgumentOutOfRangeException
            // additional allocation if the number of chars stored exceed capacity

            var sb4 = new StringBuilder("Metigator", 4);

            Console.WriteLine(sb4);
            Console.WriteLine($"Length: {sb4.Length}"); // 9
            Console.WriteLine($"Capacity: {sb4.Capacity}");
            Console.WriteLine($"MaxCapacity: {sb4.MaxCapacity}");
            Console.WriteLine("====================================");

            // StringBuilder (int capacity, int maxCapacity);
            // if capacity less than zero => ArgumentOutOfRangeException
            // if maxcapacity less than one => ArgumentOutOfRangeException
            // if capacity is zero implementation default capacity is used 
            // if capacity exeeds max capacity ArgumentOutOfRangeException

            var sb5 = new StringBuilder(0, 9);
            sb5.Append("Metigator");

            Console.WriteLine(sb5);
            Console.WriteLine($"Length: {sb5.Length}");  // 9
            Console.WriteLine($"Capacity: {sb5.Capacity}"); // 9 
            Console.WriteLine($"MaxCapacity: {sb5.MaxCapacity}"); //9
            Console.WriteLine("====================================");
            // StringBuilder (string? value, int startIndex, int length, int capacity);
            // If capacity is zero, the implementation-specific default capacity
            // if capacity less than zero => ArgumentOutOfRangeException
            // additional allocation if the number of chars stored exceed capacity
            // startIndex+length is not a position within value.=> ArgumentOutOfRangeException 

            //                          01234567
            var sb6 = new StringBuilder("I Love Metigator", 7, 9, 9);


            Console.WriteLine(sb6);
            Console.WriteLine($"Length: {sb6.Length}"); // 9
            Console.WriteLine($"Capacity: {sb6.Capacity}"); // 9
            Console.WriteLine($"MaxCapacity: {sb6.MaxCapacity}"); // 2, 147,0000
        }
        static void RunStringBuilderMethods()
        {
            Console.WriteLine("==================   StringBuilder Methods ==================");

            // ============================================================
            // Append
            // ============================================================
            // Adds text to the end of the StringBuilder.
            // Returns the same StringBuilder, so methods can be chained.

            var sb1 = new StringBuilder();

            sb1.Append("ƒ(x)")
               .Append("=")
               .Append("Σ")
               .Append("x²")
               .Append("±")
               .Append("α");

            Console.WriteLine("Append:");
            Console.WriteLine(sb1);
            Console.WriteLine("====================================");


            // ============================================================
            // AppendJoin
            // ============================================================
            // Adds multiple values with a separator between them.

            string[] words = { "I", "Love", "Metigator" };

            var sb2 = new StringBuilder();

            sb2.AppendJoin("°", words);

            Console.WriteLine("AppendJoin:");
            Console.WriteLine(sb2);
            Console.WriteLine("====================================");


            // ============================================================
            // AppendFormat
            // ============================================================
            // Adds a formatted string using placeholders.

            string customer = "Issam A";
            DateTime shippingDate = DateTime.Now;
            DateTime expectedDelivery = shippingDate.AddDays(7);
            decimal shippingCost = 29.99m;

            var sb3 = new StringBuilder();

            sb3.AppendFormat(
                "\nDear {0}," +
                "\n\nAt {1:t} on {1:D}, the order is on its way to you." +
                "\nIt's expected to be delivered at {2:t} on {2:D}." +
                "\nShipping cost: {3:c}." +
                "\n\t\t\tThanks for shopping with us!",

                customer,
                shippingDate,
                expectedDelivery,
                shippingCost
            );

            Console.WriteLine("AppendFormat:");
            Console.WriteLine(sb3);
            Console.WriteLine("====================================");


            // ============================================================
            // AppendLine
            // ============================================================
            // Adds text followed by a new line.

            var sb4 = new StringBuilder();

            sb4.AppendLine("C# is a modern, object-oriented, type-safe programming language.");
            sb4.AppendLine("C# enables developers to build secure and robust applications.");
            sb4.AppendLine("C# has its roots in the C family of languages.");

            Console.WriteLine("AppendLine:");
            Console.WriteLine(sb4);
            Console.WriteLine("====================================");


            // ============================================================
            // Insert
            // ============================================================
            // Inserts text at the specified index.

            var sb5 = new StringBuilder(
                "C# is a modern, object-, type-safe programming language"
            );

            sb5.Insert(23, "oriented");

            Console.WriteLine("Insert:");
            Console.WriteLine(sb5);
            Console.WriteLine("====================================");


            // ============================================================
            // Replace
            // ============================================================
            // Replaces all occurrences of a specified string.

            var sb6 = new StringBuilder();

            sb6.Append("Fetigator");

            Console.WriteLine("Before Replace:");
            Console.WriteLine(sb6);

            sb6.Replace("Fetigator", "Metigator");

            Console.WriteLine("After Replace:");
            Console.WriteLine(sb6);
            Console.WriteLine("====================================");


            // ============================================================
            // Remove
            // ============================================================
            // Removes a specified number of characters starting at an index.

            var sb7 = new StringBuilder();

            sb7.Append("Metigator xyx");

            Console.WriteLine("Before Remove:");
            Console.WriteLine(sb7);

            sb7.Remove(9, 4);

            Console.WriteLine("After Remove:");
            Console.WriteLine(sb7);
            Console.WriteLine("====================================");


            // ============================================================
            // Clear
            // ============================================================
            // Removes all characters from the StringBuilder.

            var sb8 = new StringBuilder();

            sb8.Append("Metigator");

            Console.WriteLine("Before Clear:");
            Console.WriteLine(sb8);

            sb8.Clear();

            Console.WriteLine("After Clear:");
            Console.WriteLine(sb8);
            Console.WriteLine("====================================");


            // ============================================================
            // GetChunks
            // ============================================================
            // Returns the StringBuilder content as a sequence of chunks.
            // Useful when working with large amounts of text.

            var sb9 = new StringBuilder();

            sb9.Append("I Love Metigator");
            sb9.Append(" Youtube Channel");

            int chunkNumber = 1;

            foreach (var chunk in sb9.GetChunks())
            {
                Console.WriteLine(
                    $"Chunk #{chunkNumber++}: \"{chunk}\" Length: {chunk.Length}"
                );
            }

            Console.WriteLine("====================================");


            // ============================================================
            // EnsureCapacity
            // ============================================================
            // Ensures that the StringBuilder has at least the specified capacity.
            // If the current capacity is already enough, nothing changes.

            var sb10 = new StringBuilder(10);

            Console.WriteLine("Before EnsureCapacity:");
            Console.WriteLine($"Capacity: {sb10.Capacity}");

            sb10.EnsureCapacity(12);

            Console.WriteLine("After EnsureCapacity(12):");
            Console.WriteLine($"Capacity: {sb10.Capacity}");

            Console.WriteLine("====================================");


            // ============================================================
            // CopyTo
            // ============================================================
            // Copies characters from the StringBuilder into a char array.

            var sb11 = new StringBuilder("Metigator");

            char[] characters = new char[sb11.Length];

            sb11.CopyTo(
                sourceIndex: 0,
                destination: characters,
                destinationIndex: 0,
                count: sb11.Length
            );

            Console.WriteLine("CopyTo:");
            Console.WriteLine(characters);
            Console.WriteLine("====================================");


            // ============================================================
            // Indexer
            // ============================================================
            // Accesses a character using its index.

            var sb12 = new StringBuilder("Metigator");

            char firstCharacter = sb12[0];

            Console.WriteLine("Indexer:");
            Console.WriteLine($"First character: {firstCharacter}");

            Console.WriteLine("====================================");
        }
        static void Generate()
        {
            Console.WriteLine("================== Generate ==================");
            Console.WriteLine(GenerateWithString());
            Console.WriteLine(GenerateWithStringBuilder());
            Console.WriteLine();
        }
        static string GenerateWithString()
        {
            //each step it it create new refrance and assaghn new value to it
            string str = null;

            str += String.Concat(new char[] { 'E', 'T', 'I' }); // ETI

            str += String.Format("GAT{0}{1}{2}", 'O', 'P', 'S'); // GATOPS

            str = "M" + str; // METIGATOPS

            str = str.Replace('P', 'R'); //METIGATORS

            str = str.Remove(str.Length - 1); // METIGATOR 

            return str;
        }
        static string GenerateWithStringBuilder()
        {
            //each step it update the same refrance
            StringBuilder sb = new StringBuilder();

            sb.Append(new char[] { 'E', 'T', 'I' }); // ETI

            sb.AppendFormat("GAT{0}{1}{2}", 'O', 'P', 'S'); // ETIGATOPS

            sb.Insert(0, "M"); // METIGATOPS

            sb.Replace('P', 'R'); //METIGATORS

            sb.Remove(sb.Length - 1, 1); // METIGATOR 

            return sb.ToString();
        }

        static void TestStringBuilderPerformance()
        {
            Console.WriteLine("==================Testing String vs StringBuilder Performance ==================");
            Console.WriteLine("Testing String Performance");

            // String is immutable.
            // Every concatenation creates a new string object.
            long startTime = DateTime.Now.Ticks;

            string s = "";

            for (int i = 0; i < 10000; i++)
            {
                s += i;
            }

            long endTime = DateTime.Now.Ticks;

            Console.WriteLine(
                $"String Time taken: {(endTime - startTime) / TimeSpan.TicksPerMillisecond} ms");

            Console.WriteLine();

            Console.WriteLine("Testing StringBuilder Performance");

            // StringBuilder is mutable.
            // It modifies the same object instead of creating a new string each time.
            long startTime1 = DateTime.Now.Ticks;

            StringBuilder s1 = new StringBuilder();

            for (int i = 0; i < 10_000; i++)
            {
                s1.Append(i);
            }

            long endTime1 = DateTime.Now.Ticks;

            Console.WriteLine(
                $"StringBuilder Time taken: {(endTime1 - startTime1) / TimeSpan.TicksPerMillisecond} ms");

            Console.WriteLine();
        }
    }
}