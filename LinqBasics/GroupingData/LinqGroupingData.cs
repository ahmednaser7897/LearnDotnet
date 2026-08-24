namespace Linq.GroupingData
{
    internal class LinqGroupingData
    {
        public static void Run()
        {
            // Run the GroupBy method syntax example.
            RunGroupByExample();

            // Run the ToLookup method syntax example.
            RunLookupExample();

            // Run the GroupBy query syntax example.
            RunGroupByWithQuerySyntax();
        }


        // ============================================================
        // GroupBy Example
        // ============================================================

        private static void RunGroupByExample()
        {
            Console.WriteLine();
            Console.WriteLine("+++++++++++++++++++++++");
            Console.WriteLine("GroupBy (Method Syntax)");
            Console.WriteLine("+++++++++++++++++++++++");
            Console.WriteLine();


            // Load all employees from the repository.
            var employees = Repository.LoadEmployees();

            // Group employees by their department.
            var result = employees.GroupBy(x => x.Department);


            // Loop through each department group.
            foreach (var item in result)
            {
                // Print the employees in the current department.
                item.Print($"Employees in '{item.Key}' Department");
            }
        }


        // ============================================================
        // ToLookup Example
        // ============================================================

        private static void RunLookupExample()
        {
            Console.WriteLine();
            Console.WriteLine("+++++++++++++++++++++++");
            Console.WriteLine("ToLookup (Method Syntax)");
            Console.WriteLine("+++++++++++++++++++++++");
            Console.WriteLine();


            // Load all employees from the repository.
            var employees = Repository.LoadEmployees();

            // Create a lookup that groups employees by department.
            var result = employees.ToLookup(x => x.Department);


            // Loop through each department group.
            foreach (var item in result)
            {
                // Print the employees in the current department.
                item.Print($"Employees in '{item.Key}' Department");
            }
        }


        // ============================================================
        // GroupBy With Query Syntax
        // ============================================================

        private static void RunGroupByWithQuerySyntax()
        {
            Console.WriteLine();
            Console.WriteLine("+++++++++++++++++++++++");
            Console.WriteLine("GroupBy (Query Syntax)");
            Console.WriteLine("+++++++++++++++++++++++");
            Console.WriteLine();


            // Load all employees from the repository.
            var employees = Repository.LoadEmployees();

            // Group employees by department using query syntax.
            var result =
                from emp in employees
                group emp by emp.Department;


            // Loop through each department group.
            foreach (var item in result)
            {
                // Print the employees in the current department.
                item.Print($"Employees in '{item.Key}' Department");
            }
        }
    }
}
