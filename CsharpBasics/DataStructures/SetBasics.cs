// ITI LECTURE - C# Fundamentals - Set<T>
// File - SetBasics.cs

namespace CsharpFundamentals.DataStructures
{
    /*
     * SET<T>
     * ======
     *
     * A Set is a collection that stores UNIQUE values.
     * Duplicate values are not stored.
     *
     * HashSet<T>
     * ----------
     * - Stores unique values.
     * - Does NOT keep values sorted.
     * - Usually faster for Add, Remove and Contains.
     *
     * Used for:
     * - Employee permissions
     * - User roles
     * - Unique emails
     * - Product tags
     *
     *
     * SortedSet<T>
     * ------------
     * - Stores unique values.
     * - Automatically keeps values sorted.
     * - Provides Min and Max.
     *
     * Used for:
     * - Employee names alphabetically
     * - Sorted salaries
     * - Rankings
     * - Sorted dates
     *
     *
     * MAIN DIFFERENCE
     * ---------------
     *
     * HashSet   -> Unique values
     * SortedSet -> Unique values + Sorted values
     *
     *
     * CUSTOM OBJECTS
     * --------------
     *
     * C# already knows how to compare:
     * int, double, string, DateTime, etc.
     *
     * For our own class like Employee,
     * we can implement IComparable<Employee>
     * to tell SortedSet how employees should be sorted.
     *
     * In this example Employee objects are compared by Id.
     */

    internal class SetBasics
    {
        public static void Run()
        {
            Console.WriteLine("========== SETS ==========\n");

            HashSetExample();

            SortedSetExample();

            SetOperations();

            EmployeeExample();

            Console.WriteLine("\n==========================");
        }

        //---------------------------------------------------------
        // HashSet<T>
        // Unique values without sorted order.
        //---------------------------------------------------------
        static void HashSetExample()
        {
            Console.WriteLine("========== HashSet ==========");

            // Real example:
            // Permissions assigned to an employee.
            HashSet<string> permissions = new HashSet<string>();

            //-------------------------------------------------
            // Add
            //-------------------------------------------------

            permissions.Add("View Customers");
            permissions.Add("Create Customer");
            permissions.Add("Edit Customer");
            permissions.Add("Delete Customer");

            Console.WriteLine("Employee Permissions:");

            Print(permissions);

            //-------------------------------------------------
            // Duplicate
            //-------------------------------------------------

            // HashSet does not add duplicate values.
            bool added = permissions.Add("View Customers");

            Console.WriteLine(
                $"\nAdd View Customers Again: {added}"
            );

            //-------------------------------------------------
            // Contains
            //-------------------------------------------------

            // Check if a permission exists.
            bool canEdit =
                permissions.Contains("Edit Customer");

            Console.WriteLine(
                $"Can Edit Customer: {canEdit}"
            );

            //-------------------------------------------------
            // Remove
            //-------------------------------------------------

            permissions.Remove("Delete Customer");

            Console.WriteLine("\nAfter Removing Delete Customer:");

            Print(permissions);

            //-------------------------------------------------
            // Count
            //-------------------------------------------------

            Console.WriteLine(
                $"\nPermissions Count: {permissions.Count}"
            );

            Console.WriteLine();
        }

