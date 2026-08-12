// ITI LECTURE - C# Fundamentals - Tuple
// File - TupleBasics.cs

namespace CsharpFundamentals.DataStructures
{
    /*
     * TUPLES IN C#
     * ============
     * A Tuple groups multiple values together without creating a class.
     * The values can have different data types.
     *
     * ValueTuple:
     * - Modern tuple: (int Id, string Name)
     * - Value type
     * - Mutable
     * - Named elements
     * - Supports deconstruction
     *
     * Tuple<T>:
     * - Older System.Tuple type
     * - Reference type
     * - Immutable
     * - Uses Item1, Item2...
     *
     * USE TUPLES FOR:
     * - Returning multiple values from a method
     * - Small temporary groups of related data
     * - Deconstruction
     *
     * For important business objects such as Employee or Product,
     * a class or record is usually clearer.
     */

    internal class TupleBasics
    {
        public static void Run()
        {
            BasicTupleExample();
            Console.WriteLine("=======================================");
            NamedTupleExample();
            Console.WriteLine("=======================================");
            DeconstructionExample();
            Console.WriteLine("=======================================");
            ReturnMultipleValuesExample();
            Console.WriteLine("=======================================");
            EqualityExample();
            Console.WriteLine("=======================================");
            CollectionExample();
            Console.WriteLine("=======================================");
            OldTupleExample();
            Console.WriteLine("=======================================");
            ValueTupleVsTupleExample();
        }

        //---------------------------------------------------------
        // Basic ValueTuple
        //---------------------------------------------------------
        static void BasicTupleExample()
        {
            Console.WriteLine("------------ Basic Tuple ------------");

            // Different types can be stored together.
            (int, string, decimal) employee = (101, "Ahmed", 15000);

            // Without names, use Item1, Item2...
            Console.WriteLine($"Id     --> {employee.Item1}");
            Console.WriteLine($"Name   --> {employee.Item2}");
            Console.WriteLine($"Salary --> {employee.Item3}");

            // ValueTuple is mutable.
            employee.Item2 = "Mohamed";
            employee.Item3 = 18000;

            Console.WriteLine($"After Change --> {employee}");
        }

        //---------------------------------------------------------
        // Named Tuple
        //---------------------------------------------------------
        static void NamedTupleExample()
        {
            Console.WriteLine("------------ Named Tuple ------------");

            // Names make the tuple easier to understand.
            (int Id, string Name, decimal Salary) employee =
                (101, "Sara", 22000);

            Console.WriteLine($"Id     --> {employee.Id}");
            Console.WriteLine($"Name   --> {employee.Name}");
            Console.WriteLine($"Salary --> {employee.Salary}");

            employee.Salary = 25000;

            Console.WriteLine($"New Salary --> {employee.Salary}");
        }

        //---------------------------------------------------------
        // Deconstruction
        //---------------------------------------------------------
        static void DeconstructionExample()
        {
            Console.WriteLine("------------ Deconstruction ------------");

            (int Id, string Name, string Department) employee =
                (101, "Omar", "Development");

            // Put tuple values into separate variables.
            var (id, name, department) = employee;

            Console.WriteLine($"{id} - {name} - {department}");

            // _ ignores a value we do not need.
            var (_, employeeName, employeeDepartment) = employee;

            Console.WriteLine(
                $"{employeeName} works in {employeeDepartment}"
            );
        }

        //---------------------------------------------------------
        // Return Multiple Values
        //---------------------------------------------------------
        static void ReturnMultipleValuesExample()
        {
            Console.WriteLine("------------ Return Multiple Values ------------");

            // A method can return multiple related values.
            var employee = GetEmployee();

            Console.WriteLine(
                $"{employee.Id} - {employee.Name} - {employee.Salary}"
            );

            // Returned tuple can also be deconstructed.
            var (id, name, salary) = GetEmployee();

            Console.WriteLine($"{id} - {name} - {salary}");
        }

