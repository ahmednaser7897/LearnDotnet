
namespace CsharpFundamentals.Keywords
{
    // ============================================================
    // INHERITANCE KEYWORDS
    // ============================================================
    //
    // base
    // this
    // virtual
    // override
    // new
    // abstract
    // sealed
    // ============================================================
    class InheritanceExample
    {
        public static void Run()
        {
            // this
            MyModel model = new("Ahmed");
            model.Print();


            // base
            Employee employee = new Employee("Ahmed");
            employee.Print();


            // virtual + override
            Animal animal = new Dog();

            animal.MakeSound();
            // Output: Woof


            // new
            Parent parent = new Child();
            parent.Print();
            // Output: Parent

            Child child = new Child();
            child.Print();
            // Output: Child


            // abstract
            Circle circle = new Circle(5);

            Console.WriteLine(circle.GetArea());

            circle.Print();


            // sealed
            FinalClass finalClass = new FinalClass();

            finalClass.Print();
        }
    }



    // ============================================================
    // this
    // ============================================================
    //
    // this refers to the current object.
    // ============================================================

    class MyModel
    {
        private string name;

        public MyModel(string name)
        {
            // this.name = class field
            // name = constructor parameter
            this.name = name;
        }


        public void Print()
        {
            Console.WriteLine(this.name);
        }
    }


    // ============================================================
    // base
    // ============================================================
    //
    // base refers to the parent class.
    // ============================================================

    class Person
    {
        protected string Name;

        public Person(string name)
        {
            Name = name;
        }


        public virtual void Print()
        {
            Console.WriteLine($"Name: {Name}");
        }
    }


    class Employee : Person
    {
        public Employee(string name)
            : base(name)
        {
        }


        public override void Print()
        {
            // Call parent method.
            base.Print();

            Console.WriteLine("Employee");
        }
    }


    // ============================================================
    // virtual + override
    // ============================================================
    //
    // virtual allows a child class to override a method.
    // override changes the parent implementation.
    // ============================================================

    class Animal
    {
        public virtual void MakeSound()
        {
            Console.WriteLine("Animal sound");
        }
    }


    class Dog : Animal
    {
        public override void MakeSound()
        {
            Console.WriteLine("Woof");
        }
    }


    // ============================================================
    // new
    // ============================================================
    //
    // new hides a member from the parent class.
    // It does NOT override it.
    // ============================================================

    class Parent
    {
        public void Print()
        {
            Console.WriteLine("Parent");
        }
    }


    class Child : Parent
    {
        public new void Print()
        {
            Console.WriteLine("Child");
        }
    }


    // ============================================================
    // abstract
    // ============================================================
    //
    // Abstract class cannot be instantiated.
    // Abstract method has no implementation.
    // Child classes must implement it.
    // ============================================================

    abstract class Shape
    {
        public abstract double GetArea();


        public void Print()
        {
            Console.WriteLine("This is a shape");
        }
    }


    class Circle : Shape
    {
        public double Radius { get; }

        public Circle(double radius)
        {
            Radius = radius;
        }


        public override double GetArea()
        {
            return Math.PI * Radius * Radius;
        }
    }


    // ============================================================
    // sealed class
    // ============================================================
    //
    // sealed prevents inheritance.
    // ============================================================

    sealed class FinalClass
    {
        public void Print()
        {
            Console.WriteLine("Final class");
        }
    }

    // This is not allowed:
    //
    // class AnotherClass : FinalClass
    // {
    // }


    // ============================================================
    // sealed override
    // ============================================================
    //
    // sealed can also stop another child class
    // from overriding a method.
    // ============================================================

    class Base
    {
        public virtual void Test()
        {
            Console.WriteLine("Base");
        }
    }


    class Middle : Base
    {
        public sealed override void Test()
        {
            Console.WriteLine("Middle");
        }
    }


    class Last : Middle
    {
        // ERROR:
        //
        // public override void Test()
        // {
        // }
    }

}
