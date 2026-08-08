namespace CsharpFundamentals.ObjectOrientedProgramming
{
    class Creature
    {
        public int Age;
        public string Name;
        public double Weight;
        public double Height;
        public Creature() : this(70)
        {   //this is a logic that exist in onother constructor and we want to use it in this constructor
            //we can use this keyword to call another constructor
            // this is called constructor chaining
            // it will go to the most specific constructor that matches the parameters
            // and then it will go to the next constructor that matches the parameters and so on
            // until it reaches the constructor that has no parameters
            // so in this case it will go to the constructor that has 2 parameters and then it will go to the constructor that has 1 parameter
            // and then it will go to the constructor that has no parameters
            // so the stack will be like this:
            // Contractor 1 -> Contractor 2 -> Contractor 3
            /*
             * instead of writing the same logic in multiple constructors,
             * we can call another constructor using this keyword 
             * Weight = 70;
             *  Height = 180;
             *  Age = 20;
             *  Name = "ahmed";
             *  Console.WriteLine($"Creature is created");
            */
            Console.WriteLine("Contractor 3");
        }
        public Creature(double Weight) : this(Weight, 180)
        {
            //this is a logic that exist in onother constructor and we want to use it in this constructor
            //we can use this keyword to call another constructor
            // this is called constructor chaining
            /*
             * instead of writing the same logic in multiple constructors,
             * we can call another constructor using this keyword 
             * this.Weight = Weight;
             * Height = 180;
             * Age = 20;
             * Name = "ahmed";
             * Console.WriteLine($"Creature is created");
            */
            Console.WriteLine("Contractor 2");
        }
        public Creature(double Weight, double Height)
        {
            this.Weight = Weight;
            this.Height = Height;
            Age = 20;
            Name = "ahmed";
            Console.WriteLine($"Creature is created");
            Console.WriteLine("Contractor 1");
        }

        /*
         * this method can not be overridden in the derived class
         * but if we want to override it in the derived class, we can use the virtual keyword
         * public void Move()
         * {
         *     Console.WriteLine($"Creature is moving");
         * }
        */
        // If we want this method to be overridden in the derived class, we can use the virtual keyword
        /*
         * Parent:
         * virtual → "You are allowed to change this behavior"
         * Child:
         * override → "I will change this behavior"
         */
        public virtual void Move()
        {
            Console.WriteLine($"Creature is moving");
        }
        public void Eat()
        {
            Console.WriteLine($"Creature is eating");
        }
        public void Sleep()
        {
            Console.WriteLine($"Creature is sleeping");

        }
        public void Die()
        {
            Console.WriteLine($"Creature is Dieing");
        }

    }

}
