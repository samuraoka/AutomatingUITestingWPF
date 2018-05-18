using FluentNHibernate.Mapping;

namespace Northwind.Logic.Common
{
    //// Simple example - Fluent NHibernate in a Nutshell
    //// https://github.com/FluentNHibernate/fluent-nhibernate/wiki/Getting-started#simple-example
    public class EntityMap<T> : ClassMap<T>
        where T : Entity
    {
        public EntityMap()
        {
            Id(x => x.Id);
        }
    }
}
