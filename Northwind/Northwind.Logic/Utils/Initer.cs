using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace Northwind.Logic.Utils
{
    public static class Initer
    {
        public static void Init()
        {
            // Connection String Syntax
            // https://docs.microsoft.com/en-us/dotnet/framework/data/adonet/connection-string-syntax
            //
            // SqlConnection.ConnectionString Property 
            // https://msdn.microsoft.com/en-us/library/system.data.sqlclient.sqlconnection.connectionstring(v=vs.110).aspx
            //
            // Starting LocalDB and Connecting to LocalDB
            // https://docs.microsoft.com/en-us/sql/database-engine/configure-windows/sql-server-2016-express-localdb?view=sql-server-2017#starting-localdb-and-connecting-to-localdb
            SessionFactory.Init(ReadConnectionStringFrom("connectionString.json"));
        }

        /// <summary>
        /// Read a connection string from a file.
        /// </summary>
        /// <param name="fileName">file name of json format</param>
        /// <returns>connection string</returns>
        private static string ReadConnectionStringFrom(string fileName)
        {
            var connectionString = string.Empty;
            if (File.Exists(fileName))
            {
                string json = File.ReadAllText(fileName);

                // Newtonsoft.Json
                // https://www.nuget.org/packages/Newtonsoft.Json/
                // Install-Package -Id Newtonsoft.Json -ProjectName Northwind.Logic
                // Install-Package -Id Newtonsoft.Json -ProjectName Northwind.UI
                //
                // How can I deserialize JSON to a simple Dictionary<string,string> in ASP.NET?
                // https://stackoverflow.com/questions/1207731/how-can-i-deserialize-json-to-a-simple-dictionarystring-string-in-asp-net
                var dic = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
                connectionString = dic["connectionString"];
            }
            return connectionString;
        }
    }
}
