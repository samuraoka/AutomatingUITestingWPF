using Northwind.UI.Common;

namespace Northwind.UI.Projects
{
    public class NewProjectViewModel : ViewModel
    {
        //TODO
        public ProjectMainPropertiesViewModel MainProperties { get; private set; }
        //TODO

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

        //TODO
    }
}
