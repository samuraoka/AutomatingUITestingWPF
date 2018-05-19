using Northwind.Logic.Model;
using Northwind.UI.Common;
using System.Collections.Generic;

namespace Northwind.UI.Employees
{
    public class ChangeDepartmentViewModel : ViewModel
    {
        public IList<DepartmentDto> Departments { get; private set; }
        public DepartmentDto SelectedDepartment { get; set; }
        public Command<DepartmentDto> OkCommand { get; private set; }
        public Command CancelCommand { get; private set; }

        public override string Caption
        {
            get { return "Change department"; }
        }

        public ChangeDepartmentViewModel()
        {
            var repository = new DepartmentRepository();
            Departments = repository.GetDepartmentDtoList();
            OkCommand = new Command<DepartmentDto>(
                d => d != null, _ => DialogResult = true);
            CancelCommand = new Command(() => DialogResult = false);
        }
    }
}
