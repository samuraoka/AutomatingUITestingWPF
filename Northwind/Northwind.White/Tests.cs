using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
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

        [TestMethod]
        public void PerformanceTest()
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            var application = Application.Launch(@"..\..\..\Northwind.UI\bin\Debug\Northwind.UI.exe");
            var window = application.GetWindow("Northwind");
            var listBox = window.Get<ListBox>();
            listBox.Item("Departments").Select();
            window.Get<Button>(SearchCriteria.ByText("Add")).Click();

            var newDeptWin = Retry.For(() => application.GetWindows().First(w => w.Title.Contains("New department")), TimeSpan.FromSeconds(30));
            newDeptWin.Get<TextBox>().Text = "Test Department";
            newDeptWin.Get<Button>(SearchCriteria.ByText("OK")).Click();

            listBox.Item("Projects").Select();
            window.Get<Button>(SearchCriteria.ByText("Add")).Click();
            var newProjWin = Retry.For(() => application.GetWindows().First(w => w.Title.Contains("New project")), TimeSpan.FromSeconds(30));
            newProjWin.Get<TextBox>(SearchCriteria.Indexed(0)).Text = "Internal project";
            newProjWin.Get<TextBox>(SearchCriteria.Indexed(1)).Text = "1000000";
            newProjWin.Get<Button>(SearchCriteria.ByText("OK")).Click();

            listBox.Item("Employees").Select();
            window.Get<Button>(SearchCriteria.ByText("Add")).Click();
            var newEmpWIn = Retry.For(() => application.GetWindows().First(w => w.Title.Contains("New employee")), TimeSpan.FromSeconds(30));
            newEmpWIn.Get<TextBox>(SearchCriteria.Indexed(0)).Text = "Vladimir";
            newEmpWIn.Get<TextBox>(SearchCriteria.Indexed(1)).Text = "Khorikov";
            newEmpWIn.Get<TextBox>(SearchCriteria.Indexed(2)).Text = "I'm a software developer";
            newEmpWIn.Get<Button>(SearchCriteria.ByText("Change")).Click();
            var changeDeptWin = Retry.For(() => application.GetWindows().First(x => x.Title.Contains("Change department")), TimeSpan.FromSeconds(30));
            changeDeptWin.Get<ListBox>().Item("Test Department").Select();
            changeDeptWin.Get<Button>(SearchCriteria.ByText("OK")).Click();
            newEmpWIn.Get<Button>(SearchCriteria.ByText("OK")).Click();

            var empWin = Retry.For(() => application.GetWindows().First(x => x.Title.Contains("Employee:")), TimeSpan.FromSeconds(30));
            empWin.Get<ListBox>().Select("Projects");
            empWin.Get<Button>(SearchCriteria.ByText("Add")).Click();
            var newProjForEmpWin = Retry.For(() => application.GetWindows().First(x => x.Title.Contains("New project for employee:")), TimeSpan.FromSeconds(30));
            newProjForEmpWin.Get<ListBox>().Select("Internal project");
            newProjForEmpWin.Get<ComboBox>().Select("Developer");
            newProjForEmpWin.Get<CheckBox>().Checked = true;
            newProjForEmpWin.Get<Button>(SearchCriteria.ByText("OK")).Click();
            empWin.Get<Button>(SearchCriteria.ByText("OK")).Click();

            window.Close();

            stopwatch.Stop();
            Console.WriteLine($"Time elapsed: {stopwatch.ElapsedMilliseconds} ms");
        }
    }
}
