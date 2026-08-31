using ORMBasics.ADOBasics;
using ORMBasics.DapperORM;
using ORMBasics.NHibernate;
namespace ORMBasics
{
    public static class Program
    {
        public static void Main()
        {
            ConnectionString.LoadConnectionString();
            ADOProgram.Run();
            DapperProgram.Run();
            NHibernateProgram.Run();
        }
    }
}