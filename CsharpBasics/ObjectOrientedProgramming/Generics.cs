namespace CsharpFundamentals.ObjectOrientedProgramming
{

    internal class Generics
    {
        public static void Run()
        {
            TestGenaricsBasics();
        }
        static void TestGenaricsBasics()
        {
            Console.WriteLine("Test Genarics Basics");
            Stack<string> stack = new();
            stack.ADD("1");
            stack.ADD("2");
            stack.ADD("3");
            stack.ADD("4");
            stack.ADD("5");
            Console.WriteLine(stack);
            Console.WriteLine(stack.Peek());
            Console.WriteLine(stack);
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack);
            int a = 10; int b = 20;
            Console.WriteLine($"A and B before swap is {a} , {b}");
            Swap(ref a, ref b);
            Console.WriteLine($"A and B after swap is {a} , {b}");
        }
        public static void Swap<T>(ref T a, ref T b)
        {
            var temp = a;
            a = b;
            b = temp;
        }
    }
    //we can add contrains to the generics
    // class Genarics<T> where T : class -> reference data types only
    // class Genarics<T> where T : struct -> value data types only
    // class Genarics<T> where T : new() -> must have a default constructor
    // class Genarics<T> where T : IComparable -> must implement IComparable interface
    // class Genarics<T> where T : IComparable<T> -> must implement IComparable<T> interface
    // class Genarics<T> where T : ICompar -> must implement ICompar interface
    
    public class Stack<T> where T : class
    {
        private T[] myList;
        private int curentIndex;
        public Stack()
        {
            myList = new T[3];
            curentIndex = 0;
        }
        public void ADD(T item)
        {
            if (curentIndex == myList.Length)
                Extende(item);
            else
                myList[curentIndex++] = item;

        }
        public void Extende(T item)
        {
            T[] list = new T[myList.Length * 2];
            Array.Copy(myList, list, myList.Length);
            myList = list;
            ADD(item);
        }
        public T Peek()
        {
            return myList[curentIndex - 1];
        }
        public T Pop()
        {
            return myList[--curentIndex];
        }
        public override string ToString()
        {
            var str = $"Index is : {curentIndex} and values is : ";
            for (int i = 0; i < curentIndex; i++)
            {
                str += myList[i] + " ";
            }
            return str;
        }
    }

}
