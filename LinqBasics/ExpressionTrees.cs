using System;
using System.Linq.Expressions;

namespace Linq
{
    internal class LinqExpressionTrees
    {
        public static void Run()
        {
            // ExpressionTreesExamples1();
            // ExpressionTreesExamples2();
            ExpressionTreesExamples3();
        }

        public static void ExpressionTreesExamples1()
        {
            Console.WriteLine("===================== Expression Trees Example 1 =====================");

            // A Func stores executable code that can be invoked directly.
            Func<int, bool> isEven = (x) => x % 2 == 0;

            Console.WriteLine(isEven(10));
            Console.WriteLine(isEven.Invoke(10));
            Console.WriteLine(IsEvenMethod(10));

            Console.WriteLine("==========================================");

            // An Expression Tree stores the structure of the code instead of only executable code.
            Expression<Func<int, bool>> isEvenExpression = (x) => x % 2 == 0;

            // We cannot invoke an Expression Tree directly.
            // Console.WriteLine(isEvenExpression(10));

            // Compile converts the Expression Tree into an executable delegate.
            var isEven2 = isEvenExpression.Compile();

            Console.WriteLine(isEvenExpression.Compile());
            Console.WriteLine(isEven2(10));

            Console.WriteLine("==========================================");
            Console.WriteLine();
        }

        static bool IsEvenMethod(int x) => x % 2 == 0;

        public static void ExpressionTreesExamples2()
        {
            Console.WriteLine("===================== Expression Trees Example 2 =====================");

            // Create an Expression Tree representing: x => x < 0.
            Expression<Func<int, bool>> isNegative = (x) => x < 0;

            // Parameters contains the parameters used by the Expression Tree.
            var parameters = isNegative.Parameters;

            if (parameters != null && parameters.Count > 0)
            {
                foreach (ParameterExpression item in parameters)
                {
                    Console.WriteLine(
                        $"Parameter name: {item.Name}, parameter type: {item.Type.Name}"
                    );
                }
            }

            // Get the first parameter: x.
            var parameter = isNegative.Parameters[0];

            // Body contains the actual operation: x < 0.
            // The Body is an Expression, and here it is a BinaryExpression.
            BinaryExpression operation = (BinaryExpression)isNegative.Body;

            // The left side of the operation is the parameter x.
            ParameterExpression left =
                (ParameterExpression)operation.Left;

            // The right side of the operation is the constant value 0.
            ConstantExpression right =
                (ConstantExpression)operation.Right;

            // We can inspect the Expression Tree and understand its structure.
            Console.WriteLine(
                $"Decomposed Expression: {parameter.Name} => " +
                $"{left.Name} {operation.NodeType} {right.Value}"
            );

            Console.WriteLine("==========================================");
            Console.WriteLine();
        }

        public static void ExpressionTreesExamples3()
        {
            Console.WriteLine("===================== Expression Trees Example 3 =====================");

            // We want to manually build this Expression Tree:
            // (num) => num % 2 == 0

            // Create the parameter: num.
            ParameterExpression numParameter =
                Expression.Parameter(typeof(int), "num");

            // Create the constant values: 0 and 2.
            ConstantExpression zeroParameter =
                Expression.Constant(0, typeof(int));

            ConstantExpression twoParameter =
                Expression.Constant(2, typeof(int));

            // Create the modulo operation: num % 2.
            BinaryExpression moduloBinaryExpression =
                Expression.Modulo(numParameter, twoParameter);

            // Create the equality operation: (num % 2) == 0.
            BinaryExpression isEvenBinaryExpression =
                Expression.Equal(moduloBinaryExpression, zeroParameter);

            // Build the complete Lambda Expression:
            // num => num % 2 == 0
            Expression<Func<int, bool>> isEvenExpression =
                Expression.Lambda<Func<int, bool>>(
                    isEvenBinaryExpression,
                    new ParameterExpression[] { numParameter }
                );

            // Compile the Expression Tree into an executable delegate.
            var isEven = isEvenExpression.Compile();

            Console.WriteLine(isEven(10));
            Console.WriteLine(isEven(9));

            Console.WriteLine("==========================================");
            Console.WriteLine();
        }
    }
}