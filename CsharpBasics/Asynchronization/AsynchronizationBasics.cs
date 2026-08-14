/*
 * ============================================================
 * Asynchronous Programming in C#
 * ============================================================
 *
 * Main Concepts:
 *
 * 1. Synchronous code:
 *    - Runs one operation at a time.
 *    - The current thread waits until the operation finishes.
 *
 * 2. Asynchronous code:
 *    - Starts an operation and allows other work to continue.
 *    - The thread does not have to stay blocked while waiting.
 *
 * 3. Task:
 *    - Represents an asynchronous operation.
 *    - A Task can complete in the future.
 *
 * 4. async / await:
 *    - async allows a method to perform asynchronous work.
 *    - await waits asynchronously for a Task to complete.
 *    - It does NOT mean "create a new thread".
 *
 * 5. GetAwaiter().OnCompleted():
 *    - Registers a callback that runs when the Task completes.
 *    - The code after it continues immediately.
 *
 * 6. Task.Delay():
 *    - Asynchronous delay.
 *    - Unlike Thread.Sleep(), it does not block the thread.
 *
 * 7. Thread.Sleep():
 *    - Synchronous/blocking delay.
 *    - The current thread remains blocked.
 *
 * ============================================================
 */

namespace CsharpFundamentals.Asynchronization
{
    internal class AsynchronizationBasics
    {
        public static void Run()
        {
            // Run the synchronous vs asynchronous example.
            //SyncVsAsyn();

            // Run the async/await example.
            //AsyncFunctions();

            // Start the asynchronous method.
            var task = AsyncFunctions();

            // Run this callback when AsyncFunctions is completed.
            task.GetAwaiter().OnCompleted(
                () => Console.WriteLine("AsyncFunctions is over")
            );

            // Wait here only because this is a console application
            // and we want the application to stay alive until the task finishes.
            task.Wait();
        }

        // ============================================================
        // Synchronous vs Asynchronous
        // ============================================================

        public static void SyncVsAsyn()
        {
            Console.WriteLine("================== Sync Vs Asyn ==================");

            // Show information about the current thread.
            ShowThreadInfo(Thread.CurrentThread, 13);

            // Execute synchronous code.
            CallSynchronous();

            ShowThreadInfo(Thread.CurrentThread, 16);

            // Execute asynchronous code.
            CallAsynchronous();

            ShowThreadInfo(Thread.CurrentThread, 19);

            Console.ReadKey();

            Console.WriteLine("====================================\n\n\n");
        }

        // ============================================================
        // Synchronous Method
        // ============================================================

        static void CallSynchronous()
        {
            // Thread.Sleep blocks the current thread.
            // Nothing using this thread can continue during this time.
            Thread.Sleep(4000);

            ShowThreadInfo(Thread.CurrentThread, 27);

            // Task.Run starts work on a ThreadPool thread,
            // but Wait() blocks the current thread until it finishes.
            Task.Run(() =>
                Console.WriteLine("++++++++++ Synchronous +++++++++++")
            ).Wait();
        }

        // ============================================================
        // Asynchronous Method
        // ============================================================

        static void CallAsynchronous()
        {
            ShowThreadInfo(Thread.CurrentThread, 34);

            // Task.Delay creates an asynchronous delay.
            // The current thread is not blocked while waiting.
            Task.Delay(4000).GetAwaiter().OnCompleted(() =>
            {
                // This code runs after the delay is completed.
                ShowThreadInfo(Thread.CurrentThread, 37);

                Console.WriteLine("++++++++++ Asynchronous +++++++++++");
            });

            // Code here can continue immediately.
        }

        // ============================================================
        // Thread Information
        // ============================================================

        private static void ShowThreadInfo(Thread th, int line)
        {
            Console.WriteLine(
                $"Line#: {line}, " +
                $"TID: {th.ManagedThreadId}, " +
                $"Pooled: {th.IsThreadPoolThread}, " +
                $"Background: {th.IsBackground}"
            );
        }

        // ============================================================
        // Async / Await
        // ============================================================

        public static async Task AsyncFunctions()
        {
            Console.WriteLine("================== Async Functions ==================");

            // -- 1 -- Using GetAwaiter().OnCompleted()
            //
            // Start the asynchronous operation.
            //var task = Task.Run(() => ReadContent("https://www.youtube.com/c/Metigator"));

            // Get an awaiter for the Task.
            //var awaiter = task.GetAwaiter();

            // Run the callback when the operation is completed.
            //awaiter.OnCompleted(() => Console.WriteLine(awaiter.GetResult()));

            // This line can run before the asynchronous operation finishes.
            //Console.WriteLine(
            //    "run before OnCompleted even its code after it (becouse its Async)"
            //);


            // -- 2 -- Using async / await
            //
            // await waits asynchronously for ReadContentAsync to finish.
            // The method does not block the thread while waiting.
            string value = await ReadContentAsync(
                "https://www.youtube.com/c/Metigator"
            );

            Console.WriteLine(value);

            Console.WriteLine(
                "waits tell ReadContentAsync even the code Async " +
                "(becouse its using await)"
            );

            Console.ReadLine();

            Console.WriteLine("====================================\n\n\n");
        }

        // ============================================================
        // Return a Task directly
        // ============================================================

        static Task<string> ReadContent(string url)
        {
            var client = new HttpClient();

            // GetStringAsync returns a Task<string>.
            // The operation runs asynchronously.
            var task = client.GetStringAsync(url);

            return task;
        }

        // ============================================================
        // Async Method using await
        // ============================================================

        static async Task<string> ReadContentAsync(string url)
        {
            var client = new HttpClient();

            // Wait asynchronously until the HTTP request finishes.
            var content = await client.GetStringAsync(url);

            return content;
        }
    }
}