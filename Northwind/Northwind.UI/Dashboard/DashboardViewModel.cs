using Northwind.Logic.Model;
using Northwind.UI.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Northwind.UI.Dashboard
{
    public class DashboardViewModel : ViewModel
    {
        private readonly DepartmentRepository _departmentRepository;
        private readonly EmployeeRepository _employeeRepository;
        private readonly ProjectRepository _projectRepository;

        public override string Caption
        {
            get { return "Dashboard"; }
        }

        public int NumberOfProjects { get; private set; }
        public int NumberOfEmployeesOnProjects { get; private set; }
        public int EmployeesOnBench { get; private set; }
        public int NumberOfEmployees { get; private set; }
        public int FullTimers { get; private set; }
        public int PartTimers { get; private set; }
        public int ProjectsPresale { get; private set; }
        public int ProjectsPresalePrice { get; private set; }
        public int ProjectsDevelopment { get; private set; }
        public int ProjectsDevelopmentPrice { get; private set; }
        public int ProjectsClosed { get; private set; }
        public int ProjectsClosedPrice { get; private set; }

        public DashboardViewModel()
        {
            _departmentRepository = new DepartmentRepository();
            _employeeRepository = new EmployeeRepository();
            _projectRepository = new ProjectRepository();

            RefreshAll();
        }

        public override void RefreshAll()
        {
            IReadOnlyList<Project> allProjects =
                _projectRepository.GetProjectList();
            IReadOnlyList<Employee> allEmployees =
                _employeeRepository.GetEmployeeList();
            IReadOnlyList<Department> allDepartments =
                _departmentRepository.GetDepartmentList();

            NumberOfProjects = allProjects.Count;
            NumberOfEmployeesOnProjects =
                allEmployees.Count(x => x.Involvements.Any());
            EmployeesOnBench =
                allEmployees.Count(x => x.Involvements.Any() == false
                && allDepartments.Any(y => y.Head == x) == false);

            NumberOfEmployees = allEmployees.Count;
            FullTimers = allEmployees.Count(x => x.IsFullTimer);
            PartTimers = allEmployees.Count(x => x.IsFullTimer == false);

            Tuple<int, int> presale =
                GetProjectsStats(allProjects, ProjectStage.Presale);
            ProjectsPresale = presale.Item1;
            ProjectsPresalePrice = presale.Item2;

            Tuple<int, int> development =
                GetProjectsStats(allProjects, ProjectStage.Development);
            ProjectsDevelopment = development.Item1;
            ProjectsDevelopmentPrice = development.Item2;

            Tuple<int, int> closed =
                GetProjectsStats(allProjects, ProjectStage.Closed);
            ProjectsClosed = closed.Item1;
            ProjectsClosedPrice = closed.Item2;
        }

        private Tuple<int, int> GetProjectsStats(
            IReadOnlyList<Project> allProjects, ProjectStage stage)
        {
            int count = allProjects
                .Count(x => x.Stage == stage);
            int price = allProjects
                .Where(x => x.Stage == stage)
                .Sum(x => x.Price);

            return new Tuple<int, int>(count, price);
        }
    }
}
