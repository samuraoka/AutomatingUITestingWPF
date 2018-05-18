using NHibernate.Transform;
using Northwind.Logic.Common;
using Northwind.Logic.Utils;
using System.Collections.Generic;
using System.Linq;

namespace Northwind.Logic.Model
{
    public class DepartmentRepository : Repository<Department>
    {
        public DepartmentDto GetDepartmentDto(long id)
        {
            return GetDepartmentDtoList().SingleOrDefault(x => x.Id == id);
        }

        public IList<DepartmentDto> GetDepartmentDtoList()
        {
            using (var unitOfWork = new UnitOfWork())
            {
                string text =
                    @"SELECT
                        d.DepartmentID Id,
                        d.Name,
                        ISNULL (t.[Count], 0) EmployeeCount,
                        e.FirstName + ' ' + e.LastName Head
                    FROM dbo.Department d
                    LEFT JOIN dbo.Employee e ON d.HeadID = e.EmployeeID
                    LEFT JOIN
                    (
                        SELECT e.DepartmentID, COUNT(*) [Count]
                        FROM dbo.Employee e
                        GROUP BY e.DepartmentID
                    ) t ON d.DepartmentID = t.DepartmentID";

                return unitOfWork.CreateSqlQuery(text)
                    .SetResultTransformer(Transformers.AliasToBean<DepartmentDto>())
                    .List<DepartmentDto>();
            }
        }

        //TODO
    }
}
