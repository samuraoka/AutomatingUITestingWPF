using Northwind.Logic.Model;
using Northwind.UI.Common;

namespace Northwind.UI.Employees
{
    public class EmployeeMainPropertiesViewModel : ViewModel
    {
        private readonly Employee _employee;
        //TODO

        public string FirstName
        {
            get { return _employee.FirstName; }
            set { _employee.FirstName = value; }
        }

        public string LastName
        {
            get { return _employee.LastName; }
            set { _employee.LastName = value; }
        }

        //TODO

        public string DepartmentName
        {
            get
            {
                return _employee.Department == null
                  ? string.Empty : _employee.Department.Name;
            }
        }

        public override string Caption
        {
            get { return "Main properties"; }
        }

        public EmployeeMainPropertiesViewModel(Employee employee)
        {
            //TODO
            _employee = employee;
            //TODO
        }

        public bool IsValid()
        {
            return string.IsNullOrWhiteSpace(FirstName) == false
                && string.IsNullOrWhiteSpace(LastName) == false
                && string.IsNullOrWhiteSpace(DepartmentName) == false;
        }

        //TODO
    }
}
