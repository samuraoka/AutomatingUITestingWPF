using Northwind.Logic.Model;
using Northwind.UI.Common;
using System.Collections.Generic;

namespace Northwind.UI.Projects
{
    public class ProjectEmployeeListViewModel : ViewModel
    {
        private readonly Project _project;

        public IReadOnlyList<ProjectInvolvement> Employees
        {
            get { return _project.Involvements; }
        }

        public override string Caption
        {
            get { return "Employees"; }
        }

        public ProjectEmployeeListViewModel(Project project)
        {
            _project = project;
        }
    }
}
