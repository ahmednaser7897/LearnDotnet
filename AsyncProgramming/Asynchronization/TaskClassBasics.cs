/*
 * ================================================================
 * Task Class Basics - C# Asynchronous Programming
 * ================================================================
 *
 * Main concepts covered in this file:
 *
 * 1. Thread vs Task
 *    - Thread represents an actual OS thread.
 *    - Task represents an asynchronous operation.
 *    - Tasks normally use ThreadPool threads.
 *
 * 2. Task<T>
 *    - A Task can return a value.
 *    - Result, GetAwaiter().GetResult(), and await can retrieve it.
 *
 * 3. LongRunning Tasks
 *    - TaskCreationOptions.LongRunning tells the scheduler that
 *      the operation is expected to take a long time.
 *
 * 4. Exception Propagation
 *    - Exceptions thrown inside a Thread do not automatically return
 *      to the thread that started it.
 *    - Exceptions from a Task can be observed by Result, Wait, or await.
 *
 * 5. Task Continuations
 *    - ContinueWith() allows code to run after a Task completes.
 *    - GetAwaiter().OnCompleted() can also register a continuation.
 *
 * 6. Task.Delay vs Thread.Sleep
 *    - Thread.Sleep blocks the current thread.
 *    - Task.Delay creates a delay without blocking the current thread
 *      when it is awaited.
 *
 * 7. Async/Await and Progress Reporting
 *    - async/await allows asynchronous operations to be composed.
 *    - Action<T> can be used to report progress to the caller.
 *
 * Important:
 * - Task.Run() does not mean "make the code asynchronous" by itself.
 * - await is the normal/recommended way to asynchronously wait for a Task.
 * - Wait() and Result block the current thread.
 *
 * ================================================================
 */

namespace AsyncProgramming.Asynchronization
{
    internal class TaskClassBasics
    {
        public static void Run()
        {
            // Uncomment one example at a time to test it.

            // ThreadVsTasks();
            // TaskReturnsValue();
            // LongRunningTask();
            // ExceptionPropagation();
            // TaskContinuation();
            // TaskDelay();

            // Start the asynchronous progress operation.
            var task = ReportProgress();

            // Register code that runs when ReportProgress is completed.
            task.GetAwaiter().OnCompleted(() =>
                Console.WriteLine("ReportProgress is over"));

            // Wait for the asynchronous operation to finish.
            task.Wait();
        }

        // ================================================================
        // Thread Vs Tasks
        // ================================================================

        public static void ThreadVsTasks()
        {
            Console.WriteLine("================== Thread Vs Tasks ==================");

            // Create and start a real Thread.
            var th = new Thread(() => Display("Metigator using thread !!!"));

            th.Start();

            // Wait for the Thread to finish.
            th.Join();

            // Task.Run normally uses a ThreadPool thread.
            Task.Run(() => Display("Metigator using task !!!")).Wait();

            // Display a message and information about the current thread.
            void Display(string message)
            {
                ShowThreadInfo(Thread.CurrentThread);
                Console.WriteLine(message);
            }

            // Display information about a thread.
            void ShowThreadInfo(Thread th)
            {
                Console.WriteLine(
                    $"TID: {th.ManagedThreadId}, " +
                    $"Pooled: {th.IsThreadPoolThread}, " +
                    $"Background: {th.IsBackground}");
            }

            Console.WriteLine("====================================\n\n\n");
        }

        // ================================================================
        // Task Returns Value
        // ================================================================

        public static void TaskReturnsValue()
        {
            Console.WriteLine("==================  Task Returns Value ==================");

            // Task<DateTime> means the Task will eventually return a DateTime.
            Task<DateTime> task = Task.Run(() => DateTime.Now);

            // Result blocks the current thread until the result is ready.
            // Console.WriteLine(task.Result);

            // GetResult also waits if the Task has not completed yet.
            Console.WriteLine(task.GetAwaiter().GetResult());

            Console.WriteLine("====================================\n\n\n");
        }

        // ================================================================
        // Long Running Task
        // ================================================================

        public static void LongRunningTask()
        {
            Console.WriteLine("==================  Long Running Task ==================");

            // LongRunning tells the scheduler that this operation
            // is expected to take a long time.
            var task = Task.Factory.StartNew(
                () =>
                {
                    // Simulate a long-running operation.
                    Thread.Sleep(3000);

                    var th = Thread.CurrentThread;

                    Console.WriteLine(
                        $"TID: {th.ManagedThreadId}, " +
                        $"Pooled: {th.IsThreadPoolThread}, " +
                        $"Background: {th.IsBackground}");

                    Console.WriteLine("Completed");
                },
                TaskCreationOptions.LongRunning);

            // Wait until the Task finishes.
            task.Wait();

            Console.WriteLine("====================================\n\n\n");
        }

        // ================================================================
        // Exception Propagation
        // ================================================================

