namespace CsharpFundamentals.ObjectOrientedProgramming
{
    internal class InheritanceBasics
    {
        public static void Run()
        {
            TesttInheritanceBasics();
        }

        public static void TesttInheritanceBasics()
        {

            Creature employee1 = new Employee();
            Human employee2 = new Employee();
            Employee employee3 = new Employee();
            Console.WriteLine("--------------------------------------");
            // this is will see the Creature featurs
            // and Eat is not virtual mehod 
            // so it will not look for if Employee and Human
            // overrides this function or not to call the write one
            // so it will call the Creature Eat method
            employee1.Eat();
            // this is will see the Human featurs
            // so it will call the Human Eat method
            employee2.Eat();
            // this is will se the Employee featurs
            // but it has no implementation to the Eat method
            // so it will use the method chaining 
            // to call the nearst Eat method
            // but this is not overriding it call the nearst base class Eat method
            // in this cass its Human Eat method
            employee3.Eat();
            Console.WriteLine("--------------------------------------");
            //the same will happins
            employee1.Die();
            // this will call the Employee Die becouse it will check if Employee overridis it or not
            // and it is
            employee2.Die();
            employee3.Die();
        }

    }
    class Human : Creature
    {

        public void Think()
        {
            Console.WriteLine($"Human is Thinking");
        }
        // this is not overriding the Eat method in the base class,
        // because the Eat method in the base class is not virtual
        // and the Eat method in the derived class is not marked as override
        // so this is called method hiding , it will hide the Eat method in the base class
        // and to tell the compiler that فhis is intentional because each function is completely different from the others;
        // we use the New key.
        public new void Eat()
        {
            Console.WriteLine($"Human is Eating");
        }
        // this is overriding the Move method in the base class,
        // because the Move method in the base class is marked as virtual
        // and the Move method in the derived class is marked as override
        /*
         * Parent:
         * virtual → "You are allowed to change this behavior"
         * Child:
         * override → "I will change this behavior"
         */
        public override void Move()
        {
            Console.WriteLine($"Human is Movung");
            // we can call the base class methodes and filde and othre things
            // throw the keyword "base"
            base.Move();
        }
        public new virtual void Die()
        {
            Console.WriteLine($"Human is Dieing");
        }


    }
    class Employee : Human
    {
        public string Name {  get; set; }
        public decimal Salary { get; set; }
        public int Id { get; set; }
        public override void Die()
        {
            Console.WriteLine($"Employee is Dieing");
        }
        public override string ToString()
        {
            return $"Nd : {Id} Name {Name} Salary {Salary}";
        } 
    }
}