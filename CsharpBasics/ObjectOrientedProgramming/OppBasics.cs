namespace CsharpFundamentals.ObjectOrientedProgramming
{
    class OppBasics
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
            TestObjectinitializer();
            TestObjectClass();
            TestCloneObject();
            Console.WriteLine("=======================================");
        }
        public static void ReferenceDataTypesBasics()
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
        static void TestObjectinitializer()
        {
            Console.WriteLine("Test Object initializer");
            Person person1 = new Person();
            person1.age = 20;
            person1.name = "Test";
            Console.WriteLine(person1);
            Person person2 = new Person()
            {
                age = 50,
                name = "ahmed"

            };
            Console.WriteLine(person2);

        }
        static void TestObjectClass()
        {
            Console.WriteLine("Test Object Class");
            Object person1 = new Person("John", 30);
            Object person2 = new Person("John", 30);
            Console.WriteLine($"person.ToString() {person1.ToString()}");
            Console.WriteLine($"person1.Equals(person2) {person1.Equals(person2)}");
            Console.WriteLine($"person1.GetHashCode() {person1.GetHashCode()}");
            Console.WriteLine($"person1.GetType() {person1.GetType()}");
        }
        static void TestCloneObject()
        {
            Console.WriteLine("TestCloneObject");
            Person person1 = new Person("John", 30);
            Person person2 = new Person("John", 30);
            // person3 and person1 refere to the same refrance now
            Person person3 = person1;
            Console.WriteLine($"Person.ReferenceEquals(person1, person3) {Person.ReferenceEquals(person1, person3)}");
            // this is shallow copy not deep copy
            Person person4 = person2.Clone();
            Console.WriteLine($"Person.ReferenceEquals(person2, person4) {Person.ReferenceEquals(person2, person4)}");
        }
       }

    class Person
    {
        public string name;
        public int age;
        public Person()
        {
        }
        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;
        }
        public override string ToString()
        {
            return $"name is {name} age is {age}";
        }
        // using is keyword and as keyword 
        //public override bool Equals(Object obj)
        //{
        //    if (obj is Person)
        //    {
        //        // Person p = (Person)p; this will case erorr if obj is not Person
        //        Person p = (obj as Person)!;//this will return null if obj is not Person
        //        return age == p.age && name == p.name;
        //    }
        //    else { return false; }
        //}
        // with is keyword we can define a an object
        public override bool Equals(Object obj)
        {
            if (obj is Person p)
                return age == p.age && name == p.name;
            else return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(name, age);
        }
        public Person Clone()
        {
            return (Person)this.MemberwiseClone();
        }
    }
  
}