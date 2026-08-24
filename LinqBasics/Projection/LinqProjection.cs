namespace Linq.Projection
{
    // Projection transforms objects or values into a new form.
    // It can create a new type, create new properties, or perform calculations.
    public class LinqProjection
    {
        public static void Run()
        {
            // Run Select examples.
            // SelectExamples();

            // Run SelectMany examples.
            // SelectManyExamples();

            // Run Zip examples.
            ZipExamples();
        }


        // ============================================================
        // Select Examples
        // ============================================================

        public static void SelectExamples()
        {
            Console.WriteLine("===================== Select Examples =====================");

            // Create a list of words.
            // string[] words01 = { "I", "love", "asp.net", "core" };

            List<string> words = new() { "i", "love", "asp.net", "core" };

            // Select can return the same value without changing it.
            // var result01 = words.Select(x => { return x; });

            // Select transforms each word to uppercase.
            var result = words.Select(x => x.ToUpper());

            // Select can also be used with query syntax.
            // var result02 = from word in words
            //                select word.ToUpper();

            // Print each transformed word.
            foreach (var word in result)
                Console.WriteLine(word);


            Console.WriteLine("==========================================");


            // Create a list of numbers.
            List<int> numbers = new() { 2, 3, 5, 7 };

            // Select can perform a mathematical operation on each item.
            // var result01 = words.Select(x => { return x; });

            // Square each number.
            var result2 = numbers.Select(x => x * x);

            // The same operation can be written using query syntax.
            // var result02 = from n in numbers
            //                select n * n;

            // Print each calculated number.
            foreach (var n in result2)
                Console.WriteLine(n);


            Console.WriteLine("==========================================");


            // Load all employees from the repository.
            var employees = Repository.LoadEmployees();

            // Select can create a new object from an existing object.
            // Here, Employee is projected into EmployeeDto.
            var result3 = employees.Select(x =>
            {
                return new EmployeeDto
                {
                    Name = $"{x.FirstName} {x.LastName}",
                    TotalSkills = x.Skills.Count()
                };
            });

            // Print each EmployeeDto object.
            foreach (var n in result3)
                Console.WriteLine(n);


            Console.WriteLine("==========================================");
            Console.WriteLine();
        }


        // ============================================================
        // SelectMany Examples
        // ============================================================

        public static void SelectManyExamples()
        {
            Console.WriteLine("===================== Select Many Examples =====================");

            // Create an array of sentences.
            string[] sentences =
            {
                "I love asp.net core",
                "I like sql server also",
                "in general i love programming"
            };

            // Select returns an array for each sentence.
            // The result contains multiple arrays.
            var words1 = sentences.Select(x => x.Split(' '));

            // Print each array.
            foreach (var word in words1)
                Console.WriteLine(word);


            // SelectMany flattens all arrays into one sequence of words.
            var words2 = sentences.SelectMany(x => x.Split(' '));

            // Print each word separately.
            foreach (var word in words2)
                Console.WriteLine(word);


            Console.WriteLine("==========================================");


            // Load all employees from the repository.
            var employees = Repository.LoadEmployees();

            // SelectMany gets all skills from all employees.
            // Distinct removes duplicate skills.
            var skills = employees
                .SelectMany(x => x.Skills)
                .Distinct();

            // The same operation can be written using query syntax.
            var result01 =
                (from employee in employees
                 from skill in employee.Skills
                 select skill)
                .Distinct();

            // Print each unique skill.
            foreach (var skill in result01)
                Console.WriteLine(skill);


            Console.WriteLine("==========================================");
            Console.WriteLine();
        }


        // ============================================================
        // Zip Examples
        // ============================================================

        public static void ZipExamples()
        {
            Console.WriteLine("===================== Zip Examples =====================");

            // Zip combines two sequences by matching items by their position.
            string[] colorName = { "Red", "Green", "Blue" };
            string[] colorHEX = { "FF0000", "00FF00", "0000FF", "extra" };

            // Create a new sequence by combining the color name and HEX value.
            // Zip stops when the shorter sequence ends.
            var colors = colorName.Zip(
                colorHEX,
                (name, hex) => $"{name} ({hex})");

            // Print each combined color.
            foreach (var c in colors)
                Console.WriteLine(c);


            Console.WriteLine("==========================================");


            // Load employees and convert the result to an array.
            var employees = Repository.LoadEmployees().ToArray();

            // Get the first three employees.
            var firstThreeEmps = employees[..3];

            // Get the last three employees.
            var lastThreeEmps = employees[^3..];


            // Combine the first three employees with the last three employees.
            var teams = firstThreeEmps.Zip(
                lastThreeEmps,
                (first, last) =>
                    $"{first.FullName} with {last.FullName}");


            // Zip can also be used with query syntax.
            var teams01 =
                from team in firstThreeEmps.Zip(lastThreeEmps)
                select $"{team.First.FullName} with {team.Second.FullName}";

            // Print each combined team.
            foreach (var team in teams01)
                Console.WriteLine(team);


            Console.WriteLine("==========================================");
            Console.WriteLine();
        }
    }


    // DTO used to store selected employee information.
    internal class EmployeeDto
    {
        // Store the employee's full name.
        public string Name { get; set; }

        // Store the number of employee skills.
        public int TotalSkills { get; set; }


        // Return a readable representation of the DTO.
        public override string ToString()
        {
            return $"{Name} ({TotalSkills})";
        }
    }
}
```
