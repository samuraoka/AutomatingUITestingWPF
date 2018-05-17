using Northwind.Logic.Model;
using Northwind.UI.Common;

namespace Northwind.UI.Departments
{
    public class DepartmentViewModel : ViewModel
    {
        //TODO
        public Department Department { get; private set; }
        //TODO

        public override string Caption
        {
            get
            {
                return Department.IsTransient() ?
                    "New department" : $"Department: {Department.Name}";
            }
        }

        public override double Height
        {
            get { return 146; }
        }

        //TODO

        public DepartmentViewModel(Department department)
        {
            //TODO
            Department = department;
            //TODO
        }
    }
}
