namespace CsharpFundamentals.ObjectOrientedProgramming
{
    internal class AbstractClass
    {
        public static void Run()
        {
            Geometric g = new Circle(1.0);

            Console.WriteLine(g.GetArea());
            Console.WriteLine(g.GetPerimeter());


            Geometric g1 = new Rectangle(1.0, 1.0);

            Console.WriteLine(g1.GetArea());
            Console.WriteLine(g1.GetPerimeter());


            Console.WriteLine(GeometricEquals(g, g1));
        }


        public static bool GeometricEquals(
            Geometric geometric1,
            Geometric geometric2)
        {
            return geometric1.GetArea() == geometric2.GetArea();
        }
    }


    // ============================================================
    // ABSTRACT CLASS
    // ============================================================

    abstract class Geometric
    {
        private string color;


        // Default constructor
        public Geometric()
            : this("White", false)
        {
        }


        // Parameterized constructor
        public Geometric(string color, bool filled)
        {
            this.color = color;
        }


        // Abstract methods
        // Child classes MUST implement them.

        public abstract double GetArea();

        public abstract double GetPerimeter();


        // Property instead of Java Getter/Setter

        public string Color
        {
            get
            {
                return color;
            }

            set
            {
                color = value;
            }
        }


        // ToString()
        public override string ToString()
        {
            return $"Geometric [color={color}]";
        }
    }


    // ============================================================
    // CIRCLE
    // ============================================================

    class Circle : Geometric
    {
        private double radius;


        // Default constructor
        public Circle()
            : this(1.0)
        {
        }


        // Constructor
        public Circle(double radius)
        {
            Radius = radius;
        }


        // Constructor
        public Circle(
            double radius,
            string color,
            bool filled)
            : base(color, filled)
        {
            Radius = radius;
        }


        // Implement abstract method
        public override double GetArea()
        {
            return Math.PI * radius * radius;
        }


        // Implement abstract method
        public override double GetPerimeter()
        {
            return 2 * Math.PI * radius;
        }


        // Radius property
        public double Radius
        {
            get
            {
                return radius;
            }

            set
            {
                if (value > 0)
                    radius = value;
                else
                    radius = 0;
            }
        }


        // Calculated property
        public double Diameter
        {
            get
            {
                return 2 * radius;
            }
        }


        public override string ToString()
        {
            return base.ToString()
                   + $" Circle [radius={radius}]";
        }
    }


    // ============================================================
    // RECTANGLE
    // ============================================================

    class Rectangle : Geometric
    {
        private double width;
        private double height;


        // Default constructor
        public Rectangle()
            : this(1.0, 1.0)
        {
        }


        // Constructor
        public Rectangle(
            double width,
            double height)
            : base()
        {
            Height = height;
            Width = width;
        }


        // Constructor
        public Rectangle(
            double width,
            double height,
            string color,
            bool filled)
            : base(color, filled)
        {
            Height = height;
            Width = width;
        }


        // Implement abstract method
        public override double GetArea()
        {
            return width * height;
        }


        // Implement abstract method
        public override double GetPerimeter()
        {
            return 2 * (width + height);
        }


        // Width property
        public double Width
        {
            get
            {
                return width;
            }

            set
            {
                if (value > 0)
                    width = value;
                else
                    width = 0;
            }
        }


        // Height property
        public double Height
        {
            get
            {
                return height;
            }

            set
            {
                if (value > 0)
                    height = value;
                else
                    height = 0;
            }
        }


        public override string ToString()
        {
            return base.ToString()
                   + $" Rectangle [width={width}, height={height}]";
        }
    }
}