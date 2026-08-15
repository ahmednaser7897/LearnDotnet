/*
 * ============================================================
 * Task Combinators in C#
 * ============================================================
 *
 * Task combinators allow us to combine and coordinate multiple
 * asynchronous Tasks.
 *
 * Main concepts:
 *
 * 1. Task.WhenAny()
 *    - Completes when the first Task finishes.
 *    - Useful when we only care about the first completed operation.
 *
 * 2. Task.WhenAll()
 *    - Completes when ALL provided Tasks finish.
 *    - Returns all results when the Tasks return values.
 *
 * 3. Task<T>
 *    - Represents an asynchronous operation that returns a value.
 *
 * 4. Task.FromResult()
 *    - Creates an already-completed Task with a specific result.
 *
 * In this example:
 *
 * - Has1000Subscriber() takes 4 seconds.
 * - Has4000ViewHours() takes 3 seconds.
 *
 * Therefore:
 * - WhenAny() returns Has4000ViewHours() first.
 * - WhenAll() waits for both Tasks and returns both results.
 *
 * ============================================================
 */

namespace AsyncProgramming.Asynchronization
{
    internal class TaskCombinators
    {
        public static async Task Run()
        {
            // Start both operations at the same time.
            var has1000SubscriberTask =
                Task.Run(() => Has1000Subscriber());

            var has4000ViewHoursTask =
                Task.Run(() => Has4000ViewHours());

            // ============================================================
            // Task.WhenAny()
            // ============================================================

            Console.WriteLine("Using WhenAny()");
            Console.WriteLine("---------------");

            // Wait until the first Task finishes.
            //
            // Has4000ViewHours() takes 3 seconds.
            // Has1000Subscriber() takes 4 seconds.
            // Therefore, Has4000ViewHours() should finish first.
            var any = await Task.WhenAny(
                has1000SubscriberTask,
                has4000ViewHoursTask
            );

            // Result contains the result of the completed Task.
            Console.WriteLine(any.Result);

            // ============================================================
            // Task.WhenAll()
            // ============================================================

            Console.WriteLine("Using WhenAll()");
            Console.WriteLine("---------------");

            // Wait until ALL Tasks are completed.
            //
            // WhenAll returns an array containing the results
            // of all the Tasks.
            var all = await Task.WhenAll(
                has1000SubscriberTask,
                has4000ViewHoursTask
            );

            // Print the result of every completed Task.
            foreach (var t in all)
            {
                Console.WriteLine(t);
            }

            Console.ReadKey();
        }

        // ============================================================
        // Task: Has 1000 Subscribers
        // ============================================================

        static Task<string> Has1000Subscriber()
        {
            // Simulate a long-running operation.
            Task.Delay(4000).Wait();

            // Return a completed Task containing the result.
            return Task.FromResult(
                "congratulation !! you have 1000 subscribers"
            );
        }

        // ============================================================
        // Task: Has 4000 View Hours
        // ============================================================

        static Task<string> Has4000ViewHours()
        {
            // Simulate a long-running operation.
            Task.Delay(3000).Wait();

            // Return a completed Task containing the result.
            return Task.FromResult(
                "congratulation !! you have 4000 view hours"
            );
        }
    }
}