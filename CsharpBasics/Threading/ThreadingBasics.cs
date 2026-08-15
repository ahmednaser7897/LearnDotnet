using System.Diagnostics;

/*
 * ================================================================
 * THREADING BASICS
 * ================================================================
 *
 * Process:
 * - A process is an instance of a running application.
 * - A process can contain one or more threads.
 *
 * Thread:
 * - A thread is the smallest unit of execution inside a process.
 * - By default, code runs sequentially on the main thread.
 * - Multiple threads allow different pieces of code to run
 *   concurrently.
 *
 * Sequential Execution:
 * - Operations run one after another on the same thread.
 * - The next operation starts after the previous one finishes.
 *
 * Multithreading:
 * - Multiple threads can execute work concurrently.
 * - The operating system schedules threads on available CPU cores.
 * - Thread scheduling is not deterministic, so the execution order
 *   can change between runs.
 *
 * Important Thread Properties:
 * - ManagedThreadId : Unique ID assigned to a managed thread.
 * - Name            : Optional name assigned to a thread.
 * - ThreadState     : Current state of the thread.
 * - IsBackground    : Indicates whether the thread is a background thread.
 *
 * Thread Methods:
 * - Start() : Starts a new thread.
 * - Join()  : Blocks the calling thread until another thread finishes.
 *
 * Important:
 * - Shared data accessed by multiple threads can cause race conditions.
 * - Multithreading therefore requires synchronization when threads
 *   modify the same data.
 *
 * ================================================================
 */

namespace CsharpFundamentals.Threading
{
    internal class ThreadingBasics
    {
        public static void Run()
        {
            //ProcessAndThread();
            //Sequential();
            Multithreading1();
            //Multithreading2();
        }


        // ============================================================
        // Process and Thread
        // ============================================================

        public static void ProcessAndThread()
        {
            Console.WriteLine("================== Process And Thread ==================");

            // Gets the ID of the current process.
            Console.WriteLine(
                $"Process Id: {Process.GetCurrentProcess().Id}");

            // Gets the ID of the current managed thread.
            Console.WriteLine(
                $"Thread Id: {Thread.CurrentThread.ManagedThreadId}");

            // Gets the processor currently executing this thread.
            Console.WriteLine(
                $"Processor Id: {Thread.GetCurrentProcessorId()}");

            Console.WriteLine("====================================\n\n\n");
        }


        // ============================================================
        // Sequential Execution
        // ============================================================

        public static void Sequential()
        {
            // By default, code executes sequentially on a single thread.
            // The same thread can be scheduled on different processors.
            Console.WriteLine("================== Sequential ==================");

            var wallet = new SequentialWallet("Issam", 80);

            // All transactions run one after another.
            wallet.RunRandomTransactions();

            Console.WriteLine("----------------");
            Console.WriteLine($"{wallet}\n");

            // The second call starts after the first call finishes.
            wallet.RunRandomTransactions();

            Console.WriteLine("----------------");
            Console.WriteLine($"{wallet}\n");
        }


