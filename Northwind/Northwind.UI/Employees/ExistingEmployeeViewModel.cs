using Northwind.Logic.Model;
using Northwind.UI.Common;
using System;
using System.Collections.Generic;

namespace Northwind.UI.Employees
{
    public class ExistingEmployeeViewModel : ViewModel
    {
        //TODO
        public Employee Employee { get; private set; }
        public Command OkCommand { get; private set; }
        public Command CancelCommand { get; private set; }
        public List<ViewModel> Tabs { get; private set; }

        public override string Caption
        {
            get { return $"Employee: {Employee.Name}"; }
        }

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
            var mainProperties = new EmployeeMainPropertiesViewModel(employee);
            var projects = new EmployeeProjectListViewModel(employee);
            Tabs = new List<ViewModel>
            {
                mainProperties,
                projects,
            };

            OkCommand = new Command(() => mainProperties.IsValid(), Save);
            CancelCommand = new Command(() => DialogResult = false);
        }

        private void Save()
        {
            //TODO
            throw new NotImplementedException();
        }
    }
}
