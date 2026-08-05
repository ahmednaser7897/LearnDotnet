//ITI LECTURE 3 - C# Fundamentals -  Data Reference Types Basics
//https://www.youtube.com/watch?v=vOpWgihaIVs&list=PLNFDrRZdysFxcO03JtQeIMed4GHFc2YlT&index=3
namespace CsharpFundamentals.ObjectOrientedProgramming
{
    internal class ReferenceDataTypes
    {
        public static void Run()
        {
            //by default, the value data types are stored in the stack memory, and the reference data types are stored in the heap memory.
            Console.WriteLine("Test Reference Data Types");
            // reference data types -> non-primitive data types
            // its any data type that stores a reference to the actual value of the variable in memory.
            // any data type that is created using class, interface, delegate, or array is a reference data type.
            // string, object, dynamic, array, class, interface, delegate
            ReferenceDataTypesBasics();
            //// this is a c# way of declaring a variable and initializing it with a value of type string.
            //string str = "Hello World";
            //// this is a intermidate language (IL) way of declaring a variable and initializing it with a value of type string.
            //String str2 = "Hello World";
            //Console.WriteLine(str + " " + str2);
            Console.WriteLine("=======================================");

        }
        static void ReferenceDataTypesBasics()
        {
            Console.WriteLine("Reference Data Types Basics");
            // this is just declaring a variable of type Person, but not initializing it with any value.
            // this is uninitialized variable and will give a compile error if we try to access it without initializing it.
            Person? person;
            //Console.WriteLine($"Person: {person}");// this will give an compile error because person is not initialized with any value.
            // but if we assign it to null it will not shop compile error.
            // but it will shor runtime erorr when we try to access any property of the person variable.
            // now its initialized with null value and will not give compile error, but will give runtime error when we try to access any property of the person variable.
            person = null;
            Console.WriteLine($"Person: {person}");// no compile and no runtime erorrs.
            //Console.WriteLine($"Person age: {person.age}");runtime erorrs.
            //Console.WriteLine($"Person name: {person.name}");// runtime erorrs.
            // this is declaring a variable of type Person and initializing it with a new instance of the Person class.
            Person person1 = new Person("John", 30);
            Person person2 = person1; // person2 is a reference to the same object as person1
            Console.WriteLine($"Person 1: {person1.name}, {person1.age}");
            Console.WriteLine($"Person 2: {person2.name}, {person2.age}");
            person2.name = "Ahmed"; // changing the name of person2 also changes the name of person1
            Console.WriteLine($"Person 1: {person1.name}, {person1.age}");
            Console.WriteLine($"Person 2: {person2.name}, {person2.age}");
        }
    }
    class Person
    {
        public string name;
        public int age;
        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;
        }
    }
}
