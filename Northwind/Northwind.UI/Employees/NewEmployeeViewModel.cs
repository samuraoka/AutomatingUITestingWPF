using System;
using Northwind.Logic.Model;
using Northwind.UI.Common;

namespace Northwind.UI.Employees
{
    public class NewEmployeeViewModel : ViewModel
    {
        //TODO
        public EmployeeMainPropertiesViewModel
            MainProperties { get; private set; }
        public Employee Employee { get; private set; }
        //TODO
        public Command OkCommand { get; private set; }
        public Command CancelCommand { get; private set; }

        public override string Caption
        {
            get { return "New employee"; }
        }

        public override double Width
        {
            get { return 500; }
        }

        public override double Height
        {
            get { return 400; }
        }

        public NewEmployeeViewModel()
        {
            //TODO
            Employee = new Employee();
            MainProperties = new EmployeeMainPropertiesViewModel(Employee);

            OkCommand = new Command(() => MainProperties.IsValid(), Save);
            CancelCommand = new Command(() => DialogResult = false);
        }

        private void Save()
        {
            //TODO
            throw new NotImplementedException();
        }
    }
}
