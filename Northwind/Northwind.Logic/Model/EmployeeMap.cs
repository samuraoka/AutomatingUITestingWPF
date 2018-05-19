using FluentNHibernate;
using Northwind.Logic.Common;

namespace Northwind.Logic.Model
{
    public class EmployeeMap : EntityMap<Employee>
    {
        public EmployeeMap()
        {
            Map(x => x.FirstName);
            Map(x => x.LastName);
            Map(x => x.IsFullTimer);
            Map(x => x.About).Nullable();

            References(x => x.Department).Not.LazyLoad();

            HasMany<ProjectInvolvement>(
                Reveal.Member<Employee>("InvolvementsInternal"))
                .Not.LazyLoad()
                .Inverse()
                .Cascade.AllDeleteOrphan();
        }
    }
}
