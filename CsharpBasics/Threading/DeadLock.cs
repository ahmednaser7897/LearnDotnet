/*
 * ================================================================
 * DEADLOCK
 * ================================================================
 *
 * A deadlock happens when two or more threads are waiting for
 * resources locked by each other, so none of them can continue.
 *
 * Example:
 *
 * Thread T1:
 *   1. Locks Wallet 1
 *   2. Tries to lock Wallet 2
 *
 * Thread T2:
 *   1. Locks Wallet 2
 *   2. Tries to lock Wallet 1
 *
 * Result:
 *
 *   T1 waits for T2
 *   T2 waits for T1
 *
 * Neither thread can continue -> DEADLOCK.
 *
 * ---------------------------------------------------------------
 * HOW TO PREVENT DEADLOCK
 * ---------------------------------------------------------------
 *
 * There are different ways to prevent or handle deadlocks.
 *
 * 1. Consistent Lock Ordering
 *
 * Always acquire multiple locks in the same order.
 *
 * In this example, we use the Wallet Id to determine the order:
 *
 *     Wallet 1 -> Wallet 2
 *
 * Even if the transaction is:
 *
 *     Wallet 2 -> Wallet 1
 *
 * the locks are still acquired as:
 *
 *     Wallet 1 -> Wallet 2
 *
 * This prevents circular waiting.
 *
 * 2. Monitor
 *
 * The lock statement is actually based on the Monitor class.
 *
 * This:
 *
 *     lock (obj)
 *     {
 *         // code
 *     }
 *
 * is conceptually similar to:
 *
 *     Monitor.Enter(obj);
 *     try
 *     {
 *         // code
 *     }
 *     finally
 *     {
 *         Monitor.Exit(obj);
 *     }
 *
 * Monitor also provides TryEnter(), which can be useful when we
 * don't want a thread to wait forever for a lock.
 *
 * ---------------------------------------------------------------
 * DEADLOCK CONDITIONS
 * ---------------------------------------------------------------
 *
 * A deadlock generally requires four conditions:
 *
 * 1. Mutual Exclusion
 *    Only one thread can own a resource at a time.
 *
 * 2. Hold and Wait
 *    A thread holds one resource while waiting for another.
 *
 * 3. No Preemption
 *    A resource cannot be forcibly taken from a thread.
 *
 * 4. Circular Wait
 *    Thread A waits for B, while B waits for A.
 *
 * Breaking any one of these conditions can prevent a deadlock.
 *
 * ================================================================
 */

namespace CsharpFundamentals.Threading
{
    class DeadLock
    {
        public static void Run()
        {
            Console.WriteLine("================== Dead Lock ==================");

            // Run the solution using consistent lock ordering.
            RunWithLockOrdering();

            // Run the solution using Monitor.
            RunWithMonitor();

            Console.WriteLine("====================================\n\n\n");
        }


        // ============================================================
        // Solution 1: Consistent Lock Ordering
        // ============================================================

        private static void RunWithLockOrdering()
        {
            Console.WriteLine("\n========== Lock Ordering Solution ==========");

            // Create two wallets.
            var wallet1 = new Wallet(1, "Issam", 100);
            var wallet2 = new Wallet(2, "Reem", 50);


            Console.WriteLine("\nBefore Transaction");
            Console.WriteLine("---------------------");
            Console.Write(wallet1 + ", ");
            Console.Write(wallet2);
            Console.WriteLine();


            // Create two opposite transactions.
            var transferManager1 =
                new TransferManager(wallet1, wallet2, 50);

            var transferManager2 =
                new TransferManager(wallet2, wallet1, 30);


            // Create a thread for each transaction.
            var t1 = new Thread(transferManager1.TransferWithLockOrdering);
            t1.Name = "T1";

            var t2 = new Thread(transferManager2.TransferWithLockOrdering);
            t2.Name = "T2";


            // Start both transactions.
            t1.Start();
            t2.Start();


            // Wait for both threads to finish.
            t1.Join();
            t2.Join();


            Console.WriteLine("\nAfter Transaction");
            Console.WriteLine("---------------------");
            Console.Write(wallet1 + ", ");
            Console.Write(wallet2);
            Console.WriteLine();
        }


        // ============================================================
        // Solution 2: Monitor
        // ============================================================

