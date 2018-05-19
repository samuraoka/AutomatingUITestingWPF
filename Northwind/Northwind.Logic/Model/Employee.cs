using Northwind.Logic.Common;

namespace Northwind.Logic.Model
{
    public class Employee : Entity
    {
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string About { get; set; }
        public virtual Department Department { get; set; }
        public virtual bool IsFullTimer { get; set; }

        //TODO

        public virtual string Name
        {
            get { return $"{FirstName} {LastName}"; }
        }

        //TODO
    }
}
