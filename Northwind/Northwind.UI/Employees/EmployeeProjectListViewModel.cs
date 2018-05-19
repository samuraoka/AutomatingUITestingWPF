using Northwind.Logic.Model;
using Northwind.UI.Common;
using System;
using System.Collections.Generic;

namespace Northwind.UI.Employees
{
    public class EmployeeProjectListViewModel : ViewModel
    {
        private EmployeeRepository _repository;
        private readonly Employee _employee;

        public Command AddProjectCommand { get; private set; }
        public Command<ProjectInvolvement> DeleteProjectCommand { get; private set; }

        public IReadOnlyList<ProjectInvolvement> Projects
        {
            get { return _employee.Involvements; }
        }

        public override string Caption
        {
            get { return "Projects"; }
        }

        public EmployeeProjectListViewModel(Employee employee)
        {
            _repository = new EmployeeRepository();
            _employee = employee;

            AddProjectCommand = new Command(AddProject);
            DeleteProjectCommand =
                new Command<ProjectInvolvement>(x => x != null, DeleteProject);
        }

        private void AddProject()
        {
            if (_repository.IsEmployeeHeadOfDepartment(_employee))
            {
                CustomMessageBox.ShowError("The employee is a Head of Department. A Head of Department can't have projects assigned.");
                return;
            }

            var viewModel = new NewEmployeeProjectViewModel(_employee);

            if (_dialogService.ShowDialog(viewModel) == true)
            {
                //TODO next
                throw new NotImplementedException();
            }
        }

        private void DeleteProject(ProjectInvolvement obj)
        {
            //TODO
            throw new NotImplementedException();
        }
    }
}
