using Northwind.Logic.Model;
using Northwind.UI.Common;

namespace Northwind.UI.Employees
{
    public class EmployeeMainPropertiesViewModel : ViewModel
    {
        private readonly Employee _employee;
        private readonly DepartmentRepository _departmentRepository;

        public Command ChangeDepartmentCommand { get; private set; }

        public string FirstName
        {
            get { return _employee.FirstName; }
            set { _employee.FirstName = value; }
        }

        public string LastName
        {
            get { return _employee.LastName; }
            set { _employee.LastName = value; }
        }

        public bool IsFullTimer
        {
            get { return _employee.IsFullTimer; }
            set { _employee.IsFullTimer = value; }
        }

        public string About
        {
            get { return _employee.About; }
            set { _employee.About = value; }
        }

        public string DepartmentName
        {
            get
            {
                return _employee.Department == null
                  ? string.Empty : _employee.Department.Name;
            }
        }

        public override string Caption
        {
            get { return "Main properties"; }
        }

        public EmployeeMainPropertiesViewModel(Employee employee)
        {
            _departmentRepository = new DepartmentRepository();
            _employee = employee;

            ChangeDepartmentCommand = new Command(ChangeDepartment);
        }

        public bool IsValid()
        {
            return string.IsNullOrWhiteSpace(FirstName) == false
                && string.IsNullOrWhiteSpace(LastName) == false
                && string.IsNullOrWhiteSpace(DepartmentName) == false;
        }

        private void ChangeDepartment()
        {
            var viewModel = new ChangeDepartmentViewModel();

            if (_dialogService.ShowDialog(viewModel) == true)
            {
                _employee.Department = _departmentRepository.GetById(
                    viewModel.SelectedDepartment.Id);
                Notify(() => DepartmentName);
            }
        }
    }
}
