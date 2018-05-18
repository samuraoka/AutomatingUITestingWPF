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
            SessionFactory.Init(@"Server=(localdb)\MSSQLLocalDB;Integrated Security=true");
        }
    }
}
