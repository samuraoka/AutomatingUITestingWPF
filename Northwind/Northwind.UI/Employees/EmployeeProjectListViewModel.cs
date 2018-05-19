using Northwind.Logic.Model;
using Northwind.UI.Common;

namespace Northwind.UI.Employees
{
    public class EmployeeProjectListViewModel : ViewModel
    {
        //TODO
        private readonly Employee _employee;
        //TODO

        public override string Caption
        {
            get { return "Projects"; }
        }

        public EmployeeProjectListViewModel(Employee employee)
        {
            //TODO
            _employee = employee;
            //TODO
        }

        //TODO
    }
}
