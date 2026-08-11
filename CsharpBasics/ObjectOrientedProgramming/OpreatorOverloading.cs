using System;
using System.Collections.Generic;
using System.Text;

namespace CsharpFundamentals.ObjectOrientedProgramming
{
    public class OpreatorOverloading
    {
        public static void Run()
        {
            ClassOpreatorOverloading();
            Console.WriteLine("=======================================");
            TestexplicitAndExplicit();
            Console.WriteLine("=======================================");

        }
        static void ClassOpreatorOverloading()
        {
            Console.WriteLine("Class Opreator Overloading");
            Complex c1 = new Complex(1, 4);
            Complex c2 = new Complex(3, 5);
            //using opreator overloading of +
            Complex c3 = c1 + c2;//->>Complex c4 = Complex.operator+(c2 , c3 )
            Console.WriteLine(c3.ToString());

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
        static void TestexplicitAndExplicit()
        {
            //using implicit casting
            Complex c1 = 100;
            Console.WriteLine(c1.ToString());
            Complex c2 = 10 + c1;
            Console.WriteLine(c2.ToString());

            //use explicit when it will be data loseing
            //for examble
            int i = (int)100.10m;//here will be data loseing 
            //using explicit casting
            Complex c3 = (Complex)100.54m;//here will be data loseing -> decimal will be int
            Console.WriteLine(c3.ToString());
            Complex c4 = (Complex)10.35m + c3;
            Console.WriteLine(c4.ToString());

            //revers casting
            int num = new Complex(1, 4);//-> this will not work untell i revers casting
            Console.WriteLine(num);
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
        //here i made explicit casting so now we can assign int to complix
        public static explicit operator Complex(decimal a)
        {
            return new Complex((int)a, (int)a);
        }
        //revers casting
        public static implicit operator int(Complex c)
        {
            return c.Real + c.Img;
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
            //return HashCode.Combine(Real, Img);
            return  base.GetHashCode();
        }
    }

}
