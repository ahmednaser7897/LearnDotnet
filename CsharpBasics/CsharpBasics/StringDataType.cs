namespace CsharpFundamentals.CsharpBasics
{
    using System.Globalization;
    using System.Text;

    class StringDataType
    {
        public static void Run()
        {
            StringBasics();
            StringCreation();
            StringLengthAndIndexing();
            StringConcatenation();
            StringInterpolation();
            StringCaseConversion();
            StringTrim();
            StringComparison();
            StringSearching();
            StringSubstrings();
            StringReplaceRemoveInsert();
            StringSplitJoin();
            StringNullChecks();
            StringsToNumbers();
            NumberToString();
            StringFormatting();
            VerbatimAndRawStrings();
            StringBuilderExample();
        }

        static void StringBasics()
        {
            Console.WriteLine("\n=== String Basics ===");

            string message = "Welcome to C#";

            Console.WriteLine(message);
            Console.WriteLine($"Length = {message.Length}");

            // String is immutable
            Console.WriteLine(message.ToUpper());
            Console.WriteLine(message); // Original unchanged
        }

        static void StringCreation()
        {
            Console.WriteLine("\n=== String Creation ===");

            string str1 = "Hello";
            string str2 = String.Empty;
            string str3 = new string('A', 5);//AAAAA

            Console.WriteLine(str1);
            Console.WriteLine($"Empty = '{str2}'");
            Console.WriteLine(str3);
        }

        static void StringLengthAndIndexing()
        {
            Console.WriteLine("\n=== Length And Indexing ===");

            string text = "Ahmed";

            Console.WriteLine($"Length = {text.Length}");
            Console.WriteLine($"First Character = {text[0]}");
            Console.WriteLine($"First Character = {text.First()}");
            Console.WriteLine($"Last Character = {text[text.Length - 1]}");
            Console.WriteLine($"Last Character = {text.Last()}");

        }

        static void StringConcatenation()
        {
            Console.WriteLine("\n=== String Concatenation ===");

            string first = "Hello";
            string second = "World";

            Console.WriteLine(first + " " + second);
            Console.WriteLine(string.Concat(first, " ", second));

            string s = "Chapter" + 2;
            Console.WriteLine(s);

            string s2 = "Supplement" + 'B';
            Console.WriteLine(s2);
        }

        static void StringInterpolation()
        {
            Console.WriteLine("\n=== String Interpolation ===");

            string name = "Ahmed";
            int age = 25;

            Console.WriteLine($"{name} is {age} years old");
        }

        static void StringCaseConversion()
        {
            Console.WriteLine("\n=== ToUpper / ToLower ===");

            string text = "Ahmed";

            Console.WriteLine(text.ToUpper());
            Console.WriteLine(text.ToLower());
        }

        static void StringTrim()
        {
            Console.WriteLine("\n=== Trim ===");

            string text = "   Ahmed   ";

            Console.WriteLine($"Before = [{text}]");
            Console.WriteLine($"After  = [{text.Trim()}]");
        }

        static void StringComparison()
        {
            Console.WriteLine("\n=== String Comparison ===");

            string str1 = "Hello";
            string str2 = "Hello";
            string str3 = "hello";

            Console.WriteLine(str1 == str2);

            Console.WriteLine(str1.Equals(str2));

            Console.WriteLine(
                str1.Equals(
                    str3));

            Console.WriteLine(string.Compare("Ahmed", "Mohamed"));
        }

        static void StringSearching()
        {
            Console.WriteLine("\n=== String Searching ===");

            string text = "Welcome to C# to Home";

            Console.WriteLine(text.Contains("to"));

            Console.WriteLine(text.StartsWith("Welcome"));

            Console.WriteLine(text.EndsWith("Home"));

            Console.WriteLine(text.IndexOf('o'));

            Console.WriteLine(text.IndexOf("to"));

            Console.WriteLine(text.IndexOf("to", 5));

            Console.WriteLine(text.LastIndexOf('o'));

            Console.WriteLine(text.LastIndexOf("to"));
        }

        static void StringSubstrings()
        {
            Console.WriteLine("\n=== Substring ===");

            string text = "Welcome to C#";

            Console.WriteLine(text.Substring(1));

            Console.WriteLine(text.Substring(1, 4));

            string fullName = "Ahmed Naser";

            int index = fullName.IndexOf(' ');

            string firstName = fullName.Substring(0, index);
            string lastName = fullName.Substring(index + 1);

            Console.WriteLine(firstName);
            Console.WriteLine(lastName);
        }

        static void StringReplaceRemoveInsert()
        {
            Console.WriteLine("\n=== Replace / Remove / Insert ===");

            string text = "Hello Ahmed";

            Console.WriteLine(text.Replace("Ahmed", "Ali"));

            Console.WriteLine(text.Remove(5));

            Console.WriteLine("Hello".Insert(5, " Ahmed"));
        }

        static void StringSplitJoin()
        {
            Console.WriteLine("\n=== Split / Join ===");

            string text = "Ahmed,Naser,Cairo";

            string[] parts = text.Split(',');

            foreach (string part in parts)
            {
                Console.WriteLine(part);
            }

            string result = string.Join(" - ", parts);

            Console.WriteLine(result);
        }

        static void StringNullChecks()
        {
            Console.WriteLine("\n=== Null Checks ===");

            string? str1 = "";
            string? str2 = "   ";
            string? str3 = null;

            Console.WriteLine(string.IsNullOrEmpty(str1));

            Console.WriteLine(string.IsNullOrWhiteSpace(str2));

            Console.WriteLine(string.IsNullOrEmpty(str3));
        }

        static void StringsToNumbers()
        {
            Console.WriteLine("\n=== String To Numbers ===");

            int intValue = int.Parse("123");

            double doubleValue =
                double.Parse(
                    "12.5",
                    CultureInfo.InvariantCulture);

            Console.WriteLine(intValue);

            Console.WriteLine(doubleValue);

            if (int.TryParse("456", out int result))
            {
                Console.WriteLine(result);
            }
        }

        static void NumberToString()
        {
            Console.WriteLine("\n=== Number To String ===");

            string s1 = 123.ToString();

            string s2 = Convert.ToString(123)!;

            string s3 = 123 + "";

            Console.WriteLine(s1);
            Console.WriteLine(s2);
            Console.WriteLine(s3);
        }

        static void StringFormatting()
        {
            Console.WriteLine("\n=== String Formatting ===");

            bool b = true;
            int i = 10;
            double d = 10.12345;
            char c = 'A';
            string s = "Hello";

            Console.WriteLine(
                "{0} {1} {2:F2} {3} {4}",
                b, i, d, c, s);

            Console.WriteLine(
                $"{b} {i} {d:F2} {c} {s}");
        }

        static void VerbatimAndRawStrings()
        {
            Console.WriteLine("\n=== Verbatim And Raw Strings ===");

            string path =
                @"C:\Users\Ahmed\Documents\Test.txt";

            Console.WriteLine(path);

            string json = """
        {
            "name": "Ahmed",
              "age": 25
        }
        """;

            Console.WriteLine(json);
        }

        static void StringBuilderExample()
        {
            Console.WriteLine("\n=== StringBuilder ===");

            StringBuilder sb = new StringBuilder();

            sb.Append("Hello");
            sb.Append(" ");
            sb.Append("Ahmed");

            Console.WriteLine(sb.ToString());
        }
    }
}
