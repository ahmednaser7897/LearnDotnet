namespace Linq.JoinOperations
{
    internal class LinqJoins
    {
        public static void Run()
        {
            // Run the Join method syntax example.
            // RunJoin();

            // Run the Join query syntax example.
            // RunJoinQuerySyntax();

            // Run the GroupJoin method syntax example.
            // RunGroupJoin();

            // Run the GroupJoin query syntax example.
            RunGroupJoinQuerySyntax();
        }


        // ============================================================
        // Join - Method Syntax
        // ============================================================

        private static void RunJoin()
        {
            // Load employees from the repository.
            var employees = Repository.LoadEmployees();

            // Load departments from the repository.
            var departments = Repository.LoadDepartment();

            // Join employees with their departments using matching IDs.
            var query = employees.Join(
                departments,
                emp => emp.DepartmentId,
                dept => dept.Id,
                (emp, dept) => new
                {
                    emp.FullName,
                    dept.Name
                });


            // Print each employee with their department.
            foreach (var item in query)
            {
                Console.WriteLine($"{item.FullName} [{item.Name}]");
            }
        }


        // ============================================================
        // Join - Query Syntax
        // ============================================================

        private static void RunJoinQuerySyntax()
        {
            // Load employees from the repository.
            var employees = Repository.LoadEmployees();

            // Load departments from the repository.
            var departments = Repository.LoadDepartment();

            // Join employees with departments using query syntax.
            var query =
                from emp in employees
                join dep in departments
                    on emp.DepartmentId equals dep.Id
                select new
                {
                    emp.FullName,
                    dep.Name
                };


            // Print each employee with their department.
            foreach (var item in query)
            {
                Console.WriteLine($"{item.FullName} [{item.Name}]");
            }
        }


        // ============================================================
        // GroupJoin - Method Syntax
        // ============================================================

        private static void RunGroupJoin()
        {
            // Load employees from the repository.
            var employees = Repository.LoadEmployees();

            // Load departments from the repository.
            var departments = Repository.LoadDepartment();

            // Group employees under their matching department.
            var query = departments.GroupJoin(
                employees,
                dept => dept.Id,
                emp => emp.DepartmentId,
                (dept, emps) => new
                {
                    Department = dept.Name,
                    Employees = emps
                });


            // Loop through each department group.
            foreach (var group in query)
            {
                Console.WriteLine();
                Console.WriteLine(
                    $"********************** {group.Department} ***********************");
                Console.WriteLine();

                // Print all employees in the current department.
                foreach (var item in group.Employees)
                {
                    Console.WriteLine($"{item.FullName}");
                }
            }
        }


        // ============================================================
        // GroupJoin - Query Syntax
        // ============================================================

        private static void RunGroupJoinQuerySyntax()
        {
            // Load employees from the repository.
            var employees = Repository.LoadEmployees();

            // Load departments from the repository.
            var departments = Repository.LoadDepartment();

            // Group employees by their matching department.
            var empGroups =
                from dept in departments
                join emp in employees
                    on dept.Id equals emp.DepartmentId into empGroup
                select empGroup;


            // Loop through each employee group.
            foreach (var group in empGroups)
            {
                Console.WriteLine("--------------------------------");

                // Print each employee in the current group.
                foreach (var item in group)
                {
                    Console.WriteLine($"{item.FullName}");
                }
            }
        }
    }
}