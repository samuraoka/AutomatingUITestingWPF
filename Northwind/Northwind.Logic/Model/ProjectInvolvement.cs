using Northwind.Logic.Common;

namespace Northwind.Logic.Model
{
    public class ProjectInvolvement : Entity
    {
        public virtual Project Project { get; protected set; }
        //TODO public virtual Employee Employee { get; protected set; }
        public virtual Role Role { get; protected set; }
        public virtual bool IsMainForEmployee { get; protected set; }

        //TODO
        //protected ProjectInvolvement()
        //{
        //}

        //public ProjectInvolvement(Project project,
        //    Employee employee, Role role, bool isMainForEmployee)
        //    : this()
        //{
        //    Project = project;
        //    Employee = employee;
        //    Role = role;
        //    IsMainForEmployee = isMainForEmployee;
        //}
    }
}
