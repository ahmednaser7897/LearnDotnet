using System;
using System.Collections.Generic;
using System.Text;

namespace CsharpFundamentals.ObjectOrientedProgramming
{
    internal class OppBasics
    {
        public static void Run()
        {
            OppClassBasics();
        }
        public static void OppClassBasics() {
            Console.WriteLine("Opp Class Basics");
            Student student = new Student("John Doe", "123-456-7890", "123 Main St",10);
            Console.WriteLine($"Student Name: {student.Name}");
            Console.WriteLine($"Student Phone Number: {student.PhoneNumber}");
            Console.WriteLine($"Student Address: {student.Address}");
        }
    }
    //<Class Modifiers> <Class Name>
    //Class Modifiers -> default (internal), public, abstract, sealed, static, partial
    //{
    //class body
    //}
    public class Student
    {   //<Constant Modifiers> const <Data Type> <Variable Name> = <Value>
        //Constant Modifiers-> const, readonly
        //Constant is always static -> called by class name
        const double TAX = 0.03;

        //<Access Modifiers> <Data Type> <Variable Name> =<Initial Value>
        // Variabls Access Modifiers -> defaul (internal) , public, private, protected, 
        public int age;
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }

        public Student(string name, string phoneNumber, string address, int age)
        {
            Name = name;
            PhoneNumber = phoneNumber;
            Address = address;
            this.age = age;
        }


    }
}
