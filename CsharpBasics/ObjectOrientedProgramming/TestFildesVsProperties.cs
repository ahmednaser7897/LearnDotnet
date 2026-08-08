namespace CsharpFundamentals.ObjectOrientedProgramming
{
    class FildesVsProperties
    {
        public static void Run()
        {
            //by default, the value data types are stored in the stack memory, and the reference data types are stored in the heap memory.
            Console.WriteLine("Test Reference Data Types");

            TestProperties();
            Console.WriteLine("=======================================");

        }
        static void TestProperties()
        {
            Console.WriteLine("Test Properties");
            PersonClass person = new PersonClass("John", 30)
            {
                age = 50,
                // the value "can" be spacifayed in the object creation only
                //and then can not be changed
                Email = "ahmednaser@gmail.com",
                // the value "must" be spacifayed in the object creation only
                //and then can be changed
                Type = "Male"
            };
            //person.Email = "test@gmail.com"; //ERROR
            person.Type = "test"; // No ERROR
            Console.WriteLine(person);
            person.age = 70;
            person.Sallary = 1000;
            Console.WriteLine(person.Sallary);
            person.Sallary = -1000;
            Console.WriteLine(person.Sallary);

            //person.Bounus = 100;//this will cause error because Bounus `set` is private
            person.SetBounus(100);//this will not cause error because SetBounus method is public
            Console.WriteLine(person.Bounus);
            person.SetBounus(-100);//this will not cause error because SetBounus method is public
            Console.WriteLine(person.HasSallary);
            //person.HasSallary = true;//this will case

            Console.WriteLine(person.Id);
            Console.WriteLine(person.Id);
            //person.Id = true;//this will case erorr
            person.BirthYear = 2001;
            Console.WriteLine(person.BirthYear);
            person.PhoneNumber = "0112332434";
            Console.WriteLine(person.PhoneNumber);
        }
    }

    class PersonClass
    {
        static int ID = 0;
        // class data members
        //fields ->variables that are declared in a class
        public string name;
        public int age;
        //Backing Filde -> private variable that stores the value of the property
        private decimal _sallary;
        private decimal _bounus;
        //properties -> methods that are used to access the fields
        //it helps to apply validation and business logic (encapsulation)
        // it allow us using normal syntax for data members access in the class code 
        public decimal Sallary
        {
            get
            {
                return _sallary;
            }
            set
            {
                //value -> is the value that is assigned to the property from outside the class.
                if (value >= 0 && value <= 100)
                    _sallary = value;
                else
                    _sallary = 0;
            }
        }
        public decimal Bounus
        {
            get
            {
                return _bounus;
            }
            private set
            {
                if (value >= 0 && value <= 100)
                    _bounus = value;
                else
                    _bounus = 0;
            }
        }

        public void SetBounus(decimal bounus)
        {
            Bounus = bounus;
        }
        //expression-bodied property (read only)
        public bool HasSallary => Sallary > 0;

        //read-only property with a Default Value
        public int Id { get; } = ++ID;
        // property with no Backing Filde used to expose calculated values 
        public int BirthYear { get => DateTime.Now.Year - age; set => age = DateTime.Now.Year - value; }
        //Auto-Implemented Property
        public string PhoneNumber { get; set; }
        // init Property
        public string Email { get; init; }
        //required Property
        public required string Type { get; set; }
        public PersonClass(string name, int age)
        {
            this.name = name;
            this.age = age;
        }
        public override string ToString()
        {
            return $"name= {name} email= {Email} age= {age}";
        }
    }
}