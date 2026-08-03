//ITI LECTURE 3 - C# Fundamentals -  Struct Basics
//https://www.youtube.com/watch?v=vOpWgihaIVs&list=PLNFDrRZdysFxcO03JtQeIMed4GHFc2YlT&index=3

namespace CsharpFundamentals.CsharpBasics
{
    internal struct Complex
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
        public static bool operator==(Complex c1, Complex c2)
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
            if(obj is Complex)
            {
                return this == (Complex)obj;
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
    internal class StructBasics
    {
        public static void Run()
        {
            Console.WriteLine("Test Enum Data Type");
            //sruct is value data type 
            //can not be accessed if its null
            //pass by its value
            StructUsing();
            StructOpreatorOverloading();
            StructPassing();

            Console.WriteLine("=======================================");
        }
        public static void StructUsing()
        {
            Console.WriteLine("Test Enum Data Type");
            // this way of creating uninitilized parimtars insied the struct
            Complex c1;
            c1.Real = 5;
            //Console.WriteLine(c1);//Compil erorr
            //Console.WriteLine(c1.Img);//Compil erorr
            //this will work becouse i gaved it a value
            Console.WriteLine(c1.Real);

            //if i want it to take the defult values use the defult contructor
            Complex c2 = new Complex();
            Console.WriteLine(c2);//CsharpFundamentals.CsharpBasics.Complex
            Console.WriteLine(c2.Img);//0
            Console.WriteLine(c1.Real);//0

            Complex c3 = new Complex(4, 5);
            Console.WriteLine(c3);//CsharpFundamentals.CsharpBasics.Complex
            Console.WriteLine(c3.Img);//5
            Console.WriteLine(c3.Real);//4
            Console.WriteLine("=======================================");
        }
        static void StructOpreatorOverloading()
        {
            Console.WriteLine("Struct Opreator Overloading");
            Complex c1 = new Complex(1,4);
            Complex c2 = new Complex(3,5);
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
            Console.WriteLine($"is c6 [{c6}] == c7 [{c7}]? {c6==c7}");
            Console.WriteLine($"is c7 [{c7}] == c8 [{c8}]? {c7 == c8}");

            ///using opreator overloading of ++ pre and post
            Console.WriteLine("Stest ++ pre and post");
            Console.WriteLine($"c6 befor is [{c6}]");//c6 befor is [Real is 1 and Img is 4]
            Complex c9= c6++;
            Console.WriteLine($"c6 after is [{c6}]");//c6 after is [Real is 2 and Img is 5]
            Console.WriteLine($"c9 is [{c9}]");//c9 is [Real is 1 and Img is 4]

            Console.WriteLine($"c7 befor is [{c7}]");//c7 befor is [Real is 3 and Img is 5]
            Complex c10 = ++c7;
            Console.WriteLine($"c7 after is [{c7}]");//c7 after is [Real is 4 and Img is 6]
            Console.WriteLine($"c10 is [{c10}]");//c10 is [Real is 4 and Img is 6]
        }
        static void StructPassing()
        {   // struct is in the heap every one is self alone not refrance
            Complex c1 = new Complex(1, 2);
            Complex c2 = c1;
            c2.Real = 100;
            Console.WriteLine(c1.Real); // 1
            Console.WriteLine(c2.Real); // 100

            //pssing is by value so if it changes in a fnuction it will not effect 
            Complex c = new Complex(1, 2);
            Change(c);
            Console.WriteLine(c.Real);
        }

        static void Change(Complex c)
        {
            c.Real = 100;
        }

    }
}
