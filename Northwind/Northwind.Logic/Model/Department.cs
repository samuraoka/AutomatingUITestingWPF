using Northwind.Logic.Common;

namespace Northwind.Logic.Model
{
    public class Department : Entity
    {
        public virtual string Name { get; set; }
        public virtual Employee Head { get; set; }
    }
}
