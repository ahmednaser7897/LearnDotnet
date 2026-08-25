using Linq.GenerationOperations;
namespace Linq
{
    internal class LinqElementOperations
    {
        public static void Run()
        {
            // ElementAtExamples();
            // FirstExamples();
            // LastExamples();
            SingleExamples();
        }

        public static void ElementAtExamples()
        {
            Console.WriteLine("===================== ElementAt Examples =====================");

            var question = QuestionBank.All;

            var question10 = question.ElementAt(10);
            Console.WriteLine($"question10->\n{question10}");

            // var question300 = question.ElementAt(300); --> ArgumentOutOfRangeException
            // Console.WriteLine($"question300->\n{question300}");

            var question300OrNull = question.ElementAtOrDefault(300); // --> No error
            Console.WriteLine($"question300OrNull->\n{question300OrNull}");

            Console.WriteLine("==========================================");
            Console.WriteLine();
        }

        public static void FirstExamples()
        {
            Console.WriteLine("===================== First Examples =====================");

            var question = QuestionBank.All;

            var firstQuestion = question.First();
            Console.WriteLine($"firstQuestion->\n{firstQuestion}");

            var firstQuestionWithCondition =
                question.First((q) => q.Title.Contains("Compression"));

            Console.WriteLine($"firstQuestionWithCondition->\n{firstQuestionWithCondition}");

            // var noTitleQuestion = question.First((q) => q.Title.Length == 0); // --> InvalidOperationException
            // Console.WriteLine($"noTitleQuestion->\n{noTitleQuestion}");

            var noTitleQuestionOrNull =
                question.FirstOrDefault((q) => q.Title.Length == 0);

            Console.WriteLine($"noTitleQuestionOrNull->\n{noTitleQuestionOrNull}");

            Console.WriteLine("==========================================");
            Console.WriteLine();
        }

        public static void LastExamples()
        {
            Console.WriteLine("===================== Last Examples =====================");

            var question = QuestionBank.All;

            var lastQuestion = question.Last();
            Console.WriteLine($"lastQuestion->\n{lastQuestion}");

            var lastQuestionWithCondition =
                question.Last((q) => q.Title.Contains("Compression"));

            Console.WriteLine($"lastQuestionWithCondition->\n{lastQuestionWithCondition}");

            // var noTitleQuestion = question.Last((q) => q.Title.Length == 0); // --> InvalidOperationException
            // Console.WriteLine($"noTitleQuestion->\n{noTitleQuestion}");

            var noTitleQuestionOrNull =
                question.LastOrDefault((q) => q.Title.Length == 0);

            Console.WriteLine($"noTitleQuestionOrNull->\n{noTitleQuestionOrNull}");

            Console.WriteLine("==========================================");
            Console.WriteLine();
        }

        public static void SingleExamples()
        {
            Console.WriteLine("===================== Single Examples =====================");

            var question = QuestionBank.All;

            // Item must exist, and only one item must match the condition.
            var singleQuestion =
                question.Single(q => q.Title.Contains("Compression"));

            Console.WriteLine($"singleQuestion->\n{singleQuestion}");

            // More than one item with Single case --> InvalidOperationException
            // var singleInvalidQuestion = question.Single(q => q.Title.Contains("#245")); // --> InvalidOperationException
            // Console.WriteLine($"singleInvalidQuestion->\n{singleInvalidQuestion}");

            // More than one item with SingleOrDefault case --> InvalidOperationException
            // var singleInvalidQuestionOrDefault = question.SingleOrDefault(q => q.Title.Contains("#245")); // --> InvalidOperationException
            // Console.WriteLine($"singleInvalidQuestionOrDefault->\n{singleInvalidQuestionOrDefault}");

            // No items with Single case --> InvalidOperationException
            // var noTitleQuestionOrNull = question.Single((q) => q.Title.Length == 0); // --> InvalidOperationException
            // Console.WriteLine($"noTitleQuestionOrNull->\n{noTitleQuestionOrNull}");

            // No items with SingleOrDefault returns null.
            var noTitleQuestionOrNull =
                question.SingleOrDefault((q) => q.Title.Length == 0);

            Console.WriteLine($"noTitleQuestionOrNull->\n{noTitleQuestionOrNull}");

            Console.WriteLine("==========================================");
            Console.WriteLine();
        }
    }
}