        //---------------------------------------------------------
        // SortedSet<T>
        // Unique values with automatic sorting.
        //---------------------------------------------------------
        static void SortedSetExample()
        {
            Console.WriteLine("========== SortedSet ==========");

            // Real example:
            // Employee names displayed alphabetically.
            SortedSet<string> employeeNames =
                new SortedSet<string>()
                {
                    "Omar",
                    "Ahmed",
                    "Youssef",
                    "Mona",
                    "Sara"
                };

            Console.WriteLine("Employee Names:");

            // SortedSet automatically sorts the names.
            Print(employeeNames);

            //-------------------------------------------------
            // Add
            //-------------------------------------------------

            // Ali will be added in the correct sorted position.
            employeeNames.Add("Ali");

            Console.WriteLine("\nAfter Adding Ali:");

            Print(employeeNames);

            //-------------------------------------------------
            // Duplicate
            //-------------------------------------------------

            // SortedSet also does not allow duplicates.
            bool added = employeeNames.Add("Ahmed");

            Console.WriteLine(
                $"\nAdd Ahmed Again: {added}"
            );

            //-------------------------------------------------
            // Contains
            //-------------------------------------------------

            Console.WriteLine(
                $"Contains Sara: {employeeNames.Contains("Sara")}"
            );

            //-------------------------------------------------
            // Min
            //-------------------------------------------------

            // First value according to the sorting.
            Console.WriteLine(
                $"Min: {employeeNames.Min}"
            );

            //-------------------------------------------------
            // Max
            //-------------------------------------------------

            // Last value according to the sorting.
            Console.WriteLine(
                $"Max: {employeeNames.Max}"
            );

            //-------------------------------------------------
            // Remove
            //-------------------------------------------------

            employeeNames.Remove("Mona");

            Console.WriteLine("\nAfter Removing Mona:");

            Print(employeeNames);

            Console.WriteLine();
        }

        //---------------------------------------------------------
        // Common Set Operations
        //---------------------------------------------------------
        static void SetOperations()
        {
            Console.WriteLine("========== Set Operations ==========");

            // Employees working on Project A.
            HashSet<string> projectA =
                new HashSet<string>()
                {
                    "Ahmed",
                    "Sara",
                    "Omar",
                    "Mona"
                };

            // Employees working on Project B.
            HashSet<string> projectB =
                new HashSet<string>()
                {
                    "Sara",
                    "Mona",
                    "Ali",
                    "Youssef"
                };

            Console.WriteLine("Project A:");

            Print(projectA);

            Console.WriteLine("\nProject B:");

            Print(projectB);

            //-------------------------------------------------
            // UnionWith
            // Get all unique employees from both projects.
            //-------------------------------------------------

            HashSet<string> allEmployees =
                new HashSet<string>(projectA);

            allEmployees.UnionWith(projectB);

            Console.WriteLine("\nAll Employees:");

            Print(allEmployees);

            //-------------------------------------------------
            // IntersectWith
            // Get employees working on BOTH projects.
            //-------------------------------------------------

            HashSet<string> commonEmployees =
                new HashSet<string>(projectA);

            commonEmployees.IntersectWith(projectB);

            Console.WriteLine("\nEmployees In Both Projects:");

            Print(commonEmployees);

            //-------------------------------------------------
            // ExceptWith
            // Get employees in Project A but not Project B.
            //-------------------------------------------------

            HashSet<string> projectAOnly =
                new HashSet<string>(projectA);

            projectAOnly.ExceptWith(projectB);

            Console.WriteLine("\nProject A Only:");

            Print(projectAOnly);

            //-------------------------------------------------
            // SymmetricExceptWith
            // Get employees who exist in only one project.
            //-------------------------------------------------

            HashSet<string> oneProjectOnly =
                new HashSet<string>(projectA);

            oneProjectOnly.SymmetricExceptWith(projectB);

            Console.WriteLine("\nEmployees In Only One Project:");

            Print(oneProjectOnly);

            //-------------------------------------------------
            // IsSubsetOf
            //-------------------------------------------------

            HashSet<string> smallTeam =
                new HashSet<string>()
                {
                    "Ahmed",
                    "Sara"
                };

            Console.WriteLine(
                $"\nSmall Team Is Subset Of Project A: " +
                $"{smallTeam.IsSubsetOf(projectA)}"
            );

            //-------------------------------------------------
            // IsSupersetOf
            //-------------------------------------------------

            Console.WriteLine(
                $"Project A Is Superset Of Small Team: " +
                $"{projectA.IsSupersetOf(smallTeam)}"
            );

            //-------------------------------------------------
            // Overlaps
            //-------------------------------------------------

            Console.WriteLine(
                $"Project A And Project B Have Common Employees: " +
                $"{projectA.Overlaps(projectB)}"
            );

            Console.WriteLine();
        }

