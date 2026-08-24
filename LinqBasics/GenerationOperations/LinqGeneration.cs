namespace Linq.GenerationOperations
{
    internal class LinqGeneration
    {
        public static void Run()
        {
            // Run the Empty examples.
            // EmptyExamples();

            // Run the DefaultIfEmpty examples.
            // DefaultIfEmptyExamples();

            // Run the Range examples.
            // RangeExamples();

            // Run the Repeat examples.
            RepeatExamples();
        }


        // ============================================================
        // Empty Examples
        // ============================================================

        public static void EmptyExamples()
        {
            Console.WriteLine("===================== Empty Examples =====================");

            // Create an empty List.
            var questions = new List<Question>();


            // The list can contain items later.
            // 1
            // ...
            // 1000

            // Iterate through the list.
            foreach (var q in questions)
            {
                Console.WriteLine(q);
            }


            // Enumerable.Empty creates an empty IEnumerable.
            // It creates the sequence without creating a List.
            var questions2 = Enumerable.Empty<Question>();


            // The sequence can contain items later.
            // 1
            // ...
            // 1000

            // Iterate through the empty sequence.
            foreach (var q in questions2)
            {
                Console.WriteLine(q);
            }


            Console.WriteLine("==========================================");
            Console.WriteLine();
        }


        // ============================================================
        // DefaultIfEmpty Examples
        // ============================================================

        public static void DefaultIfEmptyExamples()
        {
            Console.WriteLine(
                "===================== DefaultIfEmpty Examples =====================");


            // The default value of int is 0.
            // int x; // x = 0;

            // default(int) returns 0.
            // Console.WriteLine(default(int)); // 0

            // default(DateTime) returns the default DateTime value.
            // Console.WriteLine(default(DateTime)); // 01-01-0001 12:00:00 AM

            // default(Object) returns null.
            // Console.WriteLine(
            //     default(Object) is null ? "NULL" : default(Object) is null); // NULL


            // Create an empty sequence of questions.
            var questions = Enumerable.Empty<Question>();


            // DefaultIfEmpty returns the default value when the sequence is empty.
            var question2 = questions.DefaultIfEmpty();


            // DefaultIfEmpty can also return a custom default value.
            var question3 = questions.DefaultIfEmpty(Question.Default);


            // Use the result as a quiz.
            question3.ToQuiz();


            Console.WriteLine("==========================================");
            Console.WriteLine();
        }


        // ============================================================
        // Range Examples
        // ============================================================

        public static void RangeExamples()
        {
            Console.WriteLine("===================== Range Examples =====================");


            // Enumerable.Range creates a sequence of consecutive integers.
            // Start at 1 and generate 10 numbers.
            var range = Enumerable.Range(1, 10);


            // The same result can be created manually using an array.
            // int[] range2 = new int[10];


            // Fill the array manually.
            // for (int i = 0; i < range2.Length; i++)
            //     range2[i] = i;


            // Print the values from the array.
            // for (int i = 0; i < range2.Length; i++)
            //     Console.Write($" {i}");


            // Print each number from the generated range.
            foreach (var i in range)
                Console.Write($" {i}");


            // Get questions using the generated range.
            var questions = QuestionBank.GetQuestionRange(range);


            // Display the questions as a quiz.
            questions.ToQuiz();


            Console.WriteLine("==========================================");
            Console.WriteLine();
        }


        // ============================================================
        // Repeat Examples
        // ============================================================

        public static void RepeatExamples()
        {
            Console.WriteLine("===================== Repeat Examples =====================");


            // Pick one question from the question bank.
            var q = QuestionBank.PickOne();


            // Create an empty list of questions.
            var questions2 = new List<Question>();


            // Create 10 different Question objects.
            for (int i = 0; i < 10; i++)
            {
                questions2.Add(new Question());
            }


            // Check if the first two objects are the same object.
            // Each iteration creates a new Question object.
            Console.WriteLine(
                ReferenceEquals(questions2[0], questions2[1]));


            // Enumerable.Repeat repeats the same object reference 10 times.
            var questions = Enumerable.Repeat(q, 10).ToList();


            // The first two items reference the same Question object.
            Console.WriteLine(
                ReferenceEquals(questions[0], questions[1]));


            // Display the repeated questions as a quiz.
            // questions.ToQuiz();


            Console.WriteLine("==========================================");
            Console.WriteLine();
        }
    }
}