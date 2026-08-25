using Linq.GenerationOperations;
using System;
using System.Linq;

namespace Linq
{
    internal class LinqAggregateOperations
    {
        public static void Run()
        {
            AggregateExamples1();
            AggregateExamples2();
            AggregateExamples3();
            CountExamples();
            MaxExamples();
            MaxByExamples();
            MinExamples();
            MinByExamples();
            SumExamples();
            AverageExamples();
        }

        public static void AggregateExamples1()
        {
            Console.WriteLine("===================== Aggregate Example 1 =====================");

            var names = new[] { "Ali", "Salem", "Abeer", "Reem", "Jalal" };

            // Aggregate combines all elements into one final result.
            var commaSeparatedNames = names.Aggregate((a, b) =>
            {
                Console.WriteLine($"a = {a}, b = {b}");
                return $"{a},{b}";
            });

            // Aggregate can be used like string.Join while allowing custom logic.
            Console.WriteLine($"commaSeparatedNames -> {commaSeparatedNames}");

            Console.WriteLine("==========================================");
            Console.WriteLine();
        }

        public static void AggregateExamples2()
        {
            Console.WriteLine("===================== Aggregate Example 2 =====================");

            var numbers = new[] { 1, 2, 3, 4, 5 };

            // The first value starts as 2, then all numbers are added to it.
            var total = numbers.Aggregate(2, (a, b) => a + b);

            Console.WriteLine($"Total: {total}");

            Console.WriteLine("==========================================");
            Console.WriteLine();
        }

        public static void AggregateExamples3()
        {
            Console.WriteLine("===================== Aggregate Example 3 =====================");

            var quiz = QuestionBank.All;

            var longestQuestionTitle = quiz[0];

            Console.WriteLine($"{longestQuestionTitle}");
            Console.WriteLine("-----");

            // Find the question that has the longest title.
            longestQuestionTitle =
                quiz.Aggregate(
                    longestQuestionTitle,
                    (longest, next) =>
                        longest.Title.Length < next.Title.Length
                            ? next
                            : longest,
                    // The final selector can be used to transform the final result.
                    x => x
                );

            Console.WriteLine($"{longestQuestionTitle}");

            Console.WriteLine("==========================================");
            Console.WriteLine();
        }

        public static void CountExamples()
        {
            Console.WriteLine("===================== Count Examples =====================");

            var quiz = QuestionBank.GetQuestionRange(Enumerable.Range(1, 200));

            // Count returns the number of elements in the sequence.
            Console.WriteLine($"Total Questions: {quiz.Count()}");

            // Count can also count elements that match a condition.
            Console.WriteLine(
                $"Total Questions With One Mark: {quiz.Count(x => x.Marks == 1)}"
            );

            // Count can also be used after filtering with Where.
            Console.WriteLine(
                $"Total Questions With One Mark: {quiz.Where(x => x.Marks == 1).Count()}"
            );

            // LongCount is used when the result can be larger than an int.
            Console.WriteLine(
                $"Total Questions With One Mark Using LongCount: {quiz.Where(x => x.Marks == 1).LongCount()}"
            );

            Console.WriteLine("==========================================");
            Console.WriteLine();
        }

        public static void MaxExamples()
        {
            Console.WriteLine("===================== Max Examples =====================");

            var quiz = QuestionBank.GetQuestionRange(Enumerable.Range(1, 200));

            // Get the maximum Marks value.
            var maximumMark = quiz.Max(x => x.Marks);

            // var maximumMark = quiz.Where(x => x.Choices.Count < 3).Max(x => x.Marks);

            Console.WriteLine($"Maximum Mark: {maximumMark}");

            Console.WriteLine("==========================================");
            Console.WriteLine();
        }

        public static void MaxByExamples()
        {
            Console.WriteLine("===================== MaxBy Examples =====================");

            var quiz = QuestionBank.GetQuestionRange(Enumerable.Range(1, 200));

            // Get the Question that has the maximum Marks.
            var maximumQuestionMark = quiz.MaxBy(x => x.Marks);

            // var maximumQuestionMark = quiz.Where(x => x.Choices.Count < 3).MaxBy(x => x.Marks);

            Console.WriteLine($"{maximumQuestionMark}");

            Console.WriteLine("==========================================");
            Console.WriteLine();
        }

        public static void MinExamples()
        {
            Console.WriteLine("===================== Min Examples =====================");

            var quiz = QuestionBank.GetQuestionRange(Enumerable.Range(1, 200));

            // Get the minimum Marks value.
            var minimumMark = quiz.Min(x => x.Marks);

            // var minimumMark = quiz.Where(x => x.Choices.Count < 3).Min(x => x.Marks);

            Console.WriteLine($"Minimum Mark: {minimumMark}");

            Console.WriteLine("==========================================");
            Console.WriteLine();
        }

        public static void MinByExamples()
        {
            Console.WriteLine("===================== MinBy Examples =====================");

            var quiz = QuestionBank.GetQuestionRange(Enumerable.Range(1, 200));

            // Get the Question that has the minimum Marks.
            var minimumQuestionMark = quiz.MinBy(x => x.Marks);

            // var minimumQuestionMark = quiz.Where(x => x.Choices.Count < 3).MinBy(x => x.Marks);

            Console.WriteLine($"{minimumQuestionMark}");

            Console.WriteLine("==========================================");
            Console.WriteLine();
        }

        public static void SumExamples()
        {
            Console.WriteLine("===================== Sum Examples =====================");

            var quiz = QuestionBank.GetQuestionRange(Enumerable.Range(1, 200));

            // Calculate the total of all question marks.
            var total = quiz.Sum(x => x.Marks);

            Console.WriteLine($"Total: {total}");

            Console.WriteLine("==========================================");
            Console.WriteLine();
        }

        public static void AverageExamples()
        {
            Console.WriteLine("===================== Average Examples =====================");

            var quiz = QuestionBank.GetQuestionRange(Enumerable.Range(1, 200));

            // Calculate the average of all question marks.
            var average = quiz.Average(x => x.Marks);

            Console.WriteLine($"Average: {average.ToString("#.##")}");

            Console.WriteLine("==========================================");
            Console.WriteLine();
        }
    }
}