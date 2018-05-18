using Northwind.Logic.Common;
using Northwind.Logic.Utils;
using System.Collections.Generic;
using System.Linq;

namespace Northwind.Logic.Model
{
    public class ProjectRepository : Repository<Project>
    {
        public ProjectDto GetProjectDto(long id)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var project = unitOfWork
                    .Query<Project>()
                    .Single(x => x.Id == id);

                return new ProjectDto(project);
            }
        }

        public IReadOnlyList<ProjectDto> GetProjectDtoList()
        {
            return GetProjectList()
                .Select(x => new ProjectDto(x))
                .ToList();
        }

        private IReadOnlyList<Project> GetProjectList()
        {
            using (var unitOfWork = new UnitOfWork())
            {
                return unitOfWork.Query<Project>()
                    .ToList();
            }
        }
    }
}
