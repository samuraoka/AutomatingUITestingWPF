using Northwind.Logic.Common;
using System.Collections.Generic;

namespace Northwind.Logic.Model
{
    public class Project : Entity
    {
        public virtual string Name { get; set; }
        public virtual ProjectStage Stage { get; set; }
        public virtual int Price { get; set; }

        protected virtual IList<ProjectInvolvement> InvolvementsInternal
        { get; set; }
        //TODO

        public Project()
        {
            Stage = ProjectStage.Presale;
        }

        public virtual void Promote()
        {
            switch (Stage)
            {
                case ProjectStage.Presale:
                    Stage = ProjectStage.Development;
                    break;

                case ProjectStage.Development:
                    Stage = ProjectStage.Closed;
                    break;
            }
        }
    }
}
