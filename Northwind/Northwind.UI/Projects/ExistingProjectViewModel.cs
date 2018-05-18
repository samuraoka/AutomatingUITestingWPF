using Northwind.Logic.Model;
using Northwind.UI.Common;
using System;
using System.Collections.Generic;

namespace Northwind.UI.Projects
{
    public class ExistingProjectViewModel : ViewModel
    {
        //TODO
        public Project Project { get; private set; }
        public Command OkCommand { get; private set; }
        public Command CancelCommand { get; private set; }
        public List<ViewModel> Tabs { get; private set; }

        public override string Caption
        {
            get { return $"Project : {Project.Name}"; }
        }

        public override double Width
        {
            get { return 650; }
        }

        public override double Height
        {
            get { return 400; }
        }

        public ExistingProjectViewModel(Project project)
        {
            //TODO
            Project = project;

            var mainProperties = new ProjectMainPropertiesViewModel(project);
            Tabs = new List<ViewModel>
            {
                mainProperties,
                new ProjectEmployeeListViewModel(project),
            };

            OkCommand = new Command(() => mainProperties.IsValid(), Save);
            CancelCommand = new Command(() => DialogResult = false);
        }

        private void Save()
        {
            //TODO next
            throw new NotImplementedException();
        }
    }
}
