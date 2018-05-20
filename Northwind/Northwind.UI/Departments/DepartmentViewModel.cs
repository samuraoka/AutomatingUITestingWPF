using Northwind.Logic.Model;
using Northwind.UI.Common;
using System;

namespace Northwind.UI.Departments
{
    public class DepartmentViewModel : ViewModel
    {
        private readonly DepartmentRepository _repository;

        //TODO relevant to a head of department
        public Department Department { get; private set; }
        public Command OkCommand { get; private set; }
        public Command CancelCommand { get; private set; }

        public string Name
        {
            get { return Department.Name; }
            set { Department.Name = value; }
        }

        //TODO relevant to a head of department

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

        public DepartmentViewModel(Department department)
        {
            _repository = new DepartmentRepository();
            //TODO relevant to a head of department
            Department = department;

            OkCommand = new Command(() => !string.IsNullOrWhiteSpace(Name), Save);
            CancelCommand = new Command(() => DialogResult = false);
        }

        private void Save()
        {
            _repository.Save(Department);
            DialogResult = true;
        }
    }
}
