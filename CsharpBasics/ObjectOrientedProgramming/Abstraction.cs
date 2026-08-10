namespace CsharpFundamentals.ObjectOrientedProgramming.l
{
    internal class Abstract
    {
        public static void Run()
        {
            // ============================================================
            // ABSTRACT CLASS
            // ============================================================

            // We CANNOT create an object directly from an abstract class.
            // Animal animal = new Animal(); // ❌ Compile-time error

            // But we can use an abstract class as a reference type.
            Animal animal1 = new Dog("Max", 3);

            animal1.Eat();
            animal1.Sleep();
            animal1.MakeSound();

            Console.WriteLine($"Animal Name: {animal1.Name}");
            Console.WriteLine($"Animal Age: {animal1.Age}");

            Console.WriteLine();


            // ============================================================
            // POLYMORPHISM WITH ABSTRACT CLASSES
            // ============================================================

            // The reference type is Animal,
            // but the actual object is Dog.
            Animal animal2 = new Cat("Luna", 2);

            animal2.Eat();
            animal2.Sleep();
            animal2.MakeSound();

            Console.WriteLine();


            // ============================================================
            // USING THE CONCRETE TYPE
            // ============================================================

            Dog dog = new Dog("Rocky", 5);

            dog.Eat();
            dog.Sleep();
            dog.MakeSound();

            // Dog-specific method.
            dog.Bark();

            Console.WriteLine();


            // ============================================================
            // ABSTRACT PROPERTIES
            // ============================================================

            Animal animal3 = new Dog("Buddy", 4);

            // Name and Age are implemented by Dog.
            Console.WriteLine($"Name: {animal3.Name}");
            Console.WriteLine($"Age: {animal3.Age}");

            Console.WriteLine();


            // ============================================================
            // ABSTRACT STATIC METHOD / MEMBER
            // ============================================================

            // Abstract members cannot be static.
            // They must belong to an object and be overridden
            // by a derived class.
        }
    }


    // ====================================================================
    // ABSTRACT CLASS
    // ====================================================================

    // An abstract class is a class that cannot be instantiated directly.
    //
    // It is usually used as a base class for other classes.
    //
    // An abstract class can contain:
    // - Fields
    // - Properties
    // - Constructors
    // - Concrete methods
    // - Abstract methods
    // - Abstract properties
    // - Static members
    // - Constants
    abstract class Animal
    {
        // ================================================================
        // FIELD
        // ================================================================

        // Abstract classes can have normal fields.
        protected string species;


        // ================================================================
        // PROPERTY
        // ================================================================

        // Normal property.
        // Derived classes automatically inherit it.
        public string Name { get; set; }


        // ================================================================
        // ABSTRACT PROPERTY
        // ================================================================

        // An abstract property has no implementation.
        //
        // Every non-abstract derived class must provide
        // an implementation for it.
        public abstract int Age { get; }


        // ================================================================
        // CONSTRUCTOR
        // ================================================================

        // Abstract classes CAN have constructors.
        //
        // The constructor runs when a derived class object is created.
        protected Animal(string name)
        {
            Name = name;
            species = "Animal";

            Console.WriteLine("Animal Constructor");
        }


        // ================================================================
        // CONCRETE METHOD
        // ================================================================

        // An abstract class can have normal methods
        // with a complete implementation.
        public void Eat()
        {
            Console.WriteLine($"{Name} is eating.");
        }


        public void Sleep()
        {
            Console.WriteLine($"{Name} is sleeping.");
        }


        // ================================================================
        // ABSTRACT METHOD
        // ================================================================

        // An abstract method has NO implementation.
        //
        // The derived class MUST override it.
        public abstract void MakeSound();


        // ================================================================
        // VIRTUAL METHOD
        // ================================================================

        // A virtual method has a default implementation.
        //
        // A derived class MAY override it, but it is not required.
        public virtual void Move()
        {
            Console.WriteLine($"{Name} is moving.");
        }
    }


    // ====================================================================
    // DOG
    // ====================================================================

    // Dog inherits from the abstract Animal class.
    //
    // Because Dog is NOT abstract, it must implement
    // all abstract members from Animal.
    class Dog : Animal
    {
        // Constructor of Dog.
        //
        // base(name) calls the constructor of Animal.
        public Dog(string name, int age)
            : base(name)
        {
            AgeValue = age;

            Console.WriteLine("Dog Constructor");
        }


        // ================================================================
        // IMPLEMENTING ABSTRACT PROPERTY
        // ================================================================

        private int AgeValue;

        // Dog provides the implementation of Animal.Age.
        public override int Age
        {
            get
            {
                return AgeValue;
            }
        }


        // ================================================================
        // IMPLEMENTING ABSTRACT METHOD
        // ================================================================

        // override is REQUIRED because MakeSound()
        // was declared abstract in Animal.
        public override void MakeSound()
        {
            Console.WriteLine($"{Name} says: Woof!");
        }


        // ================================================================
        // OVERRIDING VIRTUAL METHOD
        // ================================================================

        // Move() was virtual, so overriding it is optional.
        public override void Move()
        {
            Console.WriteLine($"{Name} is running.");
        }


        // ================================================================
        // DOG-SPECIFIC METHOD
        // ================================================================

        // This method exists only in Dog.
        public void Bark()
        {
            Console.WriteLine($"{Name} is barking.");
        }
    }


    // ====================================================================
    // CAT
    // ====================================================================

    class Cat : Animal
    {
        private int AgeValue;


        // Constructor.
        //
        // base(name) calls the Animal constructor.
        public Cat(string name, int age)
            : base(name)
        {
            AgeValue = age;

            Console.WriteLine("Cat Constructor");
        }


        // ================================================================
        // IMPLEMENTING ABSTRACT PROPERTY
        // ================================================================

        public override int Age
        {
            get
            {
                return AgeValue;
            }
        }


        // ================================================================
        // IMPLEMENTING ABSTRACT METHOD
        // ================================================================

        public override void MakeSound()
        {
            Console.WriteLine($"{Name} says: Meow!");
        }


        // ================================================================
        // USING THE INHERITED VIRTUAL METHOD
        // ================================================================

        // We don't have to override Move().
        //
        // If we don't override it, the implementation from
        // Animal will be used.
    }


    // ====================================================================
    // ANOTHER ABSTRACT CLASS
    // ====================================================================

    // An abstract class can inherit from another abstract class.
    abstract class Mammal : Animal
    {
        protected Mammal(string name)
            : base(name)
        {
        }

        // Mammal can leave abstract members unimplemented.
        //
        // Because Mammal is also abstract, it does NOT have to
        // implement Animal.MakeSound() or Animal.Age.
    }


    // ====================================================================
    // CONCRETE CLASS INHERITING FROM MAMMAL
    // ====================================================================

    class Human : Mammal
    {
        private int age;


        public Human(string name, int age)
            : base(name)
        {
            this.age = age;
        }


        // Implementing the abstract property from Animal.
        public override int Age
        {
            get
            {
                return age;
            }
        }


        // Implementing the abstract method from Animal.
        public override void MakeSound()
        {
            Console.WriteLine($"{Name} says: Hello!");
        }
    }
}