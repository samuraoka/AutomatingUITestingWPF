using Northwind.UI.Dashboard;
using Northwind.UI.Departments;
using Northwind.UI.Employees;
using Northwind.UI.Projects;
using System.Collections.Generic;

namespace Northwind.UI.Common
{
    public class MainViewModel
    {
        public List<ViewModel> Items { get; private set; }

        public MainViewModel()
        {
            Items = new List<ViewModel>
            {
                new DashboardViewModel(),
                new DepartmentListViewModel(),
                new EmployeeListViewModel(),
                new ProjectListViewModel(),
            };
        }
    }
}
