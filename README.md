# Automating UI Tests for WPF Applications
This is a demo application for [Automating UI Tests for WPF Applications](https://app.pluralsight.com/library/courses/wpf-applications-automating-ui-tests/table-of-contents) by [Vladimir Khorikov](https://app.pluralsight.com/profile/author/vladimir-khorikov) on Pluralsight.  

* [WPF](https://docs.microsoft.com/en-us/dotnet/framework/wpf/)
* [MS SQL Server LocalDB](https://docs.microsoft.com/en-us/sql/database-engine/configure-windows/sql-server-2016-express-localdb?view=sql-server-2017)
* [NHibernate 5.1.3](https://www.nuget.org/packages/NHibernate/)
* [FluentNHibernate 2.1.2](https://www.nuget.org/packages/FluentNHibernate/)
* [Xunit 2.3.1](https://www.nuget.org/packages/xunit/2.3.1)
* [TestStack.White 0.13.3](https://www.nuget.org/packages/TestStack.White/)

## To run the project:
1. Create a Northwind database using the SqlScript.sql in the solution root folder.
2. Create a json file named "connectionString.json" at root of the Northwind.UI project.
And set "Copy to Output Directory" property of the connectionsString.json file to "Copy if newer".
3. Write a connection string to the connectionString.json file like below
```
{
  "connectionString": "Server=(localdb)\\MSSQLLocalDB;Database=Northwind;Integrated Security=true;"
}
```
