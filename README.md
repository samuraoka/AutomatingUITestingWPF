# Automating UI Tests for WPF Applications
This is a demo application for the Automating UI Tests for WPF Applications by Vladimir Khorikov on Pluralsight.  
https://app.pluralsight.com/library/courses/wpf-applications-automating-ui-tests/table-of-contents

* WPF
* MS SQL LocalDB
* NHibernate
* FluentNHibernate

## To run the project:
1. Create a Northwind database using the SqlScript.sql
2. Change the connection string in Northwind\Northwind.Logic\Utils\Initer.cs
3. Create a json file named "connectionString.json" at root of Northwind.UI. And set "Copy to Output Directory" property to "Copy if newer".
4. write a connection string to the connectionString.json file like below
```
{
  "connectionString": "Server=(localdb)\\MSSQLLocalDB;Database=Northwind;Integrated Security=true;"
}
```
