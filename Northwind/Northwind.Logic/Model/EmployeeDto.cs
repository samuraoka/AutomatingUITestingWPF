namespace Northwind.Logic.Model
{
    public class EmployeeDto
    {
        public long Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string DepartmentName { get; private set; }

        public EmployeeDto(long id,
            string firstName, string lastName, string departmentName)
        {
            FirstName = firstName;
            Id = id;
            LastName = lastName;
            DepartmentName = departmentName;
        }

        public EmployeeDto(Employee employee)
            : this(employee.Id, employee.FirstName,
                  employee.LastName, employee.Department.Name)
        {
        }
    }
}
