using Microsoft.Extensions.Configuration;

namespace ORMBasics
{
    internal static class ConnectionString
    {
        public static string LoadConnectionString()
        {
            // 1- first way save it as any key in the json file and get it by the key name
            // we use package Microsoft.Extensions.Configuration
            // to load a json file from the project directory
            // and return an IConfiguration object
            var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();
            // load connectStrings object from json file
            // and display its value
            var connectionString = configuration.GetSection("connectStrings").Value;
            //Console.WriteLine("first way : " + connectionString);
            // 2- save it as ConnectionStrings->DefaultConnection in json file and get it by the DefaultConnection name
            // for this to work we need to install 
            // <PackageReference Include="Microsoft.Extensions.Configuration.Binder" Version="8.0.0" />
            var connectionString2 = configuration.GetConnectionString("DefaultConnection");
            //Console.WriteLine("second way : " + connectionString2);
            return connectionString ?? "";
        }

    }
}
