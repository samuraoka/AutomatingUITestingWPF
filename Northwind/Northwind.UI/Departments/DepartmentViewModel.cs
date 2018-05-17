using Northwind.Logic.Model;
using Northwind.UI.Common;
using System;

namespace Northwind.UI.Departments
{
    public class DepartmentViewModel : ViewModel
    {
        //TODO
        public Department Department { get; private set; }
        public Command OkCommand { get; private set; }
        public Command CancelCommand { get; private set; }

        public string Name
        {
            get { return Department.Name; }
            set { Department.Name = value; }
        }

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

            OkCommand = new Command(() => !string.IsNullOrWhiteSpace(Name), Save);
            CancelCommand = new Command(() => DialogResult = false);
        }

        private void Save()
        {
            //TODO
            throw new NotImplementedException();
        }
    }
}
