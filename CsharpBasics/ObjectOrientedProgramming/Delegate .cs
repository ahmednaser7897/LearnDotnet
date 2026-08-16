namespace CsharpFundamentals.ObjectOrientedProgramming
{
    internal class DelegatesBasics
    {
        public static void Run()
        {
            //DelegateBasics();
            MultiTaskDelegate();
            //PreDefDelegates();
        }
        delegate bool IsEven(int value);
        static void DelegateBasics()
        {
            // delegate covered to class that inherit MulticastDelegate
            // and MulticastDelegate itself inherit Delegate
            // Delegate has method Invoce that call the assign methd to this Delegate
            IsEven isEven = getEven;
            //we can call it like this
            Console.WriteLine(isEven.Invoke(10));

            // or like this
            Console.WriteLine(isEven(10));
            

            bool Pluse60000(NormalEmployee e) => (e.Salary >= 60000m);
            var employees = new NormalEmployee[]
          {
                new NormalEmployee { Id = 1, Name = "Ahmed",    Salary = 65000m, Gendar = "Male" },
                new NormalEmployee { Id = 2, Name = "Sara",     Salary = 58000m, Gendar = "Female" },
                new NormalEmployee { Id = 3, Name = "Mohamed",  Salary = 72000m, Gendar = "Male" },
                new NormalEmployee { Id = 4, Name = "Mariam",   Salary = 60000m, Gendar = "Female" },
                new NormalEmployee { Id = 5, Name = "Omar",     Salary = 55000m, Gendar = "Male" },
                new NormalEmployee { Id = 6, Name = "Nour",     Salary = 67000m, Gendar = "Female" },
                new NormalEmployee { Id = 7, Name = "Youssef",  Salary = 30000m, Gendar = "Male" },
                new NormalEmployee { Id = 8, Name = "Hana",     Salary = 59000m, Gendar = "Female" },
                new NormalEmployee { Id = 9, Name = "Khaled",   Salary = 23000m, Gendar = "Male" },
                new NormalEmployee { Id = 10, Name = "Dina",    Salary = 80000m, Gendar = "Female" }
          };
            //Report.processEmployeeWith60000PlusSalary(employees);
            //Report.processEmployeeBetween30000And59999Salary(employees);
            //Report.processEmployeeWithLess30000Salary(employees);
            Illegablemployee illegablemployee1 = new Illegablemployee(Pluse60000);
            Illegablemployee illegablemployee2 = Pluse60000;
            //can send the delegate it as a var of delegate itself or the method dirctly
            //Report.ProcessEmployee(employees, "Employee With $60,000+ Salary", illegablemployee1);
            //Report.ProcessEmployee(employees, "Employee With $60,000+ Salary", illegablemployee2);
            Report.ProcessEmployee(employees, "Employee With $60,000+ Salary", Pluse60000);
            // and can use Anonymous delegate if it will used once 
            Report.ProcessEmployee(employees, "Employee Between 30000 And 59999 Salary", delegate (NormalEmployee e) { return (e.Salary >= 30000m && e.Salary < 60000m); });

            // and can write unsing lambda expression  if it will used once ->>> can write Employee type or not -> here we removed it
            Report.ProcessEmployee(employees, "Employee With Less $30,000- Salary", (e) => (e.Salary < 30000m));


        }
        
        delegate double Rec(double width, double height);
        
        static void MultiTaskDelegate()
        {
            // delegate covered to class that inherit MulticastDelegate
            // and MulticastDelegate itself inherit Delegate
            // MulticastDelegate enable us to make on delegate refare to many methodes
            // this can be done bu "InvocationList" in MulticastDelegate
           
            RectangelHelper rectangel = new RectangelHelper();

            // Delegate holds GetArea
            Rec rec = rectangel.GetArea;

            // Delegate now holds GetArea + GetPerimeter
            rec += rectangel.GetPerimeter;

            // Both methods execute
            // The return value will be from the LAST method
            var value = rec(10, 20);

            Console.WriteLine($"Rectangle Perimeter = {value}");

            // Remove GetPerimeter
            rec -= rectangel.GetPerimeter;

            // Now only GetArea executes
            var value2 = rec(10, 20);

            Console.WriteLine($"Rectangle Area = {value2}");
        }
        static void PreDefDelegates()
        {
            // Predicate<T> takes one parameter and returns bool.
            Predicate<int> GetEven = getEven;

            Console.WriteLine($"10 is {(GetEven(10) ? "even" : "odd")}");
            Console.WriteLine($"7 is {(GetEven(7) ? "even" : "odd")}");

            Console.WriteLine("================================");

            // Func<T, TResult> takes parameters and returns a value.
            // and take no parameters, so its like this Func<int>
            // here it will not take parameters but it will return int
            Func<int, int, int> Add = add;

            Console.WriteLine($"10 + 20 = {Add(10, 20)}");

            Console.WriteLine("================================");

            // Action<T> takes parameters and does not return a value.
            // and take no parameters
            Action<string> Print = (String message) => Console.WriteLine(message);

            Print("Hello from Action delegate");
        }

        // Returns true if the number is even.
        static bool getEven(int number)
        {
            return number % 2 == 0;
        }

        // Returns the sum of two numbers.
        static int add(int number1, int number2)
        {
            return number1 + number2;
        }
    }
    class NormalEmployee
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public decimal Salary { get; set; }
        public required string Gendar { get; set; }
        public override string ToString()
        {
            return $"Name {Name} Id {Id} Salary {Salary} Gender {Gendar}";
        }

    } //this is now can hold any method with this signature
     delegate bool Illegablemployee(NormalEmployee employee);
    class Report
    {
       
        public static void ProcessEmployee(NormalEmployee[] employees,string title, Illegablemployee illegablemployee)
        {
            Console.WriteLine(title);
            Console.WriteLine("------------------------------");
            foreach (var item in employees)
            {
                if (illegablemployee(item))
                    Console.WriteLine(item);
            }
            Console.WriteLine();

        }
        //this way to much code used many times
        public static void processEmployeeWith60000PlusSalary(NormalEmployee[] employees)
        {
            Console.WriteLine("Employee With $60,000+ Salary");
            Console.WriteLine("------------------------------");
            foreach (var item in employees)
            {
                if(item.Salary>=60000m)
                    Console.WriteLine(item);
            }
            Console.WriteLine();
        }
        public static void processEmployeeWithLess30000Salary(NormalEmployee[] employees)
        {
            Console.WriteLine("Employee With Less $30,000- Salary");
            Console.WriteLine("------------------------------");
            foreach (var item in employees)
            {
                if (item.Salary < 30000m)
                    Console.WriteLine(item);
            }
            Console.WriteLine();
        }
        public static void processEmployeeBetween30000And59999Salary(NormalEmployee[] employees)
        {
            Console.WriteLine("Employee Between 30000 And 59999 Salary");
            Console.WriteLine("------------------------------");
            foreach (var item in employees)
            {
                if (item.Salary >= 30000m && item.Salary < 60000m)
                    Console.WriteLine(item);
            }
            Console.WriteLine();
        }
    }
    class RectangelHelper
    {
        
        public double GetArea(double width, double height)
        {
            Console.WriteLine($"Rectangel Area = {width*height}");
            return width * height;
        }
        public double GetPerimeter(double width, double height)
        {
            Console.WriteLine($"Rectangel Perimeter = {2*(width +height)}");
            return 2 * (width + height);
        }

    }
}
