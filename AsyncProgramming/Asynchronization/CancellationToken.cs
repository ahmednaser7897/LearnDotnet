/*
 * ============================================================
 * CancellationToken in C#
 * ============================================================
 *
 * Main Concept:
 *
 * CancellationToken provides a cooperative way to cancel
 * asynchronous or long-running operations.
 *
 * Important points:
 *
 * 1. CancellationTokenSource
 *    - Creates and controls the cancellation request.
 *    - Call Cancel() to request cancellation.
 *
 * 2. CancellationToken
 *    - Represents the cancellation request.
 *    - Token.IsCancellationRequested can be checked manually.
 *
 * 3. ThrowIfCancellationRequested()
 *    - Checks whether cancellation was requested.
 *    - Throws OperationCanceledException if cancellation was requested.
 *
 * 4. Task.Delay(..., token)
 *    - Can observe the cancellation token.
 *    - If cancellation is requested while waiting, the delay is cancelled.
 *
 * 5. Cancellation is cooperative.
 *    - Cancel() does NOT forcibly stop a thread.
 *    - The running operation must observe the token and stop itself.
 *
 * The examples below demonstrate three different approaches:
 *
 * DoCheck01:
 *    Manually checks IsCancellationRequested.
 *
 * DoCheck02:
 *    Passes the token directly to Task.Delay().
 *
 * DoCheck03:
 *    Uses ThrowIfCancellationRequested() and handles the exception.
 *
 * ============================================================
 */

namespace AsyncProgramming.Asynchronization
{
    internal class CancellationToken
    {
        public static void Run()
        {
            Console.WriteLine("==================  Long Running Task ==================");

            // Create the object responsible for requesting cancellation.
            CancellationTokenSource cancellationTokenSource =
                new CancellationTokenSource();

            // Different cancellation approaches.
            //var task = DoCheck01(cancellationTokenSource);
            //var task = DoCheck02(cancellationTokenSource);
            var task = DoCheck03(cancellationTokenSource);

            // Execute this callback when the task is completed.
            task.GetAwaiter().OnCompleted(
                () => Console.WriteLine("DoCheck is over")
            );

            // Wait until the asynchronous operation finishes.
            task.Wait();

            Console.ReadKey();

            Console.WriteLine("====================================\n\n\n");
        }

        // ============================================================
        // Approach 1: Check IsCancellationRequested manually
        // ============================================================

        static async Task DoCheck01(
            CancellationTokenSource cancellationTokenSource)
        {
            // Listen for user input in a separate task.
            Task.Run(() =>
            {
                var input = Console.ReadKey();

                // Press Q to request cancellation.
                if (input.Key == ConsoleKey.Q)
                {
                    cancellationTokenSource.Cancel();

                    Console.WriteLine("Task has been cancelled !!!");
                }
            });

            // Keep running while cancellation has not been requested.
            while (!cancellationTokenSource.Token.IsCancellationRequested)
            {
                Console.Write("Checking ...");

                // Wait asynchronously for 4 seconds.
                await Task.Delay(4000);

                Console.Write($" Completed on {DateTime.Now}");
                Console.WriteLine();
            }

            // The loop stops after cancellation is detected.
            Console.WriteLine("Check was Terminated");

            // Release the CancellationTokenSource resources.
            cancellationTokenSource.Dispose();
        }

        // ============================================================
        // Approach 2: Pass the token to Task.Delay
        // ============================================================

        static async Task DoCheck02(
            CancellationTokenSource cancellationTokenSource)
        {
            // Listen for user input in a separate task.
            Task.Run(() =>
            {
                var input = Console.ReadKey();

                // Press Q to request cancellation.
                if (input.Key == ConsoleKey.Q)
                {
                    cancellationTokenSource.Cancel();

                    Console.WriteLine("Task has been cancelled !!!");
                }
            });

            // Keep checking continuously.
            while (true)
            {
                Console.Write("Checking ...");

                // Task.Delay observes the cancellation token.
                // If Cancel() is called, Task.Delay throws
                // OperationCanceledException.
                await Task.Delay(
                    4000,
                    cancellationTokenSource.Token
                );

                Console.Write($" Completed on {DateTime.Now}");
                Console.WriteLine();
            }

            // This code is unreachable if cancellation occurs
            // because Task.Delay throws an exception.
            Console.WriteLine("Check was Terminated");

            cancellationTokenSource.Dispose();
        }

        // ============================================================
        // Approach 3: ThrowIfCancellationRequested
        // ============================================================

        static async Task DoCheck03(
            CancellationTokenSource cancellationTokenSource)
        {
            // Listen for user input in a separate task.
            Task.Run(() =>
            {
                var input = Console.ReadKey();

                // Press Q to request cancellation.
                if (input.Key == ConsoleKey.Q)
                {
                    cancellationTokenSource.Cancel();

                    Console.WriteLine("Task has been cancelled !!!");
                }
            });

            try
            {
                while (true)
                {
                    // Explicitly check whether cancellation was requested.
                    //
                    // If cancellation was requested, this throws
                    // OperationCanceledException.
                    cancellationTokenSource.Token
                        .ThrowIfCancellationRequested();

                    Console.Write("Checking ...");

                    // This delay itself does not receive the token.
                    await Task.Delay(4000);

                    Console.Write($" Completed on {DateTime.Now}");
                    Console.WriteLine();
                }
            }
            catch (Exception ex)
            {
                // Handle the exception generated by
                // ThrowIfCancellationRequested().
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("Check was Terminated");

            // Release the CancellationTokenSource resources.
            cancellationTokenSource.Dispose();
        }
    }
}