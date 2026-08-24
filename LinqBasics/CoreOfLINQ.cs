using Linq.FunctionalProgramming;

namespace Linq
{
    internal class CoreOfLINQ
    {
        public static void Run()
        {
            // Run Example 1.
            // Example1();

            // Run Example 2.
            // Example2();

            // Run Example 3.
            // Example3();

            // Run Example 4.
            Example4();
        }


        // ============================================================
        // Example 1 - Filter with Where
        // ============================================================

        public static void Example1()
        {
            Console.WriteLine("===================== Example 1 =====================");

            // Load all employees from the repository.
            var employees = Repository.LoadEmployees();

            // Filter female employees whose first name starts with "s".
            var femaleWithFnameStartsWithS01 = employees
                .Filter(employee =>
                    employee.Gender == "female" &&
                    employee.FirstName.ToLowerInvariant().StartsWith("s"));

            femaleWithFnameStartsWithS01.Print(
                "Female with first name starts with S / Filter");


            // Where is a LINQ extension method used to filter data.
            var femaleWithFnameStartsWithS02 = employees
                .Where(employee =>
                    employee.Gender == "female" &&
                    employee.FirstName.ToLowerInvariant().StartsWith("s"));

            femaleWithFnameStartsWithS02.Print(
                "Female with first name starts with S / Where");

            Console.WriteLine("==========================================");
            Console.WriteLine();
        }


        // ============================================================
        // Example 2 - Deferred Execution
        // ============================================================

        public static void Example2()
        {
            Console.WriteLine("===================== Example 2 =====================");

            // Create a list of numbers.
            List<int> numbers = new List<int>
            {
                1, 2, 3, 4, 5, 6, 7, 8, 9
            };

            // Where creates a query but does not execute it immediately.
            IEnumerable<int> evenNumbers =
                numbers.Where(number => number % 2 == 0);

            // Add new numbers after creating the query.
            numbers.Add(10);
            numbers.Add(12);

            // Remove a number before the query is executed.
            numbers.Remove(4);

            // The query is executed when we enumerate the result.
            foreach (var number in evenNumbers)
            {
                Console.Write($" {number}");
            }

            Console.WriteLine();

            // The result is 2, 6, 8, 10, 12 because the query runs later.
            Console.WriteLine("==========================================");
            Console.WriteLine();
        }


        // ============================================================
        // Example 3 - Different Ways to Use Where
        // ============================================================

        public static void Example3()
        {
            Console.WriteLine("===================== Example 3 =====================");

            // Create a list of numbers.
            List<int> numbers = new List<int>
            {
                1, 2, 3, 4, 5, 6, 7, 8, 9
            };


            // Use Where as an extension method.
            var numbersFilterUsingExtension =
                numbers.Where(number => number % 2 == 0);


            // Use Where directly from the Enumerable class.
            var numbersFilterUsingEnumerable =
                Enumerable.Where(numbers, number => number % 2 == 0);


            // Use LINQ query syntax to filter the numbers.
            var numbersFilterUsingQuery =
                from number in numbers
                where number % 2 == 0
                select number;


            // Print the result of the extension method.
            numbersFilterUsingExtension.Print(
                "Numbers Filtered Using Extension Method");


            // Print the result of the Enumerable method.
            numbersFilterUsingEnumerable.Print(
                "Numbers Filtered Using Enumerable");


            // Print the result of the query syntax.
            numbersFilterUsingQuery.Print(
                "Numbers Filtered Using Query Syntax");

            Console.WriteLine("==========================================");
            Console.WriteLine();
        }


        // ============================================================
        // Example 4 - Query Over Query
        // ============================================================

        public static void Example4()
        {
            Console.WriteLine("===================== Example 4 =====================");

            // Load all employees from the repository.
            var employees = Repository.LoadEmployees();


            // Filter male employees.
            var empMale = employees
                .Where(employee => employee.Gender == "male");

            empMale.Print("Male employees");


            // Filter employees with a salary greater than 300,000.
            var empSalaryOver300k = employees
                .Where(employee => employee.Salary > 300_000);

            empSalaryOver300k.Print(
                "Employees with Salary Over 300k");


            // Create a query for employees in the HR department.
            var hrEmployees = employees
                .Where(employee =>
                    employee.Department.ToLowerInvariant() == "hr");


            // Apply another filter to the HR employees.
            var hrMaleEmployees = hrEmployees
                .Where(employee => employee.Gender == "male");

            hrMaleEmployees.Print("Male HR employees");


            Console.WriteLine("==========================================");
            Console.WriteLine();
        }
    }
}
