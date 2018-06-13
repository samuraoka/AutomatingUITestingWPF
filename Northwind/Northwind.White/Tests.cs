using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using TestStack.White;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.ListBoxItems;
using TestStack.White.Utility;

namespace Northwind.White
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void GettingStarted()
        {
            // TestStack.White 0.13.3
            // https://www.nuget.org/packages/TestStack.White/
            // Install-Package TestStack.White -Version 0.13.3 Northwind.White
            var application = Application.Launch(@"..\..\..\Northwind.UI\bin\Debug\Northwind.UI.exe");
            var main = application.GetWindow("Northwind");
            var mainMenu = main.Get<ListBox>();
            mainMenu.Item("Employees").Select();
            main.Get<Button>(SearchCriteria.ByText("Add")).Click();

            var newEmployee = Retry.For(
                () => application.GetWindows().First(x => x.Title.Contains("New employee")),
                TimeSpan.FromSeconds(5));
            newEmployee.Get<TextBox>(SearchCriteria.Indexed(0)).Text = "Vladimir";
            newEmployee.Get<TextBox>(SearchCriteria.Indexed(1)).Text = "Khorikov";
            newEmployee.Get<TextBox>(SearchCriteria.Indexed(2)).Text = "I'm a software developer";
            newEmployee.Get<Button>(SearchCriteria.ByText("Change")).Click();

            var department = Retry.For(
                () => application.GetWindows().First(x => x.Title.Contains("Change department")),
                TimeSpan.FromSeconds(5));
            department.Get<ListBox>().Item("Test department").Select();
            department.Get<Button>(SearchCriteria.ByText("OK")).Click();

            newEmployee.Get<Button>(SearchCriteria.ByText("OK")).Click();

            var employee = Retry.For(
                () => application.GetWindows().First(x => x.Title.Contains("Employee")),
                TimeSpan.FromSeconds(5));
            employee.Get<Button>(SearchCriteria.ByText("OK")).Click();

            var listView = main.Get<ListView>();
            listView.Cell("First Name", listView.Rows.Count - 1).Click();
            main.Get<Button>(SearchCriteria.ByText("Edit")).Click();

            var editEmployee = Retry.For(
                () => application.GetWindows().First(x => x.Title.Contains("Employee")),
                TimeSpan.FromSeconds(5));
            var expected = editEmployee.Get<TextBox>(SearchCriteria.Indexed(0)).Text;
            editEmployee.Close();
            main.Close();

            Assert.AreEqual("Vladimir2", expected);
        }
    }
}