        //---------------------------------------------------------
        // SortedSet<Employee>
        //
        // Employee implements IComparable<Employee>.
        // Employees will be sorted by Id.
        //---------------------------------------------------------
        static void EmployeeExample()
        {
            Console.WriteLine("========== Employee SortedSet ==========");

            Employee emp1 =
                new Employee(4, "Mona", 20000);

            Employee emp2 =
                new Employee(2, "Sara", 22000);

            Employee emp3 =
                new Employee(1, "Ahmed", 15000);

            Employee emp4 =
                new Employee(3, "Omar", 18000);

            //-------------------------------------------------
            // HashSet<Employee>
            //-------------------------------------------------

            // HashSet stores unique Employee objects.
            // It does not sort them.
            HashSet<Employee> hashEmployees =
                new HashSet<Employee>()
                {
                    emp1,
                    emp2,
                    emp3,
                    emp4
                };

            Console.WriteLine("HashSet Employees:");

            foreach (Employee employee in hashEmployees)
            {
                Console.WriteLine(employee);
            }

            //-------------------------------------------------
            // SortedSet<Employee>
            //-------------------------------------------------

            // SortedSet calls Employee.CompareTo().
            // Our CompareTo compares employees by Id.
            SortedSet<Employee> sortedEmployees =
                new SortedSet<Employee>()
                {
                    emp1,
                    emp2,
                    emp3,
                    emp4
                };

            Console.WriteLine("\nSortedSet Employees:");

            foreach (Employee employee in sortedEmployees)
            {
                Console.WriteLine(employee);
            }

            Console.WriteLine();

            //-------------------------------------------------
            // Min
            //-------------------------------------------------

            // Employee with the smallest Id.
            Console.WriteLine(
                $"Min Employee: {sortedEmployees.Min}"
            );

            //-------------------------------------------------
            // Max
            //-------------------------------------------------

            // Employee with the largest Id.
            Console.WriteLine(
                $"Max Employee: {sortedEmployees.Max}"
            );

            Console.WriteLine();
        }

        //---------------------------------------------------------
        // Print HashSet<string>
        //---------------------------------------------------------
        static void Print(HashSet<string> set)
        {
            foreach (string item in set)
            {
                Console.Write(item + " | ");
            }

            Console.WriteLine();
        }

        //---------------------------------------------------------
        // Print SortedSet<string>
        //---------------------------------------------------------
        static void Print(SortedSet<string> set)
        {
            foreach (string item in set)
            {
                Console.Write(item + " | ");
            }

            Console.WriteLine();
        }
    }

    //-------------------------------------------------------------
    // Employee
    //-------------------------------------------------------------

    /*
     * Employee implements IComparable<Employee>
     * because SortedSet<Employee> needs to know
     * how two employees should be compared.
     *
     * In this example:
     *
     * Employee objects are compared by Id.
     *
     * Smaller Id -> comes first.
     * Larger Id  -> comes later.
     */

    internal class Employee : IComparable<Employee>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Salary { get; set; }

        public Employee(
            int id,
            string name,
            decimal salary)
        {
            Id = id;
            Name = name;
            Salary = salary;
        }

        //---------------------------------------------------------
        // CompareTo
        //
        // SortedSet uses this method to sort Employee objects.
        //
        // < 0 -> this employee comes before other
        //   0 -> both are considered equal
        // > 0 -> this employee comes after other
        //---------------------------------------------------------
        public int CompareTo(Employee? other)
        {
            if (other == null)
                return 1;

            // Compare employees by Id.
            return Id.CompareTo(other.Id);
        }

        //---------------------------------------------------------
        // ToString
        //---------------------------------------------------------
        public override string ToString()
        {
            return $"{Id} - {Name} - {Salary}";
        }
    }
}