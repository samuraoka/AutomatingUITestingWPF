using Northwind.Logic.Model;
using Northwind.UI.Common;

namespace Northwind.UI.Projects
{
    public class ExistingProjectViewModel : ViewModel
    {
        //TODO
        public Project Project { get; private set; }
        //TODO

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

            //TODO
        }

        //TODO
    }
}
