using Northwind.Logic.Model;
using Northwind.UI.Common;

namespace Northwind.UI.Employees
{
    public class NewEmployeeProjectViewModel : ViewModel
    {
        private readonly Employee _employee;
        //TODO

        public override string Caption
        {
            get { return $"New project for employee: {_employee.Name}"; }
        }

        public override double Width
        {
            get { return 500; }
        }

        public override double Height
        {
            get { return 400; }
        }

        public NewEmployeeProjectViewModel(Employee employee)
        {
            //TODO
            _employee = employee;

            //TODO
        }

        //TODO
    }
}
