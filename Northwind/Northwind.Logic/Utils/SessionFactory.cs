using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.AcceptanceCriteria;
using FluentNHibernate.Conventions.Helpers;
using FluentNHibernate.Conventions.Inspections;
using FluentNHibernate.Conventions.Instances;
using FluentNHibernate.Mapping;
using NHibernate;
using System.Reflection;

namespace Northwind.Logic.Utils
{
    public static class SessionFactory
    {
        private static ISessionFactory _factory;

        internal static ISession OpenSession()
        {
            return _factory.OpenSession();
        }

        public static void Init(string connectionString)
        {
            _factory = BuildSessionFactory(connectionString);
        }

        private static ISessionFactory BuildSessionFactory(string connectionString)
        {
            // FluentNHibernate
            // https://www.nuget.org/packages/FluentNHibernate/
            // Install-Package -Id FluentNHibernate -Project Northwind.Logic
            // Install-Package -Id FluentNHibernate -Project Northwind.UI
            //
            // Configuration - Fluent NHibernate in a Nutshell
            // https://github.com/FluentNHibernate/fluent-nhibernate/wiki/Getting-started#configuration
            var configuration = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012.ConnectionString(
                    connectionString))
                .Mappings(m => m.FluentMappings
                .AddFromAssembly(Assembly.GetExecutingAssembly())
                .Conventions.Add(
                    ForeignKey.EndsWith("ID"),
                    ConventionBuilder.Property.When(criteria =>
                    criteria.Expect(x => x.Nullable, Is.Not.Set),
                    x => x.Not.Nullable()))
                .Conventions.Add<OtherConversion>()
                .Conventions.Add<TableNameConvention>()
                .Conventions.Add<HiLoConvention>()
                //.ExportTo(@"C:\Temp\")
            );

            return configuration.BuildSessionFactory();
        }

        public static void Dispose()
        {
            if (_factory == null)
            {
                return;
            }

            _factory.Close();
            _factory = null;
        }

        private class OtherConversion : IHasManyConvention, IReferenceConvention
        {
            public void Apply(IOneToManyCollectionInstance instance)
            {
                instance.LazyLoad();
                instance.AsBag();
                instance.Cascade.SaveUpdate();
                instance.Inverse();
            }

            public void Apply(IManyToOneInstance instance)
            {
                instance.LazyLoad(Laziness.Proxy);
                instance.Cascade.None();
                instance.Not.Nullable();
            }
        }

        private class TableNameConvention
            : IClassConvention, IClassConventionAcceptance
        {
            public void Accept(IAcceptanceCriteria<IClassInspector> criteria)
            {
                criteria.Expect(x => string.IsNullOrEmpty(x.TableName));
            }

            public void Apply(IClassInstance instance)
            {
                instance.Table($"[dbo].[{instance.EntityType.Name}]");
            }
        }

        private class HiLoConvention : IIdConvention
        {
            public void Apply(IIdentityInstance instance)
            {
                instance.Column(instance.EntityType.Name + "ID");
                instance.GeneratedBy.HiLo("[dbo].[Ids]", "NextHigh", "10",
                    $"EntityName = '{instance.EntityType.Name}'");
            }
        }
    }
}
