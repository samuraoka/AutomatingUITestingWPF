using FluentNHibernate;
using Northwind.Logic.Common;

namespace Northwind.Logic.Model
{
    public class ProjectMap : EntityMap<Project>
    {
        public ProjectMap()
        {
            Map(x => x.Name);
            Map(x => x.Stage).CustomType<int>();
            Map(x => x.Price);

            HasMany<ProjectInvolvement>(
                Reveal.Member<Project>("InvolvementsInternal"))
                .Not.LazyLoad()
                .Inverse()
                .Cascade.None();
        }
    }
}
