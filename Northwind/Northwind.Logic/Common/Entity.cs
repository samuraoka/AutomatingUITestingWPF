using NHibernate;
using System;

namespace Northwind.Logic.Common
{
    public abstract class Entity
    {
        public virtual long Id { get; protected set; }

        // NHibernate: Reasons for overriding Equals and GetHashCode
        // https://stackoverflow.com/questions/5851398/nhibernate-reasons-for-overriding-equals-and-gethashcode
        public override bool Equals(object obj)
        {
            var compareTo = obj as Entity;

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
            // Install-Package -Id NHibernate -Project Northwind.UI 
            return NHibernateUtil.GetClass(this);
        }
    }
}
