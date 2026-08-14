/*
 * ================================================================
 * THREAD POOL
 * ================================================================
 *
 * The ThreadPool is a collection of reusable threads managed by
 * the .NET runtime.
 *
 * Instead of creating a new Thread manually every time, we can
 * submit work to the ThreadPool.
 *
 * ---------------------------------------------------------------
 * Thread vs ThreadPool
 * ---------------------------------------------------------------
 *
 * Thread:
 * - We create and manage the thread ourselves.
 * - Creating many threads can be expensive.
 *
 * ThreadPool:
 * - .NET manages the threads for us.
 * - Threads are reused instead of creating new threads.
 * - Good for short-running background work.
 *
 * ---------------------------------------------------------------
 * QueueUserWorkItem
 * ---------------------------------------------------------------
 *
 * ThreadPool.QueueUserWorkItem(...)
 *
 * Adds work to the ThreadPool queue.
 *
 * The ThreadPool decides when and on which thread the work runs.
 *
 * ---------------------------------------------------------------
 * Task.Run
 * ---------------------------------------------------------------
 *
 * Task.Run(...)
 *
 * Schedules work to run on a ThreadPool thread.
 *
 * Task is the modern way to represent asynchronous work.
 *
 * ---------------------------------------------------------------
 * Important
 * ---------------------------------------------------------------
 *
 * ThreadPool work is asynchronous.
 *
 * This means:
 *
 *     ThreadPool.QueueUserWorkItem(...);
 *     Console.WriteLine(...);
 *
 * does NOT guarantee that the queued work has finished before
 * Console.WriteLine executes.
 *
 * If we need to wait for the operation, Task + await is usually
 * a better choice.
 *
 * ---------------------------------------------------------------
 * ThreadPool Threads
 * ---------------------------------------------------------------
 *
 * IsThreadPoolThread:
 * - true  -> current thread belongs to the ThreadPool.
 * - false -> current thread is not a ThreadPool thread.
 *
 * IsBackground:
 * - ThreadPool threads are background threads.
 *
 * ================================================================
 */

namespace CsharpFundamentals.Threading
{
    class TestThreadPool
    {
        public static void Run()
        {
            Console.WriteLine("================== Test Thread Pool ==================");

            Console.WriteLine("Using ThreadPool");

            // Queue work to the ThreadPool.
            ThreadPool.QueueUserWorkItem(new WaitCallback(Print));


            Console.WriteLine("Using Task");

            // Task.Run also uses a ThreadPool thread.
            Task.Run(Print);


            // Create an employee.
            var employee = new Employee
            {
                Rate = 10,
                TotalHours = 40
            };


            // Queue salary calculation to the ThreadPool.
            ThreadPool.QueueUserWorkItem(
                new WaitCallback(CalculateSalary),
                employee);


            // The calculation may not have finished yet.
            Console.WriteLine(employee.TotalSalary);

            Console.WriteLine("====================================\n\n\n");
        }


        // ============================================================
        // Calculate Salary
        // ============================================================

        private static void CalculateSalary(object employee)
        {
            // Convert the object to Employee.
            var emp = employee as Employee;

            // Stop if the object is null.
            if (employee is null)
                return;

            // Calculate the salary.
            emp.TotalSalary = emp.TotalHours * emp.Rate;

            Console.WriteLine(emp.TotalSalary.ToString("C"));
        }


        // ============================================================
        // Print
        // ============================================================

        // This overload is used by Task.Run.
        private static void Print()
        {
            // Get the current thread information.
            Console.WriteLine(
                $"Thread Id: {Thread.CurrentThread.ManagedThreadId}, " +
                $"Thread Name: {Thread.CurrentThread.Name}");

            // Check if the current thread belongs to the ThreadPool.
            Console.WriteLine(
                $"Is Pooled thread: {Thread.CurrentThread.IsThreadPoolThread}");

            // Check if the thread is a background thread.
            Console.WriteLine(
                $"Background: {Thread.CurrentThread.IsBackground}");

            // Simulate some work.
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Cycle {i + 1}");
            }
        }


        // ============================================================
        // Print With State
        // ============================================================

        // This overload is used by QueueUserWorkItem.
        private static void Print(object state)
        {
            // Get the current thread information.
            Console.WriteLine(
                $"Thread Id: {Thread.CurrentThread.ManagedThreadId}, " +
                $"Thread Name: {Thread.CurrentThread.Name}");

            // Check if the current thread belongs to the ThreadPool.
            Console.WriteLine(
                $"Is Pooled thread: {Thread.CurrentThread.IsThreadPoolThread}");

            // Check if the thread is a background thread.
            Console.WriteLine(
                $"Background: {Thread.CurrentThread.IsBackground}");

            // Simulate some work.
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Cycle {i + 1}");
            }
        }
    }


    // ================================================================
    // Employee
    // ================================================================

    class Employee
    {
        public decimal TotalHours { get; set; }

        public decimal Rate { get; set; }

        public decimal TotalSalary { get; set; }
    }
}