        static (int Id, string Name, decimal Salary) GetEmployee()
        {
            return (101, "Mona", 20000);
        }

        //---------------------------------------------------------
        // ValueTuple Equality
        //---------------------------------------------------------
        static void EqualityExample()
        {
            Console.WriteLine("------------ Tuple Equality ------------");

            var employee1 = (Id: 1, Name: "Ahmed");
            var employee2 = (Id: 1, Name: "Ahmed");
            var employee3 = (Id: 2, Name: "Sara");

            // ValueTuple compares values.
            Console.WriteLine(
                $"employee1 == employee2 --> {employee1 == employee2}"
            );

            Console.WriteLine(
                $"employee1 == employee3 --> {employee1 == employee3}"
            );

            // Element names do not affect equality.
            (int Id, string Name) first = (1, "Ahmed");
            (int Number, string EmployeeName) second = (1, "Ahmed");

            Console.WriteLine($"first == second --> {first == second}");
        }

        //---------------------------------------------------------
        // Tuples Inside Collections
        //---------------------------------------------------------
        static void CollectionExample()
        {
            Console.WriteLine("------------ Tuple In Collections ------------");

            List<(int Id, string Name, decimal Salary)> employees =
                new List<(int Id, string Name, decimal Salary)>()
                {
                    (101, "Ahmed", 15000),
                    (102, "Sara", 22000),
                    (103, "Omar", 18000)
                };

            foreach (var employee in employees)
            {
                Console.WriteLine(
                    $"{employee.Id} - {employee.Name} - {employee.Salary}"
                );
            }

            // Tuple can be used as a Dictionary key.
            Dictionary<(int EmployeeId, int ProjectId), string> assignments =
                new Dictionary<(int EmployeeId, int ProjectId), string>();

            assignments.Add((101, 1), "Backend Developer");
            assignments.Add((101, 2), "API Developer");

            Console.WriteLine(
                $"Employee 101 / Project 1 --> {assignments[(101, 1)]}"
            );
        }

        //---------------------------------------------------------
        // Old System.Tuple<T>
        //---------------------------------------------------------
        static void OldTupleExample()
        {
            Console.WriteLine("------------ Old Tuple<T> ------------");

            // Older reference-type tuple.
            Tuple<int, string, decimal> employee =
                new Tuple<int, string, decimal>(101, "Youssef", 17000);

            Console.WriteLine($"Id     --> {employee.Item1}");
            Console.WriteLine($"Name   --> {employee.Item2}");
            Console.WriteLine($"Salary --> {employee.Item3}");

            // Tuple<T> is immutable.
            // This will NOT work:
            // employee.Item2 = "Ahmed";

            // Tuple.Create is a shorter creation syntax.
            var department = Tuple.Create(1, "Development");

            Console.WriteLine(
                $"Department --> {department.Item1} - {department.Item2}"
            );
        }

        //---------------------------------------------------------
        // ValueTuple VS Tuple<T>
        //---------------------------------------------------------
        static void ValueTupleVsTupleExample()
        {
            Console.WriteLine("------------ ValueTuple VS Tuple ------------");

            // ValueTuple: modern, value type and mutable.
            (int Id, string Name) valueTuple = (1, "Ahmed");

            valueTuple.Name = "Mohamed";

            Console.WriteLine($"ValueTuple --> {valueTuple}");

            // Tuple<T>: older, reference type and immutable.
            Tuple<int, string> oldTuple = Tuple.Create(1, "Ahmed");

            Console.WriteLine(
                $"Tuple --> {oldTuple.Item1} - {oldTuple.Item2}"
            );

            /*
             * QUICK DIFFERENCE
             *
             * ValueTuple
             * - Value type
             * - Modern syntax
             * - Mutable
             * - Named elements
             * - Deconstruction
             *
             * Tuple<T>
             * - Reference type
             * - Older syntax
             * - Immutable
             * - Item1, Item2...
             *
             * Modern C# usually uses ValueTuple.
             */
        }
    }
}