        // ============================================================
        // Multithreading
        // ============================================================
        public static void Multithreading1()
        {
            Console.WriteLine("================== Multithreading 1 ==================");
            // by defoult it works in Concurrency -> not the same time exactly(work in each some time and go to 2nd and so on)
            // to make it work exactly in the same time it must use Parallelism
            // as you see some output with White color and this is wrong
            // this becouse Threads conflict
            // so its not recommended to use static members with Threads(ex:ConsoleColor.White)
            // this is called race condition and can be solved using (lock keyword)
            // 1- thi can have race condition
            //var thread1 = new Thread(PrintThread1);
            //var thread2 = new Thread(PrintThread2);
            //thread1.Start();
            //thread2.Start();
            // 2- this can not have race condition
            var thread3 = new Thread(PrintThread3);
            var thread4 = new Thread(PrintThread4);
            //thread3.Start();
            //thread4.Start();

            // we can give thread Priority
            thread3.Priority = ThreadPriority.Lowest;
            thread4.Priority = ThreadPriority.Highest;
            //thread3.Start();
            //thread4.Start();

            // by defoult the main Thread in the app is Foreground
            // the the app will ends when all the Foreground Threads ends
            // even we sill have Background Threads not ended yet
            // so here the app will end before thread3,thread4 ends
            thread3.IsBackground = true;
            thread4.IsBackground = true;
            //thread3.Start();
            //thread4.Start();

            Console.WriteLine("====================================\n\n\n");
        }
        public static void PrintThread1()
        {
            for (int i = 0; i < 100; i++)
            {

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Thread One : " + i.ToString());
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        public static void PrintThread2()
        {
            for (int i = 100; i < 200; i++)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Thread Two : " + i.ToString());
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        private static readonly object _lock = new();
        public static void PrintThread3()
        {
            for (int i = 0; i < 100; i++)
            {
                lock (_lock)
                {

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Thread 3 : " + i.ToString());
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }
        public static void PrintThread4()
        {
            for (int i = 100; i < 200; i++)
            {
                lock (_lock)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Thread 4 : " + i.ToString());
                    Console.ForegroundColor = ConsoleColor.White;
                }

            }
        }

        public static void Multithreading2()
        {
            Console.WriteLine("================== Multithreading 2 ==================");

            // Name the current thread.
            Thread.CurrentThread.Name = "Main Thread";

            Console.WriteLine(Thread.CurrentThread.Name);

            // Shows whether the current thread is a background thread.
            //Console.WriteLine($"Background Thread: {Thread.CurrentThread.IsBackground}");

            var wallet = new MultithreadingWallet("Issam", 80);


            // Create a new thread and give it a method to execute.
            Thread t1 = new Thread(wallet.RunRandomTransactions);

            t1.Name = "T1";

            // Shows the state before the thread starts.
            //Console.WriteLine($"T1 Background Thread: {t1.IsBackground}");

            Console.WriteLine(
                $"after declaration {t1.Name} state is: {t1.ThreadState}");


            // Start the new thread.
            t1.Start();

            Console.WriteLine(
                $"after start() {t1.Name} state is: {t1.ThreadState}");


            // Join stops the current thread until t1 finishes.
            // Uncomment to wait for T1.
            //t1.Join();


            // Another way to create a Thread using ThreadStart.
            Thread t2 = new Thread(
                new ThreadStart(wallet.RunRandomTransactions));

            t2.Name = "T2";

            // Start the second thread.
            t2.Start();

            Console.WriteLine(
                $"after start {t1.Name} state is: {t1.ThreadState}");

            Console.WriteLine("====================================\n\n\n");
        }
    }


    // ================================================================
    // Sequential Wallet
    // ================================================================

    class SequentialWallet
    {
        public SequentialWallet(string name, int bitcoins)
        {
            Name = name;
            Bitcoins = bitcoins;
        }

        public string Name { get; private set; }
        public int Bitcoins { get; private set; }


        // Removes bitcoins from the wallet.
        public void Debit(int amount)
        {
            Bitcoins -= amount;
        }


        // Adds bitcoins to the wallet.
        public void Credit(int amount)
        {
            Bitcoins += amount;
        }


        // Executes transactions sequentially.
        public void RunRandomTransactions()
        {
            // Positive values represent credit.
            // Negative values represent debit.
            int[] amounts =
            {
                10, 20, 30, -20, 10,
                -10, 30, -10, 40, -20
            }; // 80

            foreach (var amount in amounts)
            {
                var absValue = Math.Abs(amount);

                // Negative amount means debit.
                if (amount < 0)
                    Debit(absValue);

                // Positive amount means credit.
                else
                    Credit(absValue);

                Console.WriteLine(
                    $"[Thread: {Thread.CurrentThread.ManagedThreadId}" +
                    $", Processor Id: {Thread.GetCurrentProcessorId()}] {amount}");
            }
        }


        public override string ToString()
        {
            return $"[{Name} -> {Bitcoins} Bitcoins]";
        }
    }


    // ================================================================
    // Multithreading Wallet
    // ================================================================

    class MultithreadingWallet
    {
        public MultithreadingWallet(string name, int bitcoins)
        {
            Name = name;
            Bitcoins = bitcoins;
        }

        public string Name { get; private set; }
        public int Bitcoins { get; private set; }


        // Removes bitcoins from the wallet.
        public void Debit(int amount)
        {
            // Simulates a time-consuming operation.
            Thread.Sleep(1000);

            Bitcoins -= amount;

            Console.WriteLine(
                $"[Thread: {Thread.CurrentThread.ManagedThreadId}" +
                $"-{Thread.CurrentThread.Name} " +
                $", Processor Id: {Thread.GetCurrentProcessorId()}] -{amount}");
        }


        // Adds bitcoins to the wallet.
        public void Credit(int amount)
        {
            // Simulates a time-consuming operation.
            Thread.Sleep(1000);

            Bitcoins += amount;

            Console.WriteLine(
                $"[Thread: {Thread.CurrentThread.ManagedThreadId}" +
                $"-{Thread.CurrentThread.Name} " +
                $", Processor Id: {Thread.GetCurrentProcessorId()}] +{amount}");
        }


        // Executes transactions from the thread that calls this method.
        public void RunRandomTransactions()
        {
            int[] amounts =
            {
                10, 20, 30, -20, 10,
                -10, 30, -10, 40, -20
            }; // 80

            foreach (var amount in amounts)
            {
                var absValue = Math.Abs(amount);

                // Negative amount means debit.
                if (amount < 0)
                    Debit(absValue);

                // Positive amount means credit.
                else
                    Credit(absValue);
            }
        }


        public override string ToString()
        {
            return $"[{Name} -> {Bitcoins} Bitcoins]";
        }
    }
}