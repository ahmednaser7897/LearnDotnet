using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Transactions;

// Dapper is a lightweight Micro-ORM (Object-Relational Mapper) for .NET.
// It helps applications communicate with relational databases while still
// allowing developers to write and control their own SQL queries.
//
// Dapper maps the results of SQL queries to C# objects automatically.
//
// Unlike Entity Framework Core, Dapper does NOT generate most SQL queries
// for you. You usually write the SQL yourself and let Dapper execute it
// and map the results to your C# objects.
//
// Example:
//
// var employees = connection.Query<Employee>(
//     "SELECT * FROM Employees"
// );
//
// Dapper provides methods such as:
// - Query<T>()       -> Retrieves multiple records.
// - QueryFirst<T>()  -> Retrieves the first record.
// - QuerySingle<T>() -> Retrieves exactly one record.
// - Execute()        -> Executes INSERT, UPDATE, or DELETE commands.
//
// Dapper is called a Micro-ORM because it provides object mapping
// without the large set of features provided by full ORMs like EF Core.

namespace ORMBasics.DapperORM
{
    public static class DapperProgram
    {
        //Load Connection String
        static readonly string connectionString = ConnectionString.LoadConnectionString();
        public static void Run()
        {
            ReadData();
            //WriteDataWithoutRetreiving();
            //WriteDataWithRetreiving();
            //UsingStoredProcedure();
            //UpdateWallet();
            //DeleteWallet();
            //MultiQuerys();
            //ExecuteTransaction();
        }
        public static void ReadData()
        {
            IDbConnection db = new SqlConnection(connectionString);
            const string sqlText = "select * from Wallets";
            Console.WriteLine("---------------- using Dynamic Query -------------");
            // it returns Anonymous type
            var ruselt = db.Query(sqlText);
            foreach (var row in ruselt)
                Console.WriteLine(row);

            Console.WriteLine("---------------- using Typed Query -------------");
            // we use Genaric Query to make it map the data 
            var wallets = db.Query<Wallet>(sqlText);
            foreach (var wallet in wallets)
                Console.WriteLine(wallet);
        }
        public static void WriteDataWithoutRetreiving()
        {
            var wallet = new Wallet
            {
                Holder = "noha",
                Balance = 20043
            };
            const string sqlText = "insert into Wallets (Holder,Balance) Values(@Holder,@Balance)";
            IDbConnection db = new SqlConnection(connectionString);
            // we send Anonymous type that represant the params
            // we can use Query or Execute
            // Use Execute() when your SQL changes data and you don't need rows returned.
            // Execute() returns an int representing the number of rows affected
            // Use Query() when your SQL returns rows that you want to read
            //db.Query(sqlText, new { Holder = wallet.Holder, Balance = wallet.Balance });
            db.Execute(sqlText, new { Holder = wallet.Holder, Balance = wallet.Balance });
            ReadData();
        }
        public static void WriteDataWithRetreiving()
        {
            var wallet = new Wallet
            {
                Holder = "fawzy",
                Balance = 234
            };
            const string sqlText = "INSERT INTO WALLETS (Holder, Balance) VALUES " +
               "(@Holder, @Balance);" +
               "SELECT CAST(scope_identity() AS int)";
            IDbConnection db = new SqlConnection(connectionString);
            //Use Query() when your SQL returns rows that you want to read
            // so we will use Single() becouse its only one value in the ruselt
            wallet.Id = db.Query<int>(sqlText, new { Holder = wallet.Holder, Balance = wallet.Balance }).Single();
            Console.WriteLine("new wallet : " + wallet);
            ReadData();
        }
        public static void UsingStoredProcedure()
        {
            var wallet = new Wallet
            {
                Holder = "fhhfh",
                Balance = 7655
            };
            IDbConnection db = new SqlConnection(connectionString);

            int numberOfRowsAffected = db.Execute(
                "AddWallet", new { Holder = wallet.Holder, Balance = wallet.Balance },
                commandType: CommandType.StoredProcedure
            );
            Console.WriteLine($"number of rows affected: {numberOfRowsAffected}");
            ReadData();
        }
        public static void UpdateWallet()
        {
            var wallet = new Wallet
            {
                Id = 1,
                Holder = "memo",
                Balance = 345
            };
            var sql = "UPDATE Wallets SET Holder = @Holder , Balance = @Balance " +
                      "WHERE Id = @Id;";
            IDbConnection db = new SqlConnection(connectionString);
            wallet.Id = db.Execute(sql, new { Id = wallet.Id, Holder = wallet.Holder, Balance = wallet.Balance });
            ReadData();
        }
        public static void DeleteWallet()
        {
            const string sqlText = "delete from Wallets where Id = @Id";
            IDbConnection db = new SqlConnection(connectionString);
            int numberofRowsAffected = db.Execute(sqlText, new { Id = 4 });
            Console.WriteLine($"number of rows affected : {numberofRowsAffected}");
            ReadData();
        }
        public static void MultiQuerys()
        {
            const string sqlText = "select Min(Balance) from Wallets;"
                + "select max(Balance) from Wallets;";
            IDbConnection db = new SqlConnection(connectionString);
            var multi = db.QueryMultiple(sqlText);
            // ReadSingle get value after value from the querys
            // but the value must be only one value
            //Console.WriteLine(
            //    $"Min = {multi.ReadSingle<decimal>()}" +
            //    $"\nMax = {multi.ReadSingle<decimal>()}");

            // if its more the one use Read with First
            //Console.WriteLine(
            //  $"Min = {multi.Read<decimal>().First()}" +
            //  $"\nMax = {multi.Read<decimal>().First()}");
            // or 
            Console.WriteLine(
             $"Min = {multi.Read<decimal>().Single()}" +
             $"\nMax = {multi.Read<decimal>().Single()}");

        }
        public static void ExecuteTransaction()
        {
            IDbConnection db = new SqlConnection(connectionString);
            decimal amountToTranfer = 2000m;
            using (var transactionScope = new TransactionScope())
            {
                var walletFrom = db.QuerySingle<Wallet>
                  ("SELECT * FROM Wallets Where Id = @Id", new { Id = 2 });
                var walletTo = db.QuerySingle<Wallet>
                  ("SELECT * FROM Wallets Where Id = @Id", new { Id = 3 });
                db.Execute("UPDATE Wallets Set Balance = @Balance Where Id = @Id",
                    new
                    {
                        Id = walletFrom.Id,
                        Balance = walletFrom.Balance - amountToTranfer
                    }
                ); ;
                db.Execute("UPDATE Wallets Set Balance = @Balance Where Id = @Id",
                  new
                  {
                      Id = walletTo.Id,
                      Balance = walletTo.Balance + amountToTranfer
                  }
                );
                transactionScope.Complete();
            }
            ReadData();
        }
    }
}