        private static void RunWithMonitor()
        {
            Console.WriteLine("\n========== Monitor Solution ==========");

            // Create two wallets.
            var wallet1 = new Wallet(1, "Issam", 100);
            var wallet2 = new Wallet(2, "Reem", 50);


            Console.WriteLine("\nBefore Transaction");
            Console.WriteLine("---------------------");
            Console.Write(wallet1 + ", ");
            Console.Write(wallet2);
            Console.WriteLine();


            // Create two opposite transactions.
            var transferManager1 =
                new TransferManager(wallet1, wallet2, 50);

            var transferManager2 =
                new TransferManager(wallet2, wallet1, 30);


            // Create a thread for each transaction.
            var t1 = new Thread(transferManager1.TransferWithMonitor);
            t1.Name = "T1";

            var t2 = new Thread(transferManager2.TransferWithMonitor);
            t2.Name = "T2";


            // Start both transactions.
            t1.Start();
            t2.Start();


            // Wait for both threads to finish.
            t1.Join();
            t2.Join();


            Console.WriteLine("\nAfter Transaction");
            Console.WriteLine("---------------------");
            Console.Write(wallet1 + ", ");
            Console.Write(wallet2);
            Console.WriteLine();
        }


        // ============================================================
        // Wallet
        // ============================================================

        class Wallet
        {
            // Object used to synchronize access to the wallet.
            private readonly object bitcoinsLock = new object();


            public Wallet(int id, string name, int bitcoins)
            {
                Id = id;
                Name = name;
                Bitcoins = bitcoins;
            }


            public int Id { get; private set; }

            public string Name { get; private set; }

            public int Bitcoins { get; private set; }


            // Remove bitcoins from the wallet.
            public void Debit(int amount)
            {
                lock (bitcoinsLock)
                {
                    if (Bitcoins >= amount)
                    {
                        Thread.Sleep(1000);

                        Bitcoins -= amount;
                    }
                }
            }


            // Add bitcoins to the wallet.
            public void Credit(int amount)
            {
                Thread.Sleep(1000);

                Bitcoins += amount;
            }


            public override string ToString()
            {
                return $"[{Name} -> {Bitcoins} Bitcoins]";
            }
        }


        // ============================================================
        // Transfer Manager
        // ============================================================

        class TransferManager
        {
            private Wallet from;
            private Wallet to;
            private int amountToTransfer;


            public TransferManager(
                Wallet from,
                Wallet to,
                int amountToTransfer)
            {
                this.from = from;
                this.to = to;
                this.amountToTransfer = amountToTransfer;
            }


            // ========================================================
            // Solution 1: Consistent Lock Ordering
            // ========================================================

            public void TransferWithLockOrdering()
            {
                /*
                 * Always lock the wallet with the smaller Id first.
                 *
                 * This guarantees that all threads acquire locks
                 * in the same order.
                 */
                var lock1 = from.Id < to.Id ? from : to;
                var lock2 = from.Id < to.Id ? to : from;


                Console.WriteLine(
                    $"{Thread.CurrentThread.Name} trying to lock ... {from}");


                // Acquire the first lock.
                lock (lock1)
                {
                    Console.WriteLine(
                        $"{Thread.CurrentThread.Name} lock acquired ... {from}");

                    Thread.Sleep(1000);


                    Console.WriteLine(
                        $"{Thread.CurrentThread.Name} trying to lock ... {to}");


                    // Acquire the second lock.
                    lock (lock2)
                    {
                        from.Debit(amountToTransfer);
                        to.Credit(amountToTransfer);
                    }
                }
            }


            // ========================================================
            // Solution 2: Monitor
            // ========================================================

            public void TransferWithMonitor()
            {
                /*
                 * Monitor.Enter is used to acquire a lock manually.
                 *
                 * We still use the same lock ordering strategy here.
                 * The difference is that we use Monitor instead of
                 * the lock keyword.
                 */
                var lock1 = from.Id < to.Id ? from : to;
                var lock2 = from.Id < to.Id ? to : from;


                Console.WriteLine(
                    $"{Thread.CurrentThread.Name} trying to lock ... {from}");


                // Enter the first lock.
                Monitor.Enter(lock1);

                try
                {
                    Console.WriteLine(
                        $"{Thread.CurrentThread.Name} lock acquired ... {from}");

                    Thread.Sleep(1000);


                    Console.WriteLine(
                        $"{Thread.CurrentThread.Name} trying to lock ... {to}");


                    // Enter the second lock.
                    Monitor.Enter(lock2);

                    try
                    {
                        from.Debit(amountToTransfer);
                        to.Credit(amountToTransfer);
                    }
                    finally
                    {
                        // Always release the second lock.
                        Monitor.Exit(lock2);
                    }
                }
                finally
                {
                    // Always release the first lock.
                    Monitor.Exit(lock1);
                }
            }
        }
    }
}