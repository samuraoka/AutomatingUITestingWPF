using Northwind.Logic.Model;
using Northwind.UI.Common;

namespace Northwind.UI.Projects
{
    public class NewProjectViewModel : ViewModel
    {
        private readonly ProjectRepository _repository;
        public ProjectMainPropertiesViewModel MainProperties { get; private set; }
        public Project Project { get; private set; }
        public Command OkCommand { get; private set; }
        public Command CancelCommand { get; private set; }

        public override string Caption
        {
            get { return "New project"; }
        }

        public override double Width
        {
            get { return 400; }
        }

        public override double Height
        {
            get { return 238; }
        }

        public NewProjectViewModel()
        {
            _repository = new ProjectRepository();
            Project = new Project();
            MainProperties = new ProjectMainPropertiesViewModel(Project);

            OkCommand = new Command(() => MainProperties.IsValid(), Save);
            CancelCommand = new Command(() => DialogResult = false);
        }

        private void Save()
        {
            _repository.Save(Project);
            DialogResult = true;
        }
    }
}
