using Northwind.Logic.Model;
using Northwind.UI.Common;
using System;
using System.Collections.ObjectModel;

namespace Northwind.UI.Employees
{
    public class EmployeeListViewModel : ViewModel
    {
        //TODO
        public Command AddEmployeeCommand { get; private set; }
        public Command<EmployeeDto> EditEmployeeCommand { get; private set; }
        public Command<EmployeeDto> DeleteEmployeeCommand { get; private set; }
        public ObservableCollection<EmployeeDto> Employees { get; private set; }

        public override string Caption
        {
            get { return "Employees"; }
        }

        public EmployeeListViewModel()
        {
            //TODO

            AddEmployeeCommand = new Command(AddEmployee);
            EditEmployeeCommand =
                new Command<EmployeeDto>(x => x != null, EditEmployee);
            DeleteEmployeeCommand =
                new Command<EmployeeDto>(x => x != null, DeleteEmployee);
        }

        //TODO

        private void AddEmployee()
        {
            var viewModel = new NewEmployeeViewModel();

            if (_dialogService.ShowDialog(viewModel) == true)
            {
                //TODO next
                throw new NotImplementedException();
            }
        }

        private void EditEmployee(EmployeeDto employeeDto)
        {
            //TODO
            throw new NotImplementedException();
        }

        private void DeleteEmployee(EmployeeDto obj)
        {
            //TODO
            throw new NotImplementedException();
        }
    }
}
