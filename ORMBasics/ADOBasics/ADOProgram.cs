using System.Data;
using Microsoft.Data.SqlClient;

// ADO.NET (ActiveX Data Objects .NET) is a data access technology in .NET
// used to connect applications to databases and perform operations such as:
// SELECT, INSERT, UPDATE, DELETE, and executing stored procedures.
//
// ADO.NET is NOT an ORM (Object-Relational Mapper).
// It works directly with the database using SQL queries and database-specific
// objects, giving developers more control over database operations.
//
// Common ADO.NET classes:
// - SqlConnection  -> Establishes a connection to SQL Server.
// - SqlCommand     -> Executes SQL queries and stored procedures.
// - SqlDataReader  -> Reads query results row by row.
// - SqlDataAdapter -> Retrieves data and fills DataTables/DataSets.
// - SqlParameter   -> Adds parameters to SQL commands and helps prevent SQL Injection.
//
// ORM example: Entity Framework Core.
// ORM tools map database tables to C# objects and allow developers to work
// with the database using objects instead of writing SQL for every operation.

namespace ORMBasics.ADOBasics
{
    public static class ADOProgram
    {
        //Load Connection String
        static readonly string connectionString = ConnectionString.LoadConnectionString();

        public static void Run()
        {
            //ReadData();
            //WriteDataWithoutRetreiving();
            //WriteDataWithRetreiving();
            //UsingStoredProcedure();
            //UpdateWallet();
            //DeleteWallet();
            ReadDataWithAdaptor();
            //ExecuteTransaction();
        }
        public static void ReadData()
        {
            // we use Microsoft.Data.SqlClient package to connect to SQL Server
            var sqlConnection = new SqlConnection(connectionString);
            const string sqlText = "select * from Wallets";
            var sqlCommand = new SqlCommand(sqlText, sqlConnection)
            {
                CommandType = CommandType.Text
            };
            sqlConnection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            if (sqlDataReader.HasRows)
            {
                Wallet wallet;
                while (sqlDataReader.Read())
                {
                    wallet = new Wallet
                    {
                        Id = Convert.ToInt32(sqlDataReader[0]),
                        Holder = sqlDataReader.GetString("Holder"),
                        Balance = Convert.ToDecimal(sqlDataReader[2])
                    };
                    Console.WriteLine(wallet);
                }
            }
            sqlDataReader.Close();
            sqlConnection.Close();

        }
        public static void WriteDataWithoutRetreiving()
        {
            // we use Microsoft.Data.SqlClient package to connect to SQL Server
            var sqlConnection = new SqlConnection(connectionString);
            var wallet = new Wallet
            {
                Holder = "noha",
                Balance = 20043
            };
            var paramter1 = new SqlParameter(parameterName: "@Holder", value: wallet.Holder)
            {
                Direction = ParameterDirection.Input,
                SqlDbType = SqlDbType.VarChar,
            };
            var paramter2 = new SqlParameter(parameterName: "@Balance", value: wallet.Balance)
            {
                Direction = ParameterDirection.Input,
                SqlDbType = SqlDbType.Decimal,
            };
            const string sqlText = "insert into Wallets (Holder,Balance) Values(@Holder,@Balance)";
            var sqlCommand = new SqlCommand(sqlText, sqlConnection)
            {
                CommandType = CommandType.Text,
            };
            sqlCommand.Parameters.Add(paramter1);
            sqlCommand.Parameters.Add(paramter2);
            sqlConnection.Open();
            // to execute a write data command without retreiving 
            // to write the data without geting the id of the new row 
            // we use ExecuteNonQuery that return the number of rows affected
            int numberofRowsAffected = sqlCommand.ExecuteNonQuery();
            Console.WriteLine($"number of rows affected : {numberofRowsAffected}");
            sqlConnection.Close();
            ReadData();

        }
        public static void WriteDataWithRetreiving()
        {
            // we use Microsoft.Data.SqlClient package to connect to SQL Server
            var sqlConnection = new SqlConnection(connectionString);
            var wallet = new Wallet
            {
                Holder = "Fathy",
                Balance = 567
            };
            var paramter1 = new SqlParameter(parameterName: "@Holder", value: wallet.Holder)
            {
                Direction = ParameterDirection.Input,
                SqlDbType = SqlDbType.VarChar,
            };
            var paramter2 = new SqlParameter(parameterName: "@Balance", value: wallet.Balance)
            {
                Direction = ParameterDirection.Input,
                SqlDbType = SqlDbType.Decimal,
            };
            // when we want to write the data and get the id of the new row 
            // we use ExecuteScalar
            // and the sql must return the id of the new row 
            // we use SCOPE_IDENTITY() to get the id of the new row
            // and CAST(scope_identity() AS int) to convert the id to int
            const string sql = "INSERT INTO WALLETS (Holder, Balance) VALUES " +
                "(@Holder, @Balance);" +
                "SELECT CAST(scope_identity() AS int)";
            // we can use OUTPUT INSERTED.ID instead of SELECT CAST(scope_identity() AS int)
            // const string sql = "INSERT INTO WALLETS (Holder, Balance) OUTPUT INSERTED.ID VALUES " +
            //     "(@Holder, @Balance)";

            var sqlCommand = new SqlCommand(sql, sqlConnection)
            {
                CommandType = CommandType.Text,
            };
            sqlCommand.Parameters.Add(paramter1);
            sqlCommand.Parameters.Add(paramter2);
            sqlConnection.Open();

            var id = sqlCommand.ExecuteScalar();
            wallet.Id = Convert.ToInt32(id);
            Console.WriteLine("new wallet : " + wallet);
            sqlConnection.Close();
            ReadData();
        }
        public static void UsingStoredProcedure()
        {
            // we use Microsoft.Data.SqlClient package to connect to SQL Server
            var sqlConnection = new SqlConnection(connectionString);
            var wallet = new Wallet
            {
                Holder = "mahdy",
                Balance = 231
            };
            var paramter1 = new SqlParameter(parameterName: "@Holder", value: wallet.Holder)
            {
                Direction = ParameterDirection.Input,
                SqlDbType = SqlDbType.VarChar,
            };
            var paramter2 = new SqlParameter(parameterName: "@Balance", value: wallet.Balance)
            {
                Direction = ParameterDirection.Input,
                SqlDbType = SqlDbType.Decimal,
            };
            // to execute a stored procedure
            // use CommandType.StoredProcedure and the name of the stored procedure
            var sqlCommand = new SqlCommand("AddWallet", sqlConnection)
            {
                CommandType = CommandType.StoredProcedure,
            };
            sqlCommand.Parameters.Add(paramter1);
            sqlCommand.Parameters.Add(paramter2);
            sqlConnection.Open();

            int numberofRowsAffected = sqlCommand.ExecuteNonQuery();
            Console.WriteLine($"number of rows affected : {numberofRowsAffected}");
            sqlConnection.Close();
            ReadData();
        }
        public static void UpdateWallet()
        {
            // we use Microsoft.Data.SqlClient package to connect to SQL Server
            var sqlConnection = new SqlConnection(connectionString);

            var paramter1 = new SqlParameter(parameterName: "@Holder", value: "Mahmoud")
            {
                Direction = ParameterDirection.Input,
                SqlDbType = SqlDbType.VarChar,
            };
            var paramter2 = new SqlParameter(parameterName: "@Balance", value: 3405)
            {
                Direction = ParameterDirection.Input,
                SqlDbType = SqlDbType.Decimal,
            };
            var paramter3 = new SqlParameter(parameterName: "@Id", value: 1)
            {
                Direction = ParameterDirection.Input,
                SqlDbType = SqlDbType.Int,
            };
            const string sqlText = "update Wallets set   Holder = @Holder, Balance = @Balance where Id = @Id";
            var sqlCommand = new SqlCommand(sqlText, sqlConnection)
            {
                CommandType = CommandType.Text,
            };
            sqlCommand.Parameters.Add(paramter1);
            sqlCommand.Parameters.Add(paramter2);
            sqlCommand.Parameters.Add(paramter3);
            sqlConnection.Open();
            int numberofRowsAffected = sqlCommand.ExecuteNonQuery();
            Console.WriteLine($"number of rows affected : {numberofRowsAffected}");
            sqlConnection.Close();
            ReadData();

        }
        public static void DeleteWallet()
        {
            // we use Microsoft.Data.SqlClient package to connect to SQL Server
            var sqlConnection = new SqlConnection(connectionString);

            var paramter1 = new SqlParameter(parameterName: "@Id", value: 5)
            {
                Direction = ParameterDirection.Input,
                SqlDbType = SqlDbType.Int,
            };
            const string sqlText = "delete from Wallets where Id = @Id";
            var sqlCommand = new SqlCommand(sqlText, sqlConnection)
            {
                CommandType = CommandType.Text,
            };
            sqlCommand.Parameters.Add(paramter1);
            sqlConnection.Open();
            int numberofRowsAffected = sqlCommand.ExecuteNonQuery();
            Console.WriteLine($"number of rows affected : {numberofRowsAffected}");
            sqlConnection.Close();
            ReadData();

        }
        public static void ReadDataWithAdaptor()
        {
            var sqlConnection = new SqlConnection(connectionString);
            const string sqlText = "select * from Wallets";
            sqlConnection.Open();
            var adapter = new SqlDataAdapter(sqlText, sqlConnection);
            // SqlCommandBuilder automatically generates INSERT, UPDATE, and DELETE commands.
            var commandBuilder = new SqlCommandBuilder(adapter);
            adapter.UpdateCommand = commandBuilder.GetUpdateCommand();
            adapter.DeleteCommand = commandBuilder.GetDeleteCommand();
            adapter.InsertCommand = commandBuilder.GetInsertCommand();
            Console.WriteLine(adapter.UpdateCommand.CommandText);
            var dataTable = new DataTable();
            adapter.Fill(dataTable);
            sqlConnection.Close();
            Wallet wallet;
            //here we can retreive data from the data table after the connection is closed
            // this is called offline data retreival
            // this is different from the sql data reader which is called online data retreival
            foreach (DataRow row in dataTable.Rows)
            {
                wallet = new Wallet
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Holder = Convert.ToString(row["Holder"]),
                    Balance = Convert.ToDecimal(row["Balance"])
                };
                Console.WriteLine(wallet);
            }
            //we can use adapter.Update(dataTable);
            // this will update the database with the changes in the data table
            // modify wallet in the 4th row 
            dataTable.Rows[3]["Balance"] = 2343434;
            adapter.Update(dataTable);
            //we can delete rows from the data table
            dataTable.Rows[5].Delete();
            adapter.Update(dataTable);
            //we can add rows to the data table
            DataRow newRow = dataTable.NewRow();
            newRow["Holder"] = "Mahmoud";
            newRow["Balance"] = 2343434;
            dataTable.Rows.Add(newRow);
            adapter.Update(dataTable);
            ReadData();
        }
        public static void ExecuteTransaction()
        {
            var sqlConnection = new SqlConnection(connectionString);

            SqlCommand command = sqlConnection.CreateCommand();

            command.CommandType = CommandType.Text;

            sqlConnection.Open();

            SqlTransaction transaction = sqlConnection.BeginTransaction();

            command.Transaction = transaction;

            try
            {
                command.CommandText = "UPDATE Wallets Set Balance = Balance - 10000 Where Id = 1";
                command.ExecuteNonQuery();


                command.CommandText = "UPDATE Wallets Set Balance = Balance + 1000 Where Id = 2";
                command.ExecuteNonQuery();

                transaction.Commit();

                Console.WriteLine("Transaction of transfer completed successfully");

            }
            catch
            {
                try
                {
                    transaction.Rollback();
                }
                catch
                {
                    // log errors
                }
            }
            finally
            {

                try
                {
                    sqlConnection.Close();
                }
                catch
                {
                    // log errors

                }
            }
        }
    }
}