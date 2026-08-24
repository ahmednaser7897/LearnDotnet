namespace Linq.Sorting
{
    internal class LinqSorting
    {
        public static void Run()
        {
            // Run OrderBy examples.
            // OrderByExamples();

            // Run ThenBy examples.
            // ThenByExamples();

            // Run OrderBy with a custom comparer examples.
            // OrderByWithComparerExamples();

            // Run Reverse examples.
            ReverseExamples();
        }


        // ============================================================
        // OrderBy Examples
        // ============================================================

        public static void OrderByExamples()
        {
            Console.WriteLine("===================== Order By Examples =====================");

            // Create an array of fruits.
            string[] fruits =
            {
                "apricot",
                "orange",
                "banana",
                "mango",
                "apple",
                "grape",
                "strawberry"
            };


            // Order the fruits in ascending order using method syntax.
            var orderedFruits = fruits.OrderBy(f => f);

            orderedFruits.Print("Fruits Ascending (Method Syntax)");


            // Order the fruits in ascending order using query syntax.
            var orderedFruitsQ =
                from f in fruits
                orderby f ascending
                select f;

            orderedFruitsQ.Print("Fruits Ascending (Query Syntax)");


            // Order the fruits in descending order using method syntax.
            var orderedFruitsDesc = fruits.OrderByDescending(f => f);

            orderedFruitsDesc.Print("Fruits Descending (Method Syntax)");


            // Order the fruits in descending order using query syntax.
            var orderedFruitsDescQ =
                from f in fruits
                orderby f descending
                select f;

            orderedFruitsDescQ.Print("Fruits Descending (Query Syntax)");


            // Order the fruits by their length in ascending order.
            var orderedFruitsAscLength = fruits.OrderBy(f => f.Length);

            orderedFruitsAscLength.Print("Fruits Ascending Length (Method Syntax)");


            // Order the fruits by their length in descending order using query syntax.
            var orderedFruitsAscLengthQ =
                from f in fruits
                orderby f.Length descending
                select f;

            orderedFruitsAscLengthQ.Print("Fruits Descending Length (Query Syntax)");


            Console.WriteLine("==========================================");
            Console.WriteLine();
        }


        // ============================================================
        // ThenBy Examples
        // ============================================================

        public static void ThenByExamples()
        {
            Console.WriteLine("===================== Then By Examples =====================");

            // Load employees from the repository.
            var emps = Repository.LoadEmployees();


            // Sort employees by name first, then by salary in ascending order.
            var sortedEmps01 =
                emps.OrderBy(x => x.Name)
                    .ThenBy(x => x.Salary);

            sortedEmps01.Print("sortedEmps01");


            // Sort employees by name first, then by salary in descending order.
            var sortedEmps02 =
                emps.OrderBy(x => x.Name)
                    .ThenByDescending(x => x.Salary);

            sortedEmps02.Print("sortedEmps02");


            Console.WriteLine("==========================================");
            Console.WriteLine();
        }


        // ============================================================
        // OrderBy With Comparer Examples
        // ============================================================

        public static void OrderByWithComparerExamples()
        {
            Console.WriteLine(
                "===================== Order By With Comparer Examples =====================");

            // Load employees as an IEnumerable.
            IEnumerable<Employee> emps = Repository.LoadEmployees();


            // Sort employees by EmployeeNo using the default comparer.
            // IOrderedEnumerable<Employee> sortedEmps =
            //     emps.OrderBy(e => e.EmployeeNo);


            // Sort employees using a custom EmployeeComparer.
            IOrderedEnumerable<Employee> sortedEmps =
                emps.OrderBy(e => e, new EmployeeComparer());

            sortedEmps.Print("Sorted Employees");


            Console.WriteLine("==========================================");
            Console.WriteLine();
        }


        // ============================================================
        // Reverse Examples
        // ============================================================

        public static void ReverseExamples()
        {
            Console.WriteLine("===================== Reverse Examples =====================");

            // Create an array of fruits.
            string[] fruits =
            {
                "apricot",
                "orange",
                "banana",
                "mango",
                "apple",
                "grape",
                "strawberry"
            };


            // Reverse returns the elements in reverse order.
            var reveredOrder = fruits.Reverse();


            // Calling Reverse without using its returned result does nothing to the original array.
            // fruits.Reverse();


            // Print the original array.
            fruits.Print("Employees in Reverse Order");


            Console.WriteLine("==========================================");
            Console.WriteLine();
        }
    }
}
