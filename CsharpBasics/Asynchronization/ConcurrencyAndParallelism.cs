/*
 * ============================================================
 * Concurrency and Parallelism in C#
 * ============================================================
 *
 * Main Concepts:
 *
 * 1. Concurrency
 *    - Multiple tasks can make progress during the same period.
 *    - Work does not necessarily run at the exact same time.
 *    - Tasks can take turns using available threads/resources.
 *
 * 2. Parallelism
 *    - Multiple operations execute at the same time.
 *    - Usually uses multiple threads and CPU cores.
 *    - Parallel.ForEach is designed for CPU-bound parallel work.
 *
 * 3. Important Difference:
 *
 *    Concurrency:
 *      Task A -> Task B -> Task C
 *      They can overlap in time, but don't necessarily execute
 *      simultaneously.
 *
 *    Parallelism:
 *      Task A -> CPU/Core 1
 *      Task B -> CPU/Core 2
 *      Task C -> CPU/Core 3
 *      Multiple operations can execute simultaneously.
 *
 * 4. Thread vs Processor:
 *    - A Thread is the unit of execution.
 *    - A Processor/Core executes threads.
 *    - The OS/runtime decides where threads run.
 *
 * 5. Parallel.ForEach:
 *    - Processes multiple items using parallel execution.
 *
 * 6. Normal foreach:
 *    - Processes items sequentially, one after another.
 *
 * ============================================================
 */

namespace CsharpFundamentals.Asynchronization
{
    internal class ConcurrencyAndParallelism
    {
        public static async Task Run()
        {
            // Create a collection of daily tasks.
            var things = new List<DailyDuty>
            {
                new DailyDuty("Cleaning House"),
                new DailyDuty("Washing Dishes"),
                new DailyDuty("Doing Laundry"),
                new DailyDuty("Preparing Meals"),
                new DailyDuty("Checking Emails"),
                new DailyDuty("Cleaning House")
            };

            // ============================================================
            // Parallel Processing
            // ============================================================

            // Each item can be processed in parallel using
            // multiple threads/CPU resources.
            //
            //Console.WriteLine("Using Parallel Processing");
            //await ProcessThingsInParallel(things);


            // ============================================================
            // Concurrent / Sequential Processing
            // ============================================================

            Console.WriteLine("Using Concurrent Processing");

            // Process the items one after another.
            await ProcessThingsInConcurrent(things);

            Console.ReadKey();
        }

        // ============================================================
        // Parallel Processing
        // ============================================================

        // Parallel.ForEach can process multiple items concurrently
        // using multiple ThreadPool threads and CPU resources.
        //
        // The runtime decides how many threads to use and where
        // those threads execute.
        static Task ProcessThingsInParallel(IEnumerable<DailyDuty> things)
        {
            Parallel.ForEach(
                things,
                thing => thing.Process()
            );

            return Task.CompletedTask;
        }

        // ============================================================
        // Sequential Processing
        // ============================================================

        // The foreach loop processes one item at a time.
        //
        // The next item starts only after the current item finishes.
        static Task ProcessThingsInConcurrent(
            IEnumerable<DailyDuty> things)
        {
            foreach (var thing in things)
            {
                thing.Process();
            }

            return Task.CompletedTask;
        }
    }

    // ============================================================
    // Daily Duty
    // ============================================================

    class DailyDuty
    {
        public string title { get; private set; }

        public bool Processed { get; private set; }

        public DailyDuty(string title)
        {
            this.title = title;
        }

        public void Process()
        {
            // Display the Thread and Processor handling this operation.
            Console.WriteLine(
                $"TID: {Thread.CurrentThread.ManagedThreadId}," +
                $"ProcessorId: {Thread.GetCurrentProcessorId()}"
            );

            // Simulate some work.
            // Wait blocks the current thread for 100ms.
            Task.Delay(100).Wait();

            // Mark the duty as completed.
            this.Processed = true;
        }
    }
}