using System;
using System.Collections;
using System.Collections.Generic;

namespace CsharpFundamentals.ObjectOrientedProgramming
{
    internal class EnumeratorsAndIterators
    {
        public static Manager manager;

        public static void Run()
        {
            // Create a Manager object that contains 10 employees.
            manager = new Manager(new List<SeniorEmployee>
            {
                new SeniorEmployee { Id = 1, Name = "Ahmed", Salary = 65000m },
                new SeniorEmployee { Id = 2, Name = "Mohamed", Salary = 58000m },
                new SeniorEmployee { Id = 3, Name = "Omar", Salary = 72000m },
                new SeniorEmployee { Id = 4, Name = "Ali", Salary = 61000m },
                new SeniorEmployee { Id = 5, Name = "Youssef", Salary = 75000m },
                new SeniorEmployee { Id = 6, Name = "Khaled", Salary = 54000m },
                new SeniorEmployee { Id = 7, Name = "Hassan", Salary = 68000m },
                new SeniorEmployee { Id = 8, Name = "Mahmoud", Salary = 59000m },
                new SeniorEmployee { Id = 9, Name = "Ibrahim", Salary = 80000m },
                new SeniorEmployee { Id = 10, Name = "Mostafa", Salary = 63000m }
            });

            TestEnumeratorsAndIteratorsBasics();

            TestYield();

            TestForVsForEach();
        }


        // ================================================================
        // ENUMERATORS AND ITERATORS BASICS
        // ================================================================

        static void TestEnumeratorsAndIteratorsBasics()
        {
            Console.WriteLine(
                "-------- Test Enumerators And Iterators Basics ----------");

            // Manager is an object, not an array or List.
            // Because Manager implements IEnumerable<SeniorEmployee>,
            // we can use foreach with it.
            foreach (SeniorEmployee employee in manager)
            {
                Console.WriteLine(employee);
            }
        }


        // ================================================================
        // YIELD
        // ================================================================

        static void TestYield()
        {
            Console.WriteLine("-------- Test Yield ----------");

            // Create an object that implements IEnumerable<int>.
            TestYield test = new TestYield();

            // foreach uses GetEnumerator() internally.
            //
            // The loop receives one value at a time from yield return.
            foreach (int number in test)
            {
                Console.WriteLine(number);
            }


            Console.WriteLine("----------------------------");


            // GetNumbers() returns an IEnumerator<int>.
            IEnumerator<int> numbers = GetNumbers();

            // MoveNext() moves to the next value.
            // Current returns the current value.
            while (numbers.MoveNext())
            {
                Console.WriteLine(numbers.Current);
            }
        }


        // ================================================================
        // YIELD RETURN WITH IEnumerator
        // ================================================================

        static IEnumerator<int> GetNumbers()
        {
            // yield return returns one value at a time.
            yield return 0;
            yield return 10;
            yield return 20;
        }


        // ================================================================
        // FOR VS FOREACH VS WHILE
        // ================================================================

        static void TestForVsForEach()
        {
            Console.WriteLine("-------- Test ForEach ----------");

            // foreach does not need an index.
            // It uses the enumerator internally.
            foreach (SeniorEmployee employee in manager)
            {
                Console.WriteLine(employee);
            }


            Console.WriteLine("-------- Test While ----------");

            // We can manually use the enumerator with while.
            //
            // MoveNext() moves to the next item.
            // Current gets the current item.
            IEnumerator<int> numbers = GetNumbers();

            while (numbers.MoveNext())
            {
                Console.WriteLine(numbers.Current);
            }


            Console.WriteLine("-------- Test For ----------");

            // for needs an index.
            // Manager does not directly expose an index to for.
            //
            // We have two ways to get an employee by index.


            // ============================================================
            // SOLUTION 1: USE A METHOD
            // ============================================================

            for (int i = 0; i < manager.Count(); i++)
            {
                // GetEmployee() returns the employee at index i.
                Console.WriteLine(manager.GetEmployee(i));


                // ========================================================
                // SOLUTION 2: USE AN INDEXER
                // ========================================================

                // The indexer allows us to use:
                // manager[i]
                Console.WriteLine(manager[i]);
            }
        }
    }


    // ====================================================================
    // MANAGER
    // ====================================================================

    // IEnumerable<SeniorEmployee> means:
    // Manager can be used with foreach to iterate over SeniorEmployee.
    class Manager : IEnumerable<SeniorEmployee>
    {
        private List<SeniorEmployee> employees = new();


        // ================================================================
        // GET EMPLOYEE METHOD
        // ================================================================

