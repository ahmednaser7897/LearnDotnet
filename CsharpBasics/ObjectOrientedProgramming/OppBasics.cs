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
            ClassOpreatorOverloading();
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
        static void ClassOpreatorOverloading()
        {
            Console.WriteLine("Class Opreator Overloading");
            Complex c1 = new Complex(1, 4);
            Complex c2 = new Complex(3, 5);
            //using opreator overloading of +
            Complex c3 = c1 + c2;//->>Complex c4 = Complex.operator+(c2 , c3 )
            Console.WriteLine(c3.ToString());

            //using implicit casting
            Complex c4 = 100;
            Console.WriteLine(c4.ToString());
            Complex c5 = 10 + c4;
            Console.WriteLine(c5.ToString());

            //using opreator overloading of == and !=
            Complex c6 = new Complex(1, 4);
            Complex c7 = new Complex(3, 5);
            Complex c8 = new Complex(3, 5);
            Console.WriteLine($"is c6 [{c6}] == c7 [{c7}]? {c6 == c7}");
            Console.WriteLine($"is c7 [{c7}] == c8 [{c8}]? {c7 == c8}");

            ///using opreator overloading of ++ pre and post
            Console.WriteLine("Stest ++ pre and post");
            Console.WriteLine($"c6 befor is [{c6}]");//c6 befor is [Real is 1 and Img is 4]
            Complex c9 = c6++;
            Console.WriteLine($"c6 after is [{c6}]");//c6 after is [Real is 2 and Img is 5]
            Console.WriteLine($"c9 is [{c9}]");//c9 is [Real is 1 and Img is 4]

            Console.WriteLine($"c7 befor is [{c7}]");//c7 befor is [Real is 3 and Img is 5]
            Complex c10 = ++c7;
            Console.WriteLine($"c7 after is [{c7}]");//c7 after is [Real is 4 and Img is 6]
            Console.WriteLine($"c10 is [{c10}]");//c10 is [Real is 4 and Img is 6]
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
    class Complex
    {
        public int Real;
        public int Img;
        public Complex(int Real, int Img)
        {
            this.Real = Real;
            this.Img = Img;
        }
        public
        override string ToString() => $"Real is {Real} and Img is {Img}";
        // opreator overloading for adding
        public static Complex operator +(Complex c1, Complex c2)
        {
            return new Complex(c1.Real + c2.Real, c1.Img + c2.Img);
        }
        //here i made implicit casting so now we can assign int to complix
        public static implicit operator Complex(int a)
        {
            return new Complex(a, a);
        }
        // if we used opreator overloading for a logical opreator 
        //we must create the obist of it
        // so if we created == we must create !=
        // opreator overloading for ==
        public static bool operator ==(Complex c1, Complex c2)
        {
            return (c1.Real == c2.Real && c1.Img == c2.Img);
        }
        // opreator overloading for !=
        public static bool operator !=(Complex c1, Complex c2)
        {
            //return (c1.Real != c2.Real || c1.Img != c2.Img);
            return !(c1 == c2);
        }
        //The compiler decides whether it's prefix or postfix based on the syntax (++x vs x++)
        //and generates the appropriate code.
        //You only overload one ++ operator. The compiler automatically uses it
        //for both prefix (++x) and postfix (x++).
        //opreator overloading for ++ pre and post
        public static Complex operator ++(Complex C)
        {
            C.Real++;
            C.Img++;
            return C;
        }

        public override bool Equals(Object? obj)
        {
            if (obj is Complex c)
            {
                return this == c;
            }
            else
            {
                return false;
            }

        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Real, Img);
        }
    }

}