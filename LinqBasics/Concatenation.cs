using Linq.GenerationOperations;


namespace Linq
{
    class LinqConcatenation
    {
        public static void Run()
        {
            // ConcatExamples1();
            // ConcatExamples2();
            // ConcatExamples3();
            SelectManyExamples();
        }

         static void ConcatExamples1()
        {
            Console.WriteLine("===================== Concat Example 1 =====================");

            // Create the first quiz with three random questions.
            var quiz1 = QuestionBank.Randomize(3);

            // Create the second quiz with two random questions.
            var quiz2 = QuestionBank.Randomize(2);

            // Combine both quizzes into one sequence.
            var quiz3 = quiz1.Concat(quiz2);

            quiz3.ToQuiz();

            Console.WriteLine("==========================================");
            Console.WriteLine();
        }

         static void ConcatExamples2()
        {
            Console.WriteLine("===================== Concat Example 2 =====================");

            var quiz1 = QuestionBank.Randomize(3);
            var quiz2 = QuestionBank.Randomize(2);

            // Select the question titles and concatenate both sequences.
            var questionTitles = quiz1.Select(q => q.Title)
                .Concat(quiz2.Select(q => q.Title));

            // Print all question titles.
            foreach (var title in questionTitles)
            {
                Console.WriteLine(title);
            }

            Console.WriteLine("==========================================");
            Console.WriteLine();
        }

         static void ConcatExamples3()
        {
            Console.WriteLine("===================== Concat Example 3 =====================");

            // Select titles from the first three random questions.
            var questionTitles =
                QuestionBank.Randomize(3)
                    .Select(q => q.Title)

                    // Add titles from another two random questions.
                    .Concat(
                        QuestionBank.Randomize(2)
                            .Select(q => q.Title)
                    )

                    // Add titles from questions 11 to 24.
                    .Concat(
                        QuestionBank.GetQuestionRange(Enumerable.Range(11, 14))
                            .Select(q => q.Title)
                    );

            // Print all question titles.
            foreach (var title in questionTitles)
            {
                Console.WriteLine(title);
            }

            Console.WriteLine("==========================================");
            Console.WriteLine();
        }

         static void SelectManyExamples()
        {
            Console.WriteLine("===================== SelectMany Example =====================");

            var quiz1 = QuestionBank.Randomize(3);
            var quiz2 = QuestionBank.Randomize(2);

            // Create an array containing two IEnumerable<Question> sequences.
            var quiz3 = new[] { quiz1, quiz2 };

            Console.WriteLine(quiz3);

            // SelectMany flattens multiple sequences into one IEnumerable<Question>.
            var quiz4 = new[] { quiz1, quiz2 }
                .SelectMany(q => q);

            Console.WriteLine(quiz4);

            quiz4.ToQuiz();

            Console.WriteLine("==========================================");
            Console.WriteLine();
        }
    }
}