        // Returns an employee using an index.
        public SeniorEmployee GetEmployee(int index)
        {
            return employees[index];
        }


        // ================================================================
        // CONSTRUCTOR
        // ================================================================

        public Manager(List<SeniorEmployee> employees)
        {
            this.employees = employees;
        }


        // ================================================================
        // INDEXER
        // ================================================================

        // Allows us to access an employee like an array:
        //
        // manager[0]
        // manager[1]
        // manager[2]
        //
        // instead of:
        //
        // manager.GetEmployee(0)
        public SeniorEmployee this[int index]
        {
            get
            {
                return employees[index];
            }
        }


        // ================================================================
        // GET ENUMERATOR USING LIST'S ENUMERATOR
        // ================================================================

        // We can simply return the List's enumerator.
        //
        // This is the easiest way to implement IEnumerable.
        //
        // public IEnumerator<SeniorEmployee> GetEnumerator()
        // {
        //     return employees.GetEnumerator();
        // }


        // ================================================================
        // GET ENUMERATOR USING OUR OWN ENUMERATOR
        // ================================================================

        // We can also create our own IEnumerator.
        //
        // public IEnumerator<SeniorEmployee> GetEnumerator()
        // {
        //     return new MyEnumerator(employees);
        // }


        // ================================================================
        // GET ENUMERATOR USING YIELD
        // ================================================================

        // We can use yield to create an iterator.
        public IEnumerator<SeniorEmployee> GetEnumerator()
        {
            // Code inside a yield method does NOT run immediately
            // when GetEnumerator() is called.
            //
            // It runs when the enumerator starts moving through
            // the collection.

            foreach (var employee in employees)
            {
                // Return one employee at a time.
                yield return employee;
            }
        }


        // ================================================================
        // GET ENUMERATOR USING RETURN
        // ================================================================

        public IEnumerator<SeniorEmployee> GetEmployeeEnumerator()
        {
            // This method immediately returns the List's enumerator.
            //
            // Unlike the yield version, the return statement
            // is executed when this method is called.
            return employees.GetEnumerator();
        }


        // ================================================================
        // NON-GENERIC IEnumerable
        // ================================================================

        // IEnumerable requires this non-generic version.
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }


    // ====================================================================
    // CUSTOM ENUMERATOR
    // ====================================================================

    // We can create our own IEnumerator instead of using
    // List<T>.GetEnumerator().
    public class MyEnumerator : IEnumerator<SeniorEmployee>
    {
        private readonly List<SeniorEmployee> employees;

        // Start before the first item.
        private int index = -1;


        // Constructor receives the list we want to iterate over.
        public MyEnumerator(List<SeniorEmployee> employees)
        {
            this.employees = employees;
        }


        // ================================================================
        // CURRENT
        // ================================================================

        // foreach uses Current to get the current item.
        public SeniorEmployee Current => employees[index];


        // Non-generic version required by IEnumerator.
        object IEnumerator.Current => Current;


        // ================================================================
        // DISPOSE
        // ================================================================

        // Used to release resources when the enumerator is finished.
        public void Dispose()
        {
            // Nothing needs to be released in this example.
        }


        // ================================================================
        // MOVENEXT
        // ================================================================

        // MoveNext() moves to the next item.
        //
        // Returns:
        // true  -> another item exists.
        // false -> reached the end.
        public bool MoveNext()
        {
            return ++index < employees.Count;


            // The same logic can also be written as:
            //
            // index++;
            //
            // if (index < employees.Count)
            // {
            //     return true;
            // }
            //
            // return false;
        }


        // ================================================================
        // RESET
        // ================================================================

        // Reset should move the enumerator back
        // to its initial position.
        public void Reset()
        {
            index = -1;
        }
    }


    // ====================================================================
    // SENIOR EMPLOYEE
    // ====================================================================

    public class SeniorEmployee
    {
        public string Name { get; set; }

        public decimal Salary { get; set; }

        public int Id { get; set; }


        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Salary: {Salary}";
        }
    }


    // ====================================================================
    // YIELD EXAMPLE
    // ====================================================================

    // This class can be used with foreach
    // because it implements IEnumerable<int>.
    public class TestYield : IEnumerable<int>
    {
        public IEnumerator<int> GetEnumerator()
        {
            // yield return returns one value at a time.
            //
            // foreach receives:
            // 1
            // 2
            // 3
            // 4

            yield return 1;
            yield return 2;
            yield return 3;
            yield return 4;


            // yield break stops the iterator.
            yield break;


            // This code can never be reached
            // because yield break already stopped the iterator.
            //
            // yield return 5;
        }


        // Non-generic IEnumerable implementation.
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}