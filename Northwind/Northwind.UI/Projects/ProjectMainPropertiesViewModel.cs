using Northwind.Logic.Model;
using Northwind.UI.Common;

namespace Northwind.UI.Projects
{
    public class ProjectMainPropertiesViewModel : ViewModel
    {
        public Project Project { get; private set; }
        public Command PromoteProjectCommand { get; private set; }
        public bool WasPromoted { get; private set; }

        public string Name
        {
            get { return Project.Name; }
            set { Project.Name = value; }
        }

        public int Price
        {
            get { return Project.Price; }
            set { Project.Price = value; }
        }

        public ProjectStage Stage
        {
            get { return Project.Stage; }
        }

        public bool CanChangeStage
        {
            get { return Project.IsTransient() == false; }
        }

        public override string Caption
        {
            get { return "Main properties"; }
        }

        public ProjectMainPropertiesViewModel(Project project)
        {
            Project = project;
            WasPromoted = project.Stage == ProjectStage.Closed;
            PromoteProjectCommand = new Command(
                () => WasPromoted == false, PromoteProject);
        }

        private void PromoteProject()
        {
            Project.Promote();
            WasPromoted = true;

            Notify(() => WasPromoted);
            Notify(() => Stage);
        }

        public bool IsValid()
        {
            return string.IsNullOrWhiteSpace(Name) == false && Price > 0;
        }
    }
}
