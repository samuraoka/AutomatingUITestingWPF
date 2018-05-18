using Northwind.Logic.Common;

namespace Northwind.Logic.Model
{
    public class DepartmentMap : EntityMap<Department>
    {
        public DepartmentMap()
        {
            Map(x => x.Name);
            References(x => x.Head).Nullable().Not.LazyLoad();
        }
    }
}
