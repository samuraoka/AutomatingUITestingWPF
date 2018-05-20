using Northwind.Logic.Common;
using System.Collections.Generic;
using System.Linq;

namespace Northwind.Logic.Model
{
    public class Employee : Entity
    {
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string About { get; set; }
        public virtual Department Department { get; set; }
        public virtual bool IsFullTimer { get; set; }

        protected virtual IList<ProjectInvolvement> InvolvementsInternal { get; set; }
        public virtual IReadOnlyList<ProjectInvolvement> Involvements
        {
            get { return InvolvementsInternal.ToList(); }
        }

        public virtual IReadOnlyList<Project> Projects
        {
            get { return InvolvementsInternal.Select(x => x.Project).ToList(); }
        }

        public virtual string Name
        {
            get { return $"{FirstName} {LastName}"; }
        }

        public virtual Project MainProject
        {
            get
            {
                return InvolvementsInternal.SingleOrDefault(
                    x => x.IsMainForEmployee)?.Project;
            }
        }

        public Employee()
        {
            IsFullTimer = true;
        }

        public virtual void DeleteProject(ProjectInvolvement project)
        {
            if (Involvements.Contains(project) == false)
            {
                return;
            }

            InvolvementsInternal.Remove(project);
        }

        public virtual void AddProject(ProjectInvolvement project)
        {
            if (Involvements.Contains(project))
            {
                return;
            }

            InvolvementsInternal.Add(project);
        }

        public virtual bool HasMainProject()
        {
            return MainProject != null;
        }
    }
}
