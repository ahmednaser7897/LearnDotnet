using System;
using System.Collections.Generic;
using System.Text;

namespace CsharpFundamentals.ObjectOrientedProgramming
{
    internal class Finalizers
    {
        public static void Run()
        {
            // Create many objects that will become eligible for garbage collection.
            MakeSomeGarbage();

            // Get the amount of memory currently used by managed objects.
            // false = don't force a garbage collection before measuring.
            Console.WriteLine($"Memory used before clean: {GC.GetTotalMemory(false)}");

            // Explicitly ask the Garbage Collector to clean unused objects.
            GC.Collect();

            // Get memory usage after garbage collection.
            // true = wait for the garbage collection to finish.
            Console.WriteLine($"Memory used after clean: {GC.GetTotalMemory(true)}");
        }

        static void MakeSomeGarbage()
        {
            GarbageEmployee garbageEmployee;

            // Create 1000 GarbageEmployee objects.
            // After each loop, the previous object becomes eligible
            // for Garbage Collection because there is no reference to it.
            for (int i = 0; i < 1000; i++)
            {
                garbageEmployee = new GarbageEmployee(
                    id: i,
                    name: "ahmed",
                    salary: 1000m,
                    gendar: "male");
            }
        }
    }

    class GarbageEmployee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Salary { get; set; }
        public string Gendar { get; set; }

        public override string ToString()
        {
            return $"Name {Name} Id {Id} Salary {Salary} Gender {Gendar}";
        }

        // Constructor runs automatically when a new object is created.
        public GarbageEmployee(int id, string name, decimal salary, string gendar)
        {
            Id = id;
            Name = name;
            Salary = salary;
            Gendar = gendar;

            // Just print a message for every 100th object
            // so we don't print 1000 messages.
            if (id % 100 == 0)
                Console.WriteLine($"This is Constructor");
        }

        // Finalizer runs when the Garbage Collector is about
        // to remove this object from memory.
        // It is written using ~ followed by the class name.
        ~GarbageEmployee()
        {
            // Print a message for every 100th object.
            if (Id % 100 == 0)
                Console.WriteLine($"This is Destructor/Finalizer");
        }
    }
}