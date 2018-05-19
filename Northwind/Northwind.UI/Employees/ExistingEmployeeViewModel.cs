using Northwind.Logic.Model;
using Northwind.UI.Common;

namespace Northwind.UI.Employees
{
    public class ExistingEmployeeViewModel : ViewModel
    {
        //TODO
        public Employee Employee { get; private set; }
        //TODO

        public override double Width
        {
            get { return 650; }
        }

        public override double Height
        {
            get { return 400; }
        }

        public ExistingEmployeeViewModel(Employee employee)
        {
            //TODO
            Employee = employee;
            //TODO
        }

        //TODO
    }
}
