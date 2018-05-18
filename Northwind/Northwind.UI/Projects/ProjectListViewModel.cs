﻿using Northwind.Logic.Model;
using Northwind.UI.Common;
using System;
using System.Collections.ObjectModel;

namespace Northwind.UI.Projects
{
    public class ProjectListViewModel : ViewModel
    {
        private readonly ProjectRepository _repository;
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
            _repository = new ProjectRepository();
            RefreshAll();

            AddProjectCommand = new Command(AddProject);
            EditProjectCommand = new Command<ProjectDto>(
                x => x != null, EditProject);
            DeleteProjectCommand = new Command<ProjectDto>(
                x => x != null, DeleteProject);
        }

        public override void RefreshAll()
        {
            Projects = new ObservableCollection<ProjectDto>(
                _repository.GetProjectDtoList());
        }

        private void AddProject()
        {
            var viewModel = new NewProjectViewModel();

            if (_dialogService.ShowDialog(viewModel) == true)
            {
                var dto = _repository.GetProjectDto(viewModel.Project.Id);
                Projects.Add(dto);
            }
        }

        private void EditProject(ProjectDto obj)
        {
            //TODO next
            throw new NotImplementedException();
        }

        private void DeleteProject(ProjectDto obj)
        {
            //TODO
            throw new NotImplementedException();
        }
    }
}
