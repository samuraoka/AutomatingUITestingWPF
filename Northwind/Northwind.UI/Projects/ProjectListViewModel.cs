using Northwind.Logic.Model;
using Northwind.UI.Common;
using System;
using System.Collections.ObjectModel;

namespace Northwind.UI.Projects
{
    public class ProjectListViewModel : ViewModel
    {
        //TODO
        public Command AddProjectCommand { get; private set; }
        public Command<ProjectDto> EditProjectCommand { get; private set; }
        public Command<ProjectDto> DeleteProjectCommand { get; private set; }
        public ObservableCollection<ProjectDto> Projects { get; private set; }

        public override string Caption
        {
            get { return "Projects"; }
        }

        public ProjectListViewModel()
        {
            //TODO

            AddProjectCommand = new Command(AddProject);
            EditProjectCommand = new Command<ProjectDto>(
                x => x != null, EditProject);
            DeleteProjectCommand = new Command<ProjectDto>(
                x => x != null, DeleteProject);
        }

        //TODO

        private void AddProject()
        {
            var viewModel = new NewProjectViewModel();

            if (_dialogService.ShowDialog(viewModel) == true)
            {
                //TODO
                throw new NotImplementedException();
            }
        }

        private void EditProject(ProjectDto obj)
        {
            //TODO
            throw new NotImplementedException();
        }

        private void DeleteProject(ProjectDto obj)
        {
            //TODO
            throw new NotImplementedException();
        }
    }
}
