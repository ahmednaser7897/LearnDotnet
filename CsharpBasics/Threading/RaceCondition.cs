/*
 * ================================================================
 * RACE CONDITION
 * ================================================================
 *
 * A race condition happens when multiple threads access shared data
 * at the same time and the final result depends on the timing/order
 * of their execution.
 *
 * Example:
 * - Wallet starts with 50 Bitcoins.
 * - Thread 1 tries to debit 40.
 * - Thread 2 tries to debit 30.
 *
 * Without synchronization, both threads could read Bitcoins = 50
 * before either thread updates it.
 *
 * This can produce an incorrect result because both threads are
 * making decisions based on the same old value.
 *
 * ---------------------------------------------------------------
 * LOCK
 * ---------------------------------------------------------------
 *
 * The lock statement provides mutual exclusion.
 *
 * Only ONE thread can enter the locked block at a time.
 *
 * Example:
 *
 *     lock (bitcoinsLock)
 *     {
 *         // Only one thread can execute this code at a time.
 *     }
 *
 * Other threads trying to enter the same lock must wait until
 * the current thread leaves the block.
 *
 * ---------------------------------------------------------------
 * CRITICAL SECTION
 * ---------------------------------------------------------------
 *
 * A critical section is a section of code that accesses shared
 * data and must not be executed by multiple threads simultaneously.
 *
 * Here, the critical section is:
 *
 *     if (Bitcoins >= amount)
 *     {
 *         Thread.Sleep(1000);
 *         Bitcoins -= amount;
 *     }
 *
 * Both the check and the update must be protected by the same lock.
 *
 * ---------------------------------------------------------------
 * WHY THE LOCK OBJECT IS PRIVATE AND READONLY
 * ---------------------------------------------------------------
 *
 *     private readonly object bitcoinsLock = new object();
 *
 * The object is used only for synchronization.
 *
 * It should not be publicly accessible because external code could
 * lock the same object and cause unexpected blocking or deadlocks.
 *
 * readonly ensures that the lock reference cannot be replaced.
 *
 * ---------------------------------------------------------------
 * JOIN
 * ---------------------------------------------------------------
 *
 *     t1.Join();
 *
 * Join makes the current thread wait until t1 finishes.
 *
 * We use Join here so that the main thread does not print the wallet
 * before both transactions finish.
 *
 * ---------------------------------------------------------------
 * IMPORTANT
 * ---------------------------------------------------------------
 *
 * Lock protects the Debit operation, but Credit is not protected.
 *
 * If Credit and Debit can run concurrently in a real application,
 * both operations should use the same synchronization mechanism
 * when they access the same shared state.
 *
 * Other synchronization tools include:
 * - Monitor
 * - Mutex
 * - Semaphore / SemaphoreSlim
 * - Interlocked
 * - Concurrent collections
 *
 * ================================================================
 */

namespace CsharpFundamentals.Threading
{
    class RaceCondition
    {
        public static void Run()
        {
            Console.WriteLine("================== Race Condition ==================");

            var wallet = new Wallet("Issam", 50);

            // Sequential execution:
            // The first debit finishes before the second one starts.
            //
            //wallet.Debit(40);
            //wallet.Debit(30); // 10


            // Create two threads that access the same Wallet object.
            var t1 = new Thread(() => wallet.Debit(40));
            var t2 = new Thread(() => wallet.Debit(30));


            // Start both threads.
            t1.Start();
            t2.Start();


            // Wait for both threads to finish before continuing.
            t1.Join();
            t2.Join();


            // Print the final wallet balance.
            Console.WriteLine(wallet);

            Console.WriteLine("====================================\n\n\n");
        }


        // ============================================================
        // Wallet
        // ============================================================

        class Wallet
        {
            // Object used as a lock for protecting shared wallet data.
            private readonly object bitcoinsLock = new object();


            public Wallet(string name, int bitcoins)
            {
                Name = name;
                Bitcoins = bitcoins;
            }


            public string Name { get; private set; }

            // Shared data accessed by multiple threads.
            public int Bitcoins { get; private set; }


            // Removes bitcoins from the wallet.
            public void Debit(int amount)
            {
                // Only one thread can execute this block at a time.
                lock (bitcoinsLock)
                {
                    // Check and update are protected together.
                    if (Bitcoins >= amount)
                    {
                        // Simulates a time-consuming operation.
                        // This makes the concurrency behavior easier to see.
                        Thread.Sleep(1000);

                        Bitcoins -= amount;
                    }
                }
            }


            // Adds bitcoins to the wallet.
            public void Credit(int amount)
            {
                // Simulates a time-consuming operation.
                Thread.Sleep(1000);

                // NOTE:
                // This operation is not protected by the lock.
                Bitcoins += amount;
            }


            public override string ToString()
            {
                return $"[{Name} -> {Bitcoins} Bitcoins]";
            }
        }
    }
}