        public static void ExceptionPropagation()
        {
            Console.WriteLine(
                "==================  Exception Propagation ==================");

            // -- 1 --
            // An exception thrown on another Thread does not automatically
            // propagate back to the thread that called Start().
            //
            // try
            // {
            //     var th = new Thread(ThrowException);
            //     th.Start();
            //     th.Join();
            // }
            // catch
            // {
            //     Console.WriteLine("Exception is thrown!!");
            // }


            // -- 2 --
            // The exception is handled inside the Thread itself.
            //
            // var th = new Thread(ThrowExceptionWithTryCatchBlock);
            // th.Start();
            // th.Join();


            // -- 3 --
            // Task exceptions can be observed by Wait(), Result, or await.
            // Wait() rethrows the Task exception.
            try
            {
                Task.Run(ThrowException).Wait();
            }
            catch
            {
                Console.WriteLine("Exception is thrown!!");
            }

            // This method throws an exception.
            void ThrowException()
            {
                throw new NullReferenceException();
            }

            // This method catches and handles its own exception.
            void ThrowExceptionWithTryCatchBlock()
            {
                try
                {
                    throw new NullReferenceException();
                }
                catch
                {
                    Console.WriteLine("Exception is thrown!!");

                    // Rethrow the same exception.
                    throw;
                }
            }

            Console.WriteLine("====================================\n\n\n");
        }

        // ================================================================
        // Task Continuation
        // ================================================================

        public static void TaskContinuation()
        {
            Console.WriteLine(
                "==================  Task Continuation ==================");

            // -- 1 -- Normal sequential execution.
            // Console.WriteLine(
            //     CountPrimeNumberInARange(2, 2_000_000));


            // -- 2 -- Task.Result
            // Starts the calculation on a Task.
            Task<int> task = Task.Run(
                () => CountPrimeNumberInARange(2, 3_000_000));

            // Result blocks the current thread until the Task is completed.
            // Console.WriteLine(task.Result);


            // -- 3 -- GetAwaiter + OnCompleted
            // Registers a callback that runs when the Task completes.
            //
            // Console.WriteLine("using awaiter, onComplete");
            //
            // var awaiter = task.GetAwaiter();
            //
            // awaiter.OnCompleted(() =>
            // {
            //     Console.WriteLine(awaiter.GetResult());
            // });


            // -- 4 -- ContinueWith
            Console.WriteLine("using task continuewith");

            // Run this code after the Task completes.
            task.ContinueWith(
                (x) => Console.WriteLine(x.Result));

            // This can execute before the continuation.
            Console.WriteLine("Metigator");

            // Keep the console application alive so the continuation
            // has time to execute.
            Console.ReadLine();

            Console.WriteLine("====================================\n\n\n");
        }

        // Count the number of prime numbers inside a range.
        static int CountPrimeNumberInARange(int lowerBound, int upperBound)
        {
            var count = 0;

            for (int i = lowerBound; i < upperBound; i++)
            {
                var j = 2;
                var isPrime = true;

                // Check whether the number has a divisor.
                while (j <= (int)Math.Sqrt(i))
                {
                    if (i % j == 0)
                    {
                        isPrime = false;
                        break;
                    }

                    ++j;
                }

                if (isPrime)
                    ++count;
            }

            return count;
        }

        // ================================================================
        // Task Delay
        // ================================================================

        public static void TaskDelay()
        {
            Console.WriteLine("==================  Task Delay ==================");

            // Task.Delay() by itself does not wait.
            // It simply creates a Task that completes after the delay.
            DelayUsingTask(3000);

            // Thread.Sleep blocks the current thread.
            // SleepUsingThread(3000);

            void DelayUsingTask(int ms)
            {
                // This starts a delay Task but does not wait for it.
                Task.Delay(ms);

                // This runs immediately.
                Console.WriteLine(
                    $"Completed after Task.Delay({ms})");

                // To execute this after the delay, we could register
                // a continuation:
                //
                // Task.Delay(ms).GetAwaiter().OnCompleted(() =>
                // {
                //     Console.WriteLine(
                //         $"Completed after Task.Delay({ms})");
                // });
            }

            void SleepUsingThread(int ms)
            {
                // Sleep blocks the current thread.
                Thread.Sleep(ms);

                Console.WriteLine(
                    $"Completed after Thread.Sleep({ms})");
            }

            Console.ReadLine();

            Console.WriteLine("====================================\n\n\n");
        }

        // ================================================================
        // Report Progress
        // ================================================================

        public static async Task ReportProgress()
        {
            Console.WriteLine(
                "==================  Report Progress ==================");

            // Action<int> represents a method that receives an int.
            // Here it is used to report the current progress percentage.
            Action<int> progress = (p) =>
            {
                Console.Clear();
                Console.WriteLine($"{p}%");
            };

            // Wait asynchronously until the copy operation completes.
            await Copy(progress);

            Console.ReadKey();

            Console.WriteLine("====================================\n\n\n");
        }

        // Simulate a copy operation and report its progress.
        static Task Copy(Action<int> onProgressPercentChanged)
        {
            return Task.Run(() =>
            {
                // Simulate progress from 0% to 100%.
                for (int i = 0; i <= 100; i++)
                {
                    // Simulate work for each step.
                    Task.Delay(50).Wait();

                    // Report progress every 10%.
                    if (i % 10 == 0)
                        onProgressPercentChanged(i);
                }
            });
        }
    }
}