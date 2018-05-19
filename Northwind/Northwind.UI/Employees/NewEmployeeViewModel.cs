using Northwind.Logic.Model;
using Northwind.UI.Common;

namespace Northwind.UI.Employees
{
    public class NewEmployeeViewModel : ViewModel
    {
        private readonly EmployeeRepository _repository;
        public EmployeeMainPropertiesViewModel MainProperties { get; private set; }
        public Employee Employee { get; private set; }
        public Command OkCommand { get; private set; }
        public Command CancelCommand { get; private set; }

        public override string Caption
        {
            get { return "New employee"; }
        }

        public override double Width
        {
            get { return 500; }
        }

        public override double Height
        {
            get { return 400; }
        }

        public NewEmployeeViewModel()
        {
            _repository = new EmployeeRepository();
            Employee = new Employee();
            MainProperties = new EmployeeMainPropertiesViewModel(Employee);

            OkCommand = new Command(() => MainProperties.IsValid(), Save);
            CancelCommand = new Command(() => DialogResult = false);
        }

        private void Save()
        {
            _repository.Save(Employee);
            DialogResult = true;
        }
    }
}
