using System;

namespace CsharpFundamentals.ObjectOrientedProgramming
{
    internal class NestedTypes
    {
        public static void Run()
        {
            // Create an object from the outer class.
            Company company = new Company("Microsoft");

            Console.WriteLine($"Company: {company.Name}");

            // Create an object from the nested class.
            // The nested class belongs to Company.
            Company.Employee employee =
                new Company.Employee(1, "Ahmed", 65000m);

            Console.WriteLine(employee);
        }
    }

    // Outer class
    public class Company
    {
        public string Name { get; set; }
        private int id = 1;
        public Company(string name)
        {
            Name = name;
        }

        // Nested class.
        // Employee is declared inside Company.
        public class Employee
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public decimal Salary { get; set; }

            public Employee(int id, string name, decimal salary)
            {
                Id = id;
                Name = name;
                Salary = salary;
            }

            public override string ToString()
            {
                return $"Id: {Id}, Name: {Name}, Salary: {Salary}";
            }
        }
    }
}