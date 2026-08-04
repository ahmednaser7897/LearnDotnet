namespace CsharpFundamentals.CsharpBasics
{
    class ExceptionHandling
    {
        public static void Run()
        {
            BasicTryCatch();
            MultipleCatchBlocks();
            FinallyBlock();
            ExceptionProperties();
            ThrowException();
            ThrowIfExample();
            CheckedUncheckedExample();
            NestedTryCatch();
            CustomExceptionExample();
        }

        static void BasicTryCatch()
        {
            Console.WriteLine("========== Basic Try Catch ==========");

            try
            {
                int number = 10;
                int result = number / 0;
                Console.WriteLine(result);
            }
            catch
            {
                Console.WriteLine("An exception occurred.");
            }
        }

        static void MultipleCatchBlocks()
        {
            Console.WriteLine("\n========== Multiple Catch Blocks ==========");

            try
            {
                int[] numbers = { 1, 2, 3 };

                Console.Write("Enter index: ");
                int index = int.Parse(Console.ReadLine());

                Console.WriteLine(numbers[index]);
            }
            catch (FormatException e)
            {
                Console.WriteLine("Invalid number format. " + e.ToString());
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine("Index is outside array bounds. " + e.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine("General exception occurred. " + e.ToString());
            }
        }

        static void FinallyBlock()
        {
            Console.WriteLine("\n========== Finally Block ==========");

            try
            {
                Console.WriteLine("Inside try block.");
            }
            catch
            {
                Console.WriteLine("Inside catch block.");
            }
            finally
            {
                Console.WriteLine("Finally always executes.");
            }
        }

        static void ExceptionProperties()
        {
            Console.WriteLine("\n========== Exception Properties ==========");

            try
            {
                int.Parse("ABC");
            }
            catch (Exception ex)
            {
                //Console.WriteLine($"ToString : {ex.ToString()}");
                Console.WriteLine($"Message : {ex.Message}");
                Console.WriteLine($"Type    : {ex.GetType().Name}");
                Console.WriteLine($"Source  : {ex.Source}");
                Console.WriteLine($"StackTrace:\n{ex.StackTrace}");
            }
        }

        static void ThrowException()
        {
            Console.WriteLine("\n========== Throw ==========");

            try
            {
                ValidateAge(15);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void ValidateAge(int age)
        {
            if (age < 18)
            {
                throw new Exception("Age must be at least 18.");
            }

            Console.WriteLine("Valid age.");
        }
        // C# 14.0 introduces the ThrowIfNull method in the ArgumentNullException class,
        // which allows you to throw an ArgumentNullException if a specified argument is null.
        // This method simplifies the process of checking for null values and throwing exceptions,
        // making your code cleaner and more concise.
        static void ThrowIfExample()
        {
            Console.WriteLine("\n========== ThrowIfNull ==========");

            try
            {
                string? name = null;

                ArgumentNullException.ThrowIfNull(name);

                Console.WriteLine(name);
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // C# 14.0 introduces the checked and unchecked contexts for arithmetic operations,
        // which allow you to control how overflow is handled during calculations.

        static void CheckedUncheckedExample()
        {
            Console.WriteLine("\n========== Checked / Unchecked ==========");

            try
            {
                // The checked context enables overflow checking for arithmetic operations.
                //if i did not use checked keyword then it will not throw exception and will give wrong result.
                // the result will be -2147483648 which is wrong because it should be 2147483648 but it is out of range for int.
                // so we use checked keyword to throw exception when overflow occurs.
                checked
                {
                    int number = int.MaxValue;
                    number++;
                    Console.WriteLine(number);
                }
            }
            catch (OverflowException)
            {
                Console.WriteLine("Overflow detected.");
            }
            // The unchecked context allows arithmetic operations to overflow without throwing an exception.
            // In this case, the result will wrap around to the minimum value for the data type.
            // "Even if overflow checking is enabled globally, I want this particular code to allow overflow."
            unchecked
            {
                int number2 = int.MaxValue;
                number2++;

                Console.WriteLine($"Unchecked overflow = {number2}");
            }
        }

        static void NestedTryCatch()
        {
            Console.WriteLine("\n========== Nested Try Catch ==========");

            try
            {
                try
                {
                    int.Parse("ABC");
                }
                catch (FormatException )
                {
                    Console.WriteLine("Inner catch handled FormatException.");
                    throw;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Outer catch received the exception.");
            }
        }

        static void CustomExceptionExample()
        {
            Console.WriteLine("\n========== Custom Exception ==========");

            try
            {
                Withdraw(2000, 1000);
            }
            catch (InsufficientBalanceException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void Withdraw(decimal amount, decimal balance)
        {
            if (amount > balance)
            {
                throw new InsufficientBalanceException("Insufficient account balance.");
            }

            Console.WriteLine("Withdrawal successful.");
        }
    }

    class InsufficientBalanceException : Exception
    {
        public InsufficientBalanceException()
        {
        }

        public InsufficientBalanceException(string message)
            : base(message)
        {
        }

        public InsufficientBalanceException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}