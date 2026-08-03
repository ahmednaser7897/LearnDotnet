namespace CsharpFundamentals.CsharpBasics
{
    class CharDataType
    {
        public static void Run()
        {
            CharBasic();
            CastingCharAndInt();
            ComparisonTestingCharacters();
            CharacterClassMethods();
        }

        static void CharBasic()
        {
            // char is a 16-bit Unicode character

            Console.WriteLine("char declaration");

            char letter = 'A';           // ASCII
            char numChar = '4';          // ASCII
            char letter2 = '\u0041';     // Unicode
            char numChar2 = '\u0034';    // Unicode

            Console.WriteLine($"letter = {letter}");
            Console.WriteLine($"numChar = {numChar}");
            Console.WriteLine($"letter2 = {letter2}");
            Console.WriteLine($"numChar2 = {numChar2}");

            char num = '5';
            Console.WriteLine($"num = {num}");

            char letter3 = 'A';
            Console.WriteLine($"letter3 = {letter3}");

            char specialChar = '@';
            Console.WriteLine($"specialChar = {specialChar}");

            char space = ' ';
            Console.WriteLine($"space = [{space}]");

            // increment and decrement char
            char b = 'B';
            b++;
            Console.WriteLine($"increment B = {b}");

            b--;
            Console.WriteLine($"decrement B = {b}");
        }

        static void CastingCharAndInt()
        {
            Console.WriteLine("\ncasting char and int");

            int i = 'a';          // implicit conversion
            char c = (char)97;    // explicit conversion required

            Console.WriteLine($"i = {i}");
            Console.WriteLine($"c = {c}");
        }

        static void ComparisonTestingCharacters()
        {
            Console.WriteLine("\ncomparison testing characters");

            char ch = 'A';

            if (ch >= 'A' && ch <= 'Z')
                Console.WriteLine($"{ch} is an uppercase letter");
            else if (ch >= 'a' && ch <= 'z')
                Console.WriteLine($"{ch} is a lowercase letter");
            else if (ch >= '0' && ch <= '9')
                Console.WriteLine($"{ch} is a numeric character");
        }

        static void CharacterClassMethods()
        {
            Console.WriteLine("\ncharacter class methods");

            char ch = 'A';

            Console.WriteLine($"IsUpper = {char.IsUpper(ch)}");
            Console.WriteLine($"IsLower = {char.IsLower(ch)}");
            Console.WriteLine($"IsLetterOrDigit = {char.IsLetterOrDigit(ch)}");
            Console.WriteLine($"IsDigit = {char.IsDigit(ch)}");
            Console.WriteLine($"IsLetter = {char.IsLetter(ch)}");
            Console.WriteLine($"ToLower = {char.ToLower(ch)}");
            Console.WriteLine($"ToUpper = {char.ToUpper(ch)}");
        }
    }
}
