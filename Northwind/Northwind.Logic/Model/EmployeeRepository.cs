using Northwind.Logic.Common;
using Northwind.Logic.Utils;
using System.Collections.Generic;
using System.Linq;

namespace Northwind.Logic.Model
{
    public class EmployeeRepository : Repository<Employee>
    {
        public EmployeeDto GetEmployeeDto(long id)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var emp = unitOfWork.Query<Employee>()
                    .Single(e => e.Id == id);

                return new EmployeeDto(emp);
            }
        }

        public IReadOnlyList<EmployeeDto> GetEmployeeDtoList()
        {
            return GetEmployeeList()
                .Select(x => new EmployeeDto(x))
                .ToList();
        }

        private IReadOnlyList<Employee> GetEmployeeList()
        {
            using (var unitOfWork = new UnitOfWork())
            {
                return unitOfWork.Query<Employee>().ToList();
            }
        }

        //TODO
    }
}
