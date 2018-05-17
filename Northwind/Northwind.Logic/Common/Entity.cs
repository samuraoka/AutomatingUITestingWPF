using NHibernate;
using System;

namespace Northwind.Logic.Common
{
    public abstract class Entity : IEquatable<Entity>
    {
        public virtual long Id { get; protected set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as Entity);
        }

        public bool Equals(Entity compareTo)
        {
            if (ReferenceEquals(compareTo, null))
            {
                return false;
            }

            if (ReferenceEquals(this, compareTo))
            {
                return true;
            }

            if (GetRealType() != compareTo.GetRealType())
            {
                return false;
            }

            if (!IsTransient() && !compareTo.IsTransient() && Id == compareTo.Id)
            {
                return true;
            }

            return false;
        }

        public static bool operator ==(Entity a, Entity b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
            {
                return true;
            }

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
            {
                return false;
            }

            return a.Equals(b);
        }

        public static bool operator !=(Entity a, Entity b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return (GetRealType().ToString() + Id).GetHashCode();
        }

        public virtual bool IsTransient()
        {
            return Id == 0;
        }

        public virtual Type GetRealType()
        {
            // NHibernate
            // https://www.nuget.org/packages/NHibernate/
            // Install-Package -Id NHibernate -Project Northwind.Logic 
            return NHibernateUtil.GetClass(this);
        }
    }
}
