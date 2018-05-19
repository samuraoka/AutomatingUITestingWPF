using Northwind.Logic.Common;

namespace Northwind.Logic.Model
{
    public class Employee : Entity
    {
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        //TODO
        public virtual Department Department { get; set; }
        //TODO
    }
}
