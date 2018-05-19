using Northwind.Logic.Model;
using Northwind.UI.Common;
using System;
using System.Collections.Generic;

namespace Northwind.UI.Employees
{
    public class EmployeeProjectListViewModel : ViewModel
    {
        //TODO
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
            //TODO
            _employee = employee;

            AddProjectCommand = new Command(AddProject);
            DeleteProjectCommand =
                new Command<ProjectInvolvement>(x => x != null, DeleteProject);
        }

        private void AddProject()
        {
            //TODO next
            throw new NotImplementedException();
        }

        private void DeleteProject(ProjectInvolvement obj)
        {
            //TODO
            throw new NotImplementedException();
        }
    }
}
