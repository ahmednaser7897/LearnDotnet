// NHibernate is a full-featured ORM (Object-Relational Mapper) for .NET.
// It allows applications to work with relational databases using C# objects
// instead of directly working with database tables and rows.
//
// NHibernate maps:
// - Database tables  -> C# classes
// - Table columns    -> C# properties
// - Database rows    -> C# objects
//
// NHibernate can handle common database operations such as:
// - INSERT -> Save/Add entities.
// - SELECT -> Query entities.
// - UPDATE -> Modify entities.
// - DELETE -> Delete entities.
//
// Unlike Dapper, NHibernate is a full ORM and provides many features such as:
// - Change tracking.
// - Relationships between entities.
// - Lazy loading.
// - Transactions.
// - Caching.
// - Automatic SQL generation.
//
// NHibernate can generate SQL queries based on the operations performed
// on C# objects, so developers do not always need to write SQL manually.
//
// Example:
//
// var employees = session.Query<Employee>().ToList();
//
// NHibernate is a full ORM, while Dapper is a lightweight Micro-ORM.

namespace ORMBasics.NHibernate
{
    public static class NHibernateProgram
    {
        public static void Run()
        {
            //TestSession();
            ReadData();
            //InsertData();
            //UpdateData();
            //DeleteData();
            //ExecuteTransaction();
        }

        public static void TestSession()
        {
            // Create a new NHibernate session.
            using (var session = Sessioncreator.CreateSession<NWallet>())
            {
                // Check whether the session is connected.
                Console.WriteLine(session.IsConnected);
            }
        }

        public static void ReadData()
        {
            // Create a new NHibernate session.
            using var session = Sessioncreator.CreateSession<NWallet>();

            // Begin a database transaction.
            using var transaction = session.BeginTransaction();

            // Read all wallets.
            var wallets = session.Query<NWallet>().ToList();

            foreach (var item in wallets)
                Console.WriteLine(item);

            // Read one wallet by its ID.
            var wallet = session.Query<NWallet>().Single(w => w.Id == 10);

            //var wallet = session.Get<NWallet>(id);

            // Display the wallet.
            Console.WriteLine($"wallet with id 10 => {wallet}");
        }

        public static void InsertData()
        {
            // Create a new NHibernate session.
            using var session = Sessioncreator.CreateSession<NWallet>();

            // Begin a database transaction.
            using var transaction = session.BeginTransaction();

            // Create a new wallet.
            var wallet = new NWallet
            {
                Holder = "name",
                Balance = 243
            };

            // Save the new wallet.
            session.Save(wallet);

            // Commit the transaction.
            transaction.Commit();

            // Display the new wallet.
            Console.WriteLine($"new wallet => {wallet}");

            // Read the wallet data.
            ReadData();
        }

        public static void UpdateData()
        {
            // Create a new NHibernate session.
            using var session = Sessioncreator.CreateSession<NWallet>();

            // Begin a database transaction.
            using var transaction = session.BeginTransaction();

            int id = 10;

            // Get the wallet by its ID.
            var wallet = session.Get<NWallet>(id);

            // Update the wallet balance.
            wallet.Balance = 500;

            // Update the wallet in the database.
            session.Update(wallet);

            // Commit the transaction.
            transaction.Commit();

            // Display the updated wallet.
            Console.WriteLine($"new wallet => {wallet}");
        }

        public static void DeleteData()
        {
            // Create a new NHibernate session.
            using var session = Sessioncreator.CreateSession<NWallet>();

            // Begin a database transaction.
            using var transaction = session.BeginTransaction();

            int id = 15;

            // Get the wallet by its ID.
            var wallet = session.Get<NWallet>(id);

            // Delete the wallet.
            session.Delete(wallet);

            // Commit the transaction.
            transaction.Commit();

            // Display the deletion message.
            Console.WriteLine($"wallet deleted");
        }

        public static void ExecuteTransaction()
        {
            // Create a new NHibernate session.
            using var session = Sessioncreator.CreateSession<NWallet>();

            // Begin a database transaction.
            using var transaction = session.BeginTransaction();

            var idFrom = 2;
            var idTo = 1;
            var amountToTransfer = 1000;

            // Get the source wallet.
            var walletFrom = session.Get<NWallet>(idFrom);

            // Get the destination wallet.
            var walletTo = session.Get<NWallet>(idTo);

            // Subtract the amount from the source wallet.
            walletFrom.Balance -= amountToTransfer;

            // Add the amount to the destination wallet.
            walletTo.Balance += amountToTransfer;

            // Update the source wallet.
            session.Update(walletFrom);

            // Update the destination wallet.
            session.Update(walletTo);

            // Commit both changes as one transaction.
            transaction.Commit();
        }
    }
}
