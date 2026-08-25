using Linq.GenerationOperations;
namespace Linq
{
    internal class LinqEqualityOperations
    {
        public static void Run()
        {
            // SequenceEqualExamples1();
            // SequenceEqualExamples2();
            SequenceEqualExamples3();
        }

        public static void SequenceEqualExamples1()
        {
            Console.WriteLine("===================== SequenceEqual Example 1 =====================");

            var q1 = QuestionBank.PickOne();
            var q2 = QuestionBank.PickOne();
            var q3 = QuestionBank.PickOne();

            // Both quizzes contain the same Question object references.
            var quiz1 = new List<Question>(new[] { q1, q2, q3 });
            var quiz2 = new List<Question>(new[] { q1, q2, q3 });

            // SequenceEqual checks if both sequences contain equal elements in the same order.
            var equal = quiz1.SequenceEqual(quiz2);

            Console.WriteLine(
                $"quiz#1 and quiz#2 {(equal ? "are" : "are not")} equal"
            );

            Console.WriteLine("==========================================");
            Console.WriteLine();
        }

        public static void SequenceEqualExamples2()
        {
            Console.WriteLine("===================== SequenceEqual Example 2 =====================");

            // Create one sequence containing four questions.
            var randomFourQuestions =
                QuestionBank.GetQuestionRange(Enumerable.Range(1, 4));

            // Both variables reference the same sequence.
            var quiz1 = randomFourQuestions;
            var quiz2 = randomFourQuestions;

            // Both sequences are equal because they reference the same sequence.
            var equal = quiz1.SequenceEqual(quiz2);

            Console.WriteLine(
                $"quiz#1 and quiz#2 {(equal ? "are" : "are not")} equal"
            );

            Console.WriteLine("==========================================");
            Console.WriteLine();
        }

        public static void SequenceEqualExamples3()
        {
            Console.WriteLine("===================== SequenceEqual Example 3 =====================");

            // Create the first sequence.
            var quiz1 =
                QuestionBank.GetQuestionRange(Enumerable.Range(1, 4));

            // Create another sequence with the same range.
            var quiz2 =
                QuestionBank.GetQuestionRange(Enumerable.Range(1, 4));

            // Equality depends on how the Question class implements equality.
            var equal = quiz1.SequenceEqual(quiz2);

            Console.WriteLine(
                $"quiz#1 and quiz#2 {(equal ? "are" : "are not")} equal"
            );

            Console.WriteLine("==========================================");
            Console.WriteLine();
        }
    }
}