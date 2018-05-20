using Northwind.Logic.Model;
using Northwind.UI.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Northwind.UI.Employees
{
    public class NewEmployeeProjectViewModel : ViewModel
    {
        private readonly Employee _employee;
        private readonly ProjectRepository _repository;
        public ProjectInvolvement ProjectInvolvement { get; private set; }
        public ProjectDto SelectedProject { get; set; }
        public IReadOnlyList<ProjectDto> Projects { get; private set; }
        public Role SelectedRole { get; set; }

        public IReadOnlyList<Role> Roles
        {
            get { return Enum.GetValues(typeof(Role)).Cast<Role>().ToList(); }
        }

        public bool IsMain { get; set; }
        public Command OkCommand { get; private set; }
        public Command CancelCommand { get; private set; }

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
            _repository = new ProjectRepository();
            _employee = employee;

            Projects = _repository.GetProjectDtoList()
                .Where(x => employee.Projects.Any(y => y.Id == x.Id) == false)
                .ToList();

            OkCommand = new Command(IsValid, Save);
            CancelCommand = new Command(() => DialogResult = false);
        }

        private bool IsValid()
        {
            return SelectedRole != 0 && SelectedProject != null;
        }

        private void Save()
        {
            if (IsMain && _employee.HasMainProject())
            {
                //TODO next
                throw new NotImplementedException();
                //CustomMessageBox.ShowError(
                //    $"The employee already has a main project ({_employee.MainProject.Name}).");
            }

            var project = _repository.GetById(SelectedProject.Id);
            ProjectInvolvement = new ProjectInvolvement(
                project, _employee, SelectedRole, IsMain);

            DialogResult = true;
        }
    }
}
