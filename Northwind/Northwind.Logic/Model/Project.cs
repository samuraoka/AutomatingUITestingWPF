using Northwind.Logic.Common;

namespace Northwind.Logic.Model
{
    public class Project : Entity
    {
        public virtual string Name { get; set; }
        public virtual ProjectStage Stage { get; set; }
        public virtual int Price { get; set; }

        //TODO

        public Project()
        {
            Stage = ProjectStage.Presale;
        }

        //TODO
    }
}
