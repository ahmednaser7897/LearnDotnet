namespace Linq.Quantifiers
{
    internal class LinqQuantifiers
    {
        public static void Run()
        {
            // Run the Any() examples.
            // RunAny();

            // Run the All() examples.
            // RunAll();

            // Run Any() and All() using query syntax.
            // RunAnyAllQuerySyntax();

            // Run the Contains() example.
            RunContain();
        }


        // ============================================================
        // Any() Examples
        // ============================================================

        private static void RunAny()
        {
            Console.WriteLine();
            Console.WriteLine("+++++++++");
            Console.WriteLine("Run Any()");
            Console.WriteLine("+++++++++");
            Console.WriteLine();


            // Load all employees from the repository.
            var employees = Repository.LoadEmployees();


            // Check if any employee's name starts with the given text.
            var input1 = "jac";

            var result1 = employees.Any(
                e => e.Name.StartsWith(
                    input1,
                    StringComparison.OrdinalIgnoreCase));

            Console.WriteLine(
                $"Find employee with name starts with '{input1}' result: {result1}");


            // Check if any employee has a salary less than the given value.
            var input2 = 10000;

            var result2 = employees.Any(e => e.Salary < input2);

            Console.WriteLine(
                $"At least one employee with salary less than {input2.ToString("C2")} result: {result2}");


            // Check if any employee has fewer skills than the given number.
            var noOfSkills = 1;

            var result3 = employees.Any(
                e => e.Skills.Count < noOfSkills);

            Console.WriteLine(
                $"At least one employee with skill count less than {noOfSkills} result: {result3}");
        }


        // ============================================================
        // All() Examples
        // ============================================================

        private static void RunAll()
        {
            Console.WriteLine();
            Console.WriteLine("+++++++++");
            Console.WriteLine("Run All()");
            Console.WriteLine("+++++++++");
            Console.WriteLine();


            // Load all employees from the repository.
            var employees = Repository.LoadEmployees();


            // Check if all employees have an email.
            var result1 = employees.All(
                e => !string.IsNullOrWhiteSpace(e.Email));

            Console.WriteLine(
                $"All employees have email result: {result1}");


            // Check if all employees have at least one skill containing "C#".
            var result2 = employees.All(
                e => e.Skills.Any(x => x.Contains("C#")));

            Console.WriteLine(
                $"All employees have C# in their skills list result: {result2}");
        }


        // ============================================================
        // Any() and All() Query Syntax Examples
        // ============================================================

        private static void RunAnyAllQuerySyntax()
        {
            Console.WriteLine();
            Console.WriteLine("++++++++++++++++++++++++++++++++++");
            Console.WriteLine("Run All() + Any() Query Expression");
            Console.WriteLine("++++++++++++++++++++++++++++++++++");
            Console.WriteLine();


            // Load all employees from the repository.
            var employees = Repository.LoadEmployees();


            // Find employees whose skills all contain the letter "c".
            var result1 =
                from emp in employees
                where emp.Skills.All(
                    x => x.Contains(
                        "c",
                        StringComparison.OrdinalIgnoreCase))
                select emp;

            result1.Print("Employees having all skills containing 'c'");


            // Find employees who have at least one skill containing "node".
            var result2 =
                from emp in employees
                where emp.Skills.Any(
                    x => x.Contains(
                        "node",
                        StringComparison.OrdinalIgnoreCase))
                select emp;

            result2.Print("Employees having skill 'node'");
        }


        // ============================================================
        // Contains() Examples
        // ============================================================

        private static void RunContain()
        {
            Console.WriteLine();
            Console.WriteLine("++++++++++++++");
            Console.WriteLine("Run Contains()");
            Console.WriteLine("++++++++++++++");
            Console.WriteLine();


            // Load all employees from the repository.
            var employees = Repository.LoadEmployees();


            // Get the first employee from the collection.
            var e1 = employees.ToArray()[0];


            // Check if the collection contains the same employee object.
            var result1 = employees.Contains(e1);

            Console.WriteLine(
                $"Find if any employee contains " +
                $"'{e1.Email}' in his/her name result: {result1}");


            // Create a new employee object with the same email.
            var e2 = new Employee
            {
                Email = "Cole.Cochran02@example.com"
            };


            // Check if the collection contains this employee object.
            var result2 = employees.Contains(e2);

            Console.WriteLine(
                $"Find if any employee contains " +
                $"'{e2.Email}' in his/her name result: {result2}");
        }
    }
}

