
namespace CsharpFundamentals.Keywords
{
    // ============================================================
    // const
    // readonly
    // init
    // required
    // ============================================================
    class ConstantsExample
    {
        public static void Run()
        {
            // const
            Console.WriteLine(ConstantsAndImmutability.Pi);


            // readonly
            var data = new ConstantsAndImmutability(
                id: 1,
                name: "Ahmed"
            );
            //data.Name = "Erorr";

            data.Test();


            // init
            var product = new Product
            {
                Name = "Laptop",
                Price = 50000
            };

            Console.WriteLine(product.Name);
            Console.WriteLine(product.Price);

            // product.Name = "Phone"; // ERROR


            // required
            var user = new User
            {
                Name = "Ahmed",
                Email = "ahmed@gmail.com"
            };

            Console.WriteLine(user.Name);
        }
    }


    class ConstantsAndImmutability
    {
        // ========================================================
        // const
        // ========================================================
        //
        // - Value must be known at compile time.
        // - Cannot be changed.
        // - Is implicitly static.
        // ========================================================

        public const double Pi = 3.14159;

        public const int MaxUsers = 100;


        // ========================================================
        // readonly
        // ========================================================
        //
        // - Cannot be changed after initialization.
        // - Can be assigned when declared.
        // - Can also be assigned inside the constructor.
        // - Each object can have a different readonly value.
        // ========================================================

        public readonly int Id;

        public readonly string Name;


        public ConstantsAndImmutability(int id, string name)
        {
            Id = id;
            Name = name;
        }


        public void Test()
        {
            Console.WriteLine($"Pi: {Pi}");
            Console.WriteLine($"Max Users: {MaxUsers}");

            Console.WriteLine($"Id: {Id}");
            Console.WriteLine($"Name: {Name}");

            // Pi = 10;       // ERROR
            // Id = 10;       // ERROR
            // Name = "Ali";  // ERROR
        }
    }


    // ============================================================
    // init
    // ============================================================
    //
    // init allows a property to be assigned only during
    // object initialization.
    // ============================================================

    class Product
    {
        public string Name { get; init; } = "";

        public double Price { get; init; }
    }


    // ============================================================
    // required
    // ============================================================
    //
    // required forces the caller to provide a value
    // when creating the object.
    // ============================================================

    class User
    {
        public required string Name { get; set; }

        public required string Email { get; set; }

        public int Age { get; set; }